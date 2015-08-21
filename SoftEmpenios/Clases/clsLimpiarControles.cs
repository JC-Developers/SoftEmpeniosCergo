using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SoftEmpenios.Clases
{
    public class ManejadorControles
    {
        public void LimpiarControles(System.Windows.Forms.Control c)
        {
            switch (c.GetType().Name)
            {
                
                case "JCTextBox":
                case "MemoEdit":
                case "TextEditCurrency":
                    c.Text = string.Empty;
                    break;
                
                case "TextEdit":
                case "TextEditSelected":
                    if (((TextEdit)c).EditValue.GetType() == Type.GetType("System.Decimal"))
                        ((TextEdit)c).EditValue = 0M;
                    else if (((TextEdit)c).EditValue.GetType() == Type.GetType("System.Int32"))
                        ((TextEdit)c).EditValue = 0;
                    else
                        ((TextEdit)c).EditValue = string.Empty;
                    break;
                case "LookUpEdit":
                    ((LookUpEdit)c).EditValue = null;
                    break;
                case "ComboBoxEdit":
                    ((ComboBoxEdit)c).EditValue = null;
                    break;
                case "SpinEdit":
                    ((SpinEdit)c).EditValue = ((SpinEdit)c).Properties.MinValue;
                    break;
                case "DateEdit":
                    ((DateEdit)c).EditValue = DateTime.Today.Date;
                    break;



                default:
                    foreach (Control child in c.Controls)
                        LimpiarControles(child);
                    break;

            }
        }
        public void DesectivarTextBox(System.Windows.Forms.Control c, bool activar)
        {
            switch (c.GetType().Name)
            {
                case "TextEdit":
                case "MemoEdit":
                case "LookUpEdit":
                case "SpinEdit":
                case "ComboBoxEdit":
                case "ButtonEdit":
                case "TextEditSelected":
                    c.Enabled = activar;
                    break;
               
                default:
                    foreach (System.Windows.Forms.Control child in c.Controls)
                        DesectivarTextBox(child, activar);
                    break;
            }

        }
    }

}
