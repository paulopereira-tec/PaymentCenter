namespace PaymentCenter.Infra.Shared.Interfaces
{
  /// <summary>
  /// Estabelece os métodos e as propriedades para boletos bancários.
  /// </summary>
  public interface IBankBillet: IPlatform, IPrintablePayment
  {
    /// <summary>
    /// Código da linha digitável do boleto.
    /// </summary>
    string BarcodeNumber { get; set; }
  }
}
