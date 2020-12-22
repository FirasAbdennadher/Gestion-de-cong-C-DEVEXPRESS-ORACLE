using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Gestion_Paie_Oracle
{
    public partial class Listes_Employes : DevExpress.XtraEditors.XtraForm
    {
        public Listes_Employes()
        {
            InitializeComponent();
        }

        private void Listes_Employes_Load(object sender, EventArgs e)
        {
            Gestion_Paie_Oracle.Menu.pr.remplirDG("employe","",gridControl1);
            #region hide colum
            gridView1.Columns[0].Visible = true;
            gridView1.Columns[1].Visible = true;
            gridView1.Columns[2].Visible = true;
            gridView1.Columns[3].Visible = true;
            gridView1.Columns[4].Visible = true;
            gridView1.Columns[5].Visible = true;
            gridView1.Columns[6].Visible = true;
            gridView1.Columns[7].Visible = true;
            gridView1.Columns[8].Visible = false;
            gridView1.Columns[9].Visible = true;
            gridView1.Columns[10].Visible = true;
            gridView1.Columns[11].Visible = false;
            gridView1.Columns[12].Visible = false;
            gridView1.Columns[13].Visible = false;
            gridView1.Columns[14].Visible = true;
            gridView1.Columns[15].Visible = true;
            gridView1.Columns[16].Visible = true;
            gridView1.Columns[17].Visible = false;
            gridView1.Columns[18].Visible = false;
            gridView1.Columns[19].Visible = false;


            #endregion

        }

        private void pirnt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.ShowPrintPreview();

        }

        private void gridControl1_Load(object sender, EventArgs e)
        {/*
            int index = gridView1.FocusedRowHandle;

            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                if (gridView1.GetRowCellValue(i, "etat_civil").ToString().Equals("Celibataire"))
                {
                    gridView1.SetRowCellValue(i, "nb_enfant", "");


                }
            }*/
        }
    }
}