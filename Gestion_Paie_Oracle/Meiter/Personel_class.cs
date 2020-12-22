using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using Acces;
//using Oracle.DataAccess.Client;
using Oracle.ManagedDataAccess.Client;

namespace Metier
{
    public class Personel_class
    {

        #region attribut
        private String nom;
        private String prenom;
        private DateTime datanais;
        private String Cin;
        private String sexe;
        private String Rolee;
        private String etat_civil;
        private String adresse;
        private DateTime date_recrutement;
        private String telephone_societee;
        private String telephoneprive;
        private String ville;
        private String lieu_nais;
        private Int32 id_ent;
        private String matricule;
        private String DEPARTEMENT;
        private String SERVICE;
        private String email;
        private String Login;
        private String Motpass;
       
        #endregion




        #region conctructor et getter et setter
        public Personel_class(String mat, String cin, String nom, String pren, DateTime dn,String lieunais, String sexe, String role,  String ec, String adr, DateTime dr, String telsoc, String telepriv, String ville, int iden,String dep,String serv,String em,String log , String pass)
        {
            email = em;
            Login = log;
            Motpass = pass;
            this.nom = nom;
            prenom = pren;
            datanais = dn;
            Cin = cin;
            this.sexe = sexe;
            Rolee = role;
            etat_civil = ec;
            adresse = adr;
            date_recrutement = dr;
            telephone_societee = telsoc;
            telephoneprive = telepriv;
            this.ville = ville;
            lieu_nais = lieunais;
            id_ent = iden;
            this.matricule = mat;
            DEPARTEMENT = dep;
            SERVICE = serv;
        }

        public Personel_class()
        {
            Login = "";
            Motpass = "";

            email = "";
            DEPARTEMENT = "";
            SERVICE = "";
            nom = "";
            prenom = "";
            datanais =Convert.ToDateTime( DateTime.Now.Date.ToString("dd-MM-yyyy"));
            Cin = "";
            sexe = "";
            Rolee = "";
            etat_civil = "";
            adresse = "";
            date_recrutement = Convert.ToDateTime(DateTime.Now.Date.ToString("dd-MM-yyyy"));
            telephone_societee = "";
            telephoneprive = "";

            this.ville = "";
            lieu_nais = "";
            id_ent = 0;
            matricule = "";
        }

           
        public Personel_class(String cin, String etat)
        {
            this.Cin = cin;
            etat_civil = etat;

        }

        public String EMAIL
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public String Role
        {
            get { return this.Rolee; }
            set { this.Rolee = value; }
        }

        public String Pass
        {
            get { return this.Motpass; }
            set { this.Motpass = value; }
        }
        public String LOGIN
        {
            get { return this.Login; }
            set { this.Login = value; }
        }


        public String lieux
        {
            get { return this.lieu_nais; }
            set { this.lieu_nais = value; }
        }

   

        

        public String Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public String Prenom
        {
            get { return this.prenom; }
            set { this.prenom = value; }
        }
        
        public DateTime datenais
        {
            get { return this.datanais; }
            set { this.datanais = value; }
        }
        public String cin
        {
            get { return this.Cin; }
            set { this.Cin = value; }
        }
  
       
        public String etatcivil
        {
            get { return this.etat_civil; }
            set { this.etat_civil = value; }
        }
        public String Adresse
        {
            get { return this.adresse; }
            set { this.adresse = value; }
        }
        public DateTime daterecrutement
        {
            get { return this.date_recrutement; }
            set { this.date_recrutement = value; }
        }
        
        public String telephonesociete
        {
            get { return this.telephone_societee; }
            set { this.telephone_societee = value; }
        }
        public String villes
        {
            get { return this.ville; }
            set { this.ville = value; }
        }

        public String sexxe
        {
            get { return this.sexe; }
            set { this.sexe = value; }
        }
     
        public String Matricule
        {
            get { return this.matricule; }
            set { this.matricule = value; }
        }

        public int id_entr
        {
            get { return this.id_ent; }
            set { this.id_ent = value; }
        }

        public String Telephone_prive
        {
            get { return this.telephoneprive; }
            set { this.telephoneprive = value; }
        }


        public String Departements
        {
            get { return this.DEPARTEMENT; }
            set { this.DEPARTEMENT = value; }
        }
        public String Services
        {
            get { return this.SERVICE; }
            set { this.SERVICE = value; }
        }


        #endregion
    }

    //gestion Personel

    public class GestionPersonel
    {

        string rsql;
        Connexion cnx = new Connexion();
        OracleDataReader dr = null;




        //chercher Personel

