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
    public class CDViajes
    {
        CDConexion cn = new CDConexion();

        private int id;
        private int idRuta;
        private string ruta;
        private string destino1;
        private string destino2;
        private string destino3;
        private int idBus;
        private int idConductor;
        private string viajes;
        private DateTime fecha;
        private int estado;
        public int Id { get => id; set => id = value; }
        public int IdRuta { get => idRuta; set => idRuta = value; }
        public string Ruta { get => ruta; set => ruta = value; }
        public string Destino1 { get => destino1; set => destino1 = value; }
        public string Destino2 { get => destino2; set => destino2 = value; }
        public string Destino3 { get => destino3; set => destino3 = value; }
        public int IdBus { get => idBus; set => idBus = value; }
        public int IdConductor { get => idConductor; set => idConductor = value; }
        public string Viajes { get => viajes; set => viajes = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Estado { get => estado; set => estado = value; }

        public Boolean insertarRuta()
        {
            try
            {
                object idR;
                string insert;
                cn.AbrirConexion();
                insert = "INSERT INTO Ruta (lugar) VALUES (@ruta); SELECT SCOPE_IDENTITY();";
                SqlCommand insertar1;
                insertar1 = new SqlCommand(insert, cn.AbrirConexion());
                //insertar1.CommandType = CommandType.StoredProcedure;
                insertar1.Parameters.Add(new SqlParameter("@ruta", SqlDbType.VarChar));
                insertar1.Parameters["@ruta"].Value = ruta;
                idR = insertar1.ExecuteScalar();
                idRuta = Convert.ToInt32(idR);
                //MessageBox.Show("Ruta registrado" + Convert.ToString(idR));
                cn.CerrarConexion();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Boolean insertDestinos()
        {
            try
            {
                string insert;
                cn.AbrirConexion();
                insert = "INSERT INTO Destinos (id_ruta,destino1,destino2,destino3) VALUES (@idRuta,@destino1,@destino2,@destino3)";
                SqlCommand insertar1;
                insertar1 = new SqlCommand(insert, cn.AbrirConexion());
                insertar1.Parameters.Add(new SqlParameter("@idRuta", SqlDbType.Int));
                insertar1.Parameters["@idRuta"].Value = idRuta;
                insertar1.Parameters.Add(new SqlParameter("@destino1", SqlDbType.VarChar));
                insertar1.Parameters["@destino1"].Value = destino1;
                insertar1.Parameters.Add(new SqlParameter("@destino2", SqlDbType.VarChar));
                insertar1.Parameters["@destino2"].Value = destino2;
                insertar1.Parameters.Add(new SqlParameter("@destino3", SqlDbType.VarChar));
                insertar1.Parameters["@destino3"].Value = destino3;
                insertar1.ExecuteNonQuery();
                //MessageBox.Show("Destino registrado");
                cn.CerrarConexion();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean InsertarViaje()
        {
            try
            {
                string insert;
                object idV;
                cn.AbrirConexion();
                insert = "INSERT INTO Viajes Values(@idRuta,@idBus,@idConductor,@viaje,@fecha,@estado); SELECT SCOPE_IDENTITY();";
                SqlCommand insertar1;
                insertar1 = new SqlCommand(insert, cn.AbrirConexion());
                insertar1.Parameters.Add(new SqlParameter("@idRuta", SqlDbType.Int));
                insertar1.Parameters["@idRuta"].Value = idRuta;
                insertar1.Parameters.Add(new SqlParameter("@idBus", SqlDbType.Int));
                insertar1.Parameters["@idBus"].Value = idBus;
                insertar1.Parameters.Add(new SqlParameter("@idConductor", SqlDbType.Int));
                insertar1.Parameters["@idConductor"].Value = idConductor;
                insertar1.Parameters.Add(new SqlParameter("@viaje", SqlDbType.VarChar));
                insertar1.Parameters["@viaje"].Value = viajes;
                insertar1.Parameters.Add(new SqlParameter("@fecha", SqlDbType.SmallDateTime));
                insertar1.Parameters["@fecha"].Value = fecha;
                insertar1.Parameters.Add(new SqlParameter("@estado", SqlDbType.Int));
                insertar1.Parameters["@estado"].Value = 1;
                idV = insertar1.ExecuteScalar();
                id = Convert.ToInt32(idV);
                MessageBox.Show("Viaje registrado" + "Num" + id);
                cn.CerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar viaje: " + ex);
                return false;
            }            
        }

        public void comboBus(ComboBox cmb)
        {
            string insert;
            cn.AbrirConexion();
            insert = "SELECT id,placa FROM bus";
            SqlCommand insertar1;
            insertar1 = new SqlCommand(insert, cn.AbrirConexion());
            SqlDataAdapter mysqldt = new SqlDataAdapter(insertar1);
            DataTable dt = new DataTable();
            mysqldt.Fill(dt);
            cmb.ValueMember = "id";
            cmb.DisplayMember = "placa";
            cmb.DataSource = dt;
            cn.CerrarConexion();
        }
        public void comboConductor(ComboBox cmb)
        {
            string insert;
            cn.AbrirConexion();
            insert = "SELECT id,nombre FROM usuarios WHERE licencia <> ''";
            SqlCommand insertar1;
            insertar1 = new SqlCommand(insert, cn.AbrirConexion());
            SqlDataAdapter mysqldt = new SqlDataAdapter(insertar1);
            DataTable dt = new DataTable();
            mysqldt.Fill(dt);
            cmb.ValueMember = "id";
            cmb.DisplayMember = "nombre";
            cmb.DataSource = dt;
            cn.CerrarConexion();
        }

    }
}
