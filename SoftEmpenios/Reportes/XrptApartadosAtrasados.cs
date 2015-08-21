using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraReports.UI;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.Reportes
{
    public partial class XrptApartadosAtrasados : DevExpress.XtraReports.UI.XtraReport
    {
        private readonly IEnumerable<DetalleVenta> _articulos =
            new EmpeñosDC(new clsConeccionDB().StringConn()).DetalleVentas.Where(a => a.Venta.Estado == "Apartado" &&
            a.Venta.FechaVenta.AddMonths(
                        Convert.ToInt32(new clsModificarConfiguracion().configGetValue("VencimientoApartado"))).Date <
                    DateTime.Today.Date);
        
        public XrptApartadosAtrasados()
        {
            InitializeComponent();
        }

        private void xrPlata_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor =_articulos.Where(art=>art.Articulo.Kilates== "Plata").Sum(art => art.Articulo.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xrMedallon_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Articulo.Kilates == "Medallon").Sum(art => art.Articulo.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xr10Rojo_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Articulo.Kilates == "Oro 10Kt Rojo").Sum(art => art.Articulo.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xr10A_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Articulo.Kilates == "Oro 10Kt Amarillo").Sum(art => art.Articulo.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xr14_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Articulo.Kilates == "Oro 14Kt").Sum(art => art.Articulo.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xr18_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Articulo.Kilates == "Oro 18Kt").Sum(art => art.Articulo.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xr22_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Articulo.Kilates == "Oro 22Kt").Sum(art => art.Articulo.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xr24_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Articulo.Kilates == "Oro 24Kt").Sum(art => art.Articulo.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xrTotalOro_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Articulo.Kilates != "Medallon" && art.Articulo.Kilates != "Varios" && art.Articulo.Kilates != "Plata" && art.Articulo.Kilates != "Plata Nueva").Sum(art => art.Articulo.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xrVarios_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Articulo.Kilates == "Varios").Sum(art => art.Articulo.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xrPlataNueva_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Articulo.Kilates == "Plata nuevo").Sum(art => art.Articulo.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xr10RNuevo_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Articulo.Kilates == "Oro 10Kt Rojo Nuevo").Sum(art => art.Articulo.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xr10ANuevo_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Articulo.Kilates == "Oro 10Kt Amarillo Nuevo").Sum(art => art.Articulo.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xr14Nuevo_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor = _articulos.Where(art => art.Articulo.Kilates == "Oro 14Kt Nuevo").Sum(art => art.Articulo.Peso);
            e.Result = valor;
            e.Handled = true;
        }

        private void xrTableCell11_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {

        }

        private void xrTableCell11_SummaryRowChanged(object sender, EventArgs e)
        {
            
        }

        private void xrTableCell11_EvaluateBinding(object sender, BindingEventArgs e)
        {
            Venta vent =
                new EmpeñosDC(new clsConeccionDB().StringConn()).Ventas.Single(c => c.Clave == Convert.ToInt32(e.Value));
            e.Value = vent.Saldo-vent.PagosVentas.Where(pv=>pv.Estado).Sum(pv=>pv.Abono);
        }

        private void xrLabel4_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal ventas =
            new EmpeñosDC(new clsConeccionDB().StringConn()).Ventas.Where(a => a.Estado == "Apartado" &&
            a.FechaVenta.AddMonths(
                        Convert.ToInt32(new clsModificarConfiguracion().configGetValue("VencimientoApartado"))).Date <
                    DateTime.Today.Date)
                    .Select(v=>new {saldo=v.Saldo- v.PagosVentas.Where(p=>p.Estado).Sum(p=>p.Abono)}).Sum(arg => arg.saldo);
            
            e.Result = ventas;
            e.Handled = true;
        }

    }
}
