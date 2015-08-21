using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.LogicaNegocios
{
    public class LogicaCreditos
    {
        readonly EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());
        public int AgregarCredito(FinancieraCredito credito)
        {
            if (credito.CveGrupo==0)
                throw new ValidationException("Elija el Grupo para poder otorgar un credito");
            _entidades.FinancieraCreditos.InsertOnSubmit(credito);
            _entidades.SubmitChanges();
            return credito.Clave;
        }
    }
}
