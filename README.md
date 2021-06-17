# CleanArchitecture

Criando projetos .NET Core segundo a Clean Architecture

## 1. Definindo o projeto - Escopo Geral - Relacionamento e dependência entre os projetos

- CleanArchitecture.Domain: Não possui nenhuma dependência
- CleanArchitecture.Application: Dependência com o projeto -> Domain
- CleanArchitecture.Infra.Data: Dependência com o projeto -> Domain
- CleanArchitecture.Infra.IoC: Dependência com op rpjrto -> Domain, Apllication, Infea.Data
- CleanArchitecture.WebUI: Dependência com o projeto -> Infra.IoC

![Arquitetura do projeto](https://raw.githubusercontent.com/wandealves/CleanArchitecture/0e4ef12f8754d8ac98201200d92b263d2eddadc2/assets/ArquiteturaProjeto.svg "Arquitetura do projeto")

## 2. Migrations

Visual Studio

Add-migration <nome>
update-database
remove-migration
get-migration

Net CLI

dotnet ef migrations add <nome>
dotnet ef database
dotnet ef migrations remove
dotnet ef migrations list

dotnet tool install --global dotnet-ef
