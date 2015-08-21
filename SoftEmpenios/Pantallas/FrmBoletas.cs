using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;
using SoftEmpenios.LogicaNegocios;
using SoftEmpenios.Reportes;

namespace SoftEmpenios.Pantallas
{
    public partial class FrmBoletas : XtraForm, iPantalla
    {
        readonly DataTable _dtprenda = new DataTable("Prendas");
        readonly DataTable _dtprecios = new DataTable("Precios");
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        private bool Guardado;
        public FrmBoletas()
        {
            InitializeComponent();
            _dtprenda.Columns.Add("Descripción", Type.GetType("System.String"));
            _dtprenda.Columns.Add("PesoCantidad", Type.GetType("System.Decimal"));
            _dtprenda.Columns.Add("Tipo", Type.GetType("System.String"));
            _dtprenda.Columns.Add("Avaluo", Type.GetType("System.Decimal"));

            DataColumn num = new DataColumn
            {
                ColumnName = "Clave",
                DataType = Type.GetType("System.Int32"),
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ReadOnly = true,
                Unique = true
            };
            _dtprecios.Columns.Add(num);
            _dtprecios.Columns.Add("Tipo", Type.GetType("System.String"));
            _dtprecios.Columns.Add("PrecioGr", Type.GetType("System.Decimal"));

            var precios = _entidades.Precios.Select(p => new { p.Tipo, PrecioGr = p.Empeño }).Where(p=>p.PrecioGr>0);

            foreach (var pre in precios)
            {
                _dtprecios.Rows.Add(new object[] { null, pre.Tipo, pre.PrecioGr });
            }
            _dtprecios.Rows.Add(new object[] { null, "Automovil", 0M });
            _dtprecios.Rows.Add(new object[] { null, "Motocicleta", 0M });
            _dtprecios.Rows.Add(new object[] { null, "Varios", 0M });
            cboTipoPrenda.Properties.DataSource = _dtprecios;
            cboTipoPrenda.Properties.DisplayMember = "Tipo";
            cboTipoPrenda.Properties.ValueMember = "Clave";

            gridPrendas.DataSource = _dtprenda;
        }

        private void FrmBoletas_Shown(object sender, EventArgs e)
        {
            Nuevo();
            grvPrendas.Columns[0].Width = 280;
            grvPrendas.Columns[2].Width = 115;
            grvPrendas.Columns[3].OptionsColumn.AllowEdit = false;
            grvPrendas.Columns[1].DisplayFormat.FormatType = FormatType.Numeric;
            grvPrendas.Columns[1].DisplayFormat.FormatString = "###.##";
            grvPrendas.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
            grvPrendas.Columns[3].DisplayFormat.FormatString = "c2";
            cboTipoPrenda.Properties.PopulateColumns();
            cboTipoPrenda.Properties.Columns[0].Visible = false;
        }

        public void Buscar()
        {
            //throw new NotImplementedException();
        }
        public void Eliminar()
        {
            //throw new NotImplementedException();
        }

