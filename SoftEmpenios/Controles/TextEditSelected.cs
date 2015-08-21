using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SoftEmpenios.Controles
{
    public partial class TextEditSelected : TextEdit
    {
        public TextEditSelected()
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
