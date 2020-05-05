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
    public partial class FormUsuarios : Form
    {
        CDConductor conductorCD = new CDConductor();
        ValidacionesC v = new ValidacionesC();
        private string idConductor = null;
        private bool Editar = false;
        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void MostrarConductor()
        {
            CDConductor conductor = new CDConductor();
            dataGridView1.DataSource = conductor.Mostrar();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            MostrarConductor();
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    conductorCD.Insertar(txtNombre.Text, txtApellido.Text, txtDUI.Text, Int32.Parse(txtEdad.Text), txtTelefono.Text, txtCorreo.Text, txtPass.Text, txtLicencia.Text);
                    MessageBox.Show("Conductor agregado correctamente");
                    MostrarConductor();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error. No se pudo insertar el conductor");
                }
            }

            if (Editar == true)
            {
                try
                {
                    conductorCD.Editar(txtNombre.Text, txtApellido.Text, txtDUI.Text, Int32.Parse(txtEdad.Text), txtTelefono.Text, txtCorreo.Text, txtPass.Text, txtLicencia.Text, Int32.Parse(idConductor));
                    MessageBox.Show("Conductor editado correctamente");
                    MostrarConductor();
                    Editar = false;
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error. No se pudo editar los datos del conductor");
                }
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells["apellido"].Value.ToString();
                txtDUI.Text = dataGridView1.CurrentRow.Cells["dui"].Value.ToString();
                txtEdad.Text = dataGridView1.CurrentRow.Cells["edad"].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells["Teléfono"].Value.ToString();
                txtCorreo.Text = dataGridView1.CurrentRow.Cells["Correo"].Value.ToString();
                txtPass.Text = dataGridView1.CurrentRow.Cells["Contraseña"].Value.ToString();
                txtLicencia.Text = dataGridView1.CurrentRow.Cells["Licencia"].Value.ToString();
                idConductor = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Aún no ha seleccionado una fila");
            }
        }

        private void limpiarForm()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDUI.Clear();
            txtEdad.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtPass.Clear();
            txtLicencia.Clear();

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idConductor = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                try
                {
                    conductorCD.Eliminar(Int32.Parse(idConductor));
                    MessageBox.Show("Conductor eliminado");
                    MostrarConductor();
                } catch(Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar el conductor, puede que ya tengo un viaje asignado");
                }
                
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar");
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.noEspacios(e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }

        private void txtLicencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.noEspacios(e);
        }

        private void txtDUI_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.noEspacios(e);
        }
    }
}
