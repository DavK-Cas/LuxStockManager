namespace SistemaJoyería.View.SalesDetailsView
{
    partial class FrmSalesDetailView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSalesDetailView));
            this.txtDate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearchSale = new System.Windows.Forms.Button();
            this.txtSearchSale = new System.Windows.Forms.TextBox();
            this.btnImprent = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dtpDateSell = new System.Windows.Forms.DateTimePicker();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInsertSell = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProductsSell = new System.Windows.Forms.Label();
            this.mskPrice = new System.Windows.Forms.MaskedTextBox();
            this.dgvSellInfo = new System.Windows.Forms.DataGridView();
            this.MenuVentas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsDeleteSale = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelPrint = new System.Windows.Forms.Panel();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSellInfo)).BeginInit();
            this.MenuVentas.SuspendLayout();
            this.PanelPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDate
            // 
            this.txtDate.AutoSize = true;
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(268, 121);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(78, 25);
            this.txtDate.TabIndex = 1;
            this.txtDate.Text = "Fecha ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSearchSale);
            this.groupBox1.Controls.Add(this.txtSearchSale);
            this.groupBox1.Controls.Add(this.btnImprent);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.dtpDateSell);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnInsertSell);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtQuantity);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.cmbClient);
            this.groupBox1.Controls.Add(this.cmbEmployee);
            this.groupBox1.Controls.Add(this.cmbProduct);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtProductsSell);
            this.groupBox1.Controls.Add(this.mskPrice);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(27, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1217, 335);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Area de Ventas";
            // 
            // btnSearchSale
            // 
            this.btnSearchSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnSearchSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSearchSale.ForeColor = System.Drawing.Color.White;
            this.btnSearchSale.Location = new System.Drawing.Point(1027, 27);
            this.btnSearchSale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearchSale.Name = "btnSearchSale";
            this.btnSearchSale.Size = new System.Drawing.Size(173, 46);
            this.btnSearchSale.TabIndex = 14;
            this.btnSearchSale.Text = "Buscar";
            this.btnSearchSale.UseVisualStyleBackColor = false;
            // 
            // txtSearchSale
            // 
            this.txtSearchSale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSearchSale.Location = new System.Drawing.Point(643, 36);
            this.txtSearchSale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchSale.Name = "txtSearchSale";
            this.txtSearchSale.Size = new System.Drawing.Size(357, 30);
            this.txtSearchSale.TabIndex = 13;
            // 
            // btnImprent
            // 
            this.btnImprent.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnImprent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnImprent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnImprent.ForeColor = System.Drawing.Color.White;
            this.btnImprent.Location = new System.Drawing.Point(999, 271);
            this.btnImprent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImprent.Name = "btnImprent";
            this.btnImprent.Size = new System.Drawing.Size(201, 50);
            this.btnImprent.TabIndex = 10;
            this.btnImprent.Text = "Imprimir Factura";
            this.btnImprent.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(904, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 32);
            this.label2.TabIndex = 9;
            this.label2.Text = "$";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(828, 271);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(137, 52);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refrescar";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // dtpDateSell
            // 
            this.dtpDateSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpDateSell.Location = new System.Drawing.Point(275, 148);
            this.dtpDateSell.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDateSell.Name = "dtpDateSell";
            this.dtpDateSell.Size = new System.Drawing.Size(201, 30);
            this.dtpDateSell.TabIndex = 3;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClear.ForeColor = System.Drawing.Color.Snow;
            this.btnClear.Location = new System.Drawing.Point(8, 272);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(143, 50);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Limpiar";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnInsertSell
            // 
            this.btnInsertSell.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnInsertSell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnInsertSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnInsertSell.ForeColor = System.Drawing.Color.White;
            this.btnInsertSell.Location = new System.Drawing.Point(192, 272);
            this.btnInsertSell.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInsertSell.Name = "btnInsertSell";
            this.btnInsertSell.Size = new System.Drawing.Size(140, 50);
            this.btnInsertSell.TabIndex = 6;
            this.btnInsertSell.Text = "Registrar";
            this.btnInsertSell.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label6.Location = new System.Drawing.Point(904, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(238, 29);
            this.label6.TabIndex = 6;
            this.label6.Text = "Precio del producto:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtQuantity.Location = new System.Drawing.Point(275, 74);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(201, 30);
            this.txtQuantity.TabIndex = 2;
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(269, 43);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(106, 25);
            this.txtTotal.TabIndex = 4;
            this.txtTotal.Text = "Cantidad:";
            // 
            // cmbClient
            // 
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(9, 222);
            this.cmbClient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(221, 33);
            this.cmbClient.TabIndex = 1;
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(9, 145);
            this.cmbEmployee.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(221, 33);
            this.cmbEmployee.TabIndex = 1;
            // 
            // cmbProduct
            // 
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(9, 74);
            this.cmbProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(221, 33);
            this.cmbProduct.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "A nombre de:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Venta realizada por:";
            // 
            // txtProductsSell
            // 
            this.txtProductsSell.AutoSize = true;
            this.txtProductsSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductsSell.Location = new System.Drawing.Point(4, 43);
            this.txtProductsSell.Name = "txtProductsSell";
            this.txtProductsSell.Size = new System.Drawing.Size(216, 25);
            this.txtProductsSell.TabIndex = 0;
            this.txtProductsSell.Text = "Seleccione producto:";
            // 
            // mskPrice
            // 
            this.mskPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mskPrice.Location = new System.Drawing.Point(943, 161);
            this.mskPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mskPrice.Mask = "00.00";
            this.mskPrice.Name = "mskPrice";
            this.mskPrice.Size = new System.Drawing.Size(111, 30);
            this.mskPrice.TabIndex = 11;
            // 
            // dgvSellInfo
            // 
            this.dgvSellInfo.AllowUserToDeleteRows = false;
            this.dgvSellInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSellInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSellInfo.ContextMenuStrip = this.MenuVentas;
            this.dgvSellInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSellInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvSellInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSellInfo.Name = "dgvSellInfo";
            this.dgvSellInfo.ReadOnly = true;
            this.dgvSellInfo.RowHeadersWidth = 51;
            this.dgvSellInfo.RowTemplate.Height = 24;
            this.dgvSellInfo.Size = new System.Drawing.Size(1066, 347);
            this.dgvSellInfo.TabIndex = 8;
            // 
            // MenuVentas
            // 
            this.MenuVentas.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuVentas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsDeleteSale});
            this.MenuVentas.Name = "MenuProductos";
            this.MenuVentas.Size = new System.Drawing.Size(187, 28);
            // 
            // cmsDeleteSale
            // 
            this.cmsDeleteSale.Name = "cmsDeleteSale";
            this.cmsDeleteSale.Size = new System.Drawing.Size(186, 24);
            this.cmsDeleteSale.Text = "Eliminar Usuario";
            // 
            // PanelPrint
            // 
            this.PanelPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PanelPrint.Controls.Add(this.dgvSellInfo);
            this.PanelPrint.Location = new System.Drawing.Point(117, 379);
            this.PanelPrint.Margin = new System.Windows.Forms.Padding(4);
            this.PanelPrint.Name = "PanelPrint";
            this.PanelPrint.Size = new System.Drawing.Size(1066, 347);
            this.PanelPrint.TabIndex = 11;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // FrmSalesDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 766);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PanelPrint);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmSalesDetailView";
            this.Text = "FrmSalesDetailView";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSellInfo)).EndInit();
            this.MenuVentas.ResumeLayout(false);
            this.PanelPrint.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label txtDate;
        public System.Windows.Forms.ComboBox cmbProduct;
        public System.Windows.Forms.Label txtProductsSell;
        public System.Windows.Forms.Label txtTotal;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtQuantity;
        public System.Windows.Forms.DateTimePicker dtpDateSell;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnInsertSell;
        public System.Windows.Forms.Button btnImprent;
        public System.Windows.Forms.DataGridView dgvSellInfo;
        public System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cmbClient;
        public System.Windows.Forms.ComboBox cmbEmployee;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.MaskedTextBox mskPrice;
        private System.Drawing.Printing.PrintDocument printDocument;
        public System.Windows.Forms.Panel PanelPrint;
        public System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        public System.Windows.Forms.ContextMenuStrip MenuVentas;
        public System.Windows.Forms.ToolStripMenuItem cmsDeleteSale;
        public System.Windows.Forms.Button btnSearchSale;
        public System.Windows.Forms.TextBox txtSearchSale;
    }
}