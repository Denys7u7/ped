using capaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion.Forms
{
    public partial class FormBus : Form
    {
        public FormBus()
        {
            InitializeComponent();
        }

        private void FormBus_Load(object sender, EventArgs e)
        {
            mostrarBuses();
            mostrarMarcas();
            mostrarColores();
        }

        void mostrarBuses()
        {
            CDBus bus = new CDBus();
            dgvBuses.DataSource = bus.mostrar();
        }

        void mostrarMarcas()
        {
            CDBus bus = new CDBus();
            bus.cargarMarca(comboBox1);
        }

        void mostrarColores()
        {
            CDBus bus = new CDBus();
            bus.cargarColor(comboBox2);
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if(txtCatacteristicas.Text == "" || txtPlaca.Text == "" || txtCatacteristicas.Text == "")
            {
                MessageBox.Show("Todos los campos se deben llenar", "Aviso");
            }
            else
            {
                CDBus bus = new CDBus(txtPlaca.Text,int.Parse(comboBox2.SelectedValue.ToString()),int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(nmCapacidad.Value.ToString()), txtCatacteristicas.Text);
                bus.insertar();
                mostrarBuses();
            }
        }
    }
}
