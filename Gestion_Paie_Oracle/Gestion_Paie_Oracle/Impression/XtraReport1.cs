using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Gestion_Paie_Oracle;
using System.Windows.Forms;

namespace Gestion_Paie_Oracle.Impression
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            InitializeComponent();
        }

        public void constructor(String nom, String prenom, DateTime datedemand, DateTime debut, DateTime fin, bool x)
        {
            
            if (x == true)
            {
                p_bool_acpter.Value = x;
            p_nom.Value = nom;
                p_prenom.Value = prenom;
                p_demande.Value = datedemand;//.ToShortDateString();
                p_debut.Value = debut;//.ToShortDateString();
                p_fin.Value = fin;//.ToShortDateString();
                MessageBox.Show("1"+nom + "" + debut + "" + p_debut.Value);

            }
            else if(x==false)
            {
                p_bool_ref.Value = true;
                p_nom.Value = nom;
                p_prenom.Value = prenom;
                p_demande.Value = datedemand;//.ToShortDateString();
                p_debut.Value = debut;//.ToShortDateString();
                p_fin.Value = fin;//.ToShortDateString();
                MessageBox.Show("2"+nom + "" + debut + "" + p_debut.Value);

            }


        }


    }
}
