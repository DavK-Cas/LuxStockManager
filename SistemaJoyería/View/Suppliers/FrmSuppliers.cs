using SistemaJoyería.Controller.Suppliers;
using System;
using System.Windows.Forms;

namespace SistemaJoyería.View.Suppliers
{
    public partial class FrmSuppliers : Form
    {
        public FrmSuppliers()
        {
            InitializeComponent();
            new ControllerSuppliers(this);
            this.KeyPreview = true;
            this.KeyDown += Form_KeyDown;

            // Hacemos que el ListView se ajuste de forma responsiva
            this.listSuppliers.Dock = DockStyle.Fill; // El ListView se extiende y ocupa todo el espacio disponible

            // Ajustar el tamaño de las columnas cuando se cambia el tamaño del formulario
            this.Resize += new EventHandler(FrmSuppliers_Resize);
            AjustarColumnasListView(); // Llamada inicial para ajustar columnas
        }

        // Método para bloquear copiar y pegar
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true;
            }
        }

        // Ajustar las columnas del ListView al redimensionar el formulario
        private void FrmSuppliers_Resize(object sender, EventArgs e)
        {
            AjustarColumnasListView();
        }

        // Método para ajustar las columnas proporcionalmente
        private void AjustarColumnasListView()
        {
            if (listSuppliers.Columns.Count > 0)
            {
                // Dividir el ancho total del ListView entre el número de columnas
                int totalWidth = listSuppliers.Width;
                int columnCount = listSuppliers.Columns.Count;
                int columnWidth = totalWidth / columnCount;

                // Asignar el ancho proporcional a cada columna
                for (int i = 0; i < listSuppliers.Columns.Count; i++)
                {
                    listSuppliers.Columns[i].Width = columnWidth;
                }
            }
        }

        private void listSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
        }
    }
}
