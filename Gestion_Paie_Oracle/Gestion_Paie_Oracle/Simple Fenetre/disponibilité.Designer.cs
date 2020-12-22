namespace Gestion_Paie_Oracle.Simple_Fenetre
{
    partial class disponibilité
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(disponibilité));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title17 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title18 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title19 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title20 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title21 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title22 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title23 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title24 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.parremployer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.dataSet1 = new Gestion_Paie_Oracle.DataSet1();
            this.dEMANDECONGEBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dEMANDECONGEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dEMANDE_CONGETableAdapter = new Gestion_Paie_Oracle.DataSet1TableAdapters.DEMANDE_CONGETableAdapter();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEMANDECONGEBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEMANDECONGEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.parremployer,
            this.barButtonItem1});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 3;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1368, 169);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Click += new System.EventHandler(this.ribbon_Click);
            // 
            // parremployer
            // 
            this.parremployer.Caption = "Par employé";
            this.parremployer.Glyph = ((System.Drawing.Image)(resources.GetObject("parremployer.Glyph")));
            this.parremployer.Id = 1;
            this.parremployer.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("parremployer.LargeGlyph")));
            this.parremployer.Name = "parremployer";
            this.parremployer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.parremployer_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Par service";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage1.Image")));
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "SERVICES";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.parremployer);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Filtre par Critére";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 745);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1368, 34);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dEMANDECONGEBindingSource1
            // 
            this.dEMANDECONGEBindingSource1.DataMember = "DEMANDE_CONGE";
            this.dEMANDECONGEBindingSource1.DataSource = this.dataSet1;
            // 
            // dEMANDECONGEBindingSource
            // 
            this.dEMANDECONGEBindingSource.DataMember = "DEMANDE_CONGE";
            this.dEMANDECONGEBindingSource.DataSource = this.dataSet1;
            // 
            // dEMANDE_CONGETableAdapter
            // 
            this.dEMANDE_CONGETableAdapter.ClearBeforeFill = true;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea5.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.DataSource = this.dEMANDECONGEBindingSource1;
            legend5.Name = "Legend1";
            legend5.Title = "Le nombre d\'employé qui ont demander un congé dans cette periode :";
            this.chart1.Legends.Add(legend5);
            this.chart1.Location = new System.Drawing.Point(19, 38);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Nombre de jour de congé";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(667, 507);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            title17.Font = new System.Drawing.Font("Courier New", 14.26415F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title17.ForeColor = System.Drawing.Color.Red;
            title17.Name = "Title1";
            title17.Text = "Demandes de congés non encore validés";
            title18.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title18.Name = "Title2";
            title18.Text = "Période :";
            title19.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F);
            title19.Name = "Title3";
            title20.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F);
            title20.Name = "Title4";
            this.chart1.Titles.Add(title17);
            this.chart1.Titles.Add(title18);
            this.chart1.Titles.Add(title19);
            this.chart1.Titles.Add(title20);
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Transparent;
            chartArea6.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea6.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea6);
            this.chart2.DataSource = this.dEMANDECONGEBindingSource;
            legend6.Name = "Legend1";
            legend6.Title = "Le nombre d\'employé qui ont demander un congé dans cette periode :";
            this.chart2.Legends.Add(legend6);
            this.chart2.Location = new System.Drawing.Point(707, 38);
            this.chart2.Name = "chart2";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Nombre de jour de congé";
            this.chart2.Series.Add(series6);
            this.chart2.Size = new System.Drawing.Size(633, 507);
            this.chart2.TabIndex = 8;
            this.chart2.Text = "chart2";
            title21.Font = new System.Drawing.Font("Courier New", 14.26415F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title21.ForeColor = System.Drawing.Color.Red;
            title21.Name = "Title1";
            title21.Text = "Demande de congés Validés";
            title22.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title22.Name = "Title2";
            title22.Text = "Période :";
            title23.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F);
            title23.Name = "Title3";
            title24.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F);
            title24.Name = "Title4";
            this.chart2.Titles.Add(title21);
            this.chart2.Titles.Add(title22);
            this.chart2.Titles.Add(title23);
            this.chart2.Titles.Add(title24);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 14);
            this.label1.TabIndex = 9;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chart1);
            this.groupControl1.Controls.Add(this.chart2);
            this.groupControl1.Location = new System.Drawing.Point(7, 168);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1355, 580);
            this.groupControl1.TabIndex = 12;
            this.groupControl1.Text = "Statistiques relatives au congés ";
            // 
            // disponibilité
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 779);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "disponibilité";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Disponibilité Services";
            this.Load += new System.EventHandler(this.disponibilité_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEMANDECONGEBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEMANDECONGEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DataSet1 dataSet1;
        private DevExpress.XtraBars.BarButtonItem parremployer;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private System.Windows.Forms.BindingSource dEMANDECONGEBindingSource;
        private DataSet1TableAdapters.DEMANDE_CONGETableAdapter dEMANDE_CONGETableAdapter;
        private System.Windows.Forms.BindingSource dEMANDECONGEBindingSource1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}