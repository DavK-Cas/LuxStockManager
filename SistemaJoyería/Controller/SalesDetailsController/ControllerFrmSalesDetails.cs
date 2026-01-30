using SistemaJoyería.Model.DAO;
using SistemaJoyería.View.SalesDetailsView;
using System.Data;
using System.Windows.Forms;
using System;
using System.Drawing.Printing;
using System.Drawing;


namespace SistemaJoyería.Controller.SalesDetailsController
{
    internal class SalesDetailsController
    {
        FrmSalesDetailView ObjSalesDetails;
        private PrintDocument printDocument = new PrintDocument();
        public SalesDetailsController(FrmSalesDetailView View)
        {
            ObjSalesDetails = View;;
            // Crear evento para cuando se inicie el Formulario
            View.Load += new EventHandler(CargaInicial);
            // Eventos que se ejecutan con click
            View.btnInsertSell.Click += new EventHandler(AddSalesDetail);
            View.btnRefresh.Click += new EventHandler(RefreshDGV);
            View.txtQuantity.KeyPress += new KeyPressEventHandler(OnlyNumber);
            View.btnClear.Click += new EventHandler(ClearZone);
            View.btnImprent.Click += new EventHandler(PrintDocumentt);
            View.cmsDeleteSale.Click += new EventHandler(DeleteSale);
            //Otro tipo de método
            View.txtQuantity.TextChanged += new EventHandler(Limit3);
            View.cmbProduct.SelectedIndexChanged += new EventHandler(UpdateProductPrice);
            View.btnSearchSale.Click += new EventHandler(SearcSaleEvent);
            // Establece la fecha mínima y máxima en el DateTimePicker para que solo permita la fecha de hoy
            View.dtpDateSell.MinDate = DateTime.Today;
            View.dtpDateSell.MaxDate = DateTime.Today;
            // Establece la fecha por defecto en el DateTimePicker a la fecha de hoy
            View.dtpDateSell.Value = DateTime.Today;
            //Se hace ReadOnly el DTP
            View.dtpDateSell.Enabled = false;
            DisableCopyCutPaste(View.txtQuantity);
            DisableCopyCutPasteMasked(View.mskPrice);
            // Asignamos el evento PrintPage al documento de impresión
            printDocument.PrintPage += new PrintPageEventHandler(PrintPanel);
        }

        void CargaInicial(object sender, EventArgs e)
        {
            ShowDGVSalesDetails();
            FillProducts();
            FillEmployees();
            FillClient();
        }

        // Manejador para la impresión
        private void PrintPanel(object sender, PrintPageEventArgs e)
        {
            // Verifica que PanelPrint no sea nulo
            if (ObjSalesDetails.PanelPrint != null)
            {
                // Crear un Bitmap del tamaño del Panel
                Bitmap bm = new Bitmap(ObjSalesDetails.PanelPrint.Width, ObjSalesDetails.PanelPrint.Height);

                // Dibuja el contenido del Panel en el Bitmap
                ObjSalesDetails.PanelPrint.DrawToBitmap(bm, new Rectangle(0, 0, ObjSalesDetails.PanelPrint.Width, ObjSalesDetails.PanelPrint.Height));

                // Dibuja el Bitmap en la página de impresión
                e.Graphics.DrawImage(bm, 0, 0);
            }
        }

        // Manejador del botón para mostrar el cuadro de vista previa de impresión
        private void PrintDocumentt(object sender, EventArgs e)
        {
            // Configura el PrintPreviewDialog y asigna el documento de impresión
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = printDocument; // Asignamos el documento de impresión
            printPreviewDialog1.ShowDialog(); // Mostrar la vista previa de impresión
        }

        //LLenarTB
        void FillProducts()
        {
            //Creando un objeto de la clase DAOBooks
            SalesDetailsViewDAO daoProducts = new SalesDetailsViewDAO();
            DataSet ds = daoProducts.GetProducts();
            ObjSalesDetails.cmbProduct.DataSource = ds.Tables["Products"];
            ObjSalesDetails.cmbProduct.DisplayMember = "ProductName";
            ObjSalesDetails.cmbProduct.ValueMember = "IDProduct";
        }

        void FillEmployees()
        {
            //Creando un objeto de la clase DAOBooks
            SalesDetailsViewDAO daoEmployees = new SalesDetailsViewDAO();
            DataSet dsE = daoEmployees.GetEmployees();
            ObjSalesDetails.cmbEmployee.DataSource = dsE.Tables["Employees"];
            ObjSalesDetails.cmbEmployee.DisplayMember = "FirstNameEmployees";
            ObjSalesDetails.cmbEmployee.ValueMember = "IDEmployees";
        }

        void FillClient()
        {
            //Creando un objeto de la clase DAOBooks
            SalesDetailsViewDAO daoClient = new SalesDetailsViewDAO();
            DataSet dsC = daoClient.GetClients();
            ObjSalesDetails.cmbClient.DataSource = dsC.Tables["Clients"];
            ObjSalesDetails.cmbClient.DisplayMember = "FirstName";
            ObjSalesDetails.cmbClient.ValueMember = "IDClient";
        }

