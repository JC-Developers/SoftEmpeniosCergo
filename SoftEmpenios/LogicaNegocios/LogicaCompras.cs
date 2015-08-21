using System.ComponentModel.DataAnnotations;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.LogicaNegocios
{

    public class LogicaCompras
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());

        public int AgregarCompra(Compra compra)
        {
            if (compra.TotalCompra==0)
                throw new ValidationException("El Monto de compra no puede ser cero");
            _entidades.Compras.InsertOnSubmit(compra);
            _entidades.SubmitChanges();
            return compra.CveCompra;
        }

        public void AgregarDetalle(DetallesCompra detalle)
        {
            _entidades.DetallesCompras.InsertOnSubmit(detalle);
            _entidades.SubmitChanges();
        }
    }
}
