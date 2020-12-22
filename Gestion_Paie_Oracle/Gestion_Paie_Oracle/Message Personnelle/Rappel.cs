using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gestion_Paie_Oracle.Message_Personnelle
{
    public partial class Rappel : Form
    {
        public Rappel()
        {
            InitializeComponent();
        }

        private void Rappel_Load(object sender, EventArgs e)
        {
            bunifuFormFadeTransition1.ShowAsyc(this);
        }
    }
}
