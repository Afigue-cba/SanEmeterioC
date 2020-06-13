using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanEmeterio.Clases
{
    public class LeerTxt
    {
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    int lines = File.ReadAllLines("miarchivo.txt").Length;

        //    Random ra = new Random();
        //    int lineasrandom = ra.Next(1, lines);

        //    StreamReader archivo = File.OpenText("miarchivo.txt");
        //    string linea = null;

        //    int i = 0;

        //    while (!archivo.EndOfStream)
        //    {

        //        linea = archivo.ReadLine();
        //        if (++i == lineasrandom) break;
        //    }

        //}
        //Leer el archivo y llama al metodo agregarFilaDatagridview para que por cada linea del bloc agregue una linea en el datagridview'
        public void lecturaArchivo(DataGridView tabla, char caracter, string ruta)
        {
            StreamReader objReader = new StreamReader(ruta, System.Text.Encoding.Default, false);
            string sLine = "";
            int fila = 0;
            int campos = 33;
            tabla.Rows.Clear();
            tabla.AllowUserToAddRows = false;
            tabla.ColumnCount = campos;
            do
            {
                sLine = objReader.ReadLine();
                if ((sLine != null))
                {
                    agregarFilaDatagridview(tabla, Rutinas.Reemplaza(sLine), caracter);
                    fila += 1;
                }
            }

            while (!(sLine == null));
            objReader.Close();
        }

        //Agregar el HeaderText al datagridview(SON LOS TITULOS)'
        public static void nombrarTitulo(DataGridView tabla, string[] titulos)
        {
            int x = 0;
            for (x = 0; x <= tabla.ColumnCount - 1; x++)
            {
                tabla.Columns[x].HeaderText = titulos[x];
            }
        }

        //Agrega una fila por cada linea de Bloc de notas :D'
        public static void agregarFilaDatagridview(DataGridView tabla, string linea, char caracter)
        {
            string[] arreglo = new string[33];
            int[] posicion = { 10, 8, 25, 70, 25, 19, 8, 4, 15, 15, 15, 5, 25, 11, 15, 4, 4, 8, 8, 15, 15, 15, 25, 70, 25, 19, 5, 15, 15, 15, 25, 11, 15 };
            int start = 0;
            if (linea.Length < 580)
            {
                linea = linea + new string(' ', 580 - linea.Length);
            }
            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = linea.Substring(start, posicion[i]);
                start = posicion[i] + start;
            }
            //string[] arreglo = linea.Split(caracter);
            tabla.Rows.Add(arreglo);
        }
    }
}
