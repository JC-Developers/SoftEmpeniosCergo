using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace SoftEmpenios.Reportes
{
    public partial class XrptHistrorialPagoPersonal : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptHistrorialPagoPersonal()
        {
            InitializeComponent();
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //((XrptSubHistorialPersonal)((XRSubreport) sender).ReportSource).DatosSubInforme.DataSource = DatosInforme.DataSource;
        }

    }
}
