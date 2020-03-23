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
            if (txtCatacteristicas.Text == "" || txtPlaca.Text == "" || txtCatacteristicas.Text == "")
            {
                MessageBox.Show("Todos los campos se deben llenar", "Aviso");
            }
            else
            {
                string pr = txtPlaca.Text.Substring(0, 2);
                MessageBox.Show(pr);
                if (pr == "AB")
                {
                    if (txtPlaca.Text.Length == 8)
                    {
                        CDBus bus = new CDBus(txtPlaca.Text, int.Parse(comboBox2.SelectedValue.ToString()), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(nmCapacidad.Value.ToString()), txtCatacteristicas.Text);
                        try
                        {
                            bus.insertar();
                            mostrarBuses();
                            limpiar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("La placa del bus ya esta registrada. vuelva a intentarlo", "Advertencia");
                        }


                    }
                    else
                    {
                        MessageBox.Show("La placa de un bus, cuenta con 8 caracteres especificamente", "Aviso");
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("El formato de placa de bus, debe iniciar con: AB", "Aviso");
                    return;
                }

            }
        }

        private void dgvBuses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvBuses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvBuses.CurrentRow.Cells[0].Value.ToString();
            txtPlaca.Text = dgvBuses.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dgvBuses.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dgvBuses.CurrentRow.Cells[3].Value.ToString();
            nmCapacidad.Text = dgvBuses.CurrentRow.Cells[4].Value.ToString();
            txtCatacteristicas.Text = dgvBuses.CurrentRow.Cells[5].Value.ToString();
        }

        void limpiar()
        {
            txtId.Text = "";
            txtCatacteristicas.Clear();
            txtPlaca.Clear();
            nmCapacidad.Value = 0;
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            if(txtId.Text != "")
            {
                if (txtCatacteristicas.Text == "" || txtPlaca.Text == "" || txtCatacteristicas.Text == "")
                {
                    MessageBox.Show("Todos los campos se deben llenar", "Aviso");
                }
                else
                {
                    string pr = txtPlaca.Text.Substring(0, 2);
                    MessageBox.Show(pr);
                    if (pr == "AB")
                    {
                        if (txtPlaca.Text.Length == 8)
                        {
                            CDBus bus = new CDBus(int.Parse(txtId.Text), txtPlaca.Text, int.Parse(comboBox2.SelectedValue.ToString()), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(nmCapacidad.Value.ToString()), txtCatacteristicas.Text);
                            try
                            {
                                bus.modificar();
                                mostrarBuses();
                                limpiar();
                            } catch(Exception ex)
                            {
                                MessageBox.Show("La placa del bus ya esta registrada. vuelva a intentarlo","Advertencia");
                            }
                            
                            
                        }
                        else
                        {
                            MessageBox.Show("La placa de un bus, cuenta con 8 caracteres especificamente","Aviso");
                            return;
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("El formato de placa de bus, debe iniciar con: AB", "Aviso");
                        return;
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Seleccione el bus a modificar","Aviso");
                return;
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Seguro que desea eliminar el bus", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (dialogResult == DialogResult.Yes)
                {
                    CDBus bus = new CDBus(int.Parse(txtId.Text));
                    try
                    {
                        bus.eliminar();
                        mostrarBuses();
                        limpiar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se puede eliminar el bus, puede que este asociado a un viaje", "Aviso");
                        return;
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Seleccione el bus a eliminar", "Aviso");
                return;
            }
        }
    }
}
