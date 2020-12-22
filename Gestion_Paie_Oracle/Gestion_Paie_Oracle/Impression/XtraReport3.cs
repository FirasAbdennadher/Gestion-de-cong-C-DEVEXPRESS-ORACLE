using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Gestion_Paie_Oracle.Impression
{
    public partial class XtraReport3 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport3()
        {
            InitializeComponent();
           /* xr_acpt.Visible = false;
            xr_madame.Visible = false;
            xr_monsieur.Visible = false;
            xr_modifie.Visible = false;
            xr_refu.Visible = false;

            p_date_accepter_avec_modif.Visible = false;
            p_date_accpeter_sans_modif.Visible = false;
            p_date_refus.Visible = false;

            p_au_accepter_avec_modofication.Visible = false;
            p_au_refu.Visible = false;
            p_au_accepter_sans_modifi.Visible = false;

            p_du_accepter_sans_modif.Visible = false;
            p_du_accepter_avec_modif.Visible = false;
            p_du_refus.Visible = false;*/

        }



        public void constructor(String nom, String prenom, DateTime datedemand, DateTime debut, DateTime fin, String status, String sex, String hd, String hf)//,String anner,String droit,String pris,String solde)
        {

                if (sex.Equals("Homme"))
                {
                    xr_monsieur.Visible = true;
                }
                else xr_madame.Visible = true;
                p_nom.Value = nom;
                p_prenom.Value = prenom;
                p_date_accpeter_sans_modif.Value = datedemand;//.ToShortDateString();
                p_au_accepter_sans_modifi.Value = fin;//.ToShortDateString();
                p_du_accepter_sans_modif.Value = debut;//.ToShortDateString();
                p_heur_deb.Value = hd;
                p_heur_fin.Value = hf;
                p_status.Value = status;
                p_conge_accorder_sans.Value = true;
            


        }
    }
}