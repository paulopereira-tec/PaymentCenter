using PaymentCenter.Infra.Shared.Interfaces;
using PaymentCenter.Infra.Shared.ValuesObject.Interfaces;

namespace PaymentCenter.Infra.Shared.ValuesObject
{
  /// <summary>
  /// Abstrai os dados de uma pessoa física.
  /// </summary>
  public class NameForPhisicalPerson: INameForPhisicalPerson, IValidatable
  {
    public string FullName { get; }
    public string FirstName { get; }
    public string LastName { get; }

    /// <summary>
    /// Instancia uma pessoa física passando como parâmetros o primeiro e segundo nome.
    /// </summary>
    /// <param name="first"></param>
    /// <param name="last"></param>
    public NameForPhisicalPerson(string first, string last)
    {
      FirstName = first;
      LastName = last;
      FullName = first + " " + last;

      Validate();
    }
    
    public void Validate()
    {

    }
  }
}
