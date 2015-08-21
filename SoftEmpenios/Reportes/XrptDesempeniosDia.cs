using DevExpress.XtraReports.UI;

namespace SoftEmpenios.Reportes
{
    public partial class XrptDesempeniosDia : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptDesempeniosDia()
        {
            InitializeComponent();
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XrptSubDetalleBoleta)((XRSubreport)sender).ReportSource).FolioBoleta.Value =
                GetCurrentColumnValue("FolioBoleta");
        }

    }
}
