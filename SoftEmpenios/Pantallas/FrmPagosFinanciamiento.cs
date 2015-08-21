using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using SoftEmpenios.Dialogos;
using SoftEmpenios.DBComun;
using SoftEmpenios.Clases;
using DevExpress.Utils;

namespace SoftEmpenios.Pantallas
{
    public partial class FrmPagosFinanciamiento : Form, iPantalla
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        readonly DataTable _dtCalendario = new DataTable();
        decimal _porcInteres;
        decimal _porcRecargo;
        int _diasProrroga;
        int _cveFinanciamiento;
        private string _folios;
        private bool _guardado;
        public int cveFin = 0;
        public FrmPagosFinanciamiento()
        {
            InitializeComponent();
            _dtCalendario.Columns.Add("Num", Type.GetType("System.Int32"));
            _dtCalendario.Columns.Add("FechaInicial", Type.GetType("System.DateTime"));
            _dtCalendario.Columns.Add("FechaFinal", Type.GetType("System.DateTime"));
            _dtCalendario.Columns.Add("Balance", Type.GetType("System.Decimal"));
            _dtCalendario.Columns.Add("Cantidad", Type.GetType("System.Decimal"));
            _dtCalendario.Columns.Add("Interes", Type.GetType("System.Decimal"));
            _dtCalendario.Columns.Add("Recargo", Type.GetType("System.Decimal"));
            _dtCalendario.Columns.Add("TotalAPagar", Type.GetType("System.Decimal"));
            _dtCalendario.Columns.Add("Pagar", Type.GetType("System.Boolean"));
        }

