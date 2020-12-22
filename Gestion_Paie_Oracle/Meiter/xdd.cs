using Acces;
//using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace Meiter
{
    public class xdd
    {
        public String id;
        public DateTime d1;
        public DateTime d2;

        public xdd(String id, DateTime d1, DateTime d2)
        {
            this.id = id;
            this.d1 = d1;
            this.d2 = d2;
        }
        public xdd()
        {
            this.id = "";
            this.d1 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            this.d2 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")); ;
        }




    }
    public class gestion_xd{
        String rsql;
        OracleDataReader dr = null;
        Connexion cnx = new Connexion();
        public void ajouterxd(xdd xdd, out String erreur)
        {
            erreur = null;
            DateTime d111 = Convert.ToDateTime(xdd.d1);
            DateTime d222 = Convert.ToDateTime(xdd.d2);

    //rsql = "insert into xd values('" + xdd.id + "',to_date('" + xdd.d1 + "','dd/mm/yyyy hh24:mi:ss'),to_date('" + xdd.d2 + "','dd/mm/yyyy hh24:mi:ss'))";

            cnx.maj(rsql, out erreur);

        }



        public void getSomme(int anner,String MAT, out string erreur, out string sum , out Boolean exist)
        {
            erreur = null;
            sum = "";
            exist = false;
            anner = anner - 1;
            //     rsql = " select sum(nombrejour)AS nbjour from demande_conge where SUBSTR(date_demande, 1, 4) ="+anner+" and CIN ='"+cin+"' ";
            rsql = "select SUM(NOMBREJOUR) from DEMANDE_CONGE  where to_number( to_char(date_demande,'yyyy')) =" + anner + " and MATRICULE ='" + MAT + "'  ";
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

        public void Droit_conge_anner_precedent(int anner, String MAT, out string erreur, out string nombrejour, out Boolean exist)
        {
            erreur = null;
            nombrejour = "";
           
            exist = false;
            anner = anner - 1;
   rsql = "select DROIT_ANNER_COURANT,ARRIERE_CONGE,PRIS_ANNER_COURANT from historique_conge where anner_conge=" + anner+ " and MATRICULE='" + MAT+"' ";
            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {
                    exist = true;
                    dr.Read();
                    nombrejour = dr[0].ToString();
                }
                dr.Close();
            }


        }







        public void Droit_arrier_pris_conge_anner_precedent(int anner, String MAT, out string erreur, out string nombrejour, out string arrier, out string priss, out Boolean exist)
        {
            erreur = null;
            nombrejour = "";
            arrier = "";
            priss = "";
            exist = false;
            rsql = "select DROIT_ANNER_COURANT,ARRIERE_CONGE,PRIS_ANNER_COURANT from historique_conge where anner_conge=" + anner + " and MATRICULE='" + MAT + "' ";
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


        public void getArrierannerdernier(int anner,String MAT, out string erreur, out string sum, out Boolean exist)
        {
            erreur = null;
            sum = "";
            exist = false;
            anner = anner - 1;
            rsql = " select ARRIERE_CONGE from HISTORIQUE_CONGE  where SUBSTR(anner_conge, 1, 4) =" + anner + " and MATRICULE='" + MAT+"' ";

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


    }
}
