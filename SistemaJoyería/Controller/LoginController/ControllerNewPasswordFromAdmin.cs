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
    internal class ControllerNewPasswordFromAdmin
    {
        FrmNewPasswordFormAdmin objNewPassword;

        public ControllerNewPasswordFromAdmin(FrmNewPasswordFormAdmin vista)
        {
            objNewPassword = vista;
            objNewPassword.BtnConfirmarNuevaContraAdmin.Click += new EventHandler(SaveNewPassword);
        }

        public void SaveNewPassword(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand();

            DAOCambiarClave DAOdatacambiarClave = new DAOCambiarClave();
            CommonClassesController commonClasses = new CommonClassesController();

            DAOdatacambiarClave.LoginName1 = objNewPassword.txtNameUserAdmin.Text;
            DAOdatacambiarClave.Password1 = objNewPassword.txtNuevaContraseñaNuevaAdmin.Text;

            string cadenaencriptada = (objNewPassword.txtNuevaContraseñaNuevaAdmin.Text);
            string cadenaencriptada2 = (objNewPassword.txtConfirmarContraseñaNuevaAdmin.Text);

            DAOdatacambiarClave.Password1 = (objNewPassword.txtConfirmarContraseñaNuevaAdmin.Text);

            if (!(string.IsNullOrEmpty(objNewPassword.txtNameUserAdmin.Text.Trim()) ||
         string.IsNullOrEmpty(objNewPassword.txtConfirmarContraseñaNuevaAdmin.Text.Trim()) || string.IsNullOrEmpty(objNewPassword.txtNuevaContraseñaNuevaAdmin.Text.Trim())))
            {

                bool respuesta = DAOdatacambiarClave.ComprobarusuarioPorAdmin();
                if (cadenaencriptada == cadenaencriptada2 && respuesta == true)
                {
                    DAOdatacambiarClave.DAOCambiarclave();
                    MessageBox.Show("La contraseña se ha cambiado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    objNewPassword.Hide();


                    FrmLogin frmLogin = new FrmLogin();
                    frmLogin.Show();


                }
                else
                {
                    MessageBox.Show("Revise si  la contraseña nueva y confirmar contraseña coinciden o si el usuario ingresado es correcto ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese una nueva contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

    }
}
