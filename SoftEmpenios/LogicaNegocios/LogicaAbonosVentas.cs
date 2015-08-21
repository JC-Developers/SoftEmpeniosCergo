using SoftEmpenios.DBComun;
using System.ComponentModel.DataAnnotations;
using SoftEmpenios.Clases;

namespace SoftEmpenios.LogicaNegocios
{
    public class LogicaAbonosVentas
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        public int AgregarAbono(PagosVenta pagosVenta)
        {
            if (pagosVenta.CveVenta == 0)
                throw new ValidationException("Busque la venta que le quiere hacer abono");
            if (pagosVenta.Abono==0)
                throw new ValidationException("Indique el monto a abonar");
            if (pagosVenta.Saldo<0)
                throw new ValidationException("No puede abonar mas que el saldo");
            if (pagosVenta.Saldo<0)
                throw new ValidationException("No puede abonar mas de lo que se debe");
            _entidades.PagosVentas.InsertOnSubmit(pagosVenta);
            _entidades.SubmitChanges();
            return pagosVenta.Clave;
        }
    }
}
