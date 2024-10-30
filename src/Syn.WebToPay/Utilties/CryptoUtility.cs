using System.Security.Cryptography;
using System.Text;

namespace Syn.WebToPay.Utilties;

internal static class CryptoUtility
{
    public static string HashMd5(string text)
    {
        var md5 = MD5.Create();
        var textAsBytes = Encoding.UTF8.GetBytes(text);
        var hash = md5.ComputeHash(textAsBytes);
        var sb = new StringBuilder();
        foreach (var t in hash)
        {
            sb.Append(t.ToString("x2"));
        }

        return sb.ToString();
    }

    public static string EncodeToBase64UrlSafe(string text)
    {
        var textBytes = Encoding.UTF8.GetBytes(text);
        var base64Text = Convert.ToBase64String(textBytes);
        
        return base64Text.Replace('+', '-').Replace('/', '_');
    }
    
    public static byte[] DecodeBase64UrlSafeToByteArray(string encodedData) => 
        Convert.FromBase64String(encodedData.Replace('-', '+').Replace('_', '/'));

    public static string DecryptAesGcm(byte[] key, byte[] nonce, byte[] ciphertext, byte[] tag)
    {
        using var aesGcm = new AesGcm(key, tag.Length);
        var plaintext = new byte[ciphertext.Length];
        aesGcm.Decrypt(nonce, ciphertext, tag, plaintext);
        return Encoding.UTF8.GetString(plaintext);
    }
}