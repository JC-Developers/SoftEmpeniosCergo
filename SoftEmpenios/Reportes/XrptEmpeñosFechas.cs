using DevExpress.XtraReports.UI;

namespace SoftEmpenios.Reportes
{
    public partial class XrptEmpeñosFechas : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptEmpeñosFechas()
        {
            InitializeComponent();
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XrptSubDetalleBoleta)((XRSubreport)sender).ReportSource).FolioBoleta.Value =
                GetCurrentColumnValue("Folio");
        }
    }
}
