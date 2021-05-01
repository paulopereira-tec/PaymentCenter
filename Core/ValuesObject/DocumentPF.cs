using PaymentCenter.Core.ValuesObject.Interfaces;

namespace PaymentCenter.Core.ValuesObject
{
  public sealed class DocumentPF : Document, IDocument
  {
    public string DocumentSubscription { get; set; }

    public DocumentPF(string document): base(document) {
      Validate();
    }

    public void Validate()
    {
    }
  }
}
