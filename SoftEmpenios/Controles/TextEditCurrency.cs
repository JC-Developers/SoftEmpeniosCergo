using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SoftEmpenios.Reportes
{
    public partial class TextEditCurrency : TextEdit
    {
        public TextEditCurrency()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        protected override void OnGotFocus(System.EventArgs e)
        {
            base.SelectAll();

        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                //e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        protected override void OnClick(System.EventArgs e)
        {
            base.SelectAll();
        }
    }
}