        public void chercher_Personel(string mat, out string erreur, out Personel_class per, out Boolean exist)
        {
            erreur = null;
            per = new Personel_class();
            exist = false;
            rsql = "select * from  employe where   employe.MATRICULE='" + mat + "' ";
            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {
                    exist = true;
                    dr.Read();
                    per.Matricule = dr.GetString(0);
                    per.cin = dr.GetString(1);
                    per.Nom = dr.GetString(2);
                    per.Prenom = dr.GetString(3);
                    per.datenais = dr.GetDateTime(4);
                    per.lieux = dr.GetString(5);
                    per.sexxe = dr.GetString(6);
                    per.Role = dr.GetString(7);
                    per.etatcivil = dr.GetString(8);
                    per.Adresse = dr.GetString(9);
                    per.daterecrutement = dr.GetDateTime(10);
                    per.telephonesociete = dr.GetString(11);
                    per.Telephone_prive = dr.GetString(12);
                    per.villes = dr.GetString(13);
                    per.id_entr = dr.GetInt32(14);
                    per.Departements = dr.GetString(15);
                    per.Services = dr.GetString(16);
                    per.EMAIL = dr.GetString(17);
                    per.LOGIN = dr.GetString(18);
                    per.Pass = dr.GetString(19);



                }
                dr.Close();
            }
        }

        //chercher Personel list  selon un critére
        public void chercher_ListePersonel(String critere, out String erreur, out List<Personel_class> list, out Boolean exist)
        {
            erreur = null;
            list = new List<Personel_class>();
            Personel_class per = new Personel_class();
            exist = false;
            rsql = "select * from   employe" + critere;

            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {
                        per = new Personel_class();
                        per.Matricule = dr.GetString(0);
                        per.cin = dr.GetString(1);
                        per.Nom = dr.GetString(2);
                        per.Prenom = dr.GetString(3);
                        per.datenais = dr.GetDateTime(4);
                        per.lieux = dr.GetString(5);
                        per.sexxe = dr.GetString(6);
                        per.Role = dr.GetString(7);
                        per.etatcivil = dr.GetString(8);
                        per.Adresse = dr.GetString(9);
                        per.daterecrutement = dr.GetDateTime(10);
                        per.telephonesociete = dr.GetString(11);
                        per.Telephone_prive = dr.GetString(12);
                        per.villes = dr.GetString(13);
                        per.id_entr = dr.GetInt32(14);
                        per.Departements = dr.GetString(15);
                        per.Services = dr.GetString(16);
                        per.EMAIL = dr.GetString(17);
                        per.LOGIN = dr.GetString(18);
                        per.Pass = dr.GetString(19);

                        list.Add(per);
                    }
                }
                dr.Close();

            }


        }



        public void ajouter_Per(Personel_class per, out String erreur)
        {
          //  dr.Close();
            erreur = null;
            rsql = "insert into   employe (MATRICULE, CIN, NOM, PRENOM, DATENAISSENCE, LIEUNAISSENCE, SEXE, ROLE, ETAT_CIVIL, ADRESSE, DATE_RECRUTEMENT, TELEPHONESOCEITE, TELEPHONEPRIVE, VILLE, ID_ENT,DEPARTEMENT,SERVICE,EMAIL,LOGIN,MOTPASS) values('" + per.Matricule+"','" + per.cin + "','" + per.Nom+"','"+per.Prenom+"','" + per.datenais.ToShortDateString() + "','"+per.lieux+"','" + per.sexxe + "','" + per.Role + "','" + per.etatcivil + "','" + per.Adresse + "','" + per.daterecrutement.ToShortDateString() + "','" + per.telephonesociete + "','"+per.Telephone_prive+"','" + per.villes + "',"+ per.id_entr + ",'" + per.Departements + "','" + per.Services + "','" + per.EMAIL + "','"+per.LOGIN+"','"+per.Pass+"')";
            cnx.maj(rsql, out erreur);

        }
        public void supprimer_Employer(Personel_class pers, out String erreur)
        {
            erreur = null;
            rsql = "delete from   employe  where   employe.Matricule='" + pers.Matricule + "' ";
            cnx.maj(rsql, out erreur);
        }

        public void modifier_Personel(Personel_class per, out String erreur)
        {
            erreur = null;
            rsql = "update   employe set nom='" + per.Nom + "',prenom='"+per.Prenom+ "',DATENAISSENCE='" + per.datenais.ToShortDateString() + "',sexe='" + per.sexxe + "',ROLE='" + per.Role + "',etat_civil='" + per.etatcivil + "',adresse='" + per.Adresse + "',date_recrutement='" + per.daterecrutement.ToShortDateString() + "',TELEPHONESOCEITE='" + per.telephonesociete + "',ville='" + per.villes + "',LIEUNAISSENCE='" + per.lieux + "',id_ent=" + per.id_entr + ",TELEPHONEPRIVE='"+per.Telephone_prive+ "',DEPARTEMENT='"+per.Departements+ "',SERVICE='"+per.Services+ "',EMAIL='"+per.EMAIL+ "',LOGIN='"+per.LOGIN+ "',MOTPASS='"+per.Pass+"' where MATRICULE='" + per.Matricule + "' ";

            cnx.maj(rsql, out erreur);
        }

        public DataTable GetPersonal()
        {
            try
            {
                return cnx.Read(" EMPLOYE");
            }
            catch
            {

                throw;
            }
        }



