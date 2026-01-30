using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaJoyería.Controller.LoginController;

namespace SistemaJoyería.View.LoginView
{
    public partial class FrmQuestionsLogin : Form
    {
        public FrmQuestionsLogin()
        {
            InitializeComponent();
            ControllerQuestionVerification control = new ControllerQuestionVerification(this);
        }
    }
}
