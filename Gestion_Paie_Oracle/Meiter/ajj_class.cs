using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acces;

namespace Meiter
{
    public class ajj_class
    {
        public String idd;
        public DateTime datee;
        public ajj_class(String id, DateTime de)
        {
            this.idd = id;
            datee = de;

        }
        public ajj_class()
        {
            this.idd = "";
            datee = DateTime.Now;

        }
        String rsql = "";
        Connexion cnx = new Connexion();
        Oracle.ManagedDataAccess.Client.OracleDataReader dr = null;
        public void ajouter(ajj_class dep, out String erreur)
        {
            erreur = null;
            rsql = "insert into ajj values('" + dep.idd + "','" + dep.datee.ToShortDateString() + "')";
            cnx.maj(rsql, out erreur);

        }
        String erreur = null;
     public void counttt(out String erreur, out Int32 ss, out Boolean exist)
        { 

          erreur = null;
           ss = 0;
          exist = false;
          rsql = "select count(1)  from  AJJ";

          cnx.select(rsql, out erreur, out dr);



          if (erreur == null)
          {
              if (dr.HasRows == true)
              {

                  exist = true;
                  while (dr.Read())
                  {
                      ss =Convert.ToInt32( dr[0]);
                  }
              }
              dr.Close();

          }
      }






        int val;

        public void nombre(DateTime d1,DateTime d2, String mat,out string erreur, out string val ,out Boolean exist)
        {
            erreur = null;
            exist = false;
            val = "";
           // to_number(to_char(date_demande, 'yyyy'))
            rsql = "select to_number(to_date('03-06-2022', 'DD-MM-YYYY'))-to_number(to_char(03-05-2021,'DD-MM-YYYY')) from demande_conge"; //where MATRICULE='" + mat+"' ";
            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {
                    exist = true;
                    dr.Read();
                    val = Convert.ToString(dr[0]);// dr.GetInt64

                }
                dr.Close();
            }



        }






    }
}
