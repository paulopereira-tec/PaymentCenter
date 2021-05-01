using PaymentCenter.Core.ValuesObject.Interfaces;
using System.Text.RegularExpressions;

namespace PaymentCenter.Core.ValuesObject
{
  public abstract class Document : IDocument
  {
    public string DocumentSubscription { get; set; }

    public Document(string document)
    {
      DocumentSubscription = document;
    }

    /// <summary>
    /// Devolve o documento sem pontos, traços ou barras.
    /// </summary>
    /// <returns>Retorna o número do documento em formato puro, sem barras, pontos ou traços.</returns>
    public string PureDocument()
    {
      return Regex.Replace(DocumentSubscription, @"/|\.|-", "");
    }
  }
}
