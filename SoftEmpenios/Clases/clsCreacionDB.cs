using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace SoftEmpenios.Clases
{
    internal class clsCreacionBD
    {
        // Fields
        private string script;

        // Methods
        private string contenidoArchivoScript(string nombreArchivoScript)
        {
            string str2;
            string str = "";
            string path = Application.StartupPath + @"\ScripBaseDatos\" + nombreArchivoScript;
            StringBuilder builder = new StringBuilder();
            StreamReader reader = File.OpenText(path);
            while ((str2 = reader.ReadLine()) != null)
            {
                builder.AppendLine(str2);
            }
            str = builder.ToString();
            reader.Close();
            return str;
        }

        public bool CrearBD(string nombreServidor, string usuario, string password, string nuevaBd)
        {
            if (nuevaBd != "")
            {
                this.prepararScript("SoftEmpeniosDB.sql", nuevaBd, usuario, password, nombreServidor);
            }
            return ((nombreServidor.Trim() != "") && this.EjecutarScriptSQLConSmo(nombreServidor, usuario, password, nuevaBd));
        }

        private bool EjecutarScriptSQLConSmo(string m_nombreServidor, string m_login, string m_password, string nombreNuevaBase)
        {
            bool flag;
            try
            {
                if (this.script == "")
                {
                    return false;
                }
                ServerConnection serverConnection = new ServerConnection
                {
                    ServerInstance = m_nombreServidor
                };
                if (m_login != "")
                {
                    serverConnection.LoginSecure = false;
                    serverConnection.Login = m_login;
                    serverConnection.Password = m_password;
                }
                serverConnection.Connect();
                Server server = new Server(serverConnection);
                serverConnection.ExecuteNonQuery(this.script);
                flag = true;
            }
            catch (ConnectionFailureException)
            {
                MessageBox.Show("Conexi\x00f3n al servidor fallada.");
                flag = false;
            }
            catch (SmoException exception)
            {
                throw exception;
            }
            catch (Exception exception2)
            {
                throw exception2;
            }
            return flag;
        }

        private void prepararScript(string archivoSQL, string nombreNuevaBase, string usu, string pass, string server)
        {
            try
            {
                this.script = this.contenidoArchivoScript(archivoSQL);
                this.script = this.script.Replace("SoftEmpeñosDB", nombreNuevaBase);
                ServerConnection serverConnection = new ServerConnection(server, usu, pass);
                Server server2 = new Server(serverConnection);
                string rootDirectory = server2.Information.RootDirectory;
                this.script = this.script.Replace(@"C:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL", rootDirectory);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }


}
