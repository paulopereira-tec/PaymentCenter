using PaymentCenter.Domain.Interfaces;
using PaymentCenter.Infra.Shared.Interfaces;
using PaymentCenter.Infra.Shared.ValuesObject.Interfaces;
using System;

namespace PaymentCenter.Domain.Entities
{
  public class Person : IPerson, IValidatable
  {
    public IName Name { get; }

    public IAddress Address { get; }

    public IDocument Document { get; }

    /// <summary>
    /// Data de nascimento. Regra: não pode ser igual ou depois (superior) que a data atual.
    /// </summary>
    public DateTime BirthDate { get; }

    /// <summary>
    /// Instancia uma pessoa jurídica e documento
    /// </summary>
    /// <param name="name"></param>
    /// <param name="document"></param>
    public Person(INameForJuridicalPerson name, IDocumentForJuridicalPerson document)
    {
      Name = name;
      Document = document;

      Validate();
    }

    /// <summary>
    /// Instancia uma pessoa física e documento
    /// </summary>
    /// <param name="name"></param>
    /// <param name="document"></param>
    public Person(INameForPhisicalPerson name, IDocumentForPhysicalPerson document)
    {
      Name = name;
      Document = document;

      Validate();
    }

    /// <summary>
    /// Instancia uma pessoa no com base no nome, documento e endereço
    /// </summary>
    /// <param name="name"></param>
    /// <param name="document"></param>
    /// <param name="address"></param>
    public Person(IName name, IDocument document, IAddress address)
    {
      Name = name;
      Address = address;
      Document = document;

      Validate();
    }

    /// <summary>
    /// Instancia uma pessoa com base no nome, documento e data de nascimento
    /// </summary>
    /// <param name="name"></param>
    /// <param name="document"></param>
    /// <param name="birthDate"></param>
    public Person(IName name, IDocument document, DateTime birthDate)
    {
      Name = name;
      Document = document;
      BirthDate = birthDate;

      Validate();
    }

    public void Validate()
    {

    }
  }
}
