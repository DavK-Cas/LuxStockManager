namespace SistemaJoyería.View.Suppliers
{
    partial class FrmAddSuppliers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddSuppliers));
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNombreContacto = new System.Windows.Forms.TextBox();
            this.txtNombreEmpresa = new System.Windows.Forms.TextBox();
            this.Direccion = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.Telefono = new System.Windows.Forms.Label();
            this.NombreContacto = new System.Windows.Forms.Label();
            this.NombreEmpresa = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dtpFechaRegistro = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTelefono
            // 
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.txtTelefono.Location = new System.Drawing.Point(252, 190);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(502, 31);
            this.txtTelefono.TabIndex = 4;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.txtDireccion.Location = new System.Drawing.Point(252, 308);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(502, 31);
            this.txtDireccion.TabIndex = 6;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.txtEmail.Location = new System.Drawing.Point(252, 248);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(502, 31);
            this.txtEmail.TabIndex = 5;
            // 
            // txtNombreContacto
            // 
            this.txtNombreContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreContacto.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.txtNombreContacto.Location = new System.Drawing.Point(252, 75);
            this.txtNombreContacto.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreContacto.Name = "txtNombreContacto";
            this.txtNombreContacto.Size = new System.Drawing.Size(502, 31);
            this.txtNombreContacto.TabIndex = 2;
            // 
            // txtNombreEmpresa
            // 
            this.txtNombreEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreEmpresa.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.txtNombreEmpresa.Location = new System.Drawing.Point(252, 16);
            this.txtNombreEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreEmpresa.Name = "txtNombreEmpresa";
            this.txtNombreEmpresa.Size = new System.Drawing.Size(502, 31);
            this.txtNombreEmpresa.TabIndex = 1;
            // 
            // Direccion
            // 
            this.Direccion.AutoSize = true;
            this.Direccion.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Direccion.Location = new System.Drawing.Point(15, 316);
            this.Direccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Direccion.Name = "Direccion";
            this.Direccion.Size = new System.Drawing.Size(110, 23);
            this.Direccion.TabIndex = 0;
            this.Direccion.Text = "Dirección";
            this.Direccion.Click += new System.EventHandler(this.Direccion_Click);
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email.Location = new System.Drawing.Point(15, 256);
            this.Email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(205, 23);
            this.Email.TabIndex = 0;
            this.Email.Text = "Correo Electrónico";
            this.Email.Click += new System.EventHandler(this.Email_Click);
            // 
            // Telefono
            // 
            this.Telefono.AutoSize = true;
            this.Telefono.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Telefono.Location = new System.Drawing.Point(15, 198);
            this.Telefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Telefono.Name = "Telefono";
            this.Telefono.Size = new System.Drawing.Size(102, 23);
            this.Telefono.TabIndex = 0;
            this.Telefono.Text = "Teléfono";
            this.Telefono.Click += new System.EventHandler(this.Telefono_Click);
            // 
            // NombreContacto
            // 
            this.NombreContacto.AutoSize = true;
            this.NombreContacto.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreContacto.Location = new System.Drawing.Point(15, 75);
            this.NombreContacto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NombreContacto.Name = "NombreContacto";
            this.NombreContacto.Size = new System.Drawing.Size(226, 23);
            this.NombreContacto.TabIndex = 0;
            this.NombreContacto.Text = "Nombre de Contacto";
            this.NombreContacto.Click += new System.EventHandler(this.NombreContacto_Click);
            // 
            // NombreEmpresa
            // 
            this.NombreEmpresa.AutoSize = true;
            this.NombreEmpresa.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreEmpresa.Location = new System.Drawing.Point(15, 23);
            this.NombreEmpresa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NombreEmpresa.Name = "NombreEmpresa";
            this.NombreEmpresa.Size = new System.Drawing.Size(221, 23);
            this.NombreEmpresa.TabIndex = 0;
            this.NombreEmpresa.Text = "Nombre de Empresa";
            this.NombreEmpresa.Click += new System.EventHandler(this.NombreEmpresa_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(427, 398);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(165, 44);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dtpFechaRegistro
            // 
            this.dtpFechaRegistro.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.dtpFechaRegistro.Location = new System.Drawing.Point(252, 133);
            this.dtpFechaRegistro.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaRegistro.Name = "dtpFechaRegistro";
            this.dtpFechaRegistro.Size = new System.Drawing.Size(502, 31);
            this.dtpFechaRegistro.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 133);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha de Registro";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(179, 398);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(165, 44);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // FrmAddSuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(775, 471);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.dtpFechaRegistro);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtNombreContacto);
            this.Controls.Add(this.NombreEmpresa);
            this.Controls.Add(this.txtNombreEmpresa);
            this.Controls.Add(this.NombreContacto);
            this.Controls.Add(this.Direccion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Telefono);
            this.Controls.Add(this.Email);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAddSuppliers";
            this.Text = "Añadir Proveedores";
            this.Load += new System.EventHandler(this.FrmAddSuppliers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Direccion;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.Label Telefono;
        private System.Windows.Forms.Label NombreContacto;
        private System.Windows.Forms.Label NombreEmpresa;
        public System.Windows.Forms.Button btnGuardar;
        public System.Windows.Forms.TextBox txtDireccion;
        public System.Windows.Forms.TextBox txtEmail;
        public System.Windows.Forms.TextBox txtNombreContacto;
        public System.Windows.Forms.TextBox txtNombreEmpresa;
        public System.Windows.Forms.TextBox txtTelefono;
        public System.Windows.Forms.DateTimePicker dtpFechaRegistro;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnLimpiar;
    }
}