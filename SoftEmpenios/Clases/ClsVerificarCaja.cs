using System;
using System.Linq;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.Clases
{
    public static  class ClsVerificarCaja
    {
       
        public static  decimal SaldoEnCaja()
        {
             EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
            Caja caja = _entidades.Cajas.FirstOrDefault(c => c.FechaCajaAbierto.Date == DateTime.Today.Date);
            if (caja != null)
            {
                decimal cajaInicial =
                    caja.CajaInicial; //(from c in _mapeoCasaEmpenios.Cajas
                //where c.FechaCajaAbierto == DateTime.Today.Date && c.Estado
                //select (decimal?)c.CajaInicial).Sum()??0;
                decimal com = (from c in _entidades.Compras
                               where c.FechaCompra == DateTime.Today.Date && c.Estado == true
                               select (decimal?)c.TotalCompra).Sum() ?? 0;
                decimal empe = (from e in _entidades.Boletas
                                where e.FechaPrestamo == DateTime.Today.Date && e.EstadoBoleta != "Cancelado"
                                select (decimal?)e.Prestamo).Sum()??0;
                decimal inte = (from i in _entidades.PagosInteres
                                where i.FechaPago == DateTime.Today.Date && i.Estado == true
                                select (decimal?)i.TotalPagar).Sum()??0;
                decimal desem = (from d in _entidades.Desempeños
                                 where d.FechaDesempeño == DateTime.Today.Date && d.Estado == true
                                 select (decimal?)d.TotalPagar).Sum()??0;
                decimal ret = (from r in _entidades.Transacciones
                               where r.FechaTransaccion == DateTime.Today.Date && r.TipoTransaccion == "Retiro" && r.Estado == true
                               select (decimal?)r.Cantidad).Sum()??0;
                decimal dep = (from depo in _entidades.Transacciones
                               where depo.FechaTransaccion == DateTime.Today.Date && depo.TipoTransaccion == "Deposito" && depo.Estado == true        //DateTime.Now
                               select (decimal?)depo.Cantidad).Sum()??0;
                decimal ventas = (from vc in _entidades.Ventas
                                  where vc.TipoVenta == "Contado" && vc.Estado=="Pagado" && vc.FechaVenta == DateTime.Today.Date
                                  select (decimal?)vc.TotalVenta).Sum() ?? 0;
                decimal apartados = (from vc in _entidades.Ventas
                                     where vc.TipoVenta == "Apartado" && vc.Estado!="Cancelado" && vc.FechaVenta == DateTime.Today.Date
                                     select (decimal?)vc.Enganche).Sum() ?? 0;
                decimal abonos = (from abo in _entidades.PagosVentas
                                  where abo.Estado && abo.FechaPago == DateTime.Today.Date
                                  select (decimal?)abo.Abono).Sum() ?? 0;
                decimal pagoF = (from pf in _entidades.PagosFinanciamientos
                                 where pf.Estado&& pf.FechaPago.Date == DateTime.Today.Date
                                 select (decimal?)pf.TotalPago).Sum() ?? 0;
                decimal finan = (from pf in _entidades.Prestamos
                                 where pf.Estado != "Cancelado" && pf.FechaPrestamo.Date == DateTime.Today.Date
                                 select (decimal?)pf.Cantidad).Sum() ?? 0;
                decimal engan = (from pf in _entidades.Prestamos
                                 where pf.Estado != "Cancelado" && pf.FechaPrestamo.Date == DateTime.Today.Date
                                 select (decimal?)pf.Enganche).Sum() ?? 0;
                decimal creditos = (from pf in _entidades.FinancieraCreditos
                                    where pf.Estado == "Activo" && pf.FechaInicio.Date == DateTime.Today.Date
                                    select (decimal?)pf.Prestamo).Sum() ?? 0;
                decimal pagCre = (from pf in _entidades.FinancieraPagos
                                  where pf.Estado && pf.FechaPago.Date == DateTime.Today.Date
                                  select (decimal?)pf.TotalPago).Sum() ?? 0;


                decimal saldo =  (cajaInicial+ inte+desem+dep+pagoF+engan+ventas+abonos+apartados+pagCre) -(empe + com + finan+ret+ creditos);
                return saldo;
            }
            return 0M;
        }

        public static bool  CajaEstado()
        {
            var caj=new EmpeñosDC(new clsConeccionDB().StringConn()).Cajas.SingleOrDefault(
                    c => c.FechaCajaAbierto.Date == DateTime.Today.Date);
            if (caj != null)
                return caj.Estado;
            return true;

        }
    }
}
