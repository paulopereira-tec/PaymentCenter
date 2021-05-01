using PaymentCenter.Core.Domain.Interface;
using PaymentCenter.Core.Enums;
using PaymentCenter.Core.ValuesObject;
using PaymentCenter.Core.ValuesObject.Interfaces;
using System;
using System.Collections.Generic;

namespace PaymentCenter.Core.Domain.Entities
{
  public class Person : IPerson
  {
    public IName Name { get; set; }
    public DateTime BirthDate { get; set; }
    public IList<Address> Addresses { get; set; }
    public EPersonalitty Personality { get; set; }
    public IDocument Document { get; set; }
    public string Email { get; set; }

    public Person(IName name, Address address, IDocument document, string email)
    {
      Addresses = new List<Address>();

      Name = name;
      Addresses.Add(address);
      Document = document;
      Email = email;
      Personality = (document.PureDocument().Length == 11) ? EPersonalitty.PF: EPersonalitty.PJ;
    }

    public Person(IName name, Address address, string email)
    {
      Addresses = new List<Address>();

      Name = name;
      Addresses.Add(address);
      Email = email;
    }

    public Person(IName name, Address address)
    {
      Addresses = new List<Address>();

      Name = name;
      Addresses.Add(address);
    }

    public Person(IName name)
    {
      Addresses = new List<Address>();

      Name = name;
    }

    public void AddAddress(Address address)
    {
      Addresses.Add(address);
    }
  }
}
