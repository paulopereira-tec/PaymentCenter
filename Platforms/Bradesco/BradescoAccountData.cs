using PaymentCenter.Core.Domain.Entities;

namespace PaymentCenter.Platforms.Bradesco
{
  public class BradescoAccountData: AccountDataForBank
  {
    public BradescoAccountData(int agency, int account, int verifyDigit, string secretKey): base(agency, account, verifyDigit, secretKey)
    {

    }
  }
}
