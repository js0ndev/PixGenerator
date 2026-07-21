# Pix Generator .NET

Projeto desenvolvido para estudo e prática de desenvolvimento backend utilizando ASP.NET Core.

A aplicação gera QR Code PIX e código PIX Copia e Cola a partir dos dados informados pelo usuário.

O objetivo do projeto foi praticar criação de APIs, separação de responsabilidades, comunicação entre aplicações e organização de código utilizando .NET.

## Tecnologias

* .NET 10
* ASP.NET Core Web API
* ASP.NET Core MVC
* C#
* HttpClient
* Dependency Injection
* QRCoder

## Estrutura

O projeto possui duas aplicações:

### Pix.Api

API responsável pela geração do PIX.

Responsável por:

* Receber os dados;
* Gerar o BR Code;
* Criar o QR Code;
* Retornar a resposta em JSON.

### Pix.Web

Aplicação MVC responsável pela interface.

Responsável por:

* Exibir o formulário;
* Consumir a API;
* Exibir o QR Code gerado.

## Fluxo

```
Usuário
   ↓
Pix.Web (MVC)
   ↓
HTTP Request
   ↓
Pix.Api
   ↓
Geração PIX + QR Code
   ↓
Resposta JSON
```

## Conceitos praticados

* ASP.NET Core Web API
* MVC
* Controllers e Services
* Dependency Injection
* HttpClient
* REST API
* JSON
* async/await
* Organização em camadas

## Como executar

API:

```bash
dotnet run --project Pix.Api
```

MVC:

```bash
dotnet run --project Pix.Web
```

## Próximas melhorias

* Persistência em banco de dados;
* Testes automatizados;
* Deploy em cloud;
* Autenticação de usuários.

Projeto desenvolvido como prática de evolução no desenvolvimento backend com .NET.
