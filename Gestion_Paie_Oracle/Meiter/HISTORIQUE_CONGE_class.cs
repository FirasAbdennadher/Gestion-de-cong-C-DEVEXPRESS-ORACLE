using Acces;
//using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace Metier
{
    public class HISTORIQUE_CONGE
    {
        private decimal arrier_conge;
        private decimal droit_annner_courant;
        private decimal pris_anner_courant;
        private String anner_conge;
        private String depasment_conge;
        private String conge_compensation;
        private String commentaire;
        private String id_histo;
        private String Matricule;

        public HISTORIQUE_CONGE(String idhisto, decimal arrier, decimal droitanner, decimal prisanner_courant, String annerconge, String depasemmnt, String compensation, String cmtr,String mat)
        {
            id_histo = idhisto;
            commentaire = cmtr;
            arrier_conge = arrier;
            anner_conge = annerconge;
            conge_compensation = compensation;
            depasment_conge = depasemmnt;
            droit_annner_courant = droitanner;
            pris_anner_courant = prisanner_courant;
            Matricule=mat;

        }

        public HISTORIQUE_CONGE()
        {
            id_histo = "";
            commentaire = "";
            arrier_conge = 0;
            anner_conge = "";
            conge_compensation = "";
            depasment_conge = "";
            droit_annner_courant = 21;
            pris_anner_courant = 0;
            Matricule = "";

        }



        public String MATRICULE
        {
            get { return this.Matricule; }
            set { this.Matricule = value; }
        }

        public String Commentaire
        {
            get { return this.commentaire; }
            set { this.commentaire = value; }
        }

        public String Id_Historique
        {
            get { return this.id_histo; }
            set { this.id_histo = value; }
        }


        public String Anner_conge
        {
            get { return this.anner_conge; }
            set { this.anner_conge = value; }
        }
        public String Depasemment
        {
            get { return this.depasment_conge; }
            set { this.depasment_conge = value; }
        }
        public String Compsensation
        {
            get { return this.conge_compensation; }
            set { this.conge_compensation = value; }
        }



        public decimal Arrier_conge
        {
            get { return this.arrier_conge; }
            set { this.arrier_conge = value; }
        }
        public decimal Pris_anner_courant
        {
            get { return this.pris_anner_courant; }
            set { this.pris_anner_courant = value; }
        }

        public decimal Droit_annner_courant
        {
            get { return this.droit_annner_courant; }
            set { this.droit_annner_courant = value; }
        }

    }
    public class Gestion_Historique_Cong
    {

        string rsql;
        Connexion cnx = new Connexion();
        OracleDataReader dr = null;

        public void chercher_ListHistorique_conge_emp(String critere, out string erreur, out List<HISTORIQUE_CONGE> histolist, out Boolean exist)
        {
            erreur = null;
            HISTORIQUE_CONGE histoconger = new HISTORIQUE_CONGE();
            histolist = new List<HISTORIQUE_CONGE>();
            exist = false;
            rsql = "select * from  HISTORIQUE_CONGE where  HISTORIQUE_CONGE.MATRICULE='" + critere+"' ";
            cnx.select(rsql, out erreur, out dr);



            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {
                       histoconger = new HISTORIQUE_CONGE();
                        histoconger.Id_Historique = dr.GetString(0);
                        histoconger.Arrier_conge = dr.GetDecimal(1);
                        histoconger.Droit_annner_courant = dr.GetDecimal(2);
                        histoconger.Pris_anner_courant = dr.GetDecimal(3);
                        histoconger.Anner_conge = dr.GetString(4);
                        histoconger.Depasemment = dr.GetString(5);
                        histoconger.Compsensation = dr.GetString(6);
                        histoconger.Commentaire = dr.GetString(7);
                        histoconger.MATRICULE = dr.GetString(8);


                        histolist.Add(histoconger);
                    }
                }
                dr.Close();

            }
        }



        public void chercher_Historique_conge_emp(String critere, String anner, out string erreur, out HISTORIQUE_CONGE histo, out Boolean exist)
        {
            erreur = null;
            histo = new HISTORIQUE_CONGE();
            exist = false;
            rsql = "select * from  HISTORIQUE_CONGE where  HISTORIQUE_CONGE.MATRICULE='" + critere + "' and  HISTORIQUE_CONGE.ANNER_CONGE ='"+anner+"'  ";
            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {
                    exist = true;
                    dr.Read();
                    histo.Id_Historique = dr.GetString(0);
                    histo.Arrier_conge = dr.GetDecimal(1);
                    histo.Droit_annner_courant = dr.GetDecimal(2);
                    histo.Pris_anner_courant = dr.GetDecimal(3);
                    histo.Anner_conge = dr.GetString(4);
                    histo.Depasemment = dr.GetString(5);
                    histo.Compsensation = dr.GetString(6);
                    histo.Commentaire = dr.GetString(7);
                    histo.MATRICULE = dr.GetString(8);
                }
                dr.Close();
            }
          
        }


        public void ajouter_Histo_PErso(HISTORIQUE_CONGE histo, out String erreur)
        {
            //  dr.Close();
            erreur = null;
  rsql = "insert into  HISTORIQUE_CONGE values('" + histo.Id_Historique + "','" + histo.Arrier_conge + "','" + histo.Droit_annner_courant + "','" + histo.Pris_anner_courant + "','" + histo.Anner_conge + "','" + histo.Depasemment + "','" + histo.Compsensation + "','" + histo.Commentaire + "','" + histo.MATRICULE + "')";
                cnx.maj(rsql, out erreur);

        }
        public void supprimer_Histo_perso(HISTORIQUE_CONGE histo, out String erreur)
        {
            erreur = null;
            rsql = "delete from  HISTORIQUE_CONGE  where ID_HISTORIQUE='" + histo.Id_Historique + "' ";
            cnx.maj(rsql, out erreur);
        }

        public void modifier_Personel_Historique(HISTORIQUE_CONGE histo, out String erreur)
        {
            erreur = null;
rsql = "update  HISTORIQUE_CONGE set ARRIERE_CONGE='" + histo.Arrier_conge + "',DROIT_ANNER_COURANT='" + histo.Droit_annner_courant + "',PRIS_ANNER_COURANT='" + histo.Pris_anner_courant + "',ANNER_CONGE='" + histo.Anner_conge + "',DEPASEMMENT_CONGE='" + histo.Depasemment + "',CONGE_COMPENSATION='" + histo.Compsensation + "',COMMENTAIRE_CONGE='" + histo.Commentaire + "' where   ID_HISTORIQUE='"+histo.Id_Historique+"' ";

            cnx.maj(rsql, out erreur);
        }





        public void getArrierAnnerDernier(int anner, String MAT, out string erreur, out string sum, out Boolean exist)
        {
            erreur = null;
            sum = "";
            exist = false;
            anner = anner - 1;
            rsql = " select  HISTORIQUE_CONGE.ARRIERE_CONGE from  HISTORIQUE_CONGE  where SUBSTR(anner_conge, 1, 4) =" + anner + " and MATRICULE='" + MAT + "' ";

            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {
                    exist = true;
                    dr.Read();
                    sum = dr[0].ToString();
                }
                dr.Close();
            }


        }



        public void Droit_arrier_pris_conge_anner_precedent(String anner, String MAT, out string erreur, out string nombrejour, out string arrier, out string priss, out Boolean exist)
        {
            erreur = null;
            nombrejour = "";
            arrier = "";
            priss = "";
            exist = false;
            rsql = "select  HISTORIQUE_CONGE.DROIT_ANNER_COURANT, HISTORIQUE_CONGE.ARRIERE_CONGE, HISTORIQUE_CONGE.PRIS_ANNER_COURANT from  HISTORIQUE_CONGE where  HISTORIQUE_CONGE.ANNER_CONGE ='" + anner + "' and  HISTORIQUE_CONGE.MATRICULE = '" + MAT + "' ";
            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {
                    exist = true;
                    dr.Read();
                    nombrejour = dr[0].ToString();
                    arrier = dr[1].ToString();
                    priss = dr[2].ToString();
                }
                dr.Close();
            }


        }


        public void Historique_annercourante(String anner, String mat, out string erreur, out HISTORIQUE_CONGE histo, out Boolean exist)
        {
            histo = new HISTORIQUE_CONGE();
            erreur = null;
            exist = false;
            rsql = "select *  from HISTORIQUE_CONGE where ANNER_CONGE='"+anner+"' and MATRICULE='"+mat+"'";
                cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {
                    exist = true;
                    dr.Read();
                    histo.Arrier_conge = Convert.ToDecimal(dr[1]);
                    histo.Droit_annner_courant = Convert.ToDecimal(dr[2]);
                    histo.Pris_anner_courant = Convert.ToDecimal(dr[3]);
                    histo.Anner_conge = Convert.ToString(dr[4]);

                }
                dr.Close();
            }


        }


        


    }
}