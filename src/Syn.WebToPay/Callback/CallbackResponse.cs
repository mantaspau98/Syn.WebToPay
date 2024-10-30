namespace Syn.WebToPay.Callback;

public static class CallbackResponse
{
    private const string OkStatus = "OK";

    public static string SuccessReponseStatus()
    {
        return OkStatus;
    }
}