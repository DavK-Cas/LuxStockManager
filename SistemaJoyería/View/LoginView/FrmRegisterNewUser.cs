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
    public partial class FrmRegisterNewUser : Form
    {
        public FrmRegisterNewUser()
        {
            InitializeComponent();
            ControllerRegisterNewUser control = new ControllerRegisterNewUser(this);
        }
    }
}
