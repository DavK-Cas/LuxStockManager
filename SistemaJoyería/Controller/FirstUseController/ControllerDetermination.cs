using SistemaJoyería.Model.DAO;
using SistemaJoyería.View.FirstUseView;
using SistemaJoyería.View.LoginView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;


namespace SistemaJoyería.Controller
{
    internal class ControllerDetermination
    {
        public static void DeterminationView()
        {
            DAOLogin NewFirstUsuario = new DAOLogin();
            int PrimerUsuario = NewFirstUsuario.ValidarPrimerUsuario();
            if (PrimerUsuario == 0)
            {
                System.Windows.Forms.Application.Run(new FrmFirstUse());
            }
            else
            {
                System.Windows.Forms.Application.Run(new FrmLogin());
            }
        }

    }
}
