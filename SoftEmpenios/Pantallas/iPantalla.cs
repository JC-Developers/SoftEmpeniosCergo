namespace SoftEmpenios.Pantallas
{
    internal interface iPantalla
    {
        void Buscar();
        //bool ConfirmarCierre();
        void Eliminar();
        void Guardar();
        void Nuevo();
        //void Paginar(int primerRegistro);
        //void Refrescar();
        //int ComandosSoportados { get; }
        string nombrePantalla { get; }
    }
}