        void DeleteSale(object sender, EventArgs e)
        {
            //capturando el indice de la fila

            int pos = ObjSalesDetails.dgvSellInfo.CurrentRow.Index;
            SalesDetailsViewDAO daoDelete = new SalesDetailsViewDAO();
            daoDelete.IDSaleDetail1 = int.Parse(ObjSalesDetails.dgvSellInfo[0, pos].Value.ToString());
            int retorno = daoDelete.DeleteSale();
            if (retorno == 1)
            {
                MessageBox.Show("La venta seleccionada fue eliminada", "proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowDGVSalesDetails();
            }
            else
            {
                MessageBox.Show("La venta seleccionada no pudo ser eliminada", "proceso incompletado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void SearchSale(object sender, KeyPressEventArgs e)
        {
            SearchSaleController();
        }
        //Buscar productos
        public void SearcSaleEvent(object sender, EventArgs e) { SearchSaleController(); }
        void SearchSaleController()
        {
            SalesDetailsViewDAO SalesViewDAO = new SalesDetailsViewDAO();
            DataSet ds = SalesViewDAO.SearchSalesDetails(ObjSalesDetails.txtProductsSell.Text.Trim());
            ObjSalesDetails.dgvSellInfo.DataSource = ds.Tables["vw_Details"];
        }

        // Refrescar tabla
        void RefreshDGV(object sender, EventArgs e)
        {
            ShowDGVSalesDetails();
        }

        // Mostrar detalles de ventas en el DataGridView
        void ShowDGVSalesDetails()
        {
            SalesDetailsViewDAO daoSD = new SalesDetailsViewDAO();
            DataSet ds = daoSD.ShowDGV();
            ObjSalesDetails.dgvSellInfo.DataSource = ds.Tables["vw_Details"];
        }
        //// Añadir detalles de venta
        void AddSalesDetail(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ObjSalesDetails.txtQuantity.Text.Trim()) &&
                !string.IsNullOrEmpty(ObjSalesDetails.cmbProduct.Text.Trim()) &&
                !string.IsNullOrEmpty(ObjSalesDetails.cmbEmployee.Text.Trim()) &&
                !string.IsNullOrEmpty(ObjSalesDetails.cmbClient.Text.Trim()) &&
                !string.IsNullOrEmpty(ObjSalesDetails.mskPrice.Text.Trim()))
            {
                SalesDetailsViewDAO daoInsert = new SalesDetailsViewDAO();
                daoInsert.IDProduct1 = int.Parse(ObjSalesDetails.cmbProduct.SelectedValue.ToString());
                daoInsert.IDEmployee1 = int.Parse(ObjSalesDetails.cmbEmployee.SelectedValue.ToString());
                daoInsert.IDClient1 = int.Parse(ObjSalesDetails.cmbClient.SelectedValue.ToString());
                daoInsert.DayToSale1 = ObjSalesDetails.dtpDateSell.Value;
                daoInsert.Quantity1 = int.Parse(ObjSalesDetails.txtQuantity.Text.Trim());
                daoInsert.Price1 = decimal.Parse(ObjSalesDetails.mskPrice.Text.Trim());

                int retorno = daoInsert.RegisterSaleDetails();
                if (retorno == 1)
                {
                    MessageBox.Show("Los detalles de la venta fueron registrados exitosamente", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowDGVSalesDetails();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar los detalles de la venta", "Proceso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Complete el formulario con la información requerida", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void UpdateProductPrice(object sender, EventArgs e)
        {
            if (ObjSalesDetails.cmbProduct.SelectedValue != null)
            {
                try
                {

                    int selectedProductId = Convert.ToInt32(ObjSalesDetails.cmbProduct.SelectedValue);

                    SalesDetailsViewDAO dao = new SalesDetailsViewDAO();
                    decimal price = dao.GetProductPrice(selectedProductId);

                    if (price > 0)
                    {
                        ObjSalesDetails.mskPrice.Text = price.ToString("N2");
                    }
                    else
                    {
                        ObjSalesDetails.mskPrice.Clear();
                    }
                }
                catch (Exception ex)
                {
                    //
                }
            }
        }
        void ClearZone(object sender, EventArgs e)
        {
            ObjSalesDetails.cmbProduct.SelectedIndex = -1;
            ObjSalesDetails.txtQuantity.Clear();
            ObjSalesDetails.mskPrice.Clear();

        }
       

        //Validaciones
        //Método para validar que sólo sean números
        private void OnlyNumber(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void Limit3(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            CharacterLimit3(textBox);
        }

        //Limitar a 150 Carácateres
        private void CharacterLimit3(TextBox textBox)
        {
            textBox.MaxLength = 3;
        }

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
    }
}