        #region de comando de Herencia
        public bool ConfirmarCierre()
        {
            switch (MessageBox.Show("\x00bfHa realizado cambios sin Guardar?. \x00bfDesea guardarlas?", "Muebleria", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                case DialogResult.Yes:
                    Guardar();
                    return true;

                case DialogResult.No:
                    return true;
            }
            return false;
        }

        public void Refrescar()
        {
        }
        public void Buscar()
        {

        }
        public void Eliminar()
        {
        }
        public void Guardar()
        {
        }
        public void Nuevo()
        {
            _guardado = false;
            _dtCalendario.Rows.Clear();
            _folios = "";
            dtpFechaFinanciamiento.DateTime = DateTime.Today.Date;


            new ManejadorControles().LimpiarControles(gpoContenedor);
            _cveFinanciamiento = 0;
            txtNombre.Focus();
            dtpFechaPago.EditValue = DateTime.Today.Date;
            botonGuardar.Enabled = true;
            gridPagos.DataSource = _dtCalendario;
        }
        public void Paginar(int primerRegistro)
        {
            //throw new NotImplementedException();
        }
        public string nombrePantalla
        {
            get
            {
                return "Financiamientos";
            }
        }

        #endregion
        private void btnBuscarPrestamo_Click(object sender, EventArgs e)
        {
            Nuevo();
            FrmBuscar busPres = new FrmBuscar();
            busPres.CriteriosDeBusqueda("Financiamientos");
            busPres.DevolverString += PrestamoDevuelto;
            busPres.ShowDialog(this);
            busPres.DevolverString -= PrestamoDevuelto;
            busPres.Close();
        }

        private void PrestamoDevuelto(string clave)
        {
            Nuevo();
            _cveFinanciamiento = Convert.ToInt32(clave);
            Prestamo pres = _entidades.Prestamos.FirstOrDefault(p => p.Clave == Convert.ToDecimal(clave));
            if (pres == null) return;
            dtpFechaFinanciamiento.EditValue = pres.FechaPrestamo;
            txtFolioFinanciamiento.EditValue = pres.FolioFinanciamiento;
            txtTipoFinanciamiento.EditValue = pres.Tipo;
            txtCantidadFinancimiento.EditValue = pres.Cantidad;
            txtEnganche.EditValue = pres.Enganche;
            txtSaldoActual.EditValue = pres.Saldo;
            txtCveCliente.EditValue = pres.Cliente.CveCliente;
            txtNombre.EditValue = pres.Cliente.Nombre;
            txtDireccion.EditValue = pres.Cliente.Direccion;
            txtPoblacion.EditValue = pres.Cliente.Poblacion;
            txtTelefono.EditValue = pres.Cliente.Telefono;
            txtCelular.EditValue = pres.Cliente.Celular;
            txtMesesFinaniciamiento.EditValue = pres.Meses;
            txtObservación.EditValue = pres.Observacion;
            txtPorcInteres.EditValue = pres.Interes;
            txtPorcRecargo.EditValue = pres.Financiamiento.Recargo;
            txtPorcEnganche.EditValue = pres.Financiamiento.Enganche ?? 0M;
            txtProrroga.EditValue = pres.Financiamiento.Prorroga;


            decimal totalPago = (from p in _entidades.PagosFinanciamientos
                                 where p.CvePrestamo == _cveFinanciamiento && p.Estado
                                 select (decimal?)p.Cantidad).Sum() ?? 0;
            decimal totalAbono = (from p in _entidades.PagosFinanciamientos
                                  where p.CvePrestamo == _cveFinanciamiento && p.Estado
                                  select (decimal?)p.AbonoPrestamo).Sum() ?? 0;
            int numPagos = (from p in _entidades.PagosFinanciamientos
                            where p.CvePrestamo == _cveFinanciamiento && p.Estado
                            select p).Count();

            txtTotalPagado.EditValue = totalPago + totalAbono;
            if (pres.Estado == "Pagado" || pres.Estado == "Cancelado")
            {
                MessageBox.Show("Financiamiento " + pres.Estado, Application.ProductName);
                botonGuardar.Enabled = false;
                return;
            }
            _porcInteres = pres.Interes;
            _porcRecargo = pres.Financiamiento.Recargo;
            _diasProrroga = (from pro in _entidades.Financiamientos
                             where pro.Clave == pres.CveTipoFinancimiento
                             select pro.Prorroga).Sum();
            decimal pagoMensual = (pres.Cantidad - pres.Enganche) / pres.Meses;
            switch (pres.Tipo)
            {
                case "Hipotecario":
                case "Personal":
                    SacarPagoHipotecario(pres.FechaPrestamo.AddMonths(numPagos).Date, decimal.Round(pagoMensual, 2), pres.Saldo, numPagos);
                    break;
                case "AutoFinanciamiento":
                case "MotoFinanciamiento":
                case "Personal Fijo":
                    SacarPagoAutofinanciamiento(pres.FechaPrestamo.AddMonths(numPagos).Date, decimal.Round(pagoMensual, 2), pres.Saldo, numPagos);
                    break;
            }

        }

        private void SacarPagoHipotecario(DateTime fechaSaldada, decimal pagoMensual, decimal saldo, int numPagos)
        {
            //DateTime fechaSaldada1 = dtpFechaFinanciamiento.DateTime.AddMonths(numPagos);
            _dtCalendario.Rows.Clear();
            if (fechaSaldada.Date.AddDays(Convert.ToInt32(txtProrroga.EditValue)) > DateTime.Today.Date)
            {
                if (chkSaldarFinanciamiento.Checked)
                {
                    _dtCalendario.Rows.Add(new object[] { numPagos + 1, fechaSaldada.AddMonths(-1).Date, fechaSaldada.Date, saldo, 0, 0, 0, saldo, true });
                    txtAbonoCapital.EditValue = saldo;
                }
                else if (saldo <= pagoMensual || (numPagos + 1) == Convert.ToInt32(txtMesesFinaniciamiento.EditValue))
                {
                    _dtCalendario.Rows.Add(new object[] { numPagos + 1, fechaSaldada.Date, fechaSaldada.AddMonths(1).Date, saldo, saldo, 0, 0, saldo, true });

                }
                else
                {
                    decimal balance = saldo;
                    decimal inte = decimal.Round(balance * Convert.ToDecimal(_porcInteres), 2);
                    _dtCalendario.Rows.Add(new object[] { numPagos + 1, fechaSaldada.Date, fechaSaldada.Date.AddMonths(1).Date, balance, pagoMensual, inte, 0, pagoMensual + inte, true });
                }
                gridPagos.DataSource = _dtCalendario;
                FormatoGrid();
                SacarTotalPago();
                return;

            }
            int mesesaPagar = 0;
            do
            {

                if (_dtCalendario.Rows.Count == 0)
                {
                    decimal recargo = 0;
                    decimal interes = decimal.Round(Convert.ToDecimal(saldo) * Convert.ToDecimal(_porcInteres), 2);
                    if (fechaSaldada.Date.AddMonths(1).AddDays(_diasProrroga) < DateTime.Today)
                    {
                        recargo = decimal.Round(saldo * _porcRecargo, 2);
                    }
                    if (saldo <= pagoMensual || (numPagos + 1) == Convert.ToInt32(txtMesesFinaniciamiento.EditValue))
                    {
                        _dtCalendario.Rows.Add(new object[] { numPagos + 1, fechaSaldada.Date, fechaSaldada.AddMonths(1).Date, saldo, saldo, interes, recargo, saldo + interes + recargo, true });
                        break;
                    }
                    _dtCalendario.Rows.Add(new object[]
                    {
                        numPagos + 1, fechaSaldada.Date, fechaSaldada.Date.AddMonths(1), saldo, pagoMensual,
                        interes, recargo, pagoMensual+interes+recargo,true
                    });
                }
                else
                {
                    decimal balance = (decimal)_dtCalendario.Rows[_dtCalendario.Rows.Count - 1]["Balance"] -
                                      pagoMensual;
                    DateTime fchSal = Convert.ToDateTime(_dtCalendario.Rows[_dtCalendario.Rows.Count - 1]["FechaFinal"]);
                    decimal recargo = 0;
                    decimal interes = decimal.Round(balance * Convert.ToDecimal(_porcInteres), 2);
                    if (fchSal.AddMonths(1).AddDays(_diasProrroga) < DateTime.Today)
                    {
                        recargo = decimal.Round(balance * _porcRecargo, 2);
                    }
                    if (balance == 0) break;
                    if (balance <= pagoMensual || (numPagos + 1) == Convert.ToInt32(txtMesesFinaniciamiento.EditValue))
                    {
                        _dtCalendario.Rows.Add(new object[] { numPagos + 1 + mesesaPagar, fchSal, fchSal.AddMonths(1), balance, balance, interes, recargo, balance + interes + recargo, true });
                        break;
                    }_dtCalendario.Rows.Add(new object[]
                    {
                         numPagos + mesesaPagar+1, fchSal, fchSal.AddMonths(1), balance, pagoMensual,interes, recargo,
                         pagoMensual+interes+recargo,true
                    });

                }
                //fechaSaldada = fechaSaldada.Date.AddMonths(1);
                mesesaPagar++;
            } while (fechaSaldada.AddMonths(mesesaPagar).AddDays(_diasProrroga).Date < DateTime.Today.Date);
            if (chkSaldarFinanciamiento.Checked)
                txtAbonoCapital.EditValue = Convert.ToDecimal(txtSaldoActual.EditValue) - _dtCalendario.Rows.Cast<DataRow>().Aggregate<DataRow, decimal>(0M, (current, row) => current + (decimal)row["Cantidad"]);
            SacarTotalPago();
            FormatoGrid();
            return;

        }

        private void SacarTotalPago()
        {

            decimal cantidad = 0;
            decimal interes = 0;
            decimal recargos = 0;

            foreach (DataRow fila in from DataRow pago in _dtCalendario.Rows
                                     where (bool)pago["Pagar"]
                                     select pago)
            {
                cantidad += (decimal)fila[4];
                interes += (decimal)fila[5];
                recargos += (decimal)fila[6];
            }
            //for (int i = 0; i < _dtCalendario.Rows.Count; i++)
            //{
            //    cantidad += (decimal)_dtCalendario.Rows[i][4];
            //    interes += (decimal)_dtCalendario.Rows[i][5];
            //    recargos += (decimal)_dtCalendario.Rows[i][6];
            //}
            txtMesesPagar.EditValue = _dtCalendario.Rows.Cast<DataRow>().Count(fila => (bool)fila["Pagar"]); ;
            txtCantidadPago.EditValue = cantidad + interes;
            txtTotalRecargo.EditValue = recargos;
            txtTotalAPagar.EditValue = (cantidad + recargos + interes) + Convert.ToDecimal(txtAbonoCapital.EditValue);


        }
        void FormatoGrid()
        {
            grvPagos.Columns[0].Width = 50;
            grvPagos.Columns["Pagar"].BestFit();
            //gridView1.Columns[1].Visible = false;
            //gridView1.Columns[2].Visible = false;
            grvPagos.Columns[1].DisplayFormat.FormatType = FormatType.DateTime;
            grvPagos.Columns[1].DisplayFormat.FormatString = "dd-MMM-yyyy";
            grvPagos.Columns[2].DisplayFormat.FormatType = FormatType.DateTime;
            grvPagos.Columns[2].DisplayFormat.FormatString = "dd-MMM-yyyy";
            grvPagos.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            grvPagos.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
            grvPagos.Columns[3].DisplayFormat.FormatString = "$ #,##0.00";
            grvPagos.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
            grvPagos.Columns[4].DisplayFormat.FormatString = "$ #,##0.00";
            grvPagos.Columns[5].DisplayFormat.FormatType = FormatType.Numeric;
            grvPagos.Columns[5].DisplayFormat.FormatString = "$ #,##0.00";
            grvPagos.Columns[6].DisplayFormat.FormatType = FormatType.Numeric;
            grvPagos.Columns[6].DisplayFormat.FormatString = "$ #,##0.00";
            grvPagos.Columns[7].DisplayFormat.FormatType = FormatType.Numeric;
            grvPagos.Columns[7].DisplayFormat.FormatString = "$ #,##0.00";
            grvPagos.Columns[0].OptionsColumn.AllowEdit = false;
            grvPagos.Columns[1].OptionsColumn.AllowEdit = false;
            grvPagos.Columns[2].OptionsColumn.AllowEdit = false;
            grvPagos.Columns[3].OptionsColumn.AllowEdit = false;
            grvPagos.Columns[4].OptionsColumn.AllowEdit = false;
            grvPagos.Columns[5].OptionsColumn.AllowEdit = false;
            grvPagos.Columns[6].OptionsColumn.AllowEdit = false;
            grvPagos.Columns[7].OptionsColumn.AllowEdit = false;
        }
        private void SacarPagoAutofinanciamiento(DateTime fechaSaldada, decimal pagoMensual, decimal saldo, int numPagos)
        {
            _dtCalendario.Rows.Clear();
            if (fechaSaldada.Date.AddDays(Convert.ToInt32(txtProrroga.EditValue)) > DateTime.Today.Date)
            {
                if (chkSaldarFinanciamiento.Checked)
                {
                    _dtCalendario.Rows.Add(new object[] { numPagos + 1, fechaSaldada.AddMonths(-1).Date, fechaSaldada.Date, saldo, 0, 0, 0, saldo, true });
                    txtAbonoCapital.EditValue = saldo;
                }
                else if (saldo <= pagoMensual || (numPagos + 1) == Convert.ToInt32(txtMesesFinaniciamiento.EditValue))
                {
                    _dtCalendario.Rows.Add(new object[] { numPagos + 1, fechaSaldada.Date, fechaSaldada.AddMonths(1).Date, saldo, saldo, 0, 0, saldo, true });
                }
                else
                {
                    decimal balance = saldo;
                    decimal cantidad = (Convert.ToDecimal(txtCantidadFinancimiento.EditValue) -
                                        (decimal)txtEnganche.EditValue);
                    decimal inte = decimal.Round(cantidad * Convert.ToDecimal(_porcInteres), 2);
                    _dtCalendario.Rows.Add(new object[] { numPagos + 1, fechaSaldada.Date, fechaSaldada.Date.AddMonths(1), balance, pagoMensual, inte, 0, pagoMensual + inte, true });
                }
                gridPagos.DataSource = _dtCalendario;
                FormatoGrid();
                SacarTotalPago();
                return;

            }
            int mesesaPagar = 0;
            do
            {

                if (_dtCalendario.Rows.Count == 0)
                {
                    decimal recargo = 0;
                    decimal cantidad = (Convert.ToDecimal(txtCantidadFinancimiento.EditValue) -
                                         (decimal)txtEnganche.EditValue);
                    decimal inte = decimal.Round(cantidad * Convert.ToDecimal(_porcInteres), 2);
                    if (fechaSaldada.Date.AddMonths(1).AddDays(_diasProrroga) < DateTime.Today)
                    {
                        recargo = decimal.Round(cantidad * _porcRecargo, 2);
                    }
                    if (saldo <= pagoMensual || (numPagos + 1) == Convert.ToInt32(txtMesesFinaniciamiento.EditValue))
                    {
                        _dtCalendario.Rows.Add(new object[] { numPagos + 1, fechaSaldada.Date, fechaSaldada.AddMonths(1).Date, saldo, saldo, inte,recargo, saldo+recargo+inte, true });
                        break;
                    }
                    _dtCalendario.Rows.Add(new object[]
                    {
                        numPagos + 1, fechaSaldada.Date, fechaSaldada.Date.AddMonths(1), saldo, pagoMensual,
                        inte, recargo, pagoMensual+inte+recargo,true
                    });
                    grvPagos.Columns[7].OptionsColumn.AllowEdit = false;
                }
                else
                {
                    decimal balance = (decimal)_dtCalendario.Rows[_dtCalendario.Rows.Count - 1]["Balance"] -
                                      pagoMensual;
                    DateTime fchSal = Convert.ToDateTime(_dtCalendario.Rows[_dtCalendario.Rows.Count - 1]["FechaFinal"]);
                    decimal recargo = 0; decimal cantidad = (Convert.ToDecimal(txtCantidadFinancimiento.EditValue) -
                                          (decimal)txtEnganche.EditValue);
                    decimal inte = decimal.Round(cantidad * Convert.ToDecimal(_porcInteres), 2);
                    if (fchSal.AddMonths(1).AddDays(_diasProrroga) < DateTime.Today)
                    {
                        recargo = decimal.Round(cantidad * _porcRecargo, 2);
                    }
                    if (balance <= pagoMensual || (numPagos + 1) == Convert.ToInt32(txtMesesFinaniciamiento.EditValue))
                    {
                        _dtCalendario.Rows.Add(new object[] { numPagos + 1+mesesaPagar, fchSal, fchSal.AddMonths(1), balance, balance, inte, recargo, balance + recargo + inte, true });
                        break;
                    }if (balance == 0) break;

                    _dtCalendario.Rows.Add(new object[]
                    {
                         numPagos + mesesaPagar+1, fchSal, fchSal.AddMonths(1), balance, pagoMensual,inte, recargo,
                         pagoMensual+inte+recargo,true
                    });

                }
                //fechaSaldada = fechaSaldada.Date.AddMonths(1);
                mesesaPagar++;
            } while (fechaSaldada.AddMonths(mesesaPagar).AddDays(_diasProrroga).Date < DateTime.Today.Date);
            if (chkSaldarFinanciamiento.Checked)
                txtAbonoCapital.EditValue = Convert.ToDecimal(txtSaldoActual.EditValue) - _dtCalendario.Rows.Cast<DataRow>().Aggregate<DataRow, decimal>(0M, (current, row) => current + (decimal)row["Cantidad"]);
            SacarTotalPago();
            FormatoGrid();
            return;

        }
        private void txtAbonoCapital_EditValueChanged(object sender, EventArgs e)
        {
            SacarTotalPago();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            if ((decimal)txtTotalAPagar.EditValue <= 0) return;
            if (!ClsVerificarCaja.CajaEstado())
            {
                MessageBox.Show("La Caja del Dia de hoy ya se ha cerrado\n SISTEMA BLOQUEADO", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            if (!_guardado)
            {
                if ((int)txtFolioFinanciamiento.EditValue == 0)
                {
                    MessageBox.Show("Busque Primero el financiamiento para poder cobrar", Application.ProductName);
                    return;
                }
                decimal totalcantidad = 0;
                if (_dtCalendario.Rows.Count > 0)
                {
                    //if para saber si va a cobrar pagos de interes y moratorios
                    for (int i = 0; i < _dtCalendario.Rows.Count; i++)
                    {

                        if ((bool)_dtCalendario.Rows[i]["Pagar"] == false) continue;
                        PagosFinanciamiento pagFin = new PagosFinanciamiento()
                        {
                            FechaPago = dtpFechaPago.DateTime.Date,
                            CvePrestamo = _cveFinanciamiento,
                            Cantidad = (decimal)_dtCalendario.Rows[i]["Cantidad"],
                            Interes = (decimal)_dtCalendario.Rows[i]["Interes"],
                            Recargo = (decimal)_dtCalendario.Rows[i]["Recargo"],
                            AbonoPrestamo =
                                (i == _dtCalendario.Rows.Count - 1) ? (decimal)txtAbonoCapital.EditValue : 0,
                            //TotalPago =
                            //    (i == _dtCalendario.Rows.Count - 1 && !chkSaldarFinanciamiento.Checked )
                            //        ? ((decimal) _dtCalendario.Rows[i]["TotalAPagar"] +
                            //           Convert.ToDecimal(txtAbonoCapital.EditValue))
                            //        : (decimal) _dtCalendario.Rows[i]["TotalAPagar"],
                            CveUsuario =
                                Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IdUsuarioApp")),
                            Estado = true
                        };
                        pagFin.TotalPago = pagFin.AbonoPrestamo + pagFin.Cantidad + pagFin.Interes + pagFin.Recargo;

                        totalcantidad += (decimal)_dtCalendario.Rows[i]["Cantidad"];
                        _entidades.PagosFinanciamientos.InsertOnSubmit(pagFin);
                        _entidades.SubmitChanges();
                        _folios += pagFin.Clave + "; ";
                        _guardado = true;
                    }
                }
                else
                {
                    //de lo contrario ya hizo todos los pagos de interes y solo falta que liquide el capital
                    PagosFinanciamiento pagFin = new PagosFinanciamiento
                        {
                            FechaPago = dtpFechaPago.DateTime.Date,
                            CvePrestamo = _cveFinanciamiento,
                            Cantidad = 0,
                            Interes = 0,
                            Recargo = 0,
                            AbonoPrestamo = (decimal)txtAbonoCapital.EditValue,
                            TotalPago = (decimal)txtAbonoCapital.EditValue,
                            CveUsuario = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IdUsuarioApp")),
                            Estado = true
                        };
                    _entidades.PagosFinanciamientos.InsertOnSubmit(pagFin);
                    _entidades.SubmitChanges();
                    _guardado = true;
                }
                new ManejadorControles().DesectivarTextBox(gpoContenedor, true);
                MessageBox.Show("Pagos Registrado", Application.ProductName);
                ModificarSaldoFinanciamiento(_cveFinanciamiento, (totalcantidad + Convert.ToDecimal(txtAbonoCapital.EditValue)));
                ImprimirTicketPago();
            }
            else
            {
                ImprimirTicketPago();
            }
            SendKeys.Send("{TAB}");

        }
        void ImprimirTicketPago()
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
                string dirc = String.Format("{0} CP {1}", empre.Direccion, empre.CodigoPostal);//new clsModificarConfiguracion().configGetValue("Direccion");
                //string mun = String.Format("C.P: {0} {1}", conf.Single().CodigoPostal, conf.Single().Municipio);
                int padRe = ((40 - empresa.Length) / 2) + empresa.Length;
                int padRrs = ((40 - razonSocial.Length) / 2) + razonSocial.Length;
                int padRrfc = ((40 - rfc.Length) / 2) + rfc.Length;
                int padRcurp = ((40 - curp.Length) / 2) + curp.Length;
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
                ticket.AddHeaderLine("     TICKET DE PAGO FINANCIAMIENTO      ");


                ticket.AddSubHeaderLine("CLAVES PAGO: " + _folios);
                ticket.AddSubHeaderLine("CLAVE FOLIO: # " + txtFolioFinanciamiento.Text);
                ticket.AddSubHeaderLine("TIPO: # " + txtTipoFinanciamiento.Text);
                if (_entidades != null)
                {
                    Usuario usu = _entidades.Usuarios.FirstOrDefault(u => u.CveUsuario == Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioApp")));
                    if (usu != null) ticket.AddSubHeaderLine("ATENDIO: " + usu.Nombre);
                }
                ticket.AddSubHeaderLine("CLIENTE: " + txtNombre.Text);
                ticket.AddSubHeaderLine("SALDO ANTERIOR: " + double.Parse(txtSaldoActual.EditValue.ToString()).ToString("C"));

                ticket.AddSubHeaderLine(String.Format("FECHA: {0} {1}", DateTime.Today.ToString("dd/MMM/yyyy").ToUpper(), DateTime.Now.ToShortTimeString()));

                for (int x = 0; x < _dtCalendario.Rows.Count; x++)
                {
                    if ((bool)_dtCalendario.Rows[x]["Pagar"] == false) continue;
                    ticket.AddItem(_dtCalendario.Rows[x][0].ToString(), Convert.ToDateTime(_dtCalendario.Rows[x][1]).ToString("dd/MMM/yy").ToUpper() + " AL " + Convert.ToDateTime(_dtCalendario.Rows[x][2]).ToString("dd/MMM/yy").ToUpper(), double.Parse(_dtCalendario.Rows[x][7].ToString()).ToString("C"));//; gridProductos.Rows[x].Cells[0].Value.ToString(), gridProductos.Rows[x].Cells[0].Value.ToString(), gridProductos.Rows[x].Cells[0].Value.ToString());
                }
                Prestamo fina = new EmpeñosDC(new clsConeccionDB().StringConn()).Prestamos.FirstOrDefault(p => p.Clave == _cveFinanciamiento);
                ticket.AddTotal("# PAGOS: ", txtMesesPagar.EditValue.ToString());
                ticket.AddTotal("CANTIDAD: ", decimal.Parse(txtCantidadPago.EditValue.ToString()).ToString("C"));
                ticket.AddTotal("RECARGO: ", decimal.Parse(txtTotalRecargo.EditValue.ToString()).ToString("C"));
                ticket.AddTotal("ABONO A CAPITAL: ", decimal.Parse(txtAbonoCapital.EditValue.ToString()).ToString("C"));
                ticket.AddTotal("TOTAL PAGO: ", decimal.Parse(txtTotalAPagar.EditValue.ToString()).ToString("C"));

                if (fina != null) ticket.AddTotal("SALDO ACTUAL: ", fina.Saldo.ToString("C"));

                ticket.AddFooterLine("          GRACIAS POR SU PAGO            ");
                ticket.AddFooterLine("");
                ticket.AddFooterLine("");
                ticket.AddFooterLine("");
                ticket.AddFooterLine("");
                ticket.PrintTicket(new clsModificarConfiguracion().configGetValue("ImpresoraTickets"));
            }
        }
        private void ModificarSaldoFinanciamiento(int cveprestamo, decimal totaldescontar)
        {
            Prestamo prs = _entidades.Prestamos.FirstOrDefault(p => p.Clave == cveprestamo);
            if (prs != null)
            {
                prs.Saldo = prs.Saldo - totaldescontar;
                if (chkSaldarFinanciamiento.Checked || prs.Saldo == 0)
                    prs.Estado = "Pagado";
            }

            _entidades.SubmitChanges();
        }

        private void btnImprimirHistorico_Click(object sender, EventArgs e)
        {
            var pagos = from p in _entidades.PagosFinanciamientos
                        where p.CvePrestamo == _cveFinanciamiento && p.Estado
                        select new { p.Clave, p.Cantidad, p.Interes, p.Recargo, p.AbonoPrestamo, p.TotalPago, p.FechaPago, Registró = p.Usuario.Nombre };

            DataTable dtPagos = new LinqToDataTable().ObtenerDataTable2(pagos);
            if (dtPagos.Rows.Count == 0)
            {
                MessageBox.Show("Financiamiento sin pagos Previos", Application.ProductName);
                return;
            }

            FrmCronograma cro = new FrmCronograma { Tipo = "Pagos", DtCronos = dtPagos };
            cro.ShowDialog(this);
        }

        private void botonNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void txtAbonoCapital_Enter(object sender, EventArgs e)
        {
            if ((txtTipoFinanciamiento.Text == "AutoFinanciamiento" || txtTipoFinanciamiento.Text == "MotoFinanciamiento") && (decimal)txtAbonoCapital.EditValue == 0)
                txtAbonoCapital.EditValue = (decimal)_dtCalendario.Rows[0][4];
        }

        private void txtAbonoCapital_Leave(object sender, EventArgs e)
        {
            //decimal saldo = (decimal) txtSaldoActual.EditValue - pagos;
            if ((txtTipoFinanciamiento.Text == "AutoFinanciamiento" || txtTipoFinanciamiento.Text == "MotoFinanciamiento") && ((decimal)txtAbonoCapital.EditValue % (decimal)_dtCalendario.Rows[0][4] != 0))
            {

                txtAbonoCapital.EditValue = (decimal)_dtCalendario.Rows[0][4];
                MessageBox.Show("No puede abonar mas o menos de lo correspondiente a cada letra");

            }
        }

        private void chkPagarActual_CheckedChanged(object sender, EventArgs e)
        {
            //if (_cveFinanciamiento > 0)
            //    PrestamoDevuelto(_cveFinanciamiento.ToString());
        }

        private void chkSaldarFinanciamiento_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow fila in _dtCalendario.Rows)
            {
                fila["Pagar"] = true;
            }
            if (chkSaldarFinanciamiento.Checked)
            {
                txtAbonoCapital.EditValue = Convert.ToDecimal(txtSaldoActual.EditValue) -
                                            _dtCalendario.Rows.Cast<DataRow>()
                                                .Aggregate<DataRow, decimal>(0M,
                                                    (current, row) => current + (decimal)row["Cantidad"]);
                grvPagos.OptionsBehavior.Editable = false;
            }
            else
            {
                txtAbonoCapital.EditValue = 0M;
                grvPagos.OptionsBehavior.Editable = true;
            }
            PrestamoDevuelto(_cveFinanciamiento.ToString());
        }

