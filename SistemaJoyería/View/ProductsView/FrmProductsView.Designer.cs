namespace SistemaJoyería.View.ProductsView
{
    partial class FrmProductsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductsView));
            this.txtIDProducts = new System.Windows.Forms.TextBox();
            this.lbDescriptionProduct = new System.Windows.Forms.Label();
            this.lbNameSupplier = new System.Windows.Forms.Label();
            this.lbMaterialProduct = new System.Windows.Forms.Label();
            this.lbProducts = new System.Windows.Forms.Label();
            this.MenuProductos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsDeleteProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsUpdateProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearchProduct = new System.Windows.Forms.Button();
            this.lb = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearchProductos = new System.Windows.Forms.TextBox();
            this.btnRestart = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtID = new System.Windows.Forms.Label();
            this.btnKeep = new System.Windows.Forms.Button();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lbCantidad = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lbPriceProduct = new System.Windows.Forms.Label();
            this.txtProductDescription = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.mktPriceProduct = new System.Windows.Forms.MaskedTextBox();
            this.cmbSuppliers = new System.Windows.Forms.ComboBox();
            this.txtProductMaterial = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.MenuProductos.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIDProducts
            // 
            this.txtIDProducts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIDProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtIDProducts.Location = new System.Drawing.Point(61, 556);
            this.txtIDProducts.Margin = new System.Windows.Forms.Padding(4);
            this.txtIDProducts.Name = "txtIDProducts";
            this.txtIDProducts.ReadOnly = true;
            this.txtIDProducts.Size = new System.Drawing.Size(244, 30);
            this.txtIDProducts.TabIndex = 0;
            // 
            // lbDescriptionProduct
            // 
            this.lbDescriptionProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescriptionProduct.AutoSize = true;
            this.lbDescriptionProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescriptionProduct.ForeColor = System.Drawing.Color.Black;
            this.lbDescriptionProduct.Location = new System.Drawing.Point(25, 428);
            this.lbDescriptionProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDescriptionProduct.Name = "lbDescriptionProduct";
            this.lbDescriptionProduct.Size = new System.Drawing.Size(125, 25);
            this.lbDescriptionProduct.TabIndex = 5;
            this.lbDescriptionProduct.Text = "Descripción";
            // 
            // lbNameSupplier
            // 
            this.lbNameSupplier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbNameSupplier.AutoSize = true;
            this.lbNameSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameSupplier.ForeColor = System.Drawing.Color.Black;
            this.lbNameSupplier.Location = new System.Drawing.Point(25, 145);
            this.lbNameSupplier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNameSupplier.Name = "lbNameSupplier";
            this.lbNameSupplier.Size = new System.Drawing.Size(225, 25);
            this.lbNameSupplier.TabIndex = 3;
            this.lbNameSupplier.Text = "Nombre del proveedor";
            // 
            // lbMaterialProduct
            // 
            this.lbMaterialProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbMaterialProduct.AutoSize = true;
            this.lbMaterialProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaterialProduct.ForeColor = System.Drawing.Color.Black;
            this.lbMaterialProduct.Location = new System.Drawing.Point(25, 72);
            this.lbMaterialProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMaterialProduct.Name = "lbMaterialProduct";
            this.lbMaterialProduct.Size = new System.Drawing.Size(89, 25);
            this.lbMaterialProduct.TabIndex = 2;
            this.lbMaterialProduct.Text = "Material";
            // 
            // lbProducts
            // 
            this.lbProducts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbProducts.AutoSize = true;
            this.lbProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProducts.ForeColor = System.Drawing.Color.Black;
            this.lbProducts.Location = new System.Drawing.Point(25, 5);
            this.lbProducts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbProducts.Name = "lbProducts";
            this.lbProducts.Size = new System.Drawing.Size(87, 25);
            this.lbProducts.TabIndex = 0;
            this.lbProducts.Text = "Nombre";
            // 
            // MenuProductos
            // 
            this.MenuProductos.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuProductos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsDeleteProduct,
            this.cmsUpdateProduct});
            this.MenuProductos.Name = "MenuProductos";
            this.MenuProductos.Size = new System.Drawing.Size(210, 52);
            // 
            // cmsDeleteProduct
            // 
            this.cmsDeleteProduct.Name = "cmsDeleteProduct";
            this.cmsDeleteProduct.Size = new System.Drawing.Size(209, 24);
            this.cmsDeleteProduct.Text = "Eliminar producto";
            // 
            // cmsUpdateProduct
            // 
            this.cmsUpdateProduct.Name = "cmsUpdateProduct";
            this.cmsUpdateProduct.Size = new System.Drawing.Size(209, 24);
            this.cmsUpdateProduct.Text = "Actualizar producto";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnSearchProduct);
            this.panel1.Controls.Add(this.lb);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.txtSearchProductos);
            this.panel1.Controls.Add(this.btnRestart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1288, 102);
            this.panel1.TabIndex = 12;
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnSearchProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSearchProduct.ForeColor = System.Drawing.Color.White;
            this.btnSearchProduct.Location = new System.Drawing.Point(764, 34);
            this.btnSearchProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(141, 47);
            this.btnSearchProduct.TabIndex = 15;
            this.btnSearchProduct.Text = "Buscar";
            this.btnSearchProduct.UseVisualStyleBackColor = false;
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb.ForeColor = System.Drawing.Color.Black;
            this.lb.Location = new System.Drawing.Point(25, 42);
            this.lb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(243, 25);
            this.lb.TabIndex = 14;
            this.lb.Text = "CONTROL PRODUCTOS";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1144, 34);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(141, 47);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Refrescar";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // txtSearchProductos
            // 
            this.txtSearchProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSearchProductos.Location = new System.Drawing.Point(327, 42);
            this.txtSearchProductos.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchProductos.Name = "txtSearchProductos";
            this.txtSearchProductos.Size = new System.Drawing.Size(393, 30);
            this.txtSearchProductos.TabIndex = 10;
            // 
            // btnRestart
            // 
            this.btnRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnRestart.ForeColor = System.Drawing.Color.White;
            this.btnRestart.Location = new System.Drawing.Point(992, 34);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(4);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(141, 47);
            this.btnRestart.TabIndex = 12;
            this.btnRestart.Text = "Reiniciar";
            this.btnRestart.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.txtID);
            this.panel2.Controls.Add(this.btnKeep);
            this.panel2.Controls.Add(this.txtStock);
            this.panel2.Controls.Add(this.lbCantidad);
            this.panel2.Controls.Add(this.lbDate);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.lbPriceProduct);
            this.panel2.Controls.Add(this.lbProducts);
            this.panel2.Controls.Add(this.lbMaterialProduct);
            this.panel2.Controls.Add(this.txtProductDescription);
            this.panel2.Controls.Add(this.dtpDate);
            this.panel2.Controls.Add(this.mktPriceProduct);
            this.panel2.Controls.Add(this.cmbSuppliers);
            this.panel2.Controls.Add(this.txtProductMaterial);
            this.panel2.Controls.Add(this.txtProductName);
            this.panel2.Controls.Add(this.lbNameSupplier);
            this.panel2.Controls.Add(this.lbDescriptionProduct);
            this.panel2.Controls.Add(this.txtIDProducts);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 102);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 664);
            this.panel2.TabIndex = 13;
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtID.AutoSize = true;
            this.txtID.BackColor = System.Drawing.Color.Transparent;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(16, 560);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(33, 25);
            this.txtID.TabIndex = 67;
            this.txtID.Text = "ID";
            // 
            // btnKeep
            // 
            this.btnKeep.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnKeep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnKeep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnKeep.ForeColor = System.Drawing.Color.Transparent;
            this.btnKeep.Location = new System.Drawing.Point(16, 610);
            this.btnKeep.Margin = new System.Windows.Forms.Padding(4);
            this.btnKeep.Name = "btnKeep";
            this.btnKeep.Size = new System.Drawing.Size(139, 38);
            this.btnKeep.TabIndex = 66;
            this.btnKeep.Text = "Guardar";
            this.btnKeep.UseVisualStyleBackColor = false;
            // 
            // txtStock
            // 
            this.txtStock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtStock.Location = new System.Drawing.Point(21, 386);
            this.txtStock.Margin = new System.Windows.Forms.Padding(4);
            this.txtStock.MaxLength = 4;
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(284, 30);
            this.txtStock.TabIndex = 6;
            // 
            // lbCantidad
            // 
            this.lbCantidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCantidad.AutoSize = true;
            this.lbCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantidad.ForeColor = System.Drawing.Color.Black;
            this.lbCantidad.Location = new System.Drawing.Point(25, 358);
            this.lbCantidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCantidad.Name = "lbCantidad";
            this.lbCantidad.Size = new System.Drawing.Size(99, 25);
            this.lbCantidad.TabIndex = 24;
            this.lbCantidad.Text = "Cantidad";
            // 
            // lbDate
            // 
            this.lbDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.ForeColor = System.Drawing.Color.Black;
            this.lbDate.Location = new System.Drawing.Point(25, 288);
            this.lbDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(181, 25);
            this.lbDate.TabIndex = 18;
            this.lbDate.Text = "Fecha de entrada";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(173, 610);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(133, 38);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Actualizar";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // lbPriceProduct
            // 
            this.lbPriceProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbPriceProduct.AutoSize = true;
            this.lbPriceProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPriceProduct.ForeColor = System.Drawing.Color.Black;
            this.lbPriceProduct.Location = new System.Drawing.Point(25, 218);
            this.lbPriceProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPriceProduct.Name = "lbPriceProduct";
            this.lbPriceProduct.Size = new System.Drawing.Size(73, 25);
            this.lbPriceProduct.TabIndex = 16;
            this.lbPriceProduct.Text = "Precio";
            // 
            // txtProductDescription
            // 
            this.txtProductDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtProductDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtProductDescription.Location = new System.Drawing.Point(21, 456);
            this.txtProductDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductDescription.MaxLength = 100;
            this.txtProductDescription.Multiline = true;
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.Size = new System.Drawing.Size(284, 64);
            this.txtProductDescription.TabIndex = 7;
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpDate.Location = new System.Drawing.Point(21, 316);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(284, 30);
            this.dtpDate.TabIndex = 5;
            this.dtpDate.Value = new System.DateTime(2024, 9, 3, 18, 50, 5, 0);
            // 
            // mktPriceProduct
            // 
            this.mktPriceProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mktPriceProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.mktPriceProduct.Location = new System.Drawing.Point(21, 246);
            this.mktPriceProduct.Margin = new System.Windows.Forms.Padding(4);
            this.mktPriceProduct.Mask = "00.00";
            this.mktPriceProduct.Name = "mktPriceProduct";
            this.mktPriceProduct.Size = new System.Drawing.Size(284, 30);
            this.mktPriceProduct.TabIndex = 4;
            // 
            // cmbSuppliers
            // 
            this.cmbSuppliers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbSuppliers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSuppliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbSuppliers.FormattingEnabled = true;
            this.cmbSuppliers.Location = new System.Drawing.Point(21, 173);
            this.cmbSuppliers.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSuppliers.Name = "cmbSuppliers";
            this.cmbSuppliers.Size = new System.Drawing.Size(284, 33);
            this.cmbSuppliers.TabIndex = 3;
            // 
            // txtProductMaterial
            // 
            this.txtProductMaterial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtProductMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtProductMaterial.Location = new System.Drawing.Point(21, 101);
            this.txtProductMaterial.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductMaterial.MaxLength = 15;
            this.txtProductMaterial.Name = "txtProductMaterial";
            this.txtProductMaterial.Size = new System.Drawing.Size(284, 30);
            this.txtProductMaterial.TabIndex = 2;
            // 
            // txtProductName
            // 
            this.txtProductName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtProductName.Location = new System.Drawing.Point(21, 33);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductName.MaxLength = 15;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(284, 30);
            this.txtProductName.TabIndex = 1;
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProduct.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(228)))), ((int)(((byte)(226)))));
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.ContextMenuStrip = this.MenuProductos;
            this.dgvProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduct.Location = new System.Drawing.Point(327, 102);
            this.dgvProduct.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.RowHeadersVisible = false;
            this.dgvProduct.RowHeadersWidth = 51;
            this.dgvProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduct.Size = new System.Drawing.Size(961, 664);
            this.dgvProduct.TabIndex = 0;
            // 
            // FrmProductsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 766);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmProductsView";
            this.Text = "FrmProductsView";
            this.MenuProductos.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox txtIDProducts;
        private System.Windows.Forms.Label lbDescriptionProduct;
        private System.Windows.Forms.Label lbNameSupplier;
        private System.Windows.Forms.Label lbMaterialProduct;
        private System.Windows.Forms.Label lbProducts;
        public System.Windows.Forms.ToolStripMenuItem cmsDeleteProduct;
        public System.Windows.Forms.ToolStripMenuItem cmsUpdateProduct;
        public System.Windows.Forms.ContextMenuStrip MenuProductos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Label lbPriceProduct;
        private System.Windows.Forms.Label lbDate;
        public System.Windows.Forms.TextBox txtProductName;
        public System.Windows.Forms.TextBox txtProductMaterial;
        public System.Windows.Forms.ComboBox cmbSuppliers;
        public System.Windows.Forms.TextBox txtProductDescription;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.TextBox txtSearchProductos;
        public System.Windows.Forms.Button btnRestart;
        public System.Windows.Forms.MaskedTextBox mktPriceProduct;
        public System.Windows.Forms.DateTimePicker dtpDate;
        public System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lbCantidad;
        public System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lb;
        public System.Windows.Forms.Button btnSearchProduct;
        public System.Windows.Forms.Button btnKeep;
        public System.Windows.Forms.Label txtID;
    }
}