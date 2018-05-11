using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace AuthProvider.Crypto
{
    public class RS256
    {
        private readonly string KeyPath;
        private X509Certificate2 x509;

        public RS256(string _keyPath)
        {
            KeyPath = _keyPath;
            byte[] RawData = null; // here we gotta import the cert
            x509 = new X509Certificate2();
            x509.Import(RawData);

        }

        public string Sign(byte [] message) //returns a base64 encoded signature
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(x509.PrivateKey.ToXmlString(true)); 
            return Convert.ToBase64String(rsa.SignData(message,CryptoConfig.MapNameToOID("SHA256"))); //MapNameToOID should return the algorithm
            
        }
        


    }
}
