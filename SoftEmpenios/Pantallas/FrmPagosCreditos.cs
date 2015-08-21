using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;
using SoftEmpenios.Dialogos;
using SoftEmpenios.LogicaNegocios;

namespace SoftEmpenios.Pantallas
{
    public partial class FrmPagosCreditos : XtraForm, iPantalla
    {
        private EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        private readonly DataTable _dTpagos = new DataTable("Pagos");
        private bool _guardado;
        private string _folios;
        public int cveCredito = 0;
        public FrmPagosCreditos()
        {
            InitializeComponent();
            _dTpagos.Columns.Add("Num", Type.GetType("System.Int32"));
            _dTpagos.Columns.Add("FechaPago", Type.GetType("System.DateTime"));
            _dTpagos.Columns.Add("Pago", Type.GetType("System.Decimal"));
            _dTpagos.Columns.Add("Recargo", Type.GetType("System.Decimal"));
            _dTpagos.Columns.Add("TotalAPagar", Type.GetType("System.Decimal"));
            _dTpagos.Columns.Add("Pagar", Type.GetType("System.Boolean"));
        }

        public void Buscar()
        {
            throw new NotImplementedException();
        }

        public void Eliminar()
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            throw new NotImplementedException();
        }

        public string nombrePantalla { get; private set; }

        private void btnBuscarGrupo_Click(object sender, EventArgs e)
        {
            FrmBuscar buscRef = new FrmBuscar();
            buscRef.CriteriosDeBusqueda("CreditosFinanciera");
            buscRef.DevolverString += CreditoDevuelto;
            buscRef.ShowDialog(this);
            buscRef.DevolverString += CreditoDevuelto;
            buscRef.Close();

        }

        private void CreditoDevuelto(string clave)
        {
            Nuevo();
            FinancieraCredito credito = new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraCreditos.Single(cre => cre.Clave == Convert.ToInt32(clave));
            txtCveCredito.EditValue = credito.Clave;
            dtpFechaCredito.EditValue = credito.FechaModificacion;
            txtPlazo.EditValue = credito.Plazos;
            txtNumPlazos.EditValue = credito.NumeroPlazos;
            dtpFechaInicio.EditValue = credito.FechaInicio;
            dtpFechaFinal.EditValue = credito.FechaFinal;
            txtCantidadCredito.EditValue = credito.Prestamo;
            txtSaldoCredito.EditValue = credito.SaldoActual;
            txtMontoPago.EditValue = credito.Pago;
            txtBase.EditValue = credito.Base;
            txtCveGrupo.EditValue = credito.CveGrupo;
            txtNombreGrupo.EditValue = credito.FinancieraGrupo.Nombre;
            var detgpo = new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraGruposDetalles.Where(det => det.CveGrupo == credito.CveGrupo)
                .Select(det => new {det.FinancieraCliente.Nombre, det.Aprobado, det.Base, det.Tipo});
            txtLetrasRestantes.EditValue = (credito.NumeroPlazos - credito.FinancieraPagos.Count(c=>c.Estado));
            gridIntegrantes.DataSource = detgpo;
            if (credito.Estado == "Pagado" || credito.Estado == "Cancelado")
            {
                MessageBox.Show("Crédito " + credito.Estado, Application.ProductName);
                botonGuardar.Enabled = false;
                return;
            }
            grvIntegrantes.Columns[1].DisplayFormat.FormatType = FormatType.Numeric;
            grvIntegrantes.Columns[1].DisplayFormat.FormatString = "$ #,##0.00";
            grvIntegrantes.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
            grvIntegrantes.Columns[2].DisplayFormat.FormatString = "$ #,##0.00";

            CalcularPago(credito.FinancieraPagos.Count(c => c.Estado));
            gridPagos.DataSource = _dTpagos;
            grvPagos.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            grvPagos.Columns[1].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            grvPagos.Columns[1].DisplayFormat.FormatType = FormatType.DateTime;
            grvPagos.Columns[1].DisplayFormat.FormatString = "dd-MMM-yyyy";
            grvPagos.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
            grvPagos.Columns[2].DisplayFormat.FormatString = "$ #,##0.00";
            grvPagos.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
            grvPagos.Columns[3].DisplayFormat.FormatString = "$ #,##0.00";
            grvPagos.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
            grvPagos.Columns[4].DisplayFormat.FormatString = "$ #,##0.00";
            grvPagos.Columns[0].Width = 50;
            grvPagos.Columns["Pagar"].BestFit();
            grvPagos.Columns[0].OptionsColumn.AllowEdit = false;
            grvPagos.Columns[1].OptionsColumn.AllowEdit = false;
            grvPagos.Columns[2].OptionsColumn.AllowEdit = false;
            grvPagos.Columns[3].OptionsColumn.AllowEdit = false;
            grvPagos.Columns[4].OptionsColumn.AllowEdit = false;
        }

