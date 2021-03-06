using PaymentCenter.Domain.Interfaces;
using PaymentCenter.Infra.Shared.Abstractions;
using PaymentCenter.Infra.Shared.Interfaces;

namespace PaymentCenter.Platforms.Itau
{
  /// <summary>
  /// Cria opção de pagamento por boleto bancário do banco Itaú
  /// </summary>
  public class ItauBillet : PaymentWithBillet, IBankBillet
  {
    /// <summary>
    /// Instancia opção de pagamento passando os dados da conta e pagamento.
    /// </summary>
    /// <param name="agency"></param>
    /// <param name="account"></param>
    /// <param name="verifyingDigit"></param>
    public ItauBillet(IBankAccount account) : base(account){}

    public string BarcodeNumber { get; set; }

    public void Print()
    {
    }

    public void ConfigureHolders(IPerson payer, IPerson receiver)
    {
    }

    public void Execute(IPaymentData paymentData)
    {
      Print();
    }
  }
}
