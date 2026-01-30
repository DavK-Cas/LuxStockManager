namespace SistemaJoyería.View.UsersView
{
    partial class FrmUserView
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
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.MenuUsuarios = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbRolUser = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdUser = new System.Windows.Forms.TextBox();
            this.txtUpdateEstado = new System.Windows.Forms.TextBox();
            this.txtUpdateUserEmail = new System.Windows.Forms.TextBox();
            this.txtUpdateUserPassword = new System.Windows.Forms.TextBox();
            this.txtUpdateUserName = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchUser = new System.Windows.Forms.Button();
            this.txtSearchUser = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAddClients = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.MenuUsuarios.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUser.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(228)))), ((int)(((byte)(226)))));
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.ContextMenuStrip = this.MenuUsuarios;
            this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUser.Location = new System.Drawing.Point(242, 83);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.ReadOnly = true;
            this.dgvUser.RowHeadersVisible = false;
            this.dgvUser.RowHeadersWidth = 51;
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.Size = new System.Drawing.Size(724, 526);
            this.dgvUser.TabIndex = 69;
            // 
            // MenuUsuarios
            // 
            this.MenuUsuarios.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuUsuarios.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsDeleteUser});
            this.MenuUsuarios.Name = "MenuProductos";
            this.MenuUsuarios.Size = new System.Drawing.Size(161, 26);
            // 
            // cmsDeleteUser
            // 
            this.cmsDeleteUser.Name = "cmsDeleteUser";
            this.cmsDeleteUser.Size = new System.Drawing.Size(160, 22);
            this.cmsDeleteUser.Text = "Eliminar Usuario";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.cmbRolUser);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtIdUser);
            this.panel1.Controls.Add(this.txtUpdateEstado);
            this.panel1.Controls.Add(this.txtUpdateUserEmail);
            this.panel1.Controls.Add(this.txtUpdateUserPassword);
            this.panel1.Controls.Add(this.txtUpdateUserName);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(0, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 526);
            this.panel1.TabIndex = 68;
            // 
            // cmbRolUser
            // 
            this.cmbRolUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbRolUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRolUser.FormattingEnabled = true;
            this.cmbRolUser.Items.AddRange(new object[] {
            "administrador",
            "Empleado"});
            this.cmbRolUser.Location = new System.Drawing.Point(12, 281);
            this.cmbRolUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbRolUser.Name = "cmbRolUser";
            this.cmbRolUser.Size = new System.Drawing.Size(212, 28);
            this.cmbRolUser.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(9, 260);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Rol";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(9, 325);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "ID";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(9, 202);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Estado";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(9, 141);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Correo Electrónico";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(9, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Contraseña";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nombre de Usuario";
            // 
            // txtIdUser
            // 
            this.txtIdUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIdUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdUser.Location = new System.Drawing.Point(12, 346);
            this.txtIdUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIdUser.Name = "txtIdUser";
            this.txtIdUser.Size = new System.Drawing.Size(212, 26);
            this.txtIdUser.TabIndex = 14;
            // 
            // txtUpdateEstado
            // 
            this.txtUpdateEstado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUpdateEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUpdateEstado.Location = new System.Drawing.Point(12, 223);
            this.txtUpdateEstado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUpdateEstado.Name = "txtUpdateEstado";
            this.txtUpdateEstado.Size = new System.Drawing.Size(212, 26);
            this.txtUpdateEstado.TabIndex = 14;
            // 
            // txtUpdateUserEmail
            // 
            this.txtUpdateUserEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUpdateUserEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUpdateUserEmail.Location = new System.Drawing.Point(12, 162);
            this.txtUpdateUserEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUpdateUserEmail.Name = "txtUpdateUserEmail";
            this.txtUpdateUserEmail.Size = new System.Drawing.Size(212, 26);
            this.txtUpdateUserEmail.TabIndex = 14;
            // 
            // txtUpdateUserPassword
            // 
            this.txtUpdateUserPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUpdateUserPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUpdateUserPassword.Location = new System.Drawing.Point(12, 96);
            this.txtUpdateUserPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUpdateUserPassword.Name = "txtUpdateUserPassword";
            this.txtUpdateUserPassword.Size = new System.Drawing.Size(212, 26);
            this.txtUpdateUserPassword.TabIndex = 14;
            // 
            // txtUpdateUserName
            // 
            this.txtUpdateUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUpdateUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUpdateUserName.Location = new System.Drawing.Point(12, 31);
            this.txtUpdateUserName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUpdateUserName.Name = "txtUpdateUserName";
            this.txtUpdateUserName.Size = new System.Drawing.Size(212, 26);
            this.txtUpdateUserName.TabIndex = 14;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(5, 431);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(99, 37);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Limpiar";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(124, 431);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(99, 37);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Actualizar";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.btnAddUser);
            this.panel4.Controls.Add(this.btnRestart);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.btnSearchUser);
            this.panel4.Controls.Add(this.txtSearchUser);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(966, 83);
            this.panel4.TabIndex = 67;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Location = new System.Drawing.Point(833, 26);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(130, 37);
            this.btnAddUser.TabIndex = 4;
            this.btnAddUser.Text = "Añadir";
            this.btnAddUser.UseVisualStyleBackColor = false;
            // 
            // btnRestart
            // 
            this.btnRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnRestart.ForeColor = System.Drawing.Color.White;
            this.btnRestart.Location = new System.Drawing.Point(698, 26);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(130, 37);
            this.btnRestart.TabIndex = 3;
            this.btnRestart.Text = "Reiniciar";
            this.btnRestart.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "CONTROL DE USUARIOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnSearchUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSearchUser.ForeColor = System.Drawing.Color.White;
            this.btnSearchUser.Location = new System.Drawing.Point(530, 26);
            this.btnSearchUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(130, 37);
            this.btnSearchUser.TabIndex = 2;
            this.btnSearchUser.Text = "Buscar";
            this.btnSearchUser.UseVisualStyleBackColor = false;
            // 
            // txtSearchUser
            // 
            this.txtSearchUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSearchUser.Location = new System.Drawing.Point(242, 33);
            this.txtSearchUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearchUser.Name = "txtSearchUser";
            this.txtSearchUser.Size = new System.Drawing.Size(269, 26);
            this.txtSearchUser.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(686, 19);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(143, 40);
            this.btnRefresh.TabIndex = 65;
            this.btnRefresh.Text = "Refrescar ";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnAddClients
            // 
            this.btnAddClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnAddClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddClients.ForeColor = System.Drawing.Color.White;
            this.btnAddClients.Location = new System.Drawing.Point(833, 19);
            this.btnAddClients.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddClients.Name = "btnAddClients";
            this.btnAddClients.Size = new System.Drawing.Size(106, 40);
            this.btnAddClients.TabIndex = 66;
            this.btnAddClients.Text = "Añadir";
            this.btnAddClients.UseVisualStyleBackColor = false;
            // 
            // FrmUserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 609);
            this.Controls.Add(this.dgvUser);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAddClients);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmUserView";
            this.Text = "FrmUserView";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.MenuUsuarios.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvUser;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnAddUser;
        public System.Windows.Forms.Button btnRestart;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnSearchUser;
        public System.Windows.Forms.TextBox txtSearchUser;
        public System.Windows.Forms.Button btnRefresh;
        public System.Windows.Forms.Button btnAddClients;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtUpdateUserName;
        public System.Windows.Forms.ComboBox cmbRolUser;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtUpdateUserEmail;
        public System.Windows.Forms.TextBox txtUpdateUserPassword;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtIdUser;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtUpdateEstado;
        public System.Windows.Forms.ContextMenuStrip MenuUsuarios;
        public System.Windows.Forms.ToolStripMenuItem cmsDeleteUser;
    }
}