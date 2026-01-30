using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaJoyería.Model.DAO;
using SistemaJoyería.Model.DTO;
using SistemaJoyería.View.ClientsView;

namespace SistemaJoyería.Controller.ClientsController
{
    public class ViewClientsController
    {
        FrmClientsView ObjView;

        public ViewClientsController(FrmClientsView view)
        {
            ObjView = view;
            view.Load += new EventHandler(InitialCharge);
            //Eventos del CRUD (Read, Delete, Update)
            view.btnAddClients.Click += new EventHandler(ShowAddClients);
            view.btnUpdate.Click += new EventHandler(UpdateRegister);
            //Eventos
            view.btnRefresh.Click += new EventHandler(RefreshPage);
            view.btnClearUpdate.Click += new EventHandler(ClearUpdateZone);
            view.btnSearchClient.Click += new EventHandler(SearchClientsEvent);
            //Sección de Validaciones
            view.dtpUClientsBirthday.MaxDate = DateTime.Today.AddYears(-18);
            view.dtpUClientsBirthday.MinDate = DateTime.Now.AddYears(-61);
            view.tbUClientsName.KeyPress += new KeyPressEventHandler(OnlyLettersSpace);
            view.tbUClientsSurname.KeyPress += new KeyPressEventHandler(OnlyLettersSpace);
            view.tbSearchClient.KeyPress += new KeyPressEventHandler(OnlyLettersSpace);
            view.dgvClientsTable.CellClick += new DataGridViewCellEventHandler(SelectClient);
            view.tbUEmail.KeyPress += new KeyPressEventHandler(TbUEmail_KeyPress);
            view.tbUAddress.KeyPress += new KeyPressEventHandler(TbUAddress_KeyPress);
            view.tbUClientsName.TextChanged += new EventHandler(Limit25);
            view.tbUClientsSurname.TextChanged += new EventHandler(Limit25);
            view.tbUEmail.TextChanged += new EventHandler(Limit50);
            view.tbUAddress.TextChanged += new EventHandler(Limit150);
            DisableCopyCutPaste(view.tbUClientsName);
            DisableCopyCutPaste(view.tbUClientsSurname);
            DisableCopyCutPasteMasked(view.mskUCellphoneN);
            DisableCopyCutPasteMasked(view.mskUDuiDoc);
            DisableCopyCutPaste(view.tbUEmail);
            DisableCopyCutPaste(view.tbUAddress);
            DisableCopyCutPaste(view.tbSearchClient);
        }

        void InitialCharge(object sender, EventArgs e)
        {
            ShowDGVlients();
            ReadOnly(sender, e);
        }

        void ReadOnly(object sender, EventArgs e)
        {
            ObjView.tbUClientsName.ReadOnly = true;
            ObjView.tbUClientsSurname.ReadOnly = true;
            ObjView.mskUCellphoneN.ReadOnly = true;
            ObjView.mskUDuiDoc.ReadOnly = true;
            ObjView.tbUEmail.ReadOnly = true;
            ObjView.tbUAddress.ReadOnly = true;
            ObjView.dtpUClientsBirthday.Enabled = false;
        }

