namespace PaymentCenter.Infra.Shared.ValuesObject.Interfaces
{
  public interface INameForPhisicalPerson: IName
  {
    string FirstName { get; }
    string LastName { get; }
  }
}
