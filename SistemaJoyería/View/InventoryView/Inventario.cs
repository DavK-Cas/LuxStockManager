using SistemaJoyería.Controller.Inventario;
using SistemaJoyería.Controller.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaJoyería.View.InventarioView
{
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
            new Inventario(this);
        }
    }
}
