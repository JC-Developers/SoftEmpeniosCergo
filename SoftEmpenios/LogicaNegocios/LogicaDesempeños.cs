using System.ComponentModel.DataAnnotations;
using System.Linq;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.LogicaNegocios
{
    public class LogicaDesempeños
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());

        public int AgregarDesempeño(Desempeño des)
        {
            if (des.FolioBoleta == string.Empty)
                throw new ValidationException("Selecione la boleta a Desempeñar");
            if (des.TotalPagar == 0)
                throw new ValidationException("El Monto a pagar no puede ser cero");
            _entidades.Desempeños.InsertOnSubmit(des);
            Boleta bol = _entidades.Boletas.First(b => b.Folio == des.FolioBoleta);
            bol.EstadoBoleta = "Desempeñado";
            bol.Pagado = true;
            _entidades.SubmitChanges();
            return des.Clave;
        }
    }
}
