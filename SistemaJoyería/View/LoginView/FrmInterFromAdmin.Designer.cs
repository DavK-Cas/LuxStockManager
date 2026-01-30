namespace SistemaJoyería.View.LoginView
{
    partial class FrmInterFromAdmin
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
            this.BtnContraAdmin = new System.Windows.Forms.Button();
            this.txtContraseñaAdmin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnComeBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnContraAdmin
            // 
            this.BtnContraAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.BtnContraAdmin.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.BtnContraAdmin.ForeColor = System.Drawing.Color.White;
            this.BtnContraAdmin.Location = new System.Drawing.Point(110, 260);
            this.BtnContraAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.BtnContraAdmin.Name = "BtnContraAdmin";
            this.BtnContraAdmin.Size = new System.Drawing.Size(119, 52);
            this.BtnContraAdmin.TabIndex = 2;
            this.BtnContraAdmin.Text = "Confirmar";
            this.BtnContraAdmin.UseVisualStyleBackColor = false;
            // 
            // txtContraseñaAdmin
            // 
            this.txtContraseñaAdmin.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.txtContraseñaAdmin.Location = new System.Drawing.Point(54, 219);
            this.txtContraseñaAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.txtContraseñaAdmin.MaxLength = 50;
            this.txtContraseñaAdmin.Name = "txtContraseñaAdmin";
            this.txtContraseñaAdmin.Size = new System.Drawing.Size(234, 26);
            this.txtContraseñaAdmin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(51, 186);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Contraseña del Administrador";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::SistemaJoyería.Properties.Resources.User1;
            this.pictureBox1.Location = new System.Drawing.Point(54, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(233, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnComeBack
            // 
            this.btnComeBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnComeBack.Font = new System.Drawing.Font("Lucida Sans", 12F);
            this.btnComeBack.ForeColor = System.Drawing.Color.White;
            this.btnComeBack.Location = new System.Drawing.Point(253, 313);
            this.btnComeBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnComeBack.Name = "btnComeBack";
            this.btnComeBack.Size = new System.Drawing.Size(83, 30);
            this.btnComeBack.TabIndex = 3;
            this.btnComeBack.Text = "Regresar";
            this.btnComeBack.UseVisualStyleBackColor = false;
            // 
            // FrmInterFromAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(347, 354);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnComeBack);
            this.Controls.Add(this.BtnContraAdmin);
            this.Controls.Add(this.txtContraseñaAdmin);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmInterFromAdmin";
            this.Text = "FrmInterFromAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button BtnContraAdmin;
        public System.Windows.Forms.TextBox txtContraseñaAdmin;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button btnComeBack;
    }
}