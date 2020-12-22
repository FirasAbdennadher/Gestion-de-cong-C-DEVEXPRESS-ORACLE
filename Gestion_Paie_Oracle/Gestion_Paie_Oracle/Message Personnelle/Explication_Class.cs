using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Gestion_Paie_Oracle.Message_Personnelle
{
   public static class Explication_Class
    {
        public static DialogResult ShowMessage(String msg ,String caption,MessageBoxButtons btn, MessageBoxIcon icon)
        {
            DialogResult dgres = DialogResult.None;
            switch (btn)
            {
                case MessageBoxButtons.OK:
                  
                        using (frmmsgok frmok = new frmmsgok())
                        {
                            frmok.Text = caption;
                            frmok.mesage = msg;
                        switch (icon)
                        {
                            case MessageBoxIcon.Information:
                                frmok.msgicon = Properties.Resources.Exclamation_icon1;break;
                            case MessageBoxIcon.Question:
                                frmok.msgicon = Properties.Resources.Icon_Small_2x;break;
                        }
                        dgres = frmok.ShowDialog();

                        
                    }break;

                case MessageBoxButtons.YesNo:

                    using (FrmMsgYesNo frmokYesNo = new FrmMsgYesNo())
                    {
                        frmokYesNo.Text = caption;
                        frmokYesNo.mesage = msg;
                        switch (icon)
                        {
                            case MessageBoxIcon.Information:
                                frmokYesNo.msgicon = Properties.Resources.Exclamation_icon1; break;
                            case MessageBoxIcon.Question:
                                frmokYesNo.msgicon = Properties.Resources.Icon_Small_2x;

                                break;
                        }
                        dgres = frmokYesNo.ShowDialog();


                    }
                    break;

            }
            return dgres;
        }
    }
}
