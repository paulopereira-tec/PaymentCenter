using PaymentCenter.Infra.Shared.ValuesObject.Interfaces;

namespace PaymentCenter.Infra.Shared.ValuesObject
{
  public class DocumentForJuridicalPerson : Document, IDocumentForJuridicalPerson
  {
    public string CNPJ { get; }

    /// <summary>
    /// Instancia o CNPJ de uma empresa
    /// </summary>
    /// <param name="cnpj"></param>
    public DocumentForJuridicalPerson(string cnpj): base(cnpj)
    {
      CNPJ = cnpj;

      Validate();
    }

    public void Validate() {
    
    }
  }
}
