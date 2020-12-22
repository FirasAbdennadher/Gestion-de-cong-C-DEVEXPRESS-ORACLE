using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Metier;
using DevExpress.XtraBars.Docking;
using System.Media;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using Oracle.ManagedDataAccess.Client;
using Meiter;
using Microsoft.VisualBasic;
using Acces;
using Gestion_Paie_Oracle.Simple_Fenetre;
using DevExpress.XtraBars;
using System.Net.Mail;
using Gestion_Paie_Oracle.Impression;
using static Meiter.class_fich_demande_conge;
#region Header

namespace Gestion_Paie_Oracle
{
    public partial class Menu : DevExpress.XtraEditors.XtraForm
    {

        public static Menu pr;
        String name_entre;
        public String Role;
        public String ad;
        public Int32 idd = 0;
        public String dep = "";
        public String matricule_emp = "";
        public String sv = "";
        public String nom_employer;
        public String prenom_employer;
        public String telehpone_employer;
        public Menu(String name, String rolee, String admin, Int32 id, String departement, String serviceSS, String mat, String nom_empl, String prenomn, String telehponneee)
        {
            InitializeComponent();
            name_entre = name;
            Role = rolee;
            ad = admin;
            idd = id;
            dep = departement;
            sv = serviceSS;
            nom_employer = nom_empl;
            prenom_employer = prenomn;
            telehpone_employer = telehponneee;
            matricule_emp = mat;
            barStaticItem1.Caption += admin + "";
            barStaticItem2.Caption += id;
            barStaticItem3.Caption += DateTime.Today.ToString("dd-MM-yyyy");

        }

        #region "initialisation"

        string erreur = null;
        Boolean exist = false;
        gestion_type_conge gestion_typeconge = new gestion_type_conge();
        gestion_Fiche_demande gestion_fiche = new gestion_Fiche_demande();
        GestionPersonel gestion_personel = new GestionPersonel();
        GestionFonction gestion_fonction = new GestionFonction();
        Gestion_Demande_Class gestion_demande = new Gestion_Demande_Class();
        Gestion_Historique_Cong gestion_historique_emp_conge = new Gestion_Historique_Cong();
        gestion_entreprise gestion_entpreise = new gestion_entreprise();
        Gestion_Validation_Class gestion_validation = new Gestion_Validation_Class();
        gestion_xd gestion_xdd = new gestion_xd();
        gestion_Departement gestion_department = new gestion_Departement();
        gestion_Service gestion_servie = new gestion_Service();

        #endregion

        #region connectionoforfiltre
        public OracleConnection sqlconnection;
        public OracleCommand sqlcommand;
        String ConnectionString = "Data Source = localhost; Persist Security Info = True; User ID = mariem; Password = mariem;";
        public string Query;
        public DataSet dataset;
        public DataTable datatable;
        public OracleDataAdapter sqladapter;
        #endregion
        private void Menu_Load(object sender, EventArgs e)
        {
            compte_navbar.Visible = false;
            salarie_dockPanel.Close();
            type_dockpanel.Close();
            demand_dp.Close();
            entreprise_dockpanel.Close();
            service_dockpanel.Close();
            stat_dockpanel.Close();
            dep_dockpanel.Close();
            vallidation_dp.Close();
            suivdockpanel.Close();
            bonreprise_dockpanel.Close();
            lettrerejet_dockpanel.Close();
            titreconge_dockpanel.Close();
            pr = this;

            if (Role.Equals("Simple Utilisateur"))
            {
                #region si Simple
                validaiton_navbar.Visible = false;
                titreouvrir.Visible = false;
                ouvrirlettrerejet.Visible = false;
                ouvrir_bonreprirse.Visible = false;


                navBarGroup4.Visible = false;
                entrepri_nav.Visible = false;
                compte_navbar.Visible = true;
                salarie_dockPanel.Show();
                ribbonPageGroup1.Visible = false;
                Personel_class per = null;
                gestion_personel.chercher_Personel(matricule_emp, out erreur, out per, out exist);
                #region ll dem
                cin_salaries_demande1.Text = per.Matricule;
                nom_emp_demande.Text = per.Nom;
                prenom_emp_demand.Text = per.Prenom;
                #endregion
                matriculee.Text = matricule_emp;
                matriculee.ReadOnly = true;
                matriculee.BackColor = System.Drawing.SystemColors.Window;
                nom.Text = per.Nom;
                nom.ReadOnly = true;
                nom.BackColor = System.Drawing.SystemColors.Window;
                prenom.Text = per.Prenom;
                prenom.ReadOnly = true;
                prenom.BackColor = System.Drawing.SystemColors.Window;

                emaill.Text = per.EMAIL + "";
                emaill.ReadOnly = true;
                emaill.BackColor = System.Drawing.SystemColors.Window;

                adresse.Text = per.Adresse;
                adresse.ReadOnly = true;
                adresse.BackColor = System.Drawing.SystemColors.Window;

                daterecreutement.Text = per.daterecrutement + "";
                daterecreutement.Enabled = false;
                daterecreutement.BackColor = System.Drawing.SystemColors.Window;

                telephone_societe.Text = per.telephonesociete;
                telephone_societe.ReadOnly = true;
                telephone_societe.BackColor = System.Drawing.SystemColors.Window;

                ville.Text = per.villes;
                ville.ReadOnly = true;
                ville.BackColor = System.Drawing.SystemColors.Window;

                telephone_personel.Text = per.Telephone_prive;
                telephone_personel.ReadOnly = true;
                telephone_personel.BackColor = System.Drawing.SystemColors.Window;

                lieuuxx.Text = per.lieux;
                lieuuxx.ReadOnly = true;
                lieuuxx.BackColor = System.Drawing.SystemColors.Window;

                login_utilsateur.Text = per.LOGIN;
                login_utilsateur.ReadOnly = true;
                login_utilsateur.BackColor = System.Drawing.SystemColors.Window;

                Password_utlisateur.Text = per.Pass;
                Password_utlisateur.ReadOnly = true;
                Password_utlisateur.BackColor = System.Drawing.SystemColors.Window;


                if (per.etatcivil.Equals("Marié"))
                {
                    marie.Checked = true;

                    //groupboxEtat.Visible = false;
                }

                else
                {
                    celibataire.Checked = true;

                    // Gestion_Paie_Oracle.Menu.pr.groupboxEtat.Visible = true;

                }

                cin.Text = per.cin;
                cin.ReadOnly = true;
                cin.BackColor = System.Drawing.SystemColors.Window;

                datenais.Text = per.datenais + "";
                datenais.Enabled = false;
                adresse.BackColor = System.Drawing.SystemColors.Window;



                if (per.sexxe.Equals("Homme"))
                {
                    homme.Checked = true;

                }
                else
                {
                    femme.Checked = true;

                }


                #endregion
            }
            else if (Role.Equals("Chef Service"))
            {
                navBarGroup4.Visible = false;
                grindcontrol_liste.Visibility = BarItemVisibility.Never;
                salarie_navbar.Visible = false;
                type_conge_bar.Visible = false;
                navBarGroup2.Visible = false;
                navBarGroup1.Visible = false;



            }
            else if (Role.Equals("Chef Departement"))
            {
                navBarGroup4.Visible = false;
                grindcontrol_liste.Visibility = BarItemVisibility.Never;
                salarie_navbar.Visible = false;
                type_conge_bar.Visible = false;
                navBarGroup2.Visible = false;
                navBarGroup1.Visible = false;

            }
            else
            {


                remplirDG3("", historique_dg);//tao naralha 7all !!


                List<Departement_Class> lisst = new List<Departement_Class>();
                String dbb = "";
                gestion_department.chercher_ListeDepartement("", out erreur, out lisst, out dbb, out exist);

                foreach (Departement_Class x in lisst)
                {
                    // MessageBox.Show(dbb);
                    comb_depar.Items.Add(x.DESG_Dep + "");
                }



            }





        }


        #endregion
        public void remplirDG(String Table, String critere, DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select * from " + Table + critere; ;
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }


        #region Entreprise Dock
        private void entrepr_dockmager_ActivePanelChanged(object sender, ActivePanelChangedEventArgs e)
        {
            entreprise_class en = new entreprise_class();

            List<entreprise_class> lentre;
            gestion_entpreise.chercher_entreprise(" id_ent=" + idd, out erreur, out lentre, out exist);
            foreach (entreprise_class x in lentre)
            {
                nom_entrepreise.Text = x.designiation_ent;
                adr_entrepreise.Text = x.adresse;
                ncnss_entrepreise.Text = x.cnsss + "";
                email_entrepreise.Text = x.email_entreprise;
                fax_entrepreise.Text = x.fax_entreprise;
                tele_entrepreise.Text = x.telephone_entreprise;
                datecrea_entrepreise.Text = x.DCreat + "";
                ville_entrepreise.Text = x.Ville;
                mat_entrepreise.Text = x.matricule_fiscale;
                Nombre_heur_parjour.Text = x.nbjoursmois + "";
                nombre_jour_par_mois.Text = x.nbheurjours + "";
                cp_entrepreise.Text = x.CodeCP + "";
                repot1.Text = x.Repot1 + "";
                repot2.Text = x.Repot2 + "";
            }
        }

        private void modifier_entre_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region button modifier


            if (nom_entrepreise.Text == "")
            {
                MessageBox.Show("Nom obligatoire");

            }
            else if (Nombre_heur_parjour.Text == "")
            {
                MessageBox.Show(" Nombre Par Heurs   est obligatoire");

            }

            else if (nombre_jour_par_mois.Text == "")
            {
                MessageBox.Show("Nombre par Mois   est obligatoire");

            }

            else if (mat_entrepreise.Text == "")
            {
                MessageBox.Show(" Matricule est obligatoire");

            }
            else if (fax_entrepreise.Text == "")
            {
                MessageBox.Show("Fax  est obligatoire");

            }
            else if (tele_entrepreise.Text == "")
            {
                MessageBox.Show(" Telephone est obligatoire");

            }
            else if (email_entrepreise.Text == "")
            {
                MessageBox.Show(" Email est obligatoire");

            }
            else if (datecrea_entrepreise.Text == "")
            {
                MessageBox.Show("Date Creation  est obligatoire");

            }
            else if (ville_entrepreise.Text == "")
            {
                MessageBox.Show(" Ville  est obligatoire");

            }
            else if (cp_entrepreise.Text == "")
            {
                MessageBox.Show(" Code Postal est obligatoire");

            }
            else if (repot1.Text == "")
            {
                MessageBox.Show(" Jour repot 1 st obligatoire");

            }
            else if (repot2.Text == "")
            {
                MessageBox.Show(" Jour repot 2 est obligatoire");

            }
            else
            {

                // entreprise_class entre = new entreprise_class(1, nom_entrepreise.Text, adr_entrepreise.Text, email_entrepreise.Text, tele_entrepreise.Text, fax_entrepreise.Text, mat_entrepreise.Text, Convert.ToInt32(Nombre_heur_parjour.Text), Convert.ToInt32(nombre_jour_par_mois.Text), Convert.ToInt32(ncnss_entrepreise.Text), Convert.ToDateTime(datecrea_entrepreise.Value.ToString("dd-MM-yyyy")), ville_entrepreise.Text, Convert.ToInt32(cp_entrepreise.Text), repot1.Text, repot2.Text);
                entreprise_class entre = new entreprise_class(1, nom_entrepreise.Text, adr_entrepreise.Text, email_entrepreise.Text, tele_entrepreise.Text, fax_entrepreise.Text, mat_entrepreise.Text, Convert.ToInt32(Nombre_heur_parjour.Text), Convert.ToInt32(nombre_jour_par_mois.Text), Convert.ToInt32(ncnss_entrepreise.Text), datecrea_entrepreise.Value.ToString("dd-MM-yyyy"), ville_entrepreise.Text, Convert.ToInt32(cp_entrepreise.Text), repot1.Text, repot2.Text);

                gestion_entpreise.modifier_En(entre, out erreur);

                if (erreur == null)
                {


                    MessageBox.Show("Modification Avec Succès ! ");
                }
                else
                {

                    MessageBox.Show(erreur);

                }

            }

            #endregion
        }


