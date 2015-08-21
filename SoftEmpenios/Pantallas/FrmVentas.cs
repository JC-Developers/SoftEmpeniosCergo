using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoftEmpenios.Clases;
using SoftEmpenios.Dialogos;
using SoftEmpenios.DBComun;
using System.ComponentModel.DataAnnotations;
using SoftEmpenios.LogicaNegocios;

namespace SoftEmpenios.Pantallas
{
    public partial class FrmVentas : Form, iPantalla
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        readonly DataTable _dtartic = new DataTable("articulos");
        public FrmVentas()
        {
            InitializeComponent();
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

        public void Buscar()
        {

        }
        public void Eliminar()
        {
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
                if ((int)txtCveVenta.EditValue== 0)
                {
                    Venta entity = new Venta
                    {
                        Cliente = txtCliente.Text,
                        TipoVenta = cboTipoVenta.Text,
                        FechaVenta = Convert.ToDateTime(dtpFechaVenta.EditValue),
                        TotalVenta = Convert.ToDecimal(txtTotalVenta.EditValue),
                        Enganche = Convert.ToDecimal(txtEnganche.EditValue),
                        Saldo = Convert.ToDecimal(txtSaldo.EditValue),
                        Estado = (cboTipoVenta.SelectedIndex == 0) ? "Pagado" : "Apartado",
                        CveUsuario = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioApp")),
                    };
                    txtCveVenta.EditValue = new LogicaVentas().InsertarVenta(entity);
                    foreach (DataRow t in _dtartic.Rows)
                    {
                        DetalleVenta detVenta = new DetalleVenta
                        {
                            CveVenta = Convert.ToInt32(txtCveVenta.EditValue),
                            CveArticulo = Convert.ToInt32(t["Clave"]),
                            PrecioCompra = Convert.ToDecimal(t["Precio"]),
                        };
                        new LogicaVentas().GuardarDetalleVenta(detVenta,(cboTipoVenta.SelectedIndex == 0) ? "Vendido" : "Apartado");
                    }
                    ImprimirTicketsVenta();
                        // (from vent in base.mapeoCasaEmpenios.BoletasDC select vent.Folio).Max<int>().ToString();
                    new ManejadorControles().DesectivarTextBox(gpoContenedor, true);

                }
                else
                {
                    XtraMessageBox.Show("Ya se ha guardado la Venta solo se puede Imprimir el Ticket ",
                        "Datos Guardados");
                    ImprimirTicketsVenta();
                }
            }
            catch (ValidationException vex)
            {
                XtraMessageBox.Show(vex.Message, "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Validación de Datos");
            }
        }
        public void Nuevo()
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            var clientes = new EmpeñosDC(new clsConeccionDB().StringConn()).Ventas.Select(c => new { c.Cliente });
            foreach (var lugar in clientes)
            {
                lista.Add(lugar.Cliente);
            }

