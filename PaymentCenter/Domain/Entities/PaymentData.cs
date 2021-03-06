using PaymentCenter.Domain.Interfaces;
using PaymentCenter.Infra.Shared.Interfaces;
using System;

namespace PaymentCenter.Domain.Entities
{
  /// <summary>
  /// Abstrai os dados para pagamento.
  /// </summary>
  public class PaymentData : IPaymentData, IValidatable
  {
    /// <summary>
    /// Valor a ser pago
    /// </summary>
    public float Value { get; }

    /// <summary>
    /// Data do vencimento
    /// </summary>
    public DateTime DueDate { get; }

    /// <summary>
    /// Data de criação
    /// </summary>
    public DateTime CreateDate { get; }

    public void Validate() { }

    /// <summary>
    /// Instancia os dados do pagamento com valor e data de vencimento.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="dueDate"></param>
    public PaymentData(float value, DateTime dueDate)
    {
      Value = value;
      DueDate = dueDate;
      CreateDate = DateTime.Now;

      Validate();
    }

    /// <summary>
    /// Instancia um pagamento com valor, data de vencimento e de criação
    /// </summary>
    /// <param name="value"></param>
    /// <param name="dueDate"></param>
    /// <param name="createDate"></param>
    public PaymentData(float value, DateTime dueDate, DateTime createDate)
    {
      Value = value;
      DueDate = dueDate;
      CreateDate = createDate;

      Validate();
    }
  }
}
