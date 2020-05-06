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
    public class CDCliente
    {
        CDConexion cn = new CDConexion();
        private string nombre;
        private string apellido;
        private string dui;
        private int edad;
        private string telefono;
        private int id;
        private int idViaje;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellidos
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string DUI
        {
            get { return dui; }
            set { dui = value; }
        }

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }



        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public int Id
        {

            get { return id; }
            set { id = value; }
        }

        public int IdViaje { get => idViaje; set => idViaje = value; }

        public void insertar(string nombre, string apellido, string dui, int edad, string telefono, int idViaje)
        {
            cn.AbrirConexion();
            string insert;
            insert = "Insert into usuarios (nombre, apellido, dui,edad ,telefono, cargo, idviaje)";
            insert += "VALUES(@nombre, @apellido, @dui, @edad,  @telefono, 3, @idViaje)";
            SqlCommand insertar1;
            insertar1 = new SqlCommand(insert, cn.AbrirConexion());
            insertar1.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));
            insertar1.Parameters["@nombre"].Value = nombre;
            insertar1.Parameters.Add(new SqlParameter("@apellido", SqlDbType.VarChar));
            insertar1.Parameters["@apellido"].Value = apellido;
            insertar1.Parameters.Add(new SqlParameter("@dui", SqlDbType.VarChar));
            insertar1.Parameters["@dui"].Value = dui;
            insertar1.Parameters.Add(new SqlParameter("@edad", SqlDbType.Int));
            insertar1.Parameters["@edad"].Value = edad;
            insertar1.Parameters.Add(new SqlParameter("@telefono", SqlDbType.VarChar));
            insertar1.Parameters["@telefono"].Value = telefono;
            insertar1.Parameters.Add(new SqlParameter("@idViaje", SqlDbType.Int));
            insertar1.Parameters["@idViaje"].Value = idViaje;
            insertar1.ExecuteNonQuery();
            MessageBox.Show("Cliente registrado");
            cn.CerrarConexion();
        }

        public DataTable mostrarClientes()
        {
            DataTable Consulta = new DataTable();

            string instruccion;
            instruccion = "select id,nombre, apellido, dui, edad, telefono, viaje from usuarios u  inner join Viajes v ON u.idviaje = v.id_viaje where cargo = 3";
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

        public static int Actualizar(string nombre, string apellido, string dui, int edad, string telefono,int idViaje, int id)
        {
            CDConexion cn = new CDConexion();
            cn.AbrirConexion();
            //Lo mismo que en insertar
            int retorno = 0;
            SqlConnection connection = cn.AbrirConexion();
            SqlCommand comando = new SqlCommand(String.Format("UPDATE usuarios SET nombre='{0}',apellido= '{1}', dui= '{2}', edad='{3}', telefono='{4}', idviaje='{5}' WHERE id = '{6}'", nombre, apellido, dui, edad, telefono,idViaje ,id), connection);
            MessageBox.Show("Cliente Actualizado");
            retorno = comando.ExecuteNonQuery();
            cn.CerrarConexion();
            return retorno;
        }

        public static int Eliminar(string Id)
        {
            CDConexion cn = new CDConexion();
            cn.AbrirConexion();
            //Lo mismo que en insertar
            int retorno = 0;
            SqlConnection connection = cn.AbrirConexion();
            SqlCommand comando = new SqlCommand(String.Format("delete from usuarios WHERE id = '{0}'", Id), connection);
            MessageBox.Show("Cliente Eliminado");
            retorno = comando.ExecuteNonQuery();
            cn.CerrarConexion();
            return retorno;
        }
    }
}
