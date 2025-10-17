# LojaPesca - Solução .NET 6.0

Solução de gerenciamento de loja de pesca seguindo a arquitetura **Onion/Clean Architecture**.

## 🏗️ Estrutura da Solução

A solução está organizada em 4 projetos com responsabilidades bem definidas:

### 1. **LojaPesca.Domain** (Class Library)
- **Responsabilidade:** Entidades de negócio, Value Objects e Interfaces de Repositório (contratos)
- **Dependências:** Nenhuma
- **Estrutura:**
  - `Entities/` - Entidades do domínio
  - `IRepository.cs` - Interface genérica de repositório com métodos assíncronos

### 2. **LojaPesca.Application** (Class Library)
- **Responsabilidade:** Casos de uso (CQRS), DTOs, Lógica de aplicação
- **Dependências:** 
  - `LojaPesca.Domain`
  - `MediatR` (v13.0.0)
  - `AutoMapper.Extensions.Microsoft.DependencyInjection` (v12.0.1)
- **Estrutura:**
  - `Features/Pecas/` - Use cases relacionados a peças
    - `CadastrarPecaCommand.cs` - Command para cadastro
    - `CadastrarPecaCommandHandler.cs` - Handler do command

### 3. **LojaPesca.Infrastructure** (Class Library)
- **Responsabilidade:** Implementação de repositórios (EF Core), Serviços de infraestrutura
- **Dependências:**
  - `LojaPesca.Domain`
  - `LojaPesca.Application`
  - `Microsoft.EntityFrameworkCore.SqlServer` (v6.0.35)
- **Estrutura:**
  - `Repositories/` - Implementações de repositórios
    - `PecaRepositoryMock.cs` - Implementação mockada do repositório

### 4. **LojaPesca.API** (ASP.NET Core Web API)
- **Responsabilidade:** Endpoints HTTP, Injeção de Dependência, Middlewares
- **Dependências:**
  - `LojaPesca.Application`
  - `LojaPesca.Infrastructure`
  - `Swashbuckle.AspNetCore` (v6.5.0)
- **Estrutura:**
  - `Program.cs` - Configuração de serviços e Minimal API Endpoints
  - `DTOs/` - Data Transfer Objects para API
    - `CadastrarPecaDto.cs` - DTO para cadastro de peças

## 🚀 Endpoints Disponíveis

### POST /pecas
Cadastra uma nova peça no sistema.

**Request Body:**
```json
{
  "nome": "Vara de Pesca Telescópica",
  "descricao": "Vara telescópica 2.1m",
  "preco": 159.90,
  "quantidadeEstoque": 50
}
```

**Response:**
```json
{
  "id": 1
}
```

## 🛠️ Tecnologias Utilizadas

- **.NET 6.0**
- **MediatR** - Implementação do padrão Mediator para CQRS
- **AutoMapper** - Mapeamento objeto-objeto
- **Entity Framework Core** - ORM para acesso a dados
- **Swagger/OpenAPI** - Documentação da API

## 📦 Como Executar

1. **Restaurar dependências:**
```powershell
dotnet restore
```

2. **Compilar a solução:**
```powershell
dotnet build
```

3. **Executar a API:**
```powershell
cd LojaPesca.API
dotnet run
```

4. **Acessar o Swagger:**
Abra o navegador em: `https://localhost:<porta>/swagger`

## 🏛️ Princípios da Arquitetura

A solução segue os princípios da **Clean Architecture**:

- ✅ **Independência de frameworks** - O domínio não depende de frameworks externos
- ✅ **Testabilidade** - Regras de negócio podem ser testadas isoladamente
- ✅ **Independência de UI** - A UI pode mudar sem afetar o domínio
- ✅ **Independência de banco de dados** - Pode trocar SQL Server por outro BD
- ✅ **Separação de responsabilidades** - Cada camada tem uma responsabilidade única

## 📝 Próximos Passos

- [ ] Implementar entidade `Peca` no Domain
- [ ] Configurar DbContext no Infrastructure
- [ ] Implementar repositório real com EF Core
- [ ] Adicionar AutoMapper profiles
- [ ] Implementar validações com FluentValidation
- [ ] Adicionar tratamento de erros global
- [ ] Implementar testes unitários
- [ ] Configurar string de conexão
- [ ] Adicionar migrations do EF Core

## 📄 Licença

Este projeto foi criado para fins educacionais.

Projeto e-commerce para simular uma loja de pesca virtual.
