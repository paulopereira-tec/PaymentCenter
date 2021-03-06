using PaymentCenter.Domain.Interfaces;
using PaymentCenter.Infra.Shared.ValuesObject.Interfaces;
using System;

namespace PaymentCenter.Infra.Shared.Abstractions
{
  public abstract class PaymentWithCreditCard
  {
    private IPerson _payer { get; set; }
    private IPerson _receiver { get; set; }
    private IAddress _payerAddress { get; set; }
    private DateTime _birthDate { get; set; }
    private IDocument _document { get; set; }

    public void Payer(IPerson payer)
    {
      _payer = payer;
    }

    public void Receiver(IPerson receiver)
    {
      _receiver = receiver;
    }

    public void PayerAddress(IAddress address)
    {
      _payerAddress = address;
    }

    public void BirthDate(DateTime date) 
    {
      _birthDate = date;
    }

    public void Document(IDocument document)
    {
      _document = document;
    }

  }
}
