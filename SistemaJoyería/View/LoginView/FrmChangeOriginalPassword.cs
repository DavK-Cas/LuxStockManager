using SistemaJoyería.Controller.LoginController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaJoyería.View.LoginView
{
    public partial class FrmChangeOriginalPassword : Form
    {
        public FrmChangeOriginalPassword()
        {
            InitializeComponent();
            ChangeOriginalPasswordController changeOriginalPasswordController = new ChangeOriginalPasswordController(this);
        }
    }
}
