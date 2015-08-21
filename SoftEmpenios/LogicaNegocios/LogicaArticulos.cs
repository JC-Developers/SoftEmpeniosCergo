using System.ComponentModel.DataAnnotations;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.LogicaNegocios
{
    public class LogicaArticulos
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());

        public int InsertarArticulo(Articulo art)
        {
            if (art.Descripcion==string.Empty)
                throw new ValidationException("Indique la descripción del artículo");
            if (art.Peso==0)
                throw new ValidationException("Indique el peso del artículo");
            if (art.Precio == 0)
                throw new ValidationException("Indique el Precio del Articulo");
            if (art.PrecioCredito == 0)
                throw new ValidationException("Indique el Precio Apartado");
            _entidades.Articulos.InsertOnSubmit(art);
            _entidades.SubmitChanges();
            return art.Clave;
        }

        public void ActualizarArticulo(Articulo  art,Articulo original )
        {
            if (art.Descripcion == string.Empty)
                throw new ValidationException("Indique la descripción del artículo");
            if (art.Peso == 0)
                throw new ValidationException("Indique el peso del artículo");
            if (art.Precio == 0)
                throw new ValidationException("Indique el Precio del Articulo");
            if (art.PrecioCredito == 0)
                throw new ValidationException("Indique el Precio Apartado");
            _entidades.Articulos.Attach(art,original);
            _entidades.SubmitChanges();
        }
    }
}
