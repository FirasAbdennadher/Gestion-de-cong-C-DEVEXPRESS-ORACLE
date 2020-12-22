using Acces;
//using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace Meiter
{
    public class Services_Class
    {
            private String id_serv;
            private String desg_serv;
        private String departement;
        private String resp_service;
        private Int32 seuill;



        public Services_Class(String id, String des, String dep,String res, Int32 seui)
            {
                id_serv = id;
            desg_serv = des;
            departement = dep;
            resp_service = res;
            seuill = seui;
            }

            public Services_Class()
            {
            id_serv = "";
            desg_serv = "";
            departement = "";
            resp_service = "";

            seuill = 0;
            }
        public Int32 Seuille
        {
            get { return this.seuill; }
            set { this.seuill = value; }
        }
        public string DESG_Serv
            {
                get { return this.desg_serv; }
                set { this.desg_serv = value; }
            }
        public string Resp_service
        {
            get { return this.resp_service; }
            set { this.resp_service = value; }
        }
        
            public string ID_SErv
            {
                get { return this.id_serv; }
                set { this.id_serv = value; }
            }

        public string Depar
        {
            get { return this.departement; }
            set { this.departement = value; }
        }

    }
        public class gestion_Service
        {


            string rsql;
            Connexion cnx = new Connexion();
            OracleDataReader dr = null;


            //chercher fonction

            public void Chercher_Service(string id, out string erreur, out Services_Class serv, out Boolean exist)
            {
                erreur = null;
                serv = new Services_Class();
                exist = false;
                rsql = "select * from  SERVICE where  SERVICE.ID_SERVICE=" + id + " ";
                cnx.select(rsql, out erreur, out dr);
                if (erreur == null)
                {
                    if (dr.HasRows == true)
                    {
                        exist = true;
                        dr.Read();
                    serv.ID_SErv = dr.GetString(0);
                    serv.DESG_Serv = dr.GetString(1);
                    serv.Depar = dr.GetString(2);
                    serv.Resp_service = dr.GetString(3);
                    serv.Seuille = dr.GetInt32(4);

                }
                dr.Close();
                }



            }

            //chercher une liste de fonction selon un critére
            public void chercher_ListeService(String critere, out String erreur, out List<Services_Class> list, out Boolean exist)
            {
                erreur = null;
                list = new List<Services_Class>();
                Services_Class serv = new Services_Class();
                exist = false;
                rsql = "select * from  SERVICE " + critere;

                cnx.select(rsql, out erreur, out dr);
                if (erreur == null)
                {
                    if (dr.HasRows == true)
                    {

                        exist = true;
                        while (dr.Read())
                        {
                        serv = new Services_Class();
                        serv.ID_SErv = dr.GetString(0);
                        serv.DESG_Serv = dr.GetString(1);
                        serv.Depar = dr.GetString(2);
                        serv.Resp_service = dr.GetString(3);
                        serv.Seuille = dr.GetInt32(4);

                        list.Add(serv);
                        }
                        dr.Close();
                    }
                }


            }




            public void ajouter_Service(Services_Class servi, out String erreur)
            {
                erreur = null;
                rsql = "insert into SERVICE values('" + servi.ID_SErv + "','" + servi.DESG_Serv + "','"+servi.Depar+"','"+servi.Resp_service+"',"+servi.Seuille+")";
                cnx.maj(rsql, out erreur);

            }
            public void supprimer_Service(Services_Class servi, out String erreur)
            {
                erreur = null;
                rsql = "delete from SERVICE  where ID_SERVICE='" + servi.ID_SErv + "' ";
                cnx.maj(rsql, out erreur);
            }
            public void modifier_Service(Services_Class servi, out String erreur)
            {
                erreur = null;
            rsql = "update SERVICE set DESIGNATION_SERVICE ='" + servi.DESG_Serv + "',ID_DEPARTEMENT='" + servi.Depar + "',RESPONSABLE_SERVICE='"+servi.Resp_service+ "',SEUILE_SERVICE="+servi.Seuille+" where ID_SERVICE='" + servi.ID_SErv + "' ";
                cnx.maj(rsql, out erreur);
            }






        public void chercher_Service_retour_code(String lib, out string erreur, out String code, out Boolean exist)
        {
            erreur = null;
            code = "";
            exist = false;
            rsql = "select * from SERVICE where DESIGNATION_SERVICE='" + lib + "'  ";
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



        public void chercher_Service3(String id, out string erreur, out string nom,out int seuil, out Boolean exist)
        {
            erreur = null;
            Services_Class fn = new Services_Class();
            nom = null;
             seuil = 0;
            exist = false;
            rsql = "select * from  SERVICE where  SERVICE.ID_SERVICE='" + id + "'  ";
            cnx.select(rsql, out erreur, out dr);


            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {

                       fn = new Services_Class();
                        nom = fn.DESG_Serv = dr.GetString(1);
                        seuil =dr.GetInt32(4);
                    }
                    dr.Close();
                }
            }
        }






        public void Chercher_ListService_Departement(String iddep, out String erreur, out List<Services_Class> list, out Boolean exist)
        {
            erreur = null;
            list = new List<Services_Class>();
            Services_Class serv = new Services_Class();
            exist = false;
            rsql = "select * from  SERVICE where ID_DEPARTEMENT='"+iddep+"' ";

            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {
                        serv = new Services_Class();
                        serv.ID_SErv = dr.GetString(0);
                        serv.DESG_Serv = dr.GetString(1);
                        serv.Depar = dr.GetString(2);
                        serv.Seuille = dr.GetInt32(4);

                        list.Add(serv);
                    }
                    dr.Close();
                }
            }


        }



    }
}