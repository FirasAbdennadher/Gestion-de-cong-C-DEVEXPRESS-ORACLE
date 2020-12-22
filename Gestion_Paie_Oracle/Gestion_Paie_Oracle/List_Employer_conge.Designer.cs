namespace Gestion_Paie_Oracle
{
    partial class List_Employer_conge
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.eMPLOYEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Gestion_Paie_Oracle.DataSet1();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPRENOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.eMPLOYETableAdapter = new Gestion_Paie_Oracle.DataSet1TableAdapters.EMPLOYETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eMPLOYEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.eMPLOYEBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(307, 374);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // eMPLOYEBindingSource
            // 
            this.eMPLOYEBindingSource.DataMember = "EMPLOYE";
            this.eMPLOYEBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCIN,
            this.colNOM,
            this.colPRENOM});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "Filter par Critére ...";
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colCIN
            // 
            this.colCIN.FieldName = "CIN";
            this.colCIN.Name = "colCIN";
            this.colCIN.Visible = true;
            this.colCIN.VisibleIndex = 0;
            this.colCIN.Width = 98;
            // 
            // colNOM
            // 
            this.colNOM.FieldName = "NOM";
            this.colNOM.Name = "colNOM";
            this.colNOM.Visible = true;
            this.colNOM.VisibleIndex = 1;
            this.colNOM.Width = 108;
            // 
            // colPRENOM
            // 
            this.colPRENOM.FieldName = "PRENOM";
            this.colPRENOM.Name = "colPRENOM";
            this.colPRENOM.Visible = true;
            this.colPRENOM.VisibleIndex = 2;
            this.colPRENOM.Width = 86;
            // 
            // eMPLOYETableAdapter
            // 
            this.eMPLOYETableAdapter.ClearBeforeFill = true;
            // 
            // List_Employer_conge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 374);
            this.ControlBox = false;
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(280, 130);
            this.Name = "List_Employer_conge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "List_Employer_conge";
            this.Load += new System.EventHandler(this.List_Employer_conge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eMPLOYEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource eMPLOYEBindingSource;
        private DataSet1TableAdapters.EMPLOYETableAdapter eMPLOYETableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colCIN;
        private DevExpress.XtraGrid.Columns.GridColumn colNOM;
        private DevExpress.XtraGrid.Columns.GridColumn colPRENOM;
    }
}