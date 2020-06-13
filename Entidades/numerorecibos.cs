using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanEmeterio.Entidades
{
    public class numerorecibos
    {

        private int _idrecibos;

        public int Idrecibos
        {
            get { return _idrecibos; }
            set { _idrecibos = value; }
        }
        private string _nombre_recibos;

        public string Nombre_recibos
        {
            get { return _nombre_recibos; }
            set { _nombre_recibos = value; }
        }
        private int _numero_recibos;

        public int Numero_recibos
        {
            get { return _numero_recibos; }
            set { _numero_recibos = value; }
        }
        private int _copias;

        public int Copias
        {
            get { return _copias; }
            set { _copias = value; }
        }

        public numerorecibos()
        {

        }

        public numerorecibos(int idrecibos, string nombre_recibos, int numero_recibos, int copias)
        {
            this.Idrecibos = idrecibos;
            this.Nombre_recibos = nombre_recibos;
            this.Numero_recibos = numero_recibos;
            this.Copias = copias;
        }


    }
}
