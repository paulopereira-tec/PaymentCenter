using System.Collections.Generic;
using System.Linq;

namespace PaymentCenter.Platforms.Bradesco
{
  public static class BradescoTableSpecieTitle
  {
    /// <summary>
    /// Tabela de espécie de títulos conforme padrão especificado no anexo 9.1 do manual do Bradesco.
    /// </summary>
    public static List<SpecieTitle> SpecieTitles = new List<SpecieTitle>();

    /// <summary>
    /// Instancia uma tabela de código de espécie de títulos conforme anexo 9 do manual do Bradesco.
    /// </summary>
    private static void create()
    {
      // Limpa qualquer outra criação de tabela que tenha havido.
      SpecieTitles.Clear();

      #region Tabela de Código de Espécie de Títulos
      SpecieTitles.Add(new("01", "CH", "CHEQUE"));
      SpecieTitles.Add(new("02", "DM", "DUPLICATA DE VENDA MERCANTIL"));
      SpecieTitles.Add(new("03", "DMI", "DUPLICATA MERCANTIL POR INDICACAO"));
      SpecieTitles.Add(new("04", "DS", "DUPLICATA DE PRESTACAO DE SERVICOS"));
      SpecieTitles.Add(new("05", "DSI", "DUPLICATA PREST. SERVICOS POR INDICACAO"));
      SpecieTitles.Add(new("06", "DR", "DUPLICATA RURAL"));
      SpecieTitles.Add(new("07", "LC", "LETRA DE CAMBIO"));
      SpecieTitles.Add(new("08", "NCC", "OTA DE CREDITO COMERCIAL"));
      SpecieTitles.Add(new("09", "NCE", "NOTA DE CREDITO EXPORTACAO"));
      SpecieTitles.Add(new("10", "NCI", "NOTA DE CREDITO INDUSTRIAL"));
      SpecieTitles.Add(new("11", "NCR", "NOTA DE CREDITO RURAL"));
      SpecieTitles.Add(new("12", "NP", "NOTA PROMISSORIA"));
      SpecieTitles.Add(new("13", "NPR", "NOTA PROMISSORIA RURAL"));
      SpecieTitles.Add(new("14", "TM", "TRIPLICATA DE VENDA MERCANTIL"));
      SpecieTitles.Add(new("15", "TS", "TRIPLICATA DE PRESTACAO DE SERVICOS"));
      SpecieTitles.Add(new("16", "NS", "NOTA DE SERVICO"));
      SpecieTitles.Add(new("17", "RC", "RECIBO"));
      SpecieTitles.Add(new("18", "FAT", "FATURA"));
      SpecieTitles.Add(new("19", "ND", "NOTA DE DEBITO"));
      SpecieTitles.Add(new("20", "AP", "APOLICE DE SEGURO"));
      SpecieTitles.Add(new("21", "ME", "MENSALIDADE ESCOLAR"));
      SpecieTitles.Add(new("22", "PC", "PARCELA DE CONSORCIO"));
      SpecieTitles.Add(new("23", "DD", "DOCUMENTO DE DIVIDA"));
      SpecieTitles.Add(new("24", "CCB", "CEDULA DE CREDITO BANCARIO"));
      SpecieTitles.Add(new("25", "FI", "FINANCIAMENTO"));
      SpecieTitles.Add(new("26", "RD", "RATEIO DE DESPESAS"));
      SpecieTitles.Add(new("27", "DRI", "DUPLICATA RURAL INDICACAO"));
      SpecieTitles.Add(new("28", "EC", "ENCARGOS CONDOMINIAIS"));
      SpecieTitles.Add(new("29", "ECI", "ENCARGOS CONDOMINIAIS POR INDICACAO"));
      SpecieTitles.Add(new("31", "CC", "CARTAO DE CREDITO"));
      SpecieTitles.Add(new("32", "BDP", "BOLETO DE PROPOSTA"));
      SpecieTitles.Add(new("99", "OUT", "OUTROS"));
      #endregion
    }

    /// <summary>
    /// Recupera a espécie de título conformeo  número inserido. Caso não seja encontrado, retorna 99 = Outros.
    /// </summary>
    /// <returns></returns>
    public static SpecieTitle GetByCode(string code)
    {
      create();

      SpecieTitle specie = SpecieTitles.Where(x => x.Code == code).FirstOrDefault();
      
      if(specie is null)
      {
        return SpecieTitles.Where(x => x.Code == "99").FirstOrDefault();
      }
      else
      {
        return specie;
      }
    }

    /// <summary>
    /// Recupera a espécie de título conformeo a sigla inserida. Caso não seja encontrado, retorna 99 = Outros.
    /// </summary>
    /// <returns></returns>
    public static SpecieTitle GetByInitials(string initials)
    {
      create();

      SpecieTitle specie = SpecieTitles.Where(x => x.Initials == initials).FirstOrDefault();

      if (specie is null)
      {
        return SpecieTitles.Where(x => x.Code == "99").FirstOrDefault();
      }
      else
      {
        return specie;
      }
    }

    /// <summary>
    /// Recupera a espécie de título conforme descrição inserida. Caso não seja encontrado, retorna 99 = outros.
    /// </summary>
    /// <returns></returns>
    public static SpecieTitle GetByDescription(string description)
    {
      create();

      SpecieTitle specie = SpecieTitles.Where(x => x.Initials.Contains(description)).FirstOrDefault();

      if (specie is null)
      {
        return SpecieTitles.Where(x => x.Code == "99").FirstOrDefault();
      }
      else
      {
        return specie;
      }
    }
  }

  /// <summary>
  /// Estrutura básica da tabela de códigos de espécie de títulos
  /// </summary>
  public class SpecieTitle{
    public string Code { get; private set; }
    public string Initials { get; private set; }
    public string Description { get; private set; }

    public SpecieTitle(string code, string initials, string description)
    {
      Code = code;
      Initials = initials;
      Description = description;
    }
  }
}
