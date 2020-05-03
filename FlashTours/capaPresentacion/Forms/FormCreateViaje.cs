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
    public partial class FormCreateViaje : Form
    {
        CDViajes viajes = new CDViajes();
        public FormCreateViaje()
        {
            InitializeComponent();
            //btnsiguiente.Enabled = false;
            cmbBus.Items.Clear();
            cmbConductor.Items.Clear();
            viajes.comboBus(cmbBus);
            viajes.comboConductor(cmbConductor);
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtRuta.Text)) {
               
                if (!String.IsNullOrEmpty(txtdestino1.Text)){
                    if (!String.IsNullOrEmpty(txtdestino2.Text)){
                        if (!String.IsNullOrEmpty(txtdestino3.Text)){
                            if (!String.IsNullOrEmpty(cmbBus.Text)){
                                if (!String.IsNullOrEmpty(cmbConductor.Text)){
                                    if (!String.IsNullOrEmpty(txtViaje.Text)){
                                        if (!String.IsNullOrEmpty(dtViaje.Value.ToString())){
                                            //CODIGO
                                            viajes.Ruta = txtRuta.Text;
                                            viajes.Destino1 = txtdestino1.Text;
                                            viajes.Destino2 = txtdestino2.Text;
                                            viajes.Destino3 = txtdestino3.Text;
                                            viajes.IdBus = Convert.ToInt32(cmbBus.SelectedValue.ToString());
                                            viajes.IdConductor = Convert.ToInt32(cmbConductor.SelectedValue.ToString());
                                            viajes.Viajes = txtViaje.Text;
                                            viajes.Fecha = dtViaje.Value;

                                            if (viajes.insertarRuta())
                                            {
                                                if (viajes.insertDestinos())
                                                {
                                                    if (viajes.InsertarViaje())
                                                    {
                                                        MessageBox.Show("Viaje ingresado");
                                                       // activarBoton();
                                                    }
                                                }
                                            }
                                             
                                             
                                        }
                                        else
                                        {
                                            MessageBox.Show("Seleccione la fecha del viaje");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ingrese el nombre del viaje");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Seleccione el conductor");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Seleccione el bus");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ingrese el destino3");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese el destino2");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el destino1");
                }
            }
            else
            {
                MessageBox.Show("Ingrese Ruta");
            }
        }
           
        /*public void activarBoton()
        {
            btnregistrar.Enabled = false;
            btnsiguiente.Enabled = true;
        }*/
        private void cmbBus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new Forms.FormCreateViaje(), sender);
        }
    }
}
