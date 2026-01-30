using SistemaJoyería.Model.DAO;
using SistemaJoyería.View;
using SistemaJoyería.View.LoginView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaJoyería.Controller.LoginController
{
    internal class ControllerCambiarContraFromQuestions
    {
        FrmChangePassword objContraFromQuestions;

        public ControllerCambiarContraFromQuestions(FrmChangePassword vista, string username)
        {
            objContraFromQuestions = vista;
            objContraFromQuestions.txtconfirmarusuario.Text = username;
            objContraFromQuestions.txtNuevaContra.Click += new EventHandler(NuevaContraseña);
        }

        public void NuevaContraseña(object sender, EventArgs e)
        {
            DAOCambiarClave daoCambiarClavePDS = new DAOCambiarClave();
            CommonClassesController commonClasses = new CommonClassesController();
            daoCambiarClavePDS.Password1 = objContraFromQuestions.txtNuevaContra.Text.Trim();
            daoCambiarClavePDS.LoginName1 = objContraFromQuestions.txtconfirmarusuario.Text.Trim();
            string cadenaencriptada = commonClasses.ComputeSha256Hash(objContraFromQuestions.txtNuevaContra.Text.Trim());
            string cadenaencriptada2 = commonClasses.ComputeSha256Hash(objContraFromQuestions.txtConfirmarContra.Text.Trim());

            daoCambiarClavePDS.Password1 = commonClasses.ComputeSha256Hash(objContraFromQuestions.txtNuevaContra.Text.Trim());

            bool respuesta = daoCambiarClavePDS.ComprobarusuarioPorAdmin();

            if (!(string.IsNullOrEmpty(objContraFromQuestions.txtNuevaContra.Text.Trim()) ||
            string.IsNullOrEmpty(objContraFromQuestions.txtConfirmarContra.Text.Trim())))
            {
                if (cadenaencriptada == cadenaencriptada2 && respuesta == true)
                {
                    daoCambiarClavePDS.DAOCambiarclave();
                    MessageBox.Show("La contraseña se ha cambiado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    objContraFromQuestions.Hide();
                    FrmLogin frmLogin = new FrmLogin();
                    frmLogin.Show();
                }
                else
                {
                    MessageBox.Show("Ha habido un error al momento de cambiar la clave", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese una nueva contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
