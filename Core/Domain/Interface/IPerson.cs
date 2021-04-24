using PaymentCenter.Core.Enums;
using PaymentCenter.Core.ValuesObject;
using PaymentCenter.Core.ValuesObject.Interfaces;
using System;
using System.Collections.Generic;

namespace PaymentCenter.Core.Domain.Interface
{
  public interface IPerson
  {
    IName Name { get; set; }
    DateTime BirthDate { get; set; }
    IList<Address> Addresses { get; set; }
    EPersonalitty Personality { get; set; }
    IDocument Document { get; set; }
    string Email { get; set; }
  }
}
