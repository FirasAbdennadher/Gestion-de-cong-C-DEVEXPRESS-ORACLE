using Acces;
using Oracle.ManagedDataAccess.Client;

//using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Meiter
{
    public class Departement_Class
    {
        private String id_dep;
        private String desg_dep;
        private String resp_dep;

        private Int32 seuille;

        public Departement_Class(String id, String des ,String resp, Int32 seuile)
        {
            id_dep = id;
            desg_dep = des;
            resp_dep = resp;
            seuille = seuile;
        }

        public Departement_Class()
        {
            id_dep = "";
            desg_dep = "";
            resp_dep = "";
            seuille = 0;
        }


        public Int32 Seuuuilee
        {
            get { return this.seuille; }
            set { this.seuille = value; }
        }
        public string DESG_Dep
        {
            get { return this.desg_dep; }
            set { this.desg_dep = value; }
        }
        public string RESPONSABLE
        {
            get { return this.resp_dep; }
            set { this.resp_dep = value; }
        }

        public string ID_DEP
        {
            get { return this.id_dep; }
            set { this.id_dep = value; }
        }
    }
        public class gestion_Departement
    {


        string rsql;
        Connexion cnx = new Connexion();
        OracleDataReader dr = null;


        //chercher fonction

        public void Chercher_Departement(string id, out string erreur, out Departement_Class dep, out Boolean exist)
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
        //chercher une liste de fonction selon un critére
 public void chercher_ListeDepartement(String critere, out String erreur, out List<Departement_Class> list,out String dbb, out Boolean exist)
        {            erreur = null;
            dbb = "";
            list = new List<Departement_Class>();
            Departement_Class dep = new Departement_Class();
            exist = false;
            rsql = "select * from  DEPARTEMENT " + critere;

            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {
                        dep = new Departement_Class();
                        dep.ID_DEP = dr.GetString(0);
                        dep.DESG_Dep = dr.GetString(1);                         
                        dep.RESPONSABLE = dr.GetString(2);
                        dep.Seuuuilee = dr.GetInt32(3);

                        list.Add(dep);
                    }
                    dr.Close();
                }
            }


        }




        public void ajouter_DEPARTEMENT(Departement_Class dep, out String erreur)
        {
            erreur = null;
            rsql = "insert into DEPARTEMENT values('" + dep.ID_DEP + "','" + dep.DESG_Dep + "','"+dep.RESPONSABLE+"','"+dep.Seuuuilee+"')";
            cnx.maj(rsql, out erreur);

        }
        public void supprimer_DEPARTEMENT(Departement_Class dep, out String erreur)
        {
            erreur = null;
            rsql = "delete from DEPARTEMENT  where ID_DEPARTMENT='" + dep.ID_DEP + "' ";
            cnx.maj(rsql, out erreur);
        }
        public void modifier_DEPARTEMENT(Departement_Class dep, out String erreur)
        {
            erreur = null;
            //update DEPARTEMENT d set d.DESGN_DEPARTEMENT ='XX' ,d.REPONSABLE_DEP='Emp5' where d.ID_DEPARTMENT='D6' and   not exists
            //(select 1  from DEPARTEMENT where 'Emp5' = REPONSABLE_DEP);
            rsql = "update DEPARTEMENT set DESGN_DEPARTEMENT ='" + dep.DESG_Dep + "',REPONSABLE_DEP='"+dep.RESPONSABLE+ "',SEUILE_DEPARTEMENT='"+dep.Seuuuilee+"' where ID_DEPARTMENT='" + dep.ID_DEP + "' ";
            cnx.maj(rsql, out erreur);
        }


        public void chercher_Departement_retour_code(String lib, out string erreur, out String code, out Boolean exist)
        {
            erreur = null;
            code = "";
            exist = false;
            rsql = "select * from DEPARTEMENT where DESGN_DEPARTEMENT='" + lib + "'  ";
            cnx.select(rsql, out erreur, out dr);


            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {

                        code = dr.GetString(0);
                    }
                    dr.Close();
                }
            }
        }


        public void chercher_Departement3(String id, out string erreur, out string nom, out int seuil,out string rsp, out Boolean exist)
        {
            erreur = null;
            rsp = "";
            Departement_Class fn = new Departement_Class();
            nom = null;
            exist = false;
            seuil = 0;
            rsql = "select * from  DEPARTEMENT where  DEPARTEMENT.ID_DEPARTMENT='" + id + "'  ";
            cnx.select(rsql, out erreur, out dr);


            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {

                        fn = new Departement_Class();
                        nom = fn.DESG_Dep = dr.GetString(1);
                        rsp = dr.GetString(2);
                        seuil = dr.GetInt32(3);

                    }
                    dr.Close();
                }
            }
        }

       


    }
}
