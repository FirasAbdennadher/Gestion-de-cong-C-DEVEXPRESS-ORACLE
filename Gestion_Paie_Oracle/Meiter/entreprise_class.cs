using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Oracle.DataAccess.Client;
using Oracle.ManagedDataAccess.Client;

using Acces;

namespace Metier
{
    public class entreprise_class
    {
        private Int32 id_ent;
        private String desg_ent;
        private String adr_ent;
        private String email_ent;
        private String tel_ent;
        private String fax_ent;
        private String mat_fisc;
        private String datecr;
        private Int32 nb_j_mois;
        private Int32 nb_heur_jour;
        private Int32 cnss;
        private int Cp;
        private String ville;
        private String repot1;
        private String repot2;




        public entreprise_class(Int32 id, String des, String adr,String email, String tel, String fax, String fisc, Int32 nbjour, Int32 nbh, Int32 cnsss, String dr,String vl  , int cp,String re1,String re2)
        {
            datecr = dr;
            nb_j_mois = nbjour; nb_heur_jour = nbh; cnss = cnsss;
            id_ent = id;
            desg_ent = des;
            adr_ent = adr;
            email_ent = email;
            tel_ent = tel;
            fax_ent = fax;
            mat_fisc = fisc;

            ville = vl;
            Cp = cp;

            repot1 = re1;
            repot2 = re2;
        }

        public entreprise_class()
        {
            ville = "";
            Cp = 0;
            nb_j_mois = 0; nb_heur_jour = 0; cnss = 0;
          //  datecr =DateTime.Now;
            id_ent = 0;
            desg_ent = "";
            adr_ent = "";
            email_ent = "";
            tel_ent = "";
            fax_ent = "";
            mat_fisc = "";
            repot1 = "";
            repot2 = "";
        }

        public String DCreat
        {
            get { return this.datecr; }
            set { this.datecr = value; }

        }

        public String Repot1
        {
            get { return this.repot1; }
            set { this.repot1 = value; }

        }
        public String Repot2
        {
            get { return this.repot2; }
            set { this.repot2 = value; }

        }
        public String Ville
        {
            get { return this.ville; }
            set { this.ville = value; }

        }


        public int CodeCP
        {
            get { return this.Cp; }
            set { this.Cp = value; }

        }

        public int nbjoursmois
        {
            get { return this.nb_j_mois; }
            set { this.nb_j_mois = value; }

        }
        public int nbheurjours
        {
            get { return this.nb_heur_jour; }
            set { this.nb_heur_jour = value; }

        }
        public int cnsss
        {
            get { return this.cnss; }
            set { this.cnss = value; }

        }

        public int id_entreprise
        {
            get { return this.id_ent; }
            set { this.id_ent = value; }

        }
        public String designiation_ent
        {
            get { return this.desg_ent; }
            set { this.desg_ent = value; }
        }
        public String adresse
        {
            get { return this.adr_ent; }
            set { this.adr_ent = value; }
        }

        public String email_entreprise
        {
            get { return this.email_ent; }
            set { this.email_ent = value; }
        }


        public String telephone_entreprise
        {
            get { return this.tel_ent; }
            set { this.tel_ent = value; }
        }


        public String fax_entreprise
        {
            get { return this.fax_ent; }
            set { this.fax_ent = value; }
        }


        public String matricule_fiscale
        {
            get { return this.mat_fisc; }
            set { this.mat_fisc = value; }
        }


    }

    //gestion armateur

    public class gestion_entreprise
    {

        string rsql;
        Connexion cnx = new Connexion();
        OracleDataReader dr = null;
        


        //chercher entreprise
        #region chercger 
        
