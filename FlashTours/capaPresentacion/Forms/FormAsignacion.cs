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
        CDAsientos asientos = new CDAsientos();

        CDcola clientes = new CDcola();
        CDcola nombres = new CDcola();


        CDcola CDasientos = new CDcola();
        //CDcola CDpeople = new CDcola();
    
        public int idViaje,idAsiento;
        int[,] AsientosN = new int[2,36];
        int[] PersonasID = new int[36];

        public FormAsignacion(int idViaje)
        {
            InitializeComponent();

            this.idViaje = idViaje;
            ConsultarAsientos();
            //comsultarPeople();

           listBox1.Items.Clear();
            ConsultarClientes(idViaje);


            prueba();
        }
        public void prueba()
        {
            for (int i = 0; i < PersonasID.Length; i++)
            {
                PersonasID[i] = 0;
            }
        }
       /* public void comsultarPeople()
        {
            asientos.IdViaje = idViaje;
            asientos.consultarPeople(CDpeople);
        }*/
        public void ConsultarAsientos()
        {
            asientos.IdViaje = idViaje;
            asientos.consultarAsientos(CDasientos);


            AsignarAsientos(btnA1,0);
            AsignarAsientos(btnA2,1);
            AsignarAsientos(btnA3,2);
            AsignarAsientos(btnA4,3);
            AsignarAsientos(btnA5,4);
            AsignarAsientos(btnA6,5);
            AsignarAsientos(btnA7,6);
            AsignarAsientos(btnA8,7);
            AsignarAsientos(btnA9,8);
            AsignarAsientos(btnA10,9);
            AsignarAsientos(btnA11,10);
            AsignarAsientos(btnA12,11);
            AsignarAsientos(btnA13,12);
            AsignarAsientos(btnA14,13);
            AsignarAsientos(btnA15,14);
            AsignarAsientos(btnA16,15);
            AsignarAsientos(btnA17,16);
            AsignarAsientos(btnA18,17);
            AsignarAsientos(btnA19,18);
            AsignarAsientos(btnA20,19);
            AsignarAsientos(btnA21,20);
            AsignarAsientos(btnA22,21);
            AsignarAsientos(btnA23,22);
            AsignarAsientos(btnA24,23);
            AsignarAsientos(btnA25,24);
            AsignarAsientos(btnA26,25);
            AsignarAsientos(btnA27,26);
            AsignarAsientos(btnA28,27);
            AsignarAsientos(btnA29,28);
            AsignarAsientos(btnA30,29);
            AsignarAsientos(btnA31,30);
            AsignarAsientos(btnA32,31);
            AsignarAsientos(btnA33,32);
            AsignarAsientos(btnA34,33);
            AsignarAsientos(btnA35,34);
            AsignarAsientos(btnA36,35);
        }

        public void AsignarAsientos(Button btn,int i)
        {
            int valor = Convert.ToInt32(CDasientos.DesenCDcolarValor());
            if (valor == 1) btn.BackColor = Color.ForestGreen;
            if (valor == 2) btn.BackColor = Color.DarkGoldenrod;
            if (valor == 3) btn.BackColor = Color.DarkRed;
            if (valor == 0) btn.BackColor = Color.White;
            AsientosN[0,i] = valor;
        }
        public void agregarCliente(int Ndestino)
        {
            int filas = AsientosN.GetLength(1);
            for (int i = 0; i < filas; i++)
            {
                 if(AsientosN[0, i] == 1 && Ndestino == 1 && AsientosN[1,i] == 0)
                {                 
                    if(clientes != null)
                    {
                        object client = clientes.DesenCDcolarValor();
                        object Nombreclient = nombres.DesenCDcolarValor();
                        listBox1.Items.Remove(Nombreclient.ToString());
                        PersonasID[i] = Convert.ToInt32(client);
                        AsientosN[1, i] = 1;
                        NombreCliente(i);
                        break;
                    }
                    else
                    {
                        MessageBox.Show("No hay Clientes en la cola");
                    }
                }
                if (AsientosN[0, i] == 2 && Ndestino == 2 && AsientosN[1, i] == 0)
                {
                    if (clientes != null)
                    {
                        object client = clientes.DesenCDcolarValor();
                        object Nombreclient = nombres.DesenCDcolarValor();
                        listBox1.Items.Remove(Nombreclient.ToString());
                        PersonasID[i] = Convert.ToInt32(client);

                        AsientosN[1, i] = 1;
                        NombreCliente(i);
                        break;
                    }
                    else
                    {
                        MessageBox.Show("No hay Clientes en la cola");
                    }
                }
                if (AsientosN[0, i] == 3 && Ndestino == 3 && AsientosN[1, i] == 0)
                {
                    if (clientes != null)
                    {
                        object client = clientes.DesenCDcolarValor();
                        object Nombreclient = nombres.DesenCDcolarValor();
                        listBox1.Items.Remove(Nombreclient.ToString());
                        PersonasID[i] = Convert.ToInt32(client);

                        AsientosN[1, i] = 1;
                        NombreCliente(i);
                        break;
                    }
                    else
                    {
                        MessageBox.Show("No hay Clientes en la cola");
                    }
                }
            }
        }
        public void ClienteAsignado(Button btn)
        {
            btn.Text = "AS";
            
        }
        public void NombreCliente(int i)
        {
            i += 1;
            if (i == 1) ClienteAsignado(btnA1);
            if (i == 2) ClienteAsignado(btnA2);
            if (i == 3) ClienteAsignado(btnA3);
            if (i == 4) ClienteAsignado(btnA4);
            if (i == 5) ClienteAsignado(btnA5);
            if (i == 6) ClienteAsignado(btnA6);
            if (i == 7) ClienteAsignado(btnA7);
            if (i == 8) ClienteAsignado(btnA8);
            if (i == 9) ClienteAsignado(btnA9);
            if (i == 10) ClienteAsignado(btnA10);
            if (i == 11) ClienteAsignado(btnA11);
            if (i == 12) ClienteAsignado(btnA12);
            if (i == 13) ClienteAsignado(btnA13);
            if (i == 14) ClienteAsignado(btnA14);
            if (i == 15) ClienteAsignado(btnA15);
            if (i == 16) ClienteAsignado(btnA16);
            if (i == 17) ClienteAsignado(btnA17);
            if (i == 18) ClienteAsignado(btnA18);
            if (i == 19) ClienteAsignado(btnA19);
            if (i == 20) ClienteAsignado(btnA20);
            if (i == 21) ClienteAsignado(btnA21);
            if (i == 22) ClienteAsignado(btnA22);
            if (i == 23) ClienteAsignado(btnA23);
            if (i == 24) ClienteAsignado(btnA24);
            if (i == 25) ClienteAsignado(btnA25);
            if (i == 26) ClienteAsignado(btnA26);
            if (i == 27) ClienteAsignado(btnA27);
            if (i == 28) ClienteAsignado(btnA28);
            if (i == 29) ClienteAsignado(btnA29);
            if (i == 30) ClienteAsignado(btnA30);
            if (i == 31) ClienteAsignado(btnA31);
            if (i == 32) ClienteAsignado(btnA32);
            if (i == 33) ClienteAsignado(btnA33);
            if (i == 34) ClienteAsignado(btnA34);
            if (i == 35) ClienteAsignado(btnA35);
            if (i == 36) ClienteAsignado(btnA36);
        }

        public void ConsultarClientes(int idViajes)
        {
            asientos.readClientes(listBox1, clientes, nombres,idViajes);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            agregarCliente(1);
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

        private void button37_Click(object sender, EventArgs e)
        {
            agregarCliente(2);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            agregarCliente(3);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                asientos.consultarIdAsiento();
                idAsiento = asientos.Id;
                int filas = AsientosN.GetLength(1);
                for (int i = 0; i < filas; i++)
                {
                    asientos.IdViaje = idViaje;
                    asientos.IdPersona = PersonasID[i];
                    asientos.Id = idAsiento;
                    idAsiento++;
                    asientos.AsignarPersonas();
                }
                MessageBox.Show("se ingresaron los clientes");
            }
            catch (Exception)
            {
                MessageBox.Show("Error al ingresar clientes");
                throw;
            }
        }
    }
}
