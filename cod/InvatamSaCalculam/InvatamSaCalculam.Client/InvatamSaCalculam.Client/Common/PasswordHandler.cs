using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace InvatamSaCalculam.Client.Common
{
    public class PasswordHandler
    {
        private PasswordHandler()
        {}

        private static PasswordHandler instance;
        public static PasswordHandler Instance
        {
            get { return instance ?? (instance = new PasswordHandler()); }
        }

        public string EncryptString(string clearText)
        {
            byte[] clearTextBytes = Encoding.UTF8.GetBytes(clearText);
            System.Security.Cryptography.SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();
            MemoryStream ms = new MemoryStream();
            byte[] rgbIV = Encoding.ASCII.GetBytes("ryojvlzffalyglrj");
            byte[] key = Encoding.ASCII.GetBytes("hcxilkqbbffffeultgbskdmaunivmfuo");
            CryptoStream cs = new CryptoStream(ms, rijn.CreateEncryptor(key, rgbIV),
                CryptoStreamMode.Write);

            cs.Write(clearTextBytes, 0, clearTextBytes.Length);
            cs.Close();

            return Convert.ToBase64String(ms.ToArray());
        }
    }
}
