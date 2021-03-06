using PaymentCenter.Infra.Shared.Enums;

namespace PaymentCenter.Infra.Shared.Interfaces
{
  /// <summary>
  /// Estabelece métodos e propriedades para a abstração dos dados de um banco.
  /// </summary>
  public interface IBankAccount
  {
    /// <summary>
    /// Número da agência bancária
    /// </summary>
    int Agency { get; set; }

    /// <summary>
    /// Número da conta bancária
    /// </summary>
    int Account { get; set; }

    /// <summary>
    /// Dígito verificado da conta bancária
    /// </summary>
    int VerifyingDigit { get; set; }

    /// <summary>
    /// Código número do banco estabelecido pelo banco central
    /// </summary>
    EBankNumbers BankNumber { get; set; }
  }
}
