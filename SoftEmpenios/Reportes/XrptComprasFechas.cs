using System;
using System.Linq;
using DevExpress.XtraReports.UI;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.Reportes
{
    public partial class XrptComprasFechas : XtraReport
    {
         public DateTime FechaInicial;
        public DateTime FechaFinal;
        private IQueryable<DetallesCompra> detalles;
        public XrptComprasFechas()
        {
            InitializeComponent();
        detalles= new EmpeñosDC(new clsConeccionDB().StringConn()).DetallesCompras
            .Where(d => (d.Compra.FechaCompra.Date >= FechaInicial && d.Compra.FechaCompra.Date <= FechaFinal) && d.Compra.Estado);
        }

        private void xrPlata_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = Enumerable.Sum(detalles.Where(detallesCompra => detallesCompra.TipodeCompra == "Plata"), detallesCompra => detallesCompra.PesoCantidad);
            e.Result = total;
            e.Handled = true;
        }

        private void xrMedallon_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = Enumerable.Sum(detalles.Where(detallesCompra => detallesCompra.TipodeCompra == "Medallon"), detallesCompra => detallesCompra.PesoCantidad);
            e.Result = total;
            e.Handled = true;
        }

        private void xr10Rojo_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = Enumerable.Sum(detalles.Where(detallesCompra => detallesCompra.TipodeCompra == "Oro 10Kt Rojo"), detallesCompra => detallesCompra.PesoCantidad);
            e.Result = total;
            e.Handled = true;
        }

        private void xr10A_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = Enumerable.Sum(detalles.Where(detallesCompra => detallesCompra.TipodeCompra == "Oro 10Kt Amarillo"), detallesCompra => detallesCompra.PesoCantidad);
            e.Result = total;
            e.Handled = true;
        }

        private void xr14_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = Enumerable.Sum(detalles.Where(detallesCompra => detallesCompra.TipodeCompra == "Oro 14Kt"), detallesCompra => detallesCompra.PesoCantidad);
            e.Result = total;
            e.Handled = true;
        }

        private void xr18_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = Enumerable.Sum(detalles.Where(detallesCompra => detallesCompra.TipodeCompra == "Oro 18Kt"), detallesCompra => detallesCompra.PesoCantidad);
            e.Result = total;
            e.Handled = true;
        }

        private void xr22_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = Enumerable.Sum(detalles.Where(detallesCompra => detallesCompra.TipodeCompra == "Oro 22Kt"), detallesCompra => detallesCompra.PesoCantidad);
            e.Result = total;
            e.Handled = true;
        }

        private void xr24_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = Enumerable.Sum(detalles.Where(detallesCompra => detallesCompra.TipodeCompra == "Oro 24Kt"), detallesCompra => detallesCompra.PesoCantidad);
            e.Result = total;
            e.Handled = true;
        }

        private void xrDolares_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = Enumerable.Sum(detalles.Where(detallesCompra => detallesCompra.TipodeCompra == "Dolares"), detallesCompra => detallesCompra.PesoCantidad);
            e.Result = total;
            e.Handled = true;
        }
    }
}
