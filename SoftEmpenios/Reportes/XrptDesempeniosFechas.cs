using DevExpress.XtraReports.UI;

namespace SoftEmpenios.Reportes
{
    public partial class XrptDesempeniosFechas : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptDesempeniosFechas()
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
