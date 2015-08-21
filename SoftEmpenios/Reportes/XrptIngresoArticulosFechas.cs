using System;
using System.Linq;
using DevExpress.XtraReports.UI;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.Reportes
{
    public partial class XrptIngresoArticulosFechas : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptIngresoArticulosFechas()
        {
            InitializeComponent();
        }

        private void xrPlata_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor =
                new EmpeñosDC(new clsConeccionDB().StringConn()).Articulos.Where(
                    v => v.Kilates == "Plata" && (v.FechaRegistro >= Convert.ToDateTime(FechaInicial.Value) && v.FechaRegistro <= Convert.ToDateTime(FechaFinal.Value)) && v.Estado != "Baja").Sum(v => (decimal?)v.Peso) ??
                0;
            e.Result = valor;
            e.Handled = true;
        }

        private void xrMedallon_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor =
               new EmpeñosDC(new clsConeccionDB().StringConn()).Articulos.Where(
                   v => v.Kilates == "Medallon" && (v.FechaRegistro >= Convert.ToDateTime(FechaInicial.Value) && v.FechaRegistro <= Convert.ToDateTime(FechaFinal.Value)) && v.Estado != "Baja").Sum(v => (decimal?)v.Peso) ??
               0;
            e.Result = valor;
            e.Handled = true;
        }

        private void xr10Rojo_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor =
               new EmpeñosDC(new clsConeccionDB().StringConn()).Articulos.Where(
                   v => v.Kilates == "Oro 10Kt Rojo" && (v.FechaRegistro >= Convert.ToDateTime(FechaInicial.Value) && v.FechaRegistro <= Convert.ToDateTime(FechaFinal.Value)) && v.Estado != "Baja").Sum(v => (decimal?)v.Peso) ??
               0;
            e.Result = valor;
            e.Handled = true;
        }

        private void xr10A_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor =
               new EmpeñosDC(new clsConeccionDB().StringConn()).Articulos.Where(
                   v => v.Kilates == "Oro 10Kt Amarillo" && (v.FechaRegistro >= Convert.ToDateTime(FechaInicial.Value) && v.FechaRegistro <= Convert.ToDateTime(FechaFinal.Value)) && v.Estado != "Baja").Sum(v => (decimal?)v.Peso) ??
               0;
            e.Result = valor;
            e.Handled = true;
        }

        private void xr14_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor =
               new EmpeñosDC(new clsConeccionDB().StringConn()).Articulos.Where(
                   v => v.Kilates == "Oro 14Kt" && (v.FechaRegistro >= Convert.ToDateTime(FechaInicial.Value) && v.FechaRegistro <= Convert.ToDateTime(FechaFinal.Value)) && v.Estado != "Baja").Sum(v => (decimal?)v.Peso) ??
               0;
            e.Result = valor;
            e.Handled = true;
        }

        private void xr18_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor =
               new EmpeñosDC(new clsConeccionDB().StringConn()).Articulos.Where(
                   v => v.Kilates == "Oro 18Kt" && (v.FechaRegistro >= Convert.ToDateTime(FechaInicial.Value) && v.FechaRegistro <= Convert.ToDateTime(FechaFinal.Value)) && v.Estado != "Baja").Sum(v => (decimal?)v.Peso) ??
               0;
            e.Result = valor;
            e.Handled = true;
        }

        private void xr22_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor =
               new EmpeñosDC(new clsConeccionDB().StringConn()).Articulos.Where(
                   v => v.Kilates == "Oro 22Kt" && (v.FechaRegistro >= Convert.ToDateTime(FechaInicial.Value) && v.FechaRegistro <= Convert.ToDateTime(FechaFinal.Value)) && v.Estado != "Baja").Sum(v => (decimal?)v.Peso) ??
               0;
            e.Result = valor;
            e.Handled = true;
        }

        private void xr24_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor =
               new EmpeñosDC(new clsConeccionDB().StringConn()).Articulos.Where(
                   v => v.Kilates == "Oro 24Kt" && (v.FechaRegistro >= Convert.ToDateTime(FechaInicial.Value) && v.FechaRegistro <= Convert.ToDateTime(FechaFinal.Value)) && v.Estado != "Baja").Sum(v => (decimal?)v.Peso) ??
               0;
            e.Result = valor;
            e.Handled = true;
        }

        private void xrTotalOro_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor =
               new EmpeñosDC(new clsConeccionDB().StringConn()).Articulos.Where(
                   v => (v.Kilates != "Varios") && (v.FechaRegistro >= Convert.ToDateTime(FechaInicial.Value) && v.FechaRegistro <= Convert.ToDateTime(FechaFinal.Value)) && v.Estado != "Baja").Sum(v => (decimal?)v.Peso) ??
               0;
            e.Result = valor;
            e.Handled = true;
        }

        private void xrVarios_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor =
              new EmpeñosDC(new clsConeccionDB().StringConn()).Articulos.Where(
                  v => v.Kilates == "Varios" && (v.FechaRegistro >= Convert.ToDateTime(FechaInicial.Value) && v.FechaRegistro <= Convert.ToDateTime(FechaFinal.Value)) && v.Estado != "Baja").Sum(v => (decimal?)v.Peso) ??
              0;
            e.Result = valor;
            e.Handled = true;
        }

        private void xr10RNuevo_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor =
               new EmpeñosDC(new clsConeccionDB().StringConn()).Articulos.Where(
                   v => v.Kilates == "Oro 10Kt Rojo Nuevo" && (v.FechaRegistro >= Convert.ToDateTime(FechaInicial.Value) && v.FechaRegistro <= Convert.ToDateTime(FechaFinal.Value)) && v.Estado != "Baja").Sum(v => (decimal?)v.Peso) ??
               0;
            e.Result = valor;
            e.Handled = true;
        }

        private void xr10ANuevo_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor =
               new EmpeñosDC(new clsConeccionDB().StringConn()).Articulos.Where(
                   v => v.Kilates == "Oro 10Kt Amarillo Nuevo" && (v.FechaRegistro >= Convert.ToDateTime(FechaInicial.Value) && v.FechaRegistro <= Convert.ToDateTime(FechaFinal.Value)) && v.Estado != "Baja").Sum(v => (decimal?)v.Peso) ??
               0;
            e.Result = valor;
            e.Handled = true;
        }

        private void xr14Nuevo_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor =
               new EmpeñosDC(new clsConeccionDB().StringConn()).Articulos.Where(
                   v => v.Kilates == "Oro 14Kt Nuevo" && (v.FechaRegistro >= Convert.ToDateTime(FechaInicial.Value) && v.FechaRegistro <= Convert.ToDateTime(FechaFinal.Value)) && v.Estado != "Baja").Sum(v => (decimal?)v.Peso) ??
               0;
            e.Result = valor;
            e.Handled = true;
        }

        private void xrTableCell26_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            decimal valor =
              new EmpeñosDC(new clsConeccionDB().StringConn()).Articulos.Where(
                  v => v.Kilates == "Plata Nueva" && (v.FechaRegistro >= Convert.ToDateTime(FechaInicial.Value) && v.FechaRegistro <= Convert.ToDateTime(FechaFinal.Value)) && v.Estado != "Baja").Sum(v => (decimal?)v.Peso) ??
              0;
            e.Result = valor;
            e.Handled = true;
        }

    }
}
