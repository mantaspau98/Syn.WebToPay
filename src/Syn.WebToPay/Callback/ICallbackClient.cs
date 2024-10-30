namespace Syn.WebToPay.Callback;

public interface ICallbackClient
{
    string GetDataFromQuery(string query);
    CallbackData GetMacroCallbackData(string base64EncodedData);
}