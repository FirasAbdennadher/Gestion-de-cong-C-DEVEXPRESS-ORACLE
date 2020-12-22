using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Acces;
using Metier;
namespace Gestion_Paie_Oracle
{

    public partial class Login_Form : Form
    {

        public Login_Form()
        {
            InitializeComponent();
            panel2.Visible = false;
            timer1.Enabled = true;


        }
     //   gestion_entreprise g_entreprise = new gestion_entreprise();


        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Ajouterentreprise_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;

        }

       
        

        public void Login_Form_Load(object sender, EventArgs e)
        {
            //this.password.isPassword = true;
            // password.isPassword = true;
            users.Text = "GRH";
            password.Text = "GRH";
        //    CenterToParent();
            //  this.AcceptButton = login_btn;
          //  gestion_entreprise g_entreprise = new gestion_entreprise();
            String error = null;
            List<entreprise_class> l;//= new List<entreprise_class>();
            Boolean exist = false;

         /*   g_entreprise.chercher_entreprise("id_ent>0", out error, out l, out exist);

            foreach (entreprise_class x in l)
            {

                company.Properties.Items.Add(x.designiation_ent);
            }*/
         //  company.SelectedIndex = 0;

        //  authentifier_Click(sender, e);

        }



    private void authentifier_Click(object sender, EventArgs e)
        {
            login l = new login();
            String error = null;
            Boolean exist = false;
            String rolee="";
            String departem = "";
            String servic = "";
            Int32 id = 0;
            int x = 0;
            String matricule_emp = "";
            String nom_employer="";
            String prenom_emplyer="";
            String telephone_emplyer="";
            l.connecter(users.Text, password.Text, "", out error, out exist, out rolee, out id, out departem, out servic,out matricule_emp, out nom_employer,out prenom_emplyer,out telephone_emplyer);
            String ch = "";// company.Text;
            /* g_entreprise.chercher_entreprise_nom(ch,out error,out x, out exist);
             MessageBox.Show(x + "");*/
            if (exist == true)
            {
                this.BringToFront();

                //   this.Hide();
                // Formulaire.Second_menu f1 = new Second_menu(ch,id,login.Text);
                Menu f1 = new Menu(ch, rolee, users.Text,id,departem,servic, matricule_emp,nom_employer,prenom_emplyer,telephone_emplyer);

                try
                {
                    f1.ShowDialog();// Show();
                }catch(Exception ex)
                {
                    MessageBox.Show("Il ya une erreur" + ex);
                }
            }
            else
            {
                MessageBox.Show("le login " + users.Text + "et le mot de pass" + password.Text + " est inccorect ! ");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (transitionManager1.IsTransition)
            {
                transitionManager1.EndTransition();
            }
            else
            {
                transitionManager1.StartTransition(panel1);
            }
            imageSlider1.AnimationTime = 3500;
            int max = imageSlider1.Images.Count;
            int cur = 0;
            if (cur < max) { imageSlider1.SlideNext(); }
            else { cur = 0; timer1.Stop(); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
/*
            login l = new login();
            String error = null;
            Boolean exist = false;
            int id;
            int x = 0;
            l.connecter(users.Text, password.Text, "", out error, out exist, out id);
            String ch ="";//; company.Text;
            
            if (exist == true)
            {

                this.Hide();
                // Formulaire.Second_menu f1 = new Second_menu(ch,id,login.Text);
                Menu f1 = new Menu(ch, id, users.Text);
                f1.validaiton_navbar.Enabled = false;
                f1.type_conge_bar.Enabled = false;
                f1.demande_baritem.Enabled = false;

                try
                {
                    f1.ShowDialog();// Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Il ya une erreur" + ex);
                }
            }
            else
            {
                MessageBox.Show("le login " + users.Text + "et le mot de pass" + password.Text + " est inccorect ! ");
            }
            */
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cnx cnx = new cnx();
            string erreur = null;
            cnx.ouvrirConnexion(out erreur);
            if (erreur == null)
                MessageBox.Show("connexion réussite");
            else
                MessageBox.Show(erreur);
        }
    }
}