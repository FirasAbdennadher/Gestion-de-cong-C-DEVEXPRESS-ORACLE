using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Gestion_Paie_Oracle.Impression
{
    public partial class XtraReport2 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport2()
        {
            InitializeComponent();
        }

        public void initliasier(String p1, String p2, String p3, String p4, String p5, String p6, DateTime db, DateTime df, String hd, String hf, String nom, String prenom, String s, String nb, String type, DateTime datedemande)
        {
            p_1.Value = p1;
            p_2.Value = p2;
            p_3.Value = p3;
            p_4.Value = p4;
            p_5.Value = p5;
            p_6.Value = p6;
            p_debut.Value = db;
            p_fin.Value = df;
            p_datedemande.Value = datedemande;
            p_nbjour.Value = nb;
            p_nom.Value = nom;
            p_prenom.Value = prenom;
            p_type.Value = type;
            p_service.Value = s;
            p_hd.Value = hd;
            p_hf.Value = hf;



        }



    }
}