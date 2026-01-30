using SistemaJoyería.Model.DAO;
using SistemaJoyería.View.LoginView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaJoyería.Controller.LoginController
{
    internal class ControllerRegisterQuestions
    {
        FrmRegisterQuestions objAddQuestions;

        public ControllerRegisterQuestions(FrmRegisterQuestions vista)
        {
            objAddQuestions = vista;
            objAddQuestions.btnVerificarRespuestas.Click += new EventHandler(GuardarPreguntas);
        }

        public void GuardarPreguntas(object sender, EventArgs e)
        {
            DAOSecurityQuestions DAOQuestions = new DAOSecurityQuestions();
            DAOQuestions.Usuario = objAddQuestions.txtUsuario.Text.Trim();
            DAOQuestions.Pregunta1 = objAddQuestions.txtRespuesta1.Text.Trim();
            DAOQuestions.Pregunta2 = objAddQuestions.txtPregunta2.Text.Trim();
            DAOQuestions.Pregunta3 = objAddQuestions.txtRespuesta3.Text.Trim();

            int ValorRetornado = DAOQuestions.ingresarPreguntas();
            if (ValorRetornado == 1)
            {
                MessageBox.Show("Preguntas Guardadas", "Proceso Completo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objAddQuestions.Hide();
                FrmLogin openForm = new FrmLogin();
                openForm.Show();
            }
            else
            {
                MessageBox.Show("Preguntas No Guardadas", "Proceso Interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
