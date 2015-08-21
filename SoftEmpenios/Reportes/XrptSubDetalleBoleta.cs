using System.Linq;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.Reportes
{
    public partial class XrptSubDetalleBoleta : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptSubDetalleBoleta()
        {
            InitializeComponent();
        }

        private void XrptSubDetalleBoleta_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataSource =
                new EmpeñosDC(new clsConeccionDB().StringConn()).DetallesBoletas.Where(
                    db => db.Folio == FolioBoleta.Value.ToString());
        }

    }
}
