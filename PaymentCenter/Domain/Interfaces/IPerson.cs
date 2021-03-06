using PaymentCenter.Infra.Shared.ValuesObject.Interfaces;
using System;

namespace PaymentCenter.Domain.Interfaces
{
  /// <summary>
  /// Abstrai os dados de uma pessoa, física ou jurídica
  /// </summary>
  public interface IPerson
  {
    IName Name { get; }
    IAddress Address { get; }
    IDocument Document { get; }
    DateTime BirthDate { get; }
  }
}
