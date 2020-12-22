using Acces;
//using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;


namespace Meiter
{
    public class Validation_Conge_Class
    {


        private String id_validation;
        private String date_debut_valider;
        private String date_fin_valider;
        private String heur_debut_valider;
        private String heur_fin_valider;
        private String id_demande_conger;
        private decimal nbjourval;

        public Validation_Conge_Class(String id_val, String ddv, String dfv, String hdv, String hfv, String id_d_c, decimal nbj)
        {
            nbjourval = nbj;
            id_validation = id_val;
            date_debut_valider = ddv;
            date_fin_valider = dfv;
            heur_debut_valider = hdv;
            heur_fin_valider = hfv;
            id_demande_conger = id_d_c;

        }
        public Validation_Conge_Class()
        {
            id_validation = "";
            date_debut_valider = "";
            date_fin_valider = "";
            heur_debut_valider = "";
            heur_fin_valider = "";
            id_demande_conger = "";
            nbjourval = 0;
        }



        public String Id_validation
        {
            get { return this.id_validation; }
            set { this.id_validation = value; }
        }

        public decimal NombreJourValider
        {
            get { return this.nbjourval; }
            set { this.nbjourval = value; }
        }

        public String Date_Debut_Valider
        {
            get { return this.date_debut_valider; }
            set { this.date_debut_valider = value; }
        }
        public String Date_fin_valider
        {
            get { return this.date_fin_valider; }
            set { this.date_fin_valider = value; }
        }
        public String Heur_Debut_Valider
        {
            get { return this.heur_debut_valider; }
            set { this.heur_debut_valider = value; }
        }
        public String Heur_Fin_Valider
        {
            get { return this.heur_fin_valider; }
            set { this.heur_fin_valider = value; }
        }
        public String ID_CONGER_DEMANDER
        {
            get { return this.id_demande_conger; }
            set { this.id_demande_conger = value; }
        }
    }
    public class Gestion_Validation_Class
    {

        string rsql;
        Connexion cnx = new Connexion();
        OracleDataReader dr = null;

        public void chercher_ListValidation_conge(String critere, out string erreur, out List<Validation_Conge_Class> val, out Boolean exist)
        {
            erreur = null;
            Validation_Conge_Class Validation = new Validation_Conge_Class();
            val = new List<Validation_Conge_Class>();
            exist = false;
            rsql = "select * from VALIDATION_CONGE" + critere;
            cnx.select(rsql, out erreur, out dr);



            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {
                        Validation = new Validation_Conge_Class();
                        Validation.Id_validation = dr.GetString(0);
                        Validation.Date_Debut_Valider = dr.GetString(1);
                        Validation.Date_fin_valider = dr.GetString(2);
                        Validation.Heur_Debut_Valider = dr.GetString(3);
                        Validation.Heur_Fin_Valider = dr.GetString(4);
                        Validation.ID_CONGER_DEMANDER = dr.GetString(5);
                        Validation.NombreJourValider = dr.GetDecimal(6);

                        val.Add(Validation);
                    }
                }
                dr.Close();

            }
        }



        public void chercher_Validation_conge_emp(String id, out string erreur, out Validation_Conge_Class Validation, out Boolean exist)
        {
            erreur = null;
            Validation = new Validation_Conge_Class();
            exist = false;
            rsql = "select * from VALIDATION_CONGE where  ID_VALIDATION='" + id + "' ";
            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {
                    exist = true;
                    dr.Read();

                    Validation = new Validation_Conge_Class();
                    Validation.Id_validation = dr.GetString(0);
                    Validation.Date_Debut_Valider = dr.GetString(1);
                    Validation.Date_fin_valider = dr.GetString(2);
                    Validation.Heur_Debut_Valider = dr.GetString(3);
                    Validation.Heur_Fin_Valider = dr.GetString(4);
                    Validation.ID_CONGER_DEMANDER = dr.GetString(5);
                    Validation.NombreJourValider = dr.GetDecimal(6);

                }
                dr.Close();
            }
            /*

             */


        }



        public void chercher_ListValidation_conge1( out string erreur, out List<Validation_Conge_Class> val, out Boolean exist)
        {
            erreur = null;
            Validation_Conge_Class Validation = new Validation_Conge_Class();
            val = new List<Validation_Conge_Class>();
            exist = false;
            rsql = "select * from VALIDATION_CONGE "; 
            cnx.select(rsql, out erreur, out dr);



            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {
                        Validation = new Validation_Conge_Class();
                        Validation.Id_validation = dr.GetString(0);
                        Validation.Date_Debut_Valider = dr.GetString(1);
                        Validation.Date_fin_valider = dr.GetString(2);
                        Validation.Heur_Debut_Valider = dr.GetString(3);
                        Validation.Heur_Fin_Valider = dr.GetString(4);
                        Validation.ID_CONGER_DEMANDER = dr.GetString(5);
                        Validation.NombreJourValider = dr.GetDecimal(6);

                        val.Add(Validation);
                    }
                }
                dr.Close();

            }
        }






        public void ajouter_Validation(Validation_Conge_Class val, out String erreur)
        {
            //  dr.Close();
            erreur = null;
            rsql = "insert into VALIDATION_CONGE values('" + val.Id_validation + "','" + val.Date_Debut_Valider + "','" + val.Date_fin_valider + "','" + val.Heur_Debut_Valider + "','" + val.Heur_Fin_Valider + "','" + val.ID_CONGER_DEMANDER + "','"+val.NombreJourValider+"')";
            cnx.maj(rsql, out erreur);

        }
        public void supprimer_Validation(Validation_Conge_Class val, out String erreur)
        {
            erreur = null;
            rsql = "delete from VALIDATION_CONGE  where ID_HISTORIQUE='" + val.Id_validation + "' ";
            cnx.maj(rsql, out erreur);
        }

        public void modifier_Validation(Validation_Conge_Class val, out String erreur)
        {
            erreur = null;
            rsql = "update VALIDATION_CONGE set DATE_DEBUT_VALIDER='" + val.Date_Debut_Valider + "',DATE_FIN_VALIDER='" + val.Date_fin_valider + "',HEUR_DEBUT_VALIDER='" + val.Heur_Debut_Valider + "',HEUR_FIN_VALIDER='" + val.Heur_Fin_Valider + "',ID_DEMANDE_CONGE='" + val.ID_CONGER_DEMANDER + "',NOMBREJOUR_VALIDE='"+val.NombreJourValider+"' where   ID_VALIDATION='" + val.Id_validation + "' ";

            cnx.maj(rsql, out erreur);
        }

    }
}