            txtCliente.MaskBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtCliente.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCliente.MaskBox.AutoCompleteCustomSource = lista;
            _dtartic.Rows.Clear();
            new ManejadorControles().LimpiarControles(gpoContenedor);
            new ManejadorControles().DesectivarTextBox(gpoContenedor, true);
            cboTipoVenta.SelectedIndex = 0;
            txtCliente.Focus();
            
        }
       
        public string nombrePantalla
        {
            get
            {
                return "Ventas";
            }
        }

        #endregion

        private void frmVentas_Load(object sender, EventArgs e)
        {
            _dtartic.Columns.Add("Clave", Type.GetType("System.Int32"));//1
            _dtartic.Columns.Add("Descripcion", Type.GetType("System.String"));//2
            _dtartic.Columns.Add("Peso", Type.GetType("System.String"));//3
            _dtartic.Columns.Add("Tipo", Type.GetType("System.String"));//4
            _dtartic.Columns.Add("Precio", Type.GetType("System.Decimal"));//5
            gridArticulosVenta.DataSource = _dtartic;
            Nuevo();
        }
        private void botonAgregarArticulo_Click(object sender, EventArgs e)
        {
            FrmBuscar articulo = new FrmBuscar();
            articulo.CriteriosDeBusqueda("Articulos");
            articulo.DevolverString += Resultado_Devuelto;
            articulo.ShowDialog(this);
            articulo.DevolverString -= Resultado_Devuelto;
            articulo.Close();
        }
        public void Resultado_Devuelto(string cveArticulo)
        {
            try
            {
                Articulo articulo = _entidades.Articulos.Single(a=>a.Clave==Convert.ToInt32(cveArticulo));
                DataRow filaarticulos = _dtartic.NewRow();
                if (_dtartic.Rows.Count>0)
                {
                    for (int c = 0; c < _dtartic.Rows.Count; c++)
                    {
                        if (articulo.Clave == Convert.ToInt32(_dtartic.Rows[c]["Clave"]))
                        {

                            MessageBox.Show("Ya hay en lista de venta el articulo seleccionado");
                            break;
                        }
                        if (c == _dtartic.Rows.Count - 1)
                        {
                            filaarticulos[0] = articulo.Clave;
                            filaarticulos[1] = articulo.Descripcion;
                            filaarticulos[2] = articulo.Peso;
                            filaarticulos[3] = articulo.Kilates;

                            filaarticulos[4] = (cboTipoVenta.SelectedIndex == 0) ? articulo.Precio : articulo.PrecioCredito;//[1]es la columna y [0]es la fila
                            _dtartic.Rows.Add(filaarticulos);
                            break;
                        }
                    }
                }
                else
                {
                    filaarticulos[0] = articulo.Clave;
                    filaarticulos[1] = articulo.Descripcion;
                    filaarticulos[2] = articulo.Peso;
                    filaarticulos[3] = articulo.Kilates;
                    filaarticulos[4] = (cboTipoVenta.SelectedIndex == 0) ? articulo.Precio : articulo.PrecioCredito;
                    _dtartic.Rows.Add(filaarticulos);
                }
                CalcularTotalventa();
                
            }

            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message, "Error al Agregar articulo en la venta");
            }
        }

        private void CalcularTotalventa()
        {
            decimal totalVenta = _dtartic.Rows.Cast<DataRow>().Aggregate<DataRow, decimal>(0M, (current, row) => current + (decimal)row["Precio"]);
            txtTotalVenta.EditValue = totalVenta;
            CalcularSaldo();
        }
        void CalcularSaldo()
        {
            switch (cboTipoVenta.SelectedIndex)
            {
                case 1:
                    txtSaldo.EditValue = Convert.ToDecimal(txtTotalVenta.EditValue) - Convert.ToDecimal(txtEnganche.EditValue);
                    break;
                default:
                    txtSaldo.EditValue = 0M;
                    break;
            }
        }

        void ImprimirTicketsVenta()
        {
            _entidades.Connection.ConnectionString = new clsConeccionDB().StringConn();
            Configuracione empre = (from em in _entidades.Configuraciones
                                     select em).First();

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

            Ticket ticket = new Ticket(1);
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
            ticket.AddHeaderLine("            TICKET DE COMPRA             ");


            ticket.AddSubHeaderLine("COMPRA: # " + txtCveVenta.Text);
            Usuario usu = _entidades.Usuarios.First(u => u.CveUsuario == Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioApp")));
            ticket.AddSubHeaderLine("ATENDIO: " + usu.Nombre);
            ticket.AddSubHeaderLine("CLIENTE: " + txtCliente.Text);
            ticket.AddSubHeaderLine(String.Format("Fecha: {0} {1}", DateTime.Today.ToString("dd/MMM/yyyy"), DateTime.Now.ToShortTimeString()));

            for (int x = 0; x < _dtartic.Rows.Count; x++)
                ticket.AddItem(_dtartic.Rows[x][0].ToString(), _dtartic.Rows[x][1].ToString(), double.Parse(_dtartic.Rows[x][4].ToString()).ToString("C"));//; gridProductos.Rows[x].Cells[0].Value.ToString(), gridProductos.Rows[x].Cells[0].Value.ToString(), gridProductos.Rows[x].Cells[0].Value.ToString());
            ticket.AddTotal("TOTAL COMPRA ", double.Parse(txtTotalVenta.EditValue.ToString()).ToString("C"));
            if (cboTipoVenta.Text == "Apartado")
            {
                ticket.AddTotal("ENGANCHE ", double.Parse(txtEnganche.EditValue.ToString()).ToString("C"));
                ticket.AddTotal("SALDO ", double.Parse(txtSaldo.EditValue.ToString()).ToString("C"));
            }
            ticket.AddFooterLine("          GRACIAS POR SU COMPRA           ");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.AddFooterLine("");
            ticket.PrintTicket(new clsModificarConfiguracion().configGetValue("ImpresoraTickets"));
        }

        private void cboTipoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cboTipoVenta.SelectedIndex)
                {
                    case 0:
                        {
                            for (int x = 0; x < _dtartic.Rows.Count; x++)
                            {
                                Articulo articulo = _entidades.Articulos.Single(a=>a.Clave==Convert.ToInt32(_dtartic.Rows[x][0]));

                                _dtartic.Rows[x][4] = (articulo.Precio);

                            }
                            txtEnganche.EditValue = 0M;
                            txtEnganche.Properties.ReadOnly = true;
                            txtSaldo.EditValue = 0M;

                        }
                        break;
                    case 1:
                        {
                            for (int x = 0; x < _dtartic.Rows.Count; x++)
                            {
                                Articulo articulo = _entidades.Articulos.Single(a => a.Clave == Convert.ToInt32(_dtartic.Rows[x][0]));

                                _dtartic.Rows[x][4] = (articulo.PrecioCredito);

                            }
                            txtEnganche.EditValue = 0M;
                            txtEnganche.Properties.ReadOnly=false;
                        }
                        break;

                }
                CalcularTotalventa();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error al Agregar articulo en la venta");
            }
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void botonNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void txtEnganche_EditValueChanged(object sender, EventArgs e)
        {
            CalcularSaldo();
        }

        private void grvArticulos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && grvArticulos.FocusedRowHandle > -1)//&& e.Modifiers == Keys.Control)
            {
                if (XtraMessageBox.Show("Desea Eliminar el artículo?", "Confirmación", MessageBoxButtons.YesNo) ==
                  DialogResult.Yes)
                    grvArticulos.DeleteRow(grvArticulos.FocusedRowHandle);
                CalcularTotalventa();
            }
        }

        private void cmnuEliminar_Click(object sender, EventArgs e)
        {
            if (grvArticulos.FocusedRowHandle < 0) return;
            if (XtraMessageBox.Show("Desea Eliminar la Prenda?", "Confirmación", MessageBoxButtons.YesNo) ==
                  DialogResult.Yes)
                grvArticulos.DeleteRow(grvArticulos.FocusedRowHandle);
            CalcularTotalventa();
        }

        private void btnBuscarPrestamo_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
