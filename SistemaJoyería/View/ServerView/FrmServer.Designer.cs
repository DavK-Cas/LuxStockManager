namespace SistemaJoyería.View.ServerView
{
    partial class FrmServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmServer));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDataB = new System.Windows.Forms.TextBox();
            this.txtUserS = new System.Windows.Forms.TextBox();
            this.txtPasswordS = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(265, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Servidor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(459, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Base de datos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(265, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Usuario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(459, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Contraseña";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(268, 86);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(166, 20);
            this.txtServer.TabIndex = 1;
            // 
            // txtDataB
            // 
            this.txtDataB.Location = new System.Drawing.Point(462, 86);
            this.txtDataB.Name = "txtDataB";
            this.txtDataB.Size = new System.Drawing.Size(166, 20);
            this.txtDataB.TabIndex = 2;
            // 
            // txtUserS
            // 
            this.txtUserS.Location = new System.Drawing.Point(268, 161);
            this.txtUserS.Name = "txtUserS";
            this.txtUserS.Size = new System.Drawing.Size(166, 20);
            this.txtUserS.TabIndex = 3;
            // 
            // txtPasswordS
            // 
            this.txtPasswordS.Location = new System.Drawing.Point(462, 161);
            this.txtPasswordS.Name = "txtPasswordS";
            this.txtPasswordS.Size = new System.Drawing.Size(166, 20);
            this.txtPasswordS.TabIndex = 4;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(401, 226);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(93, 31);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Conectar";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(243, 266);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 278);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtPasswordS);
            this.Controls.Add(this.txtUserS);
            this.Controls.Add(this.txtDataB);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmServer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtServer;
        public System.Windows.Forms.TextBox txtDataB;
        public System.Windows.Forms.TextBox txtUserS;
        public System.Windows.Forms.TextBox txtPasswordS;
        public System.Windows.Forms.Button btnConnect;
    }
}