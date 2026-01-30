using SistemaJoyería.Model.DAO;
using SistemaJoyería.View.LoginView;
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SistemaJoyería.Controller.LoginController
{
    internal class ChangePasswordController
    {
        FrmChangePassword objCambiarContra;

        // El constructor agarra los eventos de la vista
        public ChangePasswordController(FrmChangePassword Vista, string user)
        {
            objCambiarContra = Vista;
            objCambiarContra.txtconfirmarusuario.Text = user;
            objCambiarContra.BtnCambiarContra.Click += new EventHandler(CambiarContra);
        }

        private void CambiarContra(object sender, EventArgs e)
        {
            string ConfirRamdomCode = objCambiarContra.txtPin.Text;
            string NuevaContra = objCambiarContra.txtNuevaContra.Text;
            string ConfirmarContra = objCambiarContra.txtConfirmarContra.Text;

            // Validaciones de la nueva contraseña
            if (!CumpleConRequisitos(NuevaContra))
            {
                MessageBox.Show("La contraseña no cumple con los requisitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (NuevaContra != ConfirmarContra)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DAOCambiarClave DAOdatacambiarClave = new DAOCambiarClave();
            CommonClassesController commonClasses = new CommonClassesController();
            DAOdatacambiarClave.Password1 = NuevaContra;
            DAOdatacambiarClave.LoginName1 = objCambiarContra.txtconfirmarusuario.Text;

            string cadenaencriptada = commonClasses.ComputeSha256Hash(NuevaContra);
            string cadenaencriptada2 = commonClasses.ComputeSha256Hash(ConfirmarContra);

            // Verificar el PIN y las contraseñas encriptadas
            if (ControllerRecuperarPorCorreo.codigoAleatorio == ConfirRamdomCode && cadenaencriptada == cadenaencriptada2)
            {
                DAOdatacambiarClave.DAOCambiarclave();
                MessageBox.Show("La clave se ha cambiado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objCambiarContra.Close();

                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();
            }
            else
            {
                MessageBox.Show("La clave no se ha podido cambiar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                objCambiarContra.Close();
            }
        }

        // Función para validar los requisitos de la contraseña
        private bool CumpleConRequisitos(string password)
        {
            // Al menos 8 caracteres
            if (password.Length < 8)
                return false;

            // Al menos un signo como % $ #
            if (!Regex.IsMatch(password, @"[!@#$%^&*(),.?""{}|<>]"))
                return false;

            // Al menos una mayúscula A-Z
            if (!Regex.IsMatch(password, @"[A-Z]"))
                return false;

            // Al menos una minúscula a-z
            if (!Regex.IsMatch(password, @"[a-z]"))
                return false;

            // Al menos un número 0-9
            if (!Regex.IsMatch(password, @"[0-9]"))
                return false;

            return true;
        }
    }
}
