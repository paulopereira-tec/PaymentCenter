using PaymentCenter.Infra.Shared.Enums;
using PaymentCenter.Infra.Shared.Interfaces;

namespace PaymentCenter.Platforms.Itau
{
  /// <summary>
  /// Abstrai dados relacinados ao banco Itaú
  /// </summary>
  public class Itau : IBankAccount
  {
    public int Agency { get; set; }
    public int Account { get; set; }
    public int VerifyingDigit { get; set; }
    public EBankNumbers BankNumber { get; set; }

    /// <summary>
    /// Cria uma abstração do banco Itaú.
    /// </summary>
    /// <param name="agency"></param>
    /// <param name="account"></param>
    /// <param name="verifyingDigit"></param>
    public Itau(int agency, int account, int verifyingDigit)
    {
      Agency = agency;
      Account = account;
      VerifyingDigit = verifyingDigit;
      BankNumber = EBankNumbers.Itau;
    }
  }
}
