using SistemaJoyería.Model.DAO;
using SistemaJoyería.View.ClientsView;
using SistemaJoyería.View.UsersView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaJoyería.Controller.UserController
{
    public class UserViewController
    {
        FrmUserView ObjView;

        public UserViewController(FrmUserView view)
        {
            ObjView = view;
            view.Load += new EventHandler(InitialCharge);
            //Eventos del CRUD (Read, Delete, Update)
            view.btnUpdate.Click += new EventHandler(UpdateRegister);
            view.cmsDeleteUser.Click += new EventHandler(DeleteUser);
            ////Eventos
            view.btnRefresh.Click += new EventHandler(RefreshPage);
            view.btnClear.Click += new EventHandler(ClearUpdateZone);
            view.btnSearchUser.Click += new EventHandler(SearcUsersEvent);
            //view.MenuProductos.MouseDown += new MouseEventHandler(OnlyDGV);
            ////Sección de Validaciones
            view.dgvUser.CellClick += new DataGridViewCellEventHandler(SelectUser);
            //view.txtUpdateUserEmail.KeyPress += new KeyPressEventHandler(TbUEmail_KeyPress);
            DisableCopyCutPaste(view.txtUpdateUserName);
            DisableCopyCutPaste(view.txtUpdateUserPassword);
            DisableCopyCutPaste(view.txtUpdateUserEmail);
            DisableCopyCutPaste(view.txtSearchUser);
        }
        void InitialCharge(object sender, EventArgs e)
        {
            ShowDGVUsers();
            ReadOnly(sender, e);
        }
        void ReadOnly(object sender, EventArgs e)
        {
            ObjView.txtUpdateUserName.ReadOnly = true;
            ObjView.txtUpdateUserEmail.ReadOnly = true;
            ObjView.txtUpdateUserPassword.ReadOnly = true;
            ObjView.cmbRolUser.Enabled = false;
            ObjView.txtUpdateEstado.ReadOnly = true;
            ObjView.txtIdUser.ReadOnly = true;

        }
        void NotReadOnly(object sender, EventArgs e)
        {
            ObjView.txtUpdateUserName.ReadOnly = false;
            ObjView.txtUpdateUserEmail.ReadOnly = false;
            ObjView.txtUpdateUserPassword.ReadOnly = false;
            ObjView.cmbRolUser.Enabled = true;
        }

        // Asignar el evento MouseDown al DataGridView
        //private void OnlyDGV(object sender, MouseEventArgs e)
        //{
        //    // Verificar si el clic fue con el botón derecho del mouse
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        // Obtener el índice de la fila bajo el cursor
        //        var hitTestInfo = ObjView.dgvUser.HitTest(e.X, e.Y);

        //        // Verificar si se ha hecho clic en una fila (no en el encabezado ni en una celda vacía)
        //        if (hitTestInfo.RowIndex >= 0)
        //        {
        //            // Seleccionar la fila correspondiente
        //            ObjView.dgvUser.ClearSelection();
        //            ObjView.dgvUser.Rows[hitTestInfo.RowIndex].Selected = true;

        //            // Mostrar el ContextMenuStrip en la posición del mouse
        //            ObjView.MenuProductos.Show(ObjView.dgvUser, new Point(e.X, e.Y));
        //        }
        //    }
        //}

        //CRUD
        public void ShowDGVUsers()
        {
            //Creamos un objeto de tipo DAO
            UserViewDAO daoVC = new UserViewDAO();
            //Ejecutamos el método para obtener los datos y los almacenamos en un DataSet
            DataSet ds = daoVC.ShowDGV();
            //Asignamos la tabla del DataSet como la fuente de datos para el DataGridView
            ObjView.dgvUser.DataSource = ds.Tables["v_Users"];
        }
        //Validar el patrón del correo
        private bool Emailverifaction(string email)
        {
            // Definimos el patrón para validar el formato de correo electrónico.
            // - El correo comience con uno o más caracteres que no sean @ ni espacios.
            // - Siga con el símbolo @.
            // - Continúe con uno o más caracteres que no sean @ ni espacios, representando el dominio.
            // - Contenga un punto (.) separando el dominio de la extensión.
            // - Termine con uno o más caracteres que no sean @ ni espacios, representando la extensión del dominio (por ejemplo, com, org).
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Utilizamos Regex.IsMatch para verificar si el correo electrónico coincide con el patrón definido.
            // Si el correo electrónico tiene el formato correcto, IsMatch devuelve true.
            // Si el correo electrónico no coincide con el patrón, devuelve false.
            return Regex.IsMatch(email, emailPattern);
        }
        void UpdateRegister(object sender, EventArgs e)
        {
            // Se crea variable para cada TB y CMB
            string ID = ObjView.txtIdUser.Text.Trim();
            string UserName = ObjView.txtUpdateUserName.Text.Trim();
            string PassWord = ObjView.txtUpdateUserPassword.Text.Trim();
            string Email = ObjView.txtUpdateUserEmail.Text.Trim();
            string Estado = ObjView.txtUpdateEstado.Text.Trim();
            string Rol = ObjView.cmbRolUser.Text.Trim();

            // Validamos si los campos requeridos no están vacíos
            if (!(string.IsNullOrEmpty(UserName) ||
                  string.IsNullOrEmpty(PassWord) ||
                  string.IsNullOrEmpty(Email) || !Emailverifaction(Email)))
            {
                    UserViewDAO daoUpdate = new UserViewDAO();
                    daoUpdate.IDUser1 = int.Parse(ID);
                    daoUpdate.UserName1 = UserName;
                    daoUpdate.Password1 = PassWord;
                    daoUpdate.UserEmail1 = Email;
                    daoUpdate.Estado1 = Estado;
                    daoUpdate.IdRoles1 = Rol;

                    int retorno = daoUpdate.UpdateUser();
                    if (retorno == 1)
                    {
                        MessageBox.Show("El Usuario seleccionado fue actualizado", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowDGVUsers();
                        ClearUpdateZone(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("El Usuario seleccionado no pudo ser actualizado", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
            }
            else
            {
                MessageBox.Show("Usuario no seleccionado o datos faltantes o incorrectos, favor verificar datos ingresados", "Revisa la información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void DeleteUser(object sender, EventArgs e)
        {
            //capturando el indice de la fila
            int pos = ObjView.dgvUser.CurrentRow.Index;
            UserViewDAO daoDelete = new UserViewDAO();
            daoDelete.IDUser1 = int.Parse(ObjView.dgvUser[0, pos].Value.ToString());
            int retorno = daoDelete.DeleteUser();
            if (retorno == 1)
            {
                MessageBox.Show("El usuario seleccionado fue eliminado", "proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowDGVUsers();
            }
            else
            {
                MessageBox.Show("El usuario seleccionado no pudo ser eliminado", "proceso incompletado", MessageBoxButtons.OK, MessageBoxIcon.Warning);             
            }
        }


        void ClearUpdateZone(object sender, EventArgs e)
        {
            ObjView.txtUpdateUserName.Clear();
            ObjView.txtUpdateUserPassword.Clear();
            ObjView.txtUpdateUserEmail.Clear();
            ObjView.cmbRolUser.Items.Clear();
            ObjView.txtIdUser.Clear();
            ReadOnly(sender, e);
        }
        void SelectUser(object sender, DataGridViewCellEventArgs e)
        {
            int pos = ObjView.dgvUser.CurrentRow.Index;

            ObjView.txtIdUser.Text = ObjView.dgvUser[0, pos].Value.ToString();
            NotReadOnly(sender, e);
            ObjView.txtUpdateUserName.Text = ObjView.dgvUser[1, pos].Value.ToString();
            ObjView.txtUpdateUserPassword.Text = (ObjView.dgvUser[2, pos].Value.ToString());
            ObjView.txtUpdateUserEmail.Text = ObjView.dgvUser[3, pos].Value.ToString();
            ObjView.txtUpdateEstado.Text = ObjView.dgvUser[4, pos].Value.ToString();
            ObjView.cmbRolUser.Text = ObjView.dgvUser[5, pos].Value.ToString();
        }
        void RefreshPage(object sender, EventArgs e)
        {
            ShowDGVUsers();
        }
        public void SearchUsers(object sender, KeyPressEventArgs e)
        {
            SearchUsersController();
        }
        //Buscar productos
        public void SearcUsersEvent(object sender, EventArgs e) { SearchUsersController(); }
        void SearchUsersController()
        {
            UserViewDAO userViewDAO = new UserViewDAO();
            DataSet ds = userViewDAO.SearchUser(ObjView.txtSearchUser.Text.Trim());
            ObjView.dgvUser.DataSource = ds.Tables["v_Users"];
        }
        void DisableCopyCutPaste(TextBox textBox)
        {
            // Deshabilitamos el menú contextual del TextBox
            textBox.ContextMenu = new ContextMenu();

            // Capturamos el evento KeyDown para detectar si se intenta copiar, cortar o pegar con atajos de teclado
            textBox.KeyDown += (sender, e) =>
            {
                // Verificamos si se está intentando copiar (Ctrl + C), cortar (Ctrl + X), o pegar (Ctrl + V)
                if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
                {
                    e.SuppressKeyPress = true; // Suprimimos la tecla para evitar la acción
                }
            };
        }
    }
}







