using PaymentCenter.Core.ValuesObject.Interfaces;

namespace PaymentCenter.Core.ValuesObject
{
  public sealed class DocumentPJ : Document, IDocument
  {
    public string DocumentSubscription { get; set; }

    public DocumentPJ(string document): base(document) {
      Validate();
    }

    public void Validate()
    {
    }
  }
}
