using SistemaJoyería.Controller.LoginController;
using System;
using System.Windows.Forms;

namespace SistemaJoyería.View.LoginView
{
    public partial class FrmChangePassword : Form
    {
        private ChangePasswordController changePasswordController;

        // El constructor del formulario
        public FrmChangePassword(string user)
        {
            InitializeComponent();

            changePasswordController = new ChangePasswordController(this, user);
        }

        // Evento que ocurre cuando el formulario se carga
        private void FrmChangePassword_Load(object sender, EventArgs e)
        {

        }
    }
}