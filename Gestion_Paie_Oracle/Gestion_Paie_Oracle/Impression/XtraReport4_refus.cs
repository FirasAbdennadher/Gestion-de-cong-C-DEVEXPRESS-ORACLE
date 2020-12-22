﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Gestion_Paie_Oracle.Impression
{
    public partial class XtraReport4_refus : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport4_refus()
        {
            InitializeComponent();
        }


        public void constructor(String nom, String prenom, DateTime datedemand, DateTime debut, DateTime fin, String status, String sex, String hd, String hf)//, String anner, String droit, String pris, String solde)
        {


            if (sex.Equals("Homme"))
            {
                xr_monsieur.Visible = true;
            }
            else xr_madame.Visible = true;

            p_nom.Value = nom;
            p_prenom.Value = prenom;
            p_date.Value = datedemand;//.ToShortDateString();
            p_au.Value = fin;//.ToShortDateString();
            p_du.Value = debut;//.ToShortDateString();
            p_hd.Value = hd;
            p_hf.Value = hf;
            p_motif.Value = status;
            p_refus.Value = true;
        }



    }
}
