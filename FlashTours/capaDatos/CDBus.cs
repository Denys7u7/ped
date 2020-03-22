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
    public class CDBus
    {
        private CDConexion conexion = new CDConexion();
        private int id;
        private string placa;
        private int color;
        private int marca;
        private int capacidad;
        private string caracteristicas;

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

        public string Placa
        {
            get
            {
                return placa;
            }

            set
            {
                placa = value;
            }
        }

        public int Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        public int Marca
        {
            get
            {
                return marca;
            }

            set
            {
                marca = value;
            }
        }

        public int Capacidad
        {
            get
            {
                return capacidad;
            }

            set
            {
                capacidad = value;
            }
        }

        public string Caracteristicas
        {
            get
            {
                return caracteristicas;
            }

            set
            {
                caracteristicas = value;
            }
        }

        public CDBus()
        {
        }

        public CDBus(int id, string placa, int color, int marca, int capacidad, string caracteristicas)
        {
            this.id = id;
            this.placa = placa;
            this.color = color;
            this.marca = marca;
            this.capacidad = capacidad;
            this.caracteristicas = caracteristicas;
        }

        public CDBus(string placa, int color, int marca, int capacidad, string caracteristicas)
        {
            this.placa = placa;
            this.color = color;
            this.marca = marca;
            this.capacidad = capacidad;
            this.caracteristicas = caracteristicas;
        }

        public CDBus(int id)
        {
            this.id = id;
        }

        public void insertar(/*string placa, int color, int marca, int capacidad, string caracteristicas*/)
        {
            SqlCommand comando = new SqlCommand("insertarBus", conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@placa", this.placa);
            comando.Parameters.AddWithValue("@color", this.color);
            comando.Parameters.AddWithValue("@marca", this.marca);
            comando.Parameters.AddWithValue("@capacidad", this.capacidad);
            comando.Parameters.AddWithValue("@caracteristicas", this.caracteristicas);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void modificar(/*int id, string placa, int color, int marca, int capacidad, string caracteristicas*/)
        {
            SqlCommand comando = new SqlCommand("modificarBus", conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", this.id);
            comando.Parameters.AddWithValue("@placa", this.placa);
            comando.Parameters.AddWithValue("@color", this.color);
            comando.Parameters.AddWithValue("@marca", this.marca);
            comando.Parameters.AddWithValue("@capacidad", this.capacidad);
            comando.Parameters.AddWithValue("@caracteristicas", this.caracteristicas);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void eliminar(/*int id*/)
        {
            SqlCommand comando = new SqlCommand("eliminarBus", conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", this.id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public DataTable mostrar()
        {
            DataTable dt = new DataTable();
            SqlCommand comando = new SqlCommand("mostrarBus", conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            adapter.Fill(dt);
            return dt;
        }

        public void cargarMarca(ComboBox comboBox1)
        {
            comboBox1.ToString();
            CDConexion conexion = new CDConexion();
            DataTable dt = new DataTable();
            using (conexion.AbrirConexion())
            {
                string query = "select * from marcasBuses order by marca";
                SqlCommand cmd = new SqlCommand(query, conexion.AbrirConexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            comboBox1.DisplayMember = "marca";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = dt;
            conexion.CerrarConexion();
        }

        public void cargarColor(ComboBox comboBox1)
        {
            comboBox1.ToString();
            CDConexion conexion = new CDConexion();
            DataTable dt = new DataTable();
            using (conexion.AbrirConexion())
            {
                string query = "select * from coloresBuses order by color";
                SqlCommand cmd = new SqlCommand(query, conexion.AbrirConexion());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            comboBox1.DisplayMember = "color";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = dt;
            conexion.CerrarConexion();
        }
    }
}
