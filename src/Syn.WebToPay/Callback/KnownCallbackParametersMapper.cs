using Syn.WebToPay.Exceptions;

namespace Syn.WebToPay.Callback;

public static class KnownCallbackParametersMapper
{
    public static string ToParameterString(this KnownCallbackParameter callbackParameter)
    {
        switch (callbackParameter)
        {
            case KnownCallbackParameter.ProjectId:
                return "projectid";
            case KnownCallbackParameter.OrderId:
                return "orderid";
            case KnownCallbackParameter.Amount:
                return "amount";
            case KnownCallbackParameter.Currency:
                return "currency";
            case KnownCallbackParameter.Payment:
                return "payment";
            case KnownCallbackParameter.PayText:
                return "paytext";
            case KnownCallbackParameter.Status:
                return "status";
            case KnownCallbackParameter.Test:
                return "test";
            case KnownCallbackParameter.Country:
                return "country";
            case KnownCallbackParameter.PayerCountry:
                return "payer_country";
            case KnownCallbackParameter.PayerIpCountry:
                return "payer_ip_country";
            case KnownCallbackParameter.PaymentCountry:
                return "payment_country";
            case KnownCallbackParameter.Lang:
                return "lang";
            case KnownCallbackParameter.Name:
                return "name";
            case KnownCallbackParameter.Surename:
                return "surename";
            case KnownCallbackParameter.Email:
                return "p_email";
            case KnownCallbackParameter.RequestId:
                return "requestid";
            case KnownCallbackParameter.PayAmount:
                return "payamount";
            case KnownCallbackParameter.PayCurrency:
                return "paycurrency";
            case KnownCallbackParameter.Version:
                return "version";
            case KnownCallbackParameter.Account:
                return "account";
            case KnownCallbackParameter.PersonCodeStatus:
                return "personcodestatus";
            case KnownCallbackParameter.IdentificationSuccessful:
                return "identification_successful";
            default:
                throw new WebToPayException($"Unkown callback parameter {callbackParameter.ToString()}");
        }
    }
}