        private DateTime fechaLimite;

        private void CalcularPago(int pagos)
        {
            try
            {
                int plazos = 0;
                DateTime ultFchPago = dtpFechaInicio.DateTime.Date;
                int prorroga = _entidades.Financiamientos.Single(fin => fin.Tipo == "Grupal").Prorroga;
                decimal porcRecargo = _entidades.Financiamientos.Single(fin => fin.Tipo == "Grupal").Recargo;
                switch (txtPlazo.Text)
                {
                    case "SEMANAL":
                        ultFchPago = dtpFechaInicio.DateTime.AddDays(pagos*7);
                        plazos = 7;
                        break;
                    case "QUINCENAL":
                        ultFchPago = dtpFechaInicio.DateTime.AddDays(pagos*14);
                        plazos = 14;
                        break;
                    case "MENSUAL":
                        ultFchPago = dtpFechaInicio.DateTime.AddMonths(pagos);
                        plazos = 1;
                        break;
                }
                _dTpagos.Rows.Clear();
                DateTime fechaActual = DateTime.Now.Date;
                fechaLimite = obtenerFechaLimite(ultFchPago, plazos);
                if (fechaLimite == fechaActual) //Al dia
                {
                    decimal pago = Convert.ToDecimal(txtMontoPago.EditValue);
                    if (pagos + 1 == Convert.ToInt32(txtNumPlazos.EditValue))
                        pago = Convert.ToDecimal(txtSaldoCredito.EditValue);
                    _dTpagos.Rows.Add(new object[]
                    {
                        pagos + 1, fechaLimite, pago, 0,
                        pago, true
                    });
                }
                else
                {
                    if (fechaLimite > fechaActual) //no recargo ni x ora ni x fecha
                    {
                        decimal pago = Convert.ToDecimal(txtMontoPago.EditValue);
                        if (pagos + 1 == Convert.ToInt32(txtNumPlazos.EditValue))
                            pago = Convert.ToDecimal(txtSaldoCredito.EditValue);
                        _dTpagos.Rows.Add(new object[]
                        {
                            pagos + 1, fechaLimite, pago, 0,
                            pago, true
                        });
                    }
                    else
                    {
                        decimal pagoPuntual = decimal.Round(Convert.ToDecimal(txtMontoPago.EditValue), 1);
                        decimal recargo = decimal.Round(
                            (pagoPuntual * Convert.ToDecimal(porcRecargo)), 1);
                        while (fechaLimite.AddDays(prorroga) < fechaActual && fechaLimite <= dtpFechaFinal.DateTime.Date)
                        //pagos atrasados ----- 10 < 29
                        {
                            //decimal pago = Convert.ToDecimal(txtMontoPago.EditValue);
                            if (pagos + 1 == Convert.ToInt32(txtNumPlazos.EditValue))
                            {
                                pagoPuntual = (_dTpagos.Rows.Count > 1)
                                    ? Convert.ToDecimal(txtSaldoCredito.EditValue)-_dTpagos.Rows.Cast<DataRow>()
                                        .Aggregate<DataRow, decimal>(0,
                                        (current, row) => current + (decimal) row["Pago"]): Convert.ToDecimal(txtSaldoCredito.EditValue)
                                    ;
                            }
                            _dTpagos.Rows.Add(new object[] { pagos + 1, fechaLimite, pagoPuntual, recargo, pagoPuntual + recargo, true });
                            fechaLimite = obtenerFechaLimite(fechaLimite, plazos);
                            pagos++;
                            if (pagos == Convert.ToInt32(txtNumPlazos.EditValue))
                            {
                                SacarTotalPago();
                                return;
                            }
                        }
                        //pago actual
                        if (fechaLimite.AddDays(prorroga) < fechaActual && fechaLimite <= dtpFechaFinal.DateTime.Date)
                        {
                            if (pagos + 1 == Convert.ToInt32(txtNumPlazos.EditValue))
                            {
                                pagoPuntual = (_dTpagos.Rows.Count > 1)
                                    ? Convert.ToDecimal(txtSaldoCredito.EditValue) - _dTpagos.Rows.Cast<DataRow>()
                                        .Aggregate<DataRow, decimal>(0,
                                        (current, row) => current + (decimal)row["Pago"]) : Convert.ToDecimal(txtSaldoCredito.EditValue)
                                    ;
                            }
                            _dTpagos.Rows.Add(new object[] { pagos + 1, fechaLimite, pagoPuntual, recargo, pagoPuntual + recargo, true });
                        }
                        else
                        {
                            if (pagos + 1 == Convert.ToInt32(txtNumPlazos.EditValue))
                            {
                                pagoPuntual = (_dTpagos.Rows.Count > 1)
                                    ? Convert.ToDecimal(txtSaldoCredito.EditValue) - _dTpagos.Rows.Cast<DataRow>()
                                        .Aggregate<DataRow, decimal>(0,
                                        (current, row) => current + (decimal)row["Pago"]) : Convert.ToDecimal(txtSaldoCredito.EditValue)
                                    ;
                            }
                            _dTpagos.Rows.Add(new object[]
                            {
                                pagos + 1, fechaLimite, pagoPuntual, 0,
                                pagoPuntual, true
                            });
                        }
                    }
                }
                SacarTotalPago();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private int mes = 0;

        private DateTime obtenerFechaLimite(DateTime fechaUltima, int plazo)
        {
            DateTime fechaProximoPago = DateTime.Now;
            if (plazo == 7) //plazo son de 7 dias
            {
                fechaProximoPago = fechaUltima.AddDays(plazo);
            }
            else
            {
                if (plazo == 14) //plazo son de 15 dias
                {

                    //if (fechaUltima.Month != 2 || fechaUltima.Day == 28) //dif a febrero
                    //{
                    //    if (fechaUltima.Month == 2)
                    //    {
                    //        fechaUltima = fechaUltima.AddDays(1);
                    //    }
                    //    if (fechaUltima.Day == 30)
                    //    {
                    //        mes = fechaUltima.Month + 1;
                    //        fechaUltima = Convert.ToDateTime("01/" + mes + "/" + fechaUltima.Year);
                    //    }
                    //    if (fechaUltima.Day >= plazo) //mas de 15 dias
                    //    {
                    //        fechaProximoPago = Convert.ToDateTime("30/" + fechaUltima.Month + "/" + fechaUltima.Year);
                    //    }
                    //    else
                    //    {
                    //        if (fechaUltima.Day < plazo) //febrero menos de 15 dias
                    //        {
                    //            fechaProximoPago = Convert.ToDateTime("15/" + fechaUltima.Month + "/" + fechaUltima.Year);
                    //        }
                    //    }
                    fechaProximoPago = fechaUltima.AddDays(14);
                //}
                //    else
                //    {
                //        if (fechaUltima.Month == 2 && fechaUltima.Day >= plazo) //febrero con mas de 15 dias
                //        {
                //            fechaProximoPago = Convert.ToDateTime("28/02/" + DateTime.Now.Year);
                //        }
                //        else
                //        {
                //            if (fechaUltima.Month == 2 && fechaUltima.Day < plazo) //febrero menos de 15 dias
                //            {
                //                fechaProximoPago = Convert.ToDateTime("15/02/" + DateTime.Now.Year);
                //            }
                //        }
                //    }
                }
                else
                {
                    if (plazo == 1)
                    {
                        //fechaProximoPago = fechaUltimoPago.AddMonths(1);
                        fechaProximoPago = fechaUltima.AddMonths(1);
                    }
                }
            }
            return fechaProximoPago;
        }

        private void grvPagos_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int ultimRow = grvPagos.RowCount - 1;
            int activecelda = grvPagos.GetFocusedDataSourceRowIndex();
            if (Convert.ToBoolean(_dTpagos.Rows[activecelda][5]))
            {
                while (activecelda >= 1)
                {
                    _dTpagos.Rows[activecelda - 1][5] = true;
                    activecelda--;
                }

            }
            if (activecelda != ultimRow)
            {
                if (Convert.ToBoolean(_dTpagos.Rows[activecelda + 1][5]))
                {
                    _dTpagos.Rows[activecelda][5] = true;
                }
            }

            SacarTotalPago();
        }

        private void grvPagos_CellValueChanging(object sender,
            DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

        private void SacarTotalPago()
        {

            decimal pagos = 0;
            decimal recargo = 0;

            foreach (DataRow fila in from DataRow pago in _dTpagos.Rows
                where (bool) pago["Pagar"]
                select pago)
            {
                pagos += (decimal) fila[2];

                recargo += (decimal) fila[3];
            }
            //for (int i = 0; i < _dtCalendario.Rows.Count; i++)
            //{
            //    cantidad += (decimal)_dtCalendario.Rows[i][4];
            //    interes += (decimal)_dtCalendario.Rows[i][5];
            //    recargos += (decimal)_dtCalendario.Rows[i][6];
            //}
            txtMesesPagar.EditValue = _dTpagos.Rows.Cast<DataRow>().Count(fila => (bool) fila["Pagar"]);
            ;
            txtCantidadPago.EditValue = pagos;
            txtTotalRecargo.EditValue = recargo;
            txtTotalAPagar.EditValue = (pagos + recargo);


        }

        private void grvPagos_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle == 0)

                e.Cancel = true;
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            if ((decimal) txtTotalAPagar.EditValue <= 0) return;
            if (!ClsVerificarCaja.CajaEstado())
            {
                MessageBox.Show("La Caja del Dia de hoy ya se ha cerrado\n SISTEMA BLOQUEADO", "Caja Cerrada",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (!_guardado)
            {
                if ((int) txtCveCredito.EditValue == 0)
                {
                    MessageBox.Show("Busque Primero el financiamiento para poder cobrar", Application.ProductName);
                    return;
                }
                decimal totalcantidad = 0;
                if (_dTpagos.Rows.Count > 0)
                {
                    //if para saber si va a cobrar pagos de interes y moratorios
                    for (int i = 0; i < _dTpagos.Rows.Count; i++)
                    {

                        if ((bool) _dTpagos.Rows[i]["Pagar"] == false) continue;
                        FinancieraPago pagFin = new FinancieraPago()
                        {
                            FechaPago = dtpFechaPago.DateTime.Date,
                            CveCredito = Convert.ToInt32(txtCveCredito.EditValue),
                            Pago = (decimal) _dTpagos.Rows[i]["Pago"],
                            Recargo = (decimal) _dTpagos.Rows[i]["Recargo"],
                            TotalPago = Convert.ToDecimal(_dTpagos.Rows[i]["TotalAPagar"]),
                            CveUsuario =
                                Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IdUsuarioApp")),
                            Estado = true
                        };


                        totalcantidad += (decimal) _dTpagos.Rows[i]["Pago"];
                        _entidades.FinancieraPagos.InsertOnSubmit(pagFin);
                        _entidades.SubmitChanges();
                        ActualizarCredito(pagFin.Pago);
                        
                        _folios += pagFin.Clave + "; ";
                        _guardado = true;
                    }
                    FinancieraCredito credito =
                    _entidades.FinancieraCreditos.Single(c => c.Clave == Convert.ToInt32(txtCveCredito.EditValue));
                    txtLetrasRestantes.EditValue = credito.NumeroPlazos - credito.FinancieraPagos.Count(c => c.Estado);
                }

                new ManejadorControles().DesectivarTextBox(gpoContenedor, true);
                MessageBox.Show("Pagos Registrado", Application.ProductName);
                // ModificarSaldoFinanciamiento(_cveFinanciamiento, (totalcantidad + Convert.ToDecimal(txtAbonoCapital.EditValue)));
                ImprimirTicketPago();
            }
            else
            {
                ImprimirTicketPago();
            }
            SendKeys.Send("{TAB}");

        }

        private void ActualizarCredito(decimal pago)
        {
            //_entidades=new EmpeñosDC(new clsConeccionDB().StringConn());
            FinancieraCredito credito =
                    _entidades.FinancieraCreditos.Single(c => c.Clave == Convert.ToInt32(txtCveCredito.EditValue));
            credito.SaldoActual = credito.SaldoActual - pago;
            //_entidades.SubmitChanges();
            
            if (credito.SaldoActual == 0)
            {
                credito.Estado = "Pagado";
                //_entidades.SubmitChanges();
                ImprimirRetiroBase();
                FinancieraGrupo grupo = _entidades.FinancieraGrupos.Single(c => c.Clave == Convert.ToInt32(txtCveGrupo.EditValue));
                grupo.Estado = "INACTIVO";
                foreach (FinancieraGruposDetalle integrantes in grupo.FinancieraGruposDetalles)
                {
                    integrantes.Aprobado = 0;
                    integrantes.Base = 0;
                }
                //_entidades.SubmitChanges();
                
            }
            _entidades.SubmitChanges();
        }

        private void ImprimirRetiroBase()
        {
            Transaccione tran = new Transaccione
            {
                CveUsuario = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioAPP")),
                FechaTransaccion = DateTime.Today.Date,
                TipoTransaccion = "Retiro",
                Cantidad = Convert.ToDecimal(txtBase.EditValue),
                Concepto = string.Format("RETIRO DE BASE DEL GRUPO {0}-{1} POR SALDAR CRÉDITO", txtCveGrupo.Text, txtNombreGrupo.Text),
                Estado = true
            };
            EmpeñosDC _enti=new EmpeñosDC(new clsConeccionDB().StringConn());
            _enti.Transacciones.InsertOnSubmit(tran);
            _enti.SubmitChanges();
            //new LogicaTransacciones().AgregarTransaccion(tran);//se comento 4/6/2014 por que usuario normal no tiene permiso de los retiros
            Configuracione empre = new EmpeñosDC(new clsConeccionDB().StringConn()).Configuraciones.First();

            string empresa = new clsModificarConfiguracion().configGetValue("Empresa");
            string razonSocial = new clsModificarConfiguracion().configGetValue("RazonSocial");
            string rfc = new clsModificarConfiguracion().configGetValue("RFC");
            string curp = new clsModificarConfiguracion().configGetValue("CURP");
            string dirc = String.Format("{0} CP {1} {2}", empre.Direccion, empre.CodigoPostal, empre.Municipio);

            int padRe = ((40 - empresa.Length) / 2) + empresa.Length;
            int padRrs = ((40 - razonSocial.Length) / 2) + razonSocial.Length;
            int padRrfc = ((40 - rfc.Length) / 2) + rfc.Length;
            int padRcurp = ((40 - curp.Length) / 2) + curp.Length;


            Ticket ticket = new Ticket(2);
            ticket.AddHeaderLine("            CASA  DE  EMPEÑOS           ");
            ticket.AddHeaderLine("                                        ");
            ticket.AddHeaderLine(empresa.PadLeft(padRe));
            ticket.AddHeaderLine(razonSocial.PadLeft(padRrs));
            ticket.AddHeaderLine(rfc.PadLeft(padRrfc));
            ticket.AddHeaderLine(curp.PadLeft(padRcurp));
            if (dirc.Length > 40)
            {
                int currentChar = 0;
                int itemLenght = dirc.Length;

                while (itemLenght > 40)
                {
                    ticket.AddHeaderLine(dirc.Substring(currentChar, 40));
                    currentChar += 40;
                    itemLenght -= 40;
                }
                ticket.AddHeaderLine(dirc.Substring(currentChar));

            }
            else
            {
                ticket.AddHeaderLine(dirc);
            }
            ticket.AddHeaderLine("           TICKET DE RETIRO");

            ticket.AddSubHeaderLine("CLAVE: " + tran.Clave);
            ticket.AddSubHeaderLine("REALIZO: " + new clsModificarConfiguracion().configGetValue("UsuarioAPP"));
            ticket.AddSubHeaderLine(String.Format("FECHA: {0} {1}", DateTime.Today.ToString("dd/MMM/yyyy").ToUpper(), DateTime.Now.ToShortTimeString()));
            string[] lineas =tran.Concepto.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var linea in lineas)
            {
                ticket.AddItem("", linea, "");
            }
            //ticket.AddItem("", txtConcepto.Text, "");
            ticket.AddTotal("CANTIDAD:",tran.Cantidad.ToString("$ #,##0.00"));
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("________________________________________");
            ticket.AddFooterLine("                AUTORIZO                ");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");

            ticket.PrintTicket(new clsModificarConfiguracion().configGetValue("ImpresoraTickets"));
        }

        private void ImprimirTicketPago()
        {

            //mapeoVentas.Connection.ConnectionString = new clsConeccionDB().StringConn();
            Configuracione empre = (from em in new EmpeñosDC(new clsConeccionDB().StringConn()).Configuraciones
                select em).FirstOrDefault();

            string empresa = new clsModificarConfiguracion().configGetValue("Empresa");
            string razonSocial = new clsModificarConfiguracion().configGetValue("RazonSocial");
            string rfc = new clsModificarConfiguracion().configGetValue("RFC");
            string curp = new clsModificarConfiguracion().configGetValue("CURP");
            if (empre != null)
            {
                string dirc = String.Format("{0} CP {1}", empre.Direccion, empre.CodigoPostal);
                    //new clsModificarConfiguracion().configGetValue("Direccion");
                //string mun = String.Format("C.P: {0} {1}", conf.Single().CodigoPostal, conf.Single().Municipio);
                int padRe = ((40 - empresa.Length)/2) + empresa.Length;
                int padRrs = ((40 - razonSocial.Length)/2) + razonSocial.Length;
                int padRrfc = ((40 - rfc.Length)/2) + rfc.Length;
                int padRcurp = ((40 - curp.Length)/2) + curp.Length;
                //int padRE = ((40 - empresa.Length) / 2) + empresa.Length;

                Ticket ticket = new Ticket(4);
                ticket.AddHeaderLine("            CASA  DE  EMPEÑOS           ");
                ticket.AddHeaderLine("                                        ");
                ticket.AddHeaderLine(empresa.PadLeft(padRe));
                ticket.AddHeaderLine(razonSocial.PadLeft(padRrs));
                ticket.AddHeaderLine(rfc.PadLeft(padRrfc));
                ticket.AddHeaderLine(curp.PadLeft(padRcurp));
                if (dirc.Length > 40)
                {
                    int currentChar = 0;
                    int itemLenght = dirc.Length;

                    while (itemLenght > 40)
                    {
                        ticket.AddHeaderLine(dirc.Substring(currentChar, 40));
                        currentChar += 40;
                        itemLenght -= 40;
                    }
                    ticket.AddHeaderLine(dirc.Substring(currentChar));

                }
                else
                {
                    ticket.AddHeaderLine(dirc);
                }
                ticket.AddHeaderLine(empre.Municipio);
                ticket.AddHeaderLine("         TICKET DE PAGO GRUPAL          ");


                ticket.AddSubHeaderLine("CLAVES PAGO: " + _folios);
                ticket.AddSubHeaderLine("CLAVE CRÉDITO: # " + txtCveCredito.Text);
                if (_entidades != null)
                {
                    Usuario usu =
                        _entidades.Usuarios.FirstOrDefault(
                            u =>
                                u.CveUsuario ==
                                Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioApp")));
                    if (usu != null) ticket.AddSubHeaderLine("ATENDIO: " + usu.Nombre);
                }
                ticket.AddSubHeaderLine("GRUPO: " + txtNombreGrupo.Text);
                //    FinancieraCredito fina =
                //    new EmpeñosDC(new clsConeccionDB().StringConn()).FinancieraCreditos.FirstOrDefault(
                //        p => p.Clave == Convert.ToInt32(txtCveCredito.EditValue));
                //int pagos = fina.NumeroPlazos - fina.FinancieraPagos.Count;
                ticket.AddTotal("LETRAS VIGENTES: ", txtLetrasRestantes.Text);
                //ticket.AddSubHeaderLine("SALDO ANTERIOR: " +
                                     //   double.Parse(txtSaldoCredito.EditValue.ToString()).ToString("C"));

                ticket.AddSubHeaderLine(String.Format("FECHA: {0} {1}", DateTime.Today.ToString("dd/MMM/yyyy").ToUpper(),
                    DateTime.Now.ToShortTimeString()));

                for (int x = 0; x < _dTpagos.Rows.Count; x++)
                {
                    if ((bool) _dTpagos.Rows[x]["Pagar"] == false) continue;
                    ticket.AddItem(_dTpagos.Rows[x][0].ToString(),"        "+
                        Convert.ToDateTime(_dTpagos.Rows[x][1]).ToString("dd/MMM/yy").ToUpper(),
                        double.Parse(_dTpagos.Rows[x][2].ToString()).ToString("C"));
                        //; gridProductos.Rows[x].Cells[0].Value.ToString(), gridProductos.Rows[x].Cells[0].Value.ToString(), gridProductos.Rows[x].Cells[0].Value.ToString());
                }
                
                ticket.AddTotal("# PAGOS: ", txtMesesPagar.EditValue.ToString());
                ticket.AddTotal("CANTIDAD: ", decimal.Parse(txtCantidadPago.EditValue.ToString()).ToString("C"));
                ticket.AddTotal("RECARGO: ", decimal.Parse(txtTotalRecargo.EditValue.ToString()).ToString("C"));
                ticket.AddTotal("TOTAL PAGO: ", decimal.Parse(txtTotalAPagar.EditValue.ToString()).ToString("C"));
                

                //if (fina != null) ticket.AddTotal("SALDO ACTUAL: ", fina.SaldoActual.ToString("C"));

                ticket.AddFooterLine("          GRACIAS POR SU PAGO            ");
                ticket.AddFooterLine("");
                ticket.AddFooterLine("");
                ticket.AddFooterLine("");
                ticket.AddFooterLine("");
                ticket.PrintTicket(new clsModificarConfiguracion().configGetValue("ImpresoraTickets"));
            }
        }

        private void botonNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }
        public void Nuevo()
        {
            _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
            _guardado = false;
            _dTpagos.Rows.Clear();
            _folios = "";

            dtpFechaCredito.DateTime = DateTime.Today.Date;
            gridIntegrantes.DataSource = null;

            new ManejadorControles().LimpiarControles(gpoContenedor);
            //_cveFinanciamiento = 0;
            //txtNombre.Focus();
            dtpFechaPago.EditValue = DateTime.Today.Date;
            botonGuardar.Enabled = true;
            gridPagos.DataSource = _dTpagos;
        }

        private void FrmPagosCreditos_Shown(object sender, EventArgs e)
        {
            Nuevo();
            if (cveCredito > 0)
            {
                CreditoDevuelto(cveCredito.ToString());
            }
        }

        private void gpoContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnImprimirHistorico_Click(object sender, EventArgs e)
        {
            var pagos = from p in _entidades.FinancieraPagos
                        where p.CveCredito == Convert.ToInt32(txtCveCredito.EditValue) && p.Estado
                        select new { p.Clave,  p.Pago, p.Recargo,  p.TotalPago, p.FechaPago, Registró = p.Usuario.Nombre };
            if (pagos.Any())
            {
                DataTable dtPagos = new LinqToDataTable().ObtenerDataTable2(pagos);
                if (dtPagos.Rows.Count == 0)
                {
                    MessageBox.Show("Crédito sin pagos Previos", Application.ProductName);
                    return;
                }

                FrmCronograma cro = new FrmCronograma {Tipo = "PagosFinanciera", DtCronos = dtPagos};
                cro.ShowDialog(this);
            }
        }
    }
}
