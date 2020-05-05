using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using capaDatos;

namespace capaPresentacion.Forms
{
    public partial class FormTickets : Form
    {
        CDAsientos viajes = new CDAsientos();
        int idViaje;
        public FormTickets()
        {
            InitializeComponent();            
            viajes.comboViajes(cmbViajes);
            txtViaje.Enabled = false;
            txtNombre.Enabled = false;
            txtDestino.Enabled = false;
            txtCodigo.Enabled = false;
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            idViaje = Convert.ToInt32(cmbViajes.SelectedValue);
            mostrarInfo();
        }
        void mostrarInfo()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            CDtickets mostrar = new CDtickets();
            mostrar.IdViaje = idViaje;
            dataGridView1.DataSource = mostrar.mostrarViajes();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtViaje.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtDestino.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtCodigo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnGenerar_Click_1(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("---------Ticket de viaje----------", new Font("Times New Romans", 18, FontStyle.Bold), Brushes.Red, new PointF(100, 80));
            e.Graphics.DrawString("Nombre:", new Font("Times New Romans", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 125));
            e.Graphics.DrawString(txtNombre.Text, new Font("Times New Romans", 14, FontStyle.Bold), Brushes.Black, new PointF(225, 125));
            e.Graphics.DrawString("Viaje:", new Font("Times New Romans", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 175));
            e.Graphics.DrawString(txtViaje.Text, new Font("Times New Romans", 14, FontStyle.Bold), Brushes.Black, new PointF(225, 175));
            e.Graphics.DrawString("Destino:", new Font("Times New Romans", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 225));
            e.Graphics.DrawString(txtDestino.Text, new Font("Times New Romans", 14, FontStyle.Bold), Brushes.Black, new PointF(225, 225));
            e.Graphics.DrawString("Codigo:", new Font("Times New Romans", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 275));
            e.Graphics.DrawString(txtCodigo.Text, new Font("Times New Romans", 14, FontStyle.Bold), Brushes.Black, new PointF(225, 275));
            e.Graphics.DrawString("--------------------------------------", new Font("Times New Romans", 18, FontStyle.Bold), Brushes.Red, new PointF(100, 320));

        }
    }
}
