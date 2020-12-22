using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Metier;

namespace Gestion_Paie_Oracle.Simple_Fenetre
{
    public partial class Compte : DevExpress.XtraEditors.XtraForm
    { string matricule;
        public Compte(string mat)
        {
            InitializeComponent();
            matricule = mat;
        }
        String erreur = null;
        GestionPersonel gp = new GestionPersonel();
        private void button1_Click(object sender, EventArgs e)
        {
            gp.changer_login(login_utilsateur.Text, Password_utlisateur.Text, matricule, out erreur);
            if (erreur == null)
            {
                MessageBox.Show("Modification avec succes");
                Gestion_Paie_Oracle.Menu.pr.login_utilsateur.Text = this.login_utilsateur.Text;
                Gestion_Paie_Oracle.Menu.pr.Password_utlisateur.Text = this.Password_utlisateur.Text;
                this.Close();
            }
            else { MessageBox.Show("Ereur modifier" + erreur); }
        }

        private void Compte_Load(object sender, EventArgs e)
        {
            this.login_utilsateur.Text = Gestion_Paie_Oracle.Menu.pr.login_utilsateur.Text;
            this.Password_utlisateur.Text = Gestion_Paie_Oracle.Menu.pr.Password_utlisateur.Text;

           
        }
    }
}