        private void btnVerReferencias_Click(object sender, EventArgs e)
        {
            var refe = from r in _entidades.DetalleReferenciasPrestamos
                       where r.CvePrestamo == _cveFinanciamiento
                       select new { Clave = r.Referencia.CveReferencia, r.Referencia.Nombre, r.Referencia.Direccion, r.Referencia.Telefono, r.Referencia.Celular };
            DataTable dtrefe = new LinqToDataTable().ObtenerDataTable2(refe);
            if (dtrefe.Rows.Count == 0)
            {
                MessageBox.Show("Financiamiento sin referencias", Application.ProductName);
                return;
            }
            FrmCronograma cro = new FrmCronograma { Tipo = "Referencias", DtCronos = dtrefe };
            cro.ShowDialog(this);
        }

        private void frmPagosFinanciamiento_Shown(object sender, EventArgs e)
        {
            Nuevo();
            if (cveFin > 0)
            {
                PrestamoDevuelto(cveFin.ToString());
            }
        }
        private bool recargo(GridView view, int row)
        {

            GridColumn col = view.Columns["Recargo"];

            decimal val = Convert.ToDecimal(view.GetRowCellValue(row, col));

            return val > 0;

        }

        private void gridView1_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle == 0)

                e.Cancel = true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int ultimRow = grvPagos.RowCount - 1;
            int activecelda = grvPagos.GetFocusedDataSourceRowIndex();
            if (Convert.ToBoolean(_dtCalendario.Rows[activecelda][8]))
            {
                while (activecelda >= 1)
                {
                    _dtCalendario.Rows[activecelda - 1][8] = true;
                    activecelda--;
                }

            }
            if (activecelda != ultimRow)
            {
                if (Convert.ToBoolean(_dtCalendario.Rows[activecelda + 1][8]))
                {
                    _dtCalendario.Rows[activecelda][8] = true;
                }
            }
            if ((bool)e.Value && _dtCalendario.Rows.Count - 1 == e.RowHandle)
            {
                txtAbonoCapital.EditValue = 0M;
                txtAbonoCapital.Enabled = true;
            }
            else
            {
                txtAbonoCapital.EditValue = 0M;
                txtAbonoCapital.Enabled = false;
            }

            
            SacarTotalPago();
            
            }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

        private void txtAbonoCapital_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

            decimal saldo = Convert.ToDecimal(txtSaldoActual.EditValue) - _dtCalendario.Rows.Cast<DataRow>().Aggregate<DataRow, decimal>(0M, (current, row) => current + (decimal)row["Cantidad"]);
            if (Convert.ToDecimal(e.NewValue) > saldo)
            {
                XtraMessageBox.Show("No puede abonar mas de lo debe el cliente");
                e.Cancel = true;
            }
        }
    }
}
