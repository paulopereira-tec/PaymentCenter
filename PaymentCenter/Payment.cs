using PaymentCenter.Domain.Interfaces;
using PaymentCenter.Infra.Shared.Interfaces;

namespace PaymentCenter
{
  /// <summary>
  /// Abstrai e prepara os dados para execução dos pagamentos.
  /// </summary>
  public class Payment
  {
    private IPerson _payer { get; set; }
    private IPerson _receiver { get; set; }
    private IPaymentData _paymentData { get; set; }
    private IPlatform _platform { get; set; }

    /// <summary>
    /// Instancia um pagamento passando nos parâmetros as pessoas pagadora, recebedora, dados do pagamento e a plataforma de pagamento.
    /// </summary>
    /// <param name="payer"></param>
    /// <param name="receiver"></param>
    /// <param name="paymentData"></param>
    public Payment(IPerson payer, IPerson receiver, IPaymentData paymentData, IPlatform platform)
    {
      _payer = payer;
      _receiver = receiver;
      _paymentData = paymentData;
      _platform = platform;
    }

    public Payment Execute()
    {
      _platform.Execute(_paymentData);
      return this;
    }
  }
}
