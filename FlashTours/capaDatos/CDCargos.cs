using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace capaDatos
{
    public class CDCargos
    {
        private int id;
        private string cargo;

        private CDConexion conexion = new CDConexion();
        private SqlDataReader leer;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Cargo
        {
            get
            {
                return cargo;
            }

            set
            {
                cargo = value;
            }
        }

        public List<CDCargos> mostrar()
        {

            List<CDCargos> leer2 = new List<CDCargos>(); 
            SqlCommand comando = new SqlCommand("psMostrarCargos", conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            //comando.Parameters.AddWithValue("@var", this.var1);
            //comando.Parameters.AddWithValue("@var2", this.var2);
            //Si se desea insertar, modificar o eliminar cambiar la siguiente linea
            //por comando.ExecuteQuery()
            leer = comando.ExecuteReader();
            comando.Parameters.Clear();

            CDCargos crg;

            while (leer.Read())
            {
                crg = new CDCargos();
                crg.Id = leer.GetInt32(0);
                crg.Cargo = leer.GetString(1);
                leer2.Add(crg);
            }

            

            return leer2;
        }
    }
}
