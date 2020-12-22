using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Gestion_Paie_Oracle
{
    public class cnx
    {
        private string cs;
        private OracleConnection cx = new OracleConnection();
        private OracleCommand cmd = new OracleCommand();
        public void ouvrirConnexion(out string erreur)
        {
            erreur = null;
            cs = "Data Source = localhost; Persist Security Info = True; User ID = mariem; Password = mariem;";
            //  cs  "Data Source=Dell-PC;user Id=mariem ;Password=mariem;";
            try
            {
                if (cx.State == ConnectionState.Closed)
                {
                    cx.ConnectionString = cs;
                    cx.Open();
                }
            }
            catch (Exception ex)
            {
                erreur = "Erreur de connexion" + ex.Message;
            }
        }
        public void fermerConnexion()
        {
            if (cx.State == ConnectionState.Open)
                cx.Close();
        }

        public void select(string rsql, out string erreur, out OracleDataReader dr)
        {
            erreur = null;
            dr = null;
            ouvrirConnexion(out erreur);
            try
            {
                cmd.Connection = cx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = rsql;
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                erreur = "Erreur de sélection " + ex.Message;
            }

        }
        public void maj(string rsql, out string erreur)
        {
            erreur = null;
            ouvrirConnexion(out erreur);
            try
            {
                cmd.Connection = cx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = rsql;
                cmd.ExecuteNonQuery();
                fermerConnexion();
            }
            catch (Exception ex)
            {
                erreur = "Erreur de sélection " + ex.Message;
            }

        }

    }
}