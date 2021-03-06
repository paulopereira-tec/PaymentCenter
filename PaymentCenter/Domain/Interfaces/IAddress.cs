namespace PaymentCenter.Domain.Interfaces
{
  public class IAddress
  {
    string Street { get; }
    string Neigborhood { get; }
    string City { get; }
    string State { get; }
    string Zipcode { get; }
    string Complement { get; }
  }
}
