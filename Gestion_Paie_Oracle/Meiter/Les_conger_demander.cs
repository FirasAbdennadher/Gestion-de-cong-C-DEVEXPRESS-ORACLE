using Acces;
//using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace Meiter
{
    public class Les_conger_demander
    {
        String codedemande;
        String CIN;
        String nomPrenom;

        public Les_conger_demander(String cd,String cc,String np)
        {
            codedemande = cd;
            CIN = cc;
            nomPrenom = np;


        }
        public Les_conger_demander()
        {
            codedemande = "";
            CIN = "";
            nomPrenom = "";


        }

    }



    public class gestion_Les_conger_demander
    {

        string rsql;
        Connexion cnx = new Connexion();
        OracleDataReader dr = null;





     /*   public DataTable getmontantprime1(String cin)
        {

            cnx.cx.ConnectionString = cnx.cs;
            DataTable datatable;

            String Query = "select emp.NOM||' '||emp.PRENOM,EMP.CIN from VALIDATION_CONGE vc,DEMANDE_CONGE dc,EMPLOYE emp where vc.ID_DEMANDE_CONGE = dc.ID_DEMANDE_CONGE and dc.CIN = emp.CIN";
            cnx.cmd = new OracleCommand(Query, cnx.cx);
            OracleDataAdapter sqladapter = new OracleDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = cnx.cmd;

            sqladapter.Fill(datatable);
            return datatable;


        }*/


        

    }
}
