using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;
using SoftEmpenios.LogicaNegocios;

namespace SoftEmpenios.Pantallas
{
    public partial class FrmCompras : XtraForm, iPantalla
    {
        readonly DataTable _dtprecios = new DataTable("Precios");
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        private readonly DataTable _dtArticulos = new DataTable();
        public FrmCompras()
        {
            InitializeComponent();
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

            var precios = new EmpeñosDC(new clsConeccionDB().StringConn()).Precios.Select(p => new { p.Tipo, PrecioGr = p.Compra });

            foreach (var pre in precios)
            {
                _dtprecios.Rows.Add(new object[] { null, pre.Tipo, pre.PrecioGr });
            }
            _dtprecios.Rows.Add(new object[] { null, "Dolares", _entidades.Configuraciones.First().PrecioCompraDolar });
            cboTipoPrenda.Properties.DataSource = _dtprecios;
            cboTipoPrenda.Properties.DisplayMember = "Tipo";
            cboTipoPrenda.Properties.ValueMember = "Clave";
            
            _dtArticulos.Columns.Add("TipoCompra", Type.GetType("System.String"));
            _dtArticulos.Columns.Add("PesoCantidad", Type.GetType("System.Decimal"));
            _dtArticulos.Columns.Add("PrecioCompra", Type.GetType("System.Decimal"));
            _dtArticulos.Columns.Add("ImporteArticulo", Type.GetType("System.Decimal"));
            gridBusqueda.DataSource = _dtArticulos;
            grvResultado.Columns[1].DisplayFormat.FormatType = FormatType.Numeric;
            grvResultado.Columns[1].DisplayFormat.FormatString = "###.##";
            grvResultado.Columns[2].DisplayFormat.FormatType = FormatType.Numeric;
            grvResultado.Columns[2].DisplayFormat.FormatString = "$ #,##0.00";
            grvResultado.Columns[3].DisplayFormat.FormatType = FormatType.Numeric;
            grvResultado.Columns[3].DisplayFormat.FormatString = "$ #,##0.00";
        }

        public void Buscar()
        {
            //throw new NotImplementedException();
        }

        public void Eliminar()
        {
            //throw new NotImplementedException();
        }

        public void Guardar()
        {
            try
            {

           
            if (ClsVerificarCaja.CajaEstado())
            {
                if (ClsVerificarCaja.SaldoEnCaja() >= Convert.ToDecimal(txtTotalCompra.EditValue))
                    {
                        if ((int)txtCveCompra.EditValue == 0)
                        {
                            Compra entity = new Compra
                            {
                                CveUsuario = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioApp")),
                                TotalCompra = Convert.ToDecimal(txtTotalCompra.EditValue),
                                FechaCompra = DateTime.Today.Date,
                                Estado = true
                            };
                            txtCveCompra.EditValue = new LogicaCompras().AgregarCompra(entity);
                            foreach (DataRow fila in _dtArticulos.Rows)
                            {
                                DetallesCompra detcomp = new DetallesCompra
                                    {
                                        CveCompra = entity.CveCompra,
                                        PesoCantidad = Convert.ToDecimal(fila[1]),
                                        TipodeCompra = fila[0].ToString(),
                                        PrecioCompra = Convert.ToDecimal(fila[2]),
                                        TotalPrecioArticulo = Convert.ToDecimal(fila[3]),
                                    };
                                new LogicaCompras().AgregarDetalle(detcomp);
                            }
                            ImprimirNotaCompra();
                        }
                        else
                        {
                            XtraMessageBox.Show("Ya se ha Guardado la compra solo se puede Imprimir el Ticket ", "Datos Guardados");
                            ImprimirNotaCompra();
                        }
                        //Nuevo();
                    }
                    else
                    {
                        XtraMessageBox.Show("No puede Comprar mas de lo disponible en la CAJA Actual");
                    }
            }
            else
            {
                XtraMessageBox.Show("La Caja del Dia de hoy ya se ha cerrado\n SISTEMA BLOQUEADO", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message,"Error al Guardar la compra");
            }
        }

        private void ImprimirNotaCompra()
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

            Ticket ticket = new Ticket(5);
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
            ticket.AddHeaderLine("             TICKET DE VENTA            ");
            Usuario usu = new EmpeñosDC(new clsConeccionDB().StringConn()).Usuarios.Single(u => u.CveUsuario == Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioApp")));
            ticket.AddSubHeaderLine("ATENDIO: " + usu.Nombre);
            ticket.AddSubHeaderLine("FOLIO COMPRA: " + txtCveCompra.Text);
            ticket.AddSubHeaderLine(String.Format("FECHA VENTA: {0} {1}", DateTime.Today.ToString("dd/MMM/yyyy"), DateTime.Now.ToShortTimeString()));

            foreach (DataRow pRow in _dtArticulos.Rows)
            {
                ticket.AddItem(pRow[1].ToString(),SacarTipo( pRow[0].ToString()), Convert.ToDecimal(pRow[2]).ToString("C"), Convert.ToDecimal(pRow[3]).ToString("C"),"");
            }
            ticket.AddTotal("TOTAL VENTA: ",Convert.ToDecimal(txtTotalCompra.EditValue).ToString("C"));
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.PrintTicket(new clsModificarConfiguracion().configGetValue("ImpresoraTickets"));
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


        public void Nuevo()
        {
           _dtArticulos.Rows.Clear();
            new ManejadorControles().LimpiarControles(gpoContenedor);
            cboTipoPrenda.EditValue = cboTipoPrenda.Properties.GetDataSourceValue(cboTipoPrenda.Properties.ValueMember, 0);
            cboTipoPrenda.Focus();
        }

        public string nombrePantalla
        {
            get
            {
                return "Compras";
            }
        }

        private void btnAgregarPrenda_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtAvaluo.EditValue) == 0M) return;
            if (cboTipoPrenda.Text == "Dolares")
            {
                decimal precio =
                   new EmpeñosDC(new clsConeccionDB().StringConn()).Configuraciones.First().PrecioCompraDolar;
                _dtArticulos.Rows.Add(new[]
                {cboTipoPrenda.Text, txtPesoEmpenio.EditValue,precio , txtAvaluo.EditValue});
            }
            else
            {
                decimal precio =
                    new EmpeñosDC(new clsConeccionDB().StringConn()).Precios.First(
                        p => p.Tipo == cboTipoPrenda.Text).Compra;
                _dtArticulos.Rows.Add(new[] {cboTipoPrenda.Text, txtPesoEmpenio.EditValue, precio, txtAvaluo.EditValue});
            }

