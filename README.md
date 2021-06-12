# CleanArchitecture

Criando projetos .NET Core segundo a Clean Architecture

## 1. Definindo o projeto - Escopo Geral - Relacionamento e dependência entre os projetos

- CleanArchitecture.Domain: Não possui nenhuma dependência
- CleanArchitecture.Application: Dependência com o projeto -> Domain
- CleanArchitecture.Infra.Data: Dependência com o projeto -> Domain
- CleanArchitecture.Infra.IoC: Dependência com op rpjrto -> Domain, Apllication, Infea.Data
- CleanArchitecture.WebUI: Dependência com o projeto -> Infra.IoC
