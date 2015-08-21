using System.ComponentModel.DataAnnotations;
using System.Linq;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.LogicaNegocios
{

    public class LogicaBoletas
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        public void EstadoVencido(string folio)
        {
            Boleta bol = _entidades.Boletas.Single(b => b.Folio == folio);
            bol.EstadoBoleta = "Vencido";
            _entidades.SubmitChanges();
        }

        public Boleta ObtenerBoleta(string folio)
        {
            return _entidades.Boletas.Single(b => b.Folio == folio);
        }

        public void AgregarBoleta(Boleta boleta)
        {
            if (boleta.Cliente==string.Empty)
                throw new ValidationException("Indique el Nombre del cliente");
            if (boleta.Prestamo == 0)
                throw new ValidationException("Indique la cantidad de Prestamo");
            _entidades.Boletas.InsertOnSubmit(boleta);
            _entidades.SubmitChanges();
        }
    }
}
