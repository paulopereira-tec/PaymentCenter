using PaymentCenter.Infra.Shared.ValuesObject.Interfaces;

namespace PaymentCenter.Infra.Shared.ValuesObject
{
  public abstract class Document : IDocument
  {
    public string ValidDocument { get; }

    public Document(string validDocument)
    {
      ValidDocument = validDocument;
    }
  }
}
