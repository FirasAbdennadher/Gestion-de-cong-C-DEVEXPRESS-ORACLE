using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Metier;
using Meiter;

namespace Gestion_Paie_Oracle
{
    public partial class List_Employer_conge : Form
    {
        public static List_Employer_conge lemplyer;

        public List_Employer_conge()
        {
            InitializeComponent();
        }

        private void List_Employer_conge_Load(object sender, EventArgs e)
        {
            this.eMPLOYETableAdapter.Fill(this.dataSet1.EMPLOYE);

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            int index = gridView1.FocusedRowHandle;

            Gestion_Paie_Oracle.Menu.pr.cin_salaries_demande1.Text = gridView1.GetRowCellValue(index, "MATRICULE").ToString();
            Gestion_Paie_Oracle.Menu.pr.nom_emp_demande.Text = gridView1.GetRowCellValue(index, "NOM").ToString();
            Gestion_Paie_Oracle.Menu.pr.prenom_emp_demand.Text = gridView1.GetRowCellValue(index, "PRENOM").ToString();

            Gestion_Historique_Cong ghc = new Gestion_Historique_Cong();
            HISTORIQUE_CONGE hc;
            String erreur = null;
            Boolean exit = false;
            ghc.chercher_Historique_conge_emp(gridView1.GetRowCellValue(index, "MATRICULE").ToString(), Convert.ToString(DateTime.Now.Year), out erreur, out hc, out exit);

            Gestion_Paie_Oracle.Menu.pr.arrierconge.Text = hc.Arrier_conge+"";
            
            Gestion_Paie_Oracle.Menu.pr.droitannecourat.Text = hc.Droit_annner_courant+"";
            Gestion_Paie_Oracle.Menu.pr.prisanne.Text = hc.Pris_anner_courant+"";
            Gestion_Paie_Oracle.Menu.pr.sommehisto.Text = ((Convert.ToInt32(Gestion_Paie_Oracle.Menu.pr.arrierconge.Text) + Convert.ToInt32(Gestion_Paie_Oracle.Menu.pr.droitannecourat.Text)) - Convert.ToInt32(Gestion_Paie_Oracle.Menu.pr.prisanne.Text)).ToString();

//            MessageBox.Show(hc.Arrier_conge + " " + hc.Anner_conge + " " + hc.Droit_annner_courant + " " + hc.Depasemment);

            //     Gestion_Paie_Oracle.Menu.pr.cin_employer = gridView1.GetRowCellValue(index, "CIN").ToString();
            Gestion_Paie_Oracle.Menu.pr.matriculevisible.Text = gridView1.GetRowCellValue(index, "MATRICULE").ToString();

           /* Gestion_Historique_Cong ghisto = new Gestion_Historique_Cong();
            HISTORIQUE_CONGE historique;
            ghisto.chercher_Historique_conge_emp("where CIN=" + gridView1.GetRowCellValue(index, "CIN"), out erreur, out historique, out exit);

            Gestion_Paie_Oracle.Menu.pr.arrierconge.Text = historique.Arrier_conge + "";
            Gestion_Paie_Oracle.Menu.pr.droitannecourat.Text = historique.Droit_annner_courant + "";
            Gestion_Paie_Oracle.Menu.pr.prisanne.Text = historique.Pris_anner_courant + "";
           */

            this.Close();

        }
    }
}
