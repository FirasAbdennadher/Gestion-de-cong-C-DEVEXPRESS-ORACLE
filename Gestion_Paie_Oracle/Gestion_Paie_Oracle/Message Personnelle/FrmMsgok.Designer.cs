namespace Gestion_Paie_Oracle.Message_Personnelle
{
    partial class frmmsgok
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
            this.fermer = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lemessage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // fermer
            // 
            this.fermer.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.fermer.Location = new System.Drawing.Point(133, 66);
            this.fermer.Name = "fermer";
            this.fermer.Size = new System.Drawing.Size(75, 23);
            this.fermer.TabIndex = 1;
            this.fermer.Text = "Ok";
            this.fermer.UseVisualStyleBackColor = true;
            this.fermer.Click += new System.EventHandler(this.fermer_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(243, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Expliquer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lemessage
            // 
            this.lemessage.AutoSize = true;
            this.lemessage.Location = new System.Drawing.Point(130, 20);
            this.lemessage.Name = "lemessage";
            this.lemessage.Size = new System.Drawing.Size(38, 14);
            this.lemessage.TabIndex = 3;
            this.lemessage.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gestion_Paie_Oracle.Properties.Resources.Exclamation_icon1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(82, 70);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmmsgok
            // 
            this.AcceptButton = this.fermer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 95);
            this.Controls.Add(this.lemessage);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.fermer);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmmsgok";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmMsgok";
            this.Load += new System.EventHandler(this.frmmsgok_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button fermer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lemessage;
    }
}