using Flunt.Notifications;
using PaymentCenter.Core.ValuesObject.Interfaces;

namespace PaymentCenter.Core.ValuesObject
{
  public class Name: IName
  {
    public string FullName { get; set; }

    public override string ToString() => FullName;
  }
}
