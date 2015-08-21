using System;
using System.Linq;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.Reportes
{
    public partial class XrptSubDetalleVenta : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptSubDetalleVenta()
        {
            InitializeComponent();
        }

        private void XrptSubDetalleVenta_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataSource =
              new EmpeñosDC(new clsConeccionDB().StringConn()).DetalleVentas.Where(
                  db => db.CveVenta ==Convert.ToInt32( CveVenta.Value));
        }

    }
}