/*
        public void ajouter_Personal_dataTable(Personel_class pr)
        {

            cnx.Read("employe");
            DataTable datatable = new DataTable();
            DataRow drToAdd = datatable.NewRow();

            drToAdd["Cin"] = pr.cin;
            drToAdd["nom"] = pr.Nom;
            drToAdd["prenom"] = pr.Prenom;
            drToAdd["datenais"] = pr.datenais;
            drToAdd["sexe"] = pr.sexxe;
            drToAdd["fonction"] = pr.Fonction;
            drToAdd["nb_enfant"] = pr.nbenfant;
            drToAdd["etat_civil"] = pr.etatcivil;
            drToAdd["adresse"] = pr.Adresse;
            drToAdd["date_recrutement"] = pr.daterecrutement;
            drToAdd["echlon"] = pr.echlons;
            drToAdd["telephone"] = pr.telephonesociete;
            drToAdd["ville"] = pr.villes;
            drToAdd["nationalite"] = pr.natio;
            drToAdd["num_CNSS"] = pr.num_cnss;
            drToAdd["salaire_base"] = pr.salaire_bases;
            drToAdd["date_sortie"] = pr.date_sorti;
            drToAdd["lieu"] = pr.lieux;
           /* drToAdd["ARRIERE_CONGE"] = pr.Arrier_conge;
            drToAdd["DROIT_ANNER_COURANT"] = pr.Droit_annner_courant;
            drToAdd["PRIS_ANNER_COURANT"] = pr.Pris_anner_courant;

            datatable.Rows.Add(drToAdd);

        }
        */
    

        public void chercher_ListePersonelSelon_Matricule(String mat, out String erreur, out List<Personel_class> list, out Boolean exist)
        {
            erreur = null;
            list = new List<Personel_class>();
            Personel_class per = new Personel_class();
            exist = false;
            rsql = "select * from   employe where  employe.MATRICULE='" + mat + "' ";
            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {
                        per = new Personel_class();

                        per.Matricule = dr.GetString(0);
                        per.cin = dr.GetString(1);
                        per.Nom = dr.GetString(2);
                        per.Prenom = dr.GetString(3);
                        per.datenais = dr.GetDateTime(4);
                        per.lieux = dr.GetString(5);
                        per.sexxe = dr.GetString(6);
                        per.Role = dr.GetString(7);
                        per.etatcivil = dr.GetString(8);
                        per.Adresse = dr.GetString(9);
                        per.daterecrutement = dr.GetDateTime(10);
                        per.telephonesociete = dr.GetString(11);
                        per.Telephone_prive = dr.GetString(12);
                        per.villes = dr.GetString(13);
                        per.id_entr = dr.GetInt32(14);
                        per.Departements = dr.GetString(15);
                        per.Services = dr.GetString(16);
                        per.EMAIL = dr.GetString(17);
                        per.LOGIN = dr.GetString(18);
                        per.Pass = dr.GetString(19);

                        list.Add(per);
                    }
                }
                dr.Close();

            }


        }



        public void modifier_Etat_Person(string mat ,string etatciv, out String erreur)
        {
            erreur = null;
            rsql = "update   employe set ETAT_CIVIL='" + etatciv + "' where MATRICULE='" + mat + "' ";
            cnx.maj(rsql, out erreur);
        }



        public void comare(DateTime date, out String erreur, out List<Personel_class> list, out Boolean exist)
        {
            erreur = null;
            list = new List<Personel_class>();
            Personel_class per = new Personel_class();
            exist = false;
            rsql = "select * from employe where DATENAISSENCE <'"+ date.ToShortDateString()+"' ";

            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {

                    exist = true;
                    while (dr.Read())
                    {
                        per = new Personel_class();

                        per.Nom = dr.GetString(2);

                        list.Add(per);
                    }
                }
                dr.Close();

            }


        }


        public void changer_login(String log,String pass,String mat, out String erreur)
        {
            erreur = null;
            rsql = "update   employe set LOGIN='" + log + "',MOTPASS='" + pass + "' where MATRICULE='" + mat + "' ";

            cnx.maj(rsql, out erreur);
        }



    }
}
