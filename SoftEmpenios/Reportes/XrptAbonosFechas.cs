using DevExpress.XtraReports.UI;

namespace SoftEmpenios.Reportes
{
    public partial class XrptAbonosFechas : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptAbonosFechas()
        {
            InitializeComponent();
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XrptSubDetalleVenta)((XRSubreport)sender).ReportSource).CveVenta.Value =
               GetCurrentColumnValue("CveVenta");
        }

    }
}
