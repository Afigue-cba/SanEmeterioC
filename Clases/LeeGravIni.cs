using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanEmeterio.Clases
{
    public class LeeGravIni
    {
        public bool SaveSetting(string FileName, string Key, string Value, string Data) //static void Main(string[] args)
        {
            string IniData = "";

            try
            {
                //primero que nada leo el archivo a ver si que datos tiene
                StreamReader streamReader = new StreamReader(@FileName);
                IniData = streamReader.ReadToEnd();
                streamReader.Close();
            }
            catch
            {
            }

            if (IniData != "")
            {//tiene datos lo proceso
                //busco ese key
                int x = IniData.ToUpper().IndexOf("[" + Key.ToUpper() + "]", 0);
                if (x != -1)
                {// encontre ese key busco ahora ese value

                    x += Key.Length + 4; // muevo x al final del ky 2 por [] y 2 por \r\n,justo ahi
                    int z = x;

                    x = IniData.ToUpper().IndexOf(Value.ToUpper(), z);
                    if (x != -1)
                    {// encontre ese value ahora busco si tiene ese data
                        // leo el data actual para luego remplazarlo
                        z = x + Value.Length + 1; // 1 por el =

                        x = IniData.IndexOf("\r\n", z);
                        if (x == -1) { return (false); } // error no encontre el dato

                        string dataActual = IniData.Substring(z, x - z);

                        if (dataActual == Data)
                        {
                            return (true); // me salgo no tengo que salvar es el mismo dato a guardar
                        }
                        else
                        { // actualizo el dato
                            string inicio = IniData.Substring(0, z);
                            string final = IniData.Substring(x, IniData.Length - x);

                            if (final.Substring((final.Length - 2), 2) == "\r\n") { final = final.Substring(0, final.Length - 2); }

                            IniData = inicio + Data + final;
                        }
                    }
                    else
                    { // no encontre ese value agrego ese value para ese key
                        // guardo las 2 partes principio y final inserto el texto y luego lo sumo todo
                        string inicio = IniData.Substring(0, z);
                        string final = IniData.Substring(z, IniData.Length - z);

                        if (final.Substring((final.Length - 2), 2) == "\r\n") { final = final.Substring(0, final.Length - 2); }

                        if (final != "") // hay mas datos al final del archivo
                        {
                            IniData = inicio + Value + "=" + Data + "\r\n" + final;
                        }
                        else
                        { // no hay mas datos al final del archivo para que sumar final, elimino el dbl enter
                            IniData = inicio + Value + "=" + Data;
                        }
                    }
                }
                else
                { // no encontre ese key lo agrego al final de archivo
                    IniData += "\r\n[" + Key.ToUpper() + "]\r\n" + Value + "=" + Data;
                }
            }
            else
            {// no tiene datos
                IniData = "[" + Key.ToUpper() + "]\r\n" + Value + "=" + Data;
            }

            try
            { //ahora salvo el ini nuevamente
                // create a writer and open the file
                TextWriter tw = new StreamWriter(@FileName);

                //quito el enter al principio
                if (IniData.Substring(0, 2) == "\r\n") { IniData = IniData.Substring(2, IniData.Length - 2); }

                // write a line of text to the file
                tw.WriteLine(IniData);

                // close the stream
                tw.Close();
                return (true);
            }
            catch
            {
                return (false);
            }
        }

        public string GetSetting(string FileName, string Key, string Value, string Default)
        {
            string IniData = "";

            try
            {
                //primero que nada leo el archivo a ver si que datos tiene
                StreamReader streamReader = new StreamReader(@FileName);
                IniData = streamReader.ReadToEnd();
                streamReader.Close();
            }
            catch
            {
                return (Default);
            }

            if (IniData != "")
            {//tiene datos lo proceso
                //busco ese key
                int x = IniData.ToUpper().IndexOf("[" + Key.ToUpper() + "]", 0);
                if (x != -1)
                {// encontre ese key busco ahora ese value

                    x += Key.Length + 4; // muevo x al final del ky 2 por [] y 2 por \r\n,justo ahi
                    int z = x;

                    x = IniData.ToUpper().IndexOf(Value.ToUpper(), z);
                    if (x != -1)
                    {// encontre ese value ahora busco si tiene ese data
                        // leo el data actual para luego remplazarlo
                        z = x + Value.Length + 1; // 1 por el =

                        x = IniData.IndexOf("\r\n", z);
                        if (x == -1) { return (Default); } // error no encontre el dato

                        return (IniData.Substring(z, x - z)); // devuelvo el valor que busco
                    }
                    else
                    { // no encontre ese value agrego ese value para ese key
                        return (Default);
                    }
                }
                else
                { // no encontre ese key lo agrego al final de archivo
                    return (Default);
                }
            }
            else
            {// no tiene datos
                return (Default);
            }
        }
    }
}
