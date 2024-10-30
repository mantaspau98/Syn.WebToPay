using System.Text;
using System.Web;

namespace Syn.WebToPay.Utilties;

internal static class HttpQueryUtility
{
    public static string BuildQueryString(Dictionary<string, string?> queryParams)
    {
        var sb = new StringBuilder();
        foreach (var queryParam in queryParams)
        {
            if (string.IsNullOrEmpty(queryParam.Value))
            {
                continue;
            }

            if (sb.Length > 0)
            {
                sb.Append("&");
            }

            sb.Append(HttpUtility.UrlEncode(queryParam.Key));
            sb.Append("=");
            sb.Append(HttpUtility.UrlEncode(queryParam.Value));
        }

        return sb.ToString();
    }
    
    public static Dictionary<string, string> ParseQueryString(string queryString)
    {
        var queryParams = new Dictionary<string, string>();
        var queryParamCollection = HttpUtility.ParseQueryString(queryString);
        
        foreach (var key in queryParamCollection.AllKeys)
        {
            queryParams[key!] = queryParamCollection[key]!;
        }

        return queryParams;
    }
}