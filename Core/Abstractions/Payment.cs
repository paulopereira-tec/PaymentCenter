using PaymentCenter.Core.Interfaces;

namespace PaymentCenter.Core.Abstractions
{
  public abstract class Payment
  {
    public IPlatform Platform { get; set; }

    protected IWebClient _webClient { get; set; }

    public Payment(IWebClient webClient, IPlatform platform)
    {
      _webClient = webClient;
      Platform = platform;
    }
  }
}
