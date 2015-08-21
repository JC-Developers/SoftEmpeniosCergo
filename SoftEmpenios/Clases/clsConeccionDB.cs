using System;
using System.Data.SqlClient;

namespace SoftEmpenios.Clases
{
    public class clsConeccionDB
    {
        // Methods
        public void crearArchivoConfig()
        {
        }

        public string leerSetting(string clave)
        {
            string str2;
            try
            {
                str2 = new clsModificarConfiguracion().configGetValue(clave);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str2;
        }

        public bool ProbarConexion(string cadenaconect)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaconect);
                connection.Open();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string StringConn()
        {
            return ("Data Source=" + this.leerSetting("ServidorDB") + ";" + "Initial catalog=" + this.leerSetting("BasedeDatos") + ";" + "User ID=" + this.leerSetting("UsuarioDB") + ";" + "Password=" + this.leerSetting("ContraseniaDB"));
        }
    }


}
