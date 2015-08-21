using System.Linq;

namespace SoftEmpenios.Clases
{
    class clsValidadoresNumericos
    {
        
        public static bool numero(char e)
        {
            string caracterpermitido = "0123456789.\b";
            bool Existe;
            Existe = caracterpermitido.Contains(e);
            
            if (Existe)
                return false;
            else
                return true;
        }
    }
}
