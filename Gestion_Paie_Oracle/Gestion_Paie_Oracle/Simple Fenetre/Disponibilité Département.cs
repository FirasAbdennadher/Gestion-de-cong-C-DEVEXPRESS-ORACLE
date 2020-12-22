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
using Meiter;
using Metier;
namespace Gestion_Paie_Oracle.Simple_Fenetre
{
    public partial class Disponibilité_Département : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DateTime debut;
        DateTime fin; String department = "";

        public Disponibilité_Département(DateTime db, DateTime df, String dep)
        {
            InitializeComponent();
            this.debut = db;
            this.fin = df;
            this.department = dep;

        }
        #region "initialisation"

        string erreur = null;
        Boolean exist = false;
        Gestion_Demande_Class gestion_demande = new Gestion_Demande_Class();
        gestion_Service gestion_servie = new gestion_Service();

        #endregion
        #region connectionoforfiltre
        public OracleConnection sqlconnection;
        public OracleCommand sqlcommand;

        String ConnectionString = "Data Source = localhost; Persist Security Info = True; User ID = mariem; Password = mariem;";
        public string Query;
        public DataSet dataset;
        public DataTable datatable;
        public DataTable datatable1;
        public DataTable datatable2;

        public OracleDataAdapter sqladapter;
        #endregion
        private void Disponibilité_Département_Load(object sender, EventArgs e)
        {
            #region remplir table database to gridview 

            sqlconnection = new OracleConnection(ConnectionString);
            String d11 = Convert.ToString(debut);
            String d22 = Convert.ToString(fin);
            MessageBox.Show(debut.ToShortDateString() + "" + Gestion_Paie_Oracle.Menu.pr.matricule_emp);
            Query = " select count(*) as S1 from  DEMANDE_CONGE where status='Non Encore Traité par GRH' and  DATE_DEMANDE between '" + debut.ToShortDateString() + "' and'" + fin.ToShortDateString() + "'  and MATRICULE in (select MATRICULE from employe  where DEPARTEMENT in(select id_department from DEPARTEMENT where reponsable_dep ='" + Gestion_Paie_Oracle.Menu.pr.matricule_emp + "' ))";

            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable1 = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable1);
            chart_non_valider.DataSource = datatable1;

            #endregion
            #region fdf
            sqlconnection = new OracleConnection(ConnectionString);
            MessageBox.Show(debut.ToShortDateString() + "" + Gestion_Paie_Oracle.Menu.pr.matricule_emp);
            Query = " select count(*) as S2 from  DEMANDE_CONGE where status='Accepter Par le GRH' and  DATE_DEMANDE between '" + debut.ToShortDateString() + "' and'" + fin.ToShortDateString() + "'  and MATRICULE in (select MATRICULE from employe  where DEPARTEMENT in(select id_department from DEPARTEMENT where reponsable_dep ='" + Gestion_Paie_Oracle.Menu.pr.matricule_emp + "' ))";

            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable2 = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable2);
            chart_valider.DataSource = datatable2;

            #endregion
            String sum = "";
            //   chart1.ChartAreas[0].AxisY.Interval = 1.5;
            String value1 = Convert.ToString(datatable1.Rows[0][0]);
            String value2 = Convert.ToString(datatable2.Rows[0][0]);

            try
            {

                chart_non_valider.Series[0].YValueMembers = "S1";
                String nom_dep = "";
                int Seuill = 0;
                String x2 = "";
                gestion_Departement gp = new gestion_Departement();
                gp.chercher_Departement3(Gestion_Paie_Oracle.Menu.pr.dep, out erreur, out nom_dep, out Seuill,out x2, out exist);
                // chart1.Series[0].IsVisibleInLegend = false;
                chart_non_valider.Titles[1].Text = "Periode : Du :" + debut.ToShortDateString() + "Au :" + fin.ToShortDateString() + "";
                chart_non_valider.Titles[2].Text = "Departement : " + nom_dep;
                chart_non_valider.Titles[3].Text = "Nombre d'employés  : " + value1 + "      " + "Seuile =" + Seuill;

                chart_non_valider.ChartAreas[0].AxisX.Maximum = 1;
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee + "");
            }

            try
            {

                //   gestion_demande.Somme_demandes_conges(Convert.ToDateTime(debut.Date.ToShortDateString()), Convert.ToDateTime(fin.Date.ToShortDateString()), Gestion_Paie_Oracle.Menu.pr.matricule_emp, out erreur, out sum, out exist);
                chart_valider.Series[0].YValueMembers = "S2";
                String nom_dep = "";
                int Seuill = 0;
                gestion_Departement gp = new gestion_Departement();
                String x2 = "";
                gp.chercher_Departement3(Gestion_Paie_Oracle.Menu.pr.dep, out erreur, out nom_dep, out Seuill,out x2, out exist);
                // chart1.Series[0].IsVisibleInLegend = false;
                chart_valider.Titles[1].Text = "Periode : Du :" + debut.ToShortDateString() + "Au :" + fin.ToShortDateString() + "";
                chart_valider.Titles[2].Text = "Departement : " + nom_dep;
                chart_valider.Titles[3].Text = "Nombre d'employés : " + value2 + "      " + "Seuile =" + Seuill;

                chart_valider.ChartAreas[0].AxisX.Maximum = 1;
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee + "");
            }


        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}