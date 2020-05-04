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

namespace capaPresentacion.Forms
{
    public partial class FormViaje : Form
    {
        CDAsientos asientos = new CDAsientos();
        int idViaje;
        public FormViaje()
        {
            InitializeComponent();
            asientos.comboViajes(cmbViajes);
            mostrarViajes();
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            idViaje = Convert.ToInt32(cmbViajes.SelectedValue);
            FormAsignacion asignacion = new FormAsignacion(idViaje);
            AddOwnedForm(asignacion);
            asignacion.ShowDialog();
        }

        void mostrarViajes()
        {
            CDAsientos mostrar = new CDAsientos();
            dgvViajes.DataSource = mostrar.mostrarViajes();
        }

        private void FormViaje_Load(object sender, EventArgs e)
        {

        }
    }
}
