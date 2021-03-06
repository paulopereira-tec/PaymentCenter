namespace PaymentCenter.Infra.Shared.ValuesObject.Interfaces
{
  public interface IDocumentForJuridicalPerson: IDocument
  {
    string CNPJ { get; }
  }
}
