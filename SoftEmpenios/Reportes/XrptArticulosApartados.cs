using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraReports.UI;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.Reportes
{
    public partial class XrptArticulosApartados : DevExpress.XtraReports.UI.XtraReport
    {
        private readonly IEnumerable<Articulo> _articulos =
            new EmpeñosDC(new clsConeccionDB().StringConn()).Articulos.Where(a => a.Estado == "Apartado");
        public XrptArticulosApartados()
        {
            InitializeComponent();
        }

        private void xrPlata_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Kilates == "Plata").Sum(art => art.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xrMedallon_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Kilates == "Medallon").Sum(art => art.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xr10Rojo_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Kilates == "Oro 10Kt Rojo").Sum(art => art.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xr10A_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Kilates == "Oro 10Kt Amarillo").Sum(art => art.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xr14_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Kilates == "Oro 14Kt").Sum(art => art.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xr18_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Kilates == "Oro 18Kt").Sum(art => art.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xr22_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Kilates == "Oro 22Kt").Sum(art => art.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xr24_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Kilates == "Oro 24Kt").Sum(art => art.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xrTotalOro_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Kilates != "Medallon" && art.Kilates != "Varios" && art.Kilates != "Plata" ).Sum(art => art.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xrVarios_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Kilates == "Varios").Sum(art => art.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xrTableCell13_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            //var saldo = new EmpeñosDC(new clsConeccionDB().StringConn()).DetalleVentas
            //    .Where(vta => vta.Clave == Convert.ToDecimal(GetCurrentColumnValue("Clave"))).Select(
            //        vta =>
            //            new
            //            {
            //                vta.DetalleVentas,
            //                vta.Saldo,
            //                Abonos = vta.PagosVentas.Sum(pg => (decimal?) pg.Abono) ?? 0,
            //                SaldoActual = vta.Saldo - (vta.PagosVentas.Sum(pg => (decimal?) pg.Abono) ??0)
            //            });
            //e.Result = saldo.Sum(c=>c.SaldoActual);
                e.Handled = true;
        }

        private void xr10RNuevo_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Kilates == "Oro 10Kt Rojo Nuevo").Sum(art => art.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xr10ANuevo_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Kilates == "Oro 10Kt Amarillo Nuevo").Sum(art => art.Peso);
            e.Result = valor;
            e.Handled = true;}

        private void xr14Nuevo_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Kilates == "Oro 14Kt Nuevo").Sum(art => art.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xrPlataNueva_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Kilates == "Plata Nueva").Sum(art => art.Peso);
            e.Result = valor;
            e.Handled = true;
        }

    }
}
