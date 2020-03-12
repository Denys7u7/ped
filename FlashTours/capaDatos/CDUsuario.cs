using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatos
{
    public class CDUsuario
    {
        private int id { get; set; }
        private string email { get; set; }
        private string contrasenia { get; set; }
        private string nombre { get; set; }
        private string apellido { get; set; }
        private string dui { get; set; }
        private int edad { get; set; }
        private string nacionalidad { get; set; }
        private string telefono { get; set; }
        private int cargo { get; set; }
        private string licencia { get; set; }

        private CDConexion conexion = new CDConexion();
        private SqlDataReader leer;

        public CDUsuario(string email, string contrasenia)
        {
            this.email = email;
            this.contrasenia = contrasenia;
        }

        public SqlDataReader logearse()
        {
            SqlCommand comando = new SqlCommand("logearse", conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@email", this.email);
            comando.Parameters.AddWithValue("@pass", this.contrasenia);
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();
            return leer;
        }
    }
}
