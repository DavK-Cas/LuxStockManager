using SistemaJoyería.View;
using SistemaJoyería.View.LoginView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace SistemaJoyería.Controller.LoginController
{
    internal class RecoverPasswordController
    {
        FrmRecoverPassword objLogin;

        //el constructor agarra los eventos de la vista
        public RecoverPasswordController(FrmRecoverPassword Vista)
        {
            objLogin = Vista;
            objLogin.btnPreguntas.Click += new EventHandler(AbrirPreguntas);
            objLogin.btnAdmin.Click += new EventHandler(interAdmin);
            objLogin.btnCorreo.Click += new EventHandler(EnviarCorreo);
            objLogin.btnComeBack.Click += new EventHandler(ComeBack);
        }

        void ComeBack(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            objLogin.Hide();
            frmLogin.Show();
        }

        public void EnviarCorreo(object sender, EventArgs e)
        {
            objLogin.Hide();
            RecuperarCorreo openForm = new RecuperarCorreo();
            openForm.Show();
        }

        public void interAdmin(object sender, EventArgs e)
        {
            objLogin.Hide();
            FrmInterFromAdmin openForm = new FrmInterFromAdmin();
            openForm.Show();
        }

        public void AbrirPreguntas(object sender, EventArgs e)
        {
            FrmQuestionsLogin opneFrom = new FrmQuestionsLogin();
            opneFrom.Show();
            objLogin.Hide();
        }

    }
}
