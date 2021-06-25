using PaymentCenter.Core.Abstractions;
using PaymentCenter.Core.Domain.Interface;

namespace PaymentCenter.Platforms.Santander
{
  public class Santander : Platform
  {
    public IAccountDataForBank AccountData { get; set; }

    public Santander(IPerson payer, IPerson receiver, IAccountDataForBank accountData) : base(payer, receiver)
    {
      AccountData = accountData;
    }

    public Santander(IPerson payer, IPerson receiver, IAccountDataForBank accountData, IPaymentData paymentData) : base(payer, receiver, paymentData)
    {
      AccountData = accountData;
    }
  }
}
