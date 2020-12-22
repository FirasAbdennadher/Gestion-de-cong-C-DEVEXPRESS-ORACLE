namespace Gestion_Paie_Oracle.Simple_Fenetre
{
    partial class Employer_datagridview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employer_datagridview));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.Dgpersonel = new DevExpress.XtraGrid.GridControl();
            this.dataSet21 = new Gestion_Paie_Oracle.DataSet2();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMATRICULE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPRENOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDATE_RECRUTEMENT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgpersonel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barButtonItem8});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 9;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(687, 151);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Click += new System.EventHandler(this.ribbon_Click);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Filtre Rapide";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "              ";
            this.barButtonItem5.Id = 5;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "barButtonItem6";
            this.barButtonItem6.Id = 6;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Recherche Rapide";
            this.barButtonItem7.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.Glyph")));
            this.barButtonItem7.Id = 7;
            this.barButtonItem7.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem7.LargeGlyph")));
            this.barButtonItem7.Name = "barButtonItem7";
            this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "Impression";
            this.barButtonItem8.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem8.Glyph")));
            this.barButtonItem8.Id = 8;
            this.barButtonItem8.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem8.LargeGlyph")));
            this.barButtonItem8.Name = "barButtonItem8";
            this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem8_ItemClick);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Filter & Impression";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem7);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem8);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 491);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(687, 34);
            // 
            // Dgpersonel
            // 
            this.Dgpersonel.DataMember = "EMPLOYE";
            this.Dgpersonel.DataSource = this.dataSet21;
            this.Dgpersonel.Location = new System.Drawing.Point(2, 148);
            this.Dgpersonel.MainView = this.gridView1;
            this.Dgpersonel.MenuManager = this.ribbon;
            this.Dgpersonel.Name = "Dgpersonel";
            this.Dgpersonel.Size = new System.Drawing.Size(684, 316);
            this.Dgpersonel.TabIndex = 5;
            this.Dgpersonel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.Dgpersonel.Click += new System.EventHandler(this.Dgpersonel_Click_1);
            // 
            // dataSet21
            // 
            this.dataSet21.DataSetName = "DataSet2";
            this.dataSet21.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMATRICULE,
            this.colCIN,
            this.colNOM,
            this.colPRENOM,
            this.colDATE_RECRUTEMENT});
            this.gridView1.GridControl = this.Dgpersonel;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colMATRICULE
            // 
            this.colMATRICULE.Caption = "Matricule";
            this.colMATRICULE.FieldName = "MATRICULE";
            this.colMATRICULE.Image = ((System.Drawing.Image)(resources.GetObject("colMATRICULE.Image")));
            this.colMATRICULE.Name = "colMATRICULE";
            this.colMATRICULE.Visible = true;
            this.colMATRICULE.VisibleIndex = 0;
            this.colMATRICULE.Width = 117;
            // 
            // colCIN
            // 
            this.colCIN.FieldName = "CIN";
            this.colCIN.Image = ((System.Drawing.Image)(resources.GetObject("colCIN.Image")));
            this.colCIN.Name = "colCIN";
            this.colCIN.Visible = true;
            this.colCIN.VisibleIndex = 1;
            this.colCIN.Width = 106;
            // 
            // colNOM
            // 
            this.colNOM.FieldName = "NOM";
            this.colNOM.Image = ((System.Drawing.Image)(resources.GetObject("colNOM.Image")));
            this.colNOM.Name = "colNOM";
            this.colNOM.Visible = true;
            this.colNOM.VisibleIndex = 2;
            this.colNOM.Width = 121;
            // 
            // colPRENOM
            // 
            this.colPRENOM.Caption = "Prenom";
            this.colPRENOM.FieldName = "PRENOM";
            this.colPRENOM.Image = ((System.Drawing.Image)(resources.GetObject("colPRENOM.Image")));
            this.colPRENOM.Name = "colPRENOM";
            this.colPRENOM.Visible = true;
            this.colPRENOM.VisibleIndex = 3;
            this.colPRENOM.Width = 132;
            // 
            // colDATE_RECRUTEMENT
            // 
            this.colDATE_RECRUTEMENT.Caption = "Date de Recrutement";
            this.colDATE_RECRUTEMENT.FieldName = "DATE_RECRUTEMENT";
            this.colDATE_RECRUTEMENT.Image = ((System.Drawing.Image)(resources.GetObject("colDATE_RECRUTEMENT.Image")));
            this.colDATE_RECRUTEMENT.Name = "colDATE_RECRUTEMENT";
            this.colDATE_RECRUTEMENT.Visible = true;
            this.colDATE_RECRUTEMENT.VisibleIndex = 4;
            this.colDATE_RECRUTEMENT.Width = 189;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Recherche Employeé";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // Employer_datagridview
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 525);
            this.Controls.Add(this.Dgpersonel);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "Employer_datagridview";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Liste des Employés";
            this.Load += new System.EventHandler(this.Employer_datagridview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgpersonel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        public DevExpress.XtraGrid.GridControl Dgpersonel;
        private DataSet2 dataSet21;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMATRICULE;
        private DevExpress.XtraGrid.Columns.GridColumn colCIN;
        private DevExpress.XtraGrid.Columns.GridColumn colNOM;
        private DevExpress.XtraGrid.Columns.GridColumn colPRENOM;
        private DevExpress.XtraGrid.Columns.GridColumn colDATE_RECRUTEMENT;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
    }
}