        public void Nuevo()
        {
            Guardado = false;
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            var clientes = new EmpeñosDC(new clsConeccionDB().StringConn()).Boletas.Select(c => new { c.Cliente });
            foreach (var lugar in clientes)
            {
                lista.Add(lugar.Cliente);
            }

            txtNomCliente.MaskBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtNomCliente.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtNomCliente.MaskBox.AutoCompleteCustomSource = lista;
            new ManejadorControles().LimpiarControles(gpoContenedor);
            new ManejadorControles().DesectivarTextBox(this, true);
            txtNomCliente.Focus();
            cboTipoPrenda.EditValue = cboTipoPrenda.Properties.GetDataSourceValue(cboTipoPrenda.Properties.ValueMember, 0);
            _dtprenda.Rows.Clear();
            dtpFechaPago.DateTime = dtpFechaEmpeño.DateTime.AddMonths(1);
            txtFolioBoleta.EditValue = ObtenerUltimoFolio();
        }
        private string ObtenerUltimoFolio()
        {
            try
            {
                var fol =
                    new EmpeñosDC(new clsConeccionDB().StringConn()).Boletas.OrderByDescending(b => b.IDBoleta)
                        .FirstOrDefault();
                int ult;
                if (fol == null)
                    ult = 1;
                else
                    ult = fol.IDBoleta + 1;
                if (ult <= 25000)
                    return (ult).ToString().PadLeft(5, '0');
                if (ult > 25000 && ult <= 50000)
                    return "A" + (ult - 25000).ToString().PadLeft(5, '0');
                if (ult > 50000 && ult <= 75000)
                    return "B" + (ult - 50000).ToString().PadLeft(5, '0');
                if (ult > 75000 && ult <= 100000)
                    return "C" + (ult - 75000).ToString().PadLeft(5, '0');
                if (ult > 75000 && ult <= 100000)
                    return "D" + (ult - 100000).ToString().PadLeft(5, '0');
                if (ult > 100000 && ult <= 125000)
                    return "E" + (ult - 125000).ToString().PadLeft(5, '0');
                if (ult > 125000 && ult <= 150000)
                    return "F" + (ult - 150000).ToString().PadLeft(5, '0');
                if (ult > 150000 && ult <= 175000)
                    return "G" + (ult - 175000).ToString().PadLeft(5, '0');
                if (ult > 175000 && ult <= 200000)
                    return "H" + (ult - 200000).ToString().PadLeft(5, '0');
                if (ult > 200000 && ult <= 225000)
                    return "1" + (ult - 225000).ToString().PadLeft(5, '0');
                if (ult > 225000 && ult <= 250000)
                    return "J" + (ult - 250000).ToString().PadLeft(5, '0');
                if (ult > 250000 && ult <= 275000)
                    return "K" + (ult - 275000).ToString().PadLeft(5, '0');
                if (ult > 275000 && ult <= 300000)
                    return "L" + (ult - 300000).ToString().PadLeft(5, '0');
                if (ult > 300000 && ult <= 325000)
                    return "M" + (ult - 325000).ToString().PadLeft(5, '0');
                if (ult > 325000 && ult <= 350000)
                    return "N" + (ult - 350000).ToString().PadLeft(5, '0');
                if (ult > 350000 && ult <= 375000)
                    return "0" + (ult - 375000).ToString().PadLeft(5, '0');
                if (ult > 375000 && ult <= 400000)
                    return "P" + (ult - 400000).ToString().PadLeft(5, '0');
                if (ult > 400000 && ult <= 425000)
                    return "Q" + (ult - 425000).ToString().PadLeft(5, '0');
                if (ult > 425000 && ult <= 450000)
                    return "R" + (ult - 450000).ToString().PadLeft(5, '0');
                if (ult > 450000 && ult <= 475000)
                    return "S" + (ult - 475000).ToString().PadLeft(5, '0');
                if (ult > 475000 && ult <= 400000)
                    return "T" + (ult - 500000).ToString().PadLeft(5, '0');
                return "00001";
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
                return null;
            }
        }
        private decimal CalcularInteres()
        {
            try
            {
                var interes = Convert.ToDecimal(new clsModificarConfiguracion().configGetValue("Interes"));
                decimal num = Convert.ToDecimal(txtPrestamo.EditValue) * (interes / 100);
                return decimal.Round(num, 1);
            }
            catch (FormatException exception)
            {
                XtraMessageBox.Show(exception.Message);
                return 0M;
            }
        }
        private void CalcularAvaluo()
        {
            if (cboTipoPrenda.EditValue != null && Convert.ToDecimal(cboTipoPrenda.EditValue) < 9)
            {
                decimal precio =
                    new EmpeñosDC(new clsConeccionDB().StringConn()).Precios.Single(
                        p => p.Tipo == cboTipoPrenda.Text).Empeño;
                txtAvaluo.EditValue = precio *
                                      Convert.ToDecimal(txtPesoEmpenio.EditValue);
            }
            else
            {
                txtAvaluo.EditValue = 0;
                txtAvaluo.Properties.ReadOnly = false;
            }
        }
        public string nombrePantalla
        {
            get
            {
                return "Empeños";
            }
        }
        private void txtPesoEmpenio_EditValueChanged(object sender, EventArgs e)
        {
            CalcularAvaluo();
        }

        private void txtPrestamo_EditValueChanged(object sender, EventArgs e)
        {
            txtInteres.EditValue = CalcularInteres();
        }

