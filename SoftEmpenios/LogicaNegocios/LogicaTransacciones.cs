using System.ComponentModel.DataAnnotations;
using System.Linq;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.LogicaNegocios
{
    public class LogicaTransacciones
    {
        readonly EmpeñosDC _entidad = new EmpeñosDC(new clsConeccionDB().StringConn());
        public int AgregarTransaccion(Transaccione item)
        {
            if (item.TipoTransaccion == "Retiro")
            {
                string per = _entidad.Usuarios.Single(u => u.CveUsuario == item.CveUsuario).Permisos;
                if (per=="Usuario")
                    throw new ValidationException("No tiene permisos para realizar Retiros");
                if (ClsVerificarCaja.SaldoEnCaja()<item.Cantidad)
                    throw new ValidationException("No Puede retirar mas de lo disponible en caja");
            }
            if (item.Cantidad==0)
                throw new ValidationException("La cantidad no puede ser cero");
            if (item.TipoTransaccion == string.Empty)
                throw new ValidationException("Indique el tipo de transacción");
            if (item.Concepto==string.Empty)
                throw new ValidationException("Indique el concepto de la transacción");
            _entidad.Transacciones.InsertOnSubmit(item);
            _entidad.SubmitChanges();
            return item.Clave;
        }
    }
}
