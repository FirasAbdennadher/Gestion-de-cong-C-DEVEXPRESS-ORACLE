using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Gestion_Paie_Oracle.Impression
{
    public partial class Impression : DevExpress.XtraEditors.XtraForm
    {
        String nom;
        String prenom;
        DateTime datedem;
        DateTime d1;
        DateTime d2;

        bool x;
        public Impression(String nom, String prenom, DateTime dd, DateTime d1, DateTime d2, bool xx)
        {
            InitializeComponent();
            this.nom = nom;
            this.prenom = prenom;
            this.datedem = dd;
            this.d1 = d1;
            this.d2 = d2;
            x = xx;

        }

        public void imprimer()
        {
            XtraReport1 imp = new XtraReport1();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in imp.Parameters)
                p.Visible = false;


            imp.constructor(nom, prenom, datedem, d1, d2, x);
            documentViewer1.DocumentSource = imp;
            imp.CreateDocument();
        }



        private void Impression_Load(object sender, EventArgs e)
        {

        }

     
    }
}