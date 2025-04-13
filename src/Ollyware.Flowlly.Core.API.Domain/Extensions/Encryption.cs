using Microsoft.Extensions.Configuration;
using Ollyware.Flowlly.Core.API.Domain.ConfigurableObjects;
using System.Security.Cryptography;
using System.Text;

namespace Ollyware.Flowlly.Core.API.Domain.Extensions;

public static class EncryptionExtensions
{
    private static EncryptionSettings? _encryptionSettings;

    public static void ConfigureEncryption(IConfiguration configuration)
    {
        _encryptionSettings = configuration.GetSection(EncryptionSettings.Key).Get<EncryptionSettings>();

        if (_encryptionSettings == null || string.IsNullOrWhiteSpace(_encryptionSettings.AesKey) || string.IsNullOrWhiteSpace(_encryptionSettings.AesIV))
            throw new InvalidOperationException("Encryption settings are missing or invalid.");
    }

    public static string EncryptIt(this string plainText)
    {
        var aes = InitializeAes();

        using var encryptor = aes.CreateEncryptor();

        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
        using var sw = new StreamWriter(cs);

        sw.Write(plainText);
        sw.Flush();
        cs.FlushFinalBlock();

        return Convert.ToBase64String(ms.ToArray());
    }

    public static string DecryptIt(this string cipherText)
    {
        var aes = InitializeAes();

        var buffer = Convert.FromBase64String(cipherText);

        using var ms = new MemoryStream(buffer);
        using var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);

        return sr.ReadToEnd();
    }

    private static Aes InitializeAes()
    {
        using var aes = Aes.Create();

        aes.Key = Encoding.UTF8.GetBytes(_encryptionSettings.AesKey);
        aes.IV = Encoding.UTF8.GetBytes(_encryptionSettings.AesIV);

        return aes;
    }
}
