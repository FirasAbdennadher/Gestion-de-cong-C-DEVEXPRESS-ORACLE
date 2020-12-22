using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Metier;
using Meiter;
namespace Gestion_Paie_Oracle.Simple_Fenetre
{
    public partial class Employer_datagridview : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static Employer_datagridview edd;

        public Employer_datagridview()
        {
            InitializeComponent();
        }
        #region init
        gestion_type_conge gestion_typeconge = new gestion_type_conge();
        GestionPersonel gestion_personel = new GestionPersonel();
        GestionFonction gestion_fonction = new GestionFonction();
        Gestion_Demande_Class gestion_demande = new Gestion_Demande_Class();
        Gestion_Historique_Cong gestion_historique_emp_conge = new Gestion_Historique_Cong();
        gestion_entreprise gestion_entpreise = new gestion_entreprise();
        Gestion_Validation_Class gestion_validation = new Gestion_Validation_Class();
        gestion_xd gestion_xdd = new gestion_xd();
        string erreur = null;
        Boolean exist = false;
        #endregion


        public void Employer_datagridview_Load(object sender, EventArgs e)
        {
            edd = this;
        }


        
        private void Dgpersonel_Click_1(object sender, EventArgs e)
        {  if (Gestion_Paie_Oracle.Menu.pr.button_Employer_Depart_Responsable_WasClicked == true)

            {
                int index = gridView1.FocusedRowHandle;

                Gestion_Paie_Oracle.Menu.pr.cin_dep.Text = gridView1.GetRowCellValue(index, "CIN").ToString();
                Gestion_Paie_Oracle.Menu.pr.nom_dep.Text = gridView1.GetRowCellValue(index, "NOM").ToString();
                Gestion_Paie_Oracle.Menu.pr.prenom_dep.Text = gridView1.GetRowCellValue(index, "PRENOM").ToString();
                Gestion_Paie_Oracle.Menu.pr.mat_dep.Text = gridView1.GetRowCellValue(index, "MATRICULE").ToString();

                Gestion_Paie_Oracle.Menu.pr.button_Employer_Depart_Responsable_WasClicked = false;
                this.Close();


            }else if (Gestion_Paie_Oracle.Menu.pr.button_Employer_Service_Responsable_WasClicked)
            {
                int index = gridView1.FocusedRowHandle;

                Gestion_Paie_Oracle.Menu.pr.cin_emp_sv.Text = gridView1.GetRowCellValue(index, "CIN").ToString();
                Gestion_Paie_Oracle.Menu.pr.nom_emp_sv.Text = gridView1.GetRowCellValue(index, "NOM").ToString();
                Gestion_Paie_Oracle.Menu.pr.prenom_emp_sv.Text = gridView1.GetRowCellValue(index, "PRENOM").ToString();
                Gestion_Paie_Oracle.Menu.pr.mat_emp_sv.Text = gridView1.GetRowCellValue(index, "MATRICULE").ToString();
                Gestion_Paie_Oracle.Menu.pr.button_Employer_Service_Responsable_WasClicked = false;
                this.Close();

            }
            else  if (Gestion_Paie_Oracle.Menu.pr.button_Employer_WasClicked == true)
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
                Gestion_Paie_Oracle.Menu.pr.arrierconge.Text = hc.Arrier_conge + "";

                Gestion_Paie_Oracle.Menu.pr.droitannecourat.Text = hc.Droit_annner_courant + "";
                Gestion_Paie_Oracle.Menu.pr.prisanne.Text = hc.Pris_anner_courant + "";
                Gestion_Paie_Oracle.Menu.pr.sommehisto.Text = ((Convert.ToDecimal(Gestion_Paie_Oracle.Menu.pr.arrierconge.Text) + Convert.ToDecimal(Gestion_Paie_Oracle.Menu.pr.droitannecourat.Text)) - Convert.ToDecimal(Gestion_Paie_Oracle.Menu.pr.prisanne.Text)).ToString();

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
                Gestion_Paie_Oracle.Menu.pr.button_Employer_WasClicked = false;
                this.Close();
            }
            else if (Gestion_Paie_Oracle.Menu.pr.button_Employer_WasClicked == false)
            {
                int index = gridView1.FocusedRowHandle;
                gridView1.FocusedRowHandle = index;
                gridView1.SelectRow(index);


                Gestion_Paie_Oracle.Menu.pr.remplirDG3(gridView1.GetRowCellValue(index, "MATRICULE").ToString(), Gestion_Paie_Oracle.Menu.pr.historique_dg);
                for (int i = 0; i < Gestion_Paie_Oracle.Menu.pr.historique_dg.Rows.Count - 1; i++)
                {
                    var cell = Gestion_Paie_Oracle.Menu.pr.historique_dg[0, i] = new DataGridViewTextBoxCell();
                    cell.ReadOnly = true;
                }

                Gestion_Paie_Oracle.Menu.pr.historique_dg.BackgroundColor = Gestion_Paie_Oracle.Menu.pr.historique_dg.DefaultCellStyle.BackColor;

               // Gestion_Paie_Oracle.Menu.pr.historique_dg.Columns[0].HeaderText = "Ajouter";
                Gestion_Paie_Oracle.Menu.pr.historique_dg.Columns[1].HeaderText = "Année Congé";
                Gestion_Paie_Oracle.Menu.pr.historique_dg.Columns[0].Width = 20;

                Gestion_Paie_Oracle.Menu.pr.historique_dg.Columns[2].HeaderText = "Droit courante d'année Congé";
                Gestion_Paie_Oracle.Menu.pr.historique_dg.Columns[3].HeaderText = "Report Caclulé";
                Gestion_Paie_Oracle.Menu.pr.historique_dg.Columns[4].HeaderText = "Report Valider";


                Gestion_Paie_Oracle.Menu.pr.historique_dg.ClearSelection();

                #region lorsque click sur une ligne du gridcontrol
                if (gridView1.GetSelectedRows().Count() > 0)
                {


                    #region remplir datagirdview list de  congé accpeter dans fiche personel
                    Gestion_Paie_Oracle.Menu.pr.remplirDG2(gridView1.GetRowCellValue(index, "MATRICULE").ToString(), Gestion_Paie_Oracle.Menu.pr.DgAlldemand);
                    decimal summ = 0;
                    for (int i = 0; i < Gestion_Paie_Oracle.Menu.pr.gridView5.RowCount; i++)
                    {
                        summ += Convert.ToDecimal(Gestion_Paie_Oracle.Menu.pr.gridView5.GetRowCellValue(i, "NOMBREJOUR").ToString());

                        Gestion_Paie_Oracle.Menu.pr.sommenbjour.Text = summ + "";
                    }
                    Gestion_Paie_Oracle.Menu.pr.gridView5.Columns[0].Caption = "Date Demande Congé";
                    Gestion_Paie_Oracle.Menu.pr.gridView5.Columns[1].Caption = "Date Debut Congé";
                    Gestion_Paie_Oracle.Menu.pr.gridView5.Columns[2].Caption = "Date Fin Congé";
                    Gestion_Paie_Oracle.Menu.pr.gridView5.Columns[3].Caption = "Heur Debut Congé";
                    Gestion_Paie_Oracle.Menu.pr.gridView5.Columns[4].Caption = "Heur Fin Congé";
                    Gestion_Paie_Oracle.Menu.pr.gridView5.Columns[5].Caption = "Nombre de jours de congés pris";

                    #endregion

                    #region remplir datagridview historique de chaque anneéé
                    // historique_dg.DataSource = null;

                    gridView1.ClearSelection();
                    #endregion

                    #region le reste du travail quand on click sur une ligne ! 
                    Gestion_Paie_Oracle.Menu.pr.cin.Text = gridView1.GetRowCellValue(index, "CIN").ToString();
                    Gestion_Paie_Oracle.Menu.pr.matriculee.Text = gridView1.GetRowCellValue(index, "MATRICULE").ToString();

                    Gestion_Paie_Oracle.Menu.pr.nom.Text = gridView1.GetRowCellValue(index, "NOM").ToString();
                    Gestion_Paie_Oracle.Menu.pr.prenom.Text = gridView1.GetRowCellValue(index, "PRENOM").ToString();
                    Gestion_Paie_Oracle.Menu.pr.datenais.Text = gridView1.GetRowCellValue(index, "DATENAISSENCE").ToString();
                    Gestion_Paie_Oracle.Menu.pr.emaill.Text = gridView1.GetRowCellValue(index, "EMAIL").ToString();



                    if (gridView1.GetRowCellValue(index, "SEXE").ToString().Equals("Homme"))
                    {
                        Gestion_Paie_Oracle.Menu.pr.homme.Checked = true;
                    }
                    else
                    {
                        Gestion_Paie_Oracle.Menu.pr.femme.Checked = true;
                    }
                    String libellefn = "";

                     //gestion_fonction.chercher_fn3(Convert.ToInt32(gridView1.GetRowCellValue(index, "FONCTION").ToString()), out erreur, out libellefn, out exist);

                    //Gestion_Paie_Oracle.Menu.pr.combofonction.Text = libellefn;


                    gestion_Departement gd = new gestion_Departement();
                    gestion_Service gs = new gestion_Service();

                    String nomdep = "";
                    String nomserv = "";
                    int xx1;
                    gs.chercher_Service3(gridView1.GetRowCellValue(index, "SERVICE").ToString(), out erreur, out nomserv,out xx1, out exist);

                    int ss;
                    String s1;
                    gd.chercher_Departement3(gridView1.GetRowCellValue(index, "DEPARTEMENT").ToString(), out erreur, out nomdep, out ss, out s1,out exist);
                    Gestion_Paie_Oracle.Menu.pr.comb_depar.Text = nomdep;
                    Gestion_Paie_Oracle.Menu.pr.comb_serv.Text = nomserv;


                    if (gridView1.GetRowCellValue(index, "ETAT_CIVIL").ToString().Equals("Marié"))
                    {
                        Gestion_Paie_Oracle.Menu.pr.marie.Checked = true;
                        Gestion_Paie_Oracle.Menu.pr.groupboxEtat.Visible = false;

                    }

                    else
                    {
                        Gestion_Paie_Oracle.Menu.pr.celibataire.Checked = true;
                        Gestion_Paie_Oracle.Menu.pr.groupboxEtat.Visible = true;

                    }



                    Gestion_Paie_Oracle.Menu.pr.adresse.Text = gridView1.GetRowCellValue(index, "ADRESSE").ToString();
                    Gestion_Paie_Oracle.Menu.pr.daterecreutement.Text = gridView1.GetRowCellValue(index, "DATE_RECRUTEMENT").ToString();
                    Gestion_Paie_Oracle.Menu.pr.telephone_societe.Text = gridView1.GetRowCellValue(index, "TELEPHONESOCEITE").ToString();
                    Gestion_Paie_Oracle.Menu.pr.ville.Text = gridView1.GetRowCellValue(index, "VILLE").ToString();
                    Gestion_Paie_Oracle.Menu.pr.telephone_personel.Text = gridView1.GetRowCellValue(index, "TELEPHONEPRIVE").ToString();
                    Gestion_Paie_Oracle.Menu.pr.lieuuxx.Text = gridView1.GetRowCellValue(index, "LIEUNAISSENCE").ToString();
                    Gestion_Paie_Oracle.Menu.pr.login_utilsateur.Text = gridView1.GetRowCellValue(index, "LOGIN").ToString();
                    Gestion_Paie_Oracle.Menu.pr.Password_utlisateur.Text = gridView1.GetRowCellValue(index, "MOTPASS").ToString();

                    /*    if (Gestion_Paie_Oracle.Menu.pr.celibataire.Checked)
                        {
                        }
                        else if (Gestion_Paie_Oracle.Menu.pr.marie.Checked)
                        {
                        }*/
                }
                #endregion



                #region remplir congé anner courante
                HISTORIQUE_CONGE histo;
                string nbjourdroit = "";
                string pris = "";
                string arrrier = "";
                try
                {
        gestion_xdd.Droit_arrier_pris_conge_anner_precedent(DateTime.Now.Year, gridView1.GetRowCellValue(index, "MATRICULE").ToString(), out erreur, out nbjourdroit, out arrrier, out pris, out exist);

                    // MessageBox.Show("f" + arrrier + "" + nbjourdroit + "" + pris);
                    //    gestion_historique_emp_conge.chercher_Historique_conge_emp(gridView1.GetRowCellValue(index, "MATRICULE").ToString(), out erreur, out histo, out exist);

                    Gestion_Paie_Oracle.Menu.pr.arrier_courant_employer.Text = arrrier;//histo.Arrier_conge + "";
                    Gestion_Paie_Oracle.Menu.pr.droit_anner_employe.Text = nbjourdroit;//histo.Droit_annner_courant + "";
                    Gestion_Paie_Oracle.Menu.pr.pris_anner_employe.Text = pris;// histo.Pris_anner_courant + "";
                    Gestion_Paie_Oracle.Menu.pr.somme_hist_employe.Text = ((Convert.ToDecimal(Gestion_Paie_Oracle.Menu.pr.arrier_courant_employer.Text) + Convert.ToDecimal(Gestion_Paie_Oracle.Menu.pr.droit_anner_employe.Text)) - Convert.ToDecimal(Gestion_Paie_Oracle.Menu.pr.pris_anner_employe.Text)).ToString();
                }catch(Exception ee)
                {

                }
                #endregion

                #endregion
            }
           
            Gestion_Paie_Oracle.Menu.pr.BringToFront();

            
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            Listes_Employes lemp = new Listes_Employes();
            lemp.Show();

        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView1.ShowFindPanel();

        }
    }
}