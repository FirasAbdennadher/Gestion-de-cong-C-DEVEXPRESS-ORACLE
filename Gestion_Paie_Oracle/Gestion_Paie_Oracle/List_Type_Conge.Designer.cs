namespace Gestion_Paie_Oracle
{
    partial class List_Type_Conge
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
            this.DgTypecong_demande_conge = new DevExpress.XtraGrid.GridControl();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.var_textbox_idconge = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgTypecong_demande_conge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            this.SuspendLayout();
            // 
            // DgTypecong_demande_conge
            // 
            this.DgTypecong_demande_conge.DataMember = "TYPE_CONGE";
            this.DgTypecong_demande_conge.Dock = System.Windows.Forms.DockStyle.Left;
            this.DgTypecong_demande_conge.Location = new System.Drawing.Point(0, 0);
            this.DgTypecong_demande_conge.MainView = this.gridView5;
            this.DgTypecong_demande_conge.Name = "DgTypecong_demande_conge";
            this.DgTypecong_demande_conge.Size = new System.Drawing.Size(294, 383);
            this.DgTypecong_demande_conge.TabIndex = 8;
            this.DgTypecong_demande_conge.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView5});
            this.DgTypecong_demande_conge.Click += new System.EventHandler(this.DgTypecong_demande_conge_Click);
            // 
            // gridView5
            // 
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn14,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18});
            this.gridView5.GridControl = this.DgTypecong_demande_conge;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsFind.AlwaysVisible = true;
            this.gridView5.OptionsFind.FindNullPrompt = "Filtre Par Critére ...";
            this.gridView5.OptionsFind.ShowClearButton = false;
            this.gridView5.OptionsFind.ShowFindButton = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.FieldName = "ID_CONGE";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            // 
            // gridColumn11
            // 
            this.gridColumn11.FieldName = "DESGIN_CONGE";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 1;
            // 
            // gridColumn14
            // 
            this.gridColumn14.FieldName = "CONGE_PAYE";
            this.gridColumn14.Name = "gridColumn14";
            // 
            // gridColumn16
            // 
            this.gridColumn16.FieldName = "JOUR_OUVRABLE";
            this.gridColumn16.Name = "gridColumn16";
            // 
            // gridColumn17
            // 
            this.gridColumn17.FieldName = "MAJ_CONGE_PAY";
            this.gridColumn17.Name = "gridColumn17";
            // 
            // gridColumn18
            // 
            this.gridColumn18.FieldName = "SPECIFICATION";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 2;
            // 
            // var_textbox_idconge
            // 
            this.var_textbox_idconge.Location = new System.Drawing.Point(252, 182);
            this.var_textbox_idconge.Name = "var_textbox_idconge";
            this.var_textbox_idconge.Size = new System.Drawing.Size(124, 20);
            this.var_textbox_idconge.TabIndex = 9;
            this.var_textbox_idconge.Visible = false;
            // 
            // List_Type_Conge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 383);
            this.Controls.Add(this.var_textbox_idconge);
            this.Controls.Add(this.DgTypecong_demande_conge);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "List_Type_Conge";
            this.Text = "List_Type_Conge";
            this.Load += new System.EventHandler(this.List_Type_Conge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgTypecong_demande_conge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl DgTypecong_demande_conge;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        public System.Windows.Forms.TextBox var_textbox_idconge;
    }
}