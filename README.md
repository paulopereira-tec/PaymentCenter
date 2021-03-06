# PaymentCenter
PaymentCenter é uma biblioteca de middleware entre sua aplicação e APIs de diversas plataformas de pagamento.

O objetivo desse projeto é criar uma central de integração com várias plataformas de pagamento, senão todas. Por exemplo: PagSeguro, Moip, Braspag, boletos bancários, Pix, etc.

É um projeto ambicioso. Se tiver interesse em colaborar, seja bem-vindo(a). Todo o projeto é de código aberto justamente com o objetivo de que muitas pessoas possam ajudá-lo a crescer. Nas próximas linhas explico como está tudo organzado.

O projeto *PaymentCenter* é a biblioteca de pagamentos propriamente dita. Já o projeto *PaymentSystem* é um projeto console para executar o anterior. Futuramente será implementado um projeto para testes unitários.

## Estrutura organizacional básica
A estrutura abaixo refere-se ao projeto "PaymentCenter".

### Domain
Contém entidades e interfaces de domínio que serão utilizadas ao longo do projeto. Interfaces estão em um diretório específico para não se confundirem com as entidades em seu diretório específico.

### Infra
O objetivo da seção "Infra" de diretórios é classes e recursos de infraestrutura da aplicação como recursos compartilhados (Shared).

Dentro do diretório Shared irá encontrar:
- *Abstractions:* Classes abstratas que serão utilizadas, principalmente na seção "Platforms".
- *Enums:* Enumeradores que podem ser usados em vários locais do sistemas.
- *Interfaces:* Interfaces usadas por todas as plataformas estão neste diretório. Interfaces mais específicas para cada plataforma serão explicadas mais a frente.
- *ValuesObjects:* Objetos de valor como Nome, documentos e outros mais estão aqui. Irá notar que há um diretório para Interfaces. Essas são bastante específicas para essa necessidades, por isso estão aqui.

### Plataforms
Aqui será de fato onde a mágica vai acontecer. Cada plataforma de pagmento terá seu próprio diretório. Já existem alguns diretórios para exemplificar a ideia. Vamos olhar para a estrutura de três diretórios: Braspag, Itaú e Pix.

#### Braspag
A Braspag é uma plataforma de pagamentos completa e eficiente assim como muitas outras existentes. Sua API é de fácil entendimento e de rápida integração. Ao fazer a integração com essa plataforma, foi criado o arquivo "Braspag.cs". Neste serão coletados os dados da conta no _gateway_ de pagamentos. Em adição, também temos o arquivo "BraspagCreditCard.cs". Este tem a única e irrestrita responsablididade (SRP) de tratar de ações e dados relativos a cartões de crédito.

Ao fazer novas integrações com a Braspag, novos arquivos poderão surgir.

#### Itaú
Seguindo a mesma lógica da anterior, temos uma classe "Itau.cs" com propriedades de dados do correntista. Temos ainda a "ItauBillet.cs", uma classe exclusiva para gerar boletos do banco Itaú.

#### Pix
Pix é o novo modelo de pagamentos estabelecidos pelo Banco Central do Brasil (BCB). É um forte candidato para substituir os saudosos boletos bancários. O BCB recentemente informou que, a partir de 15 de março de 2021, o PIX terá opções de inserir data de vencimentos, juros e mora. As mesmas características dos convencionais boletos. A vantagem é que trata-se de uma plataforma integrada e padronizada para todos os bancos.

Falando a respeito do diretório, vai notar que temos um diretório com interfaces muito específicas para esta plataforma, logo, é aqui que devem ficar. Há ainda o arquivo "Pix.cs" que fará toda a integração e geração do código de barras ou até mesmo 'Boletos Pix'. Há um arquivo bem específico chamado "PixKey.cs". Este faz a validação se a chave Pix está correta.

### Payments.cs
Esta classe é a "cola" de tudo. Nela que ocorrerá a organização de tudo, embora não seja necessário utilizá-la, haja vista que todos os items são independentes.
