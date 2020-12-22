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
    public partial class FrmMsgYesNo : DevExpress.XtraEditors.XtraForm
    {
        public FrmMsgYesNo()
        {
            InitializeComponent();
        }


        public Image msgicon
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public string mesage
        {
            get { return lemessage.Text; }
            set { lemessage.Text = value; }
        }
    }
}