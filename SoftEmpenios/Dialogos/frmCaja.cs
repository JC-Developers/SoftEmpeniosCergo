using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;
using SoftEmpenios.Pantallas;
using SoftEmpenios.Reportes;

namespace SoftEmpenios.Dialogos
{
    public partial class FrmCaja : XtraForm,iPantalla
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        public FrmCaja()
        {
            InitializeComponent();
            SacarTransacciones();
        }

        private void SacarTransacciones()
        {
            var cajahoy = (from c in _entidades.Cajas
                           where c.FechaCajaAbierto == DateTime.Today.Date && c.Estado
                           select c).SingleOrDefault();
            if (cajahoy != null)
            {
                txtCajaInicial.EditValue = Convert.ToDecimal(cajahoy.CajaInicial);
                btnAbrirCerrar.Visible = true;
                decimal com =
                    _entidades.Compras.Where(c => c.Estado == true && c.FechaCompra == cajahoy.FechaCajaAbierto)
                        .Sum(c => (decimal?)c.TotalCompra) ?? 0;

                decimal empe = _entidades.Boletas.Where(e => e.FechaPrestamo == DateTime.Today.Date && e.EstadoBoleta != "Cancelado")
                    .Sum(e => (decimal?)e.Prestamo) ?? 0;

                decimal inte = _entidades.PagosInteres.Where(i => i.FechaPago == DateTime.Today.Date && i.Estado == true)
                           .Sum(i => (decimal?)i.TotalPagar) ?? 0;
                decimal desem = _entidades.Desempeños
                            .Where(d => d.FechaDesempeño == DateTime.Today.Date && d.Estado == true)
                            .Sum(d => (decimal?)d.TotalPagar) ?? 0;
                decimal ret = _entidades.Transacciones
                          .Where(r => r.FechaTransaccion == DateTime.Today.Date && r.TipoTransaccion == "Retiro" && r.Estado == true)
                          .Sum(r => (decimal?)r.Cantidad) ?? 0;
                decimal dep = _entidades.Transacciones
                          .Where(r => r.FechaTransaccion == DateTime.Today.Date && (r.TipoTransaccion == "Deposito" || r.TipoTransaccion == "Base") && r.Estado )
                          .Sum(r => (decimal?)r.Cantidad) ?? 0;
                decimal ventas = (from vc in _entidades.Ventas
                                  where vc.TipoVenta == "Contado" && vc.Estado=="Pagado" && vc.FechaVenta == DateTime.Today.Date
                                  select (decimal?)vc.TotalVenta).Sum() ?? 0;
                decimal apartados = (from vc in _entidades.Ventas
                                     where vc.TipoVenta == "Apartado" && vc.Estado!="Cancelado" && vc.FechaVenta == DateTime.Today.Date
                                     select (decimal?)vc.Enganche).Sum() ?? 0;
                decimal abonos = (from abo in _entidades.PagosVentas
                                  where abo.Estado == true && abo.FechaPago == DateTime.Today.Date
                                  select (decimal?)abo.Abono).Sum() ?? 0;
                decimal pagoF = (from pf in _entidades.PagosFinanciamientos
                                 where pf.Estado == true && pf.FechaPago.Date == DateTime.Today.Date
                                 select (decimal?)pf.TotalPago).Sum() ?? 0;
                decimal finan = (from pf in _entidades.Prestamos
                                 where pf.Estado != "Cancelado" && pf.FechaPrestamo.Date == DateTime.Today.Date
                                 select (decimal?)pf.Cantidad).Sum() ?? 0;
                decimal creditos = (from pf in _entidades.FinancieraCreditos
                                 where pf.Estado == "Activo" && pf.FechaInicio.Date == DateTime.Today.Date
                                 select (decimal?)pf.Prestamo).Sum() ?? 0;
                decimal pagCre = (from pf in _entidades.FinancieraPagos
                                    where pf.Estado && pf.FechaPago.Date == DateTime.Today.Date
                                    select (decimal?)pf.TotalPago).Sum() ?? 0;
                decimal engan = (from pf in _entidades.Prestamos
                                 where pf.Estado != "Cancelado" && pf.FechaPrestamo.Date == DateTime.Today.Date
                                 select (decimal?)pf.Enganche).Sum() ?? 0;
                txtCancelaciones.EditValue =
                    _entidades.Cancelaciones.Count(c => c.FechaCancelacion == DateTime.Today.Date);
                txtCajaInicial.EditValue = cajahoy.CajaInicial;
                txtCompras.EditValue = com;
                txtEmpenios.EditValue = empe;
                txtIntereses.EditValue = inte;
                txtDesempeños.EditValue = desem;
                txtRetiros.EditValue = ret;
                txtDepositos.EditValue = dep;
                dtpFechaCaja.DateTime = DateTime.Today.Date;
                txtVentas.EditValue = ventas + apartados;
                txtAbonos.EditValue = abonos;
                txtFinanciamientos.EditValue = finan+ creditos;//mod para agregar credito grupales
                txtPagosFinanciamiento.EditValue = pagoF + pagCre;//mod para agregar pagos credito grupales
                txtEnganche.EditValue = engan;
                txtCajaFinal.EditValue = (cajahoy.CajaInicial + dep + inte + desem + abonos + ventas + pagoF + engan+ apartados+ pagCre) - (creditos+ empe + ret + com + finan);
            }
            else
            {
                MessageBox.Show("La Caja del Dia de hoy ya se ha cerrado\n SISTEMA BLOQUEADO", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btnAbrirCerrar_Click(object sender, EventArgs e)
        {
            _entidades.Connection.ConnectionString = new clsConeccionDB().StringConn();
            SacarTransacciones();
            switch (MessageBox.Show("Esta por hacer corte de caja, \nuna vez hecho el corte ya no podra usar el sistema hasta mañana", "Corte de Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {

                case DialogResult.Yes:
                    Caja cajadc = _entidades.Cajas.Single(c => c.FechaCajaAbierto == DateTime.Today.Date);
                    _entidades.Connection.ConnectionString = new clsConeccionDB().StringConn();
                    SacarTransacciones();

                    cajadc.CajeroCerro = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioApp"));
                    cajadc.FechaCajaCierre = DateTime.Today;
                    cajadc.Desempenios = (decimal)txtDesempeños.EditValue;
                    cajadc.InteresCobrados = (decimal)txtIntereses.EditValue;
                    cajadc.TotalEmpenios = (decimal)txtEmpenios.EditValue;
                    cajadc.TotalRetiros = (decimal)txtRetiros.EditValue;
                    cajadc.TotalDepositos = (decimal)txtDepositos.EditValue;
                    cajadc.TotalCompras = (decimal)txtCompras.EditValue;
                    cajadc.TotalVentas = (decimal)txtVentas.EditValue;
                    cajadc.TotalPagosVentas = (decimal)txtAbonos.EditValue;
                    cajadc.TotalFinanciamientos = (decimal)txtFinanciamientos.EditValue;
                    cajadc.TotalEnganche = (decimal)txtEnganche.EditValue;
                    cajadc.TotalPagosFinanciamiento = (decimal)txtPagosFinanciamiento.EditValue;
                    cajadc.CajaFinal = (decimal)txtCajaFinal.EditValue;
                    cajadc.Estado = false;
                    _entidades.SubmitChanges();
                    XrptCajaDiaria caja=new XrptCajaDiaria ();
                    caja.DatosInforme.DataSource = cajadc;
                    caja.Parameters["Sucursal"].Value = new clsModificarConfiguracion().configGetValue("Empresa");;
                    caja.Parameters["Direccion"].Value = new clsModificarConfiguracion().configGetValue("Direccion");;
                    caja.Parameters["Cancelaciones"].Value = txtCancelaciones.EditValue;
                    caja.ShowPreviewDialog();
                    break;

                case DialogResult.No:
                    MessageBox.Show("Caja sigue Abierta", "SoftEmpeños");
                    break;

            }
        }
        #region de comando de Herencia
        public bool ConfirmarCierre()
        {
            switch (MessageBox.Show("\x00bfHa realizado cambios sin Guardar?. \x00bfDesea guardarlas?", "Muebleria", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                case DialogResult.Yes:
                    this.Guardar();
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

        }
        public void Paginar(int primerRegistro)
        {
            throw new NotImplementedException();
        }
        public string nombrePantalla
        {
            get
            {
                return "Transacciones";
            }
        }

        #endregion

        private void frmCaja_Load(object sender, EventArgs e)
        {
            int canc = (from c in _entidades.Cancelaciones
                        where c.FechaCancelacion == DateTime.Today.Date
                        select c).Count();
            new clsModificarConfiguracion().configSetValue("Cancelaciones", canc.ToString());
            txtCancelaciones.EditValue = canc;
        }
        private void txtFinanciamientos_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fina = from fi in _entidades.Prestamos
                       where fi.Estado != "Cancelado" && fi.FechaPrestamo.Date == DateTime.Today.Date
                       select new { fi.FolioFinanciamiento, fi.Tipo, fi.Cliente.Nombre, Prestamo = fi.Cantidad, fi.Enganche, fi.Saldo, fi.Meses, fi.Observacion };
            var cre =
                _entidades.FinancieraCreditos.Where(c=>c.Estado=="Activo" && c.FechaModificacion==DateTime.Today.Date ) .Select(
                    c =>
                        new
                        {
                            c.Clave,
                            Grupo = c.FinancieraGrupo.Nombre,
                            c.Prestamo,
                            c.Base,
                            c.Plazos,
                            c.NumeroPlazos,
                            Registro=c.Usuario.Nombre
                        });
            FrmDetallesCaja det = new FrmDetallesCaja
            {
                DtCronos = new LinqToDataTable().ObtenerDataTable2(fina),
                DtFinanciera = new LinqToDataTable().ObtenerDataTable2(cre),
                Tipo = "Financiamientos"
            };
            det.ShowDialog(this);
        }

        private void txtPagosFinanciamiento_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var pagosF = from pf in _entidades.PagosFinanciamientos
                         where pf.Estado == true && pf.FechaPago.Date == DateTime.Today.Date
                         select new { pf.Clave, pf.Prestamo.FolioFinanciamiento, pf.Prestamo.Tipo, Cliente = pf.Prestamo.Cliente.Nombre, pf.TotalPago, pf.Usuario.Nombre };
            var pagosFinan = _entidades.FinancieraPagos.Where(pfi => pfi.Estado && pfi.FechaPago == DateTime.Today.Date)
                .Select(
                    pfi =>
                        new
                        {
                            pfi.Clave,
                            pfi.FinancieraCredito.FinancieraGrupo.Nombre,
                            pfi.Pago,
                            pfi.Recargo,
                            pfi.TotalPago,
                            Registro = pfi.Usuario.Nombre
                        });
            FrmDetallesCaja det = new FrmDetallesCaja
            {
                DtCronos = new LinqToDataTable().ObtenerDataTable2(pagosF),
                DtFinanciera = new LinqToDataTable().ObtenerDataTable2(pagosFinan),
                Tipo = "PagosF"
            };
            det.ShowDialog(this);
        }

        private void txtFinanciamientos_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtCancelaciones_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDepositos_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var depositos =
                _entidades.Transacciones.Where(
                    d => d.Estado && d.FechaTransaccion == DateTime.Today.Date && d.TipoTransaccion == "Deposito")
                    .Select(d=>new {d.Clave,d.Concepto,d.Cantidad});
            var bases =
                _entidades.Transacciones.Where(
                    d => d.Estado && d.FechaTransaccion == DateTime.Today.Date && d.TipoTransaccion == "Base")
                    .Select(d => new { d.Clave, d.Concepto, d.Cantidad }); ;
            FrmDetallesCaja det = new FrmDetallesCaja
            {
                DtCronos = new LinqToDataTable().ObtenerDataTable2(depositos),
                DtFinanciera = new LinqToDataTable().ObtenerDataTable2(bases),
                Tipo = "Depositos"
            };
            det.ShowDialog(this);
        }
    }
}
