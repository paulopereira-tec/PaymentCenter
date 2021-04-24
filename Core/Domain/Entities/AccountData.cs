using Flunt.Notifications;
using PaymentCenter.Core.Domain.Interface;

namespace PaymentCenter.Core.Domain.Entities
{
  public class AccountData: Notifiable, IAccountData
  {
    public string SecretKey { get; set; }

    public AccountData(string secretKey)
    {
      SecretKey = secretKey;
    }
  }
}
