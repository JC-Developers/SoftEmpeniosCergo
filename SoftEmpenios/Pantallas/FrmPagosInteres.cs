using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;
using SoftEmpenios.Dialogos;

namespace SoftEmpenios.Pantallas
{
    public partial class FrmPagosInteres :XtraForm, iPantalla
    {
        private readonly DataTable _dtIntereses;
        private bool _guardado;
        Cotizacion inte = new Cotizacion();
        readonly DataTable _dtprenda = new DataTable("Prendas");

        public FrmPagosInteres()
        {
            InitializeComponent();
            _dtprenda.Columns.Add("Descripción", Type.GetType("System.String"));
            _dtprenda.Columns.Add("PesoCantidad", Type.GetType("System.Decimal"));
            _dtprenda.Columns.Add("Tipo ", Type.GetType("System.String"));
            _dtprenda.Columns.Add("Avaluo", Type.GetType("System.Decimal"));
            _dtIntereses = new DataTable("pagosPersonales");
            DataColumn numMes = new DataColumn
            {
                ColumnName = "NumPago",
                DataType = Type.GetType("System.Int32"),
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ReadOnly = true,
                Unique = true
            };
            _dtIntereses.Columns.Add(numMes);
            _dtIntereses.Columns.Add("FechaInicial", typeof(DateTime));
            _dtIntereses.Columns.Add("FechaFinal", typeof(DateTime));
            _dtIntereses.Columns.Add("Interes", typeof(Decimal));
            _dtIntereses.Columns.Add("DiasRecargo", typeof(Decimal));
            _dtIntereses.Columns.Add("Recargo", typeof(Decimal));
            _dtIntereses.Columns.Add("TotalPagar", typeof(Decimal));
            _dtIntereses.Columns.Add("Pagar", typeof(Boolean));
        }

