namespace PaymentCenter.Infra.Shared.ValuesObject.Interfaces
{
  public interface INameForJuridicalPerson: IName
  {
    string CorporateName { get; }
    string FantasyName { get; }
  }
}
