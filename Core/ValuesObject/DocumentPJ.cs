using Flunt.Validations;
using PaymentCenter.Core.ValuesObject.Interfaces;

namespace PaymentCenter.Core.ValuesObject
{
  public class DocumentPJ : IDocument
  {
    public string DocumentSubscription { get; set; }

    public DocumentPJ(string document) {
      DocumentSubscription = document;

      Validate();
    }

    public void Validate()
    {
    }
  }
}
