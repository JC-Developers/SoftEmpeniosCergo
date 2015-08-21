using SoftEmpenios.DBComun;
using SoftEmpenios.Clases;
using System.ComponentModel.DataAnnotations;

namespace SoftEmpenios.LogicaNegocios
{
    public class LogicaPrestamos
    {
        readonly EmpeñosDC _mapeoFinanciamiento = new EmpeñosDC(new clsConeccionDB().StringConn());
        public int AgregarPrestamo(Prestamo pres)
        {
            if (pres.Tipo == string.Empty)
                throw new ValidationException("Indique el tipo de Financiamiento");
            if (pres.Cantidad   <= 0)
                throw new ValidationException("Indique el monto a Financiar");
            _mapeoFinanciamiento.Prestamos.InsertOnSubmit(pres);
            _mapeoFinanciamiento.SubmitChanges();
            return pres.Clave;
 
        }
    }
    
}
