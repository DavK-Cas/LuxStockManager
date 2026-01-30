namespace SistemaJoyería.View.ClientsView
{
    partial class FrmAddClients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddClients));
            this.txtAddress = new System.Windows.Forms.Label();
            this.txtDuiDoc = new System.Windows.Forms.Label();
            this.txtClientsBirthday = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.Label();
            this.txtCellphoneN = new System.Windows.Forms.Label();
            this.txtClientsSurname = new System.Windows.Forms.Label();
            this.txtClientsName = new System.Windows.Forms.Label();
            this.tbClientsName = new System.Windows.Forms.TextBox();
            this.tbClientsSurname = new System.Windows.Forms.TextBox();
            this.dtpClientsBirthday = new System.Windows.Forms.DateTimePicker();
            this.mskCellphoneN = new System.Windows.Forms.MaskedTextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.mskDuiDoc = new System.Windows.Forms.MaskedTextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.AutoSize = true;
            this.txtAddress.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(13, 506);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(110, 23);
            this.txtAddress.TabIndex = 42;
            this.txtAddress.Text = "Dirección";
            // 
            // txtDuiDoc
            // 
            this.txtDuiDoc.AutoSize = true;
            this.txtDuiDoc.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuiDoc.Location = new System.Drawing.Point(13, 418);
            this.txtDuiDoc.Name = "txtDuiDoc";
            this.txtDuiDoc.Size = new System.Drawing.Size(48, 23);
            this.txtDuiDoc.TabIndex = 40;
            this.txtDuiDoc.Text = "DUI";
            // 
            // txtClientsBirthday
            // 
            this.txtClientsBirthday.AutoSize = true;
            this.txtClientsBirthday.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientsBirthday.Location = new System.Drawing.Point(12, 167);
            this.txtClientsBirthday.Name = "txtClientsBirthday";
            this.txtClientsBirthday.Size = new System.Drawing.Size(227, 23);
            this.txtClientsBirthday.TabIndex = 38;
            this.txtClientsBirthday.Text = "Fecha de nacimiento";
            // 
            // txtEmail
            // 
            this.txtEmail.AutoSize = true;
            this.txtEmail.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(12, 345);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(205, 23);
            this.txtEmail.TabIndex = 28;
            this.txtEmail.Text = "Correo Electrónico";
            // 
            // txtCellphoneN
            // 
            this.txtCellphoneN.AutoSize = true;
            this.txtCellphoneN.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCellphoneN.Location = new System.Drawing.Point(13, 257);
            this.txtCellphoneN.Name = "txtCellphoneN";
            this.txtCellphoneN.Size = new System.Drawing.Size(223, 23);
            this.txtCellphoneN.TabIndex = 29;
            this.txtCellphoneN.Text = "Número de Teléfono";
            // 
            // txtClientsSurname
            // 
            this.txtClientsSurname.AutoSize = true;
            this.txtClientsSurname.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientsSurname.Location = new System.Drawing.Point(13, 89);
            this.txtClientsSurname.Name = "txtClientsSurname";
            this.txtClientsSurname.Size = new System.Drawing.Size(98, 23);
            this.txtClientsSurname.TabIndex = 30;
            this.txtClientsSurname.Text = "Apellido";
            // 
            // txtClientsName
            // 
            this.txtClientsName.AutoSize = true;
            this.txtClientsName.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientsName.Location = new System.Drawing.Point(12, 14);
            this.txtClientsName.Name = "txtClientsName";
            this.txtClientsName.Size = new System.Drawing.Size(93, 23);
            this.txtClientsName.TabIndex = 31;
            this.txtClientsName.Text = "Nombre";
            // 
            // tbClientsName
            // 
            this.tbClientsName.BackColor = System.Drawing.Color.White;
            this.tbClientsName.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.tbClientsName.Location = new System.Drawing.Point(17, 42);
            this.tbClientsName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbClientsName.Name = "tbClientsName";
            this.tbClientsName.Size = new System.Drawing.Size(509, 31);
            this.tbClientsName.TabIndex = 1;
            // 
            // tbClientsSurname
            // 
            this.tbClientsSurname.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.tbClientsSurname.Location = new System.Drawing.Point(17, 114);
            this.tbClientsSurname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbClientsSurname.Name = "tbClientsSurname";
            this.tbClientsSurname.Size = new System.Drawing.Size(509, 31);
            this.tbClientsSurname.TabIndex = 2;
            // 
            // dtpClientsBirthday
            // 
            this.dtpClientsBirthday.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.dtpClientsBirthday.Location = new System.Drawing.Point(17, 206);
            this.dtpClientsBirthday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpClientsBirthday.Name = "dtpClientsBirthday";
            this.dtpClientsBirthday.Size = new System.Drawing.Size(509, 31);
            this.dtpClientsBirthday.TabIndex = 3;
            // 
            // mskCellphoneN
            // 
            this.mskCellphoneN.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.mskCellphoneN.Location = new System.Drawing.Point(17, 298);
            this.mskCellphoneN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mskCellphoneN.Mask = "0000-0000";
            this.mskCellphoneN.Name = "mskCellphoneN";
            this.mskCellphoneN.Size = new System.Drawing.Size(509, 31);
            this.mskCellphoneN.TabIndex = 4;
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.tbEmail.Location = new System.Drawing.Point(17, 370);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(509, 31);
            this.tbEmail.TabIndex = 5;
            // 
            // mskDuiDoc
            // 
            this.mskDuiDoc.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.mskDuiDoc.Location = new System.Drawing.Point(17, 458);
            this.mskDuiDoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mskDuiDoc.Mask = "00000000-0";
            this.mskDuiDoc.Name = "mskDuiDoc";
            this.mskDuiDoc.Size = new System.Drawing.Size(508, 31);
            this.mskDuiDoc.TabIndex = 6;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnDelete.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(104, 636);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(135, 46);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Limpiar";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnOK.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(307, 636);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(135, 46);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "Guardar";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // tbAddress
            // 
            this.tbAddress.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.tbAddress.Location = new System.Drawing.Point(16, 532);
            this.tbAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbAddress.Multiline = true;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(509, 84);
            this.tbAddress.TabIndex = 7;
            // 
            // FrmAddClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 694);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.mskDuiDoc);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.mskCellphoneN);
            this.Controls.Add(this.dtpClientsBirthday);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.tbClientsSurname);
            this.Controls.Add(this.tbClientsName);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtDuiDoc);
            this.Controls.Add(this.txtClientsBirthday);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtCellphoneN);
            this.Controls.Add(this.txtClientsSurname);
            this.Controls.Add(this.txtClientsName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddClients";
            this.Text = "Añadir clientes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label txtAddress;
        public System.Windows.Forms.Label txtDuiDoc;
        public System.Windows.Forms.Label txtClientsBirthday;
        public System.Windows.Forms.Label txtEmail;
        public System.Windows.Forms.Label txtCellphoneN;
        public System.Windows.Forms.Label txtClientsSurname;
        public System.Windows.Forms.Label txtClientsName;
        public System.Windows.Forms.TextBox tbClientsName;
        public System.Windows.Forms.TextBox tbClientsSurname;
        public System.Windows.Forms.DateTimePicker dtpClientsBirthday;
        public System.Windows.Forms.MaskedTextBox mskCellphoneN;
        public System.Windows.Forms.TextBox tbEmail;
        public System.Windows.Forms.MaskedTextBox mskDuiDoc;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.TextBox tbAddress;
    }
}