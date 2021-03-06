using System;

namespace PaymentCenter.Domain.Interfaces
{
  /// <summary>
  /// Implementa os dados que devem ser usados no pagamento
  /// </summary>
  public interface IPaymentData
  {
    float Value { get; }
    DateTime DueDate { get; }
    DateTime CreateDate { get; }
  }
}
