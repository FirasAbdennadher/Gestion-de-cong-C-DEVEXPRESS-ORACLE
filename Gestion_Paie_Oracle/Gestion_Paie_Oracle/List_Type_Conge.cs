using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gestion_Paie_Oracle
{
    public partial class List_Type_Conge : Form
    {
        public static List_Type_Conge ltype;

        public List_Type_Conge()
        {
            InitializeComponent();
        }

        private void List_Type_Conge_Load(object sender, EventArgs e)
        {
            ltype = this;
           Gestion_Paie_Oracle.Menu.pr.remplirDG("TYPE_CONGE", "", DgTypecong_demande_conge);
        }

        private void DgTypecong_demande_conge_Click(object sender, EventArgs e)
        {


            int index = gridView5.FocusedRowHandle;

         Gestion_Paie_Oracle.Menu.pr.id_conger_pourenregiter = gridView5.GetRowCellValue(index, "ID_CONGE").ToString();

            Gestion_Paie_Oracle.Menu.pr.cbcongepay.Text = gridView5.GetRowCellValue(index, "CONGE_PAYE").ToString();
            Gestion_Paie_Oracle.Menu.pr.cb_maj.Text = gridView5.GetRowCellValue(index, "MAJ_CONGE_PAY").ToString();
            Gestion_Paie_Oracle.Menu.pr.cb_jouvrable.Text = gridView5.GetRowCellValue(index, "JOUR_OUVRABLE").ToString();
            Gestion_Paie_Oracle.Menu.pr.code_type_cong_ongle_demande.Text = gridView5.GetRowCellValue(index, "ID_CONGE").ToString();
            Gestion_Paie_Oracle.Menu.pr.libelel_type_conge.Text = gridView5.GetRowCellValue(index, "DESGIN_CONGE").ToString();

            var_textbox_idconge.Text = gridView5.GetRowCellValue(index, "ID_CONGE").ToString();


            this.Close();



        }
    }
}
