using SistemaJoyería.Model.DAO;
using SistemaJoyería.View.ClientsView;
using SistemaJoyería.View.EmployeesView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaJoyería.Controller.EmployeesController
{
    internal class AddEmployeesController 
    {
        FrmAddEmployees ObjAddView;

        public AddEmployeesController(FrmAddEmployees viewAdd)
        {
            ObjAddView = viewAdd;

            //Evento del CRUD (Create)
            viewAdd.btnOK.Click += new EventHandler(SaveRegister);
            //Eventos de Click
            viewAdd.btnDelete.Click += new EventHandler(CleanInformation);
            //Sección de validaciones de View
            viewAdd.dtpEmployeeBirthDay.MaxDate = DateTime.Today.AddYears(-18);
            viewAdd.dtpEmployeeBirthDay.MinDate = DateTime.Now.AddYears(-60);
            viewAdd.txtEmployeeName.KeyPress += new KeyPressEventHandler(OnlyLettersSpace);
            viewAdd.txtEmployeeLastName.KeyPress += new KeyPressEventHandler(OnlyLettersSpace);
            viewAdd.txtEmployeeEmail.KeyPress += new KeyPressEventHandler(TbEmail_KeyPress);
            viewAdd.txtAddressEmployee.KeyPress += new KeyPressEventHandler(TbAddress_KeyPress);
            viewAdd.txtEmployeeName.TextChanged += new EventHandler(Limit25);
            viewAdd.txtEmployeeLastName.TextChanged += new EventHandler(Limit25);
            viewAdd.txtEmployeeEmail.TextChanged += new EventHandler(Limit50);
            viewAdd.txtAddressEmployee.TextChanged += new EventHandler(Limit150);
            DisableCopyCutPaste(viewAdd.txtEmployeeName);
            DisableCopyCutPaste(viewAdd.txtEmployeeLastName);
            DisableCopyCutPasteMasked(viewAdd.mskEmployeeCellphone);
            DisableCopyCutPasteMasked(viewAdd.mskEmployeeDUI);
            DisableCopyCutPaste(viewAdd.txtEmployeeEmail);
            DisableCopyCutPaste(viewAdd.txtAddressEmployee);
        }

        void SaveRegister(object sender, EventArgs e)
        {
            string EmployeesName = ObjAddView.txtEmployeeName.Text.Trim();
            string EmployeesSurName = ObjAddView.txtEmployeeLastName.Text.Trim();
            string Email = ObjAddView.txtEmployeeEmail.Text.Trim();
            DateTime BirthDay = ObjAddView.dtpEmployeeBirthDay.Value;
            string Address = ObjAddView.txtAddressEmployee.Text.Trim();
            int AddressLength = ObjAddView.txtAddressEmployee.Text.Length;

            // Eliminamos temporalmente los guiones para validar el formato de teléfono y DUI
            string CellPhone = ObjAddView.mskEmployeeCellphone.Text.Trim().Replace("-", "");
            string DUI = ObjAddView.mskEmployeeDUI.Text.Trim().Replace("-", "");
            if (!(// Validamos si los campos de nombres y apellidos no están vacíos
                  string.IsNullOrEmpty(EmployeesName) || string.IsNullOrEmpty(EmployeesSurName) ||
                     // Validamos si el teléfono tiene exactamente 8 dígitos sin contar guiones
                  string.IsNullOrEmpty(CellPhone) || CellPhone.Length != 8 || !CellPhone.All(char.IsDigit) ||
                   // Validamos si el DUI tiene exactamente 9 dígitos sin contar guiones
                  string.IsNullOrEmpty(DUI) || DUI.Length != 9 || !DUI.All(char.IsDigit) ||
                  // Validamos si el campo de correo electrónico no está vacío y verificamos su formato
                  string.IsNullOrEmpty(Email) || !Emailverifaction(Email) ||
                  // Validamos si el campo de dirección no está vacío y si no sobrepasa los 100 caracteres
                  string.IsNullOrEmpty(Address) || AddressLength > 100))
            {
                // Se crea un objeto de tipo AddEmployeesDAO
                AddEmployeesDAO daoEmployee = new AddEmployeesDAO();

                // Se mandan valores de la vista hacia el DTO de empleados
                daoEmployee.FirstNameEmployees= EmployeesName;
                daoEmployee.LastNameEmployees1= EmployeesSurName;
                daoEmployee.BirthDateEmployees1 = BirthDay;
                daoEmployee.PhoneEmployees1 = ObjAddView.mskEmployeeCellphone.Text.Trim();
                daoEmployee.IdentityDocumentEmployees1 = ObjAddView.mskEmployeeDUI.Text.Trim();
                daoEmployee.EmailEmployees1 = Email;
                daoEmployee.AddressEmployees1 = Address;

                // Registrar empleado en la base de datos
                int resultado = daoEmployee.RegisterEmployees();
                if (resultado == 1)
                {
                    MessageBox.Show("El empleado fue registrado exitosamente", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ObjAddView.Close();
                }
                else
                {
                    MessageBox.Show("El empleado no pudo ser registrado", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Datos faltantes o incorrectos, complete el formulario con la información requerida", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        //Eventos del View
        public void CleanInformation(object sender, EventArgs e)
        {
            //Limpiamos todos los campos del formulario
            ObjAddView.txtEmployeeName.Clear();
            ObjAddView.txtEmployeeLastName.Clear();
            ObjAddView.mskEmployeeCellphone.Clear();
            ObjAddView.mskEmployeeDUI.Clear();
            ObjAddView.txtEmployeeEmail.Clear();
            ObjAddView.txtAddressEmployee.Clear();
        }

        //Validaciones

        //Limitar a 25 Carácteres
        private void CharacterLimit25(TextBox textBox)
        {
            textBox.MaxLength = 25;
        }

        private void Limit25(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            CharacterLimit25(textBox);
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

        //Limitar copiar, pegar y cortar para TB
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

        //Limitar copiar, pegar y cortar para MSK
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

        //Validación para el correo electrónico
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
        private void TbEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Evitar cualquier espacio
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        //Límitar a solamente...
        private void TbAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras, números y los caracteres básicos de dirección
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ' && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }

}
