using PaymentCenter.Core.Enums;
using PaymentCenter.Core.ValuesObject.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using x509;

namespace PaymentCenter.Platforms.Santander
{
  public static class SantanderBillet
  {
    #region Propriedades privadas
    /// <summary>
    /// Determina se a atividade atual é de geração ou consulta de boletos.
    /// </summary>
    private static EGenerateOrConsult YouLikeGenerateOrConsultBillet { get; set; }

    /// <summary>
    /// URL indicada pelo banco para gerar o ticket de autenticação
    /// </summary>
    private static string _dlbTicketURL = "https://ymbdlb.santander.com.br/dl-ticket-services/TicketEndpointService";

    /// <summary>
    /// URL indicada pelo banco para gerar ou consultar boleto.
    /// </summary>
    private static string _ymbCobrancaURL = "https://ymbcash.santander.com.br/ymbsrv/CobrancaV3EndpointService";

    /// <summary>
    /// Instancia da classe contendo o certificado digital (e-CPF ou e-CNPJ)
    /// </summary>
    private static Certificate _certificate;
    #endregion

    #region Propriedades públicas
    /// <summary>
    /// Retorna o conteúdo obtido pelo banco convertido de XML para o formato JSON
    /// </summary>
    public static string JsonData { get; private set; }

    /// <summary>
    /// Retorna o conteúdo obtido no banco no formato XML.
    /// </summary>
    public static string XmlData { get; private set; }

    /// <summary>
    /// Ticket de autenticação gerado para consultar ou gerar boletos.
    /// </summary>
    public static string XmlTicket { get; set; }

    /// <summary>
    /// XML criado para receber o ticket gerado pelo banco
    /// </summary>
    public static string XmlCallTicket { get; set; }
    #endregion

    #region Métodos privados
    /// <summary>
    /// Recupera o ticket de segurança para gerar ou consultar boletos
    /// </summary>
    /// <returns></returns>
    private static string receiveTicket()
    {
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_ymbCobrancaURL);
      request.ClientCertificates.Add(_certificate.x509);
      byte[] bytes;
      bytes = System.Text.Encoding.ASCII.GetBytes(XmlCallTicket);
      request.ContentType = "text/xml; encoding='utf-8'";
      request.ContentLength = bytes.Length;
      request.Method = "POST";
      Stream requestStream = request.GetRequestStream();
      requestStream.Write(bytes, 0, bytes.Length);
      requestStream.Close();
      HttpWebResponse response;
      response = (HttpWebResponse)request.GetResponse();
      if (response.StatusCode == HttpStatusCode.OK)
      {
        Stream responseStream = response.GetResponseStream();
        string responseStr = new StreamReader(responseStream).ReadToEnd();
        XmlCallTicket = responseStr;
        return responseStr;
      }
      return null;
    }

