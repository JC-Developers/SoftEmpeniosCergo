using System;
using System.Text;
using SoftEmpenios.Properties;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace SoftEmpenios.Clases
{
    public class clsModificarConfiguracion
{
    // Fields
    private string archivoConfig = "";
    private string sLlave = "j.ch.p.29/01/08.";

    // Methods
    public clsModificarConfiguracion()
    {
        try
        {
            this.archivoConfig = System.Windows.Forms.Application.ExecutablePath + ".config";
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    public string configGetValue(string Clave)
    {
        try
        {
            string valor = "";
            valor = Settings.Default[Clave].ToString();
            if ((Clave == "UsuarioDB") || (Clave == "ContraseniaDB"))
            {
                valor = this.DesencriptarValor(valor);
            }
            return valor;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return "";
        }
    }

    public void configSetValue(string clave, string valor)
    {
        try
        {
            if ((clave == "UsuarioDB") || (clave == "ContraseniaDB"))
            {
                valor = this.EncriptarValor(valor);
            }
            Settings.Default[clave] = valor;
            this.Salvar();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw new Exception(exception.Message);
        }
    }

    public int CreaArchivoConfig()
    {
        int num;
        try
        {
            string path = Application.ExecutablePath + ".config";
            string str2 = "";
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            builder.AppendLine("<configuration><configSections><sectionGroup name=\"userSettings\" type=\"System.Configuration.UserSettingsGroup, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\" >");
            builder.AppendLine("<section name=\"AgroDuarteTekax.Properties.Settings\" type=\"System.Configuration.ClientSettingsSection, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\" allowExeDefinition=\"MachineToLocalUser\" requirePermission=\"false\" />");
            builder.AppendLine("</sectionGroup></configSections><userSettings><AgroDuarteTekax.Properties.Settings>");
            builder.AppendLine("<setting name=\"Servidor\" serializeAs=\"String\"><value /></setting>");
            builder.AppendLine("<setting name=\"BaseDatos\" serializeAs=\"String\">");
            builder.AppendLine("<value />");
            builder.AppendLine("</setting><setting name=\"UsuarioDB\" serializeAs=\"String\"><value /></setting><setting name=\"Contrasenia\" serializeAs=\"String\"><value /></setting>");
            builder.AppendLine("<setting name=\"Pool\" serializeAs=\"String\"><value>Pooling = true;</value></setting></AgroDuarteTekax.Properties.Settings></userSettings></configuration>");
            str2 = builder.ToString();
            StreamWriter writer = new StreamWriter(path);
            writer.Write(str2);
            writer.Close();
            num = 1;
        }
        catch (Exception exception)
        {
            throw exception;
        }
        return num;
    }

    public string DesencriptarValor(string valor)
    {
        return clsMiRijndael.Desencriptar(Convert.FromBase64String(valor), this.sLlave);
    }

    public string EncriptarValor(string valor)
    {
        valor = Convert.ToBase64String(clsMiRijndael.Encriptar(valor, this.sLlave));
        return valor;
    }

    public void EncryptSectionsUser()
    {
        //System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
        //configuration.GetSectionGroup("userSettings").Sections["CasaEmpe\x00f1os.Properties.Properties.Settings"].SectionInformation.ProtectSection("RSAProtectedConfigurationProvider");
        //configuration.Save();
        //configuration = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
        //configuration.GetSectionGroup("userSettings").Sections["CasaEmpe\x00f1os.Properties.Settings"].SectionInformation.ProtectSection("RSAProtectedConfigurationProvider");
        //configuration.Save();
        System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
        configuration.GetSectionGroup("userSettings").Sections["SoftEmpenios.Properties.Settings"].SectionInformation.ProtectSection("RSAProtectedConfigurationProvider");
        configuration.Save();
        configuration = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
        configuration.GetSectionGroup("userSettings").Sections["SoftEmpenios.Properties.Settings"].SectionInformation.ProtectSection("RSAProtectedConfigurationProvider");
        configuration.Save();
    }

    public bool ExisteArchivoApp()
    {
        return File.Exists(this.archivoConfig);
    }

    public int ModificarValoresConfig(string sServer, string sBD, string sUserBD, string sPass)
    {
        try
        {
            this.configSetValue("ServidorDB", sServer);
            this.configSetValue("BasedeDatos", sBD);
            this.configSetValue("UsuarioDB", sUserBD);
            this.configSetValue("ContraseniaDB", sPass);
            this.Salvar();
            return 1;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return -1;
        }
    }

    public void Salvar()
    {
        try
        {
            Settings.Default.Save();
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
    }

    public bool ValidaClaves()
    {
        try
        {
            string str = this.configGetValue("ServidorDB");
            string str2 = this.configGetValue("BasedeDatos");
            string str3 = this.configGetValue("UsuarioDB");
            string str4 = this.configGetValue("ContraseniaDB");
            return (((((str != null) && (str != "")) && ((str2 != null) && (str2 != ""))) && (((str3 != null) && (str3 != "")) && (str4 != null))) && (str4 != ""));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return false;
        }
    }

    // Properties
    public string ArchivoConfig
    {
        get
        {
            return this.archivoConfig;
        }
        set
        {
            this.archivoConfig = value;
        }
    }
}


}
