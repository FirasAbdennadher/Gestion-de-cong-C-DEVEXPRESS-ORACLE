using Acces;
//using Oracle.DataAccess.Client;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meiter
{
   public class Bon_reprise
    {
        private String NUM_BONREPRISE;
        private DateTime DATE_REPRISE_REEL;
        private String NUM_TITRECONGE;


        public Bon_reprise(String NUM_BONREPRISES, DateTime DATE_REPRISE_REELs, String NUM_TITRECONGES)
        {
            NUM_BONREPRISE = NUM_BONREPRISES;
            DATE_REPRISE_REEL = DATE_REPRISE_REELs;
            NUM_TITRECONGE = NUM_TITRECONGES;
        }

        public Bon_reprise()
        {
            NUM_BONREPRISE = "";
            DATE_REPRISE_REEL = DateTime.Now.Date;
            NUM_TITRECONGE = "";
        }
        public String NUM_TITRECONGES
        {
            get { return this.NUM_TITRECONGE; }
            set { this.NUM_TITRECONGE = value; }
        }

        public string NUM_BONREPRISES
        {
            get { return this.NUM_BONREPRISE; }
            set { this.NUM_BONREPRISE = value; }
        }


        public DateTime DATE_REPRISE_REELS
        {
            get { return this.DATE_REPRISE_REEL; }
            set { this.DATE_REPRISE_REEL = value; }
        }
    }
    public class gestion_BonReprise
    {
        string rsql;
        Connexion cnx = new Connexion();
        Oracle.ManagedDataAccess.Client.OracleDataReader dr = null;


        public void Chercher_Reprise(string id, out string erreur, out Bon_reprise br, out Boolean exist)
        {
            erreur = null;
            br = new Bon_reprise();
            exist = false;
            rsql = "select * from  BON_REPRISE where  BON_REPRISE.NUM_BONREPRISE='" + id + "' ";
            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {
                    exist = true;
                    dr.Read();
                    br.NUM_BONREPRISES = dr.GetString(0);
                    br.DATE_REPRISE_REELS = dr.GetDateTime(1);
                    br.NUM_TITRECONGES = dr.GetString(2);

                }
                dr.Close();
            }



        }

        public void chercher_ListeBon(String critere, out String erreur, out List<Bon_reprise> list, out String dbb, out Boolean exist)
        {
            erreur = null;
            dbb = "";
            list = new List<Bon_reprise>();
            Bon_reprise br = new Bon_reprise();
            exist = false;
            rsql = "select * from  BON_REPRISE " + critere;

            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {
                        br = new Bon_reprise();
                        br.NUM_BONREPRISES = dr.GetString(0);
                        br.DATE_REPRISE_REELS = dr.GetDateTime(1);
                        br.NUM_TITRECONGES = dr.GetString(2);

                        list.Add(br);
                    }
                    dr.Close();
                }
            }


        }




        public void ajouter_Bon(Bon_reprise bon, out String erreur)
        {
            erreur = null;
            rsql = "insert into BON_REPRISE values('" + bon.NUM_BONREPRISES + "','" + bon.DATE_REPRISE_REELS.ToShortDateString() + "','"+bon.NUM_TITRECONGES+"') ";

            cnx.maj(rsql, out erreur);

        }
        public void supprimer_Bon(Bon_reprise bon, out String erreur)
        {
            erreur = null;
            rsql = "delete from BON_REPRISE  where NUM_BONREPRISE='" + bon.NUM_BONREPRISES+ "' ";
            cnx.maj(rsql, out erreur);
        }




    }

}
