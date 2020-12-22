using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Gestion_Paie_Oracle.Simple_Fenetre
{
    public partial class Departements : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static Departements edd;
        public Departements()
        {
            InitializeComponent();
        }

        private void Departements_Load(object sender, EventArgs e)
        {
            edd = this;

        }

        private void depar_grid_Click(object sender, EventArgs e)
        {
            int index = gridView1.FocusedRowHandle;

            Gestion_Paie_Oracle.Menu.pr.code_derppp.Text = gridView1.GetRowCellValue(index, "ID_DEPARTMENT").ToString();
            Gestion_Paie_Oracle.Menu.pr.libel_deparrrrr.Text = gridView1.GetRowCellValue(index, "DESGN_DEPARTEMENT").ToString();

            this.Close();

        }
    }
}