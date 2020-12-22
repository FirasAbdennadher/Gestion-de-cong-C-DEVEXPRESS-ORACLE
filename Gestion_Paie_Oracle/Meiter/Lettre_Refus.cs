using Acces;
//using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace Meiter
{
  public  class Lettre_Refus
    {

        private String numLettRejet;
        private String NUMDEMAND;

        public Lettre_Refus(String numLettRejets, String NUMDEMANDs)
        {
            numLettRejet = numLettRejets;
            NUMDEMAND = NUMDEMANDs;
        }

        public Lettre_Refus()
        {
            numLettRejet = "";
            NUMDEMAND = "";
        }

        public string NUMDEMANDs
        {
            get { return this.NUMDEMAND; }
            set { this.NUMDEMAND = value; }
        }


        public string numLettRejetS
        {
            get { return this.numLettRejet; }
            set { this.numLettRejet = value; }
        }
    }

    public class gestion_LettreRefus
    {
        string rsql;
        Connexion cnx = new Connexion();
        OracleDataReader dr = null;


        public void Chercher_Refus(string id, out string erreur, out Lettre_Refus lf, out Boolean exist)
        {
            erreur = null;
            lf = new Lettre_Refus();
            exist = false;
            rsql = "select * from  LETTRE_REJET where  LETTRE_REJET.NUM_LETTREREJET='" + id + "' ";
            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {
                    exist = true;
                    dr.Read();
                    lf.numLettRejetS = dr.GetString(0);
                    lf.NUMDEMANDs = dr.GetString(1);

                }
                dr.Close();
            }



        }

        public void chercher_ListeLettre(String critere, out String erreur, out List<Lettre_Refus> list, out String dbb, out Boolean exist)
        {
            erreur = null;
            dbb = "";
            list = new List<Lettre_Refus>();
            Lettre_Refus tit = new Lettre_Refus();
            exist = false;
            rsql = "select * from  LETTRE_REJET " + critere;

            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {
                        tit = new Lettre_Refus();
                        tit.numLettRejetS = dr.GetString(0);
                        tit.NUMDEMANDs = dr.GetString(1);

                        list.Add(tit);
                    }
                    dr.Close();
                }
            }


        }




        public void ajouter_Rejet(Lettre_Refus tit, out String erreur)
        {
            erreur = null;
            rsql = "insert into LETTRE_REJET values('" + tit.numLettRejetS + "','" + tit.NUMDEMANDs + "') ";

            cnx.maj(rsql, out erreur);

        }
        public void supprimer_Rejet(Lettre_Refus tit, out String erreur)
        {
            erreur = null;
            rsql = "delete from LETTRE_REJET  where NUM_LETTREREJET='" + tit.numLettRejetS + "' ";
            cnx.maj(rsql, out erreur);
        }




    }

}
