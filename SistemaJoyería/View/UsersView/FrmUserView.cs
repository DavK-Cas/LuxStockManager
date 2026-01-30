using SistemaJoyería.Controller.UserController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaJoyería.View.UsersView
{
    public partial class FrmUserView : Form
    {
        public FrmUserView()
        {
            InitializeComponent();
            UserViewController userViewController = new UserViewController(this);
        }   
    }
}
