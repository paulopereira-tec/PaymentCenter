namespace PaymentCenter.Core.Domain.Interface
{
  public interface IAccountDataForBank: IAccountData
  {
    int Agency { get; set; }
    int AccountNumber { get; set; }
    int VerifyDigit { get; set; }
  }
}
