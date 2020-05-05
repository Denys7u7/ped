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
    public class CDtickets
    {
        CDConexion cn = new CDConexion();

        private int id;
        private int idViaje;
        private int idCliente;
        private string nombre;
        private string destino;
        private string codigo;

        public int Id { get => id; set => id = value; }
        public int IdViaje { get => idViaje; set => idViaje = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Destino { get => destino; set => destino = value; }
        public string Codigo { get => codigo; set => codigo = value; }

        public DataTable mostrarViajes()
        {
            DataTable Consulta = new DataTable();
            try
            {
                string instruccion;
                instruccion = "select viaje,Destino,(nombre + apellido) as nombrecompleto,codigo_asiento from asientos A INNER JOIN Viajes V ON A.id_viaje = V.id_viaje INNER JOIN usuarios US ON A.id_persona = US.id WHERE A.id_viaje = @idViaje AND A.id_persona <> 0";
                SqlCommand comando = new SqlCommand(instruccion, cn.AbrirConexion());
                comando.Parameters.Add(new SqlParameter("@idViaje", SqlDbType.Int));
                comando.Parameters["@idViaje"].Value = idViaje;

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
    }
}
