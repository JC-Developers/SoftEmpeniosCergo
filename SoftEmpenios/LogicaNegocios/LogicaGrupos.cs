using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SoftEmpenios.Clases;
using SoftEmpenios.DBComun;

namespace SoftEmpenios.LogicaNegocios
{
    public class LogicaGrupos
    {
        EmpeñosDC _entidades = new EmpeñosDC(new clsConeccionDB().StringConn());

        public int AgregarGrupo(FinancieraGrupo grupo)
        {
            if (grupo.Nombre==string.Empty)
                throw new ValidationException("Indique el nombre del Grupo");
            _entidades.FinancieraGrupos.InsertOnSubmit(grupo);
            _entidades.SubmitChanges();
            return grupo.Clave;
        }

        public void AgregarIntegranteGrupo(FinancieraGruposDetalle integrante)
        {
            _entidades.FinancieraGruposDetalles.InsertOnSubmit(integrante);
            _entidades.SubmitChanges();
        }

        public void ActualizarGrupo(FinancieraGrupo nuevo, FinancieraGrupo original)
        {

            EmpeñosDC entidades=new EmpeñosDC( new clsConeccionDB().StringConn());
            entidades.FinancieraGrupos.Attach(nuevo,original);
            entidades.SubmitChanges();
        }

        public void EliminarDetalles(int cveGrupo)
        {
            IEnumerable<FinancieraGruposDetalle> detgrupo =
                _entidades.FinancieraGruposDetalles.Where(
                    dg =>  dg.CveGrupo == cveGrupo);
            _entidades.FinancieraGruposDetalles.DeleteAllOnSubmit(detgrupo);
            _entidades.SubmitChanges();
        }
    }
}
