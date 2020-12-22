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
    public partial class Impression5 : Form
    {
        String nom;
        String prenom;
        DateTime datedem;
        DateTime d1;
        DateTime d2;
        String status;
        String sexe; String hd; String hf;

        public Impression5(String nom, String prenom, DateTime dd, DateTime d1, DateTime d2, String st, String sexe, String hd, String hf)//, String anner, String droit, String pris, String solde)
        {
            InitializeComponent();
            this.nom = nom;
            this.prenom = prenom;
            this.datedem = dd;
            this.d1 = d1;
            this.d2 = d2;
            status = st;
            this.sexe = sexe
                ;
            this.hd = hd; this.hf = hf;
        }


        public void imprimer()
        {
            XtraReport4_refus imp = new XtraReport4_refus();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in imp.Parameters)
                p.Visible = false;

            imp.constructor(nom, prenom, datedem, d1, d2, status, sexe, hd, hf);//, anner, droit, pris, solde);
            documentViewer1.DocumentSource = imp;
            imp.CreateDocument();
        }


    }
}
