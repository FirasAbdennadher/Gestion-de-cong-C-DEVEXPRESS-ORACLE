namespace Gestion_Paie_Oracle.Simple_Fenetre
{
    partial class Disponibilité_Département
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Disponibilité_Département));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title7 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title8 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.dataSet1 = new Gestion_Paie_Oracle.DataSet1();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chart_non_valider = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_valider = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.vALIDATIONCONGEDEMANDECONGEBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_non_valider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_valider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vALIDATIONCONGEDEMANDECONGEBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barButtonItem1,
            this.barButtonItem2});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 3;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1362, 169);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Par employé";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Par Département";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage1.Image")));
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Département";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Filtre par Critére";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 745);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1362, 34);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chart_non_valider);
            this.groupControl1.Controls.Add(this.chart_valider);
            this.groupControl1.Location = new System.Drawing.Point(12, 175);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1344, 545);
            this.groupControl1.TabIndex = 13;
            this.groupControl1.Text = "Statistiques relatives au congés ";
            // 
            // chart_non_valider
            // 
            this.chart_non_valider.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.Name = "ChartArea1";
            this.chart_non_valider.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Name = "Legend1";
            legend1.Title = "Le nombre d\'employé qui ont pris congé dans cette periode ";
            this.chart_non_valider.Legends.Add(legend1);
            this.chart_non_valider.Location = new System.Drawing.Point(19, 38);
            this.chart_non_valider.Name = "chart_non_valider";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Nombre de jour de congé";
            this.chart_non_valider.Series.Add(series1);
            this.chart_non_valider.Size = new System.Drawing.Size(649, 526);
            this.chart_non_valider.TabIndex = 5;
            this.chart_non_valider.Text = "chart1";
            title1.Font = new System.Drawing.Font("Courier New", 14.26415F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.Red;
            title1.Name = "Title1";
            title1.Text = "Demandes de congés non encore validées";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title2";
            title2.Text = "Période :";
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F);
            title3.Name = "Title3";
            title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F);
            title4.Name = "Title4";
            this.chart_non_valider.Titles.Add(title1);
            this.chart_non_valider.Titles.Add(title2);
            this.chart_non_valider.Titles.Add(title3);
            this.chart_non_valider.Titles.Add(title4);
            // 
            // chart_valider
            // 
            this.chart_valider.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea2.Name = "ChartArea1";
            this.chart_valider.ChartAreas.Add(chartArea2);
            this.chart_valider.DataSource = this.vALIDATIONCONGEDEMANDECONGEBindingSource1;
            legend2.Name = "Legend1";
            this.chart_valider.Legends.Add(legend2);
            this.chart_valider.Location = new System.Drawing.Point(707, 38);
            this.chart_valider.Name = "chart_valider";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Nombre de jour de congé";
            this.chart_valider.Series.Add(series2);
            this.chart_valider.Size = new System.Drawing.Size(633, 507);
            this.chart_valider.TabIndex = 8;
            this.chart_valider.Text = "chart2";
            title5.Font = new System.Drawing.Font("Courier New", 14.26415F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title5.ForeColor = System.Drawing.Color.Red;
            title5.Name = "Title1";
            title5.Text = "Demande de congés Validées";
            title6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title6.Name = "Title2";
            title6.Text = "Période :";
            title7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F);
            title7.Name = "Title3";
            title8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.30189F);
            title8.Name = "Title4";
            this.chart_valider.Titles.Add(title5);
            this.chart_valider.Titles.Add(title6);
            this.chart_valider.Titles.Add(title7);
            this.chart_valider.Titles.Add(title8);
            // 
            // Disponibilité_Département
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 779);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "Disponibilité_Département";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Disponibilité Département";
            this.Load += new System.EventHandler(this.Disponibilité_Département_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_non_valider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_valider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vALIDATIONCONGEDEMANDECONGEBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DataSet1 dataSet1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_non_valider;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_valider;
        private System.Windows.Forms.BindingSource vALIDATIONCONGEDEMANDECONGEBindingSource1;
    }
}