        private void txtFolioBoleta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtFolioBoleta.Text.Trim() != string.Empty && e.KeyChar == (char) Keys.Enter)
            {
                BoletaDevuelta(txtFolioBoleta.Text);
            }
        }

        private void BoletaDevuelta(string p)
        {
            try
            {
                Nuevo();
                _dtprenda.Rows.Clear();
                Boleta bol =new  EmpeñosDC(new clsConeccionDB().StringConn()).Boletas.SingleOrDefault(b => b.Folio == p);
                if (bol == null)
                {
                    XtraMessageBox.Show(String.Format("La Boleta: {0} no Existe", txtFolioBoleta.Text), "Boleta no Encontrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                txtFolioBoleta.EditValue = p;
                txtFolioBoleta.Enabled = false;
                txtNomCliente.EditValue = bol.Cliente;
                txtCotitular.EditValue = bol.Cotitular;
                txtPrestamo.EditValue = bol.Prestamo;
                txtInteres.EditValue = bol.Interes;
                dtpFechaEmpeño.DateTime = bol.FechaPrestamo;
                dtpFechaSaldada.DateTime = bol.FechaPrestamo.AddMonths(bol.PagosInteres.Count(pg=>pg.Estado));
                _dtprenda.Rows.Clear();
                if (bol.DetallesBoletas.Any())
                {
                    var prendas = bol.DetallesBoletas
                            .Select(
                                db =>
                                    new
                                    {
                                        db.Prenda.Descripcion,
                                        db.Prenda.Peso,
                                        db.Prenda.Tipo,
                                        db.Prenda.Avaluo
                                    });
                    foreach (var pr in prendas)
                    {
                        _dtprenda.Rows.Add(new object[] { pr.Descripcion, pr.Peso, pr.Tipo, pr.Avaluo });
                    }
                }
                else
                {
                    PrendasAnteriores(bol.Articulos).ForEach(prenda => _dtprenda.Rows.Add(new object[] { prenda, 0, 0, 0 }));
                }
                gridPrendas.DataSource = _dtprenda;
                grvPrendas.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
                grvPrendas.Columns[3].DisplayFormat.FormatString = "c2";
                grvPrendas.Columns[2].AppearanceCell.TextOptions.HAlignment=HorzAlignment.Center;
                gridPrendas.ForceInitialize();
                
                switch (bol.EstadoBoleta)
                {
                    case "Vencido":
                        botonGuardar.Enabled = false;
                        XtraMessageBox.Show("El Empeño a vencido y se ha Fundido", "Boleta Vencida");
                        return;
                        
                    case "Desempeñado":
                        botonGuardar.Enabled = false;
                        DateTime fchDesempeño =
                            new EmpeñosDC(new clsConeccionDB().StringConn()).Desempeños.Single(d => d.FolioBoleta == bol.Folio).FechaDesempeño;
                        XtraMessageBox.Show("La Boleta: " + bol.Folio + " Se ha Desempeñado\n FECHA DESEMPEÑO: " + fchDesempeño.ToString("dd/MMM/yyyy"), "Boleta Desempeñada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        
                        return;
                    case "Vigente":
                        TimeSpan diasdespuesPrestamo = DateTime.Now.Subtract(dtpFechaSaldada.DateTime.Date);
                        int diastrancurridos = (int)diasdespuesPrestamo.TotalDays;
                        int diasparavencer = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("DiasVencimiento"));
                        if (diastrancurridos > diasparavencer)
                        {
                            botonGuardar.Enabled = false;
                            XtraMessageBox.Show("La boleta ya esta VENCIDA \n ya han pasado " + diastrancurridos.ToString() + " DIAS  de  " + diasparavencer.ToString() + " dias para poder pagar", "Boleta VENCIDA");
                            return;
                        }
                        botonGuardar.Enabled = true;
                        break;
                    case "Cancelado":
                        XtraMessageBox.Show("La Boleta esta cancelada");
                        botonGuardar.Enabled = false;
                        return;

                }
                CalcularIntereses(dtpFechaSaldada.DateTime.Date);
            }
            catch (Exception ex)
            {
                    
               XtraMessageBox.Show(ex.Message);
            }
           
        }

        private void CalcularIntereses(DateTime fechaSaldada)
        {
            _dtIntereses.Rows.Clear();
            _dtIntereses.AcceptChanges();
            _dtIntereses.Columns[0].AutoIncrementStep = -1;
            _dtIntereses.Columns[0].AutoIncrementSeed = -1;
            _dtIntereses.Columns[0].AutoIncrementStep = 1;
            _dtIntereses.Columns[0].AutoIncrementSeed = 1;

            DateTime fechaInicial = fechaSaldada;
            DateTime fechaFinal = fechaSaldada.AddMonths(1);
            int prorroga = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("Prorroga"));
            decimal porRecargo = Convert.ToDecimal(new clsModificarConfiguracion().configGetValue("PorcentajeRecargo"));
            decimal recargoDia = Convert.ToDecimal(txtPrestamo.EditValue)*(porRecargo/100);
            decimal interes = Convert.ToDecimal(txtInteres.EditValue);
                //Convert.ToDecimal(txtCredito.EditValue) * Convert.ToDecimal(txtInteres.EditValue);
            decimal recargo = 0;
                //(fechaSaldada.AddMonths(1).AddDays(1) < DateTime.Today.Date) ? Convert.ToDecimal(txtRecargo.EditValue) : 0;
            decimal totalpagar = interes + recargo;
            int diasRecargo=0;
            if (fechaSaldada.AddMonths(1).AddDays(prorroga) < DateTime.Today.Date)
            {
                while (fechaSaldada.AddDays(prorroga) < DateTime.Today.Date)
                {
                    fechaInicial = fechaSaldada;
                    fechaFinal = fechaSaldada.AddMonths(1);
                    diasRecargo =  DateTime.Now.Subtract(fechaFinal.AddDays(prorroga).Date).Days<=0?0:DateTime.Now.Subtract(fechaFinal.AddDays(prorroga).Date).Days;
                    recargo =diasRecargo * recargoDia ;
                        //(fechaSaldada.AddMonths(1).AddDays(1) < DateTime.Today.Date) ? Convert.ToDecimal(txtRecargo.EditValue) : 0;
                    totalpagar = interes + recargo;

                    _dtIntereses.Rows.Add(new object[]
                        {null,fechaInicial, fechaFinal, interes, diasRecargo, recargo,  totalpagar, true});
                    fechaSaldada = fechaSaldada.AddMonths(1);
                }
            }
            else
            {
                /**/
                //
                /**/
                _dtIntereses.Rows.Add(new object[]
                    {null, fechaInicial, fechaFinal, interes,diasRecargo, recargo, totalpagar, true});
            }

            gridIntereses.DataSource = _dtIntereses;

            grvIntereses.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            grvIntereses.Columns[1].DisplayFormat.FormatType = FormatType.DateTime;
            grvIntereses.Columns[2].DisplayFormat.FormatType = FormatType.DateTime;
            grvIntereses.Columns[1].DisplayFormat.FormatString = "dd/MMM/yyyy";
            grvIntereses.Columns[2].DisplayFormat.FormatString = "dd/MMM/yyyy";

            grvIntereses.Columns[0].OptionsColumn.AllowEdit = false;
            grvIntereses.Columns[1].OptionsColumn.AllowEdit = false;
            grvIntereses.Columns[2].OptionsColumn.AllowEdit = false;
            grvIntereses.Columns[3].OptionsColumn.AllowEdit = false;
            grvIntereses.Columns[4].OptionsColumn.AllowEdit = false;
            grvIntereses.Columns[5].OptionsColumn.AllowEdit = false;
            grvIntereses.Columns[6].OptionsColumn.AllowEdit = false;

            grvIntereses.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
            grvIntereses.Columns[3].DisplayFormat.FormatString = "c2";
            grvIntereses.Columns[5].DisplayFormat.FormatType = FormatType.Numeric;
            grvIntereses.Columns[5].DisplayFormat.FormatString = "c2";
            grvIntereses.Columns[6].DisplayFormat.FormatType = FormatType.Numeric;
            grvIntereses.Columns[6].DisplayFormat.FormatString = "c2";
            //grvIntereses.Columns[7].DisplayFormat.FormatString = "c2";
            txtRecargoDia.EditValue = recargoDia;
            CalcularTotales();
        }

        private List<string> PrendasAnteriores(string cadenaArticulos)
        {
            List<string> art = new List<string>();
            art.AddRange(cadenaArticulos.Split(new[] { ';' }).Where(s => s!=" " ));
            return art;
        }

        private void btnVerPagos_Click(object sender, EventArgs e)
        {
            var pagos = new EmpeñosDC(new clsConeccionDB().StringConn()).PagosInteres.Where(pg => pg.FolioBoleta == txtFolioBoleta.Text && pg.Estado)
                .Select(pg => new { pg.Clave, MesPagado = pg.MesPagado ?? "N/A", pg.Interes, pg.Recargos, pg.TotalPagar, pg.FechaPago, Registro = pg.Usuario.Nombre });
            DataTable dtPagos = new LinqToDataTable().ObtenerDataTable2(pagos);
            if (dtPagos.Rows.Count == 0)
            {
                MessageBox.Show("Boleta sin pagos de interes", Application.ProductName);
                return;
            }
            FrmCronograma cro = new FrmCronograma { Tipo = "PagosInteres", DtCronos = dtPagos };
            cro.ShowDialog(this);
        }

        public void Buscar()
        {
            FrmBuscar cliente = new FrmBuscar();
            cliente.CriteriosDeBusqueda("Empenios");
            cliente.DevolverString += BoletaDevuelta;
            cliente.ShowDialog(this);
            cliente.DevolverString -= BoletaDevuelta;
            cliente.Close();
        }

        public bool ConfirmarCierre()
        {
            return false; //throw new NotImplementedException();
        }
        public void Eliminar()
        {
            //throw new NotImplementedException();
        }

        public void Guardar()
        {
            try
            {
                if (!ClsVerificarCaja.CajaEstado())
                {
                    MessageBox.Show("La Caja del Dia de hoy ya se ha cerrado\n SISTEMA BLOQUEADO", "Caja Cerrada",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                if (!_guardado)
                {
                   
                    foreach (PagosIntere interes in from DataRow pago in _dtIntereses.Rows
                        where (bool) pago["Pagar"]
                        select new PagosIntere
                        {
                            FolioBoleta = txtFolioBoleta.Text,
                            CveUsuario = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioApp")),
                            DiasRecargo = Convert.ToInt32(pago["DiasRecargo"]),
                            Estado = true,
                            FechaPago = DateTime.Today.Date,
                            Interes = Convert.ToDecimal(pago["Interes"]),
                            NumPago =
                                new EmpeñosDC(new clsConeccionDB().StringConn()).PagosInteres.Count(
                                    pi => pi.FolioBoleta == txtFolioBoleta.Text) + 1,
                            Recargos = Convert.ToDecimal(pago["Recargo"]),
                            RecargoXDia = Convert.ToDecimal(txtRecargoDia.EditValue),
                            TotalPagar = Convert.ToDecimal(pago["TotalPagar"]),
                            MesPagado =
                                Convert.ToDateTime(pago["FechaInicial"]).ToString("dd/MMM/yyyy") + " al " +
                                Convert.ToDateTime(pago["FechaFinal"]).ToString("dd/MMM/yyyy"),
                        })
                    {
                        new LogicaNegocios.LogicaPagosInteres().AgregarPagoInteres(interes);
                        inte.Tables[1].Rows.Add(interes.Clave, interes.MesPagado, interes.Interes, interes.DiasRecargo,
                            interes.RecargoXDia, interes.Recargos, interes.TotalPagar,
                            interes.Boleta.Cliente, interes.Usuario.Nombre, interes.FolioBoleta);
                    }
                    if (inte.Tables[1].Rows.Count == 0) return;
                    XtraMessageBox.Show("Pagos Registrados", "Interes Cobrado");
                    _guardado = true;
                    ImprimirTickets(inte.Tables[1]);
                }
                else
                    ImprimirTickets(inte.Tables[1]);
                //Nuevo();
                SendKeys.Send("{TAB}");


            }
            catch (ValidationException vex)
            {
                XtraMessageBox.Show(vex.Message, "Validando Datos");
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message, "Error a Guardar E Imprimir");
            }
        }

        private void ImprimirTickets(DataTable pagos)
        {
            Configuracione empre = new EmpeñosDC(new clsConeccionDB().StringConn()).Configuraciones.First();

            string empresa = new clsModificarConfiguracion().configGetValue("Empresa");
            string razonSocial = new clsModificarConfiguracion().configGetValue("RazonSocial");
            string rfc = new clsModificarConfiguracion().configGetValue("RFC");
            string curp = new clsModificarConfiguracion().configGetValue("CURP");
            string dirc = String.Format("{0} CP {1}", empre.Direccion, empre.CodigoPostal);//new clsModificarConfiguracion().configGetValue("Direccion");
            //string mun = String.Format("C.P: {0} {1}", conf.Single().CodigoPostal, conf.Single().Municipio);
            int padRe = ((40 - empresa.Length) / 2) + empresa.Length;
            int padRrs = ((40 - razonSocial.Length) / 2) + razonSocial.Length;
            int padRrfc = ((40 - rfc.Length) / 2) + rfc.Length;
            int padRcurp = ((40 - curp.Length) / 2) + curp.Length;
            //int padRE = ((40 - empresa.Length) / 2) + empresa.Length;

            Ticket ticket = new Ticket(0);
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
            ticket.AddHeaderLine("            TICKET DE INTERES             ");
            Usuario usu = new EmpeñosDC(new clsConeccionDB().StringConn()).Usuarios.First(u => u.CveUsuario == Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioApp")));
            ticket.AddSubHeaderLine("ATENDIO: " + usu.Nombre);
            ticket.AddSubHeaderLine("FOLIO BOLETA: " + txtFolioBoleta.Text);
            ticket.AddSubHeaderLine("CLIENTE: " + txtNomCliente.Text);
            ticket.AddSubHeaderLine(String.Format("FECHA: {0} {1}", DateTime.Today.ToString("dd/MMM/yyyy"), DateTime.Now.ToShortTimeString()));

            for (int x = 0; x < pagos.Rows.Count; x++)
                ticket.AddItem(
                    pagos.Rows[x][0].ToString(),
                    Convert.ToDecimal(pagos.Rows[x][2]).ToString("C2"),
                    Convert.ToDecimal(pagos.Rows[x][5]).ToString("C2"),
                    Convert.ToDecimal(pagos.Rows[x][6]).ToString("C2"),
                    pagos.Rows[x][1].ToString().ToUpper());//; gridProductos.Rows[x].Cells[0].Value.ToString(), gridProductos.Rows[x].Cells[0].Value.ToString(), gridProductos.Rows[x].Cells[0].Value.ToString());
            ticket.AddTotal("MESES PAGADOS: ", txtMeses.EditValue.ToString());
            ticket.AddTotal("INTERES TOTAL: ", double.Parse(txtInteresGenererado.EditValue.ToString()).ToString("C2"));
            ticket.AddTotal("RECARGOS: ", double.Parse(txtRecargoGenerado.EditValue.ToString()).ToString("C2"));
            ticket.AddTotal("RECARGO POR DÍA: ", double.Parse(txtRecargoDia.EditValue.ToString()).ToString("C2"));
            ticket.AddTotal("DIAS RECARGO: ", txtDiasRecargo.EditValue.ToString());
            ticket.AddTotal("TOTAL A PAGAR: ", double.Parse(txtTotalPago.EditValue.ToString()).ToString("C2"));
            DateTime proxpago = dtpFechaEmpeño.DateTime.AddMonths(
                new EmpeñosDC(new clsConeccionDB().StringConn()).PagosInteres.Count(
                    p => p.Estado && p.FolioBoleta == txtFolioBoleta.Text) + 1);
            ticket.AddFooterLine("PROXIMO PAGO: "+ proxpago.ToString("dd-MMMM-yyyy").ToUpper());
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.PrintTicket(new clsModificarConfiguracion().configGetValue("ImpresoraTickets"));
        }

        public void Nuevo()
        {
            try
            {
                new ManejadorControles().LimpiarControles(gpoContenedor);
                gridIntereses.DataSource = null;
                gridPrendas.DataSource = null;
                grvPrendas.Columns.Clear();
                _guardado = false;
                inte.Tables[1].Rows.Clear();
                txtFolioBoleta.Enabled = true;
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
            //throw new NotImplementedException();
        }

        public void Paginar(int primerRegistro)
        {
            //throw new NotImplementedException();
        }

        public void Refrescar()
        {
            //throw new NotImplementedException();
        }

        public string nombrePantalla
        {
            get
            {
                return "Pago de Interes";
            }
        }

        private void grvIntereses_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

        private void grvIntereses_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
            int ultimRow = grvIntereses.RowCount - 1;
            int activecelda = grvIntereses.GetFocusedDataSourceRowIndex();
            if (Convert.ToBoolean(_dtIntereses.Rows[activecelda][7]))
            {
                while (activecelda >= 1)
                {
                    _dtIntereses.Rows[activecelda - 1][7] = true;
                    activecelda--;
                }

            }
            if (activecelda != ultimRow)
            {
                if (Convert.ToBoolean(_dtIntereses.Rows[activecelda + 1][7]))
                {
                    _dtIntereses.Rows[activecelda][7] = true;
                }
            }
            CalcularTotales();
        }

        private void CalcularTotales()
        {
            
            txtMeses.EditValue = _dtIntereses.Rows.Cast<DataRow>().Count(fila => (bool)fila[7]);
            decimal sum = (from DataRow fila in _dtIntereses.Rows where (bool) fila[7] select Convert.ToDecimal(fila["Interes"])).Sum();
            txtInteresGenererado.EditValue = sum;
            int sum1 = (from DataRow fila in _dtIntereses.Rows where (bool) fila[7] select Convert.ToInt32(fila["DiasRecargo"])).Sum();
            txtDiasRecargo.EditValue= sum1;
            txtRecargoGenerado.EditValue = (from DataRow fila in _dtIntereses.Rows where (bool)fila[7] select Convert.ToDecimal(fila["Recargo"])).Sum();
            txtTotalPago.EditValue = (from DataRow fila in _dtIntereses.Rows where (bool)fila[7] select Convert.ToDecimal(fila["TotalPagar"])).Sum();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void FrmPagosInteres_Shown(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void grvIntereses_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedRowHandle == 0)

                e.Cancel = true;
        }

        private void botonGuardar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Space)
                e.Handled = true;

        }

        private void botonGuardar_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                e.IsInputKey = false;
            
        }
    }
}
