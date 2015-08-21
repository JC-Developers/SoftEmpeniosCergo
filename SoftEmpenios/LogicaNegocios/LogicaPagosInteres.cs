using System.ComponentModel.DataAnnotations;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.LogicaNegocios
{
    public class LogicaPagosInteres
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());

        public int AgregarPagoInteres(PagosIntere intere)
        {
            if (intere.FolioBoleta == string.Empty)
                throw new ValidationException("Selecione la boleta a Abonar");
            if (intere.Interes == 0)
                throw new ValidationException("El Monto a pagar no puede ser cero");
            _entidades.PagosInteres.InsertOnSubmit(intere);
            _entidades.SubmitChanges();
            return intere.Clave;
        }
    }
}
