namespace Gestion_Paie_Oracle.Message_Personnelle
{
    partial class FrmMsgYesNo
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
            this.lemessage = new System.Windows.Forms.Label();
            this.fermer = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lemessage
            // 
            this.lemessage.AutoSize = true;
            this.lemessage.Location = new System.Drawing.Point(130, 24);
            this.lemessage.Name = "lemessage";
            this.lemessage.Size = new System.Drawing.Size(38, 14);
            this.lemessage.TabIndex = 7;
            this.lemessage.Text = "label1";
            // 
            // fermer
            // 
            this.fermer.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.fermer.Location = new System.Drawing.Point(162, 71);
            this.fermer.Name = "fermer";
            this.fermer.Size = new System.Drawing.Size(75, 23);
            this.fermer.TabIndex = 5;
            this.fermer.Text = "Ok";
            this.fermer.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gestion_Paie_Oracle.Properties.Resources.Icon_Small_2x;
            this.pictureBox1.Location = new System.Drawing.Point(22, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 60);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMsgYesNo
            // 
            this.AcceptButton = this.fermer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 97);
            this.Controls.Add(this.lemessage);
            this.Controls.Add(this.fermer);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmMsgYesNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rappel";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lemessage;
        private System.Windows.Forms.Button fermer;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}