namespace Gestion_Paie_Oracle.Simple_Fenetre
{
    partial class Compte
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
            this.groupControl10 = new DevExpress.XtraEditors.GroupControl();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.Password_utlisateur = new System.Windows.Forms.TextBox();
            this.login_utilsateur = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl10)).BeginInit();
            this.groupControl10.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl10
            // 
            this.groupControl10.AppearanceCaption.Font = new System.Drawing.Font("Nirmala UI", 10.86792F, System.Drawing.FontStyle.Bold);
            this.groupControl10.AppearanceCaption.Options.UseFont = true;
            this.groupControl10.Controls.Add(this.label42);
            this.groupControl10.Location = new System.Drawing.Point(173, 226);
            this.groupControl10.Name = "groupControl10";
            this.groupControl10.Size = new System.Drawing.Size(244, 40);
            this.groupControl10.TabIndex = 117;
            this.groupControl10.Text = "Authentification";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Times New Roman", 10.86792F);
            this.label44.ForeColor = System.Drawing.Color.Black;
            this.label44.Location = new System.Drawing.Point(152, 107);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(12, 19);
            this.label44.TabIndex = 118;
            this.label44.Text = ":";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Times New Roman", 10.86792F);
            this.label43.ForeColor = System.Drawing.Color.Black;
            this.label43.Location = new System.Drawing.Point(152, 30);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(12, 19);
            this.label43.TabIndex = 117;
            this.label43.Text = ":";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(279, 29);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(0, 14);
            this.label42.TabIndex = 93;
            this.label42.Visible = false;
            // 
            // Password_utlisateur
            // 
            this.Password_utlisateur.Location = new System.Drawing.Point(173, 103);
            this.Password_utlisateur.Name = "Password_utlisateur";
            this.Password_utlisateur.Size = new System.Drawing.Size(206, 21);
            this.Password_utlisateur.TabIndex = 109;
            // 
            // login_utilsateur
            // 
            this.login_utilsateur.Location = new System.Drawing.Point(173, 34);
            this.login_utilsateur.Name = "login_utilsateur";
            this.login_utilsateur.Size = new System.Drawing.Size(206, 21);
            this.login_utilsateur.TabIndex = 110;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 10.86792F);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(46, 30);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 19);
            this.label17.TabIndex = 111;
            this.label17.Text = "Login";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 10.86792F);
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(46, 106);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 19);
            this.label18.TabIndex = 112;
            this.label18.Text = "Mot de Pass";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(173, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 23);
            this.button1.TabIndex = 119;
            this.button1.Text = "Changer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Compte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 278);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.groupControl10);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.Password_utlisateur);
            this.Controls.Add(this.login_utilsateur);
            this.Name = "Compte";
            this.Text = "Compte";
            this.Load += new System.EventHandler(this.Compte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl10)).EndInit();
            this.groupControl10.ResumeLayout(false);
            this.groupControl10.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl10;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        public System.Windows.Forms.Label label42;
        public System.Windows.Forms.TextBox Password_utlisateur;
        public System.Windows.Forms.TextBox login_utilsateur;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button1;
    }
}