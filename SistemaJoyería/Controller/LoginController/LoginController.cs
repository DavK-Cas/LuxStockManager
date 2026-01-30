using System;
using System.Windows.Forms;
using SistemaJoyería.Model.DAO;
using SistemaJoyería.View.LoginView;
using SistemaJoyería.View.DashboardView;

namespace SistemaJoyería.Controller.LoginController
{
    public class LoginController
    {
        FrmLogin objLogin;
        int intentos = 0;

        public LoginController(FrmLogin Vista)
        {
            objLogin = Vista;

            // Configurar eventos
            objLogin.btnIngresar.Click += new EventHandler(DatosAcceso);
            objLogin.LinklblRecuperar.Click += new EventHandler(ShowMetods);
            objLogin.LinklblRegister.Click += new EventHandler(NewUser);

            // Configurar placeholders y eventos para los TextBox
            SetupTextBox(objLogin.txtUsuario, "Username");
            SetupTextBox(objLogin.txtContraseña, "Password");

            // Configurar la contraseña para que muestre asteriscos
            objLogin.txtContraseña.PasswordChar = '\0'; // Inicialmente muestra el placeholder
            objLogin.txtContraseña.UseSystemPasswordChar = false;

            // Deshabilitar copiar/pegar y menú contextual
            DisableCopyPaste(objLogin.txtUsuario);
            DisableCopyPaste(objLogin.txtContraseña);
        }

        private void SetupTextBox(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = System.Drawing.Color.Gray;

            textBox.Enter += (sender, e) => {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = System.Drawing.Color.Black;
                    if (textBox == objLogin.txtContraseña)
                    {
                        textBox.PasswordChar = '*';
                    }
                }
            };

            textBox.Leave += (sender, e) => {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = System.Drawing.Color.Gray;
                    if (textBox == objLogin.txtContraseña)
                    {
                        textBox.PasswordChar = '\0';
                    }
                }
            };

            textBox.KeyPress += new KeyPressEventHandler(ValidateNoSpaces);
        }

        private void DisableCopyPaste(TextBox textBox)
        {
            textBox.KeyDown += new KeyEventHandler(DisableCopyPasteEvent);
            textBox.ContextMenu = new ContextMenu();
        }

        private void ValidateNoSpaces(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
                MessageBox.Show("No se permiten espacios en el nombre de usuario o la contraseña.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DisableCopyPasteEvent(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.V || e.KeyCode == Keys.C))
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                MessageBox.Show("Copiar y pegar no está permitido por razones de seguridad.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void NewUser(object sender, EventArgs e)
        {
            objLogin.Hide();
            FrmRegisterNewUser openForm = new FrmRegisterNewUser();
            openForm.Show();
        }

        private void DatosAcceso(object sender, EventArgs e)
        {
            string username = objLogin.txtUsuario.Text;
            string password = objLogin.txtContraseña.Text;

            if (username == "Username" || password == "Password" || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Usuario y Contraseña no pueden estar vacíos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DAOLogin DAOData = new DAOLogin();
            DAOData.LoginName1 = username.Trim();
            DAOData.Password1 = password.Trim();

            bool answer = DAOData.LoginValidation();

            if (answer)
            {
                MessageBox.Show("Inicio de sesión correcto", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmDashboardView frmDashboardView = new FrmDashboardView();
                objLogin.Hide();
                frmDashboardView.Show();
            }
            else
            {
                MessageBox.Show("Los datos son incorrectos", "Error al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                intentos++;

                if (intentos == 3)
                {
                    MessageBox.Show("Lamento decirle que ha sido bloqueado, intente de nuevo más tarde.", "Usuario bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    objLogin.Close();
                }
            }
        }

        void ShowMetods(object sender, EventArgs e)
        {
            FrmRecoverPassword frmRecoverPassword = new FrmRecoverPassword();
            objLogin.Hide();
            frmRecoverPassword.Show();
        }
    }
}