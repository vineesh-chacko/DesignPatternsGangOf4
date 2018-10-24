using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Cardtronics.Common.Security
{
    class _256HashEncryptor
    {
        //public static void Main(string[] args)
        //{

        //    /*string text = System.IO.File.ReadAllText(@"C:\Test\Words.txt");*/



        //    /***********************Encryption**********************************************/
        //    // Get the bytes of the string


        //    string bytesEncrypted = AES_Encrypt("Test", "CardtronicsUK");

        //    byte[] bytesToBeDecrypted = Convert.FromBase64String(bytesEncrypted);
        //    byte[] passwordBytesdecrypt = Encoding.UTF8.GetBytes("CardtronicsUK");
        //    passwordBytesdecrypt = SHA256.Create().ComputeHash(passwordBytesdecrypt);

        //    byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytesdecrypt);

        //    string decryptedResult = Encoding.UTF8.GetString(bytesDecrypted);

        //}

        [ComVisible(true)]
        public static string AES_Encrypt(string param1, string param2)
        {
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(param1);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(param2);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            byte[] encryptedBytes = null;
            //Salt
            byte[] saltBytes = new byte[] { 2, 1, 7, 3, 6, 4, 8, 5, 77, 77, 77, 77 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return Convert.ToBase64String(encryptedBytes); ;
        }

        [ComVisible(true)]
        public static byte[] AES_Decrypt(byte[] param1, byte[] param2)
        {
            byte[] decryptedBytes = null;
           
            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 2, 1, 7, 3, 6, 4, 8, 5,77,77,77,77 };

            using (var ms = new MemoryStream())
            {
                using (var AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(param2, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(param1, 0, param1.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
    }
}
