namespace Syn.WebToPay.Callback;

public class CallbackData
{
    public string? OrderId { get; set; }
    public string? Language { get; set; }
    public int Amount { get; set; }
    public string? Currency { get; set; }
    public string? Payment { get; set; }
    public string? Country { get; set; }
    public string? PayText { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Status { get; set; }
    public bool Test { get; set; }
    public string? Email { get; set; }
    public int RequestId { get; set; }
    public int PayAmount { get; set; }
    public string? PayCurrency { get; set; }
    public string? Version { get; set; }
    public string? Account { get; set; }
    public int? PersonCodeStatus { get; set; }
    public int? IdentificationSuccessful { get; set; }
    public int ProjectId { get; set; }

    public bool IsPaymentSuccessful => Status == 1;
}