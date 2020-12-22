using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acces;
using Oracle.ManagedDataAccess.Client;

//using Oracle.DataAccess.Client;
namespace Metier
{
    public class login
    {
        string rsql;
        Connexion Oracle_connecter = new Connexion();
        OracleDataReader dr = null;

        public void connecter(string nom, string motpass, string entre, out string erreur, out Boolean exist, out String rolee,out Int32 id,out String deparrt,out String Services,out String matricule_emp,out String nom_employer,out String prenom_employer,out String telephone)
        {
            nom_employer = "";
            prenom_employer = "";
            telephone="";
            erreur = null;
            exist = false;
            rolee = "";
            id = 0;
             deparrt = "";
             Services = "";
            matricule_emp = "";

            rsql = " select * from employe where employe.login = '" + nom + "' and employe.motpass = '" + motpass + "' ";//and id_ent=(select id_ent from entreprise where desg_ent='" + entre + "') ";
            Oracle_connecter.select(rsql, out erreur, out dr);
            if (erreur == null)
            {
                if (dr.HasRows == true)
                {    exist = true;
                    dr.Read();
                    //  rolee=dr.GetString()
                    // id = dr.GetInt32(3);
                    rolee = dr.GetString(7);

                    id = dr.GetInt32(14);
                    deparrt = dr.GetString(15);
                    Services = dr.GetString(16);
                    matricule_emp = dr.GetString(0);

                }
                dr.Close();
            }
        }



    }
}
