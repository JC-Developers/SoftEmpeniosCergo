using System.ComponentModel.DataAnnotations;
using System.Linq;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.LogicaNegocios
{
    public class LogicaVentas
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        public int InsertarVenta(Venta venta)
        {
            if (venta.Cliente==string.Empty)
                throw new ValidationException("Indique el Nombre del cliente");
            if (venta.TotalVenta==0)
                throw new ValidationException("Indique los Articulos a Vender");
            if (venta.TipoVenta=="Apartado" && venta.Enganche==0)
                throw new ValidationException("Indique cuando es el enganche de la venta");
            _entidades.Ventas.InsertOnSubmit(venta);
            _entidades.SubmitChanges();
            return venta.Clave;
        }
        public void GuardarDetalleVenta(DetalleVenta detVenta, string tipo)
        {
            _entidades.DetalleVentas.InsertOnSubmit(detVenta);
            Articulo articulo = _entidades.Articulos.Single(a => a.Clave == detVenta.CveArticulo);
            articulo.Estado = tipo;
            _entidades.SubmitChanges();
        }
    }
}
