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
    class CDConexion
    {
        private SqlCommand insert;
        private SqlConnection conexionInsert;
        //private SqlConnection Conexion = new SqlConnection(@"Server=.\SQLExpress;DataBase=ped;" + "Trusted_Connection=True;MultipleActiveResultSets=true; Persist Security Info=True");
        private SqlConnection Conexion = new SqlConnection("Data Source=localhost;Initial Catalog=ped;password=kevinG5;Integrated Security=True");
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }

        public SqlConnection conectar = new SqlConnection();

        protected SqlConnection Conectar()
        {
            AbrirConexion();
            conectar = Conexion;
            return conectar;
        }

        protected void EjecutarScript(String consulta, String[] columna, Object[] valor, SqlDbType[] tipo)
        {
            try
            {
                AbrirConexion();
                insert = new SqlCommand(consulta, conexionInsert);
                for (int i = 0; i < columna.Length; i++)
                {
                    insert.Parameters.Add(new SqlParameter(columna[i], tipo));
                    insert.Parameters[columna[i]].Value = valor[i];
                }
                insert.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception ex)
            {

            }
        }

        public void listbox(ListBox list, String query, CDcola cola)
        {
            SqlCommand comando = new SqlCommand(query, Conectar());
            AbrirConexion();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Items.Add(reader.GetString(1));
                    cola.Encolar(reader.GetString(1));
                }
            }
            CerrarConexion();
        }
    }
}
