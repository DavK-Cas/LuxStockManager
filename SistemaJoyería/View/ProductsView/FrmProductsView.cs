using SistemaJoyería.Controller.ProductsController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaJoyería.View.ProductsView
{
    public partial class FrmProductsView : Form
    {
        public FrmProductsView()
        {
            InitializeComponent();
            ProductsController control = new ProductsController(this);
        }
    }
}
