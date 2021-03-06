using PaymentCenter.Infra.Shared.ValuesObject.Interfaces;

namespace PaymentCenter.Infra.Shared.ValuesObject
{
  public class DocumentForPhysicalPerson: Document, IDocumentForPhysicalPerson
  {
    public string CPF { get; }

    /// <summary>
    /// Instancia a criação do CPF de uma pessoa.
    /// </summary>
    /// <param name="cpf"></param>
    public DocumentForPhysicalPerson(string cpf): base(cpf)
    {
      CPF = cpf;

      Validate();
    }

    public void Validate()
    {

    }
  }
}
