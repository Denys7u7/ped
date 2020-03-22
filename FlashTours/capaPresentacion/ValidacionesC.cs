using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    class ValidacionesC
    {
        public void noEspacios(KeyPressEventArgs e)//no permite espacios
        {
            try
            {
                if (Char.IsSeparator(e.KeyChar))//lo unico que no permite son espacios
                {
                    e.Handled = true;// por eso es true y no false
                    MessageBox.Show("No se permiten espacios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else //todo lo demas si lo permite 
                {
                    e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void soloLetras(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsLetter(e.KeyChar))//si es letra, la deja pasar
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))//si quiere borrar, lo permite
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))//si quiere dejar un espacio de por medio, lo permite
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Solo se permiten letras", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void soloNumeros(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsNumber(e.KeyChar)) //es lo mismo para numeros solo que ya no es letter, ahora es number
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))//permite borrar
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))//no permite espacios de por medio
                {
                    e.Handled = true;
                }
                else//Lo demas que no sea eso 
                {
                    e.Handled = true;
                    MessageBox.Show("Solo se permiten números", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
