using SistemaJoyería.Controller.Suppliers;
using System;
using System.Windows.Forms;

namespace SistemaJoyería.View.Suppliers
{
    public partial class FrmAddSuppliers : Form
    {
        public FrmAddSuppliers()
        {
            InitializeComponent();
            new ControllerFrmAddSuppliers(this);
            this.KeyPreview = true;
            this.KeyDown += Form_KeyDown;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void ValidacionSoloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FrmAddSuppliers_Load(object sender, EventArgs e)
        {
            // Aquí puedes cargar cualquier lógica al iniciar el formulario
        }

        private void NombreEmpresa_Click(object sender, EventArgs e)
        {

        }

        private void NombreContacto_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Telefono_Click(object sender, EventArgs e)
        {

        }

        private void Email_Click(object sender, EventArgs e)
        {

        }

        private void Direccion_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Lógica para el botón de guardar proveedor
        }
    }
}
