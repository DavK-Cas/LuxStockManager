using SistemaJoyería.Model.DAO;
using SistemaJoyería.View;
using SistemaJoyería.View.FirstUseView;
using SistemaJoyería.View.LoginView;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SistemaJoyería.Controller.LoginController
{
    internal class ControllerInterFromAdmin
    {
        FrmInterFromAdmin objAdmin;

        public ControllerInterFromAdmin(FrmInterFromAdmin vista)
        {
            objAdmin = vista;
            objAdmin.BtnContraAdmin.Click += new EventHandler(ConfirmarClave);
            objAdmin.btnComeBack.Click += new EventHandler(ComeBack);
        }

        public void ConfirmarClave(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand();

            string ClaveAdmin = objAdmin.txtContraseñaAdmin.Text;



            DAOverificarAdmin dAOverificarContraAdmin = new DAOverificarAdmin();
            CommonClassesController commonClasses = new CommonClassesController();
            dAOverificarContraAdmin.Password1 = objAdmin.txtContraseñaAdmin.Text.Trim();
            string cadenaencriptada = commonClasses.ComputeSha256Hash(objAdmin.txtContraseñaAdmin.Text);
            dAOverificarContraAdmin.Password1 = commonClasses.ComputeSha256Hash(objAdmin.txtContraseñaAdmin.Text);
            bool Respuesta = dAOverificarContraAdmin.VerificarContraseñaAdmin();

            if (Respuesta == true)
            {

                MessageBox.Show("Su contraseña es correcta, Bienvenido Administrador.", "Acceso permitido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objAdmin.Hide();
                FrmNewPasswordFormAdmin claveUserAdmin = new FrmNewPasswordFormAdmin();
                claveUserAdmin.Show();
            }
            else
            {
                MessageBox.Show("Solo el administrador puede cambiar la contraseña", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ComeBack(object sender, EventArgs e)
        {
            FrmRecoverPassword frmRecoverPassword = new FrmRecoverPassword();
            objAdmin.Hide();
            frmRecoverPassword.Show();
        }
    }
}
