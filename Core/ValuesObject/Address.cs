using Flunt.Notifications;
using Flunt.Validations;
using PaymentCenter.Core.Enums;
using PaymentCenter.Core.ValuesObject.Interfaces;
using System.Text.RegularExpressions;

namespace PaymentCenter.Core.ValuesObject
{
  public class Address: Notifiable, IAddress, IValidatable
  {
    public EAddressType Type { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string Neigborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zipcode { get; set; }
    public string Complement { get; set; }

    public void Validate() { }

    public Address(string street, string number, string neigborhood, string city, string state, string zipcode, string complement, EAddressType type = EAddressType.Charge)
    {
      Street = street;
      Number = number;
      Neigborhood = neigborhood;
      City = city;
      State = state;
      Zipcode = zipcode;
      Complement = zipcode;
      Type = type;

      Validate();
    }

    public string PureZipcode()
    {
      return Regex.Replace(Zipcode, @"-|\.", "");
    }

    public override string ToString()
      => Street + ", " + Number + " - " + Neigborhood + " - " + City + ", " + State + " - " + Zipcode;
  }
}
