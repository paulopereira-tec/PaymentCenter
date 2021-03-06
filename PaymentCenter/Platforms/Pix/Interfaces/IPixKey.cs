namespace PaymentCenter.Platforms.Pix.Interfaces
{
  /// <summary>
  /// Estabelece métodos e propriedades para gerar uma chave de pagamento Pix
  /// </summary>
  public interface IPixKey
  {
    /// <summary>
    /// Chave a ser utilizada por ocasião do pagamento.
    /// </summary>
    public string Key { get; set; }
  }
}
