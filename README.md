# Примеры использования 2FA-TOTP

***
## Подключение библиотеки
Перед использованием функционала `2FA-TOTP` нужно подключить бибилиотеку `KoksOtpNet`:
```C#
using KoksOtpNet;
```
После подключения библиотеки, можно использовать весь представленный функционал.
***
## Генерация ключей
Для того что бы сгенирировать новый секретный ключ, для использование в своих проектах надо вызвать следующий метод 
```C#
//Получение byte[] нового ключа
var totpSecretKey = totp2FA.generateNewTotpSecretKey();
```
Если же нам надо сгенерировать серкретный ключ полученый от пользователя то вызываем следующий метод:
```C#
//Получение byte[] нового ключа, string userTotpKey - ключ от пользователя
var totpUserSecretKey = totp2FA.generateUserTotpSecretKey(userTotpKey); 
```
После этого можно получить ключ который должен использовать пользователь:
```C#
//Получение string ключа, из созданого нами, или хранимого от пользователя, byte [] totpBytes - отпраляемый ключ
string totpUserKey = totp2FA.getStringTotpKey(totpBytes); 
```
***
## Получение TOTP (OTP.Net)
Для получения TOTP мы можем использовать 1 из 2-х методов, имеющие разные пердаваемые параметры string или byte[]:
```C#
//Получение Totp, при параметрах byte[] totpBytes
var totp = totp2FA.GetTotp(totpBytes)
```

```C#
//Получение Totp, при параметрах string totpString
var totp = totp2FA.GetTotp(totpString)
```
***
## Получение Цифр из TOTP выдаваемых пользователю
Для получения TOTP цифр мы можем использовать 1 из 3-х методов, имеющие разные пердаваемые параметры string, byte[] или Totp:
```C#
//Получение string totp цифр, при параметрах byte[] totpBytes
string totpNumbers = totp2FA.getTotpNumbers(totpBytes)
```

```C#
//Получение string totp цифр, при параметрах string totpString
string totpNumbers = totp2FA.getTotpNumbers(totpString)
```
```C#
//Получение string totp цифр, при параметрах Totp totp
string totpNumbers = totp2FA.getTotpNumbers(totp)
```
***