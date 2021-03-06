using PaymentCenter.Domain.Interfaces;
using PaymentCenter.Infra.Shared.Interfaces;
using PaymentCenter.Platforms.Pix.Interfaces;

namespace PaymentCenter.Platforms.Pix
{
  /// <summary>
  /// Cria mecanismo de pagamento baseado no Pix do Banco Central brasileiro.
  /// <![CDATA[
  /// Com esta classe, é possível:
  /// - gerar código QR único e personalizado para pagamento
  /// - gerar boleto para impressão
  /// - gerar código para pagamento
  /// ]]>
  /// </summary>
  public class Pix: IPrintablePayment, IPlatform
  {
    /// <summary>
    /// Chave Pix daquele que irá receber o pagamento.
    /// </summary>
    public IPixKey Key { get; }

    /// <summary>
    /// Instancia um objeto da plataforma Pix de pagamento
    /// </summary>
    /// <param name="key"></param>
    public Pix(IPixKey key)
    {
      Key = key;
    }

    /// <summary>
    /// Prepara o objeto Pix para pagamento
    /// </summary>
    /// <param name="payer"></param>
    /// <param name="receiver"></param>
    public void ConfigureHolders(IPerson payer, IPerson receiver)
    {
      this._receiver = receiver;
      this._payer = payer;
    }

    /// <summary>
    /// Executa o pagamento
    /// </summary>
    /// <param name="paymentData"></param>
    public void Execute(IPaymentData paymentData)
    {
      this._paymentData = paymentData;
    }

    /// <summary>
    /// Imprime um documento no estilo de boleto com código QR.
    /// </summary>
    public void Print()
    {
    }

    /// <summary>
    /// Retorna o código pix para pagamento.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return "CHAVE PIX";
    }
  }
}
