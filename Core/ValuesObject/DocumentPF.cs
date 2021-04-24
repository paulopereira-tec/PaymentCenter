using Flunt.Validations;
using PaymentCenter.Core.ValuesObject.Interfaces;

namespace PaymentCenter.Core.ValuesObject
{
  public class DocumentPF : IDocument, IValidatable
  {
    public string DocumentSubscription { get; set; }

    public DocumentPF(string document) {
      DocumentSubscription = document;

      Validate();
    }

    public void Validate()
    {
    }
  }
}
