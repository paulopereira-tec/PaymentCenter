namespace PaymentCenter.Core.Interfaces
{
  public interface IWebClient
  {
    string Get(string route);
    string Get(string route, int id);
    string Post(string route, object param);
    string Put(string route, int id, object param);
    string Delete(string route, int id);
  }
}
