using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace VoucherExpense
{
    class Encoder
    {
        static byte[] MySalt = { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
        #region ====== RC2 ======
        public static byte[] RC2Encrypt(byte[] clearData, string Password)
            {
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, MySalt);
                MemoryStream ms = new MemoryStream();
                RC2 alg = RC2.Create();
                alg.Key = pdb.GetBytes(8);
                alg.IV = pdb.GetBytes(8);
                CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(clearData, 0, clearData.Length);
                cs.Close();
                byte[] encryptedData = ms.ToArray();
                return encryptedData;
            }
            public static byte[] RC2Decrypt(byte[] cipherData, string Password)
            {
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, MySalt);
                MemoryStream ms = new MemoryStream();
                RC2 alg = RC2.Create();
                alg.Key = pdb.GetBytes(8);
                alg.IV = pdb.GetBytes(8);
                CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(cipherData, 0, cipherData.Length);
                cs.Close();
                byte[] decryptedData = ms.ToArray();
                return decryptedData;
            }

            #endregion


            public static byte[] GetMD5(byte[] source)
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                return md5.ComputeHash(source);
            }
    }


}
