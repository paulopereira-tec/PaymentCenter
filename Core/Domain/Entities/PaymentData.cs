using PaymentCenter.Core.Domain.Interface;
using System;

namespace PaymentCenter.Core.Domain.Entities
{
  public class PaymentData: IPaymentData
  {
    public string Description { get; set; }
    public decimal Value { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime DueDate { get; set; }
    public int NumberOfPayment { get; set; }

    public PaymentData(string description, decimal value, DateTime createDate, DateTime dueDate)
    {
      Description = description;
      Value = value;
      CreateDate = createDate;
      DueDate = dueDate;
    }

    public PaymentData(string description, decimal value, DateTime createDate, DateTime dueDate, int numberOfPayment)
    {
      Description = description;
      Value = value;
      NumberOfPayment = numberOfPayment;
      CreateDate = createDate;
      DueDate = dueDate;
    }
  }
}
