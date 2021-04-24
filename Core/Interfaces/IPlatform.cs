using PaymentCenter.Core.Domain.Interface;

namespace PaymentCenter.Core.Interfaces
{
  public interface IPlatform
  {
    IPerson Payer { get; set; }
    IPerson Receiver { get; set; }
    IPaymentData PaymentData { get; set; }
  }
}
