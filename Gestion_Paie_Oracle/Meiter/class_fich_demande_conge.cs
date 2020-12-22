using Acces;
//using Oracle.DataAccess.Client;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meiter
{
    public class class_fich_demande_conge
    {
        private String id_fiche;
        private String id_demande;

        public class_fich_demande_conge(String id, String demande)
        {
            id_fiche = id;
            id_demande = demande;
        }

        public class_fich_demande_conge()
        {
            id_fiche = "";
            id_demande = "";
        }



        public String Demande
        {
            get { return this.id_demande; }
            set { this.id_demande = value; }
        }
        public String Id_fiche
        {
            get { return this.id_fiche; }
            set { this.id_fiche = value; }
        }

    }

    public class gestion_Fiche_demande
    {


        string rsql;
        Connexion cnx = new Connexion();
        OracleDataReader dr = null;


        //chercher fonction

        /*  public void Chercher_Fiche(string id, out string erreur, out Departement_Class dep, out Boolean exist)
          {
              erreur = null;
              dep = new Departement_Class();
              exist = false;
              rsql = "select * from  DEPARTEMENT where  DEPARTEMENT.ID_DEPARTMENT=" + id + " ";
              cnx.select(rsql, out erreur, out dr);
              if (erreur == null)
              {
                  if (dr.HasRows == true)
                  {
                      exist = true;
                      dr.Read();
                      dep.ID_DEP = dr.GetString(0);
                      dep.DESG_Dep = dr.GetString(1);
                      dep.RESPONSABLE = dr.GetString(2);
                      dep.Seuuuilee = dr.GetInt32(3);

                  }
                  dr.Close();
              }



          }
          */





        public void ajouter_fiche(class_fich_demande_conge fd, out String erreur)
        {
            erreur = null;
            rsql = "insert into FICHE_CONGE values('" + fd.Id_fiche + "','" + fd.Demande + "' )"; cnx.maj(rsql, out erreur);

        }

    }

}