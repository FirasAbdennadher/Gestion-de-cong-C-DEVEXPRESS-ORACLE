using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Oracle.DataAccess.Client;
using Oracle.ManagedDataAccess.Client;
using System.Data;
namespace Acces
{
    public class Connexion
    {
        public string cs= "";
        public OracleConnection cx = new OracleConnection();
        public OracleCommand cmd = new OracleCommand();
        OracleDataAdapter da;
        OracleDataReader dr;
        public DataTable dt = new DataTable();

        public void ouvrirConnexion(out string erreur)
        {
            erreur = null;
            //   cs = "Data Source=Dell-PC;user Id=mariem ;Password=mariem;";
            cs = "Data Source = localhost; Persist Security Info = True; User ID = mariem; Password = mariem;";
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
                erreur = "Erreur de MAJ " + ex.Message;
            }

        }



        public DataTable Read(String table)
        {
            cx.ConnectionString = cs;
            if (ConnectionState.Closed == cx.State)
                cx.Open();
            cmd = new OracleCommand("select * from " + table, cx);
            try
            {
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;

            }
            catch
            {
                throw;
            }
        }


        public void nombreline(out Int32 nombre)
        {
            String rsql;
            nombre = 0;
            String erreur = null;
            ouvrirConnexion(out erreur);
            rsql = "SELECT Count(*) from DEMANDE_CONGE ";

            cmd = new OracleCommand(rsql);
            nombre = Convert.ToInt32(cmd.ExecuteScalar());
        }




    }
}
