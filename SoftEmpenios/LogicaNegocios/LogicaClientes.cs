using SoftEmpenios.DBComun;
using System.ComponentModel.DataAnnotations;
using SoftEmpenios.Clases;

namespace SoftEmpenios.LogicaNegocios
{
    
    public class LogicaClientes
    {
        EmpeñosDC mapeoFinanciamiento = new EmpeñosDC(new clsConeccionDB().StringConn());
        public int AgregarCliente(Cliente cli)
        {
            if (cli.Nombre == string.Empty)
                throw new ValidationException("Indique el nombre del Cliente");
            if (cli.Direccion == string.Empty)
                throw new ValidationException("Indique la direccion Cliente");
            if (cli.Poblacion == string.Empty)
                throw new ValidationException("Indique el poblado del Cliente");
            if (cli.Telefono == string.Empty && cli.Celular == string.Empty)
                throw new ValidationException("Indique un numero de Telefono o Celular");
            mapeoFinanciamiento.Clientes.InsertOnSubmit(cli);
            mapeoFinanciamiento.SubmitChanges();
            return cli.CveCliente;
        }
        public void ModificarCliente(Cliente cliMod, Cliente cliOri)
        {
            if (cliMod.Nombre == string.Empty)
                throw new ValidationException("Indique el nombre del Cliente");
            if (cliMod.Direccion == string.Empty)
                throw new ValidationException("Indique la direccion Cliente");
            if (cliMod.Poblacion == string.Empty)
                throw new ValidationException("Indique el poblado del Cliente");
            if (cliMod.Telefono == string.Empty && cliMod.Celular == string.Empty)
                throw new ValidationException("Indique un numero de Telefono o Celular");
            mapeoFinanciamiento.Clientes.Attach(cliMod,cliOri);
            mapeoFinanciamiento.SubmitChanges();
            
        }
        public int AgregarClienteFinanciera(FinancieraCliente cli)
        {
            if (cli.Nombre == string.Empty)
                throw new ValidationException("Indique el nombre del Cliente");
            if (cli.Domicilio == string.Empty)
                throw new ValidationException("Indique la direccion Cliente");
            if (cli.Poblacion == string.Empty)
                throw new ValidationException("Indique el poblado del Cliente");
            //if (cli.Telefono == string.Empty && cli.Celular == string.Empty)
            //    throw new ValidationException("Indique un numero de Telefono o Celular");
            if (cli.EstadoCivil==string.Empty)
                throw new ValidationException("Indique estado civíl del Cliente");
            //if (cli.EstadoCivil == "Casada(o)")
            //{
            //    if (cli.Conyuge==string.Empty)
            //    throw new ValidationException("Indique nombre del conyuge");
            //}
            
            mapeoFinanciamiento.FinancieraClientes.InsertOnSubmit(cli);
            mapeoFinanciamiento.SubmitChanges();
            return cli.Clave;
        }
        public void ModificarClienteFinanciera(FinancieraCliente cliMod, FinancieraCliente cliOri)
        {
            if (cliMod.Nombre == string.Empty)
                throw new ValidationException("Indique el nombre del Cliente");
            if (cliMod.Domicilio == string.Empty)
                throw new ValidationException("Indique la direccion Cliente");
            if (cliMod.Poblacion == string.Empty)
                throw new ValidationException("Indique el poblado del Cliente");
            //if (cliMod.Telefono == string.Empty && cliMod.Celular == string.Empty)
            //    throw new ValidationException("Indique un numero de Telefono o Celular");
            if (cliMod.EstadoCivil == string.Empty)
                throw new ValidationException("Indique estado civíl del Cliente");
            //if (cliMod.EstadoCivil == "Casada(o)")
            //{
            //    if (cliMod.Conyuge == string.Empty)
            //        throw new ValidationException("Indique nombre del conyuge");
            //}
            mapeoFinanciamiento.FinancieraClientes.Attach(cliMod, cliOri);
            mapeoFinanciamiento.SubmitChanges();

        }

    }
}
