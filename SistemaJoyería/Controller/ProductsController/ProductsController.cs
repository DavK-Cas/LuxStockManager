using SistemaJoyería.Model.DAO;
using SistemaJoyería.View.ProductsView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaJoyería.Controller.ProductsController
{
    internal class ProductsController
    {
        FrmProductsView ObjProducts;

        public ProductsController(FrmProductsView View)
        {
            ObjProducts = View;
            //Crear evento para cuando se inicie el Formulario
            View.Load += new EventHandler(CargaInicial);
            ////Eventos que se ejecutan con click
            ///
            View.cmsDeleteProduct.Click += new EventHandler(DeleteProduct);
            View.cmsUpdateProduct.Click += new EventHandler(UpdateProduct);
            View.btnKeep.Click += new EventHandler(KeepRegistrer);
            View.btnRestart.Click += new EventHandler(RestartRegister);
            View.btnUpdate.Click += new EventHandler(UpdateProduct);
            View.btnRefresh.Click += new EventHandler(ResfreshDGV);
            View.btnSearchProduct.Click += new EventHandler(SearchProductsEvent);
            //Evento para seleccionar fila de producto
            View.dgvProduct.CellClick += new DataGridViewCellEventHandler(SelectProduct);
            //Evento para solo permitir letras
            View.txtProductName.KeyPress += new KeyPressEventHandler(txtLetters_KeyPress);
            View.txtProductMaterial.KeyPress += new KeyPressEventHandler(txtLetters_KeyPress);
            View.txtProductDescription.KeyPress += new KeyPressEventHandler(txtLetters_KeyPress);
            View.txtSearchProductos.KeyPress += new KeyPressEventHandler(SearchProduct);
            //Evento para solo permitir numeros
            View.txtStock.KeyPress += new KeyPressEventHandler(txtNumbers_KeyPress);
            View.mktPriceProduct.KeyPress += new KeyPressEventHandler(txtNumbers_KeyPress);
            //// Establece la fecha por defecto en el DateTimePicker a la fecha de hoy
            View.dtpDate.Value = DateTime.Today;
            //Read Only--------------------Borrar esta linea
            //View.dtpDate.Enabled = false;--------------------Borrar esta linea
            // Configurar el formato del DateTimePicker
            View.dtpDate.Format = DateTimePickerFormat.Custom;
            View.dtpDate.CustomFormat = "dd/MM/yyyy";
            // Deshabilitar copiar, cortar y pegar en TextBox y MaskedTextBox
            View.txtProductName.KeyDown += new KeyEventHandler(DisableCopyPaste_KeyDown);
            View.txtProductMaterial.KeyDown += new KeyEventHandler(DisableCopyPaste_KeyDown);
            View.txtProductDescription.KeyDown += new KeyEventHandler(DisableCopyPaste_KeyDown);
            View.txtStock.KeyDown += new KeyEventHandler(DisableCopyPaste_KeyDown);
            View.mktPriceProduct.KeyDown += new KeyEventHandler(DisableCopyPaste_KeyDown);
            View.txtSearchProductos.KeyDown += new KeyEventHandler(DisableCopyPaste_KeyDown);
            // Deshabilitar el menú contextual de copiar, cortar y pegar
            DisableContextMenu(View.txtProductName);
            DisableContextMenu(View.txtProductMaterial);
            DisableContextMenu(View.txtProductDescription);
            DisableContextMenu(View.txtStock);
            DisableContextMenu(View.mktPriceProduct);
            DisableContextMenu(View.txtSearchProductos);
            // Configurar el DateTimePicker
            View.dtpDate.MinDate = DateTime.Today.AddDays(-14); // Fecha mínima: hace 2 semanas
            View.dtpDate.MaxDate = DateTime.Today;              // Fecha máxima: hoy
            View.dtpDate.Value = DateTime.Today;                // Fecha predeterminada: hoy
            // Vincular el evento de cambio de valor
            View.dtpDate.ValueChanged += new EventHandler(dtpDate_ValueChanged);
        }
        // Método para deshabilitar copiar, cortar y pegar con el teclado
        private void DisableCopyPaste_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica si se presionan Ctrl+C, Ctrl+V, Ctrl+X o Shift+Insert
            if ((e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X)) || (e.Shift && e.KeyCode == Keys.Insert))
            {
                e.SuppressKeyPress = true; // Bloquea la acción
            }
        }

        // Método para deshabilitar el menú contextual de copiar, cortar y pegar
        private void DisableContextMenu(Control control)
        {
            control.ContextMenuStrip = new ContextMenuStrip(); // Asigna un menú vacío
        }
        void CargaInicial(object sender, EventArgs e)
        {
            ShowDGVProducts();
            FillComboSuppliers();
        }


        //Refrescar tabla
        void ResfreshDGV(object sender, EventArgs e)
        {
            ShowDGVProducts();           
        }

        void ShowDGVProducts()
        {
            ProductsViewDAO daoPD = new ProductsViewDAO();
            DataSet ds = daoPD.ShowDGV();
            ObjProducts.dgvProduct.DataSource = ds.Tables["vw_Products"];
            ObjProducts.btnKeep.Enabled = true;
        }

        void FillComboSuppliers()
        {
            //Creando un objeto de la clase ProductsViewDAO
            ProductsViewDAO daoSupplier = new ProductsViewDAO();
            DataSet ds = daoSupplier.GetSuppliers();
            ObjProducts.cmbSuppliers.DataSource = ds.Tables["Suppliers"];
            ObjProducts.cmbSuppliers.DisplayMember = "ContactName";
            ObjProducts.cmbSuppliers.ValueMember = "IDSupplier";
        }


        //solo permite letras
        private void txtLetters_KeyPress(object sender, KeyPressEventArgs e)
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

        //solo permite numeros
        private void txtNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        //Validacion de fecha
        // Método que se ejecuta cuando cambia la fecha seleccionada
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = ObjProducts.dtpDate.Value;
            ValidateDate(selectedDate);
        }

        // Método para validar que la fecha esté dentro del rango permitido
        private void ValidateDate(DateTime selectedDate)
        {
            DateTime today = DateTime.Today;
            DateTime twoWeeksAgo = today.AddDays(-14);

            if (selectedDate > today)
            {
                MessageBox.Show("No puedes seleccionar una fecha futura.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ObjProducts.dtpDate.Value = today; // Restablece a la fecha actual si se elige una fecha futura
            }
            else if (selectedDate < twoWeeksAgo)
            {
                MessageBox.Show("Solo puedes seleccionar una fecha dentro de las últimas dos semanas.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ObjProducts.dtpDate.Value = twoWeeksAgo; // Restablece a la fecha mínima permitida si se selecciona una fecha fuera del rango
            }
        }

        //Borrar producto
        void DeleteProduct(object sender, EventArgs e)
        {
            //capturando el indice de la fila

            int pos = ObjProducts.dgvProduct.CurrentRow.Index;
            ProductsViewDAO daoDelete = new ProductsViewDAO();
            daoDelete.IDProducto1 = int.Parse(ObjProducts.dgvProduct[0, pos].Value.ToString());
            int retorno = daoDelete.DeleteRecord();
            if (retorno == 1)
            {
                MessageBox.Show("El producto seleccionado fue eliminado", "proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El producto seleccionado no pudo ser eliminado", "proceso incompletado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ShowDGVProducts();
            }
        }

        //Seleccionar producto
        void SelectProduct(object sender, DataGridViewCellEventArgs e)
        {
            int pos = ObjProducts.dgvProduct.CurrentRow.Index;

            ObjProducts.txtIDProducts.Text = ObjProducts.dgvProduct[0, pos].Value.ToString();
            ObjProducts.txtProductName.Text = ObjProducts.dgvProduct[1, pos].Value.ToString();
            ObjProducts.txtProductMaterial.Text = ObjProducts.dgvProduct[2, pos].Value.ToString();
            ObjProducts.cmbSuppliers.Text = ObjProducts.dgvProduct[3, pos].Value.ToString();
            ObjProducts.mktPriceProduct.Text = ObjProducts.dgvProduct[6, pos].Value.ToString();

            // Validar si la fecha es correcta antes de parsearla
            string dateValue = ObjProducts.dgvProduct[4, pos].Value.ToString();
            DateTime parsedDate;

            if (DateTime.TryParse(dateValue, out parsedDate))
            {
                ObjProducts.dtpDate.Value = parsedDate;
            }
            else
            {

            }

            ObjProducts.txtStock.Text = ObjProducts.dgvProduct[5, pos].Value.ToString();
            ObjProducts.txtProductDescription.Text = ObjProducts.dgvProduct[7, pos].Value.ToString();

            // Deshabilitar el btn keep
            ObjProducts.btnKeep.Enabled = false;
        }


        //Actualizar producto
        void UpdateProduct(object sender, EventArgs e)
        {
            ProductsViewDAO daoUpdate = new ProductsViewDAO();
            daoUpdate.IDProducto1 = int.Parse(ObjProducts.txtIDProducts.Text.Trim());
            daoUpdate.NombreProducto1 = ObjProducts.txtProductName.Text.Trim();
            daoUpdate.MaterialProducto1 = ObjProducts.txtProductMaterial.Text.Trim();
            daoUpdate.IDProveedor1 = int.Parse(ObjProducts.cmbSuppliers.SelectedValue.ToString());
            daoUpdate.Stock1 = int.Parse(ObjProducts.txtStock.Text.Trim());
            daoUpdate.Price1 = float.Parse(ObjProducts.mktPriceProduct.Text.Trim());
            daoUpdate.Fecha1 = ObjProducts.dtpDate.Value;
            daoUpdate.DescripcionProducto1 = ObjProducts.txtProductDescription.Text.Trim();
            int retorno = daoUpdate.UpdateProduct();
            if (retorno == 1)
            {
                MessageBox.Show("El producto seleccionado fue actualizado", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowDGVProducts();


                //reiniciar los campos
                RestartRegister(sender, e);
            }
            else
            {
                MessageBox.Show("El producto seleccionado no pudo ser actualizado", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //Habilitar el btn keep
            ObjProducts.btnKeep.Enabled = true;
        }


        //Guardar producto
        void KeepRegistrer(object sender, EventArgs e)
        {
            //Verificar que los campos esten lleno
            if (!string.IsNullOrEmpty(ObjProducts.txtProductName.Text.Trim()) &&
                !string.IsNullOrEmpty(ObjProducts.cmbSuppliers.Text.Trim()) &&
                !string.IsNullOrEmpty(ObjProducts.txtProductMaterial.Text.Trim()) &&
                !string.IsNullOrEmpty(ObjProducts.txtStock.Text.Trim()) &&
                !string.IsNullOrEmpty(ObjProducts.mktPriceProduct.Text.Trim()) &&
                !string.IsNullOrEmpty(ObjProducts.dtpDate.Text.Trim()) &&
                !string.IsNullOrEmpty(ObjProducts.txtProductDescription.Text.Trim()))
            {
                //Crear un objeto de tipo dao
                ProductsViewDAO daoInsert = new ProductsViewDAO();
                daoInsert.NombreProducto1 = ObjProducts.txtProductName.Text.Trim();
                daoInsert.MaterialProducto1 = ObjProducts.txtProductMaterial.Text.Trim();
                daoInsert.IDProveedor1 = int.Parse(ObjProducts.cmbSuppliers.SelectedValue.ToString());
                daoInsert.DescripcionProducto1 = ObjProducts.txtProductDescription.Text.Trim();
                daoInsert.Stock1 = int.Parse(ObjProducts.txtStock.Text.Trim());
                daoInsert.Price1 = float.Parse(ObjProducts.mktPriceProduct.Text.Trim());
                daoInsert.Fecha1 = ObjProducts.dtpDate.Value;
                daoInsert.DescripcionProducto1 = ObjProducts.txtProductDescription.Text.Trim();
                int retorno = daoInsert.registrerproducts();
                if (retorno == 1)
                {
                    MessageBox.Show("El Producto fue registrado exitosamente", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowDGVProducts();

                    //reiniciar los campos
                    RestartRegister(sender, e);
                }
                else if (retorno == 0)
                {
                    MessageBox.Show("El Producto no pudo ser registrado", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                //segmento false
                MessageBox.Show("Complete el formulario con la informacion requerida", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Reiniciar campos
        private void RestartRegister(object sender, EventArgs e)
        {
            // Limpiar los TextBox
            ObjProducts.txtProductName.Text = string.Empty;
            ObjProducts.txtProductMaterial.Text = string.Empty;
            ObjProducts.cmbSuppliers.Text = string.Empty;
            ObjProducts.txtStock.Text = string.Empty;
            ObjProducts.mktPriceProduct.Text = string.Empty;
            ObjProducts.dtpDate.Value = DateTime.Today;
            ObjProducts.txtProductDescription.Text = string.Empty;
            ObjProducts.txtIDProducts.Text = string.Empty;
            // Deshabilitar el btn keep
            ObjProducts.btnKeep.Enabled = false;
        }

        //Mando a llamar el DAO
        public void SearchProduct(object sender, KeyPressEventArgs e)
        {
            SearchProductsController();
        }
        //Buscar productos
        public void SearchProductsEvent(object sender, EventArgs e) { SearchProductsController(); }
        void SearchProductsController()
        {
            ProductsViewDAO DAOProducts = new ProductsViewDAO();
            DataSet ds = DAOProducts.BuscarProducts(ObjProducts.txtSearchProductos.Text.Trim());
            ObjProducts.dgvProduct.DataSource = ds.Tables["vw_Products"];
        }


    }
}
