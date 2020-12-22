using System;
using System.Collections.Generic;
//using Oracle.DataAccess.Client;
using Acces;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Metier
{


    public class type_conge
    {
        private String id_conge;
        private String desgin_conge;
        private String conge_paye;
        private String jourouvrable;
        private String maj_conge_paye;
        private String specification;



        public type_conge(String idcong, String des,String congepay, String jourouvrable, String   majcong , String spec)
        {

            id_conge = idcong;
            desgin_conge = des;
            conge_paye = congepay;
            this.jourouvrable = jourouvrable;
            maj_conge_paye = majcong;
            specification = spec;


        }

        public type_conge() {

            id_conge = "";
            desgin_conge = "";
            conge_paye = "";
            this.jourouvrable = "";
            maj_conge_paye = "";
            specification = "";


        }

        public String Specification
        {
            get { return this.specification; }
            set { this.specification = value; }

        }

        public String MajCongePaye
        {
            get { return this.maj_conge_paye; }
            set { this.maj_conge_paye = value; }

        }
        public String Conge_Paye
        {
            get { return this.conge_paye; }
            set { this.conge_paye = value; }

        }

        public String JourOuvrable
        {
            get { return this.jourouvrable; }
            set { this.jourouvrable = value; }

        }
        
        public String Desgination
        {
            get { return this.desgin_conge; }
            set { this.desgin_conge = value; }

        }
        public String IDCONGES
        {
            get { return this.id_conge; }
            set { this.id_conge = value; }

        }

    }

    public class gestion_type_conge
    {

        string rsql;
        Connexion cnx = new Connexion();
        OracleDataReader dr = null;

        public void chercher_Type_conge(string idconge, out string erreur, out type_conge typec, out Boolean exist)
        {
            erreur = null;
            typec = new type_conge();
            exist = false;
            rsql = "select * from type_conge where cin='" +idconge + "' ";
            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {
                    exist = true;
                    dr.Read();
                    typec.IDCONGES = dr.GetString(0);
                    typec.Desgination = dr.GetString(1);
                    typec.Conge_Paye = dr.GetString(2);
                    typec.JourOuvrable = dr.GetString(3);
                    typec.MajCongePaye = dr.GetString(4);
                    typec.Specification = dr.GetString(5);

                }
                dr.Close();
            }
        }





        public void chercher_List_Type_Conge(String criter, out string erreur, out List<type_conge> typeconge, out Boolean exist)
        {
            erreur = null;
            type_conge typec = new type_conge();
            typeconge = new List<type_conge>();
            exist = false;
            rsql = "select * from TYPE_CONGE where " + criter;
            cnx.select(rsql, out erreur, out dr);


            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {
                        typec = new type_conge();
                        typec.IDCONGES = dr.GetString(0);
                        typec.Desgination = dr.GetString(1);
                        typec.Conge_Paye = dr.GetString(2);
                        typec.JourOuvrable = dr.GetString(3);
                        typec.MajCongePaye = dr.GetString(4);
                        typec.Specification = dr.GetString(5);


                        typeconge.Add(typec);
                    }
                    dr.Close();
                }
            }
        }



        public void supprimer_type_conge( type_conge typeconge, out String erreur)
        {
            erreur = null;
            rsql = "delete from TYPE_CONGE  where ID_CONGE='" + typeconge.IDCONGES + "' ";
            cnx.maj(rsql, out erreur);
        }
        public void modifier_type_conge(type_conge tc, out String erreur)
        {
            erreur = null;
            rsql = "update TYPE_CONGE set DESGIN_CONGE='" + tc.Desgination + "' ,conge_paye='"+tc.Conge_Paye+"', jour_ouvrable='"+tc.JourOuvrable+"' ,maj_conge_pay='"+tc.MajCongePaye+"',specification='"+tc.Specification+"'  where id_conge='" + tc.IDCONGES + "' ";
            cnx.maj(rsql, out erreur);
        }


        public void ajouter_type_conge(type_conge pr, out String erreur)
        {
            //dr.Close();
            erreur = null;
            rsql = "insert into TYPE_CONGE values('" + pr.IDCONGES + "','" + pr.Desgination + "' ,'" + pr.Conge_Paye + "','" + pr.JourOuvrable + "' ,'" + pr.MajCongePaye + "' ,'" + pr.Specification + "' ) ";

            cnx.maj(rsql, out erreur);

        }


        public DataTable GetTypeConge()
        {
            try
            {
                return cnx.Read("TYPE_CONGE");
            }
            catch
            {

                throw;
            }
        }


        public void chercher_Type_conge_Valider(string idconge, out string erreur, out type_conge typec, out Boolean exist)
        {
            erreur = null;
            typec = new type_conge();
            exist = false;
            rsql = "select * from type_conge where ID_CONGE='" + idconge + "' ";
            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {
                    exist = true;
                    dr.Read();
                    typec.IDCONGES = dr.GetString(0);
                    typec.Desgination = dr.GetString(1);
                    typec.Conge_Paye = dr.GetString(2);
                    typec.JourOuvrable = dr.GetString(3);
                    typec.MajCongePaye = dr.GetString(4);
                    typec.Specification = dr.GetString(5);


                }
                dr.Close();
            }
        }


    }
}
