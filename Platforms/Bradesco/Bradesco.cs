using PaymentCenter.Core.Abstractions;
using PaymentCenter.Core.Domain.Interface;

namespace PaymentCenter.Platforms.Bradesco
{
  public class Bradesco : Platform
  {
    public IAccountDataForBank AccountData { get; set; }

    public Bradesco(IPerson payer, IPerson receiver, IAccountDataForBank accountData) : base(payer, receiver)
    {
      AccountData = accountData;
    }

    public Bradesco(IPerson payer, IPerson receiver, IAccountDataForBank accountData, IPaymentData paymentData) : base(payer, receiver, paymentData)
    {
      AccountData = accountData;
    }
  }
}
