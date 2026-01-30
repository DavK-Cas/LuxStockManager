using SistemaJoyería.Model.DAO;
using SistemaJoyería.Model.DTO;
using SistemaJoyeria.Model.DTO;
using SistemaJoyería.View.Suppliers;
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SistemaJoyería.Controller.Suppliers
{
    internal class ControllerFrmAddSuppliers
    {
        private AddSuppliersDAO suppliersDAO = new AddSuppliersDAO();
        private SupplierDTO supplier = new SupplierDTO();
        private FrmAddSuppliers vistaControlada;

        // Variable estática para verificar si la ventana ya está abierta
        private static FrmAddSuppliers frmAddSuppliersInstance = null;

        public ControllerFrmAddSuppliers(FrmAddSuppliers vistaPasada)
        {
            vistaControlada = vistaPasada;

            vistaControlada.Load += (sender, e) => vistaControlada.txtNombreEmpresa.Focus();

            vistaPasada.btnGuardar.Click += (sender, e) => RegisterSupplier(supplier);
            vistaPasada.btnLimpiar.Click += (sender, e) => ClearFields();

            vistaPasada.txtNombreEmpresa.TextChanged += (sender, e) => ValidateLettersOnly(vistaPasada.txtNombreEmpresa, 20);
            vistaPasada.txtNombreContacto.TextChanged += (sender, e) => ValidateLettersOnly(vistaPasada.txtNombreContacto, 15);
            vistaPasada.dtpFechaRegistro.ValueChanged += (sender, e) => ValidateDate(vistaPasada.dtpFechaRegistro.Value);
            vistaPasada.txtTelefono.KeyPress += ValidatePhoneInput;
            vistaPasada.txtTelefono.TextChanged += ValidatePhoneLength;
            vistaPasada.txtDireccion.TextChanged += (sender, e) => ValidateLength(vistaPasada.txtDireccion, 150);

            vistaControlada.KeyPreview = true;
            vistaControlada.KeyDown += Form_KeyDown;

            // Deshabilitar el menú contextual (clic derecho) para todos los campos de texto
            DisableContextMenu(vistaPasada);
        }

        // Método para abrir el formulario FrmAddSuppliers de manera modal con ShowDialog()
        public void ShowFrmAddSuppliers()
        {
            // Verificar si el formulario ya está abierto
            if (frmAddSuppliersInstance == null || frmAddSuppliersInstance.IsDisposed)
            {
                frmAddSuppliersInstance = new FrmAddSuppliers();
                frmAddSuppliersInstance.ShowDialog();  // Abrir como modal
            }
            else
            {
                // Si ya está abierto, mostrar un mensaje al usuario
                MessageBox.Show("El formulario de agregar proveedores ya está abierto.", "Formulario en uso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Método para registrar un proveedor
        public void RegisterSupplier(SupplierDTO supplier)
        {
            if (ValidateAllFields())
            {
                CreateSupplierDTO();
                try
                {
                    int result = suppliersDAO.RegisterSupplier(supplier);
                    if (result > 0)
                    {
                        MessageBox.Show("Proveedor registrado exitosamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Cerrar el formulario automáticamente después de guardar el proveedor
                        vistaControlada.Close();
                    }
                }
                catch (SqlException ex)
                {
                    HandleSqlException(ex);
                }
            }
        }

        private void HandleSqlException(SqlException ex)
        {
            if (ex.Number == 2627 || ex.Number == 2601) // Violación de clave única
            {
                if (ex.Message.Contains("CompanyName"))
                {
                    MessageBox.Show("El nombre de la empresa ya existe.", "Error de duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Message.Contains("ContactName"))
                {
                    MessageBox.Show("El nombre del contacto ya existe.", "Error de duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Message.Contains("Phone"))
                {
                    MessageBox.Show("El número de teléfono ya existe.", "Error de duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Message.Contains("Email"))
                {
                    MessageBox.Show("El correo electrónico ya existe.", "Error de duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error al registrar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error al registrar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public SupplierDTO CreateSupplierDTO()
        {
            supplier.CompanyName = vistaControlada.txtNombreEmpresa.Text.Trim();
            supplier.ContactName = vistaControlada.txtNombreContacto.Text.Trim();
            supplier.DayAdded = vistaControlada.dtpFechaRegistro.Value;
            supplier.Phone = vistaControlada.txtTelefono.Text.Trim();
            supplier.Email = vistaControlada.txtEmail.Text.Trim();
            supplier.Direction = vistaControlada.txtDireccion.Text.Trim();
            return supplier;
        }

        private void ClearFields()
        {
            vistaControlada.txtNombreEmpresa.Clear();
            vistaControlada.txtNombreContacto.Clear();
            vistaControlada.txtTelefono.Clear();
            vistaControlada.txtEmail.Clear();
            vistaControlada.txtDireccion.Clear();
            vistaControlada.dtpFechaRegistro.Value = DateTime.Now;
        }

        // Validación de todos los campos al presionar el botón de Guardar
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

            if (!ValidateEmail(vistaControlada.txtEmail.Text))
            {
                MessageBox.Show("El formato del correo electrónico no es válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ValidateDate(vistaControlada.dtpFechaRegistro.Value))
            {
                return false;
            }

            return true;
        }

        // Validación de fecha
        private bool ValidateDate(DateTime selectedDate)
        {
            DateTime currentDate = DateTime.Now;
            DateTime maxDate = currentDate.AddYears(1);

            if (selectedDate < currentDate.Date || selectedDate > maxDate.Date)
            {
                MessageBox.Show($"La fecha debe ser hoy o dentro de un año a partir de hoy.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ValidateLength(TextBox textBox, int maxLength)
        {
            if (textBox.Text.Length > maxLength)
            {
                textBox.Text = textBox.Text.Substring(0, maxLength);
                textBox.SelectionStart = textBox.Text.Length;
                MessageBox.Show($"El campo no puede exceder {maxLength} caracteres.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

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

        private void ValidatePhoneLength(object sender, EventArgs e)
        {
            TextBox txtTelefono = (TextBox)sender;
            if (txtTelefono.Text.Length > 12)
            {
                txtTelefono.Text = txtTelefono.Text.Substring(0, 12);
                txtTelefono.SelectionStart = 12;
            }
        }

        // Validación de email solo al presionar el botón de Guardar
        private bool ValidateEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Método para bloquear Ctrl+C y Ctrl+V sin mostrar mensajes
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true; // Bloquear la acción sin mostrar mensajes
            }
        }

        // Método para deshabilitar el menú contextual en campos de texto
        private void DisableContextMenu(FrmAddSuppliers vista)
        {
            vista.txtNombreEmpresa.ContextMenu = new ContextMenu();
            vista.txtNombreContacto.ContextMenu = new ContextMenu();
            vista.txtTelefono.ContextMenu = new ContextMenu();
            vista.txtEmail.ContextMenu = new ContextMenu();
            vista.txtDireccion.ContextMenu = new ContextMenu();
        }
    }
}
