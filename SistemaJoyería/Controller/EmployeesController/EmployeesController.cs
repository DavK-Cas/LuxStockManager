using SistemaJoyería.Model.DAO;
using SistemaJoyería.View.ClientsView;
using SistemaJoyería.View.EmployeesView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaJoyería.Controller.EmployeesController
{
    internal class EmployeesController
    {
        FrmEmployeesView ObjView;

        public EmployeesController(FrmEmployeesView view)
        {
            ObjView = view;

            view.Load += new EventHandler(InitialCharge);
            //Eventos del CRUD (Read, Delete, Update)
            view.btnAddEmployee.Click += new EventHandler(ShowAddCEmployee);
            view.btnUpdate.Click += new EventHandler(UpdateRegister);
            view.cmsDeleteEmployees.Click += new EventHandler(DeleteEmployee);

            //Eventos
            view.btnRestart.Click += new EventHandler(RefreshPage);
            view.btnClear.Click += new EventHandler(ClearUpdateZone);
            view.btnSearchEmployee.Click += new EventHandler(SearchEmployeesEvent);

            //Sección de Validaciones
            view.dtpUpdateBirthDay.MaxDate = DateTime.Today.AddYears(-18);
            view.dtpUpdateBirthDay.MinDate = DateTime.Now.AddYears(-61);
            view.txtUpdateEmployeeName.KeyPress += new KeyPressEventHandler(OnlyLettersSpace);
            view.txtUpdateEmployeeLastName.KeyPress += new KeyPressEventHandler(OnlyLettersSpace);
            view.txtSearchEmployee.KeyPress += new KeyPressEventHandler(OnlyLettersSpace);
            view.dgvEmployees.CellClick += new DataGridViewCellEventHandler(SelectEmployees);
            view.txtUpdateEmployeeEmail.KeyPress += new KeyPressEventHandler(TbUEmail_KeyPress);
            view.txtUAddress.KeyPress += new KeyPressEventHandler(TbUAddress_KeyPress);

            // Límites de caracteres en TextBox
            view.txtUpdateEmployeeName.TextChanged += new EventHandler(Limit25);
            view.txtUpdateEmployeeLastName.TextChanged += new EventHandler(Limit25);
            view.txtUpdateEmployeeEmail.TextChanged += new EventHandler(Limit50);
            view.txtUAddress.TextChanged += new EventHandler(Limit150);

            // Deshabilitar copiar, pegar y cortar
            DisableCopyCutPaste(view.txtUpdateEmployeeName);
            DisableCopyCutPaste(view.txtUpdateEmployeeLastName);
            DisableCopyCutPasteMasked(view.mskUpdateEmployeePhoneNumber);
            DisableCopyCutPasteMasked(view.mskUpdateEmployeeDUI);
            DisableCopyCutPaste(view.txtUpdateEmployeeEmail);
            DisableCopyCutPaste(view.txtUAddress);
            DisableCopyCutPaste(view.txtSearchEmployee);
        }

        void InitialCharge(object sender, EventArgs e)
        {
            ShowDGVEmployees();
            ObjView.txtUpdateEmployeeName.ReadOnly = true;
            ObjView.txtUpdateEmployeeLastName.ReadOnly = true;
            ObjView.mskUpdateEmployeePhoneNumber.ReadOnly = true;
            ObjView.mskUpdateEmployeeDUI.ReadOnly = true;
            ObjView.txtUpdateEmployeeEmail.ReadOnly = true;
            ObjView.txtUAddress.ReadOnly = true;
            ObjView.dtpUpdateBirthDay.Enabled = false;
        }

        void ReadOnly(object sender, EventArgs e)
        {
            ObjView.txtUpdateEmployeeName.ReadOnly = true;
            ObjView.txtUpdateEmployeeLastName.ReadOnly = true;
            ObjView.mskUpdateEmployeePhoneNumber.ReadOnly = true;
            ObjView.mskUpdateEmployeeDUI.ReadOnly = true;
            ObjView.txtUpdateEmployeeEmail.ReadOnly = true;
            ObjView.txtUAddress.ReadOnly = true;
            ObjView.dtpUpdateBirthDay.Enabled = false;
        }

        void ShowDGVEmployees()
        {
            //Creamos un objeto de tipo DAO
            EmployeesViewDAO daoVC = new EmployeesViewDAO();
            //Ejecutamos el método para obtener los datos y los almacenamos en un DataSet
            DataSet ds = daoVC.ShowDGV();
            //Asignamos la tabla del DataSet como la fuente de datos para el DataGridView
            ObjView.dgvEmployees.DataSource = ds.Tables["vw_EmployeesInfo"];
        }

        void RefreshPage(object sender, EventArgs e)
        {
            ShowDGVEmployees();
        }

        void ShowAddCEmployee(object sender, EventArgs e)
        {
           FrmAddEmployees frmAddEmployee = new FrmAddEmployees();
            frmAddEmployee.ShowDialog();
        }
    
        void DeleteEmployee(object sender, EventArgs e)
        {
            //capturando el indice de la fila

            int pos = ObjView.dgvEmployees.CurrentRow.Index;
            EmployeesViewDAO daoDelete = new EmployeesViewDAO();
            daoDelete.IdEmployees = int.Parse(ObjView.dgvEmployees[0, pos].Value.ToString());
            int retorno = daoDelete.DeleteEmployees();
            if (retorno == 1)
            {
                MessageBox.Show("El usuario seleccionado fue eliminado", "proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowDGVEmployees();
            }
            else
            {
                MessageBox.Show("El usuario seleccionado no pudo ser eliminado", "proceso incompletado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }   

        void SelectEmployees(object sender, DataGridViewCellEventArgs e)
        {
            int pos = ObjView.dgvEmployees.CurrentRow.Index;

            // Asignamos los valores correspondientes desde el DataGridView a los campos de texto
            ObjView.txtIDEmployee.Text = ObjView.dgvEmployees[0, pos].Value.ToString();

            // Hacemos que los campos no sean de solo lectura para permitir la edición
            ObjView.txtUpdateEmployeeName.ReadOnly = false;
            ObjView.txtUpdateEmployeeLastName.ReadOnly = false;
            ObjView.mskUpdateEmployeePhoneNumber.ReadOnly = false;
            ObjView.mskUpdateEmployeeDUI.ReadOnly = false;
            ObjView.txtUpdateEmployeeEmail.ReadOnly = false;
            ObjView.txtUAddress.ReadOnly = false;
            ObjView.dtpUpdateBirthDay.Enabled = true;

            // Llenamos los TextBox y MaskedTextBox con los valores seleccionados del DataGridView
            ObjView.txtUpdateEmployeeName.Text = ObjView.dgvEmployees[1, pos].Value.ToString();
            ObjView.txtUpdateEmployeeLastName.Text = ObjView.dgvEmployees[2, pos].Value.ToString();
            ObjView.mskUpdateEmployeePhoneNumber.Text = ObjView.dgvEmployees[3, pos].Value.ToString();
            ObjView.txtUpdateEmployeeEmail.Text = ObjView.dgvEmployees[4, pos].Value.ToString();
            ObjView.dtpUpdateBirthDay.Text = ObjView.dgvEmployees[5, pos].Value.ToString();
            ObjView.mskUpdateEmployeeDUI.Text = ObjView.dgvEmployees[6, pos].Value.ToString();
            ObjView.txtUAddress.Text = ObjView.dgvEmployees[7, pos].Value.ToString();
        }


        void UpdateRegister(object sender, EventArgs e)
        {
            //Se crea variable para cada TB y MSK
            string ID = ObjView.txtIDEmployee.Text.Trim();
            string EmploName = ObjView.txtUpdateEmployeeName.Text.Trim();
            string EmploSurName = ObjView.txtUpdateEmployeeLastName.Text.Trim();
            string Email = ObjView.txtUpdateEmployeeEmail.Text.Trim();
            DateTime BirthDay = ObjView.dtpUpdateBirthDay.Value;
            string Address = ObjView.txtUAddress.Text.Trim();
            string telefono = ObjView.mskUpdateEmployeePhoneNumber.Text.Trim().Replace("-", "");
            string DUI = ObjView.mskUpdateEmployeeDUI.Text.Trim().Replace("-", "");

            // Validamos si los campos de nombres y apellidos no están vacíos
            if (!(string.IsNullOrEmpty(EmploName) || string.IsNullOrEmpty(EmploSurName) ||
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
               EmployeesViewDAO daoUpdate = new EmployeesViewDAO();
                daoUpdate.IdEmployees = int.Parse(ID);
                daoUpdate.FirstNameEmployees = EmploName;
                daoUpdate.LastNameEmployees1 = EmploSurName;
                daoUpdate.PhoneEmployees1 = ObjView.mskUpdateEmployeePhoneNumber.Text.Trim();
                daoUpdate.EmailEmployees1 = Email;
                daoUpdate.BirthDateEmployees1 = BirthDay;
                daoUpdate.IdentityDocumentEmployees1 = ObjView.mskUpdateEmployeeDUI.Text.Trim();
                daoUpdate.AddressEmployees1 = Address;

                int retorno = daoUpdate.UpdateEmployees();
                if (retorno == 1)
                {
                    MessageBox.Show("El cliente seleccionado fue actualizado", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowDGVEmployees();
                    ClearUpdateZone(sender, e);
                }
                else
                {
                    MessageBox.Show("El cliente seleccionado no pudo ser actualizado", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Datos faltantes o incorrectos, revise", "Revisa la información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void ClearUpdateZone(object sender, EventArgs e)
        {
            // Limpiamos los TextBox y MaskedTextBox correspondientes
            ObjView.txtUpdateEmployeeName.Clear();
            ObjView.txtUpdateEmployeeLastName.Clear();
            ObjView.mskUpdateEmployeePhoneNumber.Clear();
            ObjView.mskUpdateEmployeeDUI.Clear();
            ObjView.txtUpdateEmployeeEmail.Clear();
            ObjView.txtUAddress.Clear();
            ObjView.txtIDEmployee.Clear();

            // Hacemos que los campos sean de solo lectura
            ReadOnly(sender, e);
        }

        public void SearchEmployees(object sender, KeyPressEventArgs e)
        {
            SearchEmployeesController();
        }
        //Buscar productos
        public void SearchEmployeesEvent(object sender, EventArgs e) { SearchEmployeesController(); }
        void SearchEmployeesController()
        {
            ClientsViewDAO clientsViewDAO = new ClientsViewDAO();
            DataSet ds = clientsViewDAO.SearchClients(ObjView.txtSearchEmployee.Text.Trim());
            ObjView.dgvEmployees.DataSource = ds.Tables["vw_EmployeesInfo"];
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
            if (int.TryParse(ObjView.mskUpdateEmployeePhoneNumber.Text, out int cantidad))
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
