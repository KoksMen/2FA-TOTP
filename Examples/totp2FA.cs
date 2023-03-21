using OtpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoksOtpNet
{
    public static class totp2FA
    {
        public static byte[] generateNewTotpSecretKey()
        {
            var totpKey = KeyGeneration.GenerateRandomKey(30);
            return totpKey;
        }

        public static byte[] generateUserTotpSecretKey(string userTotpKey) 
        {
            userTotpKey.Replace(" ", "");
            var totpKey = OtpNet.Base32Encoding.ToBytes(userTotpKey);
            return totpKey;
        }

        public static string getStringTotpKey(byte[] totpBytes)
        {
            string totpStringKey = OtpNet.Base32Encoding.ToString(totpBytes);
            return totpStringKey;
        }

        public static Totp GetTotp(byte[] totpBytes) 
        {
            var totp = new Totp(totpBytes, step: 30);
            return totp;
        }
        public static Totp GetTotp(string totpString)
        {
            var totpBytes = generateUserTotpSecretKey(totpString);
            return GetTotp(totpBytes);
        }

        public static string getTotpNumbers(byte[] totpBytes)
        {
            var totp = GetTotp(totpBytes);
            return totp.ComputeTotp();
        }
        public static string getTotpNumbers(Totp totp)
        {
            return totp.ComputeTotp();
        }
        public static string getTotpNumbers(string totpString)
        {
            var totp = GetTotp(totpString);
            return totp.ComputeTotp();
        }
        public static bool verifyTotp(byte[] totpBytes, string userCode)
        {
            Totp totp = GetTotp(totpBytes);
            return verifyTotp(totp, userCode);
        }
        public static bool verifyTotp(string totpString, string userCode)
        {
            Totp totp = GetTotp(totpString);
            return verifyTotp(totp, userCode);
        }
        public static bool verifyTotp(Totp totp, string userCode)
        {
            bool verifyResult = totp.VerifyTotp(userCode, out long time);
            return verifyResult;
        }
    }
}
