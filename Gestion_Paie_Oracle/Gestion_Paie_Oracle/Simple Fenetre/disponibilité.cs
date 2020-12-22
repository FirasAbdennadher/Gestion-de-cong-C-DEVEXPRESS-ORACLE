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
using DevExpress.XtraCharts;
using Oracle.ManagedDataAccess.Client;

namespace Gestion_Paie_Oracle.Simple_Fenetre
{
    public partial class disponibilité : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DateTime debut;
        DateTime fin;String Service = "";
        public disponibilité(DateTime db,DateTime df,String sv)
        {
            InitializeComponent();
            this.debut = db;
            this.fin = df;
            this.Service = sv;
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
     

        private void disponibilité_Load(object sender, EventArgs e)
        {
            #region remplir table database to gridview 

            sqlconnection = new OracleConnection(ConnectionString);
            String d11 = Convert.ToString(debut);
            String d22 = Convert.ToString(fin);
            MessageBox.Show("tao ! :" + debut.ToShortDateString());
            Query = "select count(*) as S1 from  DEMANDE_CONGE where status='Non Encore Traité par GRH' and  DATE_DEMANDE between '" + debut.ToShortDateString() + "' and'" + fin.ToShortDateString() + "' ";// and MATRICULE in (select MATRICULE from employe  where SERVICE in(select id_service from service where RESPONSABLE_SERVICE ='" + Gestion_Paie_Oracle.Menu.pr.matricule_emp + "' ))";

            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable1 = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable1);
            dEMANDECONGEBindingSource1.DataSource = datatable1;

            #endregion
            #region fdf
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select count(*) as S2 from  DEMANDE_CONGE   where  status = 'Accepter Par le GRH' or status = 'Accepter Par le GRH,mais avec changement du date a cause du disponibilité des employés' and  DATE_DEMANDE between '" + debut.ToShortDateString() + "' and'" + fin.ToShortDateString() + "' ";// and MATRICULE in (select MATRICULE from employe  where SERVICE in(select id_service from service where RESPONSABLe_service ='" + Gestion_Paie_Oracle.Menu.pr.matricule_emp + "' ))";

            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable2 = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable2);
            dEMANDECONGEBindingSource.DataSource = datatable2;

            #endregion
            String sum = "";
            //   chart1.ChartAreas[0].AxisY.Interval = 1.5;
            String value1 = Convert.ToString(datatable1.Rows[0][0]);
            String value2 = Convert.ToString(datatable2.Rows[0][0]);
            MessageBox.Show(value1 + "  " + value2);

            try
            {

                //   gestion_demande.Somme_demandes_conges(Convert.ToDateTime(debut.Date.ToShortDateString()), Convert.ToDateTime(fin.Date.ToShortDateString()), Gestion_Paie_Oracle.Menu.pr.matricule_emp, out erreur, out sum, out exist);
                chart1.Series[0].YValueMembers ="S1" ;
                String nom_sv = "";
                int Seuill =0;
                gestion_servie.chercher_Service3(Gestion_Paie_Oracle.Menu.pr.sv, out erreur, out nom_sv,out Seuill, out exist);
                // chart1.Series[0].IsVisibleInLegend = false;
                chart1.Titles[1].Text = "Periode : Du :" + debut.ToShortDateString() + "Au :" + fin.ToShortDateString() + "";
                chart1.Titles[2].Text = "Service : " + nom_sv;
                chart1.Titles[3].Text = "Nombre d'employés : " + value1+ "      " + "Seuile ="+Seuill;

             chart1.ChartAreas[0].AxisX.Maximum = 1;
            }catch(Exception eee)
            {
                MessageBox.Show(eee+"");
            }

            try
            {

                //   gestion_demande.Somme_demandes_conges(Convert.ToDateTime(debut.Date.ToShortDateString()), Convert.ToDateTime(fin.Date.ToShortDateString()), Gestion_Paie_Oracle.Menu.pr.matricule_emp, out erreur, out sum, out exist);
                chart2.Series[0].YValueMembers = "S2";
                String nom_sv = "";
                int Seuill = 0;
                gestion_servie.chercher_Service3(Gestion_Paie_Oracle.Menu.pr.sv, out erreur, out nom_sv, out Seuill, out exist);
                // chart1.Series[0].IsVisibleInLegend = false;
                chart2.Titles[1].Text = "Periode : Du :" + debut.ToShortDateString() + "Au :" + fin.ToShortDateString() + "";
                chart2.Titles[2].Text = "Service : " + nom_sv;
                chart2.Titles[3].Text = "Nombre d'employés : " + value2 + "      " + "Seuile =" + Seuill;

                chart2.ChartAreas[0].AxisX.Maximum = 1;
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee + "");
            }

        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            #region remplir table database to gridview 

            sqlconnection = new OracleConnection(ConnectionString);
            String d11 = Convert.ToString(debut);
            String d22 = Convert.ToString(fin);
            MessageBox.Show(Service + "g");
            Query = "select * from  DEMANDE_CONGE where DATE_DEMANDE between '" + d11.Substring(0, 10) + "' and'" + d22.Substring(0, 10) + "' and MATRICULE in (select MATRICULE from employe where SERVICE='" + Service + "')  ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dEMANDECONGEBindingSource1.DataSource = datatable;

            #endregion

            chart1.ChartAreas[0].AxisY.Interval = 1.5;

            chart1.Series[0].XValueMember = "MATRICULE";

            chart1.Series[0].YValueMembers = "NOMBREJOUR";

            chart1.Series[0].IsVisibleInLegend = false;
        }

        private void parremployer_ItemClick(object sender, ItemClickEventArgs e)
        {
            #region remplir table database to gridview 

            sqlconnection = new OracleConnection(ConnectionString);
            String d11 = Convert.ToString(debut);
            String d22 = Convert.ToString(fin);
            MessageBox.Show(d11.Substring(0, 10) + "");
            Query = "select * from  DEMANDE_CONGE where DATE_DEMANDE > '" + d11.Substring(0, 10) + "' and DATE_DEMANDE < '" + d22.Substring(0, 10) + "' and MATRICULE in (select MATRICULE from employe where SERVICE='" + Service + "')  ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dEMANDECONGEBindingSource1.DataSource = datatable;

            #endregion

            chart1.ChartAreas[0].AxisY.Interval = 1.5;

            chart1.Series[0].XValueMember = "MATRICULE";

            chart1.Series[0].YValueMembers = "NOMBREJOUR";

            chart1.Series[0].IsVisibleInLegend = false;
        }
    }
}