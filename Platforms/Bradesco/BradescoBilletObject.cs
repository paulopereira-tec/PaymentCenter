using System;

namespace PaymentCenter.Platforms.Bradesco
{
  /// <summary>
  /// Objeto a ser convertido para JSON antes de ser enviado ao endpostring do banco. A descrição das propriedades
  /// e suas respectivas validações obedecem as especificações do "Manual Técnico e Layout de Registro On-line de
  /// Boletos de Cobrança Bradesco" - Nº 4""""8.524.""883 Versão ""3. Revisado em ""5/""6/2""2"".
  /// </summary>
  class BradescoBilletObject
  {
    /// <summary>
    /// Obrigatório. Raiz CPF/CNPJ Beneficiário. Máximo 9 caracteres.
    /// </summary>
    public string nuCPFCNPJ { get; private set; }

    /// <summary>
    /// Obrigatório. Filial CPF/CNPJ Beneficiário Se CPF, filial = "". Máximo 4 caracteres.
    /// </summary>
    public string FilialCPFCNPJ { get; private set; } = "";

    /// <summary>
    /// Obrigatório. Dígito de Controle CPF/CNPJ Beneficiário. Máximo 2 caracteres.
    /// </summary>
    public string CtrlCPFCNPJ { get; private set; }

    /// <summary>
    /// Tipo de Acesso Fixo “2” – Negociação
    /// </summary>
    public string CdTipoAcesso { get; private set; } = "2";

    /// <summary>
    /// Club Banco – 237 (Bradesco) Fixo “2269651"
    /// </summary>
    public string ClubBanco { get; private set; } = "2269651";

    /// <summary>
    /// Tipo de Contrato – Fixo “48
    /// </summary>
    public string CdTipoContrato { get; private set; } = "48";

    /// <summary>
    /// Número de Sequência do Contrato
    /// </summary>
    public string NuSequenciaContrato { get; private set; } = "0";

    /// <summary>
    /// Obrigatório. Carteira de cobrança utilizada. ID Produto (código da carteira/ modalidade de cobrança). Exemplos:
    /// - ""9 = Cobrança escritural,
    /// - ""5 = Cobrança de Seguros
    /// </summary>
    public string IdProduto { get; private set; } = "09";

    /// <summary>
    /// Obrigatório. Número da Negociação ser utilizada. Número da Negociação Formato:
    /// Agencia: 4 posições (Sem digito) Zeros: 7 posições
    /// Conta: 7 posições (Sem digito)
    /// </summary>
    public string NuNegociacao { get; private set; }

    /// <summary>
    /// Obrigatório. Código do Banco
    /// </summary>
    public string CdBanco { get; private set; } = "237";

    /// <summary>
    /// Obrigatório. Tipo de Registro do Boleto
    /// </summary>
    public string TpRegistro { get; private set; } = "1";

    /// <summary>
    /// Código do Produto
    /// </summary>
    public string CdProduto { get; private set; } = "0";

    /// <summary>
    /// Identificação do título para o banco, pode ser informado pelo cliente ou gerado pelo banco,
    /// esse número deve ser único d acordo com a carteira e negociação utilizadas
    /// </summary>
    public string NuTitulo { get; private set; } = "0";

    /// <summary>
    /// Identificação do título para o cliente
    /// </summary>
    public string NuCliente { get; private set; } = "";

    /// <summary>
    /// Data de emissão do Título
    /// </summary>
    public string DtEmissaoTitulo { get; private set; } = "";

    /// <summary>
    /// Data de Vencimento do Título, não pode ser menor que a data de emissão do Título
    /// </summary>
    public string DtVencimentoTitulo { get; private set; } = "";

    /// <summary>
    /// Tipo de Vencimento – Fixo “""”
    /// </summary>
    public string TpVencimento { get; private set; } = "0";

    /// <summary>
    /// Valor nominal do Título
    /// </summary>
    public string VlNominalTitulo { get; private set; } = "";

    /// <summary>
    /// Código da Espécie do Título Códigos possíveis de acordo com item 9.1
    /// </summary>
    public string CdEspecieTitulo { get; private set; } = "0";

    /// <summary>
    /// Tipo de Protesto Automático ou Negativação:
    /// - ""1 – DIAS CORRIDOS PARA PROTESTO
    /// - ""2 - DIAS ÚTEIS PARA PROTESTO
    /// - ""3 – DIAS CORRIDOS PARA NEGATIVAÇÃO
    /// 
    /// Não disponível para o Registro Online
    /// </summary>
    public string TpProtestoAutomaticoNegativacao { get; private set; } = "0";

    /// <summary>
    /// Prazo para Protesto Automático ou Negativação.
    /// Para Protesto na condição de dias úteis: 3 dias após o vencimento.
    /// Dias corridos 5 dias após vencimento. Para Negativação considerar 5 dias corridos após o vencimento.
    /// </summary>
    public string PrazoProtestoAutomaticoNegativacao { get; private set; } = "0";

    /// <summary>
    /// Campo de responsabilidade do cliente, não consistido pelo banco. Não obrigatório.
    /// </summary>
    public string ControleParticipante { get; private set; } = "";

    /// <summary>
    /// Indicador de pagamento parcial, segundo regra da nova Plataforma de Cobrança.
    /// Campo não disponível para o registro online. Não obrigatório.
    /// </summary>
    public string CdPagamentoParcial { get; private set; } = "";

    /// <summary>
    /// Quantidade de Pagamentos Parciais Parcial– domínio ‘S’ ou ‘N’
    /// </summary>
    public string QtdePagamentoParcial { get; private set; } = "0";

