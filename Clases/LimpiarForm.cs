using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanEmeterio.Clases
{
    public class LimpiarForm
    {
        public void BorrarCampos(Control control)
        {
            foreach (var txt in control.Controls)
            {
                if (txt is TextBox)
                {
                    ((TextBox)txt).Clear();
                }
                else if (txt is ComboBox)
                {
                    ((ComboBox)txt).SelectedIndex = 0;
                }
                else if (txt is DataGridView)
                {
                    ((DataGridView)txt).DataSource = null;
                }
            }
            //foreach (var combo in gb.Controls)
            //{
            //    if (combo is TextBox)
            //    {
            //        ((TextBox)combo).Clear();
            //    }
            //    else if (combo is ComboBox)
            //    {
            //        ((ComboBox)combo).SelectedIndex = 0;
            //    }
            //}

        }

        public void CambioColor(Control control)
        {
            ColorDialog cd = new ColorDialog();
            foreach (var ItemForm in control.Controls)
            {
                if (ItemForm is Panel)
                {
                    ((Panel)ItemForm).BackColor = cd.Color;
                }
            }
        }
    }
}
