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
using capaPresentacion;

namespace capaPresentacion.Forms
{
    public partial class FormAsignacion : Form
    {
        CDcola clientes = new CDcola();

        CDcola Destino1 = new CDcola();
        CDcola Destino2 = new CDcola();
        CDcola Destino3 = new CDcola();

        CDAsientos asientos = new CDAsientos();
        int[] AsientosN = new int[36];
        int contadorD1 = 0, contadorD2 =0, contadorD3 =0;
        public FormAsignacion(int idViaje)
        {
            InitializeComponent();

            listBox1.Items.Clear();
            ConsultarClientes();
            AsignarAsientos();
        }
        public void ConsultarClientes()
        {
            asientos.readClientes(listBox1,clientes);
        }
        public void AsignarAsientos()
        {
            asientos.asientosMetodo(AsientosN);

            btnA1.BackColor = Color.ForestGreen;
            btnA2.BackColor = Color.ForestGreen;
            btnA3.BackColor = Color.ForestGreen;
            btnA4.BackColor = Color.ForestGreen;
            btnA5.BackColor = Color.ForestGreen;
            btnA6.BackColor = Color.ForestGreen;
            btnA7.BackColor = Color.ForestGreen;
            btnA8.BackColor = Color.ForestGreen;
            btnA9.BackColor = Color.ForestGreen;
            btnA10.BackColor = Color.ForestGreen;

            btnA11.BackColor = Color.DarkGoldenrod;
            btnA12.BackColor = Color.DarkGoldenrod;
            btnA13.BackColor = Color.DarkGoldenrod;
            btnA14.BackColor = Color.DarkGoldenrod;
            btnA15.BackColor = Color.DarkGoldenrod;
            btnA16.BackColor = Color.DarkGoldenrod;
            btnA17.BackColor = Color.DarkGoldenrod;
            btnA18.BackColor = Color.DarkGoldenrod;
            btnA19.BackColor = Color.DarkGoldenrod;
            btnA20.BackColor = Color.DarkGoldenrod;
            btnA21.BackColor = Color.DarkGoldenrod;
            btnA22.BackColor = Color.DarkGoldenrod;
            btnA23.BackColor = Color.DarkGoldenrod;
            btnA24.BackColor = Color.DarkGoldenrod;

            btnA25.BackColor = Color.DarkRed;
            btnA26.BackColor = Color.DarkRed;
            btnA27.BackColor = Color.DarkRed;
            btnA28.BackColor = Color.DarkRed;
            btnA29.BackColor = Color.DarkRed;
            btnA30.BackColor = Color.DarkRed;
            btnA31.BackColor = Color.DarkRed;
            btnA32.BackColor = Color.DarkRed;
            btnA33.BackColor = Color.DarkRed;
            btnA34.BackColor = Color.DarkRed;
            btnA35.BackColor = Color.DarkRed;
            btnA36.BackColor = Color.DarkRed;
        }
        public void addClienteAsiento(int Destino)
        {
            if(Destino == 1)
            {
                if (contadorD1 == 1) btnA1.Text = "AS";
                if (contadorD1 == 2) btnA2.Text = "AS";
                if (contadorD1 == 3) btnA3.Text = "AS";
                if (contadorD1 == 4) btnA4.Text = "AS";
                if (contadorD1 == 5) btnA5.Text = "AS";
                if (contadorD1 == 6) btnA6.Text = "AS";
                if (contadorD1 == 7) btnA7.Text = "AS";
                if (contadorD1 == 8) btnA8.Text = "AS";
                if (contadorD1 == 9) btnA9.Text = "AS";
                if (contadorD1 == 10) btnA10.Text = "AS";
            }
            if (Destino == 2)
            {
                if (contadorD2 == 1) btnA11.Text = "AS";
                if (contadorD2 == 2) btnA12.Text = "AS";
                if (contadorD2 == 3) btnA13.Text = "AS";
                if (contadorD2 == 4) btnA14.Text = "AS";
                if (contadorD2 == 5) btnA15.Text = "AS";
                if (contadorD2 == 6) btnA16.Text = "AS";
                if (contadorD2 == 7) btnA17.Text = "AS";
                if (contadorD2 == 8) btnA18.Text = "AS";
                if (contadorD2 == 9) btnA19.Text = "AS";
                if (contadorD2 == 10) btnA20.Text = "AS";
                if (contadorD2 == 11) btnA21.Text = "AS";
                if (contadorD2 == 12) btnA22.Text = "AS";
                if (contadorD2 == 13) btnA23.Text = "AS";
                if (contadorD2 == 14) btnA24.Text = "AS";
            }
            if (Destino == 3)
            {
                if (contadorD3 == 1) btnA25.Text = "AS";
                if (contadorD3 == 2) btnA26.Text = "AS";
                if (contadorD3 == 3) btnA27.Text = "AS";
                if (contadorD3 == 4) btnA28.Text = "AS";
                if (contadorD3 == 5) btnA29.Text = "AS";
                if (contadorD3 == 6) btnA30.Text = "AS";
                if (contadorD3 == 7) btnA31.Text = "AS";
                if (contadorD3 == 8) btnA32.Text = "AS";
                if (contadorD3 == 9) btnA33.Text = "AS";
                if (contadorD3 == 10) btnA34.Text = "AS";
                if (contadorD3 == 11) btnA35.Text = "AS";
                if (contadorD3 == 12) btnA36.Text = "AS";
            }
        }
        public void AgregarCliente(int Destino)
        {
            object client;
            client = clientes.DesenCDcolarValor();
            if(client != null) {
                listBox1.Items.Remove(client);
                if (Destino == 1)
                {
                    Destino1.Encolar(client);
                    contadorD1++;
                    addClienteAsiento(Destino);
                }
                if (Destino == 2)
                {
                    Destino2.Encolar(client);
                    contadorD2++;
                    addClienteAsiento(Destino);
                }
                if (Destino == 3)
                {
                    Destino3.Encolar(client);
                    contadorD3++;
                    addClienteAsiento(Destino);
                }
            }
            else
            {
                MessageBox.Show("No hay clientes en CDcola");
            }
            

        }
        private void button36_Click(object sender, EventArgs e)
        {
            if(contadorD1 < 10) {
                AgregarCliente(1);
            }
            else
            {
                MessageBox.Show("Destino 1 lleno");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormAsignacion_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            if (contadorD1 < 14)
            {
                AgregarCliente(2);
            }
            else
            {
                MessageBox.Show("Destino 2 lleno");
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            if (contadorD1 < 12)
            {
                AgregarCliente(3);
            }
            else
            {
                MessageBox.Show("Destino 3 lleno");
            }
        }
    }
}
