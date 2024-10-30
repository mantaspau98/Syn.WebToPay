using Syn.WebToPay.Utilties;

namespace Syn.WebToPay.PaymentInitiation;

public class PaymentInitiationClient(WebToPayOptions options) : IPaymentInitiationClient
{
    private readonly int _projectId = options.ProjectId;
    private readonly string _signPassword = options.SignPassword;
    private readonly bool _testMode = options.TestMode;

    public PaymentInitiationRequest NewRequest()
    {
        var macroRequest = new PaymentInitiationRequest
        {
            ProjectId = _projectId,
            Version = Consts.Version,
            Test = _testMode
        };
        return macroRequest;
    }

    public string BuildRequestUrl(PaymentInitiationRequest request)
    {
        var data = request.ToBase64String();
        var sign = CryptoUtility.HashMd5(data + _signPassword);

        var requestQueryParams = new Dictionary<string, string?>
        {
            ["data"] = data,
            ["sign"] = sign
        };

        var requestQuery = HttpQueryUtility.BuildQueryString(requestQueryParams);

        return Consts.PayUrl + "?" + requestQuery;
    }
}