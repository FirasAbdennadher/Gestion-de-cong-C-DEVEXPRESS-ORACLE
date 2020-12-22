using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gestion_Paie_Oracle.Impression
{
    public partial class Impression2 : Form
    {
        String mat_p1;
        String mat_p2;
        String mat_p3;
        String mat_p4;
        String mat_p5;
        String mat_p6;

        DateTime db_conge_picker;
        DateTime df_conge_picker;
        String heurd;
        String heurf;
        String nom_emp;
        String prenom_emmp;
        String service;
        String nbjour;
        DateTime datedemande_conge;
        String type_conge;
        public Impression2(String p1, String p2, String p3, String p4, String p5, String p6, DateTime db, DateTime df, String hd, String hf, String nom, String prenom, String s, String nb, String type, DateTime datedemande)
        {
            InitializeComponent();
            mat_p1 =p1;
            mat_p2 = p2;
            mat_p3 = p3;
            mat_p4 = p4;
            mat_p5 = p5;
            mat_p6= p6;

            db_conge_picker = db;
            df_conge_picker = df;
            heurd = hd;
            heurf = hf;
            nom_emp = nom;
            prenom_emmp = prenom;
            service = s;
            nbjour = nb;
            type_conge = type;
            datedemande_conge = datedemande;
        }



        public void imprimer_fiche_deemande()
        {
            XtraReport2 imp = new XtraReport2();

            foreach (DevExpress.XtraReports.Parameters.Parameter p in imp.Parameters)
                p.Visible = false;

            imp.initliasier(mat_p1, mat_p2, mat_p3, mat_p4, mat_p5, mat_p6 , db_conge_picker, df_conge_picker, heurd, heurf, nom_emp, prenom_emmp, service, nbjour,type_conge,datedemande_conge);
            documentViewer1.DocumentSource = imp;
            imp.CreateDocument();
        }


    }
}
