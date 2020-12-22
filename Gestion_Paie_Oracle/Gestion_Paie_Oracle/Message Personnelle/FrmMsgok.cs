using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Gestion_Paie_Oracle.Message_Personnelle
{
    public partial class frmmsgok : DevExpress.XtraEditors.XtraForm
    {
        public frmmsgok()
        {
            InitializeComponent();
        }

        public Image msgicon
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public string  mesage
        {
            get { return lemessage.Text; }
            set { lemessage.Text = value; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          //  this.Close();
         //   List<Form> forms = new List<Form>();

       //    if (Explication_Class.ShowMessage("Le texteeee", "Titre", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.Yes)
         //   {
               // Explication_Class.ShowMessage("Le textt","titre", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FrmMsgYesNo ff = new FrmMsgYesNo();
            ff.Show();
           // }
        }

        private void frmmsgok_Load(object sender, EventArgs e)
        {

        }

        private void fermer_Click(object sender, EventArgs e)
        {

        }
    }
}