using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Gestion_Paie_Oracle.Simple_Fenetre
{
    public partial class Type_Conge_datagridview : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static Type_Conge_datagridview datagridtypeconge;

        public Type_Conge_datagridview()
        {
            InitializeComponent();
        }

        private void datagrid_listTypeConge_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'dataSet3.TYPE_CONGE'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.tYPE_CONGETableAdapter1.Fill(this.dataSet3.TYPE_CONGE);
           // this.tYPE_CONGETableAdapter.Fill(this.dataSet1.TYPE_CONGE);
            datagridtypeconge = this;
        }

        private void DgTypeconge_Click(object sender, EventArgs e)
        {

            if (Gestion_Paie_Oracle.Menu.pr.button_Typeconge_WasClicked == true)
            {

                int index = gridView2.FocusedRowHandle;

                Gestion_Paie_Oracle.Menu.pr.id_conger_pourenregiter = gridView2.GetRowCellValue(index, "ID_CONGE").ToString();

                Gestion_Paie_Oracle.Menu.pr.code_type_cong_ongle_demande.Text = gridView2.GetRowCellValue(index, "ID_CONGE").ToString();
                Gestion_Paie_Oracle.Menu.pr.libelel_type_conge.Text = gridView2.GetRowCellValue(index, "DESGIN_CONGE").ToString();

                var_textbox_idconge.Text = gridView2.GetRowCellValue(index,"ID_CONGE").ToString();


                if (gridView2.GetRowCellValue(index,"CONGE_PAYE").ToString().Equals("Oui"))
                {
                    Gestion_Paie_Oracle.Menu.pr.cbcongepay.Checked = true;
                }
                else
                {
                    Gestion_Paie_Oracle.Menu.pr.cbcongepay.Checked = false;

                }
                if (gridView2.GetRowCellValue(index, "MAJ_CONGE_PAY").ToString().Equals("Oui"))
                {
                    Gestion_Paie_Oracle.Menu.pr.cb_maj.Checked = true;
                }
                else
                {
                    Gestion_Paie_Oracle.Menu.pr.cb_maj.Checked = false;

                }
                if (gridView2.GetRowCellValue(index, "JOUR_OUVRABLE").ToString().Equals("Oui"))
                {
                    Gestion_Paie_Oracle.Menu.pr.cb_jouvrable.Checked = true;

                }
                else
                {
                    Gestion_Paie_Oracle.Menu.pr.cb_jouvrable.Checked = false;

                }




                this.Close();

            }
            else
            {
                int index = Type_Conge_datagridview.datagridtypeconge.gridView2.FocusedRowHandle;
                #region lorsque click on type conge


                Gestion_Paie_Oracle.Menu.pr.code_type_conge.Text = Type_Conge_datagridview.datagridtypeconge.gridView2.GetRowCellValue(index, "ID_CONGE").ToString();
                Gestion_Paie_Oracle.Menu.pr.libelle_type_conge.Text = Type_Conge_datagridview.datagridtypeconge.gridView2.GetRowCellValue(index, "DESGIN_CONGE").ToString();
                if (datagridtypeconge.gridView2.GetRowCellValue(index, "CONGE_PAYE").ToString().Equals("Oui"))
                {
                    Gestion_Paie_Oracle.Menu.pr.combobox_congepye.Checked = true;
                }
                else
                {
                    Gestion_Paie_Oracle.Menu.pr.combobox_congepye.Checked = false;

                }

                if (Type_Conge_datagridview.datagridtypeconge.gridView2.GetRowCellValue(index, "MAJ_CONGE_PAY").ToString().Equals("Oui"))
                {
                    Gestion_Paie_Oracle.Menu.pr.comboBoxmiseajour_conge.Checked = true;
                }
                else
                {
                    Gestion_Paie_Oracle.Menu.pr.comboBoxmiseajour_conge.Checked = false;

                }
                if (Type_Conge_datagridview.datagridtypeconge.gridView2.GetRowCellValue(index, "JOUR_OUVRABLE").ToString().Equals("Oui"))
                {
                    Gestion_Paie_Oracle.Menu.pr.comboboxjourouvrable.Checked = true;

                }
                else
                {
                    Gestion_Paie_Oracle.Menu.pr.comboboxjourouvrable.Checked = false;

                }

                Gestion_Paie_Oracle.Menu.pr.speci.Text = Type_Conge_datagridview.datagridtypeconge.gridView2.GetRowCellValue(index, "SPECIFICATION").ToString();
            }
            #endregion
            //     Gestion_Paie_Oracle.Menu.pr.BringToFront();
            this.Close();

        }
    }
}