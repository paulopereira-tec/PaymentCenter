using PaymentCenter.Domain.Interfaces;
using PaymentCenter.Infra.Shared.Interfaces;

namespace PaymentCenter.Domain.Entities
{
  public class Address: IAddress, IValidatable
  {
    public string Street { get; }
    public string Neigborhood { get; }
    public string City { get; }
    public string State { get; }
    public string Zipcode { get; }
    public string Complement { get; }

    public Address(string street, string neigborhood, string city, string state, string zipcode, string complement)
    {
      Street = street;
      Neigborhood = neigborhood;
      City = city;
      State = state;
      Zipcode = zipcode;
      Complement = complement;

      Validate();
    }

    public void Validate()
    {

    }
  }
}
