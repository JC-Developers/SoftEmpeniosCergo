using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;
using SoftEmpenios.Dialogos;

namespace SoftEmpenios.Pantallas
{
    public partial class FrmPagoDesempeño : XtraForm, iPantalla
    {
        private readonly DataTable _dtIntereses;
        private bool _guardado;
        readonly DataTable _dtprenda = new DataTable("Prendas");
        public FrmPagoDesempeño()
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
        }
        private void txtFolioBoleta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtFolioBoleta.Text.Trim() != string.Empty && e.KeyChar == (char)Keys.Enter)
            {
                BoletaDevuelta(txtFolioBoleta.Text);
            }
        }

        private void BoletaDevuelta(string p)
        {
            try
            {
                Nuevo();
                Boleta bol = new EmpeñosDC(new clsConeccionDB().StringConn()).Boletas.SingleOrDefault(b => b.Folio == p);
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
                dtpFechaSaldada.DateTime = bol.FechaPrestamo.AddMonths(bol.PagosInteres.Count(pg => pg.Estado ));
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
                            XtraMessageBox.Show("La boleta ya esta VENCIDA \n ya han pasado " + diastrancurridos + " DIAS  de  " + diasparavencer + " dias para poder pagar", "Boleta VENCIDA");
                            return;
                        }
                        botonGuardar.Enabled = true;
                        break;
                    case "Cancelado":
                        XtraMessageBox.Show("La Boleta esta cancelada");
                        botonGuardar.Enabled = false;
                        return;

                }
                CalcularIntereses(dtpFechaSaldada.DateTime.Date,bol.PagosInteres.Count);
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }

        }

        private void CalcularIntereses(DateTime fechaSaldada,int  numpagos)
        {
            _dtIntereses.Rows.Clear();
            _dtIntereses.AcceptChanges();
            _dtIntereses.Columns[0].AutoIncrementStep = -1;
            _dtIntereses.Columns[0].AutoIncrementSeed = -1;
            _dtIntereses.Columns[0].AutoIncrementStep = 1;
            _dtIntereses.Columns[0].AutoIncrementSeed = 1;

            int prorroga = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("Prorroga"));
            decimal porRecargo = Convert.ToDecimal(new clsModificarConfiguracion().configGetValue("PorcentajeRecargo"));
            decimal recargoDia = Convert.ToDecimal(txtPrestamo.EditValue) * (porRecargo / 100);
            decimal interes = Convert.ToDecimal(txtInteres.EditValue);
            if (numpagos==0 &&(fechaSaldada.Date == DateTime.Today.Date ||(fechaSaldada.Date<=DateTime.Today.Date &&fechaSaldada.Date>=DateTime.Today.Date.AddMonths(-1)) ) )
            {
                _dtIntereses.Rows.Add(new object[]
                    {null, fechaSaldada.Date, fechaSaldada.AddMonths(1), interes, 0, 0, interes});
            }
            else
            {
                while (fechaSaldada.AddDays(prorroga) < DateTime.Today.Date)
                {
                    DateTime fechaInicial = fechaSaldada;
                    DateTime fechaFinal = fechaSaldada.AddMonths(1);
                    int diasRecargo = DateTime.Now.Subtract(fechaFinal.AddDays(prorroga).Date).Days <= 0
                                          ? 0
                                          : DateTime.Now.Subtract(fechaFinal.AddDays(prorroga).Date).Days;
                    decimal recargo = diasRecargo*recargoDia;
                    decimal totalpagar = interes + recargo;
                    _dtIntereses.Rows.Add(new object[]
                        {null, fechaInicial, fechaFinal, interes, diasRecargo, recargo, totalpagar});
                    fechaSaldada = fechaSaldada.AddMonths(1);
                }
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
            txtRecargoDia.EditValue = recargoDia;
            CalcularTotales();
        }

        private List<string> PrendasAnteriores(string cadenaArticulos)
        {
            List<string> art = new List<string>();
            art.AddRange(cadenaArticulos.Split(new[] { ';' }).Where(s => s != String.Empty && s!=" "));
            return art;
        }
        private void btnVerPagos_Click(object sender, EventArgs e)
        {
            var pagos = new EmpeñosDC(new clsConeccionDB().StringConn()).PagosInteres.Where(pg => pg.FolioBoleta == txtFolioBoleta.Text && pg.Estado )
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
                if (!VericarHorario())
                {
                    XtraMessageBox.Show("No puede desempeñar esta fuera del horario", "Fuera de Horario");
                    return;
                }
                if (!_guardado)
                {
                    string meses = _dtIntereses.Rows.Cast<DataRow>()
                        .Aggregate("",
                            (current, fechas) =>
                                current + Convert.ToDateTime(fechas[1]).ToString("dd-MMM-yyyy") + " AL " +
                                Convert.ToDateTime(fechas[2]).ToString("dd-MMM-yyyy") + " ");
                    Desempeño entity = new Desempeño
                    {
                        FechaDesempeño = DateTime.Today.Date,
                        FolioBoleta = txtFolioBoleta.Text,
                        InteresTotal = Convert.ToDecimal(txtInteresGenererado.EditValue),
                        MesesPagados = meses.ToUpper(),
                        Recargos = Convert.ToDecimal(txtRecargoGenerado.EditValue),
                        RecargoxDia = Convert.ToDecimal(txtRecargoDia.EditValue),
                        DiasRecargo = Convert.ToDecimal(txtDiasRecargo.EditValue),
                        TotalPagar = Convert.ToDecimal(txtTotalPago.EditValue),
                        CveUsuario = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioAPP")),
                        Estado = true
                    };
                    txtClave.EditValue= new LogicaNegocios.LogicaDesempeños().AgregarDesempeño(entity);
                    _guardado = true;
                    XtraMessageBox.Show("Desempeño Registrados", "Desempeño");

                    ImprimirTickets(entity.Clave);
                }
                else
                {
                    ImprimirTickets(Convert.ToInt32(txtClave.EditValue));
                }
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
        private bool VericarHorario()
        {
            string dia = DateTime.Today.Date.ToString("dddd");
            Horario hr = new EmpeñosDC(new clsConeccionDB().StringConn()).Horarios.SingleOrDefault(h => h.Dia == dia);
            if (hr != null && ((TimeSpan.Compare(DateTime.Now.TimeOfDay, hr.HoraInicial.TimeOfDay) >= 0) &&
                               (TimeSpan.Compare(DateTime.Now.TimeOfDay, hr.HoraFinal.TimeOfDay) <= 0)))
                return true;
            return false;
        }
        private void ImprimirTickets(int cveDesempeño)
        {
            Configuracione empre = new EmpeñosDC(new clsConeccionDB().StringConn()).Configuraciones.First();

            string empresa = new clsModificarConfiguracion().configGetValue("Empresa");
            string razonSocial = new clsModificarConfiguracion().configGetValue("RazonSocial");
            string rfc = new clsModificarConfiguracion().configGetValue("RFC");
            string curp = new clsModificarConfiguracion().configGetValue("CURP");
            string dirc = String.Format("{0} CP {1}", empre.Direccion, empre.CodigoPostal);
            int padRe = ((40 - empresa.Length) / 2) + empresa.Length;
            int padRrs = ((40 - razonSocial.Length) / 2) + razonSocial.Length;
            int padRrfc = ((40 - rfc.Length) / 2) + rfc.Length;
            int padRcurp = ((40 - curp.Length) / 2) + curp.Length;

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
            ticket.AddHeaderLine("          TICKET DE DESEMPEÑO           ");
            Usuario usu = new EmpeñosDC(new clsConeccionDB().StringConn()).Usuarios.Single(u => u.CveUsuario == Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioApp")));
            ticket.AddSubHeaderLine("ATENDIO: " + usu.Nombre);
            ticket.AddSubHeaderLine("FOLIO BOLETA: " + txtFolioBoleta.Text);
            ticket.AddSubHeaderLine("DESEMPEÑO NUM: " + cveDesempeño);
            ticket.AddSubHeaderLine("CLIENTE: " + txtNomCliente.Text);
            ticket.AddSubHeaderLine(String.Format("FECHA DESEMPEÑO:{0} {1}", DateTime.Today.ToString("dd/MMM/yyyy").ToUpper(), DateTime.Now.ToShortTimeString()));
            ticket.AddSubHeaderLine("----------------------------------------");
            ticket.AddSubHeaderLine("         ARTICULOS A DESEMPEÑAR         ");
            string prendas = _dtprenda.Rows.Cast<DataRow>().Aggregate("", (current, pRow) => current + pRow[0] + ",");
            ticket.AddSubHeaderLine(prendas);
            for (int x = 0; x < _dtIntereses.Rows.Count; x++)
                ticket.AddItem(
                    txtClave.Text,
                    Convert.ToDecimal(_dtIntereses.Rows[x][3]).ToString("C2"),
                    Convert.ToDecimal(_dtIntereses.Rows[x][5]).ToString("C2"),
                    Convert.ToDecimal(_dtIntereses.Rows[x][6]).ToString("C2"),
                    Convert.ToDateTime(_dtIntereses.Rows[x][1]).ToString("dd-MMM-yyyy") + " al " + Convert.ToDateTime(_dtIntereses.Rows[x][2]).ToString("dd-MMM-yyyy"));
            ticket.AddTotal("MESES PAGADOS: ", txtMeses.EditValue.ToString());
            ticket.AddTotal("INTERES TOTAL: ", double.Parse(txtInteresGenererado.EditValue.ToString()).ToString("C2"));
            ticket.AddTotal("RECARGOS: ", double.Parse(txtRecargoGenerado.EditValue.ToString()).ToString("C2"));
            ticket.AddTotal("RECARGO POR DÍA: ", double.Parse(txtRecargoDia.EditValue.ToString()).ToString("C2"));
            ticket.AddTotal("DIAS RECARGO: ", txtDiasRecargo.EditValue.ToString());
            ticket.AddTotal("TOTAL A PAGAR: ", double.Parse(txtTotalPago.EditValue.ToString()).ToString("C2"));
            ticket.AddFooterLine("");
            ticket.AddFooterLine("FECHA DE EMPEÑO: "+ dtpFechaEmpeño.DateTime.Date.ToString("dd-MMMM-yyyy").ToUpper());
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

        private void CalcularTotales()
        {
            txtMeses.EditValue = _dtIntereses.Rows.Cast<DataRow>().Count();
            txtInteresGenererado.EditValue = _dtIntereses.Rows.Cast<DataRow>().Aggregate<DataRow, decimal>(0M, (current, row) => current + (decimal)row["Interes"]);
            txtDiasRecargo.EditValue = _dtIntereses.Rows.Cast<DataRow>().Aggregate<DataRow, decimal>(0M, (current, row) => current + (decimal)row["DiasRecargo"]);
            txtRecargoGenerado.EditValue = _dtIntereses.Rows.Cast<DataRow>().Aggregate<DataRow, decimal>(0M, (current, row) => current + (decimal)row["Recargo"]);
            txtTotalPago.EditValue = _dtIntereses.Rows.Cast<DataRow>().Aggregate<DataRow, decimal>(0M, (current, row) => current + (decimal)row["TotalPagar"]) + Convert.ToDecimal(txtPrestamo.EditValue);
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void FrmPagoDesempeño_Shown(object sender, EventArgs e)
        {
            Nuevo();
        }
    }
}
