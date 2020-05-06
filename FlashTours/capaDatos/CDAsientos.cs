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

        public void consultarAsientos(CDcola colaColor)
        {
            string insert;
            cn.AbrirConexion();
            insert = "SELECT colorAsiento FROM asientos WHERE id_viaje = @idViaje";
            SqlCommand insertar1;
            insertar1 = new SqlCommand(insert, cn.AbrirConexion());
            insertar1.Parameters.Add(new SqlParameter("@idViaje", SqlDbType.Int));
            insertar1.Parameters["@idViaje"].Value = idViaje;
            SqlDataAdapter mysqldt = new SqlDataAdapter(insertar1);
            DataTable dt = new DataTable();
            mysqldt.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                colaColor.Encolar(Convert.ToInt32(dr.Field<object>("colorAsiento")));
            }
            cn.CerrarConexion();
        }

        public void consultarPeople(CDcola colaPeople)
        {
            string insert;
            cn.AbrirConexion();
            insert = "SELECT id_persona FROM asientos WHERE id_viaje = @idViaje";
            SqlCommand insertar1;
            insertar1 = new SqlCommand(insert, cn.AbrirConexion());
            insertar1.Parameters.Add(new SqlParameter("@idViaje", SqlDbType.Int));
            insertar1.Parameters["@idViaje"].Value = idViaje;
            SqlDataAdapter mysqldt = new SqlDataAdapter(insertar1);
            DataTable dt = new DataTable();
            mysqldt.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                colaPeople.Encolar(Convert.ToInt32(dr.Field<object>("id_persona")));
            }
            cn.CerrarConexion();
        }

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

        public void AsignarPersonas()
        {
            try
            {
                string insert;
                cn.AbrirConexion();
                insert = "UPDATE asientos SET id_persona = @idPersona WHERE id_viaje = @idViaje AND id_asiento = @idAsiento";
                SqlCommand insertar1;
                insertar1 = new SqlCommand(insert, cn.AbrirConexion());
                insertar1.Parameters.Add(new SqlParameter("@idPersona", SqlDbType.Int));
                insertar1.Parameters["@idPersona"].Value = idPersona;
                insertar1.Parameters.Add(new SqlParameter("@idViaje", SqlDbType.Int));
                insertar1.Parameters["@idViaje"].Value = idViaje;
                insertar1.Parameters.Add(new SqlParameter("@idAsiento", SqlDbType.Int));
                insertar1.Parameters["@idAsiento"].Value = id;
                insertar1.ExecuteNonQuery();
                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar" + ex);
            }
        }
        public void consultarIdAsiento()
        {
            try
            {
                object idR;
                string insert;
                cn.AbrirConexion();
                insert = "SELECT top(1) id_asiento FROM asientos WHERE id_viaje = @idViaje";
                SqlCommand insertar1;
                insertar1 = new SqlCommand(insert, cn.AbrirConexion());
                insertar1.Parameters.Add(new SqlParameter("@idViaje", SqlDbType.Int));
                insertar1.Parameters["@idViaje"].Value = idViaje;
                idR = insertar1.ExecuteScalar();
                id = Convert.ToInt32(idR);
                cn.CerrarConexion();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo consultar el ID");
            }
        }
        public void comboViajes(ComboBox cmb)
        {
            string insert;
            cn.AbrirConexion();
            insert = "SELECT id_viaje,viaje FROM viajes WHERE estado = 1";
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


        public bool readClientes(ListBox lista, CDcola cola,CDcola nombres, int idViajes)
        {

            try
            {
                String sql = "SELECT U.id, (U.nombre+ ' ' +U.apellido) as Nombre FROM usuarios U  WHERE U.licencia IS NULL AND U.cargo = 3 AND U.contrasenia IS NULL AND idviaje = @idViaje";
                cn.listbox(lista, sql, cola,nombres,idViajes);
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
