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
    public partial class FormClientes : Form
    {
        CDAsientos asientos = new CDAsientos();
        CDCliente mantenimiento = new CDCliente();
        ValidacionesC v = new ValidacionesC();

        public FormClientes()
        {
            InitializeComponent();
            asientos.comboViajes(cmbViaje);
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = TemaColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = TemaColor.SecondaryColor;
                }
            }
            label4.ForeColor = TemaColor.SecondaryColor;
            label1.ForeColor = TemaColor.PrimaryColor;
            label2.ForeColor = TemaColor.PrimaryColor;
            label3.ForeColor = TemaColor.PrimaryColor;
            label5.ForeColor = TemaColor.PrimaryColor;
            label6.ForeColor = TemaColor.PrimaryColor;
        }
        //Desde aqui comienza
        void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtDUI.Clear();
            numericUpDown1.Value = 0;
        }
        void mostrarClientes()
        {
            CDCliente mostrar = new CDCliente();
            dgvclientes.DataSource = mostrar.mostrarClientes();
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if (txtApellidos.Text == "" || txtNombre.Text == "" || txtDUI.Text == "" || numericUpDown1.Text == "" || txtTelefono.Text == "")
            {
                MessageBox.Show("Se deben llenar todos los campos");
            }
            else
            {
                try
                {
                    mantenimiento.insertar(txtNombre.Text, txtApellidos.Text, txtDUI.Text, int.Parse(numericUpDown1.Value.ToString()), txtTelefono.Text, Convert.ToInt32(cmbViaje.SelectedValue));
                    mostrarClientes();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El dui o el numero de telefono ya ha sido registrado", "Datos repetidos");
                    return;
                }
                
            }
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            LoadTheme();
            mostrarClientes();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            if (txtApellidos.Text == "" || txtNombre.Text == "" || txtDUI.Text == "" || numericUpDown1.Text == "" || txtTelefono.Text == "")
            {
                MessageBox.Show("Existen campos vacíos, por favor llene todos los campos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    CDCliente.Actualizar(txtNombre.Text, txtApellidos.Text, txtDUI.Text, int.Parse(numericUpDown1.Value.ToString()), txtTelefono.Text,Convert.ToInt32(cmbViaje.SelectedValue),int.Parse(txtId.Text));
                    mostrarClientes();
                    LimpiarCampos();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("No se pudo actualizar la informacion del cliente", "Aviso");
                }
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("No hay Cliente Seleccionado");
            }
            else
            {
                if (MessageBox.Show("¿Desea Eliminar al Cliente?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    CDCliente.Eliminar(txtId.Text);
                    mostrarClientes();
                    LimpiarCampos();
                }
            }
        }

        private void dgvclientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.noEspacios(e);
        }

        private void dgvclientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvclientes.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvclientes.CurrentRow.Cells[1].Value.ToString();
            txtApellidos.Text = dgvclientes.CurrentRow.Cells[2].Value.ToString();
            txtDUI.Text = dgvclientes.CurrentRow.Cells[3].Value.ToString();
            numericUpDown1.Text = dgvclientes.CurrentRow.Cells[4].Value.ToString();
            txtTelefono.Text = dgvclientes.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
