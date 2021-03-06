namespace PaymentCenter.Infra.Shared.Interfaces
{
  /// <summary>
  /// Implementa as validações que devem existir para manter a integridade dos dados.
  /// </summary>
  public interface IValidatable
  {
    /// <summary>
    /// Realiza validações necessárias para manter a integridade dos dados.
    /// </summary>
    void Validate();
  }
}
