using PaymentCenter.Infra.Shared.ValuesObject.Interfaces;
using PaymentCenter.Platforms.Pix.Interfaces;

namespace PaymentCenter.Platforms.Pix
{
  public class PixKey: IPixKey
  {
    public string Key { get; set; }

    /// <summary>
    /// Implementa uma chave aleatória para ser usada no pagamento.
    /// </summary>
    /// <param name="aleatoryKey"></param>
    public PixKey(string aleatoryKey)
    {
      Key = aleatoryKey;
    }

    /// <summary>
    /// Implementa o CPF do beneficiário como chave para ser usada no pagamento.
    /// </summary>
    /// <param name="document"></param>
    public PixKey(IDocumentForPhysicalPerson document) {
      Key = document.CPF;
    }

    /// <summary>
    /// Implementa o CNPJ do beneficiário como chave para ser usada no pagamento.
    /// </summary>
    /// <param name="document"></param>
    public PixKey(IDocumentForJuridicalPerson document)
    {
      Key = document.CNPJ;
    }
  }
}
