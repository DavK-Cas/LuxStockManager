using SistemaJoyería.Controller.EmployeesController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaJoyería.View.EmployeesView
{
    public partial class FrmEmployeesView : Form
    {
        public FrmEmployeesView()
        {
            InitializeComponent();
            EmployeesController employeesController = new EmployeesController(this);
        }
    }
}
