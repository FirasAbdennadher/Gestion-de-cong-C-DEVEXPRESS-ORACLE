
using System;
using System.Collections.Generic;
using Acces;
//using Oracle.DataAccess.Client;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Metier
{
    public class fonction_class
    {
        private int id_fn;
        private String desg;
        private int id_entre;
        public fonction_class(int idfn, String des, int id_entre)
        {
            id_fn = idfn;
            desg = des;
            this.id_entre = id_entre;
        }

        public fonction_class()
        {
            id_fn = 0;
            desg = "";
            this.id_entre = 0;

        }

        public int id_fnctionn
        {
            get { return this.id_fn; }
            set { this.id_fn = value; }
        }

        public string desgs
        {
            get { return this.desg; }
            set { this.desg = value; }
        }


        public int id_entrep
        {
            get { return this.id_entre; }
            set { this.id_entre = value; }
        }


    }

    //gestion fonction

    public class GestionFonction
    {

        string rsql;
        Connexion cnx = new Connexion();
        OracleDataReader dr = null;


        //chercher fonction
            
        public void chercher_Fonction(string id, out string erreur, out fonction_class fn, out Boolean exist)
        {
            erreur = null;
            fn = new fonction_class();
            exist = false;
            rsql = "select * from  fonction where  fonction.id_fn=" + id + " ";
            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {
                    exist = true;
                    dr.Read();
                    fn.id_fnctionn = dr.GetInt32(0);
                    fn.desgs = dr.GetString(1);
                    fn.id_entrep = dr.GetInt32(2);
                }
                dr.Close();
            }



        }

        //chercher une liste de fonction selon un critére
        public void chercher_ListeFonction(String critere, out String erreur, out List<fonction_class> list, out Boolean exist)
        {
            erreur = null;
            list = new List<fonction_class>();
            fonction_class fn = new fonction_class();
            exist = false;
            rsql = "select * from  fonction " + critere;

            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {
                        fn = new fonction_class();
                        fn.id_fnctionn = dr.GetInt32(0);
                        fn.desgs = dr.GetString(1);
                        fn.id_entrep = dr.GetInt32(2);
                        list.Add(fn);
                    }
                    dr.Close();
                }
            }


        }


        public void chercher_fn2(int id,out string erreur, out List<fonction_class> list_fn, out Boolean exist)
        {
            erreur = null;
            fonction_class fn = new fonction_class();
            list_fn = new List<fonction_class>();
            exist = false;
            rsql = "select * from  fonction where  fonction.id_ent=" + id+" ";
            cnx.select(rsql, out erreur, out dr);


            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {

                        fn = new fonction_class();
                        fn.id_fnctionn = dr.GetInt32(0);
                        fn.desgs = dr.GetString(1);
                        fn.id_entrep = dr.GetInt32(2);


                        list_fn.Add(fn);
                    }
                    dr.Close();
                }
            }
        }


        public void chercher_fn3(int id, out string erreur, out string nom, out Boolean exist)
        {
            erreur = null;
            fonction_class fn = new fonction_class();
            nom = null;
            exist = false;
            rsql = "select * from fonction where id_fn=" + id + "  ";
            cnx.select(rsql, out erreur, out dr);


            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {

                        fn = new fonction_class();
                        nom = fn.desgs = dr.GetString(1);
                    }
                    dr.Close();
                }
            }
        }


        public void chercher_fn3_retour_code(String lib, out string erreur, out Int32 code, out Boolean exist)
        {
            erreur = null;
            fonction_class fn = new fonction_class();
            code =0 ;
            exist = false;
            rsql = "select * from fonction where DESGIN_FNN='" + lib + "'  ";
            cnx.select(rsql, out erreur, out dr);


            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {

                        code= dr.GetInt32(0);
                    }
                    dr.Close();
                }
            }
        }



        public void ajouter_fn(fonction_class fn, out String erreur)
        {
            erreur = null;
            rsql = "insert into fonction values('" + fn.id_fnctionn + "','" + fn.desgs + "','" + fn.id_entrep + "')";
            cnx.maj(rsql, out erreur);

        }
        public void supprimer_fn(fonction_class fn, out String erreur)
        {
            erreur = null;
            rsql = "delete from fonction  where id_fn='" + fn.id_entrep + "' ";
            cnx.maj(rsql, out erreur);
        }
        public void modifier_fn(fonction_class fn, out String erreur)
        {
            erreur = null;
            rsql = "update fonction set desgin_fn ='" + fn.desgs + "' where id_fn='" + fn.id_fnctionn + "' ";
            cnx.maj(rsql, out erreur);
        }




        public DataTable getFonction()
        {
            try
            {
                return cnx.Read("fonction");
            }
            catch
            {
                throw;
            }
        }












    }





}
