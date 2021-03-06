using PaymentCenter.Infra.Shared.Interfaces;
using PaymentCenter.Infra.Shared.ValuesObject.Interfaces;

namespace PaymentCenter.Infra.Shared.ValuesObject
{
  /// <summary>
  /// Abstrai o nome de uma empresa - Pessoa Jurídica.
  /// </summary>
  public class NameForJuridicalPerson : INameForJuridicalPerson, IValidatable
  {
    public string FullName { get; }
    public string CorporateName { get; }
    public string FantasyName { get; }

    public NameForJuridicalPerson(string corporate, string fantasy)
    {
      CorporateName = corporate;
      FantasyName = fantasy;
      FullName = corporate;

      Validate();
    }

    public NameForJuridicalPerson(string corporate)
    {
      CorporateName = corporate;
      FullName = corporate;

      Validate();
    }

    public void Validate()
    {

    }
  }
}
