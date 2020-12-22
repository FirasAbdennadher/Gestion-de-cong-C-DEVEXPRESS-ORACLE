using Acces;
//using Oracle.DataAccess.Client;
using Oracle.ManagedDataAccess.Client;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Meiter
{
    public class Demande_Conge_Class
    {

        #region attribut
        private String ID_DEMANDE_CONGE;
        private DateTime DATE_DEBUT_CONGE;
        private DateTime DATE_FIN_CONGE;
        private String HEUR_DEBUT;
        private String HEUR_FIN;
        private DateTime DATE_DEMANDE;
        private String MOTIF;
        private String Matricule;
        private String ID_CONGE;
        private String status;
        private decimal nbjour;
        private DateTime DATE_DEBUT_RES_SERVICE;
        private DateTime DATE_FIN_RES_SERVICE;
        private String HEUR_DEBUT_RES_SERVICE;
        private String HEUR_FIN_RES_SERVICE;
        private String STATUS_RESPONSABLE_SERVICE;
        private DateTime DATE_DEBUT_RES_DEPARTEMENT;
        private DateTime DATE_FIN_RES_DEPARTEMENT;
        private String HEUR_DEBUT_RES_Departement;
        private String HEUR_FIN_RES_Departement;
        private String STATUS_RESPONSABLE_DEPARTEMENT;
        #endregion

       #region pour global 
        public Demande_Conge_Class(String id_dem, DateTime dd, DateTime df, String hd, String hf, DateTime date_dem,String moti,String mattt,String id_congerrrr,String stats, decimal nb )
        {
            nbjour = nb;
            status = stats;
            ID_DEMANDE_CONGE = id_dem;
            DATE_DEBUT_CONGE = dd;
            DATE_FIN_CONGE = df;
            HEUR_DEBUT = hd;
            HEUR_FIN = hf;
            DATE_DEMANDE = date_dem;
            MOTIF = moti;
            ID_CONGE = id_congerrrr;
            Matricule = mattt;

        }
        public Demande_Conge_Class()
            {
            nbjour = 0;
            ID_DEMANDE_CONGE = " ";
            DATE_DEBUT_CONGE = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
            DATE_FIN_CONGE = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
            HEUR_DEBUT = " ";
            HEUR_FIN = " ";
            DATE_DEMANDE = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
            MOTIF = " ";
            ID_CONGE = " ";
            Matricule = " ";
            status = " ";
            DATE_DEBUT_RES_SERVICE =Convert.ToDateTime( DateTime.Now.ToShortTimeString());
            DATE_FIN_RES_SERVICE = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
            HEUR_DEBUT_RES_SERVICE = " ";
            HEUR_FIN_RES_SERVICE = " ";
            STATUS_RESPONSABLE_SERVICE = " ";

            DATE_DEBUT_RES_DEPARTEMENT = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
            DATE_FIN_RES_DEPARTEMENT = Convert.ToDateTime( DateTime.Now.ToShortTimeString());
            HEUR_DEBUT_RES_Departement = " ";
            HEUR_FIN_RES_Departement = " ";
            STATUS_RESPONSABLE_DEPARTEMENT = " ";

        }
        #endregion
            
        #region pour chef service 
        public Demande_Conge_Class(String id_dem, DateTime dd, DateTime df, String hd, String hf, DateTime date_dem, String moti, String mattt, String id_congerrrr, String stats, decimal nb, DateTime datedebutres_serv, DateTime datefinres_serv, String hd_service, String hf_service, String status_serv)
        {
            nbjour = nb;
            status = stats;
            ID_DEMANDE_CONGE = id_dem;
            DATE_DEBUT_CONGE = dd;
            DATE_FIN_CONGE = df;
            HEUR_DEBUT = hd;
            HEUR_FIN = hf;
            DATE_DEMANDE = date_dem;
            MOTIF = moti;
            ID_CONGE = id_congerrrr;
            Matricule = mattt;
            DATE_DEBUT_RES_SERVICE = datedebutres_serv; ;
            DATE_FIN_RES_SERVICE = datefinres_serv;
            HEUR_DEBUT_RES_SERVICE = hd_service;
            HEUR_FIN_RES_SERVICE = hf_service;
            STATUS_RESPONSABLE_SERVICE = status_serv;

        }
        
        #endregion

        #region pour chef departme

        public Demande_Conge_Class(String id_dem, DateTime dd, DateTime df, String hd, String hf, DateTime date_dem, String moti, String mattt, String id_congerrrr, String stats, decimal nb, DateTime datedebutres_serv, DateTime datefinres_serv, String hd_service, String hf_service, String status_serv, DateTime datedebutres_dpar, DateTime datefinres_depar, String hd_depar, String hf_depar, String status_depart)
        {
            nbjour = nb;
            status = stats;
            ID_DEMANDE_CONGE = id_dem;
            DATE_DEBUT_CONGE = dd;
            DATE_FIN_CONGE = df;
            HEUR_DEBUT = hd;
            HEUR_FIN = hf;
            DATE_DEMANDE = date_dem;
            MOTIF = moti;
            ID_CONGE = id_congerrrr;
            Matricule = mattt;
            DATE_DEBUT_RES_SERVICE = datedebutres_serv; ;
            DATE_FIN_RES_SERVICE = datefinres_serv;
            HEUR_DEBUT_RES_SERVICE = hd_service;
            HEUR_FIN_RES_SERVICE = hf_service;
            STATUS_RESPONSABLE_SERVICE = status_serv;

            DATE_DEBUT_RES_DEPARTEMENT = datedebutres_dpar;
            DATE_FIN_RES_DEPARTEMENT = datefinres_depar;
            HEUR_DEBUT_RES_Departement = hd_depar;
            HEUR_FIN_RES_Departement = hf_depar;
            STATUS_RESPONSABLE_DEPARTEMENT = status_depart;

        }

        #endregion


        public DateTime DATE_DEBUT_RES_DEPARTEMENTS
        {
            get { return this.DATE_DEBUT_RES_DEPARTEMENT; }
            set { this.DATE_DEBUT_RES_DEPARTEMENT = value; }
        }
        public DateTime DATE_FIN_RES_DEPARTEMENTS
        {
            get { return this.DATE_FIN_RES_DEPARTEMENT; }
            set { this.DATE_FIN_RES_DEPARTEMENT = value; }
        }
        public String HEUR_DEBUT_RES_DepartementS
        {
            get { return this.HEUR_DEBUT_RES_Departement; }
            set { this.HEUR_DEBUT_RES_Departement = value; }
        }
        public String HEUR_FIN_RES_DepartementS
        {
            get { return this.HEUR_FIN_RES_Departement; }
            set { this.HEUR_FIN_RES_Departement = value; }
        }
        public String STATUS_RESPONSABLE_DEPARTEMENTS
        {
            get { return this.STATUS_RESPONSABLE_DEPARTEMENT; }
            set { this.STATUS_RESPONSABLE_DEPARTEMENT = value; }
        }
     
         public DateTime DATE_DEBUT_RES_SERVICES
        {
            get { return this.DATE_DEBUT_RES_SERVICE; }
            set { this.DATE_DEBUT_RES_SERVICE = value; }
        }
        public DateTime DATE_FIN_RES_SERVICES
        {
            get { return this.DATE_FIN_RES_SERVICE; }
            set { this.DATE_FIN_RES_SERVICE = value; }
        }
        public String HEUR_DEBUT_RES_SERVICES
        {
            get { return this.HEUR_DEBUT_RES_SERVICE; }
            set { this.HEUR_DEBUT_RES_SERVICE = value; }
        }
        public String HEUR_FIN_RES_SERVICES
        {
            get { return this.HEUR_FIN_RES_SERVICE; }
            set { this.HEUR_FIN_RES_SERVICE = value; }
        }
        public String STATUS_RESPONSABLE_SERVICES
        {
            get { return this.STATUS_RESPONSABLE_SERVICE; }
            set { this.STATUS_RESPONSABLE_SERVICE = value; }
        }



        public DateTime Date_Demande
        {
            get { return this.DATE_DEMANDE; }
            set { this.DATE_DEMANDE = value; }
        }
        public decimal NombreJour
        {
            get { return this.nbjour; }
            set { this.nbjour = value; }
        }

        public String Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public DateTime Date_Debut
        {
            get { return this.DATE_DEBUT_CONGE; }
            set { this.DATE_DEBUT_CONGE = value; }
        }
        public DateTime Date_fin
        {
            get { return this.DATE_FIN_CONGE; }
            set { this.DATE_FIN_CONGE = value; }
        }
        public String Heur_Debut
        {
            get { return this.HEUR_DEBUT; }
            set { this.HEUR_DEBUT = value; }
        }
        public String Heur_Fin
        {
            get { return this.HEUR_FIN; }
            set { this.HEUR_FIN = value; }
        }
        public String ID_Demandee
        {
            get { return this.ID_DEMANDE_CONGE; }
            set { this.ID_DEMANDE_CONGE = value; }
        }

        public String ID_Conger
        {
            get { return this.ID_CONGE; }
            set { this.ID_CONGE = value; }
        }
        public String MATRICULE
        {
            get { return this.Matricule; }
            set { this.Matricule = value; }
        }

        public String Motiff
        {
            get { return this.MOTIF; }
            set { this.MOTIF = value; }
        }

    }
    public class Gestion_Demande_Class
    {

        string rsql;
        Connexion cnx = new Connexion();
        OracleDataReader dr = null;

        public void chercher_Demande_conge(String critere, out string erreur, out List<Demande_Conge_Class> dem, out Boolean exist)
        {
            erreur = null;
            Demande_Conge_Class Demande = new Demande_Conge_Class();
            dem = new List<Demande_Conge_Class>();
            exist = false;
            rsql = "select * from  DEMANDE_CONGE" + critere;
            cnx.select(rsql, out erreur, out dr);



            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {
                        Demande = new Demande_Conge_Class();
                        Demande.ID_Demandee = dr.GetString(0);
                        Demande.Date_Debut = dr.GetDateTime(1);
                        Demande.Date_fin = dr.GetDateTime(2);
                        Demande.Heur_Debut = dr.GetString(3);
                        Demande.Heur_Fin = dr.GetString(4);
                        Demande.Date_Demande = dr.GetDateTime(5);
                        Demande.Motiff = dr.GetString(6);
                        Demande.MATRICULE = dr.GetString(7);
                        Demande.ID_Conger = dr.GetString(8);
                        Demande.Status = dr.GetString(9);
                        Demande.NombreJour = dr.GetDecimal(10);
                        Demande.DATE_DEBUT_RES_SERVICES = dr.GetDateTime(11);
                        Demande.DATE_FIN_RES_SERVICES = dr.GetDateTime(12);
                        Demande.HEUR_DEBUT_RES_SERVICES = dr.GetString(13);
                        Demande.HEUR_FIN_RES_SERVICES = dr.GetString(14);
                        Demande.STATUS_RESPONSABLE_SERVICES = dr.GetString(15);
                        Demande.DATE_DEBUT_RES_DEPARTEMENTS = dr.GetDateTime(16);
                        Demande.DATE_FIN_RES_DEPARTEMENTS = dr.GetDateTime(17);
                        Demande.HEUR_DEBUT_RES_DepartementS = dr.GetString(18);
                        Demande.HEUR_FIN_RES_DepartementS = dr.GetString(19);
                        Demande.STATUS_RESPONSABLE_DEPARTEMENTS = dr.GetString(20);


                        dem.Add(Demande);
                    }
                }
                dr.Close();

            }
        }



        public void chercher_Demande_conge_emp(String id, out string erreur, out Demande_Conge_Class Demande, out Boolean exist)
        {
            erreur = null;
            Demande = new Demande_Conge_Class();
            exist = false;
            rsql = "select * from  DEMANDE_CONGE where   DEMANDE_CONGE.ID_DEMANDE_CONGE='" + id + "' ";
            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {
                    exist = true;
                    dr.Read();
                    Demande.ID_Demandee = dr.GetString(0);
                    Demande.Date_Debut = dr.GetDateTime(1);
                    Demande.Date_fin = dr.GetDateTime(2);
                    Demande.Heur_Debut = dr.GetString(3);
                    Demande.Heur_Fin = dr.GetString(4);
                    Demande.Date_Demande = dr.GetDateTime(5);
                    Demande.Motiff = dr.GetString(6);
                    Demande.MATRICULE = dr.GetString(7);
                    Demande.ID_Conger = dr.GetString(8);
                    Demande.Status = dr.GetString(9);
                    Demande.NombreJour = dr.GetDecimal(10);
                    Demande.DATE_DEBUT_RES_SERVICES = dr.GetDateTime(11);
                    Demande.DATE_FIN_RES_SERVICES = dr.GetDateTime(12);
                    Demande.HEUR_DEBUT_RES_SERVICES = dr.GetString(13);
                    Demande.HEUR_FIN_RES_SERVICES = dr.GetString(14);
                    Demande.STATUS_RESPONSABLE_SERVICES = dr.GetString(15);
                    Demande.DATE_DEBUT_RES_DEPARTEMENTS = dr.GetDateTime(16);
                    Demande.DATE_FIN_RES_DEPARTEMENTS = dr.GetDateTime(17);
                    Demande.HEUR_DEBUT_RES_DepartementS = dr.GetString(18);
                    Demande.HEUR_FIN_RES_DepartementS = dr.GetString(19);
                    Demande.STATUS_RESPONSABLE_DEPARTEMENTS = dr.GetString(20);


                }
                dr.Close();
            }
            /*

             */


        }

        public void chercher_Demande_conge_par_datedebut(String datee,String mat, out string erreur, out Demande_Conge_Class Demande, out Boolean exist)
        {
            erreur = null;
            Demande = new Demande_Conge_Class();
            exist = false;
            rsql = "select * from  DEMANDE_CONGE where   DEMANDE_CONGE.date_demande='" + datee + "' and  DEMANDE_CONGE.Matricule='"+mat+"' ";
            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {
                    exist = true;
                    dr.Read();
                    Demande.ID_Demandee = dr.GetString(0);
                    Demande.Date_Debut = dr.GetDateTime(1);
                    Demande.Date_fin = dr.GetDateTime(2);
                    Demande.Heur_Debut = dr.GetString(3);
                    Demande.Heur_Fin = dr.GetString(4);
                    Demande.Date_Demande = dr.GetDateTime(5);
                    Demande.Motiff = dr.GetString(6);
                    Demande.MATRICULE = dr.GetString(7);
                    Demande.ID_Conger = dr.GetString(8);
                    Demande.Status = dr.GetString(9);
                    Demande.NombreJour = dr.GetDecimal(10);
                    Demande.DATE_DEBUT_RES_SERVICES = dr.GetDateTime(11);
                    Demande.DATE_FIN_RES_SERVICES = dr.GetDateTime(12);
                    Demande.HEUR_DEBUT_RES_SERVICES = dr.GetString(13);
                    Demande.HEUR_FIN_RES_SERVICES = dr.GetString(14);
                    Demande.STATUS_RESPONSABLE_SERVICES = dr.GetString(15);
                    Demande.DATE_DEBUT_RES_DEPARTEMENTS = dr.GetDateTime(16);
                    Demande.DATE_FIN_RES_DEPARTEMENTS = dr.GetDateTime(17);
                    Demande.HEUR_DEBUT_RES_DepartementS = dr.GetString(18);
                    Demande.HEUR_FIN_RES_DepartementS = dr.GetString(19);
                    Demande.STATUS_RESPONSABLE_DEPARTEMENTS = dr.GetString(20);



                }
                dr.Close();
            }
            /*

             */


        }



        public void ajouter_DEMANDE_CONGE(Demande_Conge_Class dem, out String erreur)
        {
            //  dr.Close();
            erreur = null;
            rsql = "insert into  DEMANDE_CONGE values('" + dem.ID_Demandee + "','" + dem.Date_Debut.ToShortDateString() + "','" + dem.Date_fin.ToShortDateString() + "','" + dem.Heur_Debut + "','" + dem.Heur_Fin + "','" + dem.Date_Demande.ToShortDateString() + "','" + dem.Motiff + "','" + dem.MATRICULE + "','" + dem.ID_Conger + "','" + dem.Status + "','" + dem.NombreJour + "','"+dem.DATE_DEBUT_RES_SERVICES.ToShortDateString() + "','" + dem.DATE_FIN_RES_SERVICES.ToShortDateString() + "','" + dem.HEUR_DEBUT_RES_SERVICES+ "','" + dem.HEUR_FIN_RES_SERVICES+ "','" + dem.STATUS_RESPONSABLE_SERVICES+ "','" + dem.DATE_DEBUT_RES_DEPARTEMENTS.ToShortDateString() + "','" + dem.DATE_FIN_RES_DEPARTEMENTS.ToShortDateString() + "','" + dem.HEUR_DEBUT_RES_DepartementS+ "','" + dem.HEUR_FIN_RES_DepartementS+ "','" + dem.STATUS_RESPONSABLE_DEPARTEMENTS+ "')";
            cnx.maj(rsql, out erreur);

        }
        public void supprimer_DEMANDE_CONGE(Demande_Conge_Class dem, out String erreur)
        {
            erreur = null;
            rsql = "delete from  DEMANDE_CONGE  where  DEMANDE_CONGE.ID_DEMANDE_CONGE='" + dem.ID_Demandee + "' ";
            cnx.maj(rsql, out erreur);
        }

        public void modifier_DEMANDE_CONGE(Demande_Conge_Class dem, out String erreur)
        {
            erreur = null;
            rsql = "update DEMANDE_CONGE set DATE_DEBUT_CONGE='" + dem.Date_Debut.ToShortDateString() + "',DATE_FIN_CONGE='" + dem.Date_fin.ToShortDateString() + "',HEUR_DEBUT='" + dem.Heur_Debut + "',HEUR_FIN='" + dem.Heur_Fin + "',DATE_DEMANDE='" + dem.Date_Demande.ToShortDateString() + "',MOTIF='" + dem.Motiff + "',MATRICULE='" + dem.MATRICULE + "',ID_CONGE='" + dem.ID_Conger + "',STATUS ='" + dem.Status + "',NOMBREJOUR='" + dem.NombreJour + "',DATE_DEBUT_RSP_SERVICE='"+ dem.DATE_DEBUT_RES_SERVICES.ToShortDateString()+"',DATE_FIN_RSP_SERVICE='"+dem.DATE_FIN_RES_SERVICES.ToShortDateString() +"',HEUR_DEBUT_RES_SERVICE='"+dem.HEUR_DEBUT_RES_SERVICES+ "',HEUR_FIN_RES_SERVICE='"+dem.HEUR_FIN_RES_SERVICES+ "',STATUS_RESPONSABLE_SERVICE='"+dem.STATUS_RESPONSABLE_SERVICES+ "',DATE_DEBUT_RES_DEPARTEMENT='" + dem.DATE_DEBUT_RES_DEPARTEMENTS.ToShortDateString() + "',DATE_FIN_RES_DEPARTEMENT='" + dem.DATE_FIN_RES_DEPARTEMENTS.ToShortDateString() + "',HEUR_DEBUT_RES_DEPARTEMENT='" + dem.HEUR_DEBUT_RES_DepartementS + "',HEUR_FIN_RES_DEPARTEMENT='" + dem.HEUR_FIN_RES_DepartementS + "',STATUS_RESPONSABLE_DEPARTEMENT='" + dem.STATUS_RESPONSABLE_DEPARTEMENTS + "'  where   ID_DEMANDE_CONGE='" + dem.ID_Demandee + "' ";

            cnx.maj(rsql, out erreur);
        }

        public void modifier_DEMANDE(DateTime d2,String idd, out String erreur)
        {
            erreur = null;
            //rsql = "update  DEMANDE_CONGE set DATE_DEBUT_RES_SERVICE='" + d1.ToShortDateString()+ "',DATE_FIN_RES_SERVICE='" +d2.ToShortTimeString()+ "',HEUR_DEBUT_RES_SERVICE='" +h1+"',HEUR_FIN_RES_SERVICE='" + h2+"',STATUS_RESPONSABLE_SERVICE='" + status + "' where    DEMANDE_CONGE.ID_DEMANDE_CONGE='" + idd + "'  ";//,DATE_DEBUT_RES_DEPARTEMENT='" + dem.DATE_DEBUT_RES_DEPARTEMENTS.ToShortDateString() + "',DATE_FIN_RES_DEPARTEMENT='" + dem.DATE_FIN_RES_DEPARTEMENTS.ToShortDateString() + "',HEUR_DEBUT_RES_DEPARTEMENT='" + dem.HEUR_DEBUT_RES_DepartementS + "',HEUR_FIN_RES_DEPARTEMENT='" + dem.HEUR_FIN_RES_DepartementS + "',STATUS_RESPONSABLE_DEPARTEMENT='" + dem.STATUS_RESPONSABLE_DEPARTEMENTS + "'  where   ID_DEMANDE_CONGE='" + dem.ID_Demandee + "' ";
rsql = "update  DEMANDE_CONGE set DATE_FIN_RES_SERVICE='" + d2.ToShortTimeString() + "' where   ID_DEMANDE_CONGE='" + idd + "' ";//,HEUR_DEBUT_RES_SERVICE='" +h1+"',HEUR_FIN_RES_SERVICE='" + h2+"',STATUS_RESPONSABLE_SERVICE='" + status + "' where    DEMANDE_CONGE.ID_DEMANDE_CONGE='" + idd + "'  ";//,DATE_DEBUT_RES_DEPARTEMENT='" + dem.DATE_DEBUT_RES_DEPARTEMENTS.ToShortDateString() + "',DATE_FIN_RES_DEPARTEMENT='" + dem.DATE_FIN_RES_DEPARTEMENTS.ToShortDateString() + "',HEUR_DEBUT_RES_DEPARTEMENT='" + dem.HEUR_DEBUT_RES_DepartementS + "',HEUR_FIN_RES_DEPARTEMENT='" + dem.HEUR_FIN_RES_DepartementS + "',STATUS_RESPONSABLE_DEPARTEMENT='" + dem.STATUS_RESPONSABLE_DEPARTEMENTS + "'  where   ID_DEMANDE_CONGE='" + dem.ID_Demandee + "' ";

            cnx.maj(rsql, out erreur);
        }







        public DataTable GetDemandeConge()
        {
            try
            {
                return cnx.Read("DEMANDE_CONGE");
            }
            catch
            {

                throw;
            }
        }


        public void nombreline(out String nombre)
        {
            String erreur;
            nombre = "";
            rsql = "select count(*)  from DEMANDE_CONGE ";
            cnx.select(rsql, out erreur, out dr);

            if (dr.Read())
            {
                    nombre = dr.GetString(0);
                }
            
            dr.Close();
        }



        public void chercher_Demande_conge_STATUS(String id, out string erreur, out String status, out Boolean exist)
        {
            erreur = null;
            status = "";
            exist = false;
            rsql = "select * from  DEMANDE_CONGE where   DEMANDE_CONGE.ID_DEMANDE_CONGE='" + id + "' ";
            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {
                    exist = true;
                    dr.Read();
                    status = dr.GetString(9);


                }
                dr.Close();
            }



        }



        public void imprimer(out string erreur, out String nom, out String prenom, out DateTime datedem, out DateTime d1, out DateTime d2, out Boolean exist, String mat,out String statuss, out String sexe, out String hd, out String hf)
        {
            erreur = null;
            exist = false;
            nom = "";
            prenom = "";
            datedem = DateTime.Now;
            d1 = DateTime.Now;
            d2 = DateTime.Now;
            statuss = "";
            sexe = "";hf = "";hd = "";
            rsql = "select e.nom,e.prenom,dc.DATE_DEMANDE,dc.DATE_DEBUT_CONGE,dc.DATE_FIN_CONGE,dc.status,e.sexe,dc.heur_debut,dc.heur_fin from demande_conge dc,employe e where dc.MATRICULE=e.MATRICULE and dc.MATRICULE= '" + mat + "'"; //where MATRICULE='" + mat+"' ";
            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {
                    exist = true;
                    dr.Read();
                    nom = Convert.ToString(dr[0]);
                    prenom = Convert.ToString(dr[1]);
                    datedem = Convert.ToDateTime(dr[2]);
                    d1 = Convert.ToDateTime(dr[3]);
                    d2 = Convert.ToDateTime(dr[4]);
                    statuss = Convert.ToString(dr[5]);
                    sexe = Convert.ToString(dr[6]);
                    hd = Convert.ToString(dr[7]);
                    hf = Convert.ToString(dr[8]);
                }
                dr.Close();
            }



        }


        public void getSomme(int anner, String MAT, out string erreur, out string sum, out Boolean exist)
        {
            erreur = null;
            sum = "";
            exist = false;
            anner = anner - 1;
            //     rsql = " select sum(nombrejour)AS nbjour from demande_conge where SUBSTR(date_demande, 1, 4) ="+anner+" and CIN ='"+cin+"' ";
            rsql = "select SUM(NOMBREJOUR) from DEMANDE_CONGE  where to_number(to_char(date_demande,'yyyy')) =" + anner + " and MATRICULE ='" + MAT + "'  ";
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

        public void Somme_demandes_conges(DateTime d1,DateTime d2, String MAT, out string erreur, out string sum, out Boolean exist)
        {
            erreur = null;
            sum = "";
            exist = false;
           // anner = anner - 1;
            rsql = "select count(*) from  DEMANDE_CONGE where DATE_DEMANDE between '" + d1.ToShortDateString() + "' and'" + d2.ToShortDateString()+ "' and MATRICULE in (select MATRICULE from employe  where SERVICE in(select id_service from service where RESPONSABLe_service ='" + MAT+"' ))";

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

        public void RechercherParcritere_Anner(String criter, out string erreur, out string sum, out Boolean exist)
        {
            erreur = null;
            sum = "";
            exist = false;//to_char(DATE_DEMANDE,'yyyy')  ='" + criter + "' and status='Accepter Par le GRH' ";
                          // String critere = "

            rsql = "select count(*) from DEMANDE_CONGE " + criter;
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