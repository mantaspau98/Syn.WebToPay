using Syn.WebToPay.Utilties;

namespace Syn.WebToPay.PaymentInitiation;

public class PaymentInitiationRequest
{
    public int ProjectId { get; init; }
    public string? Version { get; init; }
    public bool Test { get; init; }
    public string? State { get; set; }
    public string? Zip { get; set; }
    public string? CountryCode { get; set; }
    public DateTime? TimeLimit { get; set; }
    public string? PersonCode { get; set; }
    public List<string> AllowPayments { get; } = new();
    public List<string> DisallowPayments { get; } = new();
    public string? CallbackUrl { get; set; }
    public string? CancelUrl { get; set; }
    public string? OrderId { get; set; }
    public string? AcceptUrl { get; set; }
    public string? Language { get; set; }
    public int Amount { get; set; }
    public string? Currency { get; set; }
    public string? Payment { get; set; }
    public string? Country { get; set; }
    public string? PayText { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public bool BuyerConsent { get; set; }
    
    public string ToBase64String()
    {
        var dataQueryParams = new Dictionary<string, string?>
        {
            ["projectid"] = ProjectId.ToString(),
            ["orderid"] = OrderId,
            ["accepturl"] = AcceptUrl,
            ["cancelurl"] = CancelUrl,
            ["callbackurl"] = CallbackUrl,
            ["version"] = Version,
            ["lang"] = Language,
            ["amount"] = Amount.ToString(),
            ["currency"] = Currency,
            ["payment"] = Payment,
            ["country"] = Country,
            ["paytext"] = PayText,
            ["p_firstname"] = FirstName,
            ["p_lastname"] = LastName,
            ["p_email"] = Email,
            ["p_street"] = Street,
            ["p_city"] = City,
            ["p_state"] = State,
            ["p_zip"] = Zip,
            ["p_countrycode"] = CountryCode,
            ["time_limit"] = TimeLimit?.ToString("yyyy-MM-dd HH:mm:ss"),
            ["personcode"] = PersonCode,
            ["buyer_consent"] = BuyerConsent ? "1" : "0",
            ["test"] = Test ? "1" : "0",
            ["only_payments"] = string.Join(",", AllowPayments),
            ["disalow_payments"] = string.Join(",", DisallowPayments)
        };

        var dataQuery = HttpQueryUtility.BuildQueryString(dataQueryParams);
        var dataQueryAsBase64 = CryptoUtility.EncodeToBase64UrlSafe(dataQuery);

        return dataQueryAsBase64;
    }
}