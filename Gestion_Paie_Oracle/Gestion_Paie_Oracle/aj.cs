using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Meiter;
using Metier;
using Acces;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gestion_Paie_Oracle
{
    public partial class aj : Form
    {
        public aj()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            ajj_class a = new ajj_class();
            String errrr = null; Int32 ss = 0; bool ee = false;

            a.counttt(out errrr, out ss, out ee);
            MessageBox.Show(ss + "");
            /*  string queryString = "SELECT count(1) from AJJ";
             String cs = "Data Source=Firas-PC;user Id=firas ;Password=joker0;";

              using (OracleConnection connection = new OracleConnection(cs))
              {
                  OracleCommand command = new OracleCommand(queryString, connection);

                  connection.Open();
                  OracleDataReader reader = command.ExecuteReader();
                  while (reader.Read())
                  {
                      MessageBox.Show(Convert.ToInt64( reader[0])+"");
                  }
                  reader.Close();
              }
          }*/

        }/*

            /*   String erreur = null;
            bool exit = false;
            Int32 ss = 0;
           Connexion co= new Connexion();

            co.nombreline(out ss);
            if (errur == null)
                MessageBox.Show(ss + "");
            else MessageBox.Show(errur); */
        private void button2_Click(object sender, EventArgs e)
        {
            ajj_class aa = new ajj_class
                ();
            bool eex = false;
            string val = "";
            String erreur = null;
            // aa.nombre( "01/01/20","01/0220", "Emp2", out erreur, out val, out eex);

            aa.nombre(Convert.ToDateTime(dateTimePicker1.Value.ToShortTimeString()), Convert.ToDateTime(dateTimePicker2.Value.ToShortTimeString()), "Emp2", out erreur, out val, out eex);
            if (erreur == null)
                MessageBox.Show(val + "");
            else MessageBox.Show(erreur);
        }

        private void aj_Load(object sender, EventArgs e)
        {

        }
        #region "initialisation"

        string erreur = null;
        Boolean exist = false;
        gestion_type_conge gestion_typeconge = new gestion_type_conge();
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

        String ConnectionString = "Data Source=Firas-PC;user Id=firas ;Password=joker0;";
        public string Query;
        public DataSet dataset;
        public DataTable datatable;
        public OracleDataAdapter sqladapter;
        #endregion
        

        private void button4_Click(object sender, EventArgs e)
        {

            var s = new Series();
            s.ChartType = SeriesChartType.Bar;

            var d = new DateTime(2013, 04, 01);

            s.Points.AddXY(d, 3);
            s.Points.AddXY(d.AddMonths(-1), 2);
            s.Points.AddXY(d.AddMonths(-2), 1);
            s.Points.AddXY(d.AddMonths(-3), 4);
            MessageBox.Show(s.Points.AddXY(d.AddMonths(-3), 4)+"");

            chart1.Series.Clear();
            chart1.Series.Add(s);


            chart1.Series[0].XValueType = ChartValueType.DateTime;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd";
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
            chart1.ChartAreas[0].AxisX.IntervalOffset = 1;

            chart1.Series[0].XValueType = ChartValueType.DateTime;
            DateTime minDate = new DateTime(2013, 01, 01).AddSeconds(-1);

            DateTime maxDate = new DateTime(2013, 05, 01); // or DateTime.Now;
            chart1.ChartAreas[0].AxisX.Minimum = minDate.ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = maxDate.ToOADate();
            MessageBox.Show(maxDate.ToOADate()+ ".."+ minDate.ToOADate());

        }

        private void button5_Click(object sender, EventArgs e)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select * from  DEMANDE_CONGE where DATE_DEMANDE between '" + dateTimePicker1.Value.Date.ToShortDateString() + "' and'" + dateTimePicker1.Value.Date.ToShortDateString() + "'  ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            //     dEMANDECONGEBindingSource.DataSource = datatable;
            this.chart1.DataSource = datatable;
            this.chart1.DataBind();

            #endregion

            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("City", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("Population", typeof(int));

            dt.Rows.Add(0, "City1", "State1", 100);
            dt.Rows.Add(1, "City2", "State1", 30);
            dt.Rows.Add(2, "City3", "State1", 40);
            dt.Rows.Add(3, "City1", "State2", 80);
            dt.Rows.Add(4, "City2", "State2", 70);

            // bind the data table to chart
            this.chart1.Series.Clear();

            var series = this.chart1.Series.Add("Series 1");
            series.XValueMember = "MATRICULE";

            series.YValueMembers = "NOMBREJOUR";

            //series.XValueMember = "Id";
            //series.YValueMembers = "Population";

            series.ChartType = SeriesChartType.Column;

            // custom labels 
            foreach (var g in datatable.AsEnumerable().GroupBy(x => x.Field<string>("MATRICULE")))
            {
                string state = g.Key;
                var cities = g.Select(r => new { Id = r.Field<decimal>("NOMBREJOUR"), City = r.Field<string>("MATRICULE") });
                // find min-max
                decimal min = cities.Min(y => y.Id);
                decimal max = cities.Max(y => y.Id);
                // city labels
                foreach (var city in cities)
                {
                    var label = new CustomLabel(Convert.ToDouble(Convert.ToDecimal(city.Id) - 1), Convert.ToDouble(Convert.ToDecimal(city.Id) + 1), city.City, 0, LabelMarkStyle.None);
                    this.chart1.ChartAreas[0].AxisX.CustomLabels.Add(label);
                }
                // city states
                var statelabel = new CustomLabel(Convert.ToDouble(min), Convert.ToDouble(max), state, 1, LabelMarkStyle.LineSideMark);
                this.chart1.ChartAreas[0].AxisX.CustomLabels.Add(statelabel);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // fill the data table with values
            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("City", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("Population", typeof(int));

            dt.Rows.Add(0, "City1", "State1", 100);
            dt.Rows.Add(1, "City2", "State1", 30);
            dt.Rows.Add(2, "City3", "State1", 40);
            dt.Rows.Add(3, "City1", "State2", 80);
            dt.Rows.Add(4, "City2", "State2", 70);

            // bind the data table to chart
            this.chart1.Series.Clear();

            var series = this.chart1.Series.Add("Series 1");
            series.XValueMember = "Id";
            series.YValueMembers = "Population";

            series.ChartType = SeriesChartType.Column;
            this.chart1.DataSource = dt;
            this.chart1.DataBind();

            // custom labels 
            foreach (var g in dt.AsEnumerable().GroupBy(x => x.Field<string>("State")))
            {
                string state = g.Key;
                var cities = g.Select(r => new { Id = r.Field<int>("Id"), City = r.Field<string>("City") });
                // find min-max
                int min = cities.Min(y => y.Id);
                int max = cities.Max(y => y.Id);
                // city labels
                foreach (var city in cities)
                {
                    var label = new CustomLabel(city.Id - 1, city.Id + 1, city.City, 0, LabelMarkStyle.None);
                    this.chart1.ChartAreas[0].AxisX.CustomLabels.Add(label);
                }
                // city states
                var statelabel = new CustomLabel(min, max, state, 1, LabelMarkStyle.LineSideMark);
                this.chart1.ChartAreas[0].AxisX.CustomLabels.Add(statelabel);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DateTime firstDay = new DateTime(2013, 01, 01);
            DateTime secondDay = new DateTime(2013, 01, 02);

            int[] group1 = new int[6] { 1, 6, 7, 5, 4, 9 };
            int[] group2 = new int[6] { 2, 5, 8, 6, 8, 3 };

            DateTime[] days = new DateTime[6] { firstDay, firstDay, firstDay, secondDay, secondDay, secondDay };

            chart1.Series.Add(new Series("Group 1"));

            chart1.Series[0].Points.DataBindXY(days, group1);
            chart1.Series[0].ChartType = SeriesChartType.Column;

            chart1.Series.Add(new Series("Group 2"));
            chart1.Series[1].Points.DataBindXY(days, group2);
            chart1.Series[1].ChartType = SeriesChartType.Column;

            double start = chart1.Series[0].Points[0].XValue;
            double end = chart1.Series[0].Points[chart1.Series[0].Points.Count - 1].XValue;
            double half = (start + end) / 2;

            chart1.ChartAreas[0].AxisX2.Enabled = AxisEnabled.True;

            chart1.ChartAreas[0].AxisX2.CustomLabels.Add(1, 3, "Category 1", 1, LabelMarkStyle.LineSideMark);

        }
        private void button3_Click(object sender, EventArgs e)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            //    Query = "select count(*) as SS from  DEMANDE_CONGE where DATE_DEBUT_CONGE >= '" + dateTimePicker1.Value.Date.ToShortDateString() + "' and DATE_DEBUT_CONGE<= '" + dateTimePicker2.Value.Date.ToShortDateString() + "'  ";
            Query = "select count(*) as  SS from  DEMANDE_CONGE where DATE_DEMANDE between '" + dateTimePicker1.Value.ToShortDateString() + "' and'" + dateTimePicker2.Value.ToShortDateString() + "' and MATRICULE in (select MATRICULE from employe  where SERVICE in(select id_service from service where RESPONSABLE_service ='Emp1' ))";

            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dEMANDECONGEBindingSource.DataSource = datatable;
            #endregion
            //MessageBox.Show(datatable.Rows[0].Field<int>(0) + "");
            MessageBox.Show(datatable.Rows[0][0] + "");


            //Demande_Conge_Class dc = new Demande_Conge_Class();
            //  chart1.ChartAreas[0].AxisX.IsLogarithmic = true;
            // chart1.ChartAreas[0].AxisX.LogarithmBase = 1;
            // chart1.ChartAreas[0].AxisY.Minimum = 0;
            //   chart1.ChartAreas[0].AxisY.Maximum = 21;
            //  chart1.ChartAreas[0].AxisY.Interval = 0.5;
            //   MessageBox.Show(dateTimePicker1.Value.ToShortDateString());

            // chart1.Series[0].XValueMember = "";
            //
            chart1.Series[0].YValueMembers = "SS";
            //chart1.ChartAreas[0].AxisX.LabelStyle.Format = "";//dateTimePicker1.Value.ToShortDateString();
        //    chart1.Series[0].XValueType =ChartValueType.DateTime;
            // DateTime minDate = new DateTime(2013, 01, 01);
            //DateTime maxDate = DateTime.Now;
            DateTime minDate = new DateTime(dateTimePicker1.Value.Year,dateTimePicker1.Value.Month,dateTimePicker1.Value.Day);

            DateTime maxDate = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day);
           /* chart1.ChartAreas[0].AxisX.Minimum = minDate.ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = maxDate.ToOADate();
            */
     //      chart1.ChartAreas[0].AxisX.Minimum = ;//Convert.ToDouble( dateTimePicker1.Value.ToShortDateString());//minDate.ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum =1;//Convert.ToDouble(dateTimePicker2.Value.ToShortDateString());//maxDate.ToOADate();

            //  chart1.Series[0].IsVisibleInLegend = false;
           // chart1.Titles[1].Text = "Periode : Du "+dat;


        }

        private void button8_Click(object sender, EventArgs e)
        {
            #region remplir table database to gridview 
            sqlconnection = new OracleConnection(ConnectionString);
            Query = "select * from  DEMANDE_CONGE where DATE_DEMANDE between '" + dateTimePicker1.Value.Date.ToShortDateString() + "' and'" + dateTimePicker1.Value.Date.ToShortDateString() + "'  ";
            sqlcommand = new OracleCommand(Query, sqlconnection);
            sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(datatable);
            dEMANDECONGEBindingSource.DataSource = datatable;
            #endregion

            chart1.ChartAreas[0].AxisY.Interval = 0.5;

            chart1.Series[0].XValueMember = "";

            chart1.Series[0].YValueMembers = "";

            chart1.Series[0].IsVisibleInLegend = false;

           // chart1.ChartAreas[0].AxisX2.Enabled = AxisEnabled.True;
         //   chart1.ChartAreas[0].AxisX2.CustomLabels.Add(0.5, 1.5, "Category 1", 1, LabelMarkStyle.LineSideMark);


        }

        private void button9_Click(object sender, EventArgs e)
        {
            Message_Personnelle.Explication_Class.ShowMessage("Le texteeee", "Titre", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }


    /*  ajj_class aa = new ajj_class("qsd", Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()));
aa.counttt(out errur, out ss, out exit);
if (errur == null)
MessageBox.Show(ss + "");
else MessageBox.Show(errur);*/
    /*String errur = null;
    bool exit = false;

    Personel_class pp = new Personel_class();
    GestionPersonel gp = new GestionPersonel();
    List<Personel_class> list = new List<Personel_class>();
    MessageBox.Show(dateTimePicker1.Value.ToShortDateString()+"");
    gp.comare(Convert.ToDateTime(DateTime.Now.Date.ToShortDateString()), out errur,out list, out exit);

    foreach(Personel_class x in list)
    {
        MessageBox.Show(x.Nom);
    }
    if (exit == true)
    {
        MessageBox.Show("gaga");
    }
    else MessageBox.Show("" + errur);*/
    /* String dd = dateTimePicker1.Text.ToString();
     DateTime d1 = Convert.ToDateTime(dd.ToString());
     MessageBox.Show(dateTimePicker1.Value.ToShortDateString() + "");
     Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()).ToString("MMM.dd,yyyy ");
     ajj_class aa = new ajj_class("qsd", Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()));
     String errur = null;
     aa.ajouter(aa, out errur);
     if (!(errur == null))
     {
         MessageBox.Show(errur);
*/
}