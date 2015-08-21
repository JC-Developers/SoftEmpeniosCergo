using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoftEmpenios.DBComun;
using SoftEmpenios.Clases;

namespace SoftEmpenios.Dialogos
{
    public partial class FrmIniciarSesion : XtraForm
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        public FrmIniciarSesion()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usu = _entidades.Usuarios.SingleOrDefault(u => u.Usuario1 == txtUsuario.Text && u.Contrasenia == txtContrasenia.Text);
                
                if (usu!=null)
                {
                    new clsModificarConfiguracion().configSetValue("UsuarioApp", usu.Nombre);
                    new clsModificarConfiguracion().configSetValue("IDUsuarioApp", usu.CveUsuario.ToString());
                    new clsModificarConfiguracion().configSetValue("PermisosApp", usu.Permisos);
                    
                    AbrirCaja();
                    Close();
                }
                else
                {
                    MessageBox.Show("El Nombre de usuario y/o contrase\x00f1a son Incorrectos", "Datos Incorrectos");
                    txtContrasenia.Text = "";
                    txtContrasenia.Focus();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Acceso denegado");
            }

        }

        private void frmIniciarSesion_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((new clsModificarConfiguracion().configGetValue("UsuarioApp") == "") && (new clsModificarConfiguracion().configGetValue("IDUsuarioApp") == ""))
            {
                MessageBox.Show("Inicie Sesion Para Utilizar el Sistema", "Iniciar Sesion");
                //Application.Exit();
            }

        }
        private void AbrirCaja()
        {
            _entidades.Connection.ConnectionString = new clsConeccionDB().StringConn();
            var cajadc = (from cj in  _entidades.Cajas
                        select cj).OrderByDescending(cj => cj.FechaCajaAbierto).FirstOrDefault();
            if (cajadc == null)
            {
                MessageBox.Show("La caja se iniciara con $ 0.00 pesos,\n realice un deposito para poder realizar empeños y compras", "No hay dinero en caja");
                AbrirCaja(0);
            }
            else
            {
                if (cajadc.Estado == false && cajadc.FechaCajaAbierto <= DateTime.Today.Date.AddDays(-1))
                {
                    AbrirCaja(cajadc.CajaFinal);
                }
                else if (cajadc.Estado && cajadc.FechaCajaAbierto < DateTime.Today)
                {
                    MessageBox.Show("Se procedera a cerrar la caja anterior y abrir el del dia de hoy");
                     
                    var com = (_entidades.Compras.Where(
                        c => c.FechaCompra == cajadc.FechaCajaAbierto && cajadc.Estado).Select(c => (decimal?)c.TotalCompra)).Sum()??0;
                    var empe = (from e in _entidades.Boletas
                               where e.FechaPrestamo == cajadc.FechaCajaAbierto && e.EstadoBoleta !="Cancelado"
                                select (decimal?)e.Prestamo).Sum()??0;
                    var inte = (from i in _entidades.PagosInteres
                               where i.FechaPago == cajadc.FechaCajaAbierto && i.Estado
                                select (decimal?)i.TotalPagar).Sum()??0;
                    var desem = (from d in _entidades.Desempeños
                                where d.FechaDesempeño == cajadc.FechaCajaAbierto && d.Estado
                                 select (decimal?)d.TotalPagar).Sum()??0;var ret = (from r in _entidades.Transacciones
                              where r.FechaTransaccion == cajadc.FechaCajaAbierto && r.TipoTransaccion == "Retiro" && r.Estado
                               select (decimal?)r.Cantidad).Sum()??0;
                    var dep = (from depo in _entidades.Transacciones
                               where depo.FechaTransaccion == cajadc.FechaCajaAbierto &&( depo.TipoTransaccion == "Deposito" || depo.TipoTransaccion == "Base") && depo.Estado               //DateTime.Now
                               select (decimal?)depo.Cantidad).Sum()??0;
                    decimal ventas = (from vc in _entidades.Ventas
                                      where vc.Estado == "Pagado" && vc.FechaVenta == cajadc.FechaCajaAbierto
                                      select (decimal?)vc.TotalVenta).Sum() ?? 0;
                    decimal apartados = (from vc in _entidades.Ventas
                                         where vc.Estado == "Apartado" && vc.FechaVenta == cajadc.FechaCajaAbierto
                                         select (decimal?)vc.Enganche).Sum()??0;
                    decimal abonos = (_entidades.PagosVentas.Where(
                        abo => abo.Estado && abo.FechaPago == cajadc.FechaCajaAbierto).Select(abo => (decimal?) abo.Abono)).Sum()??0;
                    decimal pagoF = (from pf in _entidades.PagosFinanciamientos
                                     where pf.Estado && pf.FechaPago.Date == cajadc.FechaCajaAbierto
                                     select (decimal?)pf.TotalPago).Sum() ?? 0;
                    decimal finan = (from pf in _entidades.Prestamos
                                     where pf.Estado != "Cancelado" && pf.FechaPrestamo.Date == cajadc.FechaCajaAbierto
                                     select (decimal?)pf.Cantidad).Sum() ?? 0;
                    decimal creditos = (from pf in _entidades.FinancieraCreditos
                                        where pf.Estado == "Activo" && pf.FechaInicio.Date == cajadc.FechaCajaAbierto
                                        select (decimal?)pf.Prestamo).Sum() ?? 0;
                    decimal pagCre = (from pf in _entidades.FinancieraPagos
                                      where pf.Estado && pf.FechaPago.Date == cajadc.FechaCajaAbierto
                                      select (decimal?)pf.TotalPago).Sum() ?? 0;

                    decimal engan = (from pf in _entidades.Prestamos
                                     where pf.Estado != "Cancelado" && pf.FechaPrestamo.Date == cajadc.FechaCajaAbierto
                                     select (decimal?)pf.Enganche).Sum() ?? 0;
                    
                    //decimal dtpFechaCaja= DateTime.Today.Date;
                    
                    //var cajadc = (_mapeoCasaEmpenios.Cajas.Where(c => c.FechaCajaAbierto == cajadc.FechaCajaAbierto)).First();
                    cajadc.CajeroCerro = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioApp"));
                    cajadc.FechaCajaCierre = DateTime.Today;
                    cajadc.Desempenios = desem;
                    cajadc.InteresCobrados = inte;
                    cajadc.TotalEmpenios = empe;
                    cajadc.TotalRetiros = ret;
                    cajadc.TotalDepositos = dep;
                    cajadc.TotalCompras = com;
                    cajadc.TotalVentas = ventas +apartados;
                    cajadc.TotalPagosVentas = abonos;
                    cajadc.TotalFinanciamientos = finan + creditos;
                    cajadc.TotalEnganche = engan;
                    cajadc.TotalPagosFinanciamiento = pagoF + pagCre;
                    cajadc.CajaFinal = (cajadc.CajaInicial + dep + inte + desem+ventas+apartados+abonos+engan+pagoF+ pagCre) - (empe + ret + com+finan + creditos); 
                    cajadc.Estado = false;//false significa que esta abierto
                    //mapeoCasaEmpenios.CajaDC.InsertOnSubmit(cajadc);
                    _entidades.SubmitChanges();
                    AbrirCaja(cajadc.CajaFinal);
                }
                else
                {
                    Caja caj = _entidades.Cajas.Single(c => c.FechaCajaAbierto == DateTime.Today.Date);
                    if (caj.Estado == false)
                    {
                        MessageBox.Show("La Caja del Dia de hoy ya se ha cerrado\n SISTEMA BLOQUEADO", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }

                }
            }

        }

        private void frmIniciarSesion_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }
        private void AbrirCaja(decimal cajafinal)
        {
            try
            {
                Caja cajadc = new Caja
                    {
                        CajaInicial = cajafinal,
                        CajeroAbrio = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioApp")),
                        FechaCajaAbierto = DateTime.Today,
                        CajeroCerro = Convert.ToInt32(new clsModificarConfiguracion().configGetValue("IDUsuarioApp")),
                        FechaCajaCierre = DateTime.Today,
                        Desempenios = 0,
                        InteresCobrados = 0,
                        TotalEmpenios = 0,
                        TotalRetiros = 0,
                        TotalDepositos = 0,
                        TotalCompras = 0,
                        TotalVentas = 0,
                        TotalPagosVentas = 0,
                        CajaFinal = 0,
                        Estado = true
                    };
                _entidades.Cajas.InsertOnSubmit(cajadc);
                _entidades.SubmitChanges();
                new clsModificarConfiguracion().configSetValue("Cancelaciones", "0");
                MessageBox.Show("La Caja del Dia de hoy se abrira con\n $ " + cajadc.CajaInicial, "Caja Abierta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("Ha Ocurrido un error en Abrir la Caja \n"+ ex.Message);
            }
         }

    }
}
