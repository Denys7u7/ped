using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using capaDatos;

namespace capaDatos
{
    public class CDAsientos
    {
        CDConexion db = new CDConexion();

        public void asientosMetodo(int[] AsientosN)
        {

            for (int i = 0; i < AsientosN.Length; i++)
            {
                if (i <= 10) AsientosN[i] = 1;
                if (i <= 24 && i > 10) AsientosN[i] = 2;
                if (i <= 32 && i > 24) AsientosN[i] = 3;
            }
        }

        public bool readClientes(ListBox lista, CDcola cola)
        {

            try
            {
                String sql = "SELECT U.id, (U.nombre+ ' ' +U.apellido) as Nombre FROM usuarios U  WHERE U.licencia IS NULL AND U.cargo = 3 AND U.contrasenia IS NULL";
                db.listbox(lista, sql, cola);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al cargar perfil");
                return false;
            }

        }

    }
}
