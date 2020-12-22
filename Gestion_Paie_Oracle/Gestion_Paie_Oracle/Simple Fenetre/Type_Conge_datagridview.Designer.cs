namespace Gestion_Paie_Oracle.Simple_Fenetre
{
    partial class Type_Conge_datagridview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Type_Conge_datagridview));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.DgTypeconge = new DevExpress.XtraGrid.GridControl();
            this.tYPECONGEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Gestion_Paie_Oracle.DataSet1();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID_CONGE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDESGIN_CONGE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSURDEMANDE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDUREE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCONGE_PAYE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDROIT_CONGE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJOUR_OUVRABLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAJ_CONGE_PAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPECIFICATION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tYPE_CONGETableAdapter = new Gestion_Paie_Oracle.DataSet1TableAdapters.TYPE_CONGETableAdapter();
            this.var_textbox_idconge = new System.Windows.Forms.TextBox();
            this.dataSet3 = new Gestion_Paie_Oracle.DataSet3();
            this.dataSet3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tYPECONGEBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tYPE_CONGETableAdapter1 = new Gestion_Paie_Oracle.DataSet3TableAdapters.TYPE_CONGETableAdapter();
            this.tYPECONGEBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgTypeconge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tYPECONGEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tYPECONGEBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tYPECONGEBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(765, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 486);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(765, 32);
            // 
            // DgTypeconge
            // 
            this.DgTypeconge.DataSource = this.dataSet3BindingSource;
            this.DgTypeconge.Location = new System.Drawing.Point(0, 158);
            this.DgTypeconge.MainView = this.gridView2;
            this.DgTypeconge.Name = "DgTypeconge";
            this.DgTypeconge.Size = new System.Drawing.Size(765, 329);
            this.DgTypeconge.TabIndex = 14;
            this.DgTypeconge.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.DgTypeconge.Click += new System.EventHandler(this.DgTypeconge_Click);
            // 
            // tYPECONGEBindingSource
            // 
            this.tYPECONGEBindingSource.DataMember = "TYPE_CONGE";
            this.tYPECONGEBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID_CONGE,
            this.colDESGIN_CONGE,
            this.colSURDEMANDE,
            this.colDUREE,
            this.colCONGE_PAYE,
            this.colDROIT_CONGE,
            this.colJOUR_OUVRABLE,
            this.colMAJ_CONGE_PAY,
            this.colSPECIFICATION});
            this.gridView2.GridControl = this.DgTypeconge;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colID_CONGE
            // 
            this.colID_CONGE.Caption = "Id Conge";
            this.colID_CONGE.FieldName = "ID_CONGE";
            this.colID_CONGE.Image = ((System.Drawing.Image)(resources.GetObject("colID_CONGE.Image")));
            this.colID_CONGE.Name = "colID_CONGE";
            this.colID_CONGE.Visible = true;
            this.colID_CONGE.VisibleIndex = 0;
            // 
            // colDESGIN_CONGE
            // 
            this.colDESGIN_CONGE.Caption = "Designation ";
            this.colDESGIN_CONGE.FieldName = "DESGIN_CONGE";
            this.colDESGIN_CONGE.Image = ((System.Drawing.Image)(resources.GetObject("colDESGIN_CONGE.Image")));
            this.colDESGIN_CONGE.Name = "colDESGIN_CONGE";
            this.colDESGIN_CONGE.Visible = true;
            this.colDESGIN_CONGE.VisibleIndex = 1;
            // 
            // colSURDEMANDE
            // 
            this.colSURDEMANDE.FieldName = "SURDEMANDE";
            this.colSURDEMANDE.Name = "colSURDEMANDE";
            // 
            // colDUREE
            // 
            this.colDUREE.FieldName = "DUREE";
            this.colDUREE.Name = "colDUREE";
            // 
            // colCONGE_PAYE
            // 
            this.colCONGE_PAYE.FieldName = "CONGE_PAYE";
            this.colCONGE_PAYE.Name = "colCONGE_PAYE";
            // 
            // colDROIT_CONGE
            // 
            this.colDROIT_CONGE.FieldName = "DROIT_CONGE";
            this.colDROIT_CONGE.Name = "colDROIT_CONGE";
            // 
            // colJOUR_OUVRABLE
            // 
            this.colJOUR_OUVRABLE.FieldName = "JOUR_OUVRABLE";
            this.colJOUR_OUVRABLE.Name = "colJOUR_OUVRABLE";
            // 
            // colMAJ_CONGE_PAY
            // 
            this.colMAJ_CONGE_PAY.FieldName = "MAJ_CONGE_PAY";
            this.colMAJ_CONGE_PAY.Name = "colMAJ_CONGE_PAY";
            // 
            // colSPECIFICATION
            // 
            this.colSPECIFICATION.Caption = "Specification";
            this.colSPECIFICATION.FieldName = "SPECIFICATION";
            this.colSPECIFICATION.Image = ((System.Drawing.Image)(resources.GetObject("colSPECIFICATION.Image")));
            this.colSPECIFICATION.Name = "colSPECIFICATION";
            this.colSPECIFICATION.Visible = true;
            this.colSPECIFICATION.VisibleIndex = 2;
            // 
            // tYPE_CONGETableAdapter
            // 
            this.tYPE_CONGETableAdapter.ClearBeforeFill = true;
            // 
            // var_textbox_idconge
            // 
            this.var_textbox_idconge.Location = new System.Drawing.Point(722, 328);
            this.var_textbox_idconge.Name = "var_textbox_idconge";
            this.var_textbox_idconge.Size = new System.Drawing.Size(56, 21);
            this.var_textbox_idconge.TabIndex = 17;
            this.var_textbox_idconge.Visible = false;
            // 
            // dataSet3
            // 
            this.dataSet3.DataSetName = "DataSet3";
            this.dataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet3BindingSource
            // 
            this.dataSet3BindingSource.DataSource = this.dataSet3;
            this.dataSet3BindingSource.Position = 0;
            // 
            // tYPECONGEBindingSource1
            // 
            this.tYPECONGEBindingSource1.DataMember = "TYPE_CONGE";
            this.tYPECONGEBindingSource1.DataSource = this.dataSet3BindingSource;
            // 
            // tYPE_CONGETableAdapter1
            // 
            this.tYPE_CONGETableAdapter1.ClearBeforeFill = true;
            // 
            // tYPECONGEBindingSource2
            // 
            this.tYPECONGEBindingSource2.DataMember = "TYPE_CONGE";
            this.tYPECONGEBindingSource2.DataSource = this.dataSet3BindingSource;
            // 
            // Type_Conge_datagridview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 518);
            this.Controls.Add(this.var_textbox_idconge);
            this.Controls.Add(this.DgTypeconge);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "Type_Conge_datagridview";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Liste des Types de Congés";
            this.Load += new System.EventHandler(this.datagrid_listTypeConge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgTypeconge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tYPECONGEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tYPECONGEBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tYPECONGEBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraGrid.Columns.GridColumn colID_CONGE;
        private DevExpress.XtraGrid.Columns.GridColumn colDESGIN_CONGE;
        private DevExpress.XtraGrid.Columns.GridColumn colSURDEMANDE;
        private DevExpress.XtraGrid.Columns.GridColumn colDUREE;
        private DevExpress.XtraGrid.Columns.GridColumn colCONGE_PAYE;
        private DevExpress.XtraGrid.Columns.GridColumn colDROIT_CONGE;
        private DevExpress.XtraGrid.Columns.GridColumn colJOUR_OUVRABLE;
        private DevExpress.XtraGrid.Columns.GridColumn colMAJ_CONGE_PAY;
        private DevExpress.XtraGrid.Columns.GridColumn colSPECIFICATION;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource tYPECONGEBindingSource;
        private DataSet1TableAdapters.TYPE_CONGETableAdapter tYPE_CONGETableAdapter;
        public DevExpress.XtraGrid.GridControl DgTypeconge;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        public System.Windows.Forms.TextBox var_textbox_idconge;
        private System.Windows.Forms.BindingSource dataSet3BindingSource;
        private DataSet3 dataSet3;
        private System.Windows.Forms.BindingSource tYPECONGEBindingSource1;
        private DataSet3TableAdapters.TYPE_CONGETableAdapter tYPE_CONGETableAdapter1;
        private System.Windows.Forms.BindingSource tYPECONGEBindingSource2;
    }
}