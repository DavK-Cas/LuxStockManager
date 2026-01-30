using SistemaJoyería.View.LoginView;
using System;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using SistemaJoyería.Model.DAO;

namespace SistemaJoyería.Controller.LoginController
{
    internal class ControllerRecuperarPorCorreo
    {
        RecuperarCorreo objRecuperarPorCorreo;

        public ControllerRecuperarPorCorreo(RecuperarCorreo vista)
        {
            objRecuperarPorCorreo = vista;
            objRecuperarPorCorreo.BtnEnviarCorreo.Click += new EventHandler(EnviarCorreo);
            objRecuperarPorCorreo.btnComeBack.Click += new EventHandler(ComeBack);

            // Eventos para bloquear copiar y pegar
            objRecuperarPorCorreo.txtCorreo.KeyDown += new KeyEventHandler(BloquearCopiarPegar);
            objRecuperarPorCorreo.txtCorreo.ContextMenu = new ContextMenu(); // Deshabilitar menú contextual
        }

        public static string codigoAleatorio;
        public static string correoUsuario;

        public void ComeBack(object sender, EventArgs e)
        {
            FrmRecoverPassword frmRecoverPassword = new FrmRecoverPassword();
            objRecuperarPorCorreo.Hide();
            frmRecoverPassword.Show();
        }

        public void EnviarCorreo(Object sender, EventArgs e)
        {
            // Validación para verificar que los campos no sean nulos
            if (string.IsNullOrEmpty(objRecuperarPorCorreo.txtCorreo.Text.Trim()))
            {
                MessageBox.Show("El campo de correo no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DAOCambiarClave dAOcambiarClave = new DAOCambiarClave();
            dAOcambiarClave.UserEmail1 = objRecuperarPorCorreo.txtCorreo.Text;

            // Validar si el correo está registrado
            if (!dAOcambiarClave.ComprobarUsuario(dAOcambiarClave.UserEmail1))
            {
                MessageBox.Show("El correo ingresado no existe. Verifique los datos e intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar formato de correo
            if (!IsValidEmail(dAOcambiarClave.UserEmail1))
            {
                MessageBox.Show("Ingrese un correo electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Generar un código aleatorio de 6 dígitos
            codigoAleatorio = GenerateRandomCode(6);

            // Enviar el correo con el código
            try
            {
                // Configura la información del correo (reemplaza con tus credenciales)
                string servidorSMTP = "smtp.gmail.com";
                int puertoSMTP = 587;
                string usuarioSMTP = "luxstockmanagerr2024@gmail.com";  // Tu correo
                string contrasenaSMTP = "feqf lqki cgpb jgxu";  // Tu contraseña de app

                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress(usuarioSMTP);
                mensaje.To.Add(dAOcambiarClave.UserEmail1);
                mensaje.Subject = "Recuperación de Contraseña";
                mensaje.Body = $"Tu código de recuperación es: {codigoAleatorio}";

                SmtpClient clienteSMTP = new SmtpClient(servidorSMTP, puertoSMTP);
                clienteSMTP.EnableSsl = true;
                clienteSMTP.Credentials = new NetworkCredential(usuarioSMTP, contrasenaSMTP);
                clienteSMTP.Send(mensaje);

                MessageBox.Show("Se ha enviado un correo con el código de recuperación.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objRecuperarPorCorreo.Hide();
                FrmChangePassword frmCambiarContra = new FrmChangePassword(correoUsuario);
                frmCambiarContra.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private string GenerateRandomCode(int length)
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // Método para bloquear copiar y pegar
        private void BloquearCopiarPegar(object sender, KeyEventArgs e)
        {
            // Bloquear Ctrl+C, Ctrl+V y Ctrl+X
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                e.SuppressKeyPress = true; // Bloquear el evento de tecla
            }
        }
    }
}
