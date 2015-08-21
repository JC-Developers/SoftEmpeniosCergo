using System;
using System.Text;
using System.Security.Cryptography;

namespace SoftEmpenios.Clases
{
    public class clsMiRijndael
    {
        // Methods
        public static string Desencriptar(byte[] bytDesEncriptar, byte[] bytPK)
        {
            Rijndael rijndael = Rijndael.Create();
            byte[] destinationArray = new byte[rijndael.IV.Length];
            byte[] buffer2 = new byte[bytDesEncriptar.Length - rijndael.IV.Length];
            string str = string.Empty;
            try
            {
                rijndael.Key = bytPK;
                Array.Copy(bytDesEncriptar, destinationArray, destinationArray.Length);
                Array.Copy(bytDesEncriptar, destinationArray.Length, buffer2, 0, buffer2.Length);
                rijndael.IV = destinationArray;
                str = Encoding.UTF8.GetString(rijndael.CreateDecryptor().TransformFinalBlock(buffer2, 0, buffer2.Length));
            }
            catch
            {
            }
            finally
            {
                rijndael.Clear();
            }
            return str;
        }

        public static string Desencriptar(byte[] bytDesEncriptar, string strPK)
        {
            return Desencriptar(bytDesEncriptar, new PasswordDeriveBytes(strPK, null).GetBytes(0x20));
        }

        public static byte[] Encriptar(string strEncriptar, byte[] bytPK)
        {
            Rijndael rijndael = Rijndael.Create();
            byte[] buffer = null;
            byte[] array = null;
            try
            {
                rijndael.Key = bytPK;
                rijndael.GenerateIV();
                byte[] bytes = Encoding.UTF8.GetBytes(strEncriptar);
                buffer = rijndael.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
                array = new byte[rijndael.IV.Length + buffer.Length];
                rijndael.IV.CopyTo(array, 0);
                buffer.CopyTo(array, rijndael.IV.Length);
            }
            catch
            {
            }
            finally
            {
                rijndael.Clear();
            }
            return array;
        }

        public static byte[] Encriptar(string strEncriptar, string strPK)
        {
            return Encriptar(strEncriptar, new PasswordDeriveBytes(strPK, null).GetBytes(0x20));
        }

        public static byte[] EncriptarDeImagen(byte[] bytEncriptar, string strPK, CipherMode cMode)
        {
            Rijndael rijndael = Rijndael.Create();
            byte[] buffer = null;
            byte[] array = null;
            try
            {
                rijndael.Key = new PasswordDeriveBytes(strPK, null).GetBytes(0x20);
                rijndael.Mode = cMode;
                byte[] destinationArray = new byte[bytEncriptar.Length - 0x22];
                Array.Copy(bytEncriptar, 0x22, destinationArray, 0, bytEncriptar.Length - 0x22);
                buffer = rijndael.CreateEncryptor().TransformFinalBlock(destinationArray, 0, destinationArray.Length);
                array = new byte[0x22 + buffer.Length];
                bytEncriptar.CopyTo(array, 0);
                buffer.CopyTo(array, 0x22);
            }
            catch
            {
            }
            finally
            {
                rijndael.Clear();
            }
            return array;
        }
    }


}
