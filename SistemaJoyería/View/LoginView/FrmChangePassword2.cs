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
    public partial class FrmChangePassword2 : Form
    {
        public FrmChangePassword2()
        {
            InitializeComponent();
            new ChangePasswordController2(this);
        }
    }
}
