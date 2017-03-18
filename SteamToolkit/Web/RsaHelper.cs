using System;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace SteamToolkit.Web
{
    internal class RsaHelper
    {
        private readonly string _password;

        /// <summary>
        /// Initializes the RsaHelper with the specified password
        /// </summary>
        /// <param name="password">Password to use</param>
        public RsaHelper(string password)
        {
            _password = password;
        }
        
        /// <summary>
        /// Encrypts the password retrieved through according to the response getting encryption keys from steam.
        /// </summary>
        /// <param name="response">Response containing encryption keys.</param>
        /// <returns>Encrypted password</returns>
        public string EncryptPassword(IResponse response)
        {
            if (!DeserializeRsaKey(response.ReadStream())) return null;

            //RSA Encryption
            var rsa = new RSACryptoServiceProvider();
            var rsaParameters = new RSAParameters
            {
                Exponent = HexToByte(RsaJson.PublicKeyExp),
                Modulus = HexToByte(RsaJson.PublicKeyMod)
            };

            rsa.ImportParameters(rsaParameters);

            byte[] bytePassword = Encoding.ASCII.GetBytes(_password);
            byte[] encodedPassword = rsa.Encrypt(bytePassword, false);
            return Convert.ToBase64String(encodedPassword);
        }

        private bool DeserializeRsaKey(string response)
        {
            RsaKey rsaJson = JsonConvert.DeserializeObject<RsaKey>(response);
            if (!rsaJson.Success) return false;
            RsaJson = rsaJson;
            return true;
        }

        private static byte[] HexToByte(string hex)
        {
            int hexLen = hex.Length;
            if (hexLen % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            
            byte[] ret = new byte[hexLen / 2];
            for (int i = 0; i < hexLen; i += 2)
            {
                ret[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return ret;
        }

        private static int GetHexVal(char hex)
        {
            int val = hex;
            return val - (val < 58 ? 48 : 55);
        }

        public RsaKey RsaJson { get; private set;  }
    }
}