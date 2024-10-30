namespace Syn.WebToPay.PaymentInitiation;

public interface IPaymentInitiationClient
{
    PaymentInitiationRequest NewRequest();
    string BuildRequestUrl(PaymentInitiationRequest request);
}