using PaymentCenter.Core.Enums;
using PaymentCenter.Core.ValuesObject.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using x509;

namespace PaymentCenter.Platforms.Bradesco
{
  public static class BradescoBillet
  {
    private static string JsonData { get; set; }
    private static string EncryptedData { get; set; }

    public static string GetJsonData(this Bradesco bradesco)
    {
      return JsonData;
    }

    public static string GetEncryptedData(this Bradesco bradesco)
    {
      return EncryptedData;
    }


    /// <summary>
    /// Prepara o JSON a ser enviado para o banco. Já criptografa os dados no padrão PKCS#7 assinado com cetificado digital (e-CPF ou e-CNPJ)
    /// </summary>
    /// <param name="operationType">É o mesmo que "idProduto".</param>
    /// <param name="specieTitleCode"></param>
    /// <param name="IOF">Valor de imposto a ser pago.</param>
    /// <returns></returns>
    public static Bradesco Prepare(this Bradesco bradesco, string operationType, string specieTitleCode, string IOF)
    {
      #region Variáveis a serem utilizadas na implementação
      string cdEspecieTitulo, vlIOF, vlNominalTitulo, cdIndCpfcnpjPagador, nuCpfcnpjPagador, cepPagador, complementoCepPagador, idProduto, nuNegociacao, filialCPFCNPJ, ctrlCPFCNPJ, nuCliente,
          nuCPFCNPJ, dtEmissaoTitulo, dtVencimentoTitulo, endEletronicoPagador, nomePagador, logradouroPagador, nuLogradouroPagador, complementoLogradouroPagador, bairroPagador, municipioPagador, ufPagador;
      #endregion

      #region Implementação dos dados necessários para geração do boleto
      cdEspecieTitulo = BradescoTableSpecieTitle.GetByCode(specieTitleCode).Code;
      idProduto = operationType;
      string fillAccountNumber = "";
      for (int i = 0; i < (7 - bradesco.AccountData.AccountNumber.ToString().Length); i++) fillAccountNumber += "0";
      nuNegociacao = bradesco.AccountData.Agency.ToString() + "0000000" + fillAccountNumber + bradesco.AccountData.AccountNumber.ToString();
      vlIOF = IOF;

      dtEmissaoTitulo = bradesco.PaymentData.CreateDate.ToString("dd.MM.yyyy");
      dtVencimentoTitulo = bradesco.PaymentData.DueDate.ToString("dd.MM.yyyy");

      // Se o valor informado não tiver mais de 17, completa à direita com zeros
      string fillValue = "";
      string value = Regex.Replace(bradesco.PaymentData.Value.ToString(), @"\.|,", "");
      for (int i = 0; i < (17 - value.Length); i++) fillValue += "0";
      vlNominalTitulo = "" + value;

      string cpfOrCnpj = bradesco.Receiver.Document.PureDocument();
      nuCPFCNPJ = cpfOrCnpj.Substring(0, 8);
      ctrlCPFCNPJ = cpfOrCnpj.Substring(12, 2);
      filialCPFCNPJ = cpfOrCnpj.Length > 11 ? cpfOrCnpj.Substring(8, 4) : "0";

      nuCliente = bradesco.PaymentData.NumberOfPayment.ToString();

      // nome do pagador
      nomePagador = bradesco.Payer.Name.FullName;
      cdIndCpfcnpjPagador = bradesco.Payer.Personality == EPersonalitty.PF ? "1" : "2";
      nuCpfcnpjPagador = (bradesco.Payer.Personality == EPersonalitty.PF ? "000" : "") + bradesco.Payer.Document.PureDocument();
      endEletronicoPagador = bradesco.Payer.Email;

      // endereço
      IAddress address = bradesco.Payer.Addresses.Where(x => x.Type == EAddressType.Charge).FirstOrDefault();
      logradouroPagador = address.Street;
      nuLogradouroPagador = address.Number;
      complementoLogradouroPagador = address.Complement;
      bairroPagador = address.Neigborhood;
      municipioPagador = address.City;
      ufPagador = address.State;
      
      cepPagador = address.PureZipcode().Substring(0,5);
      complementoCepPagador = address.PureZipcode().Substring(5,3);
      #endregion

      billetData = new BradescoBilletObject(
        nuCPFCNPJ, filialCPFCNPJ, ctrlCPFCNPJ, idProduto, nuNegociacao, dtEmissaoTitulo, dtVencimentoTitulo, vlNominalTitulo,
        cdEspecieTitulo, vlIOF, nomePagador, logradouroPagador, nuLogradouroPagador, complementoLogradouroPagador, cepPagador,
        complementoCepPagador, bairroPagador, municipioPagador, ufPagador, cdIndCpfcnpjPagador, nuCpfcnpjPagador,
        endEletronicoPagador, nuCliente);

      JsonData = System.Text.Json.JsonSerializer.Serialize(billetData);

      return bradesco;
    }

