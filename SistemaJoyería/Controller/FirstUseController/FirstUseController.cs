using SistemaJoyería.Controller.LoginController;
using SistemaJoyería.Model.DAO;
using SistemaJoyería.View.FirstUseView;
using SistemaJoyería.View.LoginView;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaJoyería.Controller.FirstUserController
{
    internal class ControllerFirstUser
    {
        FrmFirstUse objFirstUser;
        SqlCommand Command = new SqlCommand();

        public ControllerFirstUser(FrmFirstUse vista)
        {
            objFirstUser = vista;
            objFirstUser.btnRegisterNewUser.Click += new EventHandler(NewUser);
        }

        public void NewUser(object sender, EventArgs e)
        {
            if (objFirstUser != null)
            {
                DAOLogin DAORegistrar = new DAOLogin();
                CommonClassesController commonClasses = new CommonClassesController();
                DAORegistrar.LoginName1 = objFirstUser.txtUsuario.Text.Trim();
                string contra = objFirstUser.txtContra.Text.Trim();
                string confirmContra = objFirstUser.txtConfirmContra.Text.Trim();
                DAORegistrar.UserEmail1 = objFirstUser.txtCorreo.Text.Trim();
                if (contra == confirmContra)
                {
                    DAORegistrar.Password1 = commonClasses.ComputeSha256Hash(objFirstUser.txtContra.Text.Trim());
                    int ValorRetornado = DAORegistrar.RegistrarPrimerUsuario();
                    if (ValorRetornado == 1)
                    {
                        MessageBox.Show("Usuario Registrado Exitosamente", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        objFirstUser.Hide();
                        FrmRegisterQuestions openForm = new FrmRegisterQuestions();
                        openForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario NO Registrado", "Proceso Interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Formulario no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}