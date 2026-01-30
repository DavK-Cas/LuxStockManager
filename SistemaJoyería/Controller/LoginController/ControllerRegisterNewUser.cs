using SistemaJoyería.Model.DAO;
using SistemaJoyería.View.LoginView;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaJoyería.Controller.LoginController
{
    internal class ControllerRegisterNewUser
    {
        FrmRegisterNewUser objRegister;

        public ControllerRegisterNewUser(FrmRegisterNewUser vista)
        {
            objRegister = vista;
            objRegister.Load += new EventHandler(CargarCombos);
            objRegister.btnRegisterNewUser.Click += new EventHandler(RegistrarUsuario);
            objRegister.btnComeBack.Click += new EventHandler(ComeBack);

            // Deshabilitar copiar y pegar en todos los campos
            DisableCopyPaste(objRegister.txtUsuario);
            DisableCopyPaste(objRegister.txtCorreo);
            DisableCopyPaste(objRegister.txtContra);
            DisableCopyPaste(objRegister.txtConfirmContra);

            // Quitar el menú
            objRegister.Menu = null;
        }

        private void DisableCopyPaste(TextBox textBox)
        {
            textBox.ShortcutsEnabled = false;
            textBox.ContextMenu = new ContextMenu();
        }

        public void ComeBack(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            objRegister.Hide();
            frmLogin.Show();
        }

        public void CargarCombos(object sender, EventArgs e)
        {
            DAOLogin ObjRegister = new DAOLogin();
            DataSet dsRoleRegistro = ObjRegister.LlenarCombo("Roles");
            objRegister.cmbRol.DataSource = dsRoleRegistro.Tables["Roles"];
            objRegister.cmbRol.ValueMember = "idRol";
            objRegister.cmbRol.DisplayMember = "NombreRol";
        }

        public void RegistrarUsuario(object sender, EventArgs e)
        {
            // Validar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(objRegister.txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(objRegister.txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(objRegister.txtContra.Text) ||
                string.IsNullOrWhiteSpace(objRegister.txtConfirmContra.Text) ||
                objRegister.cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar formato de correo electrónico
            if (!IsValidEmail(objRegister.txtCorreo.Text.Trim()))
            {
                MessageBox.Show("Por favor, ingrese un correo electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DAOLogin DAORegistrar = new DAOLogin();
            CommonClassesController commonClasses = new CommonClassesController();
            DAORegistrar.LoginName1 = objRegister.txtUsuario.Text.Trim();
            string contra = objRegister.txtContra.Text.Trim();
            string confirmContra = objRegister.txtConfirmContra.Text.Trim();
            DAORegistrar.UserEmail1 = objRegister.txtCorreo.Text.Trim();

            if (contra == confirmContra)
            {
                DAORegistrar.Password1 = commonClasses.ComputeSha256Hash(contra);
                DAORegistrar.IdRol = (int)objRegister.cmbRol.SelectedValue;
                int ValorRetornado = DAORegistrar.RegistrarUsuario();
                if (ValorRetornado == 1)
                {
                    MessageBox.Show("Usuario Registrado Exitosamente", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    objRegister.Hide();
                    FrmRegisterQuestions openForm = new FrmRegisterQuestions();
                    openForm.Show();
                }
                else
                {
                    MessageBox.Show("Usuario NO Registrado ", "Proceso Interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}