            new ManejadorControles().LimpiarControles(txtPesoEmpenio);
            cboTipoPrenda.EditValue = cboTipoPrenda.Properties.GetDataSourceValue(cboTipoPrenda.Properties.ValueMember, 0);
            cboTipoPrenda.Focus();
            txtTotalCompra.EditValue = _dtArticulos.Rows.Cast<DataRow>().Aggregate<DataRow, decimal>(0M, (current, row) => current + (decimal)row["ImporteArticulo"]);
        }

        private void txtPesoEmpenio_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTipoPrenda.Text == "Dolares")
            {
                txtAvaluo.EditValue = _entidades.Configuraciones.First().PrecioCompraDolar * Convert.ToDecimal(txtPesoEmpenio.EditValue);
                return;
            }
            decimal precio =
                    new EmpeñosDC(new clsConeccionDB().StringConn()).Precios.Single(
                        p => p.Tipo == cboTipoPrenda.Text).Compra;
            txtAvaluo.EditValue = precio *
                                  Convert.ToDecimal(txtPesoEmpenio.EditValue);
        }

        private void grvResultado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && grvResultado.FocusedRowHandle > -1)//&& e.Modifiers == Keys.Control)
            {
                if (XtraMessageBox.Show("Desea Eliminar la Prenda?", "Confirmación", MessageBoxButtons.YesNo) ==
                  DialogResult.Yes)
                    grvResultado.DeleteRow(grvResultado.FocusedRowHandle);

            }
            txtTotalCompra.EditValue = _dtArticulos.Rows.Cast<DataRow>().Aggregate<DataRow, decimal>(0M, (current, row) => current + (decimal)row["ImporteArticulo"]);
        }

        private void botonGuardarCompra_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void FrmCompras_Shown(object sender, EventArgs e)
        {
            cboTipoPrenda.Properties.PopulateColumns();
            cboTipoPrenda.Properties.Columns[0].Visible = false;
            Nuevo();
        }

        private void cboTipoPrenda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTipoPrenda.EditValue==null)
                return;
            if (cboTipoPrenda.Text == "Dolares")
            {
                txtAvaluo.EditValue = _entidades.Configuraciones.First().PrecioCompraDolar * Convert.ToDecimal(txtPesoEmpenio.EditValue);
                return;
            }
            decimal precio =
                    new EmpeñosDC(new clsConeccionDB().StringConn()).Precios.Single(
                        p => p.Tipo == cboTipoPrenda.Text).Compra;
            txtAvaluo.EditValue = precio *
                                  Convert.ToDecimal(txtPesoEmpenio.EditValue);}
    }
}
