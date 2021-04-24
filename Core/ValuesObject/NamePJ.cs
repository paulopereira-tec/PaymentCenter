using Flunt.Validations;

namespace PaymentCenter.Core.ValuesObject
{
  public class NamePJ : Name, IValidatable
  {
    public string Corportate { get; set; }
    public string Fantasy { get; set; }

    public void Validate() { }

    public NamePJ(string corportate, string fantasy)
    {
      Corportate = corportate;
      Fantasy = fantasy;
      FullName = corportate;

      Validate();
    }

    public NamePJ(string corportate)
    {
      Corportate = corportate;
      FullName = corportate;

      Validate();
    }
  }
}
