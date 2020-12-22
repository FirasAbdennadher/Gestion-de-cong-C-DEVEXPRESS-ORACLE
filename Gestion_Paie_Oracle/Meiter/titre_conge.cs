using Acces;
//using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace Meiter
{
   public class titre_conge
    {

        private String numTitreconge;
        private String NUMDEMAND;

        public titre_conge(String numtitreconge, String NUMDEMANDs)
        {
            numTitreconge = numtitreconge;
            NUMDEMAND = NUMDEMANDs;
        }

        public titre_conge()
        {
            numTitreconge = "";
            NUMDEMAND = "";
        }

        public string NUMDEMANDs
        {
            get { return this.NUMDEMAND; }
            set { this.NUMDEMAND = value; }
        }


        public string numtitrecongeS
        {
            get { return this.numTitreconge; }
            set { this.numTitreconge = value; }
        }
    }
    public class gestion_titreconge
    {
        string rsql;
        Connexion cnx = new Connexion();
        OracleDataReader dr = null;


        public void Chercher_Titre(string id, out string erreur, out titre_conge tit, out Boolean exist)
        {
            erreur = null;
            tit = new titre_conge();
            exist = false;
            rsql = "select * from  TITRE_CONGE where  TITRE_CONGE.NUM_TITRECONGE='" + id + "' ";
            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {
                    exist = true;
                    dr.Read();
                    tit.numtitrecongeS = dr.GetString(0);
                    tit.NUMDEMANDs = dr.GetString(1);

                }
                dr.Close();
            }



        }

        public void chercher_ListeTitre(String critere, out String erreur, out List<titre_conge> list, out String dbb, out Boolean exist)
        {
            erreur = null;
            dbb = "";
            list = new List<titre_conge>();
            titre_conge tit = new titre_conge();
            exist = false;
            rsql = "select * from  TITRE_conge " + critere;

            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {
                        tit = new titre_conge();
                        tit.numtitrecongeS = dr.GetString(0);
                        tit.NUMDEMANDs = dr.GetString(1);

                        list.Add(tit);
                    }
                    dr.Close();
                }
            }


        }




        public void ajouter_Titre(titre_conge tit, out String erreur)
        {
            erreur = null;
            rsql = "insert into TITRE_CONGE values('"+ tit .numtitrecongeS+ "','"+tit.NUMDEMANDs+"') ";

            cnx.maj(rsql, out erreur);

        }
        public void supprimer_DEPARTEMENT(titre_conge tit, out String erreur)
        {
            erreur = null;
            rsql = "delete from TITRE_CONGE  where NUM_TITRECONGE='" + tit.numtitrecongeS + "' ";
            cnx.maj(rsql, out erreur);
        }
     /*   public void modifier_DEPARTEMENT(Departement_Class dep, out String erreur)
        {
            erreur = null;
            //update DEPARTEMENT d set d.DESGN_DEPARTEMENT ='XX' ,d.REPONSABLE_DEP='Emp5' where d.ID_DEPARTMENT='D6' and   not exists
            //(select 1  from DEPARTEMENT where 'Emp5' = REPONSABLE_DEP);
            rsql = "update DEPARTEMENT set DESGN_DEPARTEMENT ='" + dep.DESG_Dep + "',REPONSABLE_DEP='" + dep.RESPONSABLE + "',SEUILE_DEPARTEMENT='" + dep.Seuuuilee + "' where ID_DEPARTMENT='" + dep.ID_DEP + "' ";
            cnx.maj(rsql, out erreur);
        }
        */




    }
}
