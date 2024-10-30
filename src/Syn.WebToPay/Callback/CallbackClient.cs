using System.Security.Cryptography;
using System.Text;
using System.Web;
using Syn.WebToPay.Exceptions;
using Syn.WebToPay.Utilties;

namespace Syn.WebToPay.Callback;

public class CallbackClient(WebToPayOptions options) : ICallbackClient
{
    private readonly int _projectId = options.ProjectId;
    private readonly string _password = options.SignPassword;

    public string GetDataFromQuery(string query)
    {
        var queryValues = HttpUtility.ParseQueryString(query);
        
        var base64EncodedData = queryValues["data"];
        
        if (string.IsNullOrEmpty(base64EncodedData))
        {
            throw new WebToPayException("data is null or empty");
        }

        return base64EncodedData;
    }
    
    public CallbackData GetMacroCallbackData(string base64EncodedData)
    {
        var data = CryptoUtility.DecodeBase64UrlSafeToByteArray(base64EncodedData);
        
        int ivLength = AesGcm.NonceByteSizes.MaxSize;
        byte[] iv = new byte[ivLength];
        Array.Copy(data, 0, iv, 0, ivLength);

        byte[] ciphertext = new byte[data.Length - ivLength - 16];
        Array.Copy(data, ivLength, ciphertext, 0, ciphertext.Length);

        byte[] tag = new byte[16];
        Array.Copy(data, data.Length - 16, tag, 0, 16);

        string decryptedText = CryptoUtility.DecryptAesGcm(Encoding.ASCII.GetBytes(_password), iv, ciphertext, tag);
            
        var dataQueryParams = HttpQueryUtility.ParseQueryString(decryptedText);

        CallbackData callbackData = CallbackDataParser.ParseData(dataQueryParams);
        
        if (callbackData.ProjectId != _projectId)
        {
            throw new WebToPayException($"Bad project Id received: {callbackData.ProjectId}. Project id must be: {_projectId}");
        }

        return callbackData;
    }
}