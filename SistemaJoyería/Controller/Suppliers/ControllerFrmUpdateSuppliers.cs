using SistemaJoyería.Model.DAO;
using SistemaJoyeria.Model.DTO;
using SistemaJoyería.View.Suppliers;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SistemaJoyería.Controller.Suppliers
{
    public class ControllerFrmUpdateSuppliers
    {
        private FrmUpdateSuppliers vistaControlada;
        private UpdateSuppliersDAO suppliersDAO = new UpdateSuppliersDAO();
        private SupplierDTO supplier = new SupplierDTO();
        private int supplierID;

        public ControllerFrmUpdateSuppliers(string idBuena, FrmUpdateSuppliers vistaPasada)
        {
            this.vistaControlada = vistaPasada;

            // Deshabilitar el campo de fecha de registro
            vistaPasada.dtpFechaRegistro.Enabled = false;

            // Convertir idBuena (string) a int y manejar la lógica de actualización
            if (int.TryParse(idBuena, out int idProveedor))
            {
                // Cargar datos y vincular botones
                LoadSupplierData(idProveedor);
                vistaPasada.btnActualizar.Click += (sender, e) => UpdateSupplier(idProveedor);
            }
            else
            {
                MessageBox.Show("ID de proveedor no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                vistaPasada.Close();
            }

            // Validaciones de los campos
            vistaPasada.txtNombreEmpresa.TextChanged += (sender, e) => ValidateLettersOnly(vistaPasada.txtNombreEmpresa, 20);
            vistaPasada.txtNombreContacto.TextChanged += (sender, e) => ValidateLettersOnly(vistaPasada.txtNombreContacto, 15);
            vistaPasada.txtTelefono.KeyPress += ValidatePhoneInput;
            vistaPasada.txtTelefono.TextChanged += ValidatePhoneLength;
            vistaPasada.txtEmail.Leave += (sender, e) => ValidateEmail(vistaPasada.txtEmail);
            vistaPasada.txtDireccion.TextChanged += (sender, e) => ValidateLength(vistaPasada.txtDireccion, 150);

            vistaControlada.KeyPreview = true;
            vistaControlada.KeyDown += Form_KeyDown;

            // Eliminar el menú contextual y prevenir copiar/pegar
            DisableContextMenu(vistaPasada.txtNombreEmpresa);
            DisableContextMenu(vistaPasada.txtNombreContacto);
            DisableContextMenu(vistaPasada.txtTelefono);
            DisableContextMenu(vistaPasada.txtEmail);
            DisableContextMenu(vistaPasada.txtDireccion);
        }

        // Validar que solo se ingresen letras y espacios, con longitud máxima
        private void ValidateLettersOnly(TextBox textBox, int maxLength)
        {
            string input = textBox.Text;
            string lettersOnly = Regex.Replace(input, @"[^a-zA-Z\s]", "");

            if (input != lettersOnly)
            {
                MessageBox.Show("Este campo solo permite letras.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Text = lettersOnly;
                textBox.SelectionStart = lettersOnly.Length;
            }

            ValidateLength(textBox, maxLength);
        }

        // Validar que solo se ingresen números y el carácter "-" en el teléfono
        private void ValidatePhoneInput(object sender, KeyPressEventArgs e)
        {
            TextBox txtTelefono = (TextBox)sender;

            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' || txtTelefono.Text.Length >= 12)
            {
                e.Handled = true;
            }
        }

        // Validar la longitud máxima del teléfono
        private void ValidatePhoneLength(object sender, EventArgs e)
        {
            TextBox txtTelefono = (TextBox)sender;
            if (txtTelefono.Text.Length > 12)
            {
                txtTelefono.Text = txtTelefono.Text.Substring(0, 12);
                txtTelefono.SelectionStart = 12;
            }
        }

        // Validar la longitud de cualquier campo de texto
        private void ValidateLength(TextBox textBox, int maxLength)
        {
            if (textBox.Text.Length > maxLength)
            {
                textBox.Text = textBox.Text.Substring(0, maxLength);
                textBox.SelectionStart = textBox.Text.Length;
                MessageBox.Show($"El campo no puede exceder {maxLength} caracteres.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Validar formato de correo electrónico
        private bool ValidateEmail(TextBox emailTextBox)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(emailTextBox.Text, emailPattern))
            {
                MessageBox.Show("El formato del correo electrónico no es válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Eliminar el menú contextual y deshabilitar copiar/pegar
        private void DisableContextMenu(TextBox textBox)
        {
            textBox.ContextMenu = new ContextMenu();  // Eliminar el menú contextual
            textBox.ShortcutsEnabled = false;  // Deshabilitar atajos como Ctrl+C y Ctrl+V
        }

        // Método para cargar los datos del proveedor en el formulario
        private void LoadSupplierData(int idProveedor)
        {
            SupplierDTO supplier = suppliersDAO.GetSupplierByID(idProveedor);

            if (supplier != null)
            {
                vistaControlada.txtNombreEmpresa.Text = supplier.CompanyName;
                vistaControlada.txtNombreContacto.Text = supplier.ContactName;
                vistaControlada.dtpFechaRegistro.Value = supplier.DayAdded;
                vistaControlada.txtTelefono.Text = supplier.Phone;
                vistaControlada.txtEmail.Text = supplier.Email;
                vistaControlada.txtDireccion.Text = supplier.Direction;
            }
            else
            {
                MessageBox.Show("Proveedor no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                vistaControlada.Close();
            }
        }

        // Método para actualizar el proveedor
        private void UpdateSupplier(int idProveedor)
        {
            if (ValidateAllFields())
            {
                SupplierDTO supplier = new SupplierDTO
                {
                    IDSupplier = idProveedor,
                    CompanyName = vistaControlada.txtNombreEmpresa.Text.Trim(),
                    ContactName = vistaControlada.txtNombreContacto.Text.Trim(),
                    DayAdded = vistaControlada.dtpFechaRegistro.Value,
                    Phone = vistaControlada.txtTelefono.Text.Trim(),
                    Email = vistaControlada.txtEmail.Text.Trim(),
                    Direction = vistaControlada.txtDireccion.Text.Trim()
                };

                int result = suppliersDAO.UpdateSupplier(supplier);

                if (result > 0)
                {
                    MessageBox.Show("Proveedor actualizado exitosamente", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cerrar el formulario automáticamente después de actualizar el proveedor
                    vistaControlada.Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Método que valida que todos los campos estén correctamente llenos
        private bool ValidateAllFields()
        {
            if (string.IsNullOrWhiteSpace(vistaControlada.txtNombreEmpresa.Text) ||
                string.IsNullOrWhiteSpace(vistaControlada.txtNombreContacto.Text) ||
                string.IsNullOrWhiteSpace(vistaControlada.txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(vistaControlada.txtEmail.Text) ||
                string.IsNullOrWhiteSpace(vistaControlada.txtDireccion.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ValidateEmail(vistaControlada.txtEmail))
            {
                return false;
            }

            return true;
        }

        // Controlar que no se permita copiar y pegar con el teclado
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true;
                MessageBox.Show("No se permite copiar o pegar en este formulario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