    /// <summary>
    /// Executa o serviço para consulta ou geração de boletos
    /// </summary>
    /// <returns></returns>
    private static string runServiceToBilletGenerate()
    {
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_dlbTicketURL);
      request.ClientCertificates.Add(_certificate.x509);
      byte[] bytes;
      bytes = System.Text.Encoding.ASCII.GetBytes(XmlTicket);
      request.ContentType = "text/xml; encoding='utf-8'";
      request.ContentLength = bytes.Length;
      request.Method = "POST";
      Stream requestStream = request.GetRequestStream();
      requestStream.Write(bytes, 0, bytes.Length);
      requestStream.Close();
      HttpWebResponse response;
      response = (HttpWebResponse)request.GetResponse();
      if (response.StatusCode == HttpStatusCode.OK)
      {
        Stream responseStream = response.GetResponseStream();
        string responseStr = new StreamReader(responseStream).ReadToEnd();
        XmlCallTicket = responseStr;
        return responseStr;
      }
      return null;
    }
    #endregion

    #region Métodos públicos
    /// <summary>
    /// Adiciona um certificado digital x509 conforme características indicadas pelo banco a ser utilizado.
    /// </summary>
    /// <param name="bank"></param>
    /// <param name="path"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public static Santander AddCertificate(this Santander bank, string path, string password)
    {
      _certificate = new Certificate(path, password);
      return bank;
    }

    /// <summary>
    /// Inicia a execução da tarefa, seja ela geração ou consulta do boleto.
    /// </summary>
    /// <param name="santander"></param>
    public static string Execute(this Santander bank)
    {
      if (receiveTicket() is null) return null;

      return runServiceToBilletGenerate();
    }

    /// <summary>
    /// Inicia a preparação dos dados para geração do boleto bancário.
    /// </summary>
    /// <param name="bank"></param>
    /// <returns></returns>
    public static Santander PrepareBillet(this Santander bank)
    {
      YouLikeGenerateOrConsultBillet = EGenerateOrConsult.Generate;

      #region Recupera o endereço de cobrança
      IAddress address = bank.Payer.Addresses.Where(x => x.Type == EAddressType.Charge).FirstOrDefault();
      #endregion

      #region Inicia a preparação dos dados para XML
      Dictionary<string, string> tickets = new Dictionary<string, string>();

      tickets.Add("CONVENIO.COD-BANCO", "");
      tickets.Add("CONVENIO.COD-CONVENIO", "");

      tickets.Add("PAGADOR.TP-DOC", (bank.Payer.Personality == EPersonalitty.PF ? "CPF" : "CNPJ"));
      tickets.Add("PAGADOR.NUM-DOC", bank.Payer.Document.DocumentSubscription);
      tickets.Add("PAGADOR.NOME", bank.Payer.Name.FullName);

      tickets.Add("PAGADOR.ENDER", address.Street);
      tickets.Add("PAGADOR.BAIRRO", address.Neigborhood);
      tickets.Add("PAGADOR.CIDADE", address.City);
      tickets.Add("PAGADOR.UF", address.State);
      tickets.Add("PAGADOR.CEP", address.Zipcode);

      tickets.Add("TITULO.NOSSO-NUMERO", bank.PaymentData.NumberOfPayment.ToString());
      tickets.Add("TITULO.SEU-NUMERO", "");
      tickets.Add("TITULO.DT-VENCTO", bank.PaymentData.DueDate.ToString());
      tickets.Add("TITULO.DT-EMISSAO", bank.PaymentData.CreateDate.ToString());
      tickets.Add("TITULO.ESPECIE", "");
      tickets.Add("TITULO.VL-NOMINAL", bank.PaymentData.Value.ToString());
      tickets.Add("TITULO.PC-MULTA", "");
      tickets.Add("TITULO.QT-DIAS-MULTA", "");
      tickets.Add("TITULO.PC-JURO", "");
      tickets.Add("TITULO.TP-DESC", "");
      tickets.Add("TITULO.VL-DESC", "");
      tickets.Add("TITULO.DT-LIMI-DESC", "");
      tickets.Add("TITULO.VL-DESC2", "");
      tickets.Add("TITULO.DT-LIMI-DESC2", "");
      tickets.Add("TITULO.VL-DESC3", "");
      tickets.Add("TITULO.DT-LIMI-DESC3", "");
      tickets.Add("TITULO.VL-ABATIMENTO", "");
      tickets.Add("TITULO.TP-PROTESTO", "");
      tickets.Add("TITULO.QT-DIAS-PROTESTO", "");
      tickets.Add("TITULO.QT-DIAS-BAIXA", "");
      tickets.Add("TITULO.TP-PAGAMENTO", "");
      tickets.Add("TITULO.QT-PARCIAIS", "");
      tickets.Add("TITULO.TP-VALOR", "");
      tickets.Add("TITULO.VL-PERC-MINIMO", "");
      tickets.Add("TITULO.VL-PERC-MAXIMO", "");
      tickets.Add("TITULO.TP-DOC-AVALISTA", "");
      tickets.Add("TITULO.NOME-AVALISTA", "");
      tickets.Add("TITULO.COD-PARTILHA1", "");
      tickets.Add("TITULO.VL-PARTILHA1", "");
      tickets.Add("TITULO.COD-PARTILHA2", "");
      tickets.Add("TITULO.VL-PARTILHA2", "");
      tickets.Add("TITULO.COD-PARTILHA3", "");
      tickets.Add("TITULO.VL-PARTILHA3", "");
      tickets.Add("TITULO.COD-PARTILHA4", "");
      tickets.Add("TITULO.VL-PARTILHA4", "");
      tickets.Add("MENSAGEM", "");
      #endregion

      #region Prepara o XML para recuperar ticket
      XmlCallTicket = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:impl=\"http://impl.webservice.dl.app.bsbr.altec.com/\">";
      XmlCallTicket += "<soapenv:Header/>";
      XmlCallTicket += "<soapenv:Body>";
      XmlCallTicket += "<impl:create>";
      XmlCallTicket += "<TicketRequest>";

      XmlCallTicket += "<dados>";
      foreach (var ticket in tickets)
      {
        XmlCallTicket += "<key>" + ticket.Key + "</key>";
        XmlCallTicket += "<value>" + ticket.Value + "</value>";
      }
      XmlCallTicket += "</dados>";

      XmlCallTicket += "<expiracao>100</expiracao>";
      XmlCallTicket += "<sistema>YMB</sistema>";
      XmlCallTicket += "</TicketRequest>";
      XmlCallTicket += "</impl:create>";
      XmlCallTicket += "</soapenv:Body>";
      XmlCallTicket += "</soapenv:Envelope>";
      #endregion

      return bank;
    }

    /// <summary>
    /// Executa a consulta de boletos gerados
    /// </summary>
    /// <param name="bank"></param>
    public static Santander PrepareConsult(this Santander bank)
    {
      YouLikeGenerateOrConsultBillet = EGenerateOrConsult.Consult;

      return bank;
    }
    #endregion
  }
}
