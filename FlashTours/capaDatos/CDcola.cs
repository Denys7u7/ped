using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaDatos;

namespace capaDatos
{
    public class CDcola
    {
         CDnodo primero;
         CDnodo ultimo;

        public CDcola()
        {
            primero = ultimo = null;
        }
        public void Encolar(Object valor)
        {
            CDnodo aux = new CDnodo();
            aux.info = valor;
            if (primero == null)
            {
                primero = ultimo = aux;
                aux.sgte = null;
            }
            else
            {
                ultimo.sgte = aux;
                aux.sgte = null;
                ultimo = aux;
            }
        }
        public void Desencolar()
        {
            if (primero == null) MessageBox.Show("CDcola vacia");
            else primero = primero.sgte;
        }
        public Object DesenCDcolarValor()
        {
            Object valor = "";
            if (primero == null) return null;
            else
            {
                valor = primero.info;
                primero = primero.sgte;
            }
            return valor;
        }

        public void Mostrar()
        {
            if (primero == null) MessageBox.Show("CDcola vacia");
            else
            {
                CDnodo puntero;
                puntero = primero;

                do
                {
                    MessageBox.Show(Convert.ToString(puntero.info));
                    puntero = puntero.sgte;
                } while (puntero != null);
            }

        }
    }
}
