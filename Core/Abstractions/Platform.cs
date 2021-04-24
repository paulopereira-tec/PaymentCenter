using PaymentCenter.Core.Domain.Interface;
using PaymentCenter.Core.Interfaces;

namespace PaymentCenter.Core.Abstractions
{
  public abstract class Platform: IPlatform
  {
    public virtual IPerson Payer { get; set; }
    public virtual IPerson Receiver { get; set; }
    public virtual IPaymentData PaymentData { get; set; }

    public Platform(IPerson payer, IPerson receiver)
    {
      Payer = payer;
      Receiver = receiver;
    }

    public Platform(IPerson payer, IPerson receiver, IPaymentData paymentData): this(payer, receiver)
    {
      PaymentData = paymentData;
    }
  }
}
