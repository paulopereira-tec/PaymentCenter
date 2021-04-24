using PaymentCenter.Core.Domain.Interface;

namespace PaymentCenter.Core.Domain.Entities
{
  public class AccountDataForBank: AccountData, IAccountDataForBank
  {
    public int Agency { get; set; }
    public int AccountNumber { get; set; }
    public int VerifyDigit { get; set; }

    public AccountDataForBank(int agency, int accountNumber, int verifyDigit): base(null)
    {
      Agency = agency;
      AccountNumber = accountNumber;
      VerifyDigit = verifyDigit;
    }

    public AccountDataForBank(int agency, int accountNumber, int verifyDigit, string secretKey) : base(secretKey)
    {
      Agency = agency;
      AccountNumber = accountNumber;
      VerifyDigit = verifyDigit;
    }
  }
}
