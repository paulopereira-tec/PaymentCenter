# Descrição
O objetivo desse projeto é prover uma única API de integração entre sua aplicação e diversas plataformas de pagamento de forma que a integração seja uniforme e fácil de implementar. Atualmente, está integrado com as seguintes plataformas:
- Boletos do banco Bradesco.

# Exemplo de utilização
(Consulte a Wiki para mais informações)

## Criação dos personagens principais: pagador e recebedor

    /* PAGADOR */
    IName nameToPayer = new NamePF("Nome", "Sobrenome");

    Address addressToPayer = new Address("Logradouro", "Número", "Bairro", "Cidade", "UF", "00.000-000", "Complemento se houver");

    IDocument documentToPayer = new DocumentPF("000.000.000-00");

    IPerson payer = new Person(nameToPayer, addressToPayer, documentToPayer, "email@dominio.com.br");


    /* RECEBEDOR */
    IName nameToReceiver = new NamePJ("Razão social");

    Address addressToReceiver = new Address("Logradouro", "Número", "Bairro", "Cidade", "UF", "00.000-000", "Complemento se houver");
    
    IDocument documentToReceiver = new DocumentPJ("999.999.999/8888-22");
    
    IPerson receiver = new Person(nameToReceiver, addressToReceiver, documentToReceiver, "email@empresarecebedora.com.br");


## CRIA A PLATAFORMA DE PAGAMENTO
        IAccountDataForBank accountData = new AccountDataForBank(0123, 45678, 9); // Agencia, conta e dígito respectivamente
    IPaymentData paymentData = new PaymentData("Plano de saúde", 10000, DateTime.Now, DateTime.Now); // Descrição do pagamento, valor, data de emissão e data de vencimento respectivamente.

    Bradesco bradesco = new Bradesco(payer, receiver, accountData, paymentData)
        .AddCertificate(@"C:\ecnpj.pfx", "senhaDoCertificado")
        .SetEndpoint(EEnvironment.Development)
        .Prepare("1", "2", "3"); // Tipo de operação, string espécie título e IOF respectivamente

 ## Executa a emissão de boleto
    string resultFromBradesco = bradesco.Execute();
    Console.WriteLine(bradesco.GetJsonData());
    File.WriteAllTextAsync(@"C:\DadosParaOBradesco.json", bradesco.GetJsonData());
    File.WriteAllTextAsync(@"C:\RetornoBradesco.xml", resultFromBradesco);
