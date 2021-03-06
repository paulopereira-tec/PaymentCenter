using PaymentCenter.Domain.Interfaces;

namespace PaymentCenter.Infra.Shared.Interfaces
{
  /// <summary>
  /// Estabelece métodos e propriedades para plataformas de pagamento.
  /// </summary>
  public interface IPlatform
  {
    /// <summary>
    /// Configura todos os interessados nesse pagamento.
    /// </summary>
    /// <param name="payer"></param>
    /// <param name="receiver"></param>
    public void ConfigureHolders(IPerson payer, IPerson receiver);

    /// <summary>
    /// Executa o pagamento conforme os parâmetros passados.
    /// </summary>
    /// <param name="paymentData"></param>
    public void Execute(IPaymentData paymentData);
  }
}
