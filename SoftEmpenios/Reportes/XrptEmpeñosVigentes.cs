using System.Linq;
using DevExpress.XtraReports.UI;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.Reportes
{
    public partial class XrptEmpeñosVigentes : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptEmpeñosVigentes()
        {
            InitializeComponent();
        }

        private void xrTableCell14_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = new EmpeñosDC(new clsConeccionDB().StringConn()).DetallesBoletas.Where(p => p.Prenda != null && (p.Prenda.Tipo == "Plata" && p.Boleta.EstadoBoleta=="Vigente")).Sum(p => p.Prenda != null ? (decimal?)p.Prenda.Peso : 0)??0;
            e.Result = total;
                e.Handled = true;
           
        }
        private void xrMedallon_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = new EmpeñosDC(new clsConeccionDB().StringConn()).DetallesBoletas.Where(p => p.Prenda != null && (p.Prenda.Tipo == "Medallon" && p.Boleta.EstadoBoleta=="Vigente")).Sum(p => p.Prenda != null ? (decimal?)p.Prenda.Peso : 0)??0;
             e.Result = total;
            e.Handled = true;
        }

        private void xr10Rojo_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = new EmpeñosDC(new clsConeccionDB().StringConn()).DetallesBoletas.Where(p => p.Prenda != null && (p.Prenda.Tipo == "Oro 10Kt Rojo" && p.Boleta.EstadoBoleta=="Vigente")).Sum(p => p.Prenda != null ? (decimal?)p.Prenda.Peso : 0) ?? 0;
            e.Result = total;
            e.Handled = true;
        }

        private void xr10A_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = new EmpeñosDC(new clsConeccionDB().StringConn()).DetallesBoletas.Where(p => p.Prenda != null && (p.Prenda.Tipo == "Oro 10Kt Amarillo" && p.Boleta.EstadoBoleta=="Vigente")).Sum(p => p.Prenda != null ? (decimal?)p.Prenda.Peso : 0) ?? 0;
            e.Result = total;
            e.Handled = true;
        }

        private void xr14_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = new EmpeñosDC(new clsConeccionDB().StringConn()).DetallesBoletas.Where(p => p.Prenda != null && (p.Prenda.Tipo == "Oro 14Kt" && p.Boleta.EstadoBoleta=="Vigente")).Sum(p => p.Prenda != null ? (decimal?)p.Prenda.Peso : 0) ?? 0;
            e.Result = total;
            e.Handled = true;
        }

        private void xr18_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = new EmpeñosDC(new clsConeccionDB().StringConn()).DetallesBoletas.Where(p => p.Prenda != null && (p.Prenda.Tipo == "Oro 18Kt" && p.Boleta.EstadoBoleta=="Vigente")).Sum(p => p.Prenda != null ? (decimal?)p.Prenda.Peso : 0) ?? 0;
            e.Result = total;
            e.Handled = true;
        }

        private void xr22_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = new EmpeñosDC(new clsConeccionDB().StringConn()).DetallesBoletas.Where(p => p.Prenda != null && (p.Prenda.Tipo == "Oro 22Kt" && p.Boleta.EstadoBoleta=="Vigente")).Sum(p => p.Prenda != null ? (decimal?)p.Prenda.Peso : 0) ?? 0;
            e.Result = total;
            e.Handled = true;
        }

        private void xr24_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = new EmpeñosDC(new clsConeccionDB().StringConn()).DetallesBoletas.Where(p => p.Prenda != null && (p.Prenda.Tipo == "Oro 24Kt" && p.Boleta.EstadoBoleta=="Vigente")).Sum(p => p.Prenda != null ? (decimal?)p.Prenda.Peso : 0) ?? 0;
            e.Result = total;
            e.Handled = true;
        }

        private void xrMotos_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = new EmpeñosDC(new clsConeccionDB().StringConn()).DetallesBoletas.Where(p => p.Prenda != null && (p.Prenda.Tipo == "Motocicleta" && p.Boleta.EstadoBoleta=="Vigente")).Sum(p => p.Prenda != null ? (decimal?)p.Prenda.Peso : 0) ?? 0;
            e.Result = total;
            e.Handled = true;
        }

        private void xrAutos_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = new EmpeñosDC(new clsConeccionDB().StringConn()).DetallesBoletas.Where(p => p.Prenda != null && (p.Prenda.Tipo == "Automovil" && p.Boleta.EstadoBoleta=="Vigente")).Sum(p => p.Prenda != null ? (decimal?)p.Prenda.Peso : 0) ?? 0;
            e.Result = total;
            e.Handled = true;
        }

        private void xrVarios_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal total = new EmpeñosDC(new clsConeccionDB().StringConn()).DetallesBoletas.Where(p => p.Prenda != null && (p.Prenda.Tipo == "Varios" && p.Boleta.EstadoBoleta=="Vigente")).Sum(p => p.Prenda != null ? (decimal?)p.Prenda.Peso : 0) ?? 0;
            e.Result = total;
            e.Handled = true;
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XrptSubDetalleBoleta) ((XRSubreport) sender).ReportSource).FolioBoleta.Value =
                GetCurrentColumnValue("Folio");
        }
    }
}
