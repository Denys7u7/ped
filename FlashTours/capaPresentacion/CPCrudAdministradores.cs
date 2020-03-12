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
    public partial class CPCrudAdministradores : Form
    {
        public int xClick = 0, yClick = 0;
        SqlDataReader leer;
        public CPCrudAdministradores()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
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

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void CPCrudAdministradores_Load(object sender, EventArgs e)
        {
            mostrarCargos();
        }

        public void mostrarCargos()
        {
            CDCargos cargos = new CDCargos();
            if (cargos.mostrar().Count != 0)
            {
                cmbCargos.DataSource = cargos.mostrar();
                cmbCargos.ValueMember = "Id";
                cmbCargos.DisplayMember = "Cargo";
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
    }
}
