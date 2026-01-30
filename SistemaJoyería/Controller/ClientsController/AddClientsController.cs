using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaJoyería.View.ClientsView;
using SistemaJoyería.Model.DAO;
using System.Text.RegularExpressions;
using System.Data;
using System.Diagnostics.Eventing.Reader;

namespace SistemaJoyería.Controller.ClientsController
{
    public class AddClientsController
    {
        FrmAddClients ObjAddCView;
        FrmClientsView ObjClientsView;

        public AddClientsController(FrmAddClients viewAdd)
        {
            ObjAddCView = viewAdd;

            //Evento del CRUD (Create)
            viewAdd.btnOK.Click += new EventHandler(SaveRegister);
            //Eventos de Click
            viewAdd.btnDelete.Click += new EventHandler(CleanInformation);
            //Sección de validaciones de View
            viewAdd.dtpClientsBirthday.MaxDate = DateTime.Today.AddYears(-18);
            viewAdd.dtpClientsBirthday.MinDate = DateTime.Now.AddYears(-60);
            viewAdd.tbClientsName.KeyPress += new KeyPressEventHandler(OnlyLettersSpace);
            viewAdd.tbClientsSurname.KeyPress += new KeyPressEventHandler(OnlyLettersSpace);
            viewAdd.tbEmail.KeyPress += new KeyPressEventHandler(TbEmail_KeyPress);
            viewAdd.tbAddress.KeyPress += new KeyPressEventHandler(TbAddress_KeyPress);
            viewAdd.tbClientsName.TextChanged += new EventHandler(Limit25);
            viewAdd.tbClientsSurname.TextChanged += new EventHandler(Limit25);  
            viewAdd.tbEmail.TextChanged += new EventHandler(Limit50);
            viewAdd.tbAddress.TextChanged += new EventHandler(Limit150);
            DisableCopyCutPaste(viewAdd.tbClientsName);
            DisableCopyCutPaste(viewAdd.tbClientsSurname);
            DisableCopyCutPasteMasked(viewAdd.mskCellphoneN);
            DisableCopyCutPasteMasked(viewAdd.mskDuiDoc);
            DisableCopyCutPaste(viewAdd.tbEmail);
            DisableCopyCutPaste(viewAdd.tbAddress);
        }


        void SaveRegister(object sender, EventArgs e)
        {
            string ClientsName = ObjAddCView.tbClientsName.Text.Trim();
            string ClientsSurName = ObjAddCView.tbClientsSurname.Text.Trim();
            string Email = ObjAddCView.tbEmail.Text.Trim();
            DateTime BirthDay = ObjAddCView.dtpClientsBirthday.Value;
            string Address = ObjAddCView.tbAddress.Text.Trim();
            int AddressLength = ObjAddCView.tbAddress.Text.Length;

            // Eliminamos temporalmente los guiones para validar el formato de teléfono y DUI
            string CellPhone = ObjAddCView.mskCellphoneN.Text.Trim().Replace("-", "");
            string DUI = ObjAddCView.mskDuiDoc.Text.Trim().Replace("-", "");

            if (!(// Validamos si los campos de nombres y apellidos no están vacíos
                  string.IsNullOrEmpty(ClientsName) || string.IsNullOrEmpty(ClientsSurName) ||
                  // Validamos si el teléfono tiene exactamente 8 dígitos sin contar guiones  
                  string.IsNullOrEmpty(CellPhone) || CellPhone.Length != 8 || !CellPhone.All(char.IsDigit) ||
                  // Validamos si el DUI tiene exactamente 9 dígitos sin contar guiones
                  string.IsNullOrEmpty(DUI) || DUI.Length != 9 || !DUI.All(char.IsDigit) ||
                  // Validamos si el campo de correo electrónico no está vacío //Validación con método
                  string.IsNullOrEmpty(Email) || !Emailverifaction(Email) ||
                  // Validamos si el campo de dirección no está vacío  // Validamos que la dirección no sobrepase los 100 dígitos
                  string.IsNullOrEmpty(Address) || AddressLength > 100))
            {
                // Se crea un objeto de tipo ClientsDAO
                AddClientsDAO daoClient = new AddClientsDAO();

                // Se mandan valores de la vista hacia el DTO de clientes
                daoClient.FirstName = ClientsName;
                daoClient.LastName = ClientsSurName;
                daoClient.BirthDate = BirthDay;
                daoClient.Phone =  ObjAddCView.mskCellphoneN.Text.Trim();
                daoClient.IdentityDocument = ObjAddCView.mskDuiDoc.Text.Trim();
                daoClient.Email = Email;
                daoClient.AddressClient = Address;

                // Registrar cliente en la base de datos
                int resultado = daoClient.RegisterClients();
                if (resultado == 1)
                {
                    MessageBox.Show("El cliente fue registrado exitosamente", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                    ObjAddCView.Close();

                }
                else
                {
                    MessageBox.Show("El cliente no pudo ser registrado", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            ObjAddCView.tbClientsName.Clear();
            ObjAddCView.tbClientsSurname.Clear();
            ObjAddCView.mskCellphoneN.Clear();
            ObjAddCView.mskDuiDoc.Clear();
            ObjAddCView.tbEmail.Clear();
            ObjAddCView.tbAddress.Clear();
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

