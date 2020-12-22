using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Oracle.ManagedDataAccess.Client;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using Meiter;
using Gestion_Paie_Oracle.Impression;
namespace Gestion_Paie_Oracle.Simple_Fenetre
{
    public partial class ListeDesDemandeconge : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static ListeDesDemandeconge edd;
        public ListeDesDemandeconge()
        {
            InitializeComponent();

        }

        #region "initialisation"

        string erreur = null;
        Boolean exist = false;
        Meiter.Gestion_Demande_Class gestion_demande = new Meiter.Gestion_Demande_Class();
        Metier.Gestion_Historique_Cong gestion_historique = new Metier.Gestion_Historique_Cong();

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
        public void remplirDG8(DataGridView dg)
        {

            sqlconnection = new OracleConnection(ConnectionString);
            String Query = "select e.MATRICULE,e.NOM,e.PRENOM,dc.ID_CONGE,dc.ID_DEMANDE_CONGE,dc.status from  EMPLOYE e , DEMANDE_CONGE dc where e.MATRICULE=dc.MATRICULE and dc.STATUS !='Non Encore Traité par GRH'  ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dg.DataSource = datatable;
        }
        public bool accpter = false;

        private void ListeDesDemandeconge_Load(object sender, EventArgs e)
        {
            edd = this;
            remplirDG8(dataGridView1);
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            #region cmtrrr

            /*
                        if (dataGridView1.Columns.Contains("col5") == false)
                        {

                            DataGridViewCheckBoxColumn btnColumn1 = new DataGridViewCheckBoxColumn();
                            dataGridView1.Columns.Add(btnColumn1);
                            btnColumn1.Name = "col5";
                            btnColumn1.HeaderText = "Accepter|Refus";
                            btnColumn1.Width = 30;
                            //  btnColumn1.UseColumnTextForButtonValue = true;
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        }

                        String status = "";
                        bool verifier = false;
                        for (int i = 0; i <= dataGridView1.RowCount-1; i++)
                        {

                            gestion_demande.chercher_Demande_conge_STATUS(dataGridView1.Rows[i].Cells["ID_DEMANDE_CONGE"].Value.ToString(), out erreur, out status, out exist);
                            if (status.Equals("Accepter Par le GRH"))
                            {
                                dataGridView1.Rows[i].Cells[5].Value = true;
                                accpter = true;
                            }
                            else
                            {
                                dataGridView1.Rows[i].Cells[5].Value = false;

                                accpter = false;
                            }

                        }
                       // MessageBox.Show(verifier + "");

                        */
            #endregion
        }

        bool x = true;

        private void accpt_refus_conge_ItemClick(object sender, ItemClickEventArgs e)
        {
            #region cmtrrr
            /*String nomm;
            String prenom;
            DateTime datedeme;
            DateTime d11;
            DateTime d22;
            int index = dataGridView1.CurrentCell.RowIndex;
           // MessageBox.Show(index + "");
         gestion_demande.imprimer(out erreur, out nomm, out prenom, out datedeme, out d11, out d22, out exist, dataGridView1.Rows[index].Cells[0].Value.ToString());
            if (erreur == null)
            {
           //     MessageBox.Show(nomm + "||" + prenom+ "||"+datedeme+" ||"+d11+"||"+d22);
              Impression.Impression   p = new Impression.Impression(nomm, prenom, datedeme, d11, d22,Convert.ToBoolean( dataGridView1.Rows[index].Cells[5].Value));
             //   MessageBox.Show(dataGridView1.Rows[index].Cells[3].Value.ToString());
         //       MessageBox.Show(dataGridView1.Rows[index].Cells[5].Value + "fill liste");
                p.imprimer();
                p.ShowDialog();


            }
            else { MessageBox.Show(erreur); }
            if (accpter == true)
            {

                //traitement ll ttire congé 

            }else
            {
                //traitement lettre refus 
}*/
            #endregion

            String nomm;
            String prenom;
            DateTime datedeme;
            DateTime d11;
            DateTime d22;
            String sexe; String hd; String hf;
            String staatus = "";
            String anner; String droit; String pris; decimal solde;

    
            int index = dataGridView1.CurrentCell.RowIndex;
            gestion_demande.imprimer(out erreur, out nomm, out prenom, out datedeme, out d11, out d22, out exist, dataGridView1.Rows[index].Cells[0].Value.ToString(), out staatus, out sexe, out hd, out hf);
            Metier.HISTORIQUE_CONGE histo = new Metier.HISTORIQUE_CONGE();
            gestion_historique.Historique_annercourante(DateTime.Now.Year + "", dataGridView1.Rows[index].Cells[0].Value.ToString(), out erreur, out histo, out exist);
            solde = Convert.ToDecimal(histo.Droit_annner_courant) + Convert.ToDecimal(histo.Arrier_conge) - Convert.ToDecimal(histo.Pris_anner_courant);

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
            else if (staatus.Equals("Refuser Par le GRH"))
            {
                if (erreur == null)
                {
                    Impression.Impression5 p = new Impression5(nomm, prenom, datedeme, d11, d22, staatus, sexe, hd, hf);//, histo.Anner_conge, histo.Droit_annner_courant + "", histo.Pris_anner_courant + "", solde + "");
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

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
}
}