    /// <summary>
    /// Percentual de Juros Formato do Campo: Conforme item 9.2 desse manual
    /// </summary>
    public string PercentualJuros { get; private set; } = "0";

    /// <summary>
    /// Valor de Juros Se o campo percentualjuros for preenchido, não deve ser preenchido esse campo
    /// </summary>
    public string VlJuros { get; private set; } = "0";

    /// <summary>
    /// Quantidade de dias para cálculo de multa.
    /// </summary>
    public string QtdeDiasJuros { get; private set; } = "0";

    /// <summary>
    /// Percentual do desconto 1. Formato do campo conforme item 9.2 do manual.
    /// </summary>
    public string PercentualMulta { get; private set; } = "0";

    /// <summary>
    /// Valor do desconto.
    /// </summary>
    public string VlMulta { get; private set; } = "0";


    public string QtdeDiasMulta { get; private set; } = "0";


    public string PercentualDesconto1 { get; private set; } = "0";


    public string VlDesconto1 { get; private set; } = "0";


    public string DataLimiteDesconto1 { get; private set; } = "";


    public string PercentualDesconto2 { get; private set; } = "0";


    public string VlDesconto2 { get; private set; } = "0";


    public string DataLimiteDesconto2 { get; private set; } = "";


    public string PercentualDesconto3 { get; private set; } = "0";


    public string VlDesconto3 { get; private set; } = "0";


    public string DataLimiteDesconto3 { get; private set; } = "";


    public string PrazoBonificacao { get; private set; } = "0";


    public string PercentualBonificacao { get; private set; } = "0";


    public string VlBonificacao { get; private set; } = "0";


    public string DtLimiteBonificacao { get; private set; } = "";


    public string VlAbatimento { get; private set; } = "0";


    public string VlIOF { get; private set; } = "0";


    public string NomePagador { get; private set; } = "";


    public string LogradouroPagador { get; private set; } = "";


    public string NuLogradouroPagador { get; private set; } = "";


    public string ComplementoLogradouroPagador { get; private set; } = "";


    public string CepPagador { get; private set; } = "";


    public string ComplementoCepPagador { get; private set; } = "";


    public string BairroPagador { get; private set; } = "";


    public string MunicipioPagador { get; private set; } = "";


    public string UfPagador { get; private set; } = "";

    /// <summary>
    /// Indica se o documento a ser passado será CPF (1) ou CNPJ (2)
    /// </summary>
    public string CdIndCpfcnpjPagador { get; private set; } = "1";


    public string NuCpfcnpjPagador { get; private set; } = "";


    public string EndEletronicoPagador { get; private set; } = "";


    public string NomeSacadorAvalista { get; private set; } = "";


    public string LogradouroSacadorAvalista { get; private set; } = "";


    public string NuLogradouroSacadorAvalista { get; private set; } = "0";


    public string ComplementoLogradouroSacadorAvalista { get; private set; } = "";


    public string CepSacadorAvalista { get; private set; } = "0";


    public string ComplementoCepSacadorAvalista { get; private set; } = "0";


    public string BairroSacadorAvalista { get; private set; } = "";


    public string MunicipioSacadorAvalista { get; private set; } = "";


    public string UfSacadorAvalista { get; private set; } = "";


    public string CdIndCpfcnpjSacadorAvalista { get; private set; } = "0";


    public string NuCpfcnpjSacadorAvalista { get; private set; } = "0";


    public string EndEletronicoSacadorAvalista { get; private set; } = "";

    public BradescoBilletObject(
      string _nuCPFCNPJ,
      string _filialCPFCNPJ,
      string _ctrlCPFCNPJ,
      string _idProduto,
      string _nuNegociacao,
      string _dtEmissaoTitulo,
      string _dtVencimentoTitulo,
      string _vlNominalTitulo,
      string _cdEspecieTitulo,
      string _vlIOF,
      string _nomePagador,
      string _logradouroPagador,
      string _nuLogradouroPagador,
      string _complementoLogradouroPagador,
      string _cepPagador,
      string _complementoCepPagador,
      string _bairroPagador,
      string _municipioPagador,
      string _ufPagador,
      string _cdIndCpfcnpjPagador,
      string _nuCpfcnpjPagador,
      string _endEletronicoPagador,
      string _nuCliente
        )
    {
      nuCPFCNPJ = _nuCPFCNPJ;
      FilialCPFCNPJ = _filialCPFCNPJ;
      CtrlCPFCNPJ = _ctrlCPFCNPJ;
      IdProduto = _idProduto;
      NuNegociacao = _nuNegociacao;
      DtEmissaoTitulo = _dtEmissaoTitulo;
      DtVencimentoTitulo = _dtVencimentoTitulo;
      VlNominalTitulo = _vlNominalTitulo;
      CdEspecieTitulo = _cdEspecieTitulo;
      VlIOF = _vlIOF;
      NomePagador = _nomePagador;
      LogradouroPagador = _logradouroPagador;
      NuLogradouroPagador = _nuLogradouroPagador;
      ComplementoLogradouroPagador = _complementoLogradouroPagador;
      CepPagador = _cepPagador;
      ComplementoCepPagador = _complementoCepPagador;
      BairroPagador = _bairroPagador;
      MunicipioPagador = _municipioPagador;
      UfPagador = _ufPagador;
      CdIndCpfcnpjPagador = _cdIndCpfcnpjPagador;
      NuCpfcnpjPagador = _nuCpfcnpjPagador;
      EndEletronicoPagador = _endEletronicoPagador;
      NuCliente = _nuCliente;
    }
  }
}
