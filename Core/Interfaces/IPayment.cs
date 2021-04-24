namespace PaymentCenter.Core.Interfaces
{
  public interface IPayment
  {
    IPayment Create();
    IPayment Read();
    IPayment Read(int id);
    IPayment Update(int id);
    IPayment Delete(int id);
  }
}
