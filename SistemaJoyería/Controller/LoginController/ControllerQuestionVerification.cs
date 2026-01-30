using SistemaJoyería.View.LoginView;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using SistemaJoyería.Model.DAO;

namespace SistemaJoyería.Controller.LoginController
{
    internal class ControllerQuestionVerification
    {
        private FrmQuestionsLogin objVerifications;
        private string username;

        public ControllerQuestionVerification(FrmQuestionsLogin vista)
        {
            objVerifications = vista;
            objVerifications.btnVerificarRespuestas.Click += new EventHandler(VerificarRespuestasDS);
            objVerifications.btnComeBack.Click += new EventHandler(ShowRecover);

            // Deshabilitar copiar y pegar en todos los TextBox
            DisableCopyPaste(objVerifications.txtUsuario);
            DisableCopyPaste(objVerifications.txtRespuesta1);
            DisableCopyPaste(objVerifications.txtRespuesta2);
            DisableCopyPaste(objVerifications.txtRespuesta3);

            // Configurar validación para el campo de visitas
            objVerifications.txtRespuesta3.KeyPress += new KeyPressEventHandler(ValidateNumericInput);

            // Quitar el menú
            objVerifications.Menu = null;
        }

        private void DisableCopyPaste(TextBox textBox)
        {
            textBox.ShortcutsEnabled = false;
            textBox.ContextMenu = new ContextMenu();
        }

        private void ValidateNumericInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void VerificarRespuestasDS(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            DAOSecurityQuestions SecurityResults = new DAOSecurityQuestions();
            SecurityResults.Usuario = objVerifications.txtUsuario.Text.Trim();
            SecurityResults.Pregunta1 = objVerifications.txtRespuesta1.Text.Trim();
            SecurityResults.Pregunta2 = objVerifications.txtRespuesta2.Text.Trim();
            SecurityResults.Pregunta3 = objVerifications.txtRespuesta3.Text.Trim();
            username = objVerifications.txtUsuario.Text.Trim();

            bool respuesta = SecurityResults.LeerRespuestas();
            if (respuesta)
            {
                MessageBox.Show("Las respuestas son correctas", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objVerifications.Hide();
                FrmChangePassword2 CambiarContra = new FrmChangePassword2();
                CambiarContra.Show();
            }
            else
            {
                MessageBox.Show("Las respuestas son incorrectas, revise las respuestas que está ingresando", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ShowRecover(object sender, EventArgs e)
        {
            FrmRecoverPassword frmRecoverPassword = new FrmRecoverPassword();
            objVerifications.Hide();
            frmRecoverPassword.Show();
        }
    }
}