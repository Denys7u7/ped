using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaDatos;
using System.Data.SqlClient;

namespace capaPresentacion
{
    public partial class CPLogin : Form
    {
        CDUsuario user;
        SqlDataReader leer;
        public int xClick = 0, yClick = 0;

        public CPLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            
        }

        private void limpiar()
        {
            txtEmail.Clear();
            txtPass.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            leer = null;
            string error = "Datos erroneos. Vuelva a intentarlo";
            string nombre;
            user = new CDUsuario(txtEmail.Text, txtPass.Text);
            
            leer = user.logearse();
            
            //MessageBox.Show(leer.Read() == true ? "Se encontro el usuario" : "No se encontro el usuario");
            //Mensaje de error: 
            if (leer.Read() == true)
            {
                nombre = leer[0].ToString();
                CPMain frm = new CPMain(nombre);
                frm.Show();
                this.Hide();
            }
            else
            {
                lblError.Text = error;
                limpiar();
            }
        }

        private void btnMover_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Seguro quiere salir del sistema", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                xClick = e.X;
                yClick = e.Y;
            }
            else
            {
                this.Left = this.Left + (e.X - xClick);
                this.Top = this.Top + (e.Y - yClick);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
