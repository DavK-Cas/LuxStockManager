using SistemaJoyería.View.ClientsView;
using SistemaJoyería.View.DashboardView;
using SistemaJoyería.View.EmployeesView;
using SistemaJoyería.View.LoginView;
using SistemaJoyería.View.ProductsView;
using SistemaJoyería.View.SalesDetailsView;
using SistemaJoyería.View.ServerView;
using SistemaJoyería.View.Suppliers;
using SistemaJoyería.View.UsersView;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaJoyería.Controller.DashboardController
{
    internal class DashboardController
    {
        //Puente entre el controlador y el Formulario
        FrmDashboardView ObjDashboard;
        #region Metodo para abrir Formulario
        //gention del la apertura y el cierre de los formularios
        Form currentForm = null;
        //Llamada de eventos
        public DashboardController(FrmDashboardView Vista)
        {
            ObjDashboard = Vista;
            ObjDashboard.btnProducts.Click += new EventHandler(OpenProducts);
            ObjDashboard.btnSales.Click += new EventHandler(OpenSales);
            ObjDashboard.btnSupplier.Click += new EventHandler(OpenSuppliers);
            ObjDashboard.btnClients.Click += new EventHandler(OpenClients);
            ObjDashboard.btnEmployee.Click += new EventHandler(OpenEmployee);
            ObjDashboard.btnServer.Click += new EventHandler(OpenServer);
            ObjDashboard.btnUsers.Click += new EventHandler(OpenUsers);
            ObjDashboard.btnSignOut.Click += new EventHandler(SignOut);

        }

        void SignOut(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();            
            frmLogin.Show();
            ObjDashboard.Hide();
        }
        void OpenServer(object sender, EventArgs e)
        {
            FrmServer frmServer = new FrmServer();
            frmServer.ShowDialog();
        }
        private void OpenProducts(Object sender, EventArgs e)
        {
            AbrirFormulario<FrmProductsView>();
        }

        private void OpenClients(Object sender, EventArgs e)
        {
            AbrirFormulario<FrmClientsView>();
        }

        private void OpenSuppliers(Object sender, EventArgs e)
        {
            AbrirFormulario<FrmSuppliers>();
        }
        
        private void OpenEmployee(Object sender, EventArgs e)
        {
            AbrirFormulario<FrmEmployeesView>();
        }

        private void OpenSales(Object sender, EventArgs e)
        {
            AbrirFormulario<FrmSalesDetailView>();
        }
        private void OpenUsers(Object sender, EventArgs e)
        {
            AbrirFormulario<FrmUserView>();
        }
        //metodo para abrir formulario en el panel contenedor
        public void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            //Se declara objeto de tipo Form llamada formulario
            Form formulario;
            //Se guarda en el panel contenedor del formulario principal todos los controles del formulario que desea abrir <MiForm> posteriormente se guarda todo en el objeto de tipo formulario
            formulario = ObjDashboard.PanelContenedor.Controls.OfType<MiForm>().FirstOrDefault();
            //Si el formulario no existe se procederá a crearlo de lo contrario solo se traerá al frente (ver clausula else)
            if (formulario == null)
            {
                //Se define un nuevo formulario para guardarse como nuevo objeto MiForm
                formulario = new MiForm();
                //Se especifica que el formulario debe mostrarse como ventana
                formulario.TopLevel = false;
                //Se eliminan los bordes del formulario
                formulario.FormBorderStyle = FormBorderStyle.None;
                //Se establece que se abrira en todo el espacio del formulario padre
                formulario.Dock = DockStyle.Fill;
                //Se le asigna una opacidad de 0.75
                formulario.Opacity = 0.75;
                //Se evalua el formulario actual para verificar si es nulo
                if (currentForm != null)
                {
                    //Se cierra el formulario actual para mostrar el nuevo formulario
                    currentForm.Close();
                    //Se eliminan del panel contenedor todos los controles del formulario que se cerrará
                    ObjDashboard.PanelContenedor.Controls.Remove(currentForm);
                }
                //Se establece como nuevo formulario actual el formulario que se está abriendo
                currentForm = formulario;
                //Se agregan los controles del nuevo formulario al panel contenedor
                ObjDashboard.PanelContenedor.Controls.Add(formulario);
                //Tag es una propiedad genérica disponible para la mayoría de los controles en aplicaciones .NET, incluyendo los paneles.
                ObjDashboard.PanelContenedor.Tag = formulario;
                //Se muestra el formulario en el panel contenedor
                formulario.Show();
                //Se trae al frente el formulario armado
                formulario.BringToFront();
            }
            else
            {
                formulario.BringToFront();
            }
        }
        public void CerrarForm(object sender, EventArgs e)
        {
            //Se cierra el formulario actual para mostrar el nuevo formulario
            currentForm.Close();
            //Se eliminan del panel contenedor todos los controles del formulario que se cerrará
            ObjDashboard.PanelContenedor.Controls.Remove(currentForm);
        }
        #endregion
    }
}