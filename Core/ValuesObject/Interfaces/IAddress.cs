using PaymentCenter.Core.Enums;

namespace PaymentCenter.Core.ValuesObject.Interfaces
{
  public interface IAddress
  {
    EAddressType Type { get; set; }
    string Street { get; set; }
    string Number { get; set; }
    string Neigborhood { get; set; }
    string City { get; set; }
    string State { get; set; }
    string Zipcode { get; set; }
    string Complement { get; set; }
  }
}
