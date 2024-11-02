using System;
using System.Security.Cryptography;
using System.Text;

public class JWTEncrypt
{
    private static string SecretKey = "liegnt3874g51xm8hr2e087rvg87abcd";

    public static string EncryptToken(string token)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(SecretKey); // 32 bytes for AES-256
            aes.GenerateIV();

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            var tokenBytes = Encoding.UTF8.GetBytes(token);
            var encrypted = encryptor.TransformFinalBlock(tokenBytes, 0, tokenBytes.Length);

            return Convert.ToBase64String(aes.IV) + ":" + Convert.ToBase64String(encrypted);
        }
    }
}
