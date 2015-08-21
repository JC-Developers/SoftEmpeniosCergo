using System.ComponentModel.DataAnnotations;
using System.Linq;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.LogicaNegocios
{
    public class LogicaUsuarios
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        public IQueryable<Usuario> ObtenerTodos()
        {
            return _entidades.Usuarios;
        }

        public int AgregarRegistro(Usuario item)
        {
            if (item.Nombre == string.Empty)
                throw new ValidationException("El nombre no debe de estar vacio");
            if (item.Usuario1.Length < 3)
                throw new ValidationException("Nombre de Usuario muy corto");
            if (item.Contrasenia.Length < 6)
                throw new ValidationException("la contraseña deberia ser igual o mayor a 5 caracteres");
            
            _entidades.Usuarios.InsertOnSubmit(item);
            _entidades.SubmitChanges();
            return item.CveUsuario;
        }
        public void ActualizarRegistro(Usuario itemNuevo, Usuario itemAnterior)
        {
            if (itemNuevo.Nombre == string.Empty)
                throw new ValidationException("El nombre no debe de estar vacio");
            if (itemNuevo.Usuario1.Length < 3)
                throw new ValidationException("Nombre de Usuario muy corto");
            if (itemNuevo.Contrasenia.Length < 6)
                throw new ValidationException("la contraseña deberia ser igual o mayor a 5 caracteres");
            _entidades.Usuarios.Attach(itemNuevo,itemAnterior);
            _entidades.SubmitChanges();
        }
        public Usuario ObtenerUsuario(int cve)
        {
            return _entidades.Usuarios.Single(u => u.CveUsuario == cve);
        }
    }
}
