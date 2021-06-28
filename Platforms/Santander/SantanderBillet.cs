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
    public static string JsonData { get; private set; }

    public static string XmlData { get; private set; }

    /// <summary>
    /// Instancia da classe contendo o certificado digital (e-CPF ou e-CNPJ)
    /// </summary>
    private static Certificate _certificate;

    /// <summary>
    /// Adiciona um certificado digital (e-CPF ou e-CNPJ) a ser utilizado.
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
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://ymbdlb.santander.com.br/dl-ticket-services/TicketEndpointService");
      request.ClientCertificates.Add(_certificate.x509);
      byte[] bytes;
      bytes = System.Text.Encoding.ASCII.GetBytes(XmlData);
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
        return responseStr;
      }
      return null;
    }
  
  /// <summary>
  /// Inicia a preparação dos dados para geração do boleto bancário.
  /// </summary>
  /// <param name="bank"></param>
  /// <returns></returns>
  public static Santander Prepare(this Santander bank) {

      #region Recupera o endereço de cobrança
      IAddress address = bank.Payer.Addresses.Where(x => x.Type == EAddressType.Charge).FirstOrDefault();
      #endregion

      #region Inicia a preparação dos dados para XML
      Dictionary<string, string> tickets = new Dictionary<string, string>();

      tickets.Add("CONVENIO.COD-BANCO", "");
      tickets.Add("CONVENIO.COD-CONVENIO", "");

      tickets.Add("PAGADOR.TP-DOC", (bank.Payer.Personality == EPersonalitty.PF? "CPF": "CNPJ"));
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
      XmlData = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:impl=\"http://impl.webservice.dl.app.bsbr.altec.com/\">";
      XmlData += "<soapenv:Header/>";
      XmlData += "<soapenv:Body>";
      XmlData += "<impl:create>";
      XmlData += "<TicketRequest>";

      XmlData += "<dados>";
      foreach(var ticket in tickets)
      {
        XmlData += "<key>" + ticket.Key + "</key>";
        XmlData += "<value>" + ticket.Value + "</value>";
      }
      XmlData += "</dados>";

      XmlData += "<expiracao>100</expiracao>";
      XmlData += "<sistema>YMB</sistema>";
      XmlData += "</TicketRequest>";
      XmlData += "</impl:create>";
      XmlData += "</soapenv:Body>";
      XmlData += "</soapenv:Envelope>";
      #endregion

      return bank;
    }

  }
}
