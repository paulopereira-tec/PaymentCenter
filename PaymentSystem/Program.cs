using PaymentCenter;
using PaymentCenter.Domain.Entities;
using PaymentCenter.Domain.Interfaces;
using PaymentCenter.Infra.Shared.Interfaces;
using PaymentCenter.Infra.Shared.ValuesObject;
using PaymentCenter.Platforms.Itau;
using PaymentCenter.Platforms.Pix;
using System;

namespace PaymentSystem
{
  class Program
  {
    static void Main(string[] args)
    {
      IPerson payer = new Person(
        new NameForPhisicalPerson("Paulo", "Pereira"),
        new DocumentForPhysicalPerson("22569866325")
      );

      IPerson receiver = new Person(
        new NameForJuridicalPerson("Conta de luz S.A"),
        new DocumentForJuridicalPerson("56852974000158")
      );

      DateTime dateDue = new DateTime(2021, 02, 25);
      PaymentData paymentData = new PaymentData(450.00F, dateDue);

      Pix pix = new Pix(new PixKey("123456"));

      IBankBillet billet = new ItauBillet(new Itau(133,133,331));

      Payment payment = new Payment(payer, receiver, paymentData, billet).Execute();
    }
  }
}