        //CRUD
        public void ShowDGVlients()
        {
            //Creamos un objeto de tipo DAO
            ClientsViewDAO daoVC = new ClientsViewDAO();
            //Ejecutamos el método para obtener los datos y los almacenamos en un DataSet
            DataSet ds = daoVC.ShowDGV();
            //Asignamos la tabla del DataSet como la fuente de datos para el DataGridView
            ObjView.dgvClientsTable.DataSource = ds.Tables["vw_ClientesInfo"];
        }
        void UpdateRegister(object sender, EventArgs e)
        {
            //Se crea variable para cada TB y MSK
            string ID = ObjView.tbID.Text.Trim();
            string ClientsName = ObjView.tbUClientsName.Text.Trim();
            string ClientsSurName = ObjView.tbUClientsSurname.Text.Trim();
            string Email = ObjView.tbUEmail.Text.Trim();
            DateTime BirthDay = ObjView.dtpUClientsBirthday.Value;
            string Address = ObjView.tbUAddress.Text.Trim();
            string telefono = ObjView.mskUCellphoneN.Text.Trim().Replace("-", "");
            string DUI = ObjView.mskUDuiDoc.Text.Trim().Replace("-", "");

            // Validamos si los campos de nombres y apellidos no están vacíos
            if (!(string.IsNullOrEmpty(ClientsName) || string.IsNullOrEmpty(ClientsSurName) ||
                  // Validamos si el campo de número de teléfono no está vacío y tiene exactamente 8 dígitos
                  string.IsNullOrEmpty(telefono) || telefono.Length != 8 || !telefono.All(char.IsDigit) ||
                  // Validamos si el campo de DUI no está vacío
                  string.IsNullOrEmpty(DUI) || DUI.Length != 9 || !DUI.All(char.IsDigit) ||
                  // Validamos si el campo de correo electrónico no está vacío y el formato del correo es correcto
                  string.IsNullOrEmpty(Email) || !Emailverifaction(Email) ||
                  // Validamos si el campo de dirección no está vacío y que no sobrepase los 100 caracteres
                  string.IsNullOrEmpty(Address) || Address.Length > 100))
            {
                // Si todas las validaciones pasan, actualizamos el registro
                ClientsViewDAO daoUpdate = new ClientsViewDAO();
                daoUpdate.IdClient = int.Parse(ID);
                daoUpdate.FirstName = ClientsName;
                daoUpdate.LastName = ClientsSurName;
                daoUpdate.Phone = ObjView.mskUCellphoneN.Text.Trim();
                daoUpdate.Email = Email;
                daoUpdate.BirthDate = BirthDay;
                daoUpdate.IdentityDocument = ObjView.mskUDuiDoc.Text.Trim();
                daoUpdate.AddressClient = Address;

                int retorno = daoUpdate.UpdateClients();
                if (retorno == 1)
                {
                    MessageBox.Show("El cliente seleccionado fue actualizado", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowDGVlients();
                    ClearUpdateZone(sender, e);
                }
                else
                {
                    MessageBox.Show("El cliente seleccionado no pudo ser actualizado", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Cliente no seleccionado o datos faltantes o incorrectos, favor verificar datos ingresados", "Revisa la información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        //Métodos para eventos
        void ShowAddClients(object sender, EventArgs e)
        {
            FrmAddClients frmAddClients = new FrmAddClients();
            frmAddClients.ShowDialog();
        }
        void SelectClient(object sender, DataGridViewCellEventArgs e)
        {
            int pos = ObjView.dgvClientsTable.CurrentRow.Index;

            ObjView.tbID.Text = ObjView.dgvClientsTable[0, pos].Value.ToString();

            ObjView.tbUClientsName.ReadOnly = false;
            ObjView.tbUClientsSurname.ReadOnly = false;
            ObjView.mskUCellphoneN.ReadOnly = false;
            ObjView.mskUDuiDoc.ReadOnly = false;
            ObjView.tbUEmail.ReadOnly = false;
            ObjView.tbUAddress.ReadOnly = false;
            ObjView.dtpUClientsBirthday.Enabled = true;

            ObjView.tbUClientsName.Text = ObjView.dgvClientsTable[1, pos].Value.ToString();
            ObjView.tbUClientsSurname.Text = (ObjView.dgvClientsTable[2, pos].Value.ToString());
            ObjView.mskUCellphoneN.Text = ObjView.dgvClientsTable[3, pos].Value.ToString();
            ObjView.tbUEmail.Text = ObjView.dgvClientsTable[4, pos].Value.ToString();
            ObjView.dtpUClientsBirthday.Text = ObjView.dgvClientsTable[5, pos].Value.ToString();
            ObjView.mskUDuiDoc.Text = ObjView.dgvClientsTable[6, pos].Value.ToString();
            ObjView.tbUAddress.Text = ObjView.dgvClientsTable[7, pos].Value.ToString();
        }
        void RefreshPage(object sender, EventArgs e)
        {
            ShowDGVlients();
        }
        void ClearUpdateZone(object sender, EventArgs e)
        {
            ObjView.tbUClientsName.Clear();
            ObjView.tbUClientsSurname.Clear();
            ObjView.mskUCellphoneN.Clear();
            ObjView.mskUDuiDoc.Clear();
            ObjView.tbUEmail.Clear();
            ObjView.tbUAddress.Clear();
            ObjView.tbID.Clear();

            ReadOnly(sender, e);

        }

        public void SearchClients(object sender, KeyPressEventArgs e)
        {
            SearchClientsController();
        }
        //Buscar productos
        public void SearchClientsEvent(object sender, EventArgs e) { SearchClientsController(); }
        void SearchClientsController()
        {
           ClientsViewDAO clientsViewDAO = new ClientsViewDAO();
            DataSet ds = clientsViewDAO.SearchClients(ObjView.tbSearchClient.Text.Trim());
            ObjView.dgvClientsTable.DataSource = ds.Tables["vw_ClientesInfo"];
        }


        //Validaciones 

        //Limitar a 25 Caracteres
        private void LimitCharacter25(TextBox textBox)
        {
            textBox.MaxLength = 25;
        }
        private void Limit25(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            LimitCharacter25(textBox);
        }

        //Limitar a 50 Carácteres
        private void CharacterLimit50(TextBox textBox)
        {
            textBox.MaxLength = 50;
        }
        private void Limit50(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            CharacterLimit50(textBox);
        }

        //Limitar a 150 Carácateres
        private void CharacterLimit150(TextBox textBox)
        {
            textBox.MaxLength = 150;
        }
        private void Limit150(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            CharacterLimit150(textBox);
        }

        //Limitar copiar, pegar y cortar en los TB
        private void DisableCopyCutPaste(TextBox textBox)
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

        //Límitar copiar, pegar y cortar en los msk
        private void DisableCopyCutPasteMasked(MaskedTextBox maskedTextBox)
        {
            // Deshabilitamos el menú contextual del MaskedTextBox
            maskedTextBox.ContextMenu = new ContextMenu();

            // Capturamos el evento KeyDown para detectar si se intenta copiar, cortar o pegar con atajos de teclado
            maskedTextBox.KeyDown += (sender, e) =>
            {
                // Verificamos si se está intentando copiar (Ctrl + C), cortar (Ctrl + X), o pegar (Ctrl + V)
                if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
                {
                    e.SuppressKeyPress = true; // Suprimimos la tecla para evitar la acción
                }
            };
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

        //Límitar s sólo letras y un espacio
        private void OnlyLettersSpace(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras y un único espacio
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }

            // Evitar más de un espacio consecutivo
            if (e.KeyChar == ' ' && (sender as TextBox).Text.EndsWith(" "))
            {
                e.Handled = true;
            }
        }

        //Límitar a un tener ningún espacio
        private void TbUEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Evitar cualquier espacio
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        //Límitar a solamente...
        private void TbUAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, números y los caracteres básicos de dirección
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ' && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void mskCantidad_Validating(object sender, CancelEventArgs e)
        {
            // Verificamos si el contenido del MaskedTextBox es numérico y si cumple con el mínimo
            if (int.TryParse(ObjView.mskUCellphoneN.Text, out int cantidad))
            {
                int cantidadMinima = 8; // Define la cantidad mínima que deseas

                if (cantidad < cantidadMinima)
                {                  
                    e.Cancel = true; 
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

    }
}
