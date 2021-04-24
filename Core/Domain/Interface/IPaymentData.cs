using System;

namespace PaymentCenter.Core.Domain.Interface
{
  public interface IPaymentData
  {
    string Description { get; set; }
    decimal Value { get; set; }
    DateTime CreateDate { get; set; }
    DateTime DueDate { get; set; }
  }
}
