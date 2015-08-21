using System;
using System.Linq;
using DevExpress.XtraEditors;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;
using SoftEmpenios.Reportes;

namespace SoftEmpenios.Dialogos
{
    public partial class FrmReportesFechas : XtraForm
    {
        public FrmReportesFechas()
        {
            InitializeComponent();
            dtpFechaInicial.EditValue = dtpFechaFinal.EditValue = DateTime.Today.Date;
        }

        private void botonVerInforme_Click(object sender, EventArgs e)
        {
            switch (cboTipoReporte.SelectedIndex)
            {
                case 0:
                {
                    var bol = new EmpeñosDC(new clsConeccionDB().StringConn()).Boletas
                        .Where(b => (b.FechaPrestamo >= dtpFechaInicial.DateTime.Date && b.FechaPrestamo<=dtpFechaFinal.DateTime.Date ) && b.EstadoBoleta != "Cancelado");
                    if (bol.Any())
                    {
                        XrptEmpeñosFechas rptbol = new XrptEmpeñosFechas { DataSource = bol };
                        rptbol.ShowPreviewDialog();
                    }
                    else
                        XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
                }
                    break;
                case 1:
                {
                    var inte = new EmpeñosDC(new clsConeccionDB().StringConn()).PagosInteres
                        .Where(i => (i.FechaPago >= dtpFechaInicial.DateTime.Date && i.FechaPago <= dtpFechaFinal.DateTime.Date) && i.Estado );
                    if (inte.Any())
                    {
                        XrptInteresesFechas rptbol = new XrptInteresesFechas { DataSource = inte };
                        rptbol.ShowPreviewDialog();
                    }
                    else
                        XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
                }break;
                case 2:
                {
                    var des = new EmpeñosDC(new clsConeccionDB().StringConn()).Desempeños
                        .Where(b => (b.FechaDesempeño >= dtpFechaInicial.DateTime.Date && b.FechaDesempeño <= dtpFechaFinal.DateTime.Date) && b.Estado );
                    if (des.Any())
                    {
                        XrptDesempeniosFechas rptbol = new XrptDesempeniosFechas { DataSource = des };
                        rptbol.ShowPreviewDialog();
                    }
                    else
                        XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
                }break;
                case 3:
                {
                    var com = new EmpeñosDC(new clsConeccionDB().StringConn()).Compras
                        .Where(b => (b.FechaCompra >= dtpFechaInicial.DateTime.Date && b.FechaCompra <= dtpFechaFinal.DateTime.Date) && b.Estado);
                    if (com.Any())
                    {
                        XrptComprasFechas rptbol = new XrptComprasFechas { DataSource = com };
                        rptbol.FechaInicial=dtpFechaInicial.DateTime.Date;
                        rptbol.FechaFinal = dtpFechaFinal.DateTime.Date;
                        rptbol.ShowPreviewDialog();
                    }
                    else
                        XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
                }break;
                case 4:
                {
                    var dep = new EmpeñosDC(new clsConeccionDB().StringConn()).Transacciones
                        .Where(b => b.TipoTransaccion == "Deposito" && (b.FechaTransaccion >= dtpFechaInicial.DateTime.Date && b.FechaTransaccion <= dtpFechaFinal.DateTime.Date) && b.Estado );
                    if (dep.Any())
                    {
                        XrptTransaccionesFechas rptbol = new XrptTransaccionesFechas
                        {
                            DataSource = dep,
                            TipoTransaccion = { Value = "Depositos" }
                        };
                        rptbol.ShowPreviewDialog();
                    }
                    else
                        XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
                }break;
                case 5:
                    {
                        var dep = new EmpeñosDC(new clsConeccionDB().StringConn()).Transacciones
                            .Where(b => b.TipoTransaccion == "Retiro" && (b.FechaTransaccion >= dtpFechaInicial.DateTime.Date && b.FechaTransaccion <= dtpFechaFinal.DateTime.Date) && b.Estado );
                        if (dep.Any())
                        {
                            XrptTransaccionesFechas rptbol = new XrptTransaccionesFechas
                            {
                                DataSource = dep,
                                TipoTransaccion = { Value = "Retiros" }
                            };
                            rptbol.ShowPreviewDialog();
                        }
                        else
                            XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
                    } break;
                case 6:
                {
                    var dep = new EmpeñosDC(new clsConeccionDB().StringConn()).Cajas
                            .Where(b =>(b.FechaCajaAbierto >= dtpFechaInicial.DateTime.Date && b.FechaCajaAbierto <= dtpFechaFinal.DateTime.Date) && !b.Estado);
                    if (dep.Any())
                    {
                        XrptCajaFechas rptbol = new XrptCajaFechas
                        {
                            DataSource = dep,

                        };
                        rptbol.Parameters["Sucursal"].Value = new clsModificarConfiguracion().configGetValue("Empresa"); ;
                        rptbol.Parameters["Direccion"].Value = new clsModificarConfiguracion().configGetValue("Direccion"); ;
                        rptbol.Parameters["Cancelaciones"].Value = 0;
                        rptbol.ShowPreviewDialog();
                    }
                    else
                        XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
                }break;
                case 7:
                {
                    var canc = new EmpeñosDC(new clsConeccionDB().StringConn()).Cancelaciones.Where(
                                    v => v.FechaCancelacion >= dtpFechaInicial.DateTime.Date && v.FechaCancelacion<=dtpFechaFinal.DateTime.Date);
                    if (canc.Any())
                    {
                        XrptCancelacionesFechas articulos = new XrptCancelacionesFechas { DataSource = canc };
                        articulos.ShowPreviewDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay suficientes datos para mostrar el reporte", "Registros 0");
                }break;
                case 8:
                {
                    var cod = new EmpeñosDC(new clsConeccionDB().StringConn()).Boletas
                        .Where(b => b.FechaPrestamo >= dtpFechaInicial.DateTime.Date && b.FechaPrestamo <= dtpFechaFinal.DateTime.Date);
                    if (cod.Any())
                    {
                        XrptCodigoBarras rptbol = new XrptCodigoBarras { DataSource = cod };
                        rptbol.ShowPreviewDialog();
                    }
                    else
                        XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
                }break;
                case 9:
                {
                    var art = new EmpeñosDC(new clsConeccionDB().StringConn()).Articulos.Where(
                                   v => (v.FechaRegistro >= dtpFechaInicial.DateTime.Date && v.FechaRegistro<=dtpFechaFinal.DateTime.Date) && v.Estado != "Baja");
                    if (art.Any())
                    {
                        XrptIngresoArticulosFechas articulos = new XrptIngresoArticulosFechas
                        {
                            DataSource = art,
                            FechaInicial = {Value = dtpFechaInicial.DateTime.Date},
                            FechaFinal = {Value = dtpFechaFinal.DateTime.Date},
                        };
                        articulos.ShowPreviewDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay suficientes datos para mostrar el reporte", "Registros 0");
                }break;
                case 10:
                {
                    var vent = new EmpeñosDC(new clsConeccionDB().StringConn()).Ventas.Where(
                                    v => (v.FechaVenta >=dtpFechaInicial.DateTime.Date && v.FechaVenta<=dtpFechaFinal.DateTime.Date)  && v.Estado != "Cancelado");
                    if (vent.Any())
                    {
                        XrptVentasFechas articulos = new XrptVentasFechas { DataSource = vent };
                        articulos.ShowPreviewDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay suficientes datos para mostrar el reporte", "Registros 0");
                }break;
                case 11:
                {
                    var abonos = new EmpeñosDC(new clsConeccionDB().StringConn()).PagosVentas.Where(
                                   v => (v.FechaPago >= dtpFechaInicial.DateTime.Date && v.FechaPago<=dtpFechaFinal.DateTime.Date) && v.Estado);
                    if (abonos.Any())
                    {
                        XrptAbonosFechas abo = new XrptAbonosFechas { DataSource = abonos };
                        abo.ShowPreviewDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay suficientes datos para mostrar el reporte", "Registros 0");

                }break;
                case 12:
                    XrptFinanciamientosFechas fifechas = new XrptFinanciamientosFechas();
                    fifechas.Parameters["FechaInicial"].Value = dtpFechaInicial.DateTime.Date;
                    fifechas.Parameters["FechaFinal"].Value = dtpFechaFinal.DateTime.Date;
                    fifechas.ShowPreviewDialog();
                    break;
                case 13:
                    XrptPagosFinanciamientoFechas pagosfechas = new XrptPagosFinanciamientoFechas();
                    pagosfechas.Parameters["FechaInicial"].Value = dtpFechaInicial.DateTime.Date;
                    pagosfechas.Parameters["FechaFinal"].Value = dtpFechaFinal.DateTime.Date;
                    pagosfechas.ShowPreviewDialog();
                    break;
                case 14:
                    {
                        var dep = new EmpeñosDC(new clsConeccionDB().StringConn()).Transacciones
                            .Where(b => b.TipoTransaccion == "Base" && (b.FechaTransaccion >= dtpFechaInicial.DateTime.Date && b.FechaTransaccion <= dtpFechaFinal.DateTime.Date) && b.Estado);
                        if (dep.Any())
                        {
                            XrptTransaccionesFechas rptbol = new XrptTransaccionesFechas
                            {
                                DataSource = dep,
                                TipoTransaccion = { Value = "Base Grupal" }
                            };
                            rptbol.ShowPreviewDialog();
                        }
                        else
                            XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
                    } break;
                case 15:
                    {
                        var cre = new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraCreditos
                            .Where(b => (b.FechaInicio >= dtpFechaInicial.DateTime.Date && b.FechaInicio <= dtpFechaFinal.DateTime.Date) && b.Estado!="Cancelado");
                        var cred = new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraCreditos
                            .Where(b => (b.FechaInicio >= dtpFechaInicial.DateTime.Date && b.FechaInicio <= dtpFechaFinal.DateTime.Date) && b.Estado != "Cancelado").Select(c=>c.CveGrupo).ToList();
                        
                        int integrantes =
                new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraGruposDetalles.Count(
                    inte => cred.Contains(inte.CveGrupo));

                        if (cre.Any())
                        {
                            XrptCreditosFechas rptbol = new XrptCreditosFechas
                            {
                                DataSource = cre,
                                NumPersonas = {Value=integrantes}
                            };
                            rptbol.ShowPreviewDialog();
                        }
                        else
                            XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
                    } break;
                case 16:
                    {
                        var pagCre = new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraPagos
                            .Where(b => (b.FechaPago >= dtpFechaInicial.DateTime.Date && b.FechaPago <= dtpFechaFinal.DateTime.Date) && b.Estado);
                        if (pagCre.Any())
                        {
                            XrptPagosCreditosFechas rptbol = new XrptPagosCreditosFechas
                            {
                                DataSource = pagCre,
                            };
                            rptbol.ShowPreviewDialog();
                        }
                        else
                            XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
                    } break;
                case 17:
                    {
                        var cre = new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraCreditos
                            .Where(b => (b.FinancieraPagos.OrderByDescending(p => p.Clave).First().FechaPago >= dtpFechaInicial.DateTime.Date && b.FinancieraPagos.OrderByDescending(p => p.Clave).First().FechaPago <= dtpFechaFinal.DateTime.Date) && b.Estado == "Pagado");
                        //var cred = new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraCreditos
                        //    .Where(b => (b.FinancieraPagos.OrderByDescending(p => p.Clave).First().FechaPago >= dtpFechaInicial.DateTime.Date && b.FinancieraPagos.OrderByDescending(p => p.Clave).First().FechaPago <= dtpFechaFinal.DateTime.Date) && b.Estado == "Pagado").Select(c => c.CveGrupo).ToList();

                //        int integrantes =
                //new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraGruposDetalles.Count(
                //    inte => cred.Contains(inte.CveGrupo));

                        if (cre.Any())
                        {XrptCreditosFechasLiquidados rptbol = new XrptCreditosFechasLiquidados(){
                                DataSource = cre,
                                //NumPersonas = { Value = integrantes }
                            };
                            rptbol.ShowPreviewDialog();
                        }
                        else XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
                    } break;
                case 18:
                    {
                        var cre = new EmpeñosDC(new clsConeccionDB().StringConn()).Prestamos
                            .Where(b => (b.PagosFinanciamientos.OrderByDescending(p => p.Clave).First().FechaPago >= dtpFechaInicial.DateTime.Date && b.PagosFinanciamientos.OrderByDescending(p => p.Clave).First().FechaPago <= dtpFechaFinal.DateTime.Date) && b.Estado == "Pagado");
                        //var cred = new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraCreditos
                        //    .Where(b => (b.FinancieraPagos.OrderByDescending(p => p.Clave).First().FechaPago >= dtpFechaInicial.DateTime.Date && b.FinancieraPagos.OrderByDescending(p => p.Clave).First().FechaPago <= dtpFechaFinal.DateTime.Date) && b.Estado == "Pagado").Select(c => c.CveGrupo).ToList();

                        //        int integrantes =
                        //new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraGruposDetalles.Count(
                        //    inte => cred.Contains(inte.CveGrupo));

                        if (cre.Any())
                        {
                            XrptFinanciamientosLiquidados rptbol = new XrptFinanciamientosLiquidados()
                            {
                                DataSource = cre,
                                //NumPersonas = { Value = integrantes }
                            };
                            rptbol.ShowPreviewDialog();
                        }
                        else
                            XtraMessageBox.Show("No Hay Suficientes datos para mostrar el reporte", "Registros 0");
                    } break;
            }
        }
    }
}