using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Parameters;
using System.Text;

namespace AuthProvider.Crypto
{
    public class RS256
    {
        private static RSACryptoServiceProvider rsa;

        public static void Configure(string keyPath)
        {
            Logger.LogInfo("Reading Private key from: " + keyPath);
            PemReader pr = new PemReader(System.IO.File.OpenText(keyPath));
            RsaPrivateCrtKeyParameters KeyPair = (RsaPrivateCrtKeyParameters)pr.ReadObject();
            RSAParameters RSAParams = DotNetUtilities.ToRSAParameters(KeyPair);
            rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(RSAParams);
        }
        private static string BytesToStr(byte [] bytes)
        {
            StringBuilder result = new StringBuilder(); 
            for(int i =0; i < bytes.Length; i ++)
            {
                result.AppendFormat("{0:x2}",bytes[i]).Append(" ");
            }
            return result.ToString();
        }
        public static string Sign(byte [] message) //returns a base64 encoded signature
        {
            Logger.LogInfo("Generating signature for message: " + BytesToStr(message));
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte [] Signature = rsa.SignData(message, CryptoConfig.MapNameToOID("SHA256"));
            Logger.LogInfo("Generated signature: " + BytesToStr(Signature));
            return Convert.ToBase64String(Signature);
        }

    }
}