        private void btnAgregarPrenda_Click(object sender, EventArgs e)
        {
            if (txtPrenda.Text.Trim() == string.Empty || Convert.ToDecimal(txtAvaluo.EditValue) == 0M)
            {
                if (txtPrenda.Text.Trim() == string.Empty)
                    XtraMessageBox.Show("Debe indicar la descripción del Artículo", "Descripcion Requerida");
                return;
            }
            _dtprenda.Rows.Add(new[] { txtPrenda.Text, txtPesoEmpenio.EditValue, cboTipoPrenda.Text, txtAvaluo.EditValue });
            new ManejadorControles().LimpiarControles(txtPesoEmpenio);
            new ManejadorControles().LimpiarControles(txtPrenda);
            cboTipoPrenda.EditValue = cboTipoPrenda.Properties.GetDataSourceValue(cboTipoPrenda.Properties.ValueMember, 0);
            txtPrenda.Focus();
            txtPrestamo.EditValue = _dtprenda.Rows.Cast<DataRow>().Aggregate<DataRow, decimal>(0M, (current, row) => current + (decimal)row["Avaluo"]);
        }

        private void cboTipoPrenda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTipoPrenda.EditValue != null && Convert.ToDecimal(cboTipoPrenda.EditValue) < 9){
                CalcularAvaluo();
                txtAvaluo.Properties.ReadOnly = true;
                txtPesoEmpenio.Properties.ReadOnly = false;
            }
            else
            {
                txtAvaluo.EditValue = 0M;
                txtPesoEmpenio.EditValue = 1M;
                txtPesoEmpenio.Properties.ReadOnly = true;
                txtAvaluo.Properties.ReadOnly = false;
            }
        }

        private void grvPrendas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && grvPrendas.FocusedRowHandle > -1)//&& e.Modifiers == Keys.Control)
            {
                if (XtraMessageBox.Show("Desea Eliminar la Prenda?", "Confirmación", MessageBoxButtons.YesNo) ==
                  DialogResult.Yes)
                    grvPrendas.DeleteRow(grvPrendas.FocusedRowHandle);

            }
            txtPrestamo.EditValue = _dtprenda.Rows.Cast<DataRow>().Aggregate<DataRow, decimal>(0M, (current, row) => current + (decimal)row["Avaluo"]);
        }

        private void txtPrestamo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal avaluo = _dtprenda.Rows.Cast<DataRow>().Aggregate<DataRow, decimal>(0M, (current, row) => current + (decimal)row["Avaluo"]);
            if (Convert.ToDecimal(e.NewValue) <= avaluo) return;
            XtraMessageBox.Show("El Prestamo no puede ser mayor que el ávaluo", "Prestamo Mayor");
            e.Cancel = true;

        }

        private void subEliminarPrenda_Click(object sender, EventArgs e)
        {
            if (grvPrendas.FocusedRowHandle < 0) return;
            if (XtraMessageBox.Show("Desea Eliminar la Prenda?", "Confirmación", MessageBoxButtons.YesNo) ==
                  DialogResult.Yes)
                grvPrendas.DeleteRow(grvPrendas.FocusedRowHandle);
            txtPrestamo.EditValue = _dtprenda.Rows.Cast<DataRow>().Aggregate<DataRow, decimal>(0M, (current, row) => current + (decimal)row["Avaluo"]);
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Guardado)
                    Guardar();
                else
                {
                    Boleta boleta = new LogicaBoletas().ObtenerBoleta(txtFolioBoleta.Text);
                    XrptBoleta rptboleta = new XrptBoleta { DatosInForme = { DataSource = boleta } };
                    rptboleta.Print(new clsModificarConfiguracion().configGetValue("ImpresoraBoletas"));
                }
            }
            catch (ValidationException ex)
            {
                XtraMessageBox.Show(ex.Message, "Validando Datos");
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message);
            }
        }
        public void Guardar()
        {

            if (ClsVerificarCaja.CajaEstado())
            {
                if (ClsVerificarCaja.SaldoEnCaja() >= Convert.ToDecimal(txtPrestamo.EditValue))
                {
                    
                        Boleta entity = new Boleta
                            {

                                Articulos = Articulos(),
                                Cliente = txtNomCliente.Text,
                                Cotitular = txtCotitular.Text,
                                FechaPrestamo = Convert.ToDateTime(dtpFechaEmpeño.DateTime.Date),
                                Pagado = false,
                                Folio = txtFolioBoleta.Text = ObtenerUltimoFolio(),
                                PesoEmpeño = _dtprenda.Rows.Cast<DataRow>().Aggregate<DataRow, decimal>(0M, (current, row) => current + (decimal)row["PesoCantidad"]),
                                TipoEmpeño = SacarTipos(),
                                Prestamo = Convert.ToDecimal(txtPrestamo.EditValue),
                                Interes = Convert.ToDecimal(txtInteres.EditValue),
                                FechaPago = Convert.ToDateTime(dtpFechaPago.DateTime.Date),
                                EstadoBoleta = "Vigente",
                                CveUsuario = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioApp"))
                            };
                        new LogicaBoletas().AgregarBoleta(entity);
                        Guardado = true;
                        GuardarDetalle();
                        XrptBoleta boleta = new XrptBoleta { DatosInForme = { DataSource = entity } };
                    //boleta.ShowPreviewDialog();    
                    boleta.Print(new clsModificarConfiguracion().configGetValue("ImpresoraBoletas"));
                        Guardado = true;
                    
                }
                else
                {
                    XtraMessageBox.Show("No prestar  mas de lo disponible en la CAJA Actual");
                }
            }
            else
            {
                XtraMessageBox.Show("La Caja del Dia de hoy ya se ha cerrado\n SISTEMA BLOQUEADO", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            SendKeys.Send("{TAB}");
        }

        private string SacarTipos()
        {
            string tipo = "";
            foreach (DataRow det in _dtprenda.Rows)
            {
                string nstring;
                switch (det["Tipo"].ToString())
                {
                    case "Oro 10Kt Rojo":
                        nstring = det["Tipo"].ToString().Substring(4, 4) + "R";
                        break;
                    case "Oro 10Kt Amarillo":
                        nstring = det["Tipo"].ToString().Substring(4, 4) + "A";
                        break;
                    case "Oro 14Kt":
                        nstring = det["Tipo"].ToString().Substring(4, 4);
                        break;
                    case "Oro 18Kt":
                        nstring = det["Tipo"].ToString().Substring(4, 4);
                        break;
                    case "Oro 22Kt":
                        nstring = det["Tipo"].ToString().Substring(4, 4);
                        break;
                    case "Oro 24Kt":
                        nstring = det["Tipo"].ToString().Substring(4, 4);
                        break;
                    default:
                        nstring = det["Tipo"].ToString();
                        break;
                }
                tipo = tipo + nstring + ";";

            }
            return tipo;
        }

        private string SacarTipo(string tipo)
        {
            string nstring;
            switch (tipo)
            {
                case "Oro 10Kt Rojo":
                    nstring = tipo.Substring(4, 4) + "R";
                    break;
                case "Oro 10Kt Amarillo":
                    nstring = tipo.Substring(4, 4) + "A";
                    break;
                case "Oro 14Kt":
                    nstring = tipo.Substring(4, 4);
                    break;
                case "Oro 18Kt":
                    nstring = tipo.Substring(4, 4);
                    break;
                case "Oro 22Kt":
                    nstring = tipo.Substring(4, 4);
                    break;
                case "Oro 24Kt":
                    nstring = tipo.Substring(4, 4);
                    break;
                default:
                    nstring = tipo;
                    break;
            }
            return nstring;
        }

        private void GuardarDetalle()
        {
            foreach (Prenda p in from DataRow prenda in _dtprenda.Rows
                                 select new Prenda
                                     {
                                         Descripcion = prenda[0].ToString(),
                                         Peso = Convert.ToDecimal(prenda[1]),
                                         Tipo = prenda[2].ToString(),
                                         Avaluo = Convert.ToDecimal(prenda[3]),
                                         Estado = "Empeño"
                                     })
            {
                _entidades.Prendas.InsertOnSubmit(p);
                _entidades.SubmitChanges();
                DetallesBoleta db = new DetallesBoleta
                {
                    Folio = txtFolioBoleta.Text,
                    CvePrenda = p.Clave,
                };
                _entidades.DetallesBoletas.InsertOnSubmit(db);
                _entidades.SubmitChanges();
            }
        }

        private string Articulos()
        {
            return _dtprenda.Rows.Cast<DataRow>().Aggregate(string.Empty, (current, prenda) => String.Format("{0}{1} {2} {3}; ", current, prenda[0], prenda[1], SacarTipo(prenda[2].ToString())));
        }
    }
}