using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoksOtpNet;

namespace Examples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Получение byte[] нового ключа
            var totpSecretKey = totp2FA.generateNewTotpSecretKey();

            //Получение string ключа, из созданого нами, или хранимого от пользователя, byte [] totpBytes 
            string totpUserKey = totp2FA.getStringTotpKey(totpSecretKey);

            //Получение Totp, при параметрах string totpString
            var totp = totp2FA.GetTotp(totpUserKey);

            //Получение string totp цифр, при параметрах Totp totp
            string totpNumbers = totp2FA.getTotpNumbers(totp);

            //Получение bool результата проверки кодов, при параметрах byte[] totpBytes и string userCode
            bool totpAuthResult = totp2FA.verifyTotp(totp, userCode:"123456");

            //Получение int количества секунд оставшихся, до обновления кода при параметрах Totp totp 
            int updateTotpSeconds = totp2FA.getTotpSeconds(totp);
        }
    }
}