    /// <summary>
    /// Contém os dados do boleto a ser gerado.
    /// </summary>
    private static BradescoBilletObject billetData { get; set; }

    /// <summary>
    /// Executa as atividades de geração de boleto.
    /// </summary>
    /// <param name="bradesco"></param>
    /// <returns></returns>
    public static string Execute(this Bradesco bradesco)
    {
      Pkcs pkcs = new Pkcs(_certificate.x509);
      string jsonContent = pkcs.Signer(JsonData);
      EncryptedData = jsonContent;

      string returnData;

      //return bradesco;
      var encoding = new UTF8Encoding();

      //TLS 1.2
      ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

      var request = WebRequest.Create(_endpoint);

      request.Method = "POST";
      request.ContentType = "application/pkcs7-signature";
      request.ContentLength = encoding.GetBytes(jsonContent).Length;

      using (var requestStream = request.GetRequestStream())
      {
        requestStream.Write(encoding.GetBytes(jsonContent), 0, encoding.GetBytes(jsonContent).Length);
      }
      var response = request.GetResponse();

      using (var stream = response.GetResponseStream())
      {
        if (stream == null)
          throw new ApplicationException("erro ao obter resposta");

        var reader = new StreamReader(stream);

        // resultado FINAL aqui
        returnData = reader.ReadToEnd();
      }

      return returnData;
    }

    /// <summary>
    /// Instancia da classe contendo o certificado digital (e-CPF ou e-CNPJ)
    /// </summary>
    private static Certificate _certificate;

    /// <summary>
    /// Adiciona um certificado digital (e-CPF ou e-CNPJ) a ser utilizado.
    /// </summary>
    /// <param name="bradesco"></param>
    /// <param name="path"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public static Bradesco AddCertificate(this Bradesco bradesco, string path, string password)
    {
      _certificate = new Certificate(path, password);

      return bradesco;
    }

    private static string _endpoint { get; set; } = "https://cobranca.bradesconetempresa.b.br/ibpjregistrotitulows/registrotitulohomologacao";

    /// <summary>
    /// Informa uma string com a URL do ambente a ser utilizado caso haja mudanças pelo banco.
    /// </summary>
    /// <param name="bradesco"></param>
    /// <param name="url"></param>
    /// <returns></returns>
    public static Bradesco SetEndpoint(this Bradesco bradesco, string url)
    {
      _endpoint = url;
      return bradesco;
    }

    /// <summary>
    /// Seta o ambiente de trabalho: homologação (desenvolvimento), teste ou produção. Por padrão, utiliza o ambiente de desenvolvimento.
    /// </summary>
    /// <param name="bradesco"></param>
    /// <param name="environment"></param>
    /// <returns></returns>
    public static Bradesco SetEndpoint(this Bradesco bradesco, EEnvironment environment = EEnvironment.Development)
    {
      if (environment == EEnvironment.Development || environment == EEnvironment.Development)
      {
        SetEndpoint(bradesco, "https://cobranca.bradesconetempresa.b.br/ibpjregistrotitulows/registrotitulohomologacao");
      }
      else
      {
        SetEndpoint(bradesco, "https://cobranca.bradesconetempresa.b.br/ibpjregistrotitulows/registrotitulo");
      }
      return bradesco;
    }
  }
}