        private void entrepri_nav_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            entreprise_dockpanel.Show();
        }

        #endregion

        /************************************************************************/
        //Fin Entreprise//
        /************************************************************************/
        #region Personel Dock
        private void datenais_ValueChanged(object sender, EventArgs e)
        {
            #region calcul nbjour
            string strDate = DateTime.Today.ToString("dd-MM-yyyy");
            string[] arrDate = strDate.Split('-');
            string year = arrDate[2].ToString();
            string datenaiss = datenais.Value.ToString("yyyy-MM-dd");
            age.Visible = true;
            age_label.Visible = true;
            age.Text = (Convert.ToInt32(year) - Convert.ToInt32(datenaiss.Substring(0, 4).ToString())).ToString();
            #endregion
        }

        public void remplirDG3(String critere, DataGridView dg)
        {
            #region remplir datagridview tableau historique dans fiche personel 
            sqlconnection = new OracleConnection(ConnectionString);
            String Query = "select HISTORIQUE_CONGE.ANNER_CONGE as Anner, HISTORIQUE_CONGE.DROIT_ANNER_COURANT as Droit_Conge, HISTORIQUE_CONGE.ARRIERE_CONGE as Report_Calcule, HISTORIQUE_CONGE.ARRIERE_CONGE as Report_Valide from  HISTORIQUE_CONGE  where  HISTORIQUE_CONGE.MATRICULE='" + critere + "' ORDER BY 1 ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }


        private void fermer_personel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            salarie_dockPanel.Close();
        }
        public void cleartextnox()
        {
            #region clear
            emaill.Text = "";
            chef_dep.Checked = false;
            age.Visible = false;
            agepoint.Visible = false;
            age_label.Visible = false;
            DgAlldemand.DataSource = null;
            arrier_courant_employer.Text = "";
            droit_anner_employe.Text = "";
            pris_anner_employe.Text = "";
            somme_hist_employe.Text = "";
            historique_dg.DataSource = null;
            cin.Text = "";
            nom.Text = "";
            prenom.Text = "";
            homme.Checked = false;
            femme.Checked = false;
            datenais.Text = "";
            daterecreutement.Text = "";
            adresse.Text = "";
            telephone_societe.Text = "";
            telephone_personel.Text = "";
            matriculee.Text = "";
            age.Visible = false;
            age_label.Visible = false;
            lieuuxx.Text = "";
            ville.Text = "";
            marie.Checked = false;
            celibataire.Checked = false;
            datenais.Value = DateTime.Today;
            daterecreutement.Value = DateTime.Today;

            agepoint.Visible = false;

            comb_serv.Text = "";
            comb_depar.Text = "";

            #endregion
        }

        private void viderchamps_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cleartextnox();
        }


        #region Gérer Employer ( Croud)
        public bool IsValid(string emailaddress)
        {
            #region valdiation email
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
            #endregion
        }

        private void ajouter_salarie_item_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region Ajouter_Personal

            #region les test
            string datenaiss = datenais.Value.ToString("yyyy-MM-dd");
            string daterecu = daterecreutement.Value.ToString("yyyy-MM-dd");


            if (matriculee.Text.Trim() == "")
            {
                XtraMessageBox.Show("Matricule est obligatoire !");
                cin.Focus();
            }
            else if (cin.Text.Trim() == "")
            {
                XtraMessageBox.Show("Cin est obligatoire!");
                cin.Focus();
            }
            else if (nom.Text.Trim() == "")
            {
                XtraMessageBox.Show("Nom est obligatoire");
                nom.Focus();
            }



            else if (prenom.Text.Trim() == "")
            {
                XtraMessageBox.Show("Prenom est obligatoire");
                prenom.Focus();
            }

            else if (comb_serv.Text == "")
            {
                XtraMessageBox.Show(" Service est obligatoire");
                comb_serv.Focus();
            }
            else if (comb_depar.Text == "")
            {
                XtraMessageBox.Show(" Département est obligatoire");
                comb_depar.Focus();
            }

            else if (telephone_personel.Text == "")
            {
                XtraMessageBox.Show(" Téléphone Personel est obligatoire");
                telephone_personel.Focus();
            }
            else if (telephone_societe.Text == "")
            {
                XtraMessageBox.Show("Telephone Sociéte est obligatoire");
                telephone_societe.Focus();
            }
            else if (adresse.Text == "")
            {
                XtraMessageBox.Show("Adresse st obligatoire");
                adresse.Focus();
            }
            else if (ville.Text == "")
            {
                XtraMessageBox.Show("Ville st obligatoire");
                ville.Focus();
            }

            else if (homme.Checked == false && femme.Checked == false)
            {
                XtraMessageBox.Show("Tu doit choisir Sexe !");
            }
            else if (celibataire.Checked == false && marie.Checked == false)
            {
                XtraMessageBox.Show("Tu doit choisir Etat civil !");
            }


            else if (datenais.Text.Length == 0)
            {
                XtraMessageBox.Show("Date Naissance  est obligatoire");

            }

            else if (daterecreutement.Text.Length == 0)
            {
                XtraMessageBox.Show("Date Recreutement est obligatoire");

            }
            else if (lieuuxx.Text == "")
            {
                MessageBox.Show("Lieu est obligatoire");
                lieuuxx.Focus();
            }




            else if (Convert.ToInt32(DateTime.Now.Year.ToString()) < Convert.ToInt32(datenaiss.Substring(0, 4).ToString()))
            {
                MessageBox.Show("Date de naissence doit être inférieur " + DateTime.Now.ToString());

            }
            else if (IsValid(emaill.Text) == false)
            {
                MessageBox.Show("Email invalide");
            }

            #endregion

            else
            {
                String sexevalue = "";
                if (homme.Checked == true) { sexevalue = "Homme"; }
                else { sexevalue = "Femme"; }
                String etatcivil = "";
                if (marie.Checked) { etatcivil = "Marié"; }
                else
                {
                    etatcivil = "Celibataire";
                }

                String chefhi = "";
                if (comb_depar.Text != "" && comb_serv.Text == "" && chef_dep.Checked)
                {
                    chefhi = "Oui";

                }
                else if (comb_depar.Text != "" && comb_serv.Text != "" && chef_dep.Checked)
                {
                    chefhi = "Oui";

                }
                else if (comb_depar.Text != "" && comb_serv.Text != "" && chef_dep.Checked == false)
                {
                    chefhi = "Non";
                }
                Boolean trouve = false;
                String codeservices = "";
                String codesepart = "";
                String chef = "Simple Utilisateur";
                if (chef_dep.Checked)
                {
                    chef = "Chef Departement";
                }
                else if (chef_sv.Checked)
                {
                    chef = "Chef Service";
                }

                gestion_servie.chercher_Service_retour_code(comb_serv.Text, out erreur, out codeservices, out exist);
                gestion_department.chercher_Departement_retour_code(comb_depar.Text, out erreur, out codesepart, out exist);

                Personel_class per = new Personel_class();
                gestion_personel.chercher_Personel(matriculee.Text, out erreur, out per, out exist);

                if (per.Matricule.Equals(matriculee.Text))
                {
                    trouve = true;
                }

                if (trouve == false)
                {
                    Personel_class pers = new Personel_class();
                    try
                    {
                        String codde = "";
                        pers = new Personel_class(matriculee.Text, cin.Text, nom.Text, prenom.Text, Convert.ToDateTime(datenais.Value.ToShortDateString()), lieuuxx.Text, sexevalue, chef, etatcivil, adresse.Text, Convert.ToDateTime(daterecreutement.Value.ToShortDateString()), telephone_societe.Text, telephone_personel.Text, ville.Text, 1, Convert.ToString(codesepart), Convert.ToString(codeservices), emaill.Text, login_utilsateur.Text, Password_utlisateur.Text);
                        gestion_department.chercher_Departement_retour_code(comb_depar.Text, out erreur, out codde, out exist);
                        String nn = ""; int ss = 0; String rsp = "";
                        gestion_department.chercher_Departement3(codde, out erreur, out nn, out ss, out rsp, out exist);
                        Departement_Class dep = new Departement_Class(codde, comb_depar.Text, rsp, ss);
                        gestion_department.modifier_DEPARTEMENT(dep, out erreur);
                        if (!(erreur == null))

                        {
                            MessageBox.Show("Erreur Depar" + erreur);
                        }
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee + "");
                    }
                   
                    gestion_personel.ajouter_Per(pers, out erreur);
                    if (erreur == null)
                    {
                        try
                        {
                            Employer_datagridview.edd.Dgpersonel.DataSource = null;
                            Employer_datagridview.edd.Dgpersonel.DataSource = gestion_personel.GetPersonal();
                        }catch(Exception e12)
                        {

                        }
                        //  remplirDG("employe", Dgpersonel);
                        XtraMessageBox.Show("Salarié(e)   " + matriculee.Text + "  ajouté Avec Succés");

                        cleartextnox();
                    }
                    else
                    {
                        MessageBox.Show(erreur);
                    }
                }
                else
                {
                    MessageBox.Show("Employe " + matriculee.Text + " Existe !!");
                }
            }

            #endregion
        }

        private void modifier_personel_item_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                #region button modifier

                #region test
                int index = Employer_datagridview.edd.gridView1.FocusedRowHandle;


                if (matriculee.Text == "")
                {
                    MessageBox.Show(" Matricule est obligatoire");
                    matriculee.Focus();
                }
                else if (cin.Text.Trim() == "")
                {
                    MessageBox.Show("CIN est obligatoire");
                    cin.Focus();
                }
                else if (prenom.Text.Trim() == "")
                {
                    MessageBox.Show("Prenom est obligatoire");
                    prenom.Focus();
                }
                else if (nom.Text.Trim() == "")
                {
                    MessageBox.Show("Nom est obligatoire");
                    prenom.Focus();
                }


                else if (comb_depar.Text == "")
                {
                    MessageBox.Show(" Department est obligatoire");
                    comb_depar.Focus();
                }
                else if (comb_serv.Text == "")
                {
                    MessageBox.Show(" Service est obligatoire");
                    comb_serv.Focus();
                }

                else if (telephone_personel.Text == "")
                {
                    MessageBox.Show("Telephone Personel est obligatoire");
                    telephone_personel.Focus();
                }
                else if (telephone_societe.Text == "")
                {
                    MessageBox.Show("Telephone est obligatoire");
                    telephone_societe.Focus();
                }
                else if (adresse.Text == "")
                {
                    MessageBox.Show("Adresse st obligatoire");
                    adresse.Focus();
                }
                else if (ville.Text == "")
                {
                    MessageBox.Show("Ville st obligatoire");
                    ville.Focus();
                }

                else if (homme.Checked == false && femme.Checked == false)
                {
                    MessageBox.Show("Tu doit choisir Sexe !");
                }
                else if (celibataire.Checked == false && marie.Checked == false)
                {
                    MessageBox.Show("Tu doit choisir Etat civil !");
                }
                else if (datenais.Text.Length == 0)
                {
                    MessageBox.Show("Date Naissance  est obligatoire");

                }

                else if (daterecreutement.Text.Length == 0)
                {
                    MessageBox.Show("Date Recreutement est obligatoire");

                }
                else if (lieuuxx.Text == "")
                {
                    MessageBox.Show("Lieu est obligatoire");
                    lieuuxx.Focus();
                }



                #endregion
                else
                {

                    String sexevalue = "";
                    if (homme.Checked == true) { sexevalue = "Homme"; }
                    else { sexevalue = "Femme"; }
                    String etatcivil = "";
                    if (marie.Checked) { etatcivil = "Marié"; }
                    else
                    {
                        etatcivil = "Celibataire";
                    }
                    string datenaiss = datenais.Value.ToString("yyyy-MM-dd");
                    string daterecu = daterecreutement.Value.ToString("yyyy-MM-dd");
                    String chef = "Simple Utilisateur";
                    if (chef_dep.Checked)
                    {
                        chef = "Chef Departement";
                    }
                    else if (chef_sv.Checked)
                    {
                        chef = "Chef Service";
                    }


                    String chefhi = "";
                    if (comb_depar.Text != "" && comb_serv.Text == "" && chef_dep.Checked)
                    {
                        chefhi = "Oui";

                    }
                    else if (comb_depar.Text != "" && comb_serv.Text != "" && chef_dep.Checked)
                    {
                        chefhi = "Oui";

                    }
                    else if (comb_depar.Text != "" && comb_serv.Text != "" && chef_dep.Checked == false)
                    {
                        chefhi = "Non";
                    }


                    Boolean trouve = false;
                    String codeservices = "";
                    String codesepart = "";
                    gestion_servie.chercher_Service_retour_code(comb_serv.Text, out erreur, out codeservices, out exist);
                    gestion_department.chercher_Departement_retour_code(comb_depar.Text, out erreur, out codesepart, out exist);

                    Personel_class pers = new Personel_class(matriculee.Text, cin.Text, nom.Text, prenom.Text, Convert.ToDateTime(datenais.Value.ToShortDateString()), lieuuxx.Text, sexevalue, chef, etatcivil, adresse.Text, Convert.ToDateTime(daterecreutement.Value.ToShortDateString()), telephone_societe.Text, telephone_personel.Text, ville.Text, 1, Convert.ToString(codesepart), Convert.ToString(codeservices), emaill.Text, login_utilsateur.Text, Password_utlisateur.Text);

                    gestion_personel.modifier_Personel(pers, out erreur);

                    if (erreur == null)
                    {
                        Employer_datagridview.edd.gridView1.Columns.Clear();

                        Employer_datagridview.edd.Dgpersonel.DataSource = null;

                        remplirDG("employe", "", Employer_datagridview.edd.Dgpersonel);
                        //Dgpersonel.DataSource = gpersonel.GetPersonal();
                        #region hide colum
                        Employer_datagridview.edd.gridView1.Columns[0].Visible = true;
                        Employer_datagridview.edd.gridView1.Columns[1].Visible = true;
                        Employer_datagridview.edd.gridView1.Columns[2].Visible = true;
                        Employer_datagridview.edd.gridView1.Columns[3].Visible = true;
                        Employer_datagridview.edd.gridView1.Columns[4].Visible = true;
                        Employer_datagridview.edd.gridView1.Columns[5].Visible = false;
                        Employer_datagridview.edd.gridView1.Columns[6].Visible = true;
                        Employer_datagridview.edd.gridView1.Columns[7].Visible = true;
                        Employer_datagridview.edd.gridView1.Columns[8].Visible = false;
                        Employer_datagridview.edd.gridView1.Columns[9].Visible = false;
                        Employer_datagridview.edd.gridView1.Columns[10].Visible = false;
                        Employer_datagridview.edd.gridView1.Columns[11].Visible = true;
                        Employer_datagridview.edd.gridView1.Columns[12].Visible = true;
                        Employer_datagridview.edd.gridView1.Columns[13].Visible = false;
                        Employer_datagridview.edd.gridView1.Columns[14].Visible = false;
                        Employer_datagridview.edd.gridView1.Columns[15].Visible = false;
                        Employer_datagridview.edd.gridView1.Columns[16].Visible = false;

                        #endregion
                        datatable.AcceptChanges();

                        MessageBox.Show("Modification Avec Succès ! ");
                        cleartextnox();

                    }
                    else
                    {

                        MessageBox.Show(erreur);

                    }

                }
                #endregion
            }
            catch (Exception ezr)
            {
                MessageBox.Show("aucune modification");
            }
        }

        private void supprimer_salarie_item_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                #region supprimer 
                int index = Employer_datagridview.edd.gridView1.FocusedRowHandle;

                String sexevalue = "";
                if (homme.Checked == true) { sexevalue = "Homme"; }
                else { sexevalue = "Femme"; }
                String etatcivil = "";
                if (marie.Checked) { etatcivil = "Marié"; }
                else
                {
                    etatcivil = "Celibataire";
                }
                string datenaiss = datenais.Value.ToString("yyyy-MM-dd");
                string daterecu = daterecreutement.Value.ToString("yyyy-MM-dd");
                int nb_enfantt = 0;

                String chefhi = "";
                if (comb_depar.Text != "" && comb_serv.Text == "" && chef_dep.Checked)
                {
                    chefhi = "Oui";

                }
                else if (comb_depar.Text != "" && comb_serv.Text != "" && chef_dep.Checked)
                {
                    chefhi = "Oui";

                }
                else if (comb_depar.Text != "" && comb_serv.Text != "" && chef_dep.Checked == false)
                {
                    chefhi = "Non";
                }

                String chef = "Simple Utilisateur";
                if (chef_dep.Checked)
                {
                    chef = "Chef Departement";
                }
                else if (chef_sv.Checked)
                {
                    chef = "Chef Service";
                }

                Boolean trouve = false;
                String codeservices = "";
                String codesepart = "";
                gestion_servie.chercher_Service_retour_code(comb_serv.Text, out erreur, out codeservices, out exist);
                gestion_department.chercher_Departement_retour_code(comb_depar.Text, out erreur, out codesepart, out exist);

                Personel_class pers = new Personel_class(matriculee.Text, cin.Text, nom.Text, prenom.Text, Convert.ToDateTime(datenais.Value.ToShortDateString()), lieuuxx.Text, sexevalue, chef, etatcivil, adresse.Text, Convert.ToDateTime(daterecreutement.Value.ToShortDateString()), telephone_societe.Text, telephone_personel.Text, ville.Text, 1, Convert.ToString(codesepart), Convert.ToString(codeservices), emaill.Text, login_utilsateur.Text, Password_utlisateur.Text);



                gestion_personel.supprimer_Employer(pers, out erreur);
                if (erreur == null)
                {

                    Employer_datagridview.edd.gridView1.Columns.Clear();

                    Employer_datagridview.edd.Dgpersonel.DataSource = null;

                    remplirDG("employe", "", Employer_datagridview.edd.Dgpersonel);
                    //Dgpersonel.DataSource = gpersonel.GetPersonal();
                    #region hide colum
                    Employer_datagridview.edd.gridView1.Columns[0].Visible = true;
                    Employer_datagridview.edd.gridView1.Columns[1].Visible = true;
                    Employer_datagridview.edd.gridView1.Columns[2].Visible = true;
                    Employer_datagridview.edd.gridView1.Columns[3].Visible = true;
                    Employer_datagridview.edd.gridView1.Columns[4].Visible = true;
                    Employer_datagridview.edd.gridView1.Columns[5].Visible = false;
                    Employer_datagridview.edd.gridView1.Columns[6].Visible = true;
                    Employer_datagridview.edd.gridView1.Columns[7].Visible = true;
                    Employer_datagridview.edd.gridView1.Columns[8].Visible = false;
                    Employer_datagridview.edd.gridView1.Columns[9].Visible = false;
                    Employer_datagridview.edd.gridView1.Columns[10].Visible = false;
                    Employer_datagridview.edd.gridView1.Columns[11].Visible = true;
                    Employer_datagridview.edd.gridView1.Columns[12].Visible = true;
                    Employer_datagridview.edd.gridView1.Columns[13].Visible = false;
                    Employer_datagridview.edd.gridView1.Columns[14].Visible = false;
                    Employer_datagridview.edd.gridView1.Columns[15].Visible = false;
                    Employer_datagridview.edd.gridView1.Columns[16].Visible = false;

                    #endregion
                    datatable.AcceptChanges();

                    cleartextnox();
                    XtraMessageBox.Show("suppression avec succès");

                }
                else
                {
                    XtraMessageBox.Show("suppression avec succès");
                }




                #endregion
            }
            catch (Exception qdsd)
            {
                MessageBox.Show("Aucune Modification");
            }
        }

        #endregion

        private void salarie_navbar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            salarie_dockPanel.Show();
        }

        private void changeretatcivil_Click_1(object sender, EventArgs e)
        {
            #region changer etat civi
            if (matriculee.Text != "")
            {
                String etatciv = "Marié";

                groupboxEtat.Visible = false;
                marie.Checked = true;
                gestion_personel.modifier_Etat_Person(matriculee.Text, etatciv, out erreur);
                if (erreur == null)
                {

                    // dgpersonel.Rows[index].Cells[7].Value = etatciv;
                    // gridView1.SetRowCellValue(index, gridView1.Columns["ETAT_CIVIL"], etatciv);
                    //     nb_enfantlabel.Visible = true;
                    //   nombre_enfant.Visible = true;
                    MessageBox.Show("Bon mariage !");

                }



            }
            else { MessageBox.Show("Matricule Vide !!!!"); }

            #endregion
        }


        private void celibataire_CheckedChanged(object sender, EventArgs e)
        {
            groupe_enfant.Visible = false;
        }

        private void marie_CheckedChanged(object sender, EventArgs e)
        {
            groupe_enfant.Visible = true;
            #region marrié
            if (marie.Checked)
            {
                //   nombre_enfant.Visible = true;
                // nb_enfantlabel.Visible = true;
            }
            #endregion
        }


        #endregion

        /************************************************************************/
        //Fin Employerrr//
        /************************************************************************/

        #region Congé
        private void type_conge_bar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            type_dockpanel.Show();
        }

        public void remplirDG1(String id_cong, DevExpress.XtraGrid.GridControl dg)
        {
            #region Remplir datagridview liste des demande dans fiche employer 
            sqlconnection = new OracleConnection(ConnectionString);
            String Query = "select dc.DATE_DEMANDE,vc.DATE_DEBUT_VALIDER,vc.DATE_FIN_VALIDER,vc.HEUR_DEBUT_VALIDER,vc.HEUR_FIN_VALIDER, from  DEMANDE_CONGE dc , VALIDATION_CONGE vc where vc.ID_DEMANDE_CONGE=dc.ID_DEMANDE_CONGE";

            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        public void remplirDG2(String id_cong, DevExpress.XtraGrid.GridControl dg)
        {
            #region remplisage grid list de demande congé dans ficher emp
            sqlconnection = new OracleConnection(ConnectionString);
            String Query = "select  DEMANDE_CONGE.DATE_DEMANDE, DEMANDE_CONGE.DATE_DEBUT_CONGE, DEMANDE_CONGE.DATE_FIN_CONGE, DEMANDE_CONGE.HEUR_DEBUT, DEMANDE_CONGE.HEUR_FIN, DEMANDE_CONGE.NOMBREJOUR, DEMANDE_CONGE.STATUS  from  DEMANDE_CONGE  where  DEMANDE_CONGE.MATRICULE = '" + id_cong + "' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        public void remplirDG0(String id_cong, DevExpress.XtraGrid.GridControl dg)
        {
            #region Remplir Conge
            sqlconnection = new OracleConnection(ConnectionString);
            String Query = "select e.MATRICULE,e.NOM,e.PRENOM,dc.ID_CONGE,dc.ID_DEMANDE_CONGE from  EMPLOYE e , DEMANDE_CONGE dc where e.MATRICULE=dc.MATRICULE and dc.STATUS='Non Encore Traité par GRH' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        private void coge_dm_ActivePanelChanged(object sender, ActivePanelChangedEventArgs e)
        {

            remplirDG0("", Dgvalidation);
        }

        private void DgTypeconge_Click_1(object sender, EventArgs e)
        {
            int index = Type_Conge_datagridview.datagridtypeconge.gridView2.FocusedRowHandle;
            #region lorsque click on type conge
            code_type_conge.Text = Type_Conge_datagridview.datagridtypeconge.gridView2.GetRowCellValue(index, "ID_CONGE").ToString();
            libelle_type_conge.Text = Type_Conge_datagridview.datagridtypeconge.gridView2.GetRowCellValue(index, "DESGIN_CONGE").ToString();
            combobox_congepye.Text = Type_Conge_datagridview.datagridtypeconge.gridView2.GetRowCellValue(index, "CONGE_PAYE").ToString();
            comboBoxmiseajour_conge.Text = Type_Conge_datagridview.datagridtypeconge.gridView2.GetRowCellValue(index, "MAJ_CONGE_PAY").ToString();
            comboboxjourouvrable.Text = Type_Conge_datagridview.datagridtypeconge.gridView2.GetRowCellValue(index, "JOUR_OUVRABLE").ToString();
            speci.Text = Type_Conge_datagridview.datagridtypeconge.gridView2.GetRowCellValue(index, "SPECIFICATION").ToString();
            #endregion
        }

        #region gerér conge (croud)

        private void ajouter_typeconge_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region ajoutertypcong
            String spec = "";
            if (code_type_conge.Text == "")
            {
                MessageBox.Show("Code obligatoire");
            }
            else if (libelle_type_conge.Text == "")
            {
                MessageBox.Show("Libellé obligatoire");

            }
            else
            {
                String congepaye = "Non";
                String miseajourconge = "Non";
                String jourouvrable = "Non";

                if (combobox_congepye.Checked)
                {
                    congepaye = "Oui";
                }

                if (comboBoxmiseajour_conge.Checked)
                {
                    miseajourconge = "Oui";
                }
                if (comboboxjourouvrable.Checked)
                {
                    jourouvrable = "";
                }

                if (speci.Text == "")
                {
                    spec = "Aucune Specification ! ";
                }
                else
                {
                    spec = speci.Text;
                }


                Boolean trouveType = false;
                int index = Type_Conge_datagridview.datagridtypeconge.gridView2.FocusedRowHandle;

                for (int i = 0; i <= Type_Conge_datagridview.datagridtypeconge.gridView2.RowCount - 1; i++)

                {
                    if (Type_Conge_datagridview.datagridtypeconge.gridView2.GetRowCellValue(i, "ID_CONGE").ToString().Equals(code_type_conge.Text))
                    {
                        trouveType = true;
                    }
                }

                if (trouveType == false)
                {
                    type_conge type = new type_conge(code_type_conge.Text, libelle_type_conge.Text, congepaye, jourouvrable, miseajourconge, spec);


                    gestion_typeconge.ajouter_type_conge(type, out erreur);
                    if (erreur == null)
                    {
                        Type_Conge_datagridview.datagridtypeconge.DgTypeconge.DataSource = null;
                        Type_Conge_datagridview.datagridtypeconge.DgTypeconge.DataSource = gestion_typeconge.GetTypeConge();
                        XtraMessageBox.Show("Type Conge   " + code_type_conge.Text + "  ajouté Avec Succés");

                    }
                    else XtraMessageBox.Show("Erreur Dans Type conge " + erreur);

                }
                else
                {
                    XtraMessageBox.Show("Type Congé exist Déjà");

                }
            }

            #endregion
        }

        private void modifier_typeconge_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region button modifier connge
            String spec = speci.Text;
            if (code_type_conge.Text == "")
            {
                MessageBox.Show("Code obligatoire");
            }
            else if (libelle_type_conge.Text == "")
            {
                MessageBox.Show("Libellé obligatoire");

            }
            else
            {
                String congepaye = "Non";
                String miseajourconge = "Non";
                String jourouvrable = "Non";

                if (combobox_congepye.Checked)
                {
                    congepaye = "Oui";
                }


                if (comboBoxmiseajour_conge.Checked)
                {
                    miseajourconge = "Oui";
                }
                if (comboboxjourouvrable.Checked)
                {
                    jourouvrable = "Oui";
                }



                if (speci.Text == "")
                {
                    spec = "Aucune Specification ! ";
                }
                else
                {
                    spec = speci.Text;
                }

                type_conge type = new type_conge(code_type_conge.Text, libelle_type_conge.Text, congepaye, jourouvrable, miseajourconge, spec);

                gestion_typeconge.modifier_type_conge(type, out erreur);
                if (erreur == null)
                {
                    Type_Conge_datagridview.datagridtypeconge.DgTypeconge.DataSource = null;
                    Type_Conge_datagridview.datagridtypeconge.DgTypeconge.DataSource = gestion_typeconge.GetTypeConge();
                    XtraMessageBox.Show("Modification Avec Succés");

                }
                else XtraMessageBox.Show("Erreur Dans Type conge " + erreur);


            }

            #endregion
        }

        private void supprimer_typeconge_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region supprimer 
            int index = Type_Conge_datagridview.datagridtypeconge.gridView2.FocusedRowHandle;
            String spec = speci.Text;

            if (code_type_conge.Text == "")
            {
                MessageBox.Show("Code obligatoire");
            }
            else if (libelle_type_conge.Text == "")
            {
                MessageBox.Show("Libellé obligatoire");

            }

            else
            {
                String congepaye = "Non";
                String miseajourconge = "Non";
                String jourouvrable = "Non";

                if (combobox_congepye.Checked)
                {
                    congepaye = "Oui";
                }

                if (comboBoxmiseajour_conge.Checked)
                {
                    miseajourconge = "Oui";
                }
                if (comboboxjourouvrable.Checked)
                {
                    jourouvrable = "";
                }

                if (speci.Text == "")
                {
                    spec = "Aucune Specification ! ";
                }
                else
                {
                    spec = speci.Text;
                }

                type_conge type = new type_conge(code_type_conge.Text, libelle_type_conge.Text, congepaye, jourouvrable, miseajourconge, spec);


                gestion_typeconge.supprimer_type_conge(type, out erreur);
                if (erreur == null)
                {
                    XtraMessageBox.Show("suppression avec succès");
                }
                else
                {
                    XtraMessageBox.Show("suppression avec succès");
                }
                Type_Conge_datagridview.datagridtypeconge.DgTypeconge.DataSource = null;
                Type_Conge_datagridview.datagridtypeconge.DgTypeconge.DataSource = gestion_typeconge.GetTypeConge();
            }

            #endregion}
        }
        #endregion


        public String id_conger_pourenregiter = "";

        private void arrier_courant_employer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                somme_hist_employe.Text = ((Convert.ToInt32(arrier_courant_employer.Text) + Convert.ToInt32(droit_anner_employe.Text)) - Convert.ToInt32(pris_anner_employe.Text)).ToString();
            }
            catch
            {
                somme_hist_employe.Text = "";
            }
        }

        private void droit_anner_employe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                somme_hist_employe.Text = ((Convert.ToInt32(arrier_courant_employer.Text) + Convert.ToInt32(droit_anner_employe.Text)) - Convert.ToInt32(pris_anner_employe.Text)).ToString();
            }
            catch
            {
                somme_hist_employe.Text = "";
            }
        }

        private void pris_anner_employe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                somme_hist_employe.Text = ((Convert.ToInt32(arrier_courant_employer.Text) + Convert.ToInt32(droit_anner_employe.Text)) - Convert.ToInt32(pris_anner_employe.Text)).ToString();
            }
            catch
            {
                somme_hist_employe.Text = "";
            }
        }



        private double VerifierNombrejourpirs()
        {
            double nombrejourpris = 0;

            #region VerifierNombrejourpirs
            Personel_class per;
            HISTORIQUE_CONGE hi = new HISTORIQUE_CONGE();

            if (cin_salaries_demande1.Text != "")
            {
                gestion_personel.chercher_Personel(matricule_emp, out erreur, out per, out exist);
                DateTime datercrutment = Convert.ToDateTime(per.daterecrutement + "");
                DateTime date_debut_annner = new DateTime(DateTime.Now.Year, 1, 1);
                String date_anner_courante = date_debut_annner.ToString("dd-MM-yyyy");
                //   MessageBox.Show("Date Recurtement " + datercrutment + "||" + "Date Debut Anner " + date_anner_courante + "" + " || " + "Date Anner Courant" + date_debut_annner);

                double nbjourdroit = 0;
                String valeur = "";
                int annerdernier = 0;
                double sommemois = 0;

                gestion_historique_emp_conge.chercher_Historique_conge_emp(matriculevisible.Text, Convert.ToString(DateTime.Now.Year), out erreur, out hi, out exist);
                nbjourdroit = (Convert.ToDouble((hi.Droit_annner_courant)) / 12);//DROIT anner congé =>2018->21
                                                                                 // gestion_historique_emp_conge.getArrierAnnerDernier(datedemandepicker.Value.Year, matriculevisible.Text, out erreur, out valeur, out exist);
                                                                                 //bech te5ou el arrier mté3 amnwél
                String sumnbjr = "";
                int annercour = 0;
                double sum = 0;
                if (datercrutment.Date > date_debut_annner.Date)
                {//n9oulou employé d5al mars=>01/03/2018==>anner courante
                    gestion_historique_emp_conge.getArrierAnnerDernier(datedemandepicker.Value.Year, matriculevisible.Text, out erreur, out valeur, out exist);

                    if (valeur == "")
                    {
                        annerdernier = 0;
                    }
                    else { annerdernier = Convert.ToInt32(valeur); }
                    // MessageBox.Show("Arrier Anner Précedente: " + annerdernier);

                    annercour = (date_debut_annner.Year) + 1;
                    //  MessageBox.Show(annercour + " Date debut l'anner +1");
                    gestion_demande.getSomme(annercour, matriculevisible.Text, out erreur, out sumnbjr, out exist);
                    //9adeh men nhar 5tha fi héka él 3am méli bda 
                    //   MessageBox.Show("9adeh men nhar 5tha héka él 3am méli da5el " + sumnbjr);

                    sommemois = ((db_conge_picker.Value.Year - datercrutment.Year) * 12) + (db_conge_picker.Value.Month - datercrutment.Month) + 1;
                    //sommemois ==>d5al fi fivi w tao avril ==>3
                    //    MessageBox.Show("9adeh men nhar char 5dem meli d5al:" + sommemois);

                    if (sumnbjr.Equals(""))
                    {
                        sum = 0;
                    }
                    else
                    {
                        sum = Convert.ToDouble(sumnbjr);
                    }

                    nombrejourpris = ((sommemois * nbjourdroit) + annerdernier) - Convert.ToDouble(sum);
                    //   MessageBox.Show("9adeh men chhar 5dem * 1.75 + annerdernire 9adeh b9alou - 9adeh 5tha men nhar :" + nombrejourpris + "!");


                }
                else if (datercrutment.Date <= date_debut_annner.Date)
                {
                    int annner = (datedemandepicker.Value.Year) + 1;
                    gestion_historique_emp_conge.getArrierAnnerDernier(annner, matriculevisible.Text, out erreur, out valeur, out exist);

                    if (valeur == "")
                    {
                        annerdernier = 0;
                    }
                    else { annerdernier = Convert.ToInt32(valeur); }
                    //                  MessageBox.Show("ARrieur anner derinier : " + annerdernier);

                    sommemois = ((db_conge_picker.Value.Year - date_debut_annner.Year) * 12) + (db_conge_picker.Value.Month - date_debut_annner.Month) + 1;

                    //                    MessageBox.Show("Somme Mois: " + sommemois);
                    try
                    {
                        annercour = (date_debut_annner.Year) + 1;
                        gestion_xdd.getSomme(annercour, matriculevisible.Text, out erreur, out sumnbjr, out exist);

                        if (sumnbjr.Equals(""))
                        {
                            sum = 0;
                        }
                        else
                        {
                            sum = Convert.ToDouble(sumnbjr);
                        }

                        nombrejourpris = ((sommemois * nbjourdroit) + annerdernier) - Convert.ToDouble(sum);

                        // MessageBox.Show("nomre de jour cas Numero2    :" + nombrejourpris + "!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex + "");
                    }


                }
            }
            else
            {
                Employer_datagridview le = new Employer_datagridview();

                button_Employer_WasClicked = true;
                le.Show();
                #region load
                remplirDG("employe", "", Employer_datagridview.edd.Dgpersonel);
                #endregion
            }
            return nombrejourpris;
            #endregion
        }

        public String miseajourconge = "";
        private void Dgvalidation_Click(object sender, EventArgs e)
        {
            #region dgvaldier

            try
            {
                int index = gridView3.FocusedRowHandle;


                type_conge typeconger = new type_conge();
                String erreur = null;
                Boolean exit = false;
                gestion_typeconge.chercher_Type_conge_Valider(gridView3.GetRowCellValue(index, "ID_CONGE").ToString(), out erreur, out typeconger, out exit);
                miseajourconge = typeconger.MajCongePaye + "";
                Personel_class pc = null;
                gestion_personel.chercher_Personel(gridView3.GetRowCellValue(index, "MATRICULE").ToString(), out erreur, out pc, out exist);
                salaries__validation.Text = pc.Nom + " " + pc.Prenom + "";
                type_conge_h_validation.Text = gridView3.GetRowCellValue(index, "ID_CONGE").ToString();
                libelle__validation_cong.Text = typeconger.Desgination + "";
                HISTORIQUE_CONGE histo;
                gestion_historique_emp_conge.chercher_Historique_conge_emp(gridView3.GetRowCellValue(index, "MATRICULE").ToString(), Convert.ToString(DateTime.Now.Year), out erreur, out histo, out exist);
                arriervalidation.Text = histo.Arrier_conge + "";
                droitannercourant_validation.Text = histo.Droit_annner_courant + "";
                prisanne_validation.Text = histo.Pris_anner_courant + "";
                somme__validation.Text = ((Convert.ToDecimal(arriervalidation.Text) + Convert.ToDecimal(droitannercourant_validation.Text)) - Convert.ToDecimal(prisanne_validation.Text)).ToString();
                Demande_Conge_Class dem;

                gestion_demande.chercher_Demande_conge_emp(gridView3.GetRowCellValue(index, "ID_DEMANDE_CONGE").ToString(), out erreur, out dem, out exist);

                date_debut__validation_picker.Text = dem.Date_Debut + "";
                date_fin__validation_picker.Text = dem.Date_fin + "";
                hdebut_validation.Text = dem.Heur_Debut;
                hfin_validation.Text = dem.Heur_Fin;
                nbjour__validation.Text = dem.NombreJour + "";
                motfi_validation.Text = dem.Motiff + "";

                if (role_authentifier.Equals("Chef Service "))
                {
                    nbjourdepar.ReadOnly = true;
                    nbjourvalide_supervisueru.ReadOnly = true;
                    status_res_depar.ReadOnly = true;
                    db_picker_res_depar.Enabled = false;
                    df_res_depar.Enabled = false;
                    hd_res_depar.ReadOnly = true;
                    hf_res_depar.ReadOnly = true;
                    date_debut_picker_supervisier_validation.Enabled = false;
                    date_fin_picker_supervisier_validation.Enabled = false;
                    hd_picker_supervisier_validation.ReadOnly = true;
                    hf_picker_supervisier_validation.ReadOnly = true;
                    db_picker_resp_service.Value = dem.DATE_DEBUT_RES_SERVICES;
                    df_picker_resp_serviceSSSS.Value = dem.DATE_FIN_RES_SERVICES;
                    hd__resp_service.EditValue = dem.HEUR_DEBUT_RES_SERVICES;
                    hf_resp_service.EditValue = dem.HEUR_FIN_RES_SERVICES;
                    statu_resp_services.Text = dem.STATUS_RESPONSABLE_SERVICES;
                    nbjourvalide_supervisueru.ReadOnly = true;
                    nbjourdepar.Text = "0";
                    nbjourvalide_supervisueru.Text = "0";

                }
                if (role_authentifier.Equals("Chef Departement"))
                {
                    nbjourvalide_supervisueru.ReadOnly = true;
                    nbjour_service.ReadOnly = true;
                    statu_resp_services.ReadOnly = true;
                    db_picker_resp_service.Enabled = false;
                    df_picker_resp_serviceSSSS.Enabled = false;
                    hf_resp_service.ReadOnly = true;
                    hd__resp_service.ReadOnly = true;
                    date_debut_picker_supervisier_validation.Enabled = false;
                    date_fin_picker_supervisier_validation.Enabled = false;
                    hd_picker_supervisier_validation.ReadOnly = true;
                    nbjour_service.Text = nbjour__validation.Text;

                    hf_picker_supervisier_validation.ReadOnly = true;
                    if (dem.DATE_DEBUT_RES_SERVICES.Date.Equals(DateTime.Now.ToString("dd/MM/yyyy")))// || dem.DATE_DEBUT_RES_SERVICES==DateTime.Now.Date)
                    {
                        MessageBox.Show("Cette Demande Pour " + salaries__validation.Text + " Non Enocre Traité Par le Chéf Serivce ");
                        nbjour_service.Text = "0";

                    }
                    else
                    {
                        db_picker_resp_service.Text = dem.DATE_DEBUT_RES_SERVICES + "";
                        df_picker_resp_serviceSSSS.Text = dem.DATE_FIN_RES_SERVICES + "";
                        hd__resp_service.EditValue = dem.HEUR_DEBUT_RES_SERVICES;
                        hf_resp_service.EditValue = dem.HEUR_FIN_RES_SERVICES;
                        statu_resp_services.Text = dem.STATUS_RESPONSABLE_SERVICES;
                        db_picker_res_depar.Text = dem.DATE_DEBUT_RES_DEPARTEMENTS + "";
                        df_res_depar.Text = dem.DATE_FIN_RES_DEPARTEMENTS + "";
                        hd_res_depar.EditValue = dem.HEUR_DEBUT_RES_DepartementS;
                        hf_res_depar.EditValue = dem.HEUR_FIN_RES_DepartementS;

                        status_res_depar.Text = dem.STATUS_RESPONSABLE_DEPARTEMENTS;
                    }

                }
                else if (role_authentifier.Equals("GRH"))
                {
                    if (dem.STATUS_RESPONSABLE_SERVICES.Equals(" "))
                    {
                        nbjour_service.Text = "0";

                    }
                    else if (dem.STATUS_RESPONSABLE_DEPARTEMENTS.Equals(" "))
                    {
                        nbjourdepar.Text = "0";
                    }
                    else
                    {

                        db_picker_resp_service.Value = dem.DATE_DEBUT_RES_SERVICES;
                        df_picker_resp_serviceSSSS.Value = dem.DATE_FIN_RES_SERVICES;
                        hd__resp_service.EditValue = dem.HEUR_DEBUT_RES_SERVICES;
                        hf_resp_service.EditValue = dem.HEUR_FIN_RES_SERVICES;
                        statu_resp_services.Text = dem.STATUS_RESPONSABLE_SERVICES;
                        db_picker_res_depar.Value = dem.DATE_DEBUT_RES_DEPARTEMENTS;
                        df_res_depar.Value = dem.DATE_FIN_RES_DEPARTEMENTS;
                        hd_res_depar.EditValue = dem.HEUR_DEBUT_RES_DepartementS;
                        hf_res_depar.EditValue = dem.HEUR_FIN_RES_DepartementS;

                        status_res_depar.Text = dem.STATUS_RESPONSABLE_DEPARTEMENTS;
                    }
                }



                nbjourvalide_supervisueru.Text = dem.NombreJour + "";
                hd_picker_supervisier_validation.Text = "";
                string strDatedebut = dem.Heur_Debut;
                string[] arrDate = strDatedebut.Split(':');
                string lesheur = arrDate[0].ToString();
                string lesminite = arrDate[1].ToString();
                hd_picker_supervisier_validation.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(lesheur), Convert.ToInt32(lesminite), 00);
                string strDatefin = dem.Heur_Fin;
                string[] arrDate1 = strDatefin.Split(':');
                string lesheur_fin = arrDate1[0].ToString();
                string lesminite_fin = arrDate1[1].ToString();
                hf_picker_supervisier_validation.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(lesheur_fin), Convert.ToInt32(lesminite_fin), 00);

                nbjour__validation.ReadOnly = true;
                nbjourvalide_supervisueru.Text = "0";
                nbjour_service.Text = nbjour__validation.Text;
                nbjourdepar.Text = nbjour__validation.Text;

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee + "");
                ee = null;
            }
            #endregion
        }
        private void viderchamps_Validation()
        {
            arriervalidation.Text = "0"; prisanne_validation.Text = "0";//droitconger__validation.Text = "0";
            somme__validation.Text = "0";
            type_conge_h_validation.Text = ""; libelle__validation_cong.Text = "";

            date_debut__validation_picker.Text = DateTime.Now.ToString();
            date_fin__validation_picker.Text = DateTime.Now.ToString();
            hdebut_validation.Text = "00:00";
            hfin_validation.Text = "00:00";
            nbjour__validation.Text = "";

            date_debut_picker_supervisier_validation.Text = DateTime.Now.ToString();
            date_fin_picker_supervisier_validation.Text = DateTime.Now.ToString();
            nbjourvalide_supervisueru.Text = "";
            hd_picker_supervisier_validation.Text = "00:00";
            hf_picker_supervisier_validation.Text = "00:00";

            nbjour__validation.ReadOnly = true;


        }


        private void date_fin__validation_picker_ValueChanged(object sender, EventArgs e)
        {
            #region date_fin__validation_picker_ValueChanged
            string DateDebut_val = date_debut_picker_supervisier_validation.Value.ToString("yyyy-MM-dd");
            string DateFin_val = date_fin_picker_supervisier_validation.Value.ToString("yyyy-MM-dd");

            string[] datedeb = DateDebut_val.Split('-');
            string[] datefin = DateFin_val.Split('-');

            string debut = datedeb[2].ToString();
            string fin = datefin[2].ToString();
            nbjour__validation.Text = (Convert.ToInt32(fin) - Convert.ToInt32(debut)).ToString().Replace("-", "");
            #endregion
        }


        private void db_conge_picker_Leave(object sender, EventArgs e)
        {

            nbjour_conge.Text = Convert.ToString(CalculerNombreJour(hf, hd, db_conge_picker, df_conge_picker));


        }

        public double CalculerNombreJour(TimeEdit timeeditdebut, TimeEdit timeeditfin, DateTimePicker db, DateTimePicker df)
        {
            #region calculernombrejour
            DateTime debbb = DateTime.Parse(db.Text);
            DateTime finnn = DateTime.Parse(df.Text);
            TimeSpan Diff = finnn - debbb;
            int day = Convert.ToInt32(Diff.TotalDays);
            // nb.Text = (day + 1) + "";

            String hdheeur = timeeditdebut.Text;
            String[] hdc = hdheeur.Split(':');
            String debut_heur = hdc[0].ToString();
            String debut_minute = hdc[1].ToString();
            /*********************************************************/
            String hfheur = timeeditfin.Text;
            String[] hfc = hfheur.Split(':');
            String fin_heur = hfc[0].ToString();
            String fin_minute = hfc[1].ToString();
            double nbj = 0;

            if (df.Value.Date != db.Value.Date && (!timeeditdebut.Text.Equals("00:00")) && (!timeeditfin.Text.Equals("00:00")))
            {
                return nbj = (((day + Convert.ToDouble(debut_heur) / 8) + ((Convert.ToDouble(debut_minute) / 60) / 8) + (Convert.ToDouble(fin_heur) / 8) + (Convert.ToDouble(Convert.ToDouble(fin_minute) / 60) / 8)) - 1);

            }
            else if (timeeditdebut.Text.Equals("00:00") && timeeditfin.Text.Equals("00:00"))
            {
                return nbj = day + 1;
            }
            else       //if (picker1.Value.Date != picker2.Value.Date && !time1.EditValue.Equals("00:00") && !time2.EditValue.Equals("00:00"))

            {
                return nbj = (day + (Convert.ToDouble(Convert.ToDouble(debut_heur) / 8)) + (Convert.ToDouble(Convert.ToDouble(debut_minute) / 60) / 8) + (Convert.ToDouble(Convert.ToDouble(fin_heur) / 8)) + ((Convert.ToDouble(fin_minute) / 60) / 8));

            }

            #endregion
        }

        private void date_debut_picker_supervisier_validation_Leave(object sender, EventArgs e)
        {
            nbjourvalide_supervisueru.Text = (Math.Round(CalculerNombreJour(hd_picker_supervisier_validation, hf_picker_supervisier_validation, date_debut_picker_supervisier_validation, date_fin_picker_supervisier_validation), 2) + "");

        }

        private void date_fin_picker_supervisier_validation_Leave(object sender, EventArgs e)
        {
            enter = true;

            #region datatimepicker leave when there is a day sunday or saturday 

            type_conge type = new type_conge();

            entreprise_class ent = new entreprise_class();

            gestion_entpreise.chercher_entreprise(idd, out erreur, out ent, out exist);
            String repot1 = ent.Repot1 + "";
            String repot2 = ent.Repot2 + "";
            DateTime debutt = DateTime.Parse(date_debut_picker_supervisier_validation.Text);
            DateTime finnn = DateTime.Parse(date_fin_picker_supervisier_validation.Text);
            var culture = new System.Globalization.CultureInfo("fr-Fr");
            var day = culture.DateTimeFormat.GetDayName(date_fin_picker_supervisier_validation.Value.DayOfWeek);
            if (day.Equals(ent.Repot1) || day.Equals(ent.Repot2))
            {
                MessageBox.Show(
                   "Illogique ! tu veux congé en jour non ouvrable ",
                   "Avertissement ",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation //For Info Asterisk

                 );
            }
            else if (date_fin_picker_supervisier_validation.Value.Date < date_debut_picker_supervisier_validation.Value.Date)
            {

                MessageBox.Show(
                  "Date Debut de Congé Doit Etre inférieur ou Egal Au Date Fin congé ",
                  "Avertissement ",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning //For Info Asterisk

                );

            }
            else
            {

                int nbj = 0;

                List<String> listjour = new List<string>();
                for (DateTime current = debutt; current <= finnn; current = current.AddDays(1))
                {
                    listjour.Add(culture.DateTimeFormat.GetDayName(current.DayOfWeek) + "");

                }




                try
                {
                    gestion_typeconge.chercher_Type_conge_Valider(type_conge_h_validation.Text, out erreur, out type, out exist);
                    //MessageBox.Show(type.JourOuvrable);
                }
                catch (Exception ex)
                {/*
                    Simple_Fenetre.Type_Conge_datagridview dtype = new Type_Conge_datagridview();


                    dtype.Show();
                    button_Typeconge_WasClicked = true;
                    remplirDG("TYPE_CONGE", "", Type_Conge_datagridview.datagridtypeconge.DgTypeconge);
                    dtype.Show();*/
                }
                double nn0 = 0;
                for (int i = 0; i < listjour.Count; i++)
                {
                    if (repot1.Equals(listjour.ElementAt(i)))
                        //   listjour.RemoveAt(i);
                        nn0 += 1;
                    if (repot2.Equals(listjour.ElementAt(i)))
                        // listjour.RemoveAt(i);
                        nn0 += 1;

                }
                if (type.JourOuvrable.Equals("Oui"))


                {
                    if (!(day.Equals(repot1) || day.Equals(repot2)))
                    {





                        //                        MessageBox.Show("9adeh men nhar" + nn0);
                        nbjourvalide_supervisueru.Text = Math.Round((CalculerNombreJour(hd_picker_supervisier_validation, hf_picker_supervisier_validation, date_debut_picker_supervisier_validation, date_fin_picker_supervisier_validation) - nn0), 2) + "";

                        /*  for (int i = 0; i < listjour.Count; i++)
                          {
                              MessageBox.Show(listjour[i]);
                              nbj++;
                          }*/
                        //   nbjour_conge.Text = nbj + "";
                    }
                    else
                    {
                        nbjourvalide_supervisueru.Text = Math.Round((CalculerNombreJour(hd_picker_supervisier_validation, hf_picker_supervisier_validation, date_debut_picker_supervisier_validation, date_fin_picker_supervisier_validation) - nn0), 2) + "";

                    }



                }
                else
                {
                    //nbjour_conge.Text = Convert.ToString(CalculerNombreJour(hf, hd, db_conge_picker, df_conge_picker));
                    nbjourvalide_supervisueru.Text = Math.Round((CalculerNombreJour(hd_picker_supervisier_validation, hf_picker_supervisier_validation, date_debut_picker_supervisier_validation, date_fin_picker_supervisier_validation)), 2) + "";

                }

            }
            #endregion


        }

        private void hd_picker_supervisier_validation_Leave(object sender, EventArgs e)
        {
            nbjourvalide_supervisueru.Text = (Math.Round(CalculerNombreJour(hd_picker_supervisier_validation, hf_picker_supervisier_validation, date_debut_picker_supervisier_validation, date_fin_picker_supervisier_validation), 2) + "");

        }

        private void hf_picker_supervisier_validation_Leave(object sender, EventArgs e)
        {
            nbjourvalide_supervisueru.Text = (Math.Round(CalculerNombreJour(hd_picker_supervisier_validation, hf_picker_supervisier_validation, date_debut_picker_supervisier_validation, date_fin_picker_supervisier_validation), 2) + "");

        }

        private void historique_dg_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            gestion_xd xx = new gestion_xd();
            String sommme = "";
            Int32 annner = 0;
            int indexDgpersonel = 0;
            try
            {
                indexDgpersonel = Employer_datagridview.edd.gridView1.FocusedRowHandle;
                #region declar  

                int index = 0;
                Double somsoms = 0;

                double report_valide = 0;

                String droit_jour_anner_precedent = "";
                Double Nombre_Jour_anerprecedent = 0;
                #endregion
                //   ffdgdf
                #region datagridview histo dans fiche personel loresque quiter column anner 
                //  if (historique_dg.Columns[e.ColumnIndex].Name == "Année Congé")//ANNER
                //    if (historique_dg.Columns[e.ColumnIndex].Name == "Année Congé")//ANNER
                if (historique_dg.CurrentCell.ColumnIndex == 1)
                {
                    if (historique_dg.Rows.Count < 3)
                    {
                        index = historique_dg.CurrentRow.Index;
                        try
                        {
                            annner = Convert.ToInt32(historique_dg.Rows[index].Cells[1].Value.ToString());
                            xx.Droit_conge_anner_precedent(annner, Employer_datagridview.edd.gridView1.GetRowCellValue(indexDgpersonel, "MATRICULE").ToString(), out erreur, out droit_jour_anner_precedent, out exist);

                            if (droit_jour_anner_precedent.Equals(""))
                            {
                                Nombre_Jour_anerprecedent = 0;
                            }

                            //  MessageBox.Show("Droit cas 1 !" + Nombre_Jour_anerprecedent);


                            string reporrrt = historique_dg.Rows[index].Cells[4].Value + "";
                            if (reporrrt == "")
                            {
                                report_valide = 0;
                            }
                            //else
                            //{ report_valide = Convert.ToDouble(reporrrt); }

                            //   MessageBox.Show("report valider" + report_valide);

                            xx.getSomme(annner, Employer_datagridview.edd.gridView1.GetRowCellValue(indexDgpersonel, "MATRICULE").ToString(), out erreur, out sommme, out exist);
                            try
                            {
                                somsoms = Convert.ToDouble((Nombre_Jour_anerprecedent + report_valide) - (Convert.ToDouble(sommme)));

                            }
                            catch (Exception ex1)
                            { int aas = 0; }
                            historique_dg.Rows[index].Cells[3].Value = Convert.ToString(somsoms);
                            historique_dg.Rows[index].Cells[4].Value = Convert.ToString(somsoms);

                        }
                        catch (Exception ex)
                        {
                            int xs = 0;
                        }

                    }
                    else
                    {


                        index = historique_dg.CurrentRow.Index;
                        try
                        {
                            annner = Convert.ToInt32(historique_dg.Rows[index].Cells[1].Value.ToString());
                            //  MessageBox.Show("Employe 9dim Index : " + index + " | anner Courante =" + annner);
                            xx.getSomme(annner, Employer_datagridview.edd.gridView1.GetRowCellValue(indexDgpersonel, "MATRICULE").ToString(), out erreur, out sommme, out exist);
                            Double someresultat = 0;

                            if (erreur == null)
                            {
                                //  MessageBox.Show(sommme + "");
                                if (sommme.Equals(""))
                                {
                                    someresultat = 0;
                                }
                                else
                                {
                                    someresultat = Convert.ToDouble(sommme);
                                }
                                //  MessageBox.Show("Somme anner precedent =" + someresultat + "");

                            }
                            else { MessageBox.Show("err" + erreur); }

                            xx.Droit_conge_anner_precedent(annner, Employer_datagridview.edd.gridView1.GetRowCellValue(indexDgpersonel, "MATRICULE").ToString(), out erreur, out droit_jour_anner_precedent, out exist);
                            Nombre_Jour_anerprecedent = Convert.ToDouble(droit_jour_anner_precedent);

                            //  MessageBox.Show("Droit annner precedent  " + Nombre_Jour_anerprecedent);


                            string reporrrt = historique_dg.Rows[--index].Cells[4].Value + "";
                            //  MessageBox.Show("index ! " + index + " REport !" + reporrrt);
                            report_valide = Convert.ToDouble(reporrrt);

                            Double SS = Nombre_Jour_anerprecedent + report_valide;
                            Double reee = SS - someresultat;
                            //   MessageBox.Show(reee + "");
                            somsoms = Math.Round(Convert.ToDouble((Nombre_Jour_anerprecedent + report_valide) - (Convert.ToDouble(someresultat))), 2);

                            index += 1;
                            historique_dg.Rows[index].Cells[4].Value = somsoms + "";
                            historique_dg.Rows[index].Cells[3].Value = somsoms + "";


                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex + "");

                        }

                    }
                }

                #endregion

            }
            catch (Exception ee)
            {

                Simple_Fenetre.Employer_datagridview ed = new Simple_Fenetre.Employer_datagridview();


                ed.Show();
                #region lorsque Salarie Dock opend

                #region load
                remplirDG("employe", "", Employer_datagridview.edd.Dgpersonel);

                #region remplir fonction
                /*    erreur = null;
                    List<fonction_class> l;
                    exist = false;
                    GestionFonction gf = new GestionFonction();
                    gf.chercher_fn2(idd, out erreur, out l, out exist);

                    foreach (fonction_class x in l)
                    {

                        combofonction.Items.Add(x.desgs);

                    }

                        */


                #endregion

                #endregion



                #endregion
            }
        }
        private void historique_dg_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            #region when click into button dg 
            //   dsfsdfsdf
            int index11 = Employer_datagridview.edd.gridView1.FocusedRowHandle;
            // MessageBox.Show("Index Courante" + index11);
            int index = historique_dg.CurrentRow.Index;

            if (e.ColumnIndex == historique_dg.Columns["Column8"].Index)

            {
                /**/
                //lézém tryy !! 5ater kif nnzél al column fama erreur
                historique_dg.CurrentCell = historique_dg.Rows[e.RowIndex].Cells[e.ColumnIndex];
                // Can leave these here - doesn't hurt
                historique_dg.Rows[e.RowIndex].Selected = true;
                //  dataGridView2.Focus();


                string annerr = historique_dg.Rows[index].Cells[1].Value + "";
                string droitcong = historique_dg.Rows[index].Cells[2].Value + "";
                string reporttcalculer = historique_dg.Rows[index].Cells[3].Value + "";
                string reporttvalider = historique_dg.Rows[index].Cells[4].Value + "";

                if (annerr.Equals(""))
                {
                    MessageBox.Show("Anner obligatoire !");
                    historique_dg.CurrentCell = historique_dg.Rows[index].Cells[1];

                }
                else if (droitcong.Equals(""))
                {
                    MessageBox.Show("Droit Congé obligatoire !");
                    historique_dg.CurrentCell = historique_dg.Rows[index].Cells[2];

                }
                else if (reporttcalculer.Equals(""))
                {
                    MessageBox.Show("Report Calculé obligatoire !");
                    historique_dg.CurrentCell = historique_dg.Rows[index].Cells[3];

                }
                else if (reporttvalider.Equals(""))
                {
                    MessageBox.Show("Report Validé obligatoire !");
                    historique_dg.CurrentCell = historique_dg.Rows[index].Cells[4];

                }

                /*else if (Employer_datagridview.edd.gridView1.GetRowCellValue(index11, "MATRICULE").ToString() == null)
                {
                    MessageBox.Show("Cin  obligatoire !");
                    Employer_datagridview.edd.gridView1.FocusedRowHandle = 0;

                }
                */

                else if (matriculee.Text == "")
                {
                    MessageBox.Show("choisissez Employé !");
                    //Employer_datagridview.edd.gridView1.FocusedRowHandle = 0;

                }
                else
                {
                    try
                    {
                        //  MessageBox.Show(historique_dg.Rows[index].Cells[4].Value + "||| " + Convert.ToInt32(historique_dg.Rows[index].Cells[3].Value + "") + "||| " + Convert.ToInt32(historique_dg.Rows[index].Cells[1].Value + "") + "|||" + 0 + "|||" + historique_dg.Rows[index].Cells[0].Value + "|||" + Employer_datagridview.edd.gridView1.GetRowCellValue(index11, "MATRICULE").ToString());
                        HISTORIQUE_CONGE histo = new HISTORIQUE_CONGE("H_" + Employer_datagridview.edd.gridView1.GetRowCellValue(index11, "MATRICULE").ToString() + "_" + historique_dg.Rows[index].Cells[4].Value + "", Convert.ToInt32(historique_dg.Rows[index].Cells[4].Value + ""), Convert.ToInt32(historique_dg.Rows[index].Cells[2].Value + ""), 0, historique_dg.Rows[index].Cells[1].Value + "", "oui", "oui", "dfgdfg", Employer_datagridview.edd.gridView1.GetRowCellValue(index11, "MATRICULE").ToString());
                        Gestion_Historique_Cong ghisto = new Gestion_Historique_Cong();
                        ghisto.ajouter_Histo_PErso(histo, out erreur);

                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show(ex + "");
                    }
                    if (erreur == null)
                    {
                        var cell = historique_dg[0, index] = new DataGridViewTextBoxCell();// DataGridViewTextBoxCell();
                        cell.ReadOnly = true;
                        //  cell.Style.BackColor = Color.FromKnownColor(KnownColor.Control);

                        MessageBox.Show("Hisotrique Ajouté Avec Succés");
                        arrier_courant_employer.Text = historique_dg.Rows[index].Cells[4].Value + "";
                        droit_anner_employe.Text = historique_dg.Rows[index].Cells[2].Value + "";
                        pris_anner_employe.Text = "0";//historique_dg.Rows[index].Cells[].Value+"";
                        somme_hist_employe.Text = Convert.ToDouble(Convert.ToDouble(arrier_courant_employer.Text) + Convert.ToDouble(droit_anner_employe.Text) - Convert.ToDouble(pris_anner_employe.Text)) + "";
                    }
                    else MessageBox.Show("Erreur" + erreur);
                }
            }
            #endregion

        }

        private void print_salaire_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Listes_Employes lemp = new Listes_Employes();
            lemp.Show();

        }


        public bool button_Typeconge_WasClicked = false;

        private void choisir_typpe_btn_Click(object sender, EventArgs e)
        {
            Type_Conge_datagridview dtype = new Type_Conge_datagridview();
            dtype.Show();
            button_Typeconge_WasClicked = true;
            remplirDG("TYPE_CONGE", "", Type_Conge_datagridview.datagridtypeconge.DgTypeconge);
            dtype.Show();
        }


        public bool button_Employer_WasClicked = false;

        private void choisir_employer_btn_Click(object sender, EventArgs e)
        {
            Employer_datagridview le = new Employer_datagridview();
            button_Employer_WasClicked = true;
            le.Show();
            remplirDG("employe", "", Employer_datagridview.edd.Dgpersonel);
        }

        private void prenom_EditValueChanged(object sender, EventArgs e)
        {
            string[] str = { "Sfax", "Tunis", "Sousse", "tunis", "sfax", "sousse", "Gfsa", "Hammamet" };
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(str);
            prenom.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            prenom.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            prenom.MaskBox.AutoCompleteCustomSource = collection;
        }

        private void grindcontrol_liste_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Simple_Fenetre.Employer_datagridview ed = new Simple_Fenetre.Employer_datagridview();


            ed.Show();
            #region lorsque Salarie Dock opend

            #region load
            remplirDG("employe", "", Employer_datagridview.edd.Dgpersonel);

            #region remplir fonction
            /*    erreur = null;
                List<fonction_class> l;
                exist = false;
                GestionFonction gf = new GestionFonction();
                gf.chercher_fn2(idd, out erreur, out l, out exist);

                foreach (fonction_class x in l)
                {

                    combofonction.Items.Add(x.desgs);

                }

                    */


            #endregion

            #endregion



            #endregion
        }

        private void listetype_congeee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Simple_Fenetre.Type_Conge_datagridview dtype = new Type_Conge_datagridview();
            dtype.Show();
            remplirDG("TYPE_CONGE", "", Type_Conge_datagridview.datagridtypeconge.DgTypeconge);


        }

        private void barButtonItem43_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Information_Applications inf = new Information_Applications();
            inf.Show();
        }
        public bool enter = false;
        private void df_conge_picker_ValueChanged(object sender, EventArgs e)
        {
            enter = true;

            #region datatimepicker leave when there is a day sunday or saturday 

            type_conge type = new type_conge();

            entreprise_class ent = new entreprise_class();

            gestion_entpreise.chercher_entreprise(idd, out erreur, out ent, out exist);
            String repot1 = ent.Repot1 + "";
            String repot2 = ent.Repot2 + "";
            DateTime debutt = DateTime.Parse(db_conge_picker.Text);
            DateTime finnn = DateTime.Parse(df_conge_picker.Text);
            var culture = new System.Globalization.CultureInfo("fr-Fr");
            var day = culture.DateTimeFormat.GetDayName(df_conge_picker.Value.DayOfWeek);
            if (day.Equals(ent.Repot1) || day.Equals(ent.Repot2))
            {
                MessageBox.Show(
                   "Illogique ! tu veux congé en jour non ouvrable ",
                   "Avertissement ",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation //For Info Asterisk

                 );
            }
            else if (df_conge_picker.Value.Date < db_conge_picker.Value.Date)
            {

                MessageBox.Show(
                  "Date Debut de Congé Doit Etre inférieur ou Egal Au Date Fin congé ",
                  "Avertissement ",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning //For Info Asterisk

                );

            }
            else
            {

                int nbj = 0;

                List<String> listjour = new List<string>();
                for (DateTime current = debutt; current <= finnn; current = current.AddDays(1))
                {
                    listjour.Add(culture.DateTimeFormat.GetDayName(current.DayOfWeek) + "");

                }




                try
                {
                    gestion_typeconge.chercher_Type_conge_Valider(List_Type_Conge.ltype.var_textbox_idconge.Text, out erreur, out type, out exist);

                }
                catch (Exception ex)
                {/*
                    Simple_Fenetre.Type_Conge_datagridview dtype = new Type_Conge_datagridview();


                    dtype.Show();
                    button_Typeconge_WasClicked = true;
                    remplirDG("TYPE_CONGE", "", Type_Conge_datagridview.datagridtypeconge.DgTypeconge);
                    dtype.Show();*/
                }
                double nn0 = 0;
                for (int i = 0; i < listjour.Count; i++)
                {
                    if (repot1.Equals(listjour.ElementAt(i)))
                        //   listjour.RemoveAt(i);
                        nn0 += 1;
                    if (repot2.Equals(listjour.ElementAt(i)))
                        // listjour.RemoveAt(i);
                        nn0 += 1;

                }
                if (cb_jouvrable.Checked)

                {
                    if (!(day.Equals(repot1) || day.Equals(repot2)))
                    {


                        //MessageBox.Show("9adeh men nhar" + nn0);
                        nbjour_conge.Text = Math.Round((CalculerNombreJour(hf, hd, db_conge_picker, df_conge_picker) - nn0), 2) + "";

                        /*  for (int i = 0; i < listjour.Count; i++)
                          {
                              MessageBox.Show(listjour[i]);
                              nbj++;
                          }*/
                        //   nbjour_conge.Text = nbj + "";
                    }
                    else
                    {
                        nbjour_conge.Text = Math.Round(CalculerNombreJour(hf, hd, db_conge_picker, df_conge_picker) - nn0, 2) + "";

                    }



                }
                else
                {
                    nbjour_conge.Text = Convert.ToString(CalculerNombreJour(hf, hd, db_conge_picker, df_conge_picker));

                }

            }
            #endregion
        }

        private void hd_EditValueChanged(object sender, EventArgs e)
        {
            if (enter == false)
            {
                nbjour_conge.Text = (Math.Round(CalculerNombreJour(hf, hd, db_conge_picker, df_conge_picker), 2) + "");
            }
            else
            {
                nbjour_conge.Text = (Math.Round(CalculerNombreJour(hf, hd, db_conge_picker, df_conge_picker), 2) + "");
            }
        }

        private void hf_EditValueChanged(object sender, EventArgs e)
        {
            if (enter == false)
            {
                nbjour_conge.Text = (Math.Round(CalculerNombreJour(hf, hd, db_conge_picker, df_conge_picker), 2) + "");
            }
            else
            {
                nbjour_conge.Text = (Math.Round(CalculerNombreJour(hf, hd, db_conge_picker, df_conge_picker), 2) + "");
            }
        }

        private void db_conge_picker_ValueChanged(object sender, EventArgs e)
        {
            enter = true;

            nbjour_conge.Text = (Math.Round(CalculerNombreJour(hf, hd, db_conge_picker, df_conge_picker), 2) + "");

        }
        public void vider_champs_demande_conger()
        {
            cin_salaries_demande1.Text = "";
            nom_emp_demande.Text = "";
            prenom_emp_demand.Text = "";
            db_conge_picker.Text = DateTime.Now + "";
            df_conge_picker.Text = DateTime.Now + "";
            code_type_cong_ongle_demande.Text = "";
            libelel_type_conge.Text = "";
            nbjour_conge.Text = "";
            hd.EditValue = "00:00";
            hf.EditValue = "00:0";
            cbcongepay.Checked = false;
            cb_jouvrable.Checked = false;
            cb_maj.Checked = false;
        }
        public char GetLetter()
        {
            string chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rand = new Random();
            int num = rand.Next(0, chars.Length - 1);
            //MessageBox.Show(chars[num]+"");
            return chars[num];
        }

        private void demander_conge_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region ValiderDemande

            #region declar
            string DateDebut_conger_ongle_Demande_conger = db_conge_picker.Value.ToString("yyyy-MM-dd");
            string DateFin_conger_ongle_Demande_conger = df_conge_picker.Value.ToString("yyyy-MM-dd");
            string DateDemande_ongle_Demande_conger = datedemandepicker.Value.ToString("yyyy-MM-dd");
            string[] datedeb = DateDebut_conger_ongle_Demande_conger.Split('-');
            string[] datefin = DateFin_conger_ongle_Demande_conger.Split('-');

            string debut_year = datedeb[0].ToString();
            string fin_year = datedeb[0].ToString();
            string debut_month = datedeb[1].ToString();
            string fin_month = datedeb[1].ToString();

            string debut_day = datedeb[2].ToString();
            string fin_day = datedeb[2].ToString();

            //Heur 
            string[] heurdebut = hd.Text.Split('-');
            string[] heurfin = hf.Text.Split('-');

            string HeurD = datedeb[0].ToString();
            string HeurF = datedeb[0].ToString();
            string MinnuteD = datedeb[1].ToString();
            string MinnuteF = datedeb[1].ToString();
            string SecondeD = datedeb[2].ToString();
            string SecondeF = datedeb[2].ToString();


            String duree = "";
            String congepaye = combobox_congepye.Text;
            String miseajourconge = comboBoxmiseajour_conge.Text;
            String jourouvrable = comboboxjourouvrable.Text;
            string dateDemande_var = datedemandepicker.Value.ToString("yyyy-MM-dd");

            string[] datedemande = dateDemande_var.Split('-');

            string Date_unique_Demande = datedemande[2].ToString() + "_" + datedemande[0].ToString();

            #endregion

            double nbjourverfier = VerifierNombrejourpirs();
            if (code_type_cong_ongle_demande.Text == "")
            {
                MessageBox.Show("Tu doit choisir un type de congé");

                Type_Conge_datagridview dtype = new Type_Conge_datagridview();
                dtype.Show();
                button_Typeconge_WasClicked = true;
                remplirDG("TYPE_CONGE", "", Type_Conge_datagridview.datagridtypeconge.DgTypeconge);
                dtype.Show();
            }
            else if (nbjour_conge.Text == "")
            {
                MessageBox.Show("tu doit choisir date debut de congé ");
            }
            else if (nbjourverfier < Convert.ToDouble(nbjour_conge.Text))
            {
                MessageBox.Show(cin_salaries_demande1.Text + " :Le nombre de jour que tu peux le prendre : " + nbjourverfier);
                // Employer_datagridview le = new Employer_datagridview();
                //button_Employer_WasClicked = true;
                //le.Show();
                //remplirDG("employe", "", Employer_datagridview.edd.Dgpersonel);

            }


            else if (db_conge_picker.Value.Date < datedemandepicker.Value.Date)
            {
                MessageBox.Show("Date Debut Congé ne doit pas etre inférieur au Date demande");

            }

            else if (datedemandepicker.Text == "")
            {
                MessageBox.Show("Date Demande obligatoire");
            }
            else if (cin_salaries_demande1.Text == "")
            {
                MessageBox.Show("Tu doit choisir un employé");

            }



            else if (db_conge_picker.Value.Date > df_conge_picker.Value.Date)
            {
                MessageBox.Show("Date Debut de Congé Doit Etre inférieur Au Date Fin de Congé");

            }
            else if (db_conge_picker.Value.Date > df_conge_picker.Value.Date)
            {
                MessageBox.Show("Date Debut de Congé Doit Etre inférieur Au Date Fin de Congé");

            }

            else if (Convert.ToInt32(debut_year) > Convert.ToInt32(fin_year))
            {
                MessageBox.Show("Fin Congé Doit étre supérieur Ou égal Au Date Debut congé ");

            }

            else
            {
                String motif_var = "";
                if (motif.Text == "")
                {
                    motif_var = "Aucune Motif ! ";
                }
                else
                {
                    motif_var = motif.Text;
                }
                String heur_debut = "";
                String heur_fin = "";
                if (hd.Text.Equals("00:00"))
                {
                    heur_debut = "00:00";
                }
                else
                {
                    heur_debut = hd.Text;
                }
                if (hf.Text.Equals("00:00"))
                {
                    heur_fin = "00:00";
                }
                else { heur_fin = hf.Text; }

                int r = 0;
                Boolean trouve = false;
                r = (new Random()).Next(100, 10000);
                Demande_Conge_Class demande;

                gestion_demande.chercher_Demande_conge_par_datedebut(datedemandepicker.Value.ToShortDateString(), cin_salaries_demande1.Text, out erreur, out demande, out exist);
                if (exist == true)//demande.Date_Demande.ToShortDateString().Equals(datedemandepicker.Value.ToShortDateString()))
                {
                    trouve = true;
                }
                if (trouve == false)
                {
                    XtraMessageBox.Show(cin_salaries_demande1.Text + " :Le nombre de jour que tu peux le prendre : " + nbjourverfier);
                    demande = new Demande_Conge_Class("Demand_" + r, Convert.ToDateTime(db_conge_picker.Value.ToShortDateString()), Convert.ToDateTime(df_conge_picker.Value.ToShortDateString()), heur_debut, heur_fin, Convert.ToDateTime(datedemandepicker.Value.ToShortDateString()), motif_var, cin_salaries_demande1.Text, id_conger_pourenregiter, "Non Encore Traité par GRH", Convert.ToDecimal(nbjour_conge.Text), Convert.ToDateTime(DateTime.Now.ToShortTimeString()), Convert.ToDateTime(DateTime.Now.ToShortTimeString()), "00:00", "00:00", " ", Convert.ToDateTime(DateTime.Now.ToShortTimeString()), Convert.ToDateTime(DateTime.Now.ToShortTimeString()), "00:00", "00:00", " ");
                    gestion_demande.ajouter_DEMANDE_CONGE(demande, out erreur);
                    if (erreur == null)
                    {
                        XtraMessageBox.Show("Demande pour " + nom_emp_demande.Text + " a été enregistrer avec succés, Veuillez attendere la consultation de votre demande de Congé");
                        class_fich_demande_conge fd = new class_fich_demande_conge(r + "" + GetLetter() + "", "Demand_" + r);
                        gestion_fiche.ajouter_fiche(fd, out erreur);

                        DialogResult dialogResult = MessageBox.Show("Voulez vous imprimer fiche demande de congé", "Imprimer ? ", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            String s1 = cin_salaries_demande1.Text;
                            String nomserv; int xx1;
                            gestion_servie.chercher_Service3(sv, out erreur, out nomserv, out xx1, out exist);

                            Impression2 imp2 = new Impression2(Convert.ToString(s1[0]), Convert.ToString(s1[1]), Convert.ToString(s1[2]), Convert.ToString(s1[3]), Convert.ToString(s1[4]), Convert.ToString(s1[5]), Convert.ToDateTime(db_conge_picker.Value.ToShortDateString()), Convert.ToDateTime(df_conge_picker.Value.ToShortDateString()), hd.Text, hf.Text, nom_emp_demande.Text, prenom_emp_demand.Text, nomserv, nbjour_conge.Text, libelel_type_conge.Text, Convert.ToDateTime(datedemandepicker.Value.ToShortTimeString()));
                            imp2.imprimer_fiche_deemande();
                            imp2.ShowDialog();
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do something else
                        }

                    }
                    else { XtraMessageBox.Show("Erreur Dans LaDemande de Congé " + erreur); }
                }
                else
                {
                    MessageBox.Show("Cette Demande de congé existe déja ");
                }
            }




            #endregion
            //   vider_champs_demande_conger();
        }


        private void Validationsupervisuer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region valider_demander_superviser_ItemClick
            int random = (new Random()).Next(100, 1000);

            #region delc date
            /* string DateDebut_conger_ongle_valider_congerr = date_debut_picker_supervisier_validation.Value.ToShortTimeString();
             string Datefin_conger_ongle_valider_congerr = date_fin_picker_supervisier_validation.Value.ToShortTimeString();
             string[] datedeb = DateDebut_conger_ongle_valider_congerr.Split('/');
             string[] datefin = Datefin_conger_ongle_valider_congerr.Split('/');

             string debut_year = datedeb[0].ToString();
             string fin_year = datedeb[0].ToString();
             string debut_month = datedeb[1].ToString();
             string fin_month = datedeb[1].ToString();

             string debut_day = datedeb[2].ToString();
             string fin_day = datedeb[2].ToString();

             //Heur 
             string[] heurdebut = hd.Text.Split('-');
             string[] heurfin = hf.Text.Split('-');*/
            #endregion

            #region test
            int index = gridView3.FocusedRowHandle;

            /* if (Convert.ToInt32(DateTime.Now.Year.ToString()) > Convert.ToInt32(debut_year))
              {
                  MessageBox.Show("Date de Demande de Congé Doit Etre supérieur Au Date : " + DateTime.Now.Year.ToString());
              }
              else if (Convert.ToInt32(DateTime.Now.Month.ToString()) > Convert.ToInt32(debut_month.ToString()))
              {
                  MessageBox.Show("Date de Demande de Congé Doit Etre supérieur Au Date : " + DateTime.Now.Month.ToString());
              }

              else if (Convert.ToInt32(debut_year) > Convert.ToInt32(fin_year))
              {
                  MessageBox.Show("Fin Congé Doit étre supérieur Ou égal Au Date Debut congé ");
              }
              else
              {*/
            DateTime debbb = DateTime.Parse(this.date_debut_picker_supervisier_validation.Text);
            DateTime finnn = DateTime.Parse(this.date_fin_picker_supervisier_validation.Text);
            String heur_debut = "";
            String heur_fin = "";
            if (hd_picker_supervisier_validation.Text.Equals("00:00"))
            {
                heur_debut = "0";
            }
            else
            {
                heur_debut = hd_picker_supervisier_validation.Text;
            }
            if (hf_picker_supervisier_validation.Text.Equals("00:00"))
            {
                heur_fin = "0";
            }
            else { heur_fin = hf_picker_supervisier_validation.Text; }
            #endregion

            Demande_Conge_Class deman;
            String motif_var = "";
            if (motfi_validation.Text == "")
            {
                motif_var = "Aucune Motif ! ";
            }
            else
            {
                motif_var = motfi_validation.Text;
            }
            String statu_respDepar = "";
            if (status_res_depar.Text == "" || status_res_depar.Text == " ")
            {
                statu_respDepar = "Deuxième avis du Chef Du Département Avec succès";

            }
            else
            {
                statu_respDepar = status_res_depar.Text;

            }


            String statu_respService = "";
            if (statu_resp_services.Text == "")
            {
                statu_respService = "Premier avis du Chef Service Avec succès";

            }
            else
            {
                statu_respService = statu_resp_services.Text;

            }

            if (role_authentifier.Equals("Chef Service"))
            {


                gestion_demande.chercher_Demande_conge_emp(gridView3.GetRowCellValue(index, "ID_DEMANDE_CONGE").ToString(), out erreur, out deman, out exist);
                // MessageBox.Show(df_picker_resp_service.Value.ToShortDateString());
                //  MessageBox.Show(df_picker_resp_service.Text);


                Demande_Conge_Class demandeclass1 = new Demande_Conge_Class(gridView3.GetRowCellValue(index, "ID_DEMANDE_CONGE").ToString(), Convert.ToDateTime(date_debut__validation_picker.Value.ToShortDateString()), Convert.ToDateTime(date_fin__validation_picker.Value.ToShortDateString()), hdebut_validation.Text, hfin_validation.Text, Convert.ToDateTime(deman.Date_Demande.ToShortDateString()), motif_var, deman.MATRICULE, deman.ID_Conger, "Non Encore Traité par GRH", Convert.ToDecimal(nbjour__validation.Text), Convert.ToDateTime(db_picker_resp_service.Value.ToString("dd-MM-yyyy")), Convert.ToDateTime(df_picker_resp_serviceSSSS.Value.ToString("dd-MM-yyyy")), hd__resp_service.Text, hf_resp_service.Text, statu_respService, Convert.ToDateTime(db_picker_res_depar.Value.ToShortDateString()), Convert.ToDateTime(df_res_depar.Value.ToShortDateString()), "00:00", "00:00", " ");

                gestion_demande.modifier_DEMANDE_CONGE(demandeclass1, out erreur);
                if (erreur == null)
                {
                    viderchamps_Validation();
                    gridView3.DeleteRow(index);
                    MessageBox.Show("Premier avis du Chef Service Avec succès");
                }
                else { MessageBox.Show("Erreur Auprés du Chef Service" + erreur); }


            }
            else if (role_authentifier.Equals("Chef Departement"))
            {





                status_res_depar.Text = "";

                gestion_demande.chercher_Demande_conge_emp(gridView3.GetRowCellValue(index, "ID_DEMANDE_CONGE").ToString(), out erreur, out deman, out exist);

                Demande_Conge_Class demandeclass = new Demande_Conge_Class(gridView3.GetRowCellValue(index, "ID_DEMANDE_CONGE").ToString(), Convert.ToDateTime(date_debut__validation_picker.Value.ToShortDateString()), Convert.ToDateTime(date_fin__validation_picker.Value.ToShortDateString()), hdebut_validation.Text, hfin_validation.Text, deman.Date_Demande, motif_var, deman.MATRICULE + "", deman.ID_Conger + "", "Non Encore Traité par GRH", Convert.ToDecimal(nbjour__validation.Text), Convert.ToDateTime(db_picker_resp_service.Value.ToString("dd-MM-yyyy")), Convert.ToDateTime(df_picker_resp_serviceSSSS.Value.ToString("dd-MM-yyyy")), hd__resp_service.Text, hf_resp_service.Text, statu_respService, Convert.ToDateTime(db_picker_res_depar.Value.ToShortDateString()), Convert.ToDateTime(df_res_depar.Value.ToShortDateString()), hd_res_depar.Text, hf_res_depar.Text, statu_respDepar);

                gestion_demande.modifier_DEMANDE_CONGE(demandeclass, out erreur);


                if (erreur == null)
                {
                    viderchamps_Validation();
                    gridView3.DeleteRow(index);
                    MessageBox.Show("Deuxième avis du Chef Du Département Avec succès");
                }
                else { MessageBox.Show("Erreur Auprés du Chef Département" + erreur); }
            }
            else
            {

                gestion_demande.chercher_Demande_conge_emp(gridView3.GetRowCellValue(index, "ID_DEMANDE_CONGE").ToString(), out erreur, out deman, out exist);
                // Demande_Conge_Class demandeclass = new Demande_Conge_Class(gridView3.GetRowCellValue(index, "ID_DEMANDE_CONGE").ToString(), Convert.ToDateTime(date_debut_picker_supervisier_validation.Value.ToShortDateString()), Convert.ToDateTime(date_fin_picker_supervisier_validation.Value.ToShortDateString()), hd_picker_supervisier_validation.Text, hf_picker_supervisier_validation.Text, deman.Date_Demande, motif_var, deman.MATRICULE + "", deman.ID_Conger + "", "Accepter Par le GRH", Convert.ToDecimal(nbjourvalide_supervisueru.Text), Convert.ToDateTime(db_picker_resp_service.Value.ToShortTimeString()), Convert.ToDateTime(df_picker_resp_serviceSSSS.Value.ToShortTimeString()), hd__resp_service.Text, hf_resp_service.Text, statu_respService, Convert.ToDateTime(db_picker_res_depar.Value.ToShortDateString()), Convert.ToDateTime(df_res_depar.Value.ToShortDateString()), hd_res_depar.Text, hf_res_depar.Text, statu_respDepar);
                Demande_Conge_Class demandeclass = new Demande_Conge_Class(gridView3.GetRowCellValue(index, "ID_DEMANDE_CONGE").ToString(), Convert.ToDateTime(date_debut_picker_supervisier_validation.Value.ToShortDateString()), Convert.ToDateTime(date_fin_picker_supervisier_validation.Value.ToShortDateString()), hd_picker_supervisier_validation.Text, hf_picker_supervisier_validation.Text, deman.Date_Demande, motif_var, deman.MATRICULE + "", deman.ID_Conger + "", motif_final.Text, Convert.ToDecimal(nbjourvalide_supervisueru.Text), Convert.ToDateTime(db_picker_resp_service.Value.ToShortTimeString()), Convert.ToDateTime(df_picker_resp_serviceSSSS.Value.ToShortTimeString()), hd__resp_service.Text, hf_resp_service.Text, statu_respService, Convert.ToDateTime(db_picker_res_depar.Value.ToShortDateString()), Convert.ToDateTime(df_res_depar.Value.ToShortDateString()), hd_res_depar.Text, hf_res_depar.Text, statu_respDepar);

                gestion_demande.modifier_DEMANDE_CONGE(demandeclass, out erreur);

                gestion_titreconge gestion_titre = new gestion_titreconge();
                titre_conge tit = new titre_conge("titre" + gridView3.GetRowCellValue(index, "ID_DEMANDE_CONGE").ToString(), gridView3.GetRowCellValue(index, "ID_DEMANDE_CONGE").ToString());
                gestion_titre.ajouter_Titre(tit, out erreur);
                if (erreur != null)
                {
                    MessageBox.Show("erreur titre de conge" + erreur);
                }
                if (nbjourvalide_supervisueru.Text != "")


                {

                    if (miseajourconge.Equals("Non"))
                    {
                        MessageBox.Show("Congé Avec Succés ( Sans Solde ) ");
                        gridView3.DeleteRow(index);

                    }
                    else
                    {
                        HISTORIQUE_CONGE histo;
                        gestion_historique_emp_conge.chercher_Historique_conge_emp(gridView3.GetRowCellValue(index, "MATRICULE").ToString(), Convert.ToString(DateTime.Now.Year), out erreur, out histo, out exist);
                        decimal nombrejourrrrPris = histo.Pris_anner_courant;
                        nombrejourrrrPris = Convert.ToDecimal(nombrejourrrrPris + Convert.ToDecimal(nbjourvalide_supervisueru.Text));
                        HISTORIQUE_CONGE historique = new HISTORIQUE_CONGE(histo.Id_Historique + "", Convert.ToInt32(histo.Arrier_conge), histo.Droit_annner_courant, nombrejourrrrPris, DateTime.Now.Year.ToString(), "1", "1", "1", gridView3.GetRowCellValue(index, "MATRICULE").ToString());

                        gestion_historique_emp_conge.modifier_Personel_Historique(historique, out erreur);
                        if (erreur == null)
                        {

                            MessageBox.Show("Congé Avec succés");
                            gridView3.DeleteRow(index);

                        }
                        else MessageBox.Show(erreur + " hisot");
                        //  MessageBox.Show("v!" + Convert.ToInt32(histo.Arrier_conge) + "||||" + histo.Droit_annner_courant + "||||" + nombrejourrrrPris);
                    }



                }

                //}
                #endregion
            }
        }

        private void demande_baritem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            demand_dp.Show();
        }

        private void validaiton_navbar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            vallidation_dp.Show();
        }
        String role_authentifier = "";

        public void remplirDGService(String id_cong, DevExpress.XtraGrid.GridControl dg)
        {

            sqlconnection = new OracleConnection(ConnectionString);
            String Query = " select e.MATRICULE,e.NOM,e.PRENOM,dc.ID_CONGE,dc.ID_DEMANDE_CONGE from  EMPLOYE e,  DEMANDE_CONGE dc where e.MATRICULE=dc.MATRICULE and dc.STATUS_RESPONSABLE_SERVICE = ' '   and e.SERVICE = '" + sv + "' ";
            //      String Query = "select e.MATRICULE,e.NOM,e.PRENOM,dc.ID_CONGE,dc.ID_DEMANDE_CONGE from  EMPLOYE e , DEMANDE_CONGE dc where e.MATRICULE=dc.MATRICULE and dc.STATUS='Non Encore Traité par GRH' ";

            // e.MATRICULE = dc.MATRICULE and
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
        }


        public void remplirDGDepartement(String id_cong, DevExpress.XtraGrid.GridControl dg)
        {
            sqlconnection = new OracleConnection(ConnectionString);
            String Query = " select e.MATRICULE,e.NOM,e.PRENOM,dc.ID_CONGE,dc.ID_DEMANDE_CONGE from  EMPLOYE e,  DEMANDE_CONGE dc where e.MATRICULE = dc.MATRICULE and dc.STATUS_RESPONSABLE_DEPARTEMENT = ' ' and e.Departement = '" + dep + "' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
        }


        private void validation_ActivePanelChanged(object sender, ActivePanelChangedEventArgs e)
        {
            // aa
            if (vallidation_dp.IsMdiDocument == true)
            {
                // qdsqsdqd
                if (Role.Equals("GRH"))
                {
                    role_authentifier = "GRH";
                    nbjour_service.Text = "0";
                    nbjourdepar.Text = "0";
                    remplirDG0("", Dgvalidation);

                }
                else if (Role.Equals("Chef Service"))
                {

                    db_picker_res_depar.Enabled = false;
                    df_res_depar.Enabled = false;
                    hd_res_depar.ReadOnly = true;
                    hf_res_depar.ReadOnly = true;
                    date_debut_picker_supervisier_validation.Enabled = false;
                    date_fin_picker_supervisier_validation.Enabled = false;
                    hd_picker_supervisier_validation.ReadOnly = true;
                    hf_picker_supervisier_validation.ReadOnly = true;
                    role_authentifier = "Chef Service";
                    // Validationsupervisuer.Caption = "Enovyer Vers Chef Departement";
                    nbjourdepar.ReadOnly = true;
                    status_res_depar.ReadOnly = true;
                    nbjourvalide_supervisueru.ReadOnly = true;

                    remplirDGService("", Dgvalidation);

                }
                else if (Role.Equals("Chef Departement"))
                {
                    nbjourvalide_supervisueru.ReadOnly = true;
                    db_picker_resp_service.Enabled = false;
                    df_picker_resp_serviceSSSS.Enabled = false;
                    hf_resp_service.ReadOnly = true;
                    hd__resp_service.ReadOnly = true;
                    date_debut_picker_supervisier_validation.Enabled = false;
                    date_fin_picker_supervisier_validation.Enabled = false;
                    hd_picker_supervisier_validation.ReadOnly = true;
                    hf_picker_supervisier_validation.ReadOnly = true;
                    statu_resp_services.ReadOnly = true;
                    nbjour_service.ReadOnly = true;
                    role_authentifier = "Chef Departement";
                    //    Validationsupervisuer.Caption = "Enovyer Vers Chef GRH";
                    remplirDGDepartement("", Dgvalidation);

                }

            }

        }


        private void chefiher_CheckedChanged(object sender, EventArgs e)
        {
            String codde = "";
            try
            {
                gestion_department.chercher_Departement_retour_code(comb_depar.Text, out erreur, out codde, out exist);
                String nn = ""; int ss = 0; String rsp = "";
                gestion_department.chercher_Departement3(codde, out erreur, out nn, out ss, out rsp, out exist);
                if (rsp != "")
                {
                    chef_dep.Checked = false;
                    XtraMessageBox.Show("Il existe déja un Responsable pour Département :" + comb_depar.Text);
                }

            }
            catch (Exception exc)
            {

            }
        }

        private void datenais_ValueChanged_1(object sender, EventArgs e)
        {
            #region calcul nbjour
            string strDate = DateTime.Today.ToString("dd-MM-yyyy");
            string[] arrDate = strDate.Split('-');
            string year = arrDate[2].ToString();
            string datenaiss = datenais.Value.ToString("yyyy-MM-dd");
            age.Visible = true;
            age_label.Visible = true;
            age.Text = (Convert.ToInt32(year) - Convert.ToInt32(datenaiss.Substring(0, 4).ToString())).ToString();
            #endregion
        }

        private void db_picker_resp_service_ValueChanged(object sender, EventArgs e)
        {
            nbjour_service.Text = (Math.Round(CalculerNombreJour(hf_resp_service, hd__resp_service, db_picker_resp_service, df_picker_resp_serviceSSSS), 2) + "");

        }

        private void hd__resp_service_EditValueChanged(object sender, EventArgs e)
        {
            nbjour_service.Text = (Math.Round(CalculerNombreJour(hd__resp_service, hf_resp_service, db_picker_resp_service, df_picker_resp_serviceSSSS), 2) + "");

        }

        private void hf_resp_service_EditValueChanged(object sender, EventArgs e)
        {
            nbjour_service.Text = (Math.Round(CalculerNombreJour(hd__resp_service, hf_resp_service, db_picker_resp_service, df_picker_resp_serviceSSSS), 2) + "");

        }

        private void df_picker_resp_service_ValueChanged(object sender, EventArgs e)
        {
            //nbjour_service.Text = (Math.Round(CalculerNombreJour(hd__resp_service, hf_resp_service, db_picker_resp_service, df_picker_resp_serviceSSSS), 2) + "");

            enter = true;

            #region datatimepicker leave when there is a day sunday or saturday 

            type_conge type = new type_conge();

            entreprise_class ent = new entreprise_class();

            gestion_entpreise.chercher_entreprise(idd, out erreur, out ent, out exist);
            String repot1 = ent.Repot1 + "";
            String repot2 = ent.Repot2 + "";
            DateTime debutt = DateTime.Parse(db_picker_resp_service.Text);
            DateTime finnn = DateTime.Parse(df_picker_resp_serviceSSSS.Text);
            var culture = new System.Globalization.CultureInfo("fr-Fr");
            var day = culture.DateTimeFormat.GetDayName(df_picker_resp_serviceSSSS.Value.DayOfWeek);
            if (day.Equals(ent.Repot1) || day.Equals(ent.Repot2))
            {
                MessageBox.Show(
                   "Illogique ! tu veux congé en jour non ouvrable ",
                   "Avertissement ",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation //For Info Asterisk

                 );
            }
            else if (df_picker_resp_serviceSSSS.Value.Date < db_picker_resp_service.Value.Date)
            {

                MessageBox.Show(
                  "Date Debut de Congé Doit Etre inférieur ou Egal Au Date Fin congé ",
                  "Avertissement ",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning //For Info Asterisk

                );

            }
            else
            {

                int nbj = 0;

                List<String> listjour = new List<string>();
                for (DateTime current = debutt; current <= finnn; current = current.AddDays(1))
                {
                    listjour.Add(culture.DateTimeFormat.GetDayName(current.DayOfWeek) + "");

                }




                try
                {
                    gestion_typeconge.chercher_Type_conge_Valider(type_conge_h_validation.Text, out erreur, out type, out exist);

                }
                catch (Exception ex)
                {/*
                    Simple_Fenetre.Type_Conge_datagridview dtype = new Type_Conge_datagridview();


                    dtype.Show();
                    button_Typeconge_WasClicked = true;
                    remplirDG("TYPE_CONGE", "", Type_Conge_datagridview.datagridtypeconge.DgTypeconge);
                    dtype.Show();*/
                }
                double nn0 = 0;
                for (int i = 0; i < listjour.Count; i++)
                {
                    if (repot1.Equals(listjour.ElementAt(i)))
                        //   listjour.RemoveAt(i);
                        nn0 += 1;
                    if (repot2.Equals(listjour.ElementAt(i)))
                        // listjour.RemoveAt(i);
                        nn0 += 1;

                }
                if (type.JourOuvrable.Equals("Oui"))

                {
                    if (!(day.Equals(repot1) || day.Equals(repot2)))
                    {
                      //  MessageBox.Show("9adeh men nhar" + nn0);
                        nbjour_service.Text = Math.Round((CalculerNombreJour(hf_resp_service, hd__resp_service, db_picker_resp_service, df_picker_resp_serviceSSSS) - nn0), 2) + "";
                    }
                    else
                    {
                        nbjour_service.Text = Math.Round(CalculerNombreJour(hf_resp_service, hd__resp_service, db_picker_resp_service, df_picker_resp_serviceSSSS) - nn0, 2) + "";

                    }



                }
                else
                {
                    nbjour_service.Text = Convert.ToString(CalculerNombreJour(hf_resp_service, hd__resp_service, db_picker_resp_service, df_picker_resp_serviceSSSS));

                }

            }
            #endregion
        }

        private void db_picker_res_depar_ValueChanged(object sender, EventArgs e)
        {
            nbjourdepar.Text = (Math.Round(CalculerNombreJour(hd_res_depar, hf_res_depar, db_picker_res_depar, df_res_depar), 2) + "");
        }

        private void hd_res_depar_EditValueChanged(object sender, EventArgs e)
        {
            nbjourdepar.Text = (Math.Round(CalculerNombreJour(hd_res_depar, hf_res_depar, db_picker_res_depar, df_res_depar), 2) + "");
        }

        private void hf_res_depar_EditValueChanged(object sender, EventArgs e)
        {
            nbjourdepar.Text = (Math.Round(CalculerNombreJour(hd_res_depar, hf_res_depar, db_picker_res_depar, df_res_depar), 2) + "");

        }

        private void df_res_depar_ValueChanged(object sender, EventArgs e)
        {
            enter = true;

            #region datatimepicker leave when there is a day sunday or saturday 

            type_conge type = new type_conge();

            entreprise_class ent = new entreprise_class();

            gestion_entpreise.chercher_entreprise(idd, out erreur, out ent, out exist);
            String repot1 = ent.Repot1 + "";
            String repot2 = ent.Repot2 + "";
            DateTime debutt = DateTime.Parse(db_picker_res_depar.Text);
            DateTime finnn = DateTime.Parse(df_res_depar.Text);
            var culture = new System.Globalization.CultureInfo("fr-Fr");
            var day = culture.DateTimeFormat.GetDayName(df_res_depar.Value.DayOfWeek);
            if (day.Equals(ent.Repot1) || day.Equals(ent.Repot2))
            {
                MessageBox.Show(
                   "Illogique ! tu veux congé en jour non ouvrable ",
                   "Avertissement ",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation //For Info Asterisk

                 );
            }
            else if (df_res_depar.Value.Date < db_picker_res_depar.Value.Date)
            {

                MessageBox.Show(
                  "Date Debut de Congé Doit Etre inférieur ou Egal Au Date Fin congé ",
                  "Avertissement ",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning //For Info Asterisk

                );

            }
            else
            {

                int nbj = 0;

                List<String> listjour = new List<string>();
                for (DateTime current = debutt; current <= finnn; current = current.AddDays(1))
                {
                    listjour.Add(culture.DateTimeFormat.GetDayName(current.DayOfWeek) + "");

                }




                try
                {
                    gestion_typeconge.chercher_Type_conge_Valider(type_conge_h_validation.Text, out erreur, out type, out exist);

                }
                catch (Exception ex)
                {
                }
                double nn0 = 0;
                for (int i = 0; i < listjour.Count; i++)
                {
                    if (repot1.Equals(listjour.ElementAt(i)))
                        //   listjour.RemoveAt(i);
                        nn0 += 1;
                    if (repot2.Equals(listjour.ElementAt(i)))
                        // listjour.RemoveAt(i);
                        nn0 += 1;

                }
                if (type.JourOuvrable.Equals("Oui"))

                {
                    if (!(day.Equals(repot1) || day.Equals(repot2)))
                    {
                        //  MessageBox.Show("9adeh men nhar" + nn0);
                        nbjourdepar.Text = Math.Round((CalculerNombreJour(hf_res_depar, hd_res_depar, db_picker_res_depar, df_res_depar) - nn0), 2) + "";
                    }
                    else
                    {
                        nbjourdepar.Text = Math.Round((CalculerNombreJour(hf_res_depar, hd_res_depar, db_picker_res_depar, df_res_depar) - nn0), 2) + "";

                    }



                }
                else
                {
                    // nbjourdepar.Text = Convert.ToString(CalculerNombreJour(hf_resp_service, hd__resp_service, db_picker_resp_service, df_picker_resp_serviceSSSS));
                    nbjourdepar.Text = Convert.ToString(CalculerNombreJour(hf_res_depar, hd_res_depar, db_picker_res_depar, df_res_depar));

                }

            }
            #endregion

        }


        private void sommehisto_TextChanged(object sender, EventArgs e)
        {
            if (sommehisto.Text.Equals("5") || sommehisto.Text.Equals("4") || sommehisto.Text.Equals("3") || sommehisto.Text.Equals("2") || sommehisto.Text.Equals("1"))
            {
                sommehisto.ForeColor = Color.Red;
            }

        }

        private void sommehisto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                sommehisto.ForeColor = Color.Black;

            }
        }


        private void veriferservice_Click(object sender, EventArgs e)
        {

            disponibilité ds = new disponibilité(Convert.ToDateTime(db_picker_resp_service.Value.ToString("dd-MM-yyyy")), Convert.ToDateTime(df_picker_resp_serviceSSSS.Value.ToString("dd-MM-yyyy")), sv);
            ds.Show();
        }


        private void verifierdepar_Click(object sender, EventArgs e)
        {
            Disponibilité_Département dp = new Disponibilité_Département(Convert.ToDateTime(date_debut__validation_picker.Value.ToString("dd-MM-yyyy")), Convert.ToDateTime(date_fin__validation_picker.Value.ToString("dd-MM-yyyy")), dep);
            dp.Show();
        }

        public bool button_Employer_Depart_Responsable_WasClicked = false;
        public void remplirDG_Departement(DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select * from employe e where  not  exists (select 1 from  departement  where MATRICULE=REPONSABLE_DEP   )";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employer_datagridview le = new Employer_datagridview();
            button_Employer_Depart_Responsable_WasClicked = true;
            le.Show();
            remplirDG_Departement(Employer_datagridview.edd.Dgpersonel);
        }

        private void dep_navbar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            dep_dockpanel.Show();
        }

        private void sv_navbar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            service_dockpanel.Show();
        }

        private void ajouter_dep_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region Ajouter Departement

            if (code_dep.Text == "")
            {
                MessageBox.Show("Code Département obligatoire !");

            }
            else if (lib_depar.Text == "")
            {
                MessageBox.Show("Libélle Département obligatoire !");

            }
            /*     else if (cin_dep.Text == "")
                 {
                     MessageBox.Show("Tu Doit Affécter un Employé au Département !");

                 }*/

            else
            {
                String mat_departement;
                if (mat_dep.Text == "")
                {
                    mat_departement = null;

                }
                else
                {
                    mat_departement = mat_dep.Text;
                }

                Departement_Class dep = new Departement_Class(code_dep.Text, lib_depar.Text, mat_departement, Convert.ToInt32(seuil_dep.Text));
                gestion_department.ajouter_DEPARTEMENT(dep, out erreur);
                if (erreur == null)
                {
                    MessageBox.Show("L'ajout du département avec succés " + nom_dep.Text + " a été affecté avec succès");
                }

                else
                {
                    MessageBox.Show("Erreur Depar" + erreur);
                }
            }




            #endregion
        }
        public void remplirDG8(DataGridView dg)
        {

            sqlconnection = new OracleConnection(ConnectionString);
            String Query = "select e.MATRICULE,e.NOM,e.PRENOM,dc.ID_CONGE,dc.ID_DEMANDE_CONGE from  EMPLOYE e , DEMANDE_CONGE dc where e.MATRICULE=dc.MATRICULE and dc.STATUS !='Non Encore Traité par GRH'  ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
        }

        private void list_emp_acppter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Simple_Fenetre.ListeDesDemandeconge ldddc = new Simple_Fenetre.ListeDesDemandeconge();
            ldddc.Show();
        }

        private void refus_supervisueur_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
               #region valider_demander_superviser_ItemClick
            int random = (new Random()).Next(100, 1000);

            #region delc date
            /* string DateDebut_conger_ongle_valider_congerr = date_debut_picker_supervisier_validation.Value.ToShortTimeString();
             string Datefin_conger_ongle_valider_congerr = date_fin_picker_supervisier_validation.Value.ToShortTimeString();
             string[] datedeb = DateDebut_conger_ongle_valider_congerr.Split('/');
             string[] datefin = Datefin_conger_ongle_valider_congerr.Split('/');

             string debut_year = datedeb[0].ToString();
             string fin_year = datedeb[0].ToString();
             string debut_month = datedeb[1].ToString();
             string fin_month = datedeb[1].ToString();

             string debut_day = datedeb[2].ToString();
             string fin_day = datedeb[2].ToString();

             //Heur 
             string[] heurdebut = hd.Text.Split('-');
             string[] heurfin = hf.Text.Split('-');*/
            #endregion

            #region test
            int index = gridView3.FocusedRowHandle;

            /* if (Convert.ToInt32(DateTime.Now.Year.ToString()) > Convert.ToInt32(debut_year))
              {
                  MessageBox.Show("Date de Demande de Congé Doit Etre supérieur Au Date : " + DateTime.Now.Year.ToString());
              }
              else if (Convert.ToInt32(DateTime.Now.Month.ToString()) > Convert.ToInt32(debut_month.ToString()))
              {
                  MessageBox.Show("Date de Demande de Congé Doit Etre supérieur Au Date : " + DateTime.Now.Month.ToString());
              }

              else if (Convert.ToInt32(debut_year) > Convert.ToInt32(fin_year))
              {
                  MessageBox.Show("Fin Congé Doit étre supérieur Ou égal Au Date Debut congé ");
              }
              else
              {*/
            DateTime debbb = DateTime.Parse(this.date_debut_picker_supervisier_validation.Text);
            DateTime finnn = DateTime.Parse(this.date_fin_picker_supervisier_validation.Text);
            String heur_debut = "";
            String heur_fin = "";
            if (hd_picker_supervisier_validation.Text.Equals("00:00"))
            {
                heur_debut = "0";
            }
            else
            {
                heur_debut = hd_picker_supervisier_validation.Text;
            }
            if (hf_picker_supervisier_validation.Text.Equals("00:00"))
            {
                heur_fin = "0";
            }
            else { heur_fin = hf_picker_supervisier_validation.Text; }
            #endregion

            Demande_Conge_Class deman;
            String motif_var = "";
            if (motfi_validation.Text == "")
            {
                motif_var = "Aucune Motif ! ";
            }
            else
            {
                motif_var = motfi_validation.Text;
            }
            String statu_respDepar = "";
            if (status_res_depar.Text == "" || status_res_depar.Text == " ")
            {
                statu_respDepar = "Deuxième avis du Chef Du Département Avec un refus";

            }
            else
            {
                statu_respDepar = status_res_depar.Text;

            }


            String statu_respService = "";
            if (statu_resp_services.Text == "")
            {
                statu_respService = "Premier avis du Chef Service Avec un refus";

            }
            else
            {
                statu_respService = statu_resp_services.Text;

            }

            if (role_authentifier.Equals("Chef Service"))
            {


                gestion_demande.chercher_Demande_conge_emp(gridView3.GetRowCellValue(index, "ID_DEMANDE_CONGE").ToString(), out erreur, out deman, out exist);


                Demande_Conge_Class demandeclass1 = new Demande_Conge_Class(gridView3.GetRowCellValue(index, "ID_DEMANDE_CONGE").ToString(), Convert.ToDateTime(date_debut__validation_picker.Value.ToShortDateString()), Convert.ToDateTime(date_fin__validation_picker.Value.ToShortDateString()), hdebut_validation.Text, hfin_validation.Text, Convert.ToDateTime(deman.Date_Demande.ToShortDateString()), motif_var, deman.MATRICULE, deman.ID_Conger, "Non Encore Traité par GRH", Convert.ToDecimal(nbjour__validation.Text), Convert.ToDateTime(db_picker_resp_service.Value.ToString("dd-MM-yyyy")), Convert.ToDateTime(df_picker_resp_serviceSSSS.Value.ToString("dd-MM-yyyy")), hd__resp_service.Text, hf_resp_service.Text, statu_respService, Convert.ToDateTime(db_picker_res_depar.Value.ToShortDateString()), Convert.ToDateTime(df_res_depar.Value.ToShortDateString()), "00:00", "00:00", " ");

                gestion_demande.modifier_DEMANDE_CONGE(demandeclass1, out erreur);
                if (erreur == null)
                {
                    viderchamps_Validation();
                    gridView3.DeleteRow(index);
                    MessageBox.Show("Premier avis du Chef Service Avec un Refus");
                }
                else { MessageBox.Show("Erreur Auprés du Chef Service" + erreur); }


            }
            else if (role_authentifier.Equals("Chef Departement"))
            {
                status_res_depar.Text = "";

                gestion_demande.chercher_Demande_conge_emp(gridView3.GetRowCellValue(index, "ID_DEMANDE_CONGE").ToString(), out erreur, out deman, out exist);

                Demande_Conge_Class demandeclass = new Demande_Conge_Class(gridView3.GetRowCellValue(index, "ID_DEMANDE_CONGE").ToString(), Convert.ToDateTime(date_debut__validation_picker.Value.ToShortDateString()), Convert.ToDateTime(date_fin__validation_picker.Value.ToShortDateString()), hdebut_validation.Text, hfin_validation.Text, deman.Date_Demande, motif_var, deman.MATRICULE + "", deman.ID_Conger + "", "Non Encore Traité par GRH", Convert.ToDecimal(nbjour__validation.Text), Convert.ToDateTime(db_picker_resp_service.Value.ToString("dd-MM-yyyy")), Convert.ToDateTime(df_picker_resp_serviceSSSS.Value.ToString("dd-MM-yyyy")), hd__resp_service.Text, hf_resp_service.Text, statu_respService, Convert.ToDateTime(db_picker_res_depar.Value.ToShortDateString()), Convert.ToDateTime(df_res_depar.Value.ToShortDateString()), hd_res_depar.Text, hf_res_depar.Text, statu_respDepar);

                gestion_demande.modifier_DEMANDE_CONGE(demandeclass, out erreur);


                if (erreur == null)
                {
                    viderchamps_Validation();
                    gridView3.DeleteRow(index);
                    MessageBox.Show("Deuxième avis du Chef Du Département Avec un Refus");
                }
                else { MessageBox.Show("Erreur Auprés du Chef Département" + erreur); }
            }
            else
            {
                MessageBox.Show("GRH + " + role_authentifier + "   " + motif_faaa.Text);
                   gestion_demande.chercher_Demande_conge_emp(gridView3.GetRowCellValue(index, "ID_DEMANDE_CONGE").ToString(), out erreur, out deman, out exist);
                // Demande_Conge_Class demandeclass = new Demande_Conge_Class(gridView3.GetRowCellValue(index, "ID_DEMANDE_CONGE").ToString(), Convert.ToDateTime(date_debut_picker_supervisier_validation.Value.ToShortDateString()), Convert.ToDateTime(date_fin_picker_supervisier_validation.Value.ToShortDateString()), hd_picker_supervisier_validation.Text, hf_picker_supervisier_validation.Text, deman.Date_Demande, motif_var, deman.MATRICULE + "", deman.ID_Conger + "",motif_final.Text, Convert.ToDecimal(nbjourvalide_supervisueru.Text), Convert.ToDateTime(db_picker_resp_service.Value.ToShortTimeString()), Convert.ToDateTime(df_picker_resp_serviceSSSS.Value.ToShortTimeString()), hd__resp_service.Text, hf_resp_service.Text, statu_respService, Convert.ToDateTime(db_picker_res_depar.Value.ToShortDateString()), Convert.ToDateTime(df_res_depar.Value.ToShortDateString()), hd_res_depar.Text, hf_res_depar.Text, statu_respDepar);

                Demande_Conge_Class demandeclass = new Demande_Conge_Class(gridView3.GetRowCellValue(index, "ID_DEMANDE_CONGE").ToString(), Convert.ToDateTime(date_debut_picker_supervisier_validation.Value.ToShortDateString()), Convert.ToDateTime(date_fin_picker_supervisier_validation.Value.ToShortDateString()), hd_picker_supervisier_validation.Text, hf_picker_supervisier_validation.Text, deman.Date_Demande, motif_var, deman.MATRICULE + "", deman.ID_Conger + "", motif_faaa.Text, Convert.ToDecimal(nbjourvalide_supervisueru.Text), Convert.ToDateTime(db_picker_resp_service.Value.ToShortTimeString()), Convert.ToDateTime(df_picker_resp_serviceSSSS.Value.ToShortTimeString()), hd__resp_service.Text, hf_resp_service.Text, statu_respService, Convert.ToDateTime(db_picker_res_depar.Value.ToShortDateString()), Convert.ToDateTime(df_res_depar.Value.ToShortDateString()), hd_res_depar.Text, hf_res_depar.Text, statu_respDepar);

                gestion_demande.modifier_DEMANDE_CONGE(demandeclass, out erreur);

                if (erreur == null)
                {
                    MessageBox.Show("good");
                }
                else MessageBox.Show(erreur);

                Lettre_Refus refus = new Lettre_Refus("Refus_"+gridView3.GetRowCellValue(index, "ID_DEMANDE_CONGE").ToString(), gridView3.GetRowCellValue(index, "ID_DEMANDE_CONGE").ToString());
                gestion_LettreRefus gestion_refus = new gestion_LettreRefus();
                gestion_refus.ajouter_Rejet(refus, out erreur);
                if (erreur != null)
                {
                    MessageBox.Show("Lettre refus erreur" + erreur);
                }

                gridView3.DeleteRow(index);

                #endregion
            }
        }

        private void modifier_dep_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region Ajouter Departement

            if (code_dep.Text == "")
            {
                MessageBox.Show("Code Département obligatoire !");

            }
            else if (lib_depar.Text == "")
            {
                MessageBox.Show("Libélle Département obligatoire !");

            }
            else if (cin_dep.Text == "")
            {
                MessageBox.Show("Tu Doit Affécter un Employé au Département !");

            }

            else
            {
                Departement_Class dep = new Departement_Class(code_dep.Text, lib_depar.Text, mat_dep.Text, Convert.ToInt32(seuil_dep.Text));
                gestion_department.modifier_DEPARTEMENT(dep, out erreur);
                if (erreur == null)
                {
                    MessageBox.Show("L'ajout du département avec succés " + nom_dep.Text + " a été affecté avec succès");
                }

                else
                {
                    MessageBox.Show("Erreur Depar" + erreur);
                }
            }




            #endregion
        }


        private void ajouter_service_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region Ajouter Service

            if (code_service.Text == "")
            {
                MessageBox.Show("Code Service obligatoire !");

            }
            else if (liblle_service.Text == "")
            {
                MessageBox.Show("Libélle Service obligatoire !");

            }
            else if (cin_emp_sv.Text == "")
            {
                MessageBox.Show("Tu Doit Affécter un Employé au Service !");

            }

            else
            {
                Services_Class serv = new Services_Class(code_service.Text, liblle_service.Text, code_derppp.Text, mat_emp_sv.Text, Convert.ToInt32(seuill_sv.Text));
                gestion_servie.ajouter_Service(serv, out erreur);
                if (erreur == null)
                {
                    MessageBox.Show("L'ajout du Service avec succés ");
                }

                else
                {
                    MessageBox.Show("Erreur Dans Service" + erreur);
                }
            }




            #endregion
        }

        public bool button_Employer_Service_Responsable_WasClicked = false;
        public void remplirDG_Service(DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select * from employe e where not  exists (select 1 from  SERVICE where MATRICULE =RESPONSABLe_service   )";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }


        private void resp_service_Click(object sender, EventArgs e)
        {

            Employer_datagridview le = new Employer_datagridview();
            button_Employer_Service_Responsable_WasClicked = true;
            le.Show();
            remplirDG_Service(Employer_datagridview.edd.Dgpersonel);

        }
        public void remplirDG_Service_Departement(DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select * from departement"; // e where not  exists (select 1 from  SERVICE where MATRICULE =RESPONSABLe_service   )";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        private void service_dep_affecter_Click(object sender, EventArgs e)
        {

            Departements le = new Departements();
            //button_Employer_Service_Responsable_WasClicked = true;
            le.Show();
            remplirDG_Service_Departement(Departements.edd.depar_grid);
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void cin_EditValueChanged(object sender, EventArgs e)
        {
            #region cin remplir tout fil simple utlilisateur
            if (Role.Equals("Simple Utilisateur"))
            {

                try
                {
                    String libellefn = "";

                    gestion_Departement gd = new gestion_Departement();
                    gestion_Service gs = new gestion_Service();

                    String nomdep = "";
                    String nomserv = "";
                    int xx1;
                    gs.chercher_Service3(sv, out erreur, out nomserv, out xx1, out exist);

                    int ss;
                    String s1;
                    gd.chercher_Departement3(dep, out erreur, out nomdep, out ss, out s1, out exist);
                    Gestion_Paie_Oracle.Menu.pr.comb_depar.Text = nomdep;
                    Gestion_Paie_Oracle.Menu.pr.comb_serv.Text = nomserv;


                    ajouter_salarie_item.Visibility = BarItemVisibility.Never;
                    supprimer_salarie_item.Visibility = BarItemVisibility.Never;
                    grindcontrol_liste.Visibility = BarItemVisibility.Never;
                    viderchamps.Visibility = BarItemVisibility.Never;
                    ribbonPageGroup2.Visible = false;
                    ribbonPageGroup1.Text = "Edition";
                    parametre_nav.Visible = false;
                    type_conge_bar.Visible = false;
                    validaiton_navbar.Visible = false;
                    historique_dg.Visible = false;

                    navBarGroup2.Visible = false;

                    comb_depar.Enabled = false;
                    comb_depar.BackColor = System.Drawing.SystemColors.Window;

                    comb_serv.Enabled = false;
                    comb_serv.BackColor = System.Drawing.SystemColors.Window;

                    chef_dep.Visible = false;
                    chef_sv.Visible = false;

                }
                catch (Exception ee)
                {

                }
            }
            #endregion
        }
        private void compte_navbar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Compte cpt = new Compte(matricule_emp);
            cpt.ShowDialog();

        }

        private void demand_ActivePanelChanged(object sender, ActivePanelChangedEventArgs e)
        {
            if (demand_dp.IsMdiDocument == true)
            {
                if (Role.Equals("Simple Utilisateur"))
                {
                    HISTORIQUE_CONGE hc;
                    String erreur = null;
                    Boolean exit = false;
                    gestion_historique_emp_conge.chercher_Historique_conge_emp(matricule_emp, Convert.ToString(DateTime.Now.Year), out erreur, out hc, out exit);
                    Gestion_Paie_Oracle.Menu.pr.arrierconge.Text = hc.Arrier_conge + "";

                    Gestion_Paie_Oracle.Menu.pr.droitannecourat.Text = hc.Droit_annner_courant + "";
                    Gestion_Paie_Oracle.Menu.pr.prisanne.Text = hc.Pris_anner_courant + "";
                    Gestion_Paie_Oracle.Menu.pr.sommehisto.Text = ((Convert.ToDecimal(Gestion_Paie_Oracle.Menu.pr.arrierconge.Text) + Convert.ToDecimal(Gestion_Paie_Oracle.Menu.pr.droitannecourat.Text)) - Convert.ToDecimal(Gestion_Paie_Oracle.Menu.pr.prisanne.Text)).ToString();
                    choisir_employer_btn.Enabled = false;
                    choisir_employer_btn.BackColor = System.Drawing.SystemColors.Window;


                }
            }
        }

        private void details_conge_employer_Click(object sender, EventArgs e)
        {
        }

        private void tabemploye_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabemploye.SelectedTab == tabemploye.TabPages["details_conge_employer"])//your specific tabname
            {
                #region remplir congé anner courante
                HISTORIQUE_CONGE histo;
                string nbjourdroit = "";
                string pris = "";
                string arrrier = "";
                // historique_dg.Columns[0].HeaderText = "Ajouter";
                Gestion_Paie_Oracle.Menu.pr.historique_dg.Columns[0].Width = 20;

                try
                {
                    gestion_historique_emp_conge.Droit_arrier_pris_conge_anner_precedent(Convert.ToString(DateTime.Now.Year), matricule_emp, out erreur, out nbjourdroit, out arrrier, out pris, out exist);
                    arrier_courant_employer.Text = arrrier;//histo.Arrier_conge + "";
                    droit_anner_employe.Text = nbjourdroit;//histo.Droit_annner_courant + "";
                    pris_anner_employe.Text = pris;// histo.Pris_anner_courant + "";
                    somme_hist_employe.Text = ((Convert.ToDecimal(arrier_courant_employer.Text) + Convert.ToDecimal(droit_anner_employe.Text)) - Convert.ToDecimal(pris_anner_employe.Text)).ToString();
                }
                catch (Exception ee)
                {

                }
                #endregion            }
            }
            else if (tabemploye.SelectedTab == tabemploye.TabPages["tabPage2"])//your specific tabname
            {
                #region remplir datagirdview list de  congé accpeter dans fiche personel
                remplirDG2(matricule_emp, Gestion_Paie_Oracle.Menu.pr.DgAlldemand);
                decimal summ = 0;
                decimal summ2 = 0;
                int index = gridView5.FocusedRowHandle;
                for (int i = 0; i < gridView5.RowCount; i++)
                {
                    if (gridView5.GetRowCellValue(index, "STATUS").ToString().Equals("Accepter Par le GRH"))
                    {
                        summ += Convert.ToDecimal(gridView5.GetRowCellValue(i, "NOMBREJOUR").ToString());
                        sommenbjour.Text = summ + "";
                    }
                    else
                    {
                        summ2 += Convert.ToDecimal(gridView5.GetRowCellValue(i, "NOMBREJOUR").ToString());
                        sommenbjour_nonacpter.Text = summ2 + "";

                    }

                }
                Gestion_Paie_Oracle.Menu.pr.gridView5.Columns[0].Caption = "Date Demande Congé";
                Gestion_Paie_Oracle.Menu.pr.gridView5.Columns[1].Caption = "Date Debut Congé";
                Gestion_Paie_Oracle.Menu.pr.gridView5.Columns[2].Caption = "Date Fin Congé";
                Gestion_Paie_Oracle.Menu.pr.gridView5.Columns[3].Caption = "Heur Debut Congé";
                Gestion_Paie_Oracle.Menu.pr.gridView5.Columns[4].Caption = "Heur Fin Congé";
                Gestion_Paie_Oracle.Menu.pr.gridView5.Columns[5].Caption = "Nombre de jours de congés pris";
                Gestion_Paie_Oracle.Menu.pr.gridView5.Columns[6].Caption = "Accepter||Refus";

                #endregion
            }
        }

        private void comb_depar_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            List<Services_Class> lisst1 = new List<Services_Class>();
            String codee = "";
            gestion_department.chercher_Departement_retour_code(comb_depar.Text, out erreur, out codee, out exist);
            gestion_servie.Chercher_ListService_Departement(codee, out erreur, out lisst1, out exist);

            foreach (Services_Class x1 in lisst1)
            {
                comb_serv.Items.Add(x1.DESG_Serv + "");
            }

        }

        private void comb_depar_Enter_1(object sender, EventArgs e)
        {
            comb_serv.Text = "";
        }


        private void barButtonItem54_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem55_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();

        }
        public void remplirDG_Fiche_Demande(String mat, DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir datagridview Fiche 
            sqlconnection = new OracleConnection(ConnectionString);
            //    String Query = "select distinct e.nom,e.prenom,e.matricule,fc.id_demande,fc.ID_FICHE  from EMPLOYE e , DEMANDE_CONGE dc,FICHE_CONGE fc where  exists (select 1 from DEMANDE_CONGE  where dc.MATRICULE=e.matricule )";

            String Query = "  select e.nom,e.prenom,dc.MATRICULE,dc.ID_DEMANDE_CONGE ,fc.ID_FICHE from EMPLOYE e, DEMANDE_CONGE dc,FICHE_CONGE fc where dc.MATRICULE = e.MATRICULE and fc.ID_DEMANDE = dc.ID_DEMANDE_CONGE";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }


        public void remplirDG_Fiche_Demande_SimpleUSER(String mat, DevExpress.XtraGrid.GridControl dg,String idd)
        {
            #region remplir datagridview Fiche 
            sqlconnection = new OracleConnection(ConnectionString);
            //    String Query = "select distinct e.nom,e.prenom,e.matricule,fc.id_demande,fc.ID_FICHE  from EMPLOYE e , DEMANDE_CONGE dc,FICHE_CONGE fc where  exists (select 1 from DEMANDE_CONGE  where dc.MATRICULE=e.matricule )";
           
            String Query = "  select e.nom,e.prenom,dc.MATRICULE,dc.ID_DEMANDE_CONGE ,fc.ID_FICHE from EMPLOYE e, DEMANDE_CONGE dc,FICHE_CONGE fc where dc.MATRICULE = e.MATRICULE and fc.ID_DEMANDE = dc.ID_DEMANDE_CONGE and e.matricule='"+idd+"' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }


        private void fiche_demande_conger_ItemClick(object sender, ItemClickEventArgs e)
        {
            String roll = this.Role;
            Liste_fiche_demandeconger ldddc = new Liste_fiche_demandeconger(roll);
            ldddc.Show();
            #region load
            if (Role.Equals("Simple Utilisateur"))
            {
                remplirDG_Fiche_Demande_SimpleUSER("", Liste_fiche_demandeconger.edd.gridControl1,this.matricule_emp);

            }
            else
            {
                MessageBox.Show("qqq");

                remplirDG_Fiche_Demande("", Liste_fiche_demandeconger.edd.gridControl1);

            }

            #endregion

        }

        private void stat_nav_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            stat_dockpanel.Show();
        }

        #region Remplissage datagrdivew stat

        public void remplirDG_stat_anner(DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select  employe.matricule, employe.nom, employe.prenom,extract(year from  demande_conge.date_demande) as Annee  from  employe , demande_conge    where   employe.matricule= demande_conge.matricule and to_char( demande_conge.date_demande,'yyyy')='" + picker1.Value.Year + "' ";

            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }
        public void remplirDG_stat_anner_accpeter(DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select  employe.matricule, employe.nom, employe.prenom,status,extract(year from  demande_conge.date_demande) as Annee   from  employe , demande_conge    where   employe.matricule= demande_conge.matricule and to_char( demande_conge.date_demande,'yyyy')='" + picker1.Value.Year + "' and status='Accepter Par le GRH' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }
        public void remplirDG_stat_anner_nonencoretraite(DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select  employe.matricule, employe.nom, employe.prenom ,status,extract(year from  demande_conge.date_demande) as Annee from  employe , demande_conge    where   employe.matricule= demande_conge.matricule and to_char( demande_conge.date_demande,'yyyy')='" + picker1.Value.Year + "'  and status='Non Encore Traité par GRH' ";

            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }
        public void remplirDG_stat_anner_refuser(DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select  employe.matricule, employe.nom, employe.prenom,status,extract(year from  demande_conge.date_demande) as Annee  from  employe , demande_conge    where   employe.matricule= demande_conge.matricule and to_char( demande_conge.date_demande,'yyyy')='" + picker1.Value.Year + "'  and status='Refuser Par le GRH' ";

            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        public void remplirDG_stat_entre2_date(DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select  employe.matricule, employe.nom, employe.prenom ,status,demande_conge.DATE_DEBUT_CONGE,demande_conge.DATE_FIN_CONGE from  employe , demande_conge    where   employe.matricule= demande_conge.matricule and  DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }
        public void remplirDG_stat_entre2_date_accepter(DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select  employe.matricule, employe.nom, employe.prenom ,status,demande_conge.DATE_DEBUT_CONGE,demande_conge.DATE_FIN_CONGE from  employe , demande_conge    where   employe.matricule= demande_conge.matricule and  DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "'  and STATUS = 'Accepter Par le GRH' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }
        public void remplirDG_stat_entre2_date_nonencoretarite(DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select  employe.matricule, employe.nom, employe.prenom ,Status,demande_conge.DATE_DEBUT_CONGE,demande_conge.DATE_FIN_CONGE from  employe , demande_conge    where   employe.matricule= demande_conge.matricule and  DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "' and status='Non Encore Traité par GRH' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }
        public void remplirDG_stat_entre2_date_refuser(DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select  employe.matricule, employe.nom, employe.prenom,Status ,demande_conge.DATE_DEBUT_CONGE,demande_conge.DATE_FIN_CONGE from  employe , demande_conge    where   employe.matricule= demande_conge.matricule and  DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "'        and status = 'Refuser Par le GRH' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }
        public void remplirDG_stat_service(String servicee, DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            //Query= "select  employe.matricule, employe.nom, employe.prenom ,demande_conge.DATE_DEBUT_CONGE,demande_conge.DATE_FIN_CONGE, service.DESIGNATION_SERVICE from  service,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.SERVICE = SERVICE.id_service and DATE_DEMANDE between '01/01/2017' and '01/01/2019' and service.DESIGNATION_SERVICE = 'Service Vente';"
            Query = "select  employe.matricule, employe.nom, employe.prenom , service.DESIGNATION_SERVICE as Service ,status from  service,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.SERVICE = SERVICE.id_service and service.DESIGNATION_SERVICE = '" + servicee + "' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        public void remplirDG_stat_service_nonencore(String servicee, DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            //Query= "select  employe.matricule, employe.nom, employe.prenom ,demande_conge.DATE_DEBUT_CONGE,demande_conge.DATE_FIN_CONGE, service.DESIGNATION_SERVICE from  service,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.SERVICE = SERVICE.id_service and DATE_DEMANDE between '01/01/2017' and '01/01/2019' and service.DESIGNATION_SERVICE = 'Service Vente';"
            Query = "select  employe.matricule, employe.nom, employe.prenom , service.DESIGNATION_SERVICE as Service,status from  service,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.SERVICE = SERVICE.id_service and service.DESIGNATION_SERVICE = '" + servicee + "' and status='Non Encore Traité par GRH' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        public void remplirDG_stat_service_refuser(String servicee, DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            //Query= "select  employe.matricule, employe.nom, employe.prenom ,demande_conge.DATE_DEBUT_CONGE,demande_conge.DATE_FIN_CONGE, service.DESIGNATION_SERVICE from  service,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.SERVICE = SERVICE.id_service and DATE_DEMANDE between '01/01/2017' and '01/01/2019' and service.DESIGNATION_SERVICE = 'Service Vente';"
            Query = "select  employe.matricule, employe.nom, employe.prenom , service.DESIGNATION_SERVICE as Service,status from  service,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.SERVICE = SERVICE.id_service and service.DESIGNATION_SERVICE = '" + servicee + "' and  status= 'Refuser Par le GRH' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        public void remplirDG_stat_service_accepter(String servicee, DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            //Query= "select  employe.matricule, employe.nom, employe.prenom ,demande_conge.DATE_DEBUT_CONGE,demande_conge.DATE_FIN_CONGE, service.DESIGNATION_SERVICE from  service,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.SERVICE = SERVICE.id_service and DATE_DEMANDE between '01/01/2017' and '01/01/2019' and service.DESIGNATION_SERVICE = 'Service Vente';"
            Query = "select  employe.matricule, employe.nom, employe.prenom , service.DESIGNATION_SERVICE  as Service,status from  service,  employe ,  demande_conge where status = 'Accepter Par le GRH' and  employe.matricule =  demande_conge.matricule and employe.SERVICE = SERVICE.id_service and service.DESIGNATION_SERVICE = '" + servicee + "' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        public void remplirDG_stat_service_nonencore_entre_2date(String servicee, DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select  employe.matricule, employe.nom, employe.prenom ,demande_conge.DATE_DEBUT_CONGE,demande_conge.DATE_FIN_CONGE, service.DESIGNATION_SERVICE  as Service,status from  service,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.SERVICE = SERVICE.id_service and DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "'  and service.DESIGNATION_SERVICE = '" + combo_service.Text + "' and status='Non Encore Traité par GRH' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        public void remplirDG_stat_service_refuser_entre_2date(String servicee, DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select  employe.matricule, employe.nom, employe.prenom ,demande_conge.DATE_DEBUT_CONGE,demande_conge.DATE_FIN_CONGE, service.DESIGNATION_SERVICE  as Service,status from  service,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.SERVICE = SERVICE.id_service and DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "'  and service.DESIGNATION_SERVICE = '" + combo_service.Text + "'  and  status= 'Refuser Par le GRH'  ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        public void remplirDG_stat_service_accepter_entre_2date(String servicee, DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            //Query= "select  employe.matricule, employe.nom, employe.prenom ,demande_conge.DATE_DEBUT_CONGE,demande_conge.DATE_FIN_CONGE, service.DESIGNATION_SERVICE from  service,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.SERVICE = SERVICE.id_service and DATE_DEMANDE between '01/01/2017' and '01/01/2019' and service.DESIGNATION_SERVICE = 'Service Vente';"
            Query = "select  employe.matricule, employe.nom, employe.prenom ,demande_conge.DATE_DEBUT_CONGE,demande_conge.DATE_FIN_CONGE, service.DESIGNATION_SERVICE  as Service from  service,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.SERVICE = SERVICE.id_service and DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "'  and service.DESIGNATION_SERVICE = '" + combo_service.Text + "'  and   status = 'Accepter Par le GRH' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        public void remplirDG_stat_departement(String departement, DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select  employe.matricule, employe.nom, employe.prenom , departement.DESGN_DEPARTEMENT as Département from  departement,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.departement = departement.ID_DEPARTMENT  and departement.DESGN_DEPARTEMENT = '" + departement + "'  ";
            // Query = "select  employe.matricule, employe.nom, employe.prenom ,demande_conge.DATE_DEBUT_CONGE,demande_conge.DATE_FIN_CONGE, service.DESIGNATION_SERVICE from  service,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.SERVICE = SERVICE.id_service and DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "'  and service.DESIGNATION_SERVICE = '" + combo_service.Text + "'  and   status = 'Accepter Par le GRH' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        public void remplirDG_stat_departement_refus(String departement, DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select  employe.matricule, employe.nom, employe.prenom , departement.DESGN_DEPARTEMENT as Département,status from  departement,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.departement = departement.ID_DEPARTMENT  and ID_DEPARTMENT.DESGN_DEPARTEMENT = '" + departement + "'  and   status = 'Refuser Par le GRH'  ";
            // Query = "select  employe.matricule, employe.nom, employe.prenom ,demande_conge.DATE_DEBUT_CONGE,demande_conge.DATE_FIN_CONGE, service.DESIGNATION_SERVICE from  service,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.SERVICE = SERVICE.id_service and DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "'  and service.DESIGNATION_SERVICE = '" + combo_service.Text + "'  and   status = 'Accepter Par le GRH' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        public void remplirDG_stat_departement_accepter(String departement, DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select  employe.matricule, employe.nom, employe.prenom , departement.DESGN_DEPARTEMENT as Département,status from  departement,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.departement = departement.ID_DEPARTMENT  and ID_DEPARTMENT.DESGN_DEPARTEMENT = '" + departement + "' and status='Accepter Par le GRH' ";
            // Query = "select  employe.matricule, employe.nom, employe.prenom ,demande_conge.DATE_DEBUT_CONGE,demande_conge.DATE_FIN_CONGE, service.DESIGNATION_SERVICE from  service,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.SERVICE = SERVICE.id_service and DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "'  and service.DESIGNATION_SERVICE = '" + combo_service.Text + "'  and   status = 'Accepter Par le GRH' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        public void remplirDG_stat_departement_non_encore_traite(String departement, DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select  employe.matricule, employe.nom, employe.prenom , departement.DESGN_DEPARTEMENT as Département,status from  departement,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.departement = departement.ID_DEPARTMENT  and ID_DEPARTMENT.DESGN_DEPARTEMENT = '" + departement + "' and status='Non Encore Traité par GRH' ";
            // Query = "select  employe.matricule, employe.nom, employe.prenom ,demande_conge.DATE_DEBUT_CONGE,demande_conge.DATE_FIN_CONGE, service.DESIGNATION_SERVICE from  service,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.SERVICE = SERVICE.id_service and DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "'  and service.DESIGNATION_SERVICE = '" + combo_service.Text + "'  and   status = 'Accepter Par le GRH' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        public void remplirDG_stat_departement_refus_entre2date(String departement, DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select  employe.matricule, employe.nom, employe.prenom , departement.DESGN_DEPARTEMENT as Département,status from  departement,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.departement = departement.ID_DEPARTMENT  and ID_DEPARTMENT.DESGN_DEPARTEMENT = '" + departement + "'  and   status = 'Refuser Par le GRH' and DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        public void remplirDG_stat_departement_accepter_entre2date(String departement, DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select  employe.matricule, employe.nom, employe.prenom , departement.DESGN_DEPARTEMENT as Département,status from  departement,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.departement = departement.ID_DEPARTMENT  and ID_DEPARTMENT.DESGN_DEPARTEMENT = '" + departement + "' and status='Accepter Par le GRH'  and DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "'";
            // Query = "select  employe.matricule, employe.nom, employe.prenom ,demande_conge.DATE_DEBUT_CONGE,demande_conge.DATE_FIN_CONGE, service.DESIGNATION_SERVICE from  service,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.SERVICE = SERVICE.id_service and DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "'  and service.DESIGNATION_SERVICE = '" + combo_service.Text + "'  and   status = 'Accepter Par le GRH' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        public void remplirDG_stat_departement_non_encore_traite_entre2date(String departement, DevExpress.XtraGrid.GridControl dg)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select  employe.matricule, employe.nom, employe.prenom , departement.DESGN_DEPARTEMENT as Département,status from  departement,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.departement = departement.ID_DEPARTMENT  and ID_DEPARTMENT.DESGN_DEPARTEMENT = '" + departement + "' and status='Non Encore Traité par GRH'  and DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "'";
            // Query = "select  employe.matricule, employe.nom, employe.prenom ,demande_conge.DATE_DEBUT_CONGE,demande_conge.DATE_FIN_CONGE, service.DESIGNATION_SERVICE from  service,  employe ,  demande_conge where  employe.matricule =  demande_conge.matricule and employe.SERVICE = SERVICE.id_service and DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "'  and service.DESIGNATION_SERVICE = '" + combo_service.Text + "'  and   status = 'Accepter Par le GRH' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
            #endregion
        }

        #endregion

        private void barButtonItem56_ItemClick(object sender, ItemClickEventArgs e)
        {
            #region les condition stats
            #region radion_anner
            if (radio_anner.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String nbb = "0";
                String anner = picker1.Value.Year + "";
                String critere = " where to_char(DATE_DEMANDE,'yyyy')  = '" + anner + "' ";
                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_anner(grid_stat);

                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé pendant l'année " + picker1.Value.Year;
                    resultat_filtre.Text = nbb + "";
                }
                else { MessageBox.Show("e" + erreur); }
            }
            #endregion

            #region radion_anner&accepter
            if (radio_anner.Checked && radio_accepter.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String nbb = "0";
                String anner = picker1.Value.Year + "";
                String critere = " where to_char(DATE_DEMANDE,'yyyy')  = '" + anner + "' and status='Accepter Par le GRH' ";
                remplirDG_stat_anner_accpeter(grid_stat);
                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé accepté pendant l'année " + picker1.Value.Year;
                    resultat_filtre.Text = nbb + "";
                }
                else { MessageBox.Show("e" + erreur); }
            }
            #endregion

            #region radion_anner&non_traité
            if (radio_anner.Checked && radio_non_encore_traite.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String nbb = "0";
                String anner = picker1.Value.Year + "";
                String critere = " where to_char(DATE_DEMANDE,'yyyy')  = '" + anner + "' and status='Non Encore Traité par GRH' ";

                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_anner_nonencoretraite(grid_stat);

                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé non encore traité par GRH pendant l'année " + picker1.Value.Year;
                    resultat_filtre.Text = nbb + "";
                }
                else { MessageBox.Show("e" + erreur); }
            }
            #endregion


            #region radion_anner&rrefuséé
            if (radio_anner.Checked && radio_refuser.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String nbb = "0";
                String anner = picker1.Value.Year + "";
                String critere = " where to_char(DATE_DEMANDE,'yyyy')  = '" + anner + "' and status='Refuser Par le GRH' ";
                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_anner_refuser(grid_stat);

                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé Refuser Par le GRH pendant l'année " + picker1.Value.Year;
                    resultat_filtre.Text = nbb + "";
                }
                else { MessageBox.Show("e" + erreur); }
            }
            #endregion

            #region radio_entre_deux_date
            if (radio_entre_deux_date.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String nbb = "0";
                String critere = "where DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "' ";
                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_entre2_date(grid_stat);

                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé Entre " + picker2.Value.ToString("dd-MM-yyyy") + " et " + picker3.Value.ToString("dd-MM-yyyy");
                    resultat_filtre.Text = nbb + "";

                }
                else { MessageBox.Show("e" + erreur); }


            }
            #endregion

            #region radio_entre2date_accepter

            if (radio_entre_deux_date.Checked && radio_accepter.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String nbb = "0";
                String critere = " where  STATUS = 'Accepter Par le GRH' ";
                remplirDG_stat_entre2_date_accepter(grid_stat);
                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé Accepté Entre " + picker2.Value.ToString("dd-MM-yyyy") + " et " + picker3.Value.ToString("dd-MM-yyyy");
                    resultat_filtre.Text = nbb + "";

                }
                else { MessageBox.Show("e" + erreur); }

            }
            #endregion

            #region radio_entre_deux_date_radio_non_encore_traite
            if (radio_entre_deux_date.Checked && radio_non_encore_traite.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String critere = "";
                String nbb = "0";
                critere = "where DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "' and status='Non Encore Traité par GRH' ";

                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_entre2_date_nonencoretarite(grid_stat);
                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé non encore traité Entre " + picker2.Value.ToString("dd-MM-yyyy") + " et " + picker3.Value.ToString("dd-MM-yyyy");
                    resultat_filtre.Text = nbb + "";

                }
                else { MessageBox.Show("e" + erreur); }
            }
            #endregion

            #region radio_entre_deux_date_radio_refuser

            if (radio_entre_deux_date.Checked && radio_refuser.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                DateTime db = Convert.ToDateTime(picker2.Value.ToShortTimeString());
                String critere = "";
                String nbb = "0";
                critere = "where DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and '" + picker3.Value.ToString("dd-MM-yyyy") + "' and status='Refuser Par le GRH' ";

                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_entre2_date_refuser(grid_stat);
                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé refusé Entre " + picker2.Value.ToString("dd-MM-yyyy") + " et " + picker3.Value.ToString("dd-MM-yyyy");
                    resultat_filtre.Text = nbb + "";

                }
                else { MessageBox.Show("e" + erreur); }
            }
            #endregion
            /*SERVICEEEEEEEEEEeee*/

            #region radio_service
            if (radio_service.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String critere = "";
                String nbb = "0";
                string cc = "";
                gestion_servie.chercher_Service_retour_code(combo_service.Text, out erreur, out cc, out exist);

                critere = " where exists(select 1 from  employe e where e.MATRICULE=DEMANDE_CONGE.matricule and service='" + cc + "') ";// DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "' and status='Refuser Par le GRH' ";

                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_service(combo_service.Text, grid_stat);
                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé dans le service " + combo_service.Text + " Entre " + picker2.Value.ToString("dd-MM-yyyy") + " et " + picker3.Value.ToString("dd-MM-yyyy") + " ";
                    resultat_filtre.Text = nbb + "";

                }
                else { MessageBox.Show("e" + erreur); }

            }
            #endregion

            #region radio_refuser_radio_service
            if (radio_refuser.Checked && radio_service.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String critere = "";
                String nbb = "0";
                string cc = "";
                gestion_servie.chercher_Service_retour_code(combo_service.Text, out erreur, out cc, out exist);
                critere = " where  status= 'Refuser Par le GRH' and exists(select 1 from  employe e where e.MATRICULE=DEMANDE_CONGE.matricule and service='" + cc + "') ";
                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_service_refuser(combo_service.Text, grid_stat);
                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé refusé dans le service " + combo_service.Text + " Entre " + picker2.Value.ToString("dd-MM-yyyy") + " et " + picker3.Value.ToString("dd-MM-yyyy") + " ";
                    resultat_filtre.Text = nbb + "";

                }
                else { MessageBox.Show("e" + erreur); }
            }
            #endregion

            #region radio_service_accepter
            if (radio_accepter.Checked && radio_service.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String critere = "";
                String nbb = "0";
                string cc = "";
                gestion_servie.chercher_Service_retour_code(combo_service.Text, out erreur, out cc, out exist);

                critere = " where and status = 'Accepter Par le GRH' and exists (select 1 from  employe e where e.MATRICULE=DEMANDE_CONGE.matricule and service='" + cc + "') ";

                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_service_accepter(combo_service.Text, grid_stat);

                anner_label.Visible = true;
                resultat_filtre.Visible = true;
                anner_label.Text = "  Nombre de jours de congé accapté dans le service " + combo_service.Text + " Entre " + picker2.Value.ToString("dd-MM-yyyy") + " et " + picker3.Value.ToString("dd-MM-yyyy") + " ";
                resultat_filtre.Text = nbb + "";

                //}
                //else { MessageBox.Show("e" + erreur); }


            }
            #endregion

            #region radio_non_encore_traite_service
            if (radio_non_encore_traite.Checked && radio_service.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String critere = "";
                String nbb = "0";
                string cc = "";
                gestion_servie.chercher_Service_retour_code(combo_service.Text, out erreur, out cc, out exist);

                critere = " where   status='Non Encore Traité par GRH' and exists(select 1 from  employe e where e.MATRICULE=DEMANDE_CONGE.matricule and service='" + cc + "') ";
                //DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "' and
                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_service_nonencore(combo_service.Text, grid_stat);

                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé  non encore traité  dans le service " + combo_service.Text + " Entre " + picker2.Value.ToString("dd-MM-yyyy") + " et " + picker3.Value.ToString("dd-MM-yyyy") + " ";

                    resultat_filtre.Text = nbb + "";

                }
                else { MessageBox.Show("e" + erreur); }

            }
            #endregion

            #region radio_non_encore_traite_radio_entre_deux_date_service
            if (radio_non_encore_traite.Checked && radio_service.Checked && radio_entre_deux_date.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String critere = "";
                String nbb = "0";
                string cc = "";
                gestion_servie.chercher_Service_retour_code(combo_service.Text, out erreur, out cc, out exist);

                critere = " where  DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and '" + picker3.Value.ToString("dd-MM-yyyy") + "' and status='Non Encore Traité par GRH' and exists(select 1 from  employe e where e.MATRICULE=DEMANDE_CONGE.matricule and service='" + cc + "') ";

                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_service_nonencore_entre_2date(combo_service.Text, grid_stat);
                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé  non encore traité  dans le service " + combo_service.Text + " Entre " + picker2.Value.ToString("dd-MM-yyyy") + " et " + picker3.Value.ToString("dd-MM-yyyy") + " ";

                    resultat_filtre.Text = nbb + "";

                }
                else { MessageBox.Show("e" + erreur); }


            }
            #endregion

            #region radio_entre_deux_date_radio_accepter_service
            if (radio_accepter.Checked && radio_service.Checked && radio_entre_deux_date.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String critere = "";
                String nbb = "0";
                string cc = "";
                gestion_servie.chercher_Service_retour_code(combo_service.Text, out erreur, out cc, out exist);

                critere = " where  DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and '" + picker3.Value.ToString("dd-MM-yyyy") + "' and status='Accepter Par le GRH' and exists(select 1 from  employe e where e.MATRICULE=DEMANDE_CONGE.matricule and service='" + cc + "') ";

                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_service_accepter_entre_2date(combo_service.Text, grid_stat);
                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé accepté dans le service " + combo_service.Text + " Entre " + picker2.Value.ToString("dd-MM-yyyy") + " et " + picker3.Value.ToString("dd-MM-yyyy") + " ";
                    resultat_filtre.Text = nbb + "";

                }
                else { MessageBox.Show("e" + erreur); }


            }
            #endregion

            #region radio_entre_deux_date_radio_refuser_radio_service
            if (radio_refuser.Checked && radio_service.Checked && radio_entre_deux_date.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String critere = "";
                String nbb = "0";
                string cc = "";
                gestion_servie.chercher_Service_retour_code(combo_service.Text, out erreur, out cc, out exist);

                critere = " where  DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and '" + picker3.Value.ToString("dd-MM-yyyy") + "' and  status='Refuser Par le GRH' and exists(select 1 from  employe e where e.MATRICULE=DEMANDE_CONGE.matricule and service='" + cc + "') ";

                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_service_refuser_entre_2date(combo_service.Text, grid_stat);
                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé refusé dans le service " + combo_service.Text + " Entre " + picker2.Value.ToString("dd-MM-yyyy") + " et " + picker3.Value.ToString("dd-MM-yyyy") + " ";

                    resultat_filtre.Text = nbb + "";

                }
                else { MessageBox.Show("e" + erreur); }


            }

            #endregion


            /*DEPARTEMENTTTTTTTTTTt*/

            #region radio_departement
            if (radio_depar.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String critere = "";
                String nbb = "0";
                string cc = "";
                gestion_department.chercher_Departement_retour_code(combo_departementt.Text, out erreur, out cc, out exist);
                critere = " where exists(select 1 from  employe e where e.MATRICULE=DEMANDE_CONGE.matricule and departement='" + cc + "') ";// DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "' and status='Refuser Par le GRH' ";
                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_departement(combo_departementt.Text, grid_stat);
                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé dans le Departement " + combo_departementt.Text + " Entre " + picker2.Value.ToString("dd-MM-yyyy") + " et " + picker3.Value.ToString("dd-MM-yyyy") + " ";
                    resultat_filtre.Text = nbb + "";
                }
                else { MessageBox.Show("e" + erreur); }
            }
            #endregion

            #region radio_refuser_radio_depar
            if (radio_refuser.Checked && radio_depar.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String critere = "";
                String nbb = "0";
                string cc = "";
                gestion_department.chercher_Departement_retour_code(combo_departementt.Text, out erreur, out cc, out exist);
                critere = " where  status= 'Refuser Par le GRH' and exists(select 1 from  employe e where e.MATRICULE=DEMANDE_CONGE.matricule and departement='" + cc + "') ";
                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_departement_refus(combo_departementt.Text, grid_stat);
                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé refusé dans le departement " + combo_departementt.Text + " Entre " + picker2.Value.ToString("dd-MM-yyyy") + " et " + picker3.Value.ToString("dd-MM-yyyy") + " ";
                    resultat_filtre.Text = nbb + "";

                }
                else { MessageBox.Show("e" + erreur); }
            }
            #endregion

            #region radio_service_accepter
            if (radio_accepter.Checked && radio_depar.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String critere = "";
                String nbb = "0";
                string cc = "";
                gestion_department.chercher_Departement_retour_code(combo_departementt.Text, out erreur, out cc, out exist);

                critere = " where and status='Accepter Par le GRH' and exists(select 1 from  employe e where e.MATRICULE=DEMANDE_CONGE.matricule and departement='" + cc + "') ";

                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_departement_accepter(combo_departementt.Text, grid_stat);
                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé accapté dans le departement " + combo_departementt.Text + " Entre " + picker2.Value.ToString("dd-MM-yyyy") + " et " + picker3.Value.ToString("dd-MM-yyyy") + " ";
                    resultat_filtre.Text = nbb + "";

                }
                else { MessageBox.Show("e" + erreur); }


            }
            #endregion

            #region radio_non_encore_traite_dep
            if (radio_non_encore_traite.Checked && radio_depar.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String critere = "";
                String nbb = "0";
                string cc = "";
                gestion_department.chercher_Departement_retour_code(combo_departementt.Text, out erreur, out cc, out exist);

                critere = " where   status='Non Encore Traité par GRH' and exists(select 1 from  employe e where e.MATRICULE=DEMANDE_CONGE.matricule and departement='" + cc + "') ";
                //DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and'" + picker3.Value.ToString("dd-MM-yyyy") + "' and
                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_departement_non_encore_traite(combo_departementt.Text, grid_stat);
                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé  non encore traité  dans le departement " + combo_departementt.Text + " Entre " + picker2.Value.ToString("dd-MM-yyyy") + " et " + picker3.Value.ToString("dd-MM-yyyy") + " ";

                    resultat_filtre.Text = nbb + "";

                }
                else { MessageBox.Show("e" + erreur); }

            }
            #endregion

            #region radio_non_encore_traite_radio_entre_deux_date_depar
            if (radio_non_encore_traite.Checked && radio_depar.Checked && radio_entre_deux_date.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String critere = "";
                String nbb = "0";
                string cc = "";
                gestion_department.chercher_Departement_retour_code(combo_departementt.Text, out erreur, out cc, out exist);

                critere = " where  DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and '" + picker3.Value.ToString("dd-MM-yyyy") + "' and status='Non Encore Traité par GRH' and exists(select 1 from  employe e where e.MATRICULE=DEMANDE_CONGE.matricule and departement='" + cc + "') ";

                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_departement_non_encore_traite_entre2date(combo_departementt.Text, grid_stat);
                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé  non encore traité  dans le departement " + combo_departementt.Text + " Entre " + picker2.Value.ToString("dd-MM-yyyy") + " et " + picker3.Value.ToString("dd-MM-yyyy") + " ";

                    resultat_filtre.Text = nbb + "";

                }
                else { MessageBox.Show("e" + erreur); }


            }
            #endregion

            #region radio_entre_deux_date_radio_accepter_service
            if (radio_accepter.Checked && radio_depar.Checked && radio_entre_deux_date.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String critere = "";
                String nbb = "0";
                string cc = "";
                gestion_department.chercher_Departement_retour_code(combo_departementt.Text, out erreur, out cc, out exist);

                critere = " where  DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and '" + picker3.Value.ToString("dd-MM-yyyy") + "' and status='Accepter Par le GRH' and exists(select 1 from  employe e where e.MATRICULE=DEMANDE_CONGE.matricule and departement='" + cc + "') ";

                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_departement_accepter_entre2date(combo_departementt.Text, grid_stat);
                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé accepté dans le departement " + combo_departementt.Text + " Entre " + picker2.Value.ToString("dd-MM-yyyy") + " et " + picker3.Value.ToString("dd-MM-yyyy") + " ";
                    resultat_filtre.Text = nbb + "";

                }
                else { MessageBox.Show("e" + erreur); }


            }
            #endregion

            #region radio_entre_deux_date_radio_refuser_radio_service
            if (radio_refuser.Checked && radio_depar.Checked && radio_entre_deux_date.Checked)
            {
                grid_stat.DataSource = null;
                gridView1.Columns.Clear();

                String critere = "";
                String nbb = "0";
                string cc = "";
                gestion_department.chercher_Departement_retour_code(combo_departementt.Text, out erreur, out cc, out exist);

                critere = " where  DATE_DEMANDE between '" + picker2.Value.ToString("dd-MM-yyyy") + "' and '" + picker3.Value.ToString("dd-MM-yyyy") + "' and  status='Refuser Par le GRH' and exists(select 1 from  employe e where e.MATRICULE=DEMANDE_CONGE.matricule and departement='" + cc + "') ";

                gestion_demande.RechercherParcritere_Anner(critere, out erreur, out nbb, out exist);
                remplirDG_stat_departement_refus_entre2date(combo_departementt.Text, grid_stat);
                if (erreur == null)
                {
                    anner_label.Visible = true;
                    resultat_filtre.Visible = true;
                    anner_label.Text = "  Nombre de jours de congé refusé dans le departement " + combo_departementt.Text + " Entre " + picker2.Value.ToString("dd-MM-yyyy") + " et " + picker3.Value.ToString("dd-MM-yyyy") + " ";

                    resultat_filtre.Text = nbb + "";

                }
                else { MessageBox.Show("e" + erreur); }


            }

            #endregion

            #endregion
        }



        private void radio_anner_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radio_anner.Checked)
            {
                picker1.Visible = true;
                picker2.Visible = false;
                picker3.Visible = false;
                combo_departementt.Visible = false;
                combo_service.Visible = false;
            }
            else if (radio_anner.Checked == false)

            {
                picker1.Visible = false;
                /* picker2.Visible = false;
                 picker3.Visible = false;
                 combo_departementt.Visible = false;
                 combo_service.Visible = false;*/

            }

        }

        private void radio_non_encore_traite_CheckedChanged_1(object sender, EventArgs e)
        {
            /*  if (radio_non_encore_traite.Checked == true)
              {*/
            /*   combo_service.Visible = false;
               picker2.Visible = false;
               picker1.Visible = false;
               picker3.Visible = false;
               combo_departementt.Visible = false;*/
            /*      radio_non_encore_traite.Visible = true;
              }
              else if (radio_non_encore_traite.Checked == false)
              {*/
            /*  combo_service.Visible = false;
              picker2.Visible = false;
              picker1.Visible = false;
              picker3.Visible = false;
              combo_departementt.Visible = false;*/
            /*   radio_non_encore_traite.Visible = false;


           }
           */
        }

        private void radio_accepter_CheckedChanged_1(object sender, EventArgs e)
        {
            /*if (radio_accepter.Checked == true)
            {*/
            // radio_accepter.Visible = true;
            /*  combo_service.Visible = true;
              picker2.Visible = true;
              picker1.Visible = false;
              picker3.Visible = true;
              combo_departementt.Visible = false;*/
            /*    }
                else if (radio_accepter.Checked == false)
                {
                    radio_accepter.Visible = false;
                    */
            /*  combo_service.Visible = false;
              picker2.Visible = false;
              picker1.Visible = false;
              picker3.Visible = false;
              combo_departementt.Visible = false;*/

            // }
        }

        private void radio_refuser_CheckedChanged_1(object sender, EventArgs e)
        {
            /*  if (radio_refuser.Checked) 
               {*/
            //    radio_refuser.Visible = true;
            /*   combo_service.Visible = true;
               picker2.Visible = true;
               picker1.Visible = false;
               picker3.Visible = true;
               combo_departementt.Visible = false;*/
            /* }else if (radio_refuser.Checked == false)
             {*/
            // radio_refuser.Visible = false;
            /* combo_service.Visible = false;
             picker2.Visible = false;
             picker1.Visible = false;
             picker3.Visible = false;
             combo_departementt.Visible = false;
             */

            //     }
        }
        private void radio_depar_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radio_depar.Checked)
            {


                /* combo_service.Visible = true;
                 picker2.Visible = true;
                 picker1.Visible = false;
                 picker3.Visible = true;*/
                combo_departementt.Visible = true;
            }
            else if (radio_depar.Checked == false)
            {

                /* combo_service.Visible = false;
                 picker2.Visible = false;
                 picker1.Visible = false;
                 picker3.Visible = false;*/
                combo_departementt.Visible = false;

            }
        }

        private void radio_entre_deux_date_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radio_entre_deux_date.Checked == true)
            {
                picker2.Visible = true;
                //  picker1.Visible = false;
                picker3.Visible = true;
                //   combo_departementt.Visible = false;
                //    combo_service.Visible = false;
            }

            if (radio_entre_deux_date.Checked == false)
            {
                picker2.Visible = false;
                picker3.Visible = false;
                //  picker2.Visible = false;
                //   picker1.Visible = false;
                // picker3.Visible = false;
                //   combo_departementt.Visible = false;
                //   combo_service.Visible = false;

            }


        }

        private void radio_service_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radio_service.Checked == true)
            {
                combo_service.Visible = true;
                /*   picker2.Visible = false;
                   picker1.Visible = false;
                   picker3.Visible = false;
                   combo_departementt.Visible = false;
                   */
            }
            else if (radio_service.Checked == false)
            {
                combo_service.Visible = false;
            }

        }



        private void stata_ActivePanelChanged(object sender, ActivePanelChangedEventArgs e)
        {
            if (stat_dockpanel.IsMdiDocument)
            {
                List<Services_Class> lissts = new List<Services_Class>();
                String dbb = "";
                gestion_servie.chercher_ListeService("", out erreur, out lissts, out exist);

                foreach (Services_Class x in lissts)
                {
                    combo_service.Items.Add(x.DESG_Serv + "");
                }

                List<Departement_Class> lisst = new List<Departement_Class>();
                String dbbs = "";
                gestion_department.chercher_ListeDepartement("", out erreur, out lisst, out dbbs, out exist);

                foreach (Departement_Class x in lisst)
                {
                    combo_departementt.Items.Add(x.DESG_Dep + "");
                }
            }

        }
        public void remplirDGTitre(DevExpress.XtraGrid.GridControl dg)
        {

            sqlconnection = new OracleConnection(ConnectionString);
            String Query = "select e.MATRICULE,e.NOM,e.PRENOM,dc.ID_CONGE,dc.ID_DEMANDE_CONGE from  EMPLOYE e , DEMANDE_CONGE dc where e.MATRICULE=dc.MATRICULE and  dc.STATUS like'%Accepter%' ";// Par le GRH' ";//or dc.STATUS='Accepter Par le GRH,mais avec changement du date a cause du disponibilité des employés' ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
        }


        private void tirecongeee_ActivePanelChanged(object sender, ActivePanelChangedEventArgs e)
        {
            if (titreconge_dockpanel.IsMdiDocument)
            {
                remplirDGTitre(titrecongegridcontrol);
                //     dataGridView1.Columns[3].Visible = false;
                //   dataGridView1.Columns[4].Visible = false;
                //  dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridView2.Columns[3].Visible = false;
                gridView2.Columns[4].Visible = false;


            }
        }

        private void imprimertitreconge_ItemClick(object sender, ItemClickEventArgs e)
        {

            String nomm;
            String prenom;
            DateTime datedeme;
            DateTime d11;
            DateTime d22;
            String sexe; String hd; String hf;
            String staatus = "";
            int index = gridView2.FocusedRowHandle;

            gestion_demande.imprimer(out erreur, out nomm, out prenom, out datedeme, out d11, out d22, out exist, gridView2.GetRowCellValue(index, "MATRICULE").ToString(), out staatus, out sexe, out hd, out hf);

            if (staatus.Equals("Accepter Par le GRH"))
            {
                if (erreur == null)
                {
                    Impression3 p = new Impression3(nomm, prenom, datedeme, d11, d22, staatus, sexe, hd, hf);//, histo.Anner_conge, histo.Droit_annner_courant + "", histo.Pris_anner_courant + "", solde + "");
                    p.imprimer();
                    p.ShowDialog();
                }
                else { MessageBox.Show(erreur); }

            }
            else if (staatus.Equals("Accepter Par le GRH,mais avec changement du date a cause du disponibilité des employés"))
               {
                   if (erreur == null)
                   {
                    Impression.Impression4 p = new Impression4(nomm, prenom, datedeme, d11, d22, staatus, sexe, hd, hf); //histo.Anner_conge, histo.Droit_annner_courant + "", histo.Pris_anner_courant + "", solde + "");
                       p.imprimer();
                       p.ShowDialog();
                   }
                   else { MessageBox.Show(erreur); }

               }
               else// if (staatus.Equals("Non Encore Traité par GRH"))
               {
                   if (erreur == null)
                   {
                    Impression.Impression4 p = new Impression4(nomm, prenom, datedeme, d11, d22, staatus, sexe, hd, hf);//, histo.Anner_conge, histo.Droit_annner_courant + "", histo.Pris_anner_courant + "", solde + "");
                       p.imprimer();
                       p.ShowDialog();
                   }
                   else { MessageBox.Show(erreur); }


               }

        }

        private void titreouvrir_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            titreconge_dockpanel.Show();
        }

        private void ouvrir_bonreprirse_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        private void ouvrirlettrerejet_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            lettrerejet_dockpanel.Show();
        }

        private void imprimerlettrerefus_ItemClick(object sender, ItemClickEventArgs e)
        {

            String nomm;
            String prenom;
            DateTime datedeme;
            DateTime d11;
            DateTime d22;
            String sexe; String hd; String hf;
            String staatus = "";
            int index = gridView4.FocusedRowHandle;

            gestion_demande.imprimer(out erreur, out nomm, out prenom, out datedeme, out d11, out d22, out exist, gridView4.GetRowCellValue(index, "MATRICULE").ToString(), out staatus, out sexe, out hd, out hf);


                    if (staatus.Equals("Refuser Par le GRH"))
               {
                   if (erreur == null)
                   {
                    Impression.Impression5 p = new Impression5(nomm, prenom, datedeme, d11, d22, staatus, sexe, hd, hf);//, histo.Anner_conge, histo.Droit_annner_courant + "", histo.Pris_anner_courant + "", solde + "");
                       p.imprimer();
                       p.ShowDialog();
                   }
                   else { MessageBox.Show(erreur); }

               }
              /* else// if (staatus.Equals("Non Encore Traité par GRH"))
               {
                   if (erreur == null)
                   {
                       Impression.Impression4 p = new Impression4(nomm, prenom, datedeme, d11, d22, staatus, sexe, hd, hf, histo.Anner_conge, histo.Droit_annner_courant + "", histo.Pris_anner_courant + "", solde + "");
                       p.imprimer();
                       p.ShowDialog();
                   }
                   else { MessageBox.Show(erreur); }


               }*/

        }
        public void remplirDGRefus(DevExpress.XtraGrid.GridControl dg)
        {

            sqlconnection = new OracleConnection(ConnectionString);
            String Query = "select e.MATRICULE,e.NOM,e.PRENOM,dc.ID_CONGE,dc.ID_DEMANDE_CONGE from  EMPLOYE e , DEMANDE_CONGE dc where e.MATRICULE=dc.MATRICULE and dc.STATUS ='Refuser Par le GRH , manque des employés'  ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
        }


      
        private void lettrerejet_ActivePanelChanged(object sender, ActivePanelChangedEventArgs e)
        {

            if (lettrerejet_dockpanel.IsMdiDocument)
            {
                remplirDGRefus(lettreRefus_DG);
                //     dataGridView1.Columns[3].Visible = false;
                //   dataGridView1.Columns[4].Visible = false;
                //  dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridView4.Columns[3].Visible = false;
                gridView4.Columns[4].Visible = false;


            }
        }

        private void historique_dg_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            #region imageoncells
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.Done_icon.Width;
                var h = Properties.Resources.Done_icon.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.Done_icon, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
           

            #endregion
        }

        private void motif_final_EditValueChanged(object sender, EventArgs e)
        {
        /*    string[] strTITRE = { "Accepter Par le GRH", "Accepter Par le GRH,mais avec changement du date a cause du disponibilité des employés", "Refuser Par le GRH" };
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(strTITRE);
            motif_final.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            motif_final.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            motif_final.MaskBox.AutoCompleteCustomSource = collection;
            */
        }

        private void list_dep_ItemClick(object sender, ItemClickEventArgs e)
        {
        }


        #endregion

        /************************************************************************/
        //Fin Conger //
        /************************************************************************/

    }
}