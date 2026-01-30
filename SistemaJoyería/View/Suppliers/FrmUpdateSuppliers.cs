using SistemaJoyería.Controller.Suppliers;
using SistemaJoyería.Model.DAO;
using SistemaJoyeria.Model.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaJoyería.View.Suppliers
{
    public partial class FrmUpdateSuppliers : Form
    {
        public FrmUpdateSuppliers(string idBuena)
        {
            InitializeComponent();

            // Instanciar el controlador y pasar el formulario actual como referencia
            new ControllerFrmUpdateSuppliers(idBuena, this);

            // Habilitar el manejo de eventos KeyDown
            this.KeyPreview = true;
            this.KeyDown += Form_KeyDown;
        }

        // Este método captura los eventos de teclado
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();  // Cerrar el formulario si se presiona ESC
            }
        }
    }

}