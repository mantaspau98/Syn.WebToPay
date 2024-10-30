namespace Syn.WebToPay.Callback;

public static class CallbackDataParser
{
    public static CallbackData ParseData(Dictionary<string, string> dataParameters)
    {
        var callbackData = new CallbackData
        {
            ProjectId = int.Parse(dataParameters[KnownCallbackParameter.ProjectId.ToParameterString()]),
            Status = int.Parse(dataParameters[KnownCallbackParameter.Status.ToParameterString()]),
            Amount = int.Parse(dataParameters[KnownCallbackParameter.Amount.ToParameterString()]),
            OrderId = dataParameters[KnownCallbackParameter.OrderId.ToParameterString()],
            Currency = dataParameters[KnownCallbackParameter.Currency.ToParameterString()],
            Payment = dataParameters[KnownCallbackParameter.Payment.ToParameterString()],
            PayText = dataParameters[KnownCallbackParameter.PayText.ToParameterString()],
            Test = dataParameters[KnownCallbackParameter.Test.ToParameterString()] == "1"
        };

        if (dataParameters.ContainsKey(KnownCallbackParameter.PaymentCountry.ToParameterString()))
        {
            callbackData.Country = dataParameters[KnownCallbackParameter.Country.ToParameterString()];
        }

        if (dataParameters.ContainsKey(KnownCallbackParameter.Lang.ToParameterString()))
        {
            callbackData.Language = dataParameters[KnownCallbackParameter.Lang.ToParameterString()];
        }

        if (dataParameters.ContainsKey(KnownCallbackParameter.Name.ToParameterString()))
        {
            callbackData.FirstName = dataParameters[KnownCallbackParameter.Name.ToParameterString()];
        }

        if (dataParameters.ContainsKey(KnownCallbackParameter.Surename.ToParameterString()))
        {
            callbackData.LastName = dataParameters[KnownCallbackParameter.Surename.ToParameterString()];
        }

        if (dataParameters.ContainsKey(KnownCallbackParameter.Email.ToParameterString()))
        {
            callbackData.Email =dataParameters[KnownCallbackParameter.Email.ToParameterString()];
        }

        if (dataParameters.ContainsKey(KnownCallbackParameter.PayCurrency.ToParameterString()))
        {
            callbackData.PayCurrency = dataParameters[KnownCallbackParameter.PayCurrency.ToParameterString()];
        }

        if (dataParameters.ContainsKey(KnownCallbackParameter.Version.ToParameterString()))
        {
            callbackData.Version = dataParameters[KnownCallbackParameter.Version.ToParameterString()];
        }

        if (dataParameters.ContainsKey(KnownCallbackParameter.Account.ToParameterString()))
        {
            callbackData.Account = dataParameters[KnownCallbackParameter.Account.ToParameterString()];
        }
        
        if (dataParameters.ContainsKey(KnownCallbackParameter.RequestId.ToParameterString()))
        {
            callbackData.RequestId = int.Parse(dataParameters[KnownCallbackParameter.RequestId.ToParameterString()]);
        }

        if (dataParameters.ContainsKey(KnownCallbackParameter.PayAmount.ToParameterString()))
        {
            callbackData.PayAmount = int.Parse(dataParameters[KnownCallbackParameter.PayAmount.ToParameterString()]);
        }

        if (dataParameters.ContainsKey(KnownCallbackParameter.PersonCodeStatus.ToParameterString()))
        {
            callbackData.PersonCodeStatus = int.Parse(dataParameters[KnownCallbackParameter.PersonCodeStatus.ToParameterString()]);
        }
        
        if (dataParameters.ContainsKey(KnownCallbackParameter.IdentificationSuccessful.ToParameterString()))
        {
            callbackData.IdentificationSuccessful = int.Parse(dataParameters[KnownCallbackParameter.IdentificationSuccessful.ToParameterString()]);
        }

        return callbackData;
    }
}