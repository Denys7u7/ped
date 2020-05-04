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
    public partial class FormAsientos : Form
    {
        CDAsientos CDasientos = new CDAsientos();
        public int idViaje;
        int[] asientos = new int[36];
        
        int colorActual;

        public string destino1, destino2, destino3;
        public FormAsientos(int idViaje, string nombreViaje,string destino1,string destino2,string destino3)
        {
            InitializeComponent();
            this.idViaje = idViaje;
            this.destino1 = destino1;
            this.destino2 = destino2;
            this.destino3 = destino3;
            labelViaje.Text = nombreViaje;
            ds1.Text = destino1;
            ds2.Text = destino2;
            ds3.Text = destino3;
        }

        private void FormAsientos_Load(object sender, EventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            ColorAsiento(2);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            ColorAsiento(3);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            ColorAsiento(1);
        }

        private void btnA1_Click(object sender, EventArgs e)
        {
            ColorButton(btnA1, 0);
        }

        private void btnA2_Click(object sender, EventArgs e)
        {
            ColorButton(btnA2, 1);
        }

        private void btnA3_Click(object sender, EventArgs e)
        {
            ColorButton(btnA3, 2);
        }

        private void btnA4_Click(object sender, EventArgs e)
        {
            ColorButton(btnA4, 3);
        }

        private void btnA5_Click(object sender, EventArgs e)
        {
            ColorButton(btnA5, 4);
        }

        private void btnA6_Click(object sender, EventArgs e)
        {
            ColorButton(btnA6, 5);
        }

        private void btnA7_Click(object sender, EventArgs e)
        {
            ColorButton(btnA7, 6);
        }

        private void btnA8_Click(object sender, EventArgs e)
        {
            ColorButton(btnA8, 7);
        }

        private void btnA9_Click(object sender, EventArgs e)
        {
            ColorButton(btnA9, 8);
        }

        private void btnA10_Click(object sender, EventArgs e)
        {
            ColorButton(btnA10, 9);
        }

        private void btnA11_Click(object sender, EventArgs e)
        {
            ColorButton(btnA11, 10);
        }

        private void btnA12_Click(object sender, EventArgs e)
        {
            ColorButton(btnA12, 11);
        }

        private void btnA13_Click(object sender, EventArgs e)
        {
            ColorButton(btnA13, 12);
        }

        private void btnA14_Click(object sender, EventArgs e)
        {
            ColorButton(btnA14, 13);
        }

        private void btnA15_Click(object sender, EventArgs e)
        {
            ColorButton(btnA15, 14);
        }

        private void btnA16_Click(object sender, EventArgs e)
        {
            ColorButton(btnA16, 15);
        }

        private void btnA17_Click(object sender, EventArgs e)
        {
            ColorButton(btnA17, 16);
        }

        private void btnA18_Click(object sender, EventArgs e)
        {
            ColorButton(btnA18, 17);
        }

        private void btnA19_Click(object sender, EventArgs e)
        {
            ColorButton(btnA19, 18);
        }

        private void btnA20_Click(object sender, EventArgs e)
        {
            ColorButton(btnA20, 19);
        }

        private void btnA21_Click(object sender, EventArgs e)
        {
            ColorButton(btnA21, 20);
        }

        private void btnA22_Click(object sender, EventArgs e)
        {
            ColorButton(btnA22, 21);
        }

        private void btnA23_Click(object sender, EventArgs e)
        {
            ColorButton(btnA23, 22);
        }

        private void btnA24_Click(object sender, EventArgs e)
        {
            ColorButton(btnA24, 23);
        }

        private void btnA25_Click(object sender, EventArgs e)
        {
            ColorButton(btnA25, 24);
        }

        private void btnA26_Click(object sender, EventArgs e)
        {
            ColorButton(btnA26, 25);
        }

        private void btnA27_Click(object sender, EventArgs e)
        {
            ColorButton(btnA27, 26);
        }

        private void btnA28_Click(object sender, EventArgs e)
        {
            ColorButton(btnA28, 27);
        }

        private void btnA29_Click(object sender, EventArgs e)
        {
            ColorButton(btnA29, 28);
        }

        private void btnA30_Click(object sender, EventArgs e)
        {
            ColorButton(btnA30, 29);
        }

        private void btnA31_Click(object sender, EventArgs e)
        {
            ColorButton(btnA31, 30);
        }

        private void btnA32_Click(object sender, EventArgs e)
        {
            ColorButton(btnA32, 31);
        }

        private void btnA33_Click(object sender, EventArgs e)
        {
            ColorButton(btnA33, 32);
        }

        private void btnA34_Click(object sender, EventArgs e)
        {
            ColorButton(btnA34, 33);
        }

        private void btnA35_Click(object sender, EventArgs e)
        {
            ColorButton(btnA35, 34);
        }

        private void btnA36_Click(object sender, EventArgs e)
        {
            ColorButton(btnA36, 35);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
                for (int i = 0; i < asientos.Length; i++)
                {
                    CDasientos.IdViaje = idViaje;
                    CDasientos.Destino = "vacio";
                    if (asientos[i] == 1) CDasientos.Destino = destino1;
                    if (asientos[i] == 2) CDasientos.Destino = destino2;
                    if (asientos[i] == 3) CDasientos.Destino = destino3;
                    if (asientos[i] == 0) CDasientos.Destino = "vacio";

                    CDasientos.Color = asientos[i];
                    CDasientos.AsignarAsiento();
                }
                MessageBox.Show("se ingresaron los asientos");
            }
            catch (Exception)
            {
                MessageBox.Show("Error al ingresar asientos");
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorAsiento(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ColorAsiento(int valor){
            colorActual = (valor == 1)?1:(valor == 2)?2:(valor == 3)?3:0;                   
        }
        private void ColorButton(Button btn, int Nbutton)
        {
            if (colorActual == 1) btn.BackColor = Color.ForestGreen;
            if (colorActual == 2) btn.BackColor = Color.DarkGoldenrod;
            if (colorActual == 3) btn.BackColor = Color.DarkRed;
            if (colorActual == 0) btn.BackColor = Color.White;

            for (int i = 0; i < asientos.Length; i++)
            {
                if (Nbutton == i) asientos[i] = colorActual;
            }
        }
    }
}
