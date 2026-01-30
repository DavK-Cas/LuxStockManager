using SistemaJoyería.Controller.DashboardController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaJoyería.View.DashboardView
{
    public partial class FrmDashboardView : Form
    {
        public FrmDashboardView()
        {
            InitializeComponent();
            DashboardController controller = new DashboardController(this);
        }
    }
}
