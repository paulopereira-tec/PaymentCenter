using PaymentCenter.Platforms.Interfaces;

namespace PaymentCenter.Infra.Shared.Abstractions
{
  public abstract class PaymentWithBillet
  {
    private IBankAccount _account { get; set; }

    public PaymentWithBillet(IBankAccount account)
    {
      _account = account;
    }
  }
}
