using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaDatos
{
    public class CDAsientos
    {
        CDConexion cn = new CDConexion();
        private int id;
        private int idViaje;
        private string destino;
        private int color;
        private int idPersona;
        private string codigoAsiento;

        public int Id { get => id; set => id = value; }
        public int IdViaje { get => idViaje; set => idViaje = value; }
        public string Destino { get => destino; set => destino = value; }
        public int Color { get => color; set => color = value; }
        public int IdPersona { get => idPersona; set => idPersona = value; }
        public string CodigoAsiento { get => codigoAsiento; set => codigoAsiento = value; }

        public void AsignarAsiento()
        {
                try
                {
                    string insert;
                    cn.AbrirConexion();
                    insert = "UPDATE top(1) asientos SET Destino = @Destinos, colorAsiento = @color WHERE id_viaje = @idViaje AND Destino = 'NULL'";
                    SqlCommand insertar1;
                    insertar1 = new SqlCommand(insert, cn.AbrirConexion());
                    insertar1.Parameters.Add(new SqlParameter("@Destinos", SqlDbType.VarChar));
                    insertar1.Parameters["@Destinos"].Value = destino;
                    insertar1.Parameters.Add(new SqlParameter("@color", SqlDbType.Int));
                    insertar1.Parameters["@color"].Value = color;
                    insertar1.Parameters.Add(new SqlParameter("@idViaje", SqlDbType.Int));
                    insertar1.Parameters["@idViaje"].Value = idViaje;
                    insertar1.ExecuteNonQuery();
                    cn.CerrarConexion();
                }
                catch (Exception ex)
                {
                MessageBox.Show("Error al ingresar" + ex);
            }           
        }
        public void comboViajes(ComboBox cmb)
        {
            string insert;
            cn.AbrirConexion();
            insert = "SELECT id_viaje,viaje FROM viajes";
            SqlCommand insertar1;
            insertar1 = new SqlCommand(insert, cn.AbrirConexion());
            SqlDataAdapter mysqldt = new SqlDataAdapter(insertar1);
            DataTable dt = new DataTable();
            mysqldt.Fill(dt);
            cmb.ValueMember = "id_viaje";
            cmb.DisplayMember = "viaje";
            cmb.DataSource = dt;
            cn.CerrarConexion();
        }

        public DataTable mostrarViajes()
        {
            DataTable Consulta = new DataTable();

            string instruccion;
            instruccion = "select id_viaje,lugar, placa,nombre from Viajes V INNER JOIN Ruta R ON V.id_ruta = R.id_ruta  INNER JOIN bus B ON V.id_bus = B.id INNER JOIN usuarios U	ON V.id_conductor = U.id WHERE   estado = 1";
            SqlCommand comando = new SqlCommand(instruccion, cn.AbrirConexion());
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(Consulta);
                return Consulta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
                return Consulta;
            }
            finally
            {
                cn.CerrarConexion();
            }
        }

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
                cn.listbox(lista, sql, cola);
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
