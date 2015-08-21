using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SoftEmpenios.DBComun;
using SoftEmpenios.Clases;
using SoftEmpenios.Dialogos;
using DevExpress.Utils;
using System.ComponentModel.DataAnnotations;
using SoftEmpenios.Reportes;

namespace SoftEmpenios.Pantallas
{
    public partial class FrmFinanciamiento : Form, iPantalla
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        readonly DataTable _dtCronograma = new DataTable("Cotizacion");
        readonly DataTable _dtReferencias = new DataTable();
        int _cveTipoFinanciamiento;
        int _cveprestamo;
        public FrmFinanciamiento()
        {
            InitializeComponent();
            _dtCronograma.Columns.Add("Num", Type.GetType("System.Int32"));
            _dtCronograma.Columns.Add("Balance", Type.GetType("System.Decimal"));
            _dtCronograma.Columns.Add("Capital", Type.GetType("System.Decimal"));
            _dtCronograma.Columns.Add("Interes", Type.GetType("System.Decimal"));
            _dtCronograma.Columns.Add("PagoRegular", Type.GetType("System.Decimal"));
            _dtCronograma.Columns.Add("PagoAtrasado", Type.GetType("System.Decimal"));
            _dtCronograma.Columns.Add("FechaPago", Type.GetType("System.DateTime"));
            _dtReferencias.Columns.Add("Clave", Type.GetType("System.Int32"));
            _dtReferencias.Columns.Add("Rerefencia", Type.GetType("System.String"));
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
            new ManejadorControles().DesectivarTextBox(gpoContenedor, true);
            new ManejadorControles().LimpiarControles(gpoContenedor);
            txtNombre.Focus();
            _dtCronograma.Rows.Clear();
            _dtReferencias.Rows.Clear();
            dtpFechaPrestamo.DateTime = DateTime.Today.Date;
            txtTotalAPagar.EditValue = 0;
            txtPagoMensual.EditValue = 0;
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

        private void cboTipoFinanciamiento_SelectedIndexChanged(object sender, EventArgs e)
        {

            _dtCronograma.Rows.Clear();
            if (cboTipoFinanciamiento.EditValue == null)
                return;
            switch (cboTipoFinanciamiento.Text)
            {
                case "Hipotecario":
                    Financiamiento fH = _entidades.Financiamientos.Single(f => f.Tipo == cboTipoFinanciamiento.Text);
                    txtFolioFinanciamiento.EditValue = (_entidades.Prestamos.Count(f => f.Tipo == cboTipoFinanciamiento.Text) + 1);
                    txtPorcInteres.EditValue = fH.Interes;
                    txtProrroga.EditValue = fH.Prorroga;
                    txtPorcRecargo.EditValue = fH.Recargo;
                    lblEnganche.Visible = false;
                    lblPorcEnganche.Visible = false;
                    txtPorcEnganche.Visible = false;
                    txtEnganche.Visible = false;
                    txtEnganche.EditValue = 0;
                    CalcularPagoHipotecario();
                    _cveTipoFinanciamiento = fH.Clave;
                    break;
                case "AutoFinanciamiento":
                case "MotoFinanciamiento":
                    Financiamiento fA = _entidades.Financiamientos.Single(f => f.Tipo == "AutoFinanciamiento");
                    txtFolioFinanciamiento.EditValue = (_entidades.Prestamos.Count(f => f.Tipo == cboTipoFinanciamiento.Text) + 1);
                    txtPorcInteres.EditValue = fA.Interes;
                    txtProrroga.EditValue = fA.Prorroga;
                    txtPorcRecargo.EditValue = fA.Recargo;
                    txtPorcEnganche.EditValue = fA.Enganche;
                    lblEnganche.Visible = true;
                    lblPorcEnganche.Visible = true;
                    txtPorcEnganche.Visible = true;
                    txtEnganche.Visible = true;
                    decimal enganche = Convert.ToDecimal(txtCantidadFinancimiento.EditValue) * Convert.ToDecimal(txtPorcEnganche.EditValue);
                    txtEnganche.EditValue = enganche;
                    CalcularPagoAutoMoto();
                    _cveTipoFinanciamiento = fA.Clave;
                    break;
                case "Personal":
                    Financiamiento fP = _entidades.Financiamientos.Single(f => f.Tipo == cboTipoFinanciamiento.Text);
                    txtFolioFinanciamiento.EditValue = (_entidades.Prestamos.Count(f => f.Tipo == cboTipoFinanciamiento.Text) + 1);
                    txtPorcInteres.EditValue = fP.Interes;
                    txtProrroga.EditValue = fP.Prorroga;
                    txtPorcRecargo.EditValue = fP.Recargo;
                    lblEnganche.Visible = false;
                    lblPorcEnganche.Visible = false;
                    txtPorcEnganche.Visible = false;
                    txtEnganche.Visible = false;
                    txtEnganche.EditValue = 0;
                    CalcularPagoHipotecario();
                    _cveTipoFinanciamiento = fP.Clave;
                    break;
                case "Personal Fijo":
                    Financiamiento fPF = _entidades.Financiamientos.Single(f => f.Tipo == cboTipoFinanciamiento.Text);
                    txtFolioFinanciamiento.EditValue = (_entidades.Prestamos.Count(f => f.Tipo == cboTipoFinanciamiento.Text) + 1);
                    txtPorcInteres.EditValue = fPF.Interes;
                    txtProrroga.EditValue = fPF.Prorroga;
                    txtPorcRecargo.EditValue = fPF.Recargo;
                    lblEnganche.Visible = false;
                    lblPorcEnganche.Visible = false;
                    txtPorcEnganche.Visible = false;
                    txtEnganche.Visible = false;
                    txtEnganche.EditValue = 0;
                    CalcularPagoAutoMoto();
                    _cveTipoFinanciamiento = fPF.Clave;
                    break;
                default:
                    txtTotalAPagar.EditValue = null;
                    txtPagoMensual.EditValue = null;
                    break;
            }
        }

        private void botonAgregarReferencias_Click(object sender, EventArgs e)
        {
            FrmReferencias referencias = new FrmReferencias();
            referencias.EventDevolverClave += ReferenciaDevuelta;
            referencias.ShowDialog(this);
            referencias.EventDevolverClave -= ReferenciaDevuelta;
            referencias.Close();
        }
        void ReferenciaDevuelta(int clave)
        {
            Referencia rfD = _entidades.Referencias.Single(r => r.CveReferencia == clave);
            for (int i = 0; i < _dtReferencias.Rows.Count; i++)
            {
                if (rfD.CveReferencia == (int)_dtReferencias.Rows[i][0])
                {
                    MessageBox.Show("Ya se encuentra la referencia seleccionada", "Referencia Existente");
                    return;
                }
            }
            _dtReferencias.Rows.Add(new object[] { rfD.CveReferencia, rfD.Nombre });


        }

        private void txtCantidadFinancimiento_EditValueChanged(object sender, EventArgs e)
        {

            switch (cboTipoFinanciamiento.Text)
            {
                case "Hipotecario":
                    CalcularPagoHipotecario();

                    break;
                case "AutoFinanciamiento":
                case "MotoFinanciamiento":
                    decimal enganche = Convert.ToDecimal(txtCantidadFinancimiento.EditValue) * Convert.ToDecimal(txtPorcEnganche.EditValue);
                    txtEnganche.EditValue = enganche;
                    CalcularPagoAutoMoto();
                    break;
                case "Personal":
                    CalcularPagoHipotecario();
                    break;
                case "Personal Fijo":
                    CalcularPagoAutoMoto();
                    break;
                default:
                    txtTotalAPagar.EditValue = 0M;
                    txtPagoMensual.EditValue = 0M;
                    break;
            }
        }

        private void CalcularPagoHipotecario()
        {
            if (txtCantidadFinancimiento.EditValue == null)
                return;
            decimal interesPrestamo = Convert.ToDecimal(txtCantidadFinancimiento.EditValue) * Convert.ToDecimal(txtPorcInteres.EditValue);
            txtPagoMensual.EditValue = decimal.Round((Convert.ToDecimal(txtCantidadFinancimiento.EditValue) / Convert.ToInt32(txtMeses.EditValue) + interesPrestamo), 2);
            decimal totalpago = 0;
            _dtCronograma.Rows.Clear();
            for (int x = 1; x <= Convert.ToInt32(txtMeses.EditValue); x++)
            {
                DataRow fila = _dtCronograma.NewRow();
                fila[0] = x;
                fila[1] = (x == 1) ? Convert.ToDecimal(txtCantidadFinancimiento.EditValue) : Convert.ToDecimal((decimal)_dtCronograma.Rows[x - 2][1] - (decimal)_dtCronograma.Rows[x - 2][2]);
                fila[2] = (x == Convert.ToInt32(txtMeses.EditValue)) ? fila[1] : decimal.Round(Convert.ToDecimal(txtCantidadFinancimiento.EditValue) / Convert.ToInt32(txtMeses.EditValue), 2);
                fila[3] = decimal.Round(Convert.ToDecimal(fila[1]) * Convert.ToDecimal(txtPorcInteres.EditValue), 2);
                fila[4] = decimal.Round(Convert.ToDecimal((decimal)fila[2] + (decimal)fila[3]), 2);
                fila[5] = decimal.Round((decimal)fila[4] + ((decimal)fila[1] * (decimal)txtPorcRecargo.EditValue), 2);
                fila[6] = dtpFechaPrestamo.DateTime.AddMonths(x);
                _dtCronograma.Rows.Add(fila);
                totalpago += Convert.ToDecimal(fila[4]);

            }
            txtTotalAPagar.EditValue = totalpago;
        }
        private void CalcularPagoAutoMoto()
        {
            if (txtCantidadFinancimiento.EditValue == null || cboTipoFinanciamiento.Text == string.Empty)
                return;
            decimal cantidadFinanciar = (Convert.ToDecimal(txtCantidadFinancimiento.EditValue) - Convert.ToDecimal(txtEnganche.EditValue));
            decimal interesPrestamo = cantidadFinanciar * Convert.ToDecimal(txtPorcInteres.EditValue);

            txtPagoMensual.EditValue = decimal.Round((cantidadFinanciar / Convert.ToInt32(txtMeses.EditValue) + interesPrestamo), 2);
            decimal totalpago = 0;
            _dtCronograma.Rows.Clear();

            for (int x = 1; x <= Convert.ToInt32(txtMeses.EditValue); x++)
            {
                DataRow fila = _dtCronograma.NewRow();
                fila[0] = x;
                fila[1] = (x == 1) ? cantidadFinanciar : Convert.ToDecimal((decimal)_dtCronograma.Rows[x - 2][1] - (decimal)_dtCronograma.Rows[x - 2][2]);
                fila[2] = (x == Convert.ToInt32(txtMeses.EditValue)) ? fila[1] : decimal.Round(cantidadFinanciar / Convert.ToInt32(txtMeses.EditValue), 2);
                fila[3] = decimal.Round(cantidadFinanciar * Convert.ToDecimal(txtPorcInteres.EditValue), 2);
                fila[4] = decimal.Round(Convert.ToDecimal((decimal)fila[2] + (decimal)fila[3]), 2);
                fila[5] = decimal.Round((decimal)fila[4] + (cantidadFinanciar * (decimal)txtPorcRecargo.EditValue), 2);
                fila[6] = dtpFechaPrestamo.DateTime.AddMonths(x);
                _dtCronograma.Rows.Add(fila);
                totalpago += Convert.ToDecimal(fila[4]);

            }
            txtTotalAPagar.EditValue = totalpago;
        }
        private void txtEnganche_EditValueChanged(object sender, EventArgs e)
        {

            CalcularPagoAutoMoto();
        }

        private void botonCronograma_Click(object sender, EventArgs e)
        {
            FrmCronograma cro = new FrmCronograma { Tipo = "Cronograma", DtCronos = _dtCronograma };
            cro.ShowDialog(this);
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ClsVerificarCaja.CajaEstado())
                {
                    MessageBox.Show("La Caja del Dia de hoy ya se ha cerrado\n SISTEMA BLOQUEADO", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                if (_cveprestamo > 0)
                {
                    if (
                        MessageBox.Show("El Prestamo se ha registrado desea volver a Imprimir documentos", "Reimpresión",
                                        MessageBoxButtons.YesNo) !=
                        DialogResult.Yes)
                    {
                        ImprimirDocumentos();
                        return;
                    }
                }
                if (ClsVerificarCaja.SaldoEnCaja() >
                    ((decimal)txtCantidadFinancimiento.EditValue + Convert.ToDecimal(txtEnganche.EditValue)))
                {
                    Prestamo pres = new Prestamo
                        {
                            CveCliente = GuadarCliente(),
                            CveTipoFinancimiento = _cveTipoFinanciamiento,
                            FolioFinanciamiento = Convert.ToInt32(txtFolioFinanciamiento.EditValue),
                            Cantidad = Convert.ToDecimal(txtCantidadFinancimiento.EditValue),
                            Enganche = Convert.ToDecimal(txtEnganche.EditValue),
                            Saldo =
                                Convert.ToDecimal(txtCantidadFinancimiento.EditValue) -
                                Convert.ToDecimal(txtEnganche.EditValue),
                            CveUsuario = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IdUsuarioApp")),
                            FechaPrestamo = dtpFechaPrestamo.DateTime,
                            Tipo = cboTipoFinanciamiento.Text,
                            Observacion = txtObservacion.Text,
                            Interes = Convert.ToDecimal(txtPorcInteres.EditValue),
                            Recargo = Convert.ToDecimal(txtPorcRecargo.EditValue),
                            Meses = Convert.ToInt32(txtMeses.EditValue),
                            Estado = "Vigente",
                        };
                    _cveprestamo = new LogicaNegocios.LogicaPrestamos().AgregarPrestamo(pres);
                    if (_dtReferencias.Rows.Count > 0)
                        GuardarReferencias(_cveprestamo);
                    MessageBox.Show("Prestamo Guardado", Application.ProductName);
                    new ManejadorControles().DesectivarTextBox(gpoContenedor, false);
                    ImprimirDocumentos();
                }
                else
                    MessageBox.Show("Lo disponible en caja es menor a lo que desea financiar", Application.ProductName);
            }
            catch (ValidationException vex)
            {
                MessageBox.Show(vex.Message, "Validación de datos");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }
        private void ImprimirDocumentos()
        {
            if (_dtCronograma.Rows.Count > 0)
            {
                XrptAutoFinanciamiento coti = new XrptAutoFinanciamiento();
                for (int i = 0; i < _dtCronograma.Rows.Count; i++)
                {
                    coti.cotizacion.Tables[0].ImportRow(_dtCronograma.Rows[i]);
                }
                coti.Parameters["CvePrestamo"].Value = _cveprestamo;
                coti.ShowPreviewDialog();

            }
        }

        private void GuardarReferencias(int cveprestamos)
        {
            for (int i = 0; i < _dtReferencias.Rows.Count; i++)
            {
                DetalleReferenciasPrestamo dtRef = new DetalleReferenciasPrestamo
                {
                    CvePrestamo = cveprestamos,
                    CveReferencia = (int)_dtReferencias.Rows[i][0],
                };
                _entidades.DetalleReferenciasPrestamos.InsertOnSubmit(dtRef);

            }
            _entidades.SubmitChanges();
        }

        private int GuadarCliente()
        {
            if ((int)txtCveCliente.EditValue == 0)
            {
                Cliente cli = new Cliente
                {
                    Nombre = txtNombre.Text,
                    Direccion = txtDireccion.Text,
                    Poblacion = txtPoblacion.Text,
                    Telefono = txtTelefono.Text,
                    Celular = txtCelular.Text
                };

                txtCveCliente.EditValue = new LogicaNegocios.LogicaClientes().AgregarCliente(cli);
                return cli.CveCliente;
            }
            Cliente cliOri = _entidades.Clientes.Single(cl => cl.CveCliente == (int)txtCveCliente.EditValue);
            Cliente cliMod = new Cliente
                {
                    CveCliente = cliOri.CveCliente,
                    Nombre = txtNombre.Text,
                    Direccion = txtDireccion.Text,
                    Poblacion = txtPoblacion.Text,
                    Telefono = txtTelefono.Text,
                    Celular = txtCelular.Text
                };
            new LogicaNegocios.LogicaClientes().ModificarCliente(cliMod, cliOri);
            return cliOri.CveCliente;

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmBuscar buscli = new FrmBuscar();
            buscli.CriteriosDeBusqueda("Clientes");
            buscli.DevolverString += ClienteEncontrado;
            buscli.ShowDialog(this);
            buscli.DevolverString += ClienteEncontrado;
        }
        private void ClienteEncontrado(string clave)
        {
            Cliente cli = _entidades.Clientes.First(cl => cl.CveCliente == Convert.ToInt32(clave));
            txtCveCliente.EditValue = cli.CveCliente;
            txtNombre.EditValue = cli.Nombre;
            txtDireccion.EditValue = cli.Direccion;
            txtPoblacion.EditValue = cli.Poblacion;
            txtTelefono.EditValue = cli.Telefono;
            txtCelular.EditValue = cli.Celular;

        }

        private void frmFinanciamiento_Shown(object sender, EventArgs e)
        {
            gridCrono.DataSource = _dtReferencias;
            gridView1.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            gridView1.Columns[0].Width = 50;
            Nuevo();
        }

        private void BotonNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && _dtReferencias.Rows.Count > 0)
            {
                if (MessageBox.Show("Desea Borrar referencia?", "Confirmación", MessageBoxButtons.YesNo) !=
                  DialogResult.Yes)
                    return;
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
            }

        }

        private void txtEnganche_Leave(object sender, EventArgs e)
        {
            decimal enganche = Convert.ToDecimal(txtCantidadFinancimiento.EditValue) * Convert.ToDecimal(txtPorcEnganche.EditValue);
            if ((decimal)txtEnganche.EditValue < enganche && cboTipoFinanciamiento.Text == "AutoFinanciamiento")
            {
                MessageBox.Show("El Enganche no puede ser menor al porcentaje requerido");
                txtEnganche.EditValue = enganche;

            }
        }

        private void btnImprimirCotizacion_Click(object sender, EventArgs e)
        {
            if (_dtCronograma.Rows.Count > 0)
            {
                XrptCotizacion coti = new XrptCotizacion();
                for (int i = 0; i < _dtCronograma.Rows.Count; i++)
                {
                    coti.cotizacion.Tables[0].ImportRow(_dtCronograma.Rows[i]);
                }

                coti.ShowPreviewDialog();

            }
        }
    }
}