                public void chercher_entreprise(String criter,out string erreur, out List<entreprise_class> list_emp, out Boolean exist)
                {
                    erreur = null;
                    entreprise_class ent = new entreprise_class();
                    list_emp = new List<entreprise_class>();
                    exist = false;
                    rsql = "select * from entreprise where "+criter;
                    cnx.select(rsql, out erreur, out dr);


                    if (erreur == null)
                    {
                        if (dr.HasRows == true)
                        {

                            exist = true;
                            while (dr.Read())
                            {
                                ent = new entreprise_class();
                                ent.id_entreprise = dr.GetInt32(0);
                                ent.designiation_ent = dr.GetString(1);
                                ent.adresse = dr.GetString(2);
                                ent.email_entreprise = dr.GetString(3);
                                ent.telephone_entreprise = dr.GetString(4);
                                ent.fax_entreprise = dr.GetString(5);
                                ent.matricule_fiscale = dr.GetString(6);
                                ent.nbjoursmois = dr.GetInt32(7);
                                ent.nbheurjours = dr.GetInt32(8);
                                ent.cnsss = dr.GetInt32(9);
                        ent.DCreat = dr.GetString(10);
                        ent.CodeCP = dr.GetInt32(11);

                        ent.Ville = dr.GetString(12);
                        ent.Repot1 = dr.GetString(13);
                        ent.Repot2 = dr.GetString(14);

                        list_emp.Add(ent);
                            }
                            dr.Close();
                        }
                    }
                }



                public void chercher_entreprise(int id, out string erreur, out entreprise_class ent, out Boolean exist)
                {
                    erreur = null;
                    ent = new entreprise_class();
                    exist = false;
                    rsql = "select * from entreprise where id_ent=" + id + " ";
                    cnx.select(rsql, out erreur, out dr);
                    if (erreur == null)
                    {
                        if (dr.HasRows == true)
                        {
                            exist = true;
                            dr.Read();

                    ent = new entreprise_class();
                    ent.id_entreprise = dr.GetInt32(0);
                    ent.designiation_ent = dr.GetString(1);
                    ent.adresse = dr.GetString(2);
                    ent.email_entreprise = dr.GetString(3);
                    ent.telephone_entreprise = dr.GetString(4);
                    ent.fax_entreprise = dr.GetString(5);
                    ent.matricule_fiscale = dr.GetString(6);
                    ent.nbjoursmois = dr.GetInt32(7);
                    ent.nbheurjours = dr.GetInt32(8);
                    ent.cnsss = dr.GetInt32(9);
                    ent.DCreat = dr.GetString(10);
                    ent.CodeCP = dr.GetInt32(11);

                    ent.Ville = dr.GetString(12);
                    ent.Repot1 = dr.GetString(13);
                    ent.Repot2 = dr.GetString(14);


                }
                dr.Close();
                    }



                }
               
        #endregion


        public void chercher_entreprise_nom(String des, out string erreur, out int x, out Boolean exist)
        {
            x = 0;
            erreur = null;
            exist = false;
            rsql = "select * from entreprise where desg_ent='" + des + "' ";
            cnx.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {
                    exist = true;
                    dr.Read();

                    x = dr.GetInt32(0);

                }
                dr.Close();
            }



        }




        public void modifier_En(entreprise_class en, out String erreur)
        {
            erreur = null;
            //  rsql = "update entreprise set desg_ent ='" + en.designiation_ent + "',adr_ent='"+en.adresse+ "',email_ent='"+en.email_entreprise+ "',mat_fisc='" + en.matricule_fiscale + "', tel_ent='" + en.telephone_entreprise+ "',fax_ent='"+en.fax_entreprise+ "',nb_jour_mois="+en.nbjoursmois+ ",nb_heur_jour="+en.nbheurjours+ ",cnss="+en.cnsss+ ",date_creation='"+en.DCreat.ToString("dd-MM-yyyy")+ "',codepostal="+en.CodeCP+ ",ville='"+en.Ville+"' where id_ent=" + en.id_entreprise + " ";
 rsql = "update entreprise set desg_ent ='" + en.designiation_ent + "',adr_ent='"+en.adresse+ "',email_ent='"+en.email_entreprise+ "',mat_fisc='" + en.matricule_fiscale + "', tel_ent='" + en.telephone_entreprise+ "',fax_ent='"+en.fax_entreprise+ "',nb_jour_mois="+en.nbjoursmois+ ",nb_heur_jour="+en.nbheurjours+ ",cnss="+en.cnsss+ ",date_creation='"+en.DCreat+ "',codepostal="+en.CodeCP+ ",ville='"+en.Ville+"' where id_ent=" + en.id_entreprise + " ";

            cnx.maj(rsql, out erreur);
        }




    }
}
