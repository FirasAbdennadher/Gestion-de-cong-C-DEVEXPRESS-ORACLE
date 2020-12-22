using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Meiter;
using Gestion_Paie_Oracle.Impression;
using Metier;
using Gestion_Paie_Oracle;

namespace Gestion_Paie_Oracle.Simple_Fenetre
{
    public partial class Liste_fiche_demandeconger : DevExpress.XtraEditors.XtraForm
    {
        public static Liste_fiche_demandeconger edd;
        public String rrole;


        public Liste_fiche_demandeconger(String rrole)
        {
            InitializeComponent();
            this.rrole = rrole;
        }

        private void Liste_fiche_demandeconger_Load(object sender, EventArgs e)
        {
            edd = this;
        }
        String erreur = null;bool exist = false;
        private void supprimer_typeconge_btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        { Gestion_Demande_Class gdd = new Gestion_Demande_Class();
            String nomserv; int xx1;
            gestion_Service gs = new gestion_Service();
            type_conge tc = new type_conge();
            gestion_type_conge gtc = new gestion_type_conge();
         int   indexDgpersonel =gridView1.FocusedRowHandle;
            Demande_Conge_Class dem = new Demande_Conge_Class();
            gdd.chercher_Demande_conge_emp(gridView1.GetRowCellValue(indexDgpersonel, "ID_DEMANDE_CONGE").ToString(), out erreur, out dem, out exist);

            GestionPersonel gp = new GestionPersonel();
            Personel_class perr = new Personel_class();
            gp.chercher_Personel(gridView1.GetRowCellValue(indexDgpersonel, "MATRICULE") + "", out erreur, out perr, out exist);
            String s1 = perr.Matricule + "";

            var charArray = s1.ToCharArray(); //{'1','2','3','4','5'}

           gs.chercher_Service3(perr.Services, out erreur, out nomserv, out xx1, out exist);
            gtc.chercher_Type_conge_Valider(dem.ID_Conger, out erreur, out tc, out exist);
            Impression2 imp2 = new Impression2(Convert.ToString(charArray[0]), Convert.ToString(charArray[1]), Convert.ToString(charArray[2]), Convert.ToString(charArray[3]), Convert.ToString(charArray[4]), Convert.ToString(charArray[5]), Convert.ToDateTime(dem.Date_Debut), Convert.ToDateTime(dem.Date_fin), dem.Heur_Debut ,dem.Heur_Fin,perr.Nom+"", perr.Prenom, nomserv,Convert.ToString( dem.NombreJour), tc.Desgination, Convert.ToDateTime(dem.Date_Demande));
            imp2.imprimer_fiche_deemande();
            imp2.ShowDialog();
        
    }
    }
}