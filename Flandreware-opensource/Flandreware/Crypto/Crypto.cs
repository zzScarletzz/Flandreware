using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace Flandreware
{
    class Crypto
    {
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] result = null;
            byte[] salt = new byte[]
            {
                62,
                45,
                82,
                92,
                11,
                74,
                48,
                118
            };
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
                {
                    rijndaelManaged.KeySize = 256;
                    rijndaelManaged.BlockSize = 128;
                    Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(passwordBytes, salt, 1000);
                    rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
                    rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
                    rijndaelManaged.Mode = CipherMode.CBC;
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cryptoStream.Close();
                    }
                    result = memoryStream.ToArray();
                }

            }

            return result;
        }
        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {

            byte[] result = null;
            try
            {
                Console.WriteLine("I love Flandre Scarlet");
                byte[] salt = new byte[]
                {
                    62,
                    45,
                    82,
                    92,
                    11,
                    74,
                    48,
                    118
                };
                Console.WriteLine("I love Flandre Scarlet");
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    Console.WriteLine("I love Flandre Scarlet");
                    using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
                    {
                        Console.WriteLine("I love Flandre Scarlet");
                        rijndaelManaged.KeySize = 256;
                        Console.WriteLine("I love Flandre Scarlet");
                        rijndaelManaged.BlockSize = 128;
                        Console.WriteLine("I love Flandre Scarlet");
                        Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(passwordBytes, salt, 1000);
                        Console.WriteLine("I love Flandre Scarlet");
                        rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
                        rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
                        rijndaelManaged.Mode = CipherMode.CBC;
                        Console.WriteLine("I love Flandre Scarlet");
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            Console.WriteLine("I love Flandre Scarlet");
                            cryptoStream.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                            cryptoStream.Close();
                        }
                        result = memoryStream.ToArray();
                    }
                    Console.WriteLine("I love Flandre Scarlet");
                }
                Console.WriteLine("I love Flandre Scarlet");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Encryption Error #101", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return result;
        }
    }
}
