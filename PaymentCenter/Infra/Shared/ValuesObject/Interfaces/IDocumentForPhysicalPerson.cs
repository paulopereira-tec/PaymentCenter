namespace PaymentCenter.Infra.Shared.ValuesObject.Interfaces
{
  public interface IDocumentForPhysicalPerson: IDocument
  {
    string CPF { get; }
  }
}
