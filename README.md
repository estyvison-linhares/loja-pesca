# Loja Pesca - E-commerce

Projeto e-commerce para simular uma loja de pesca virtual.

## 🏗️ Arquitetura

Este projeto segue os princípios de **Clean Architecture** com separação em camadas:

```
LojaPesca/
├── src/
│   ├── LojaPesca.Domain/          # Camada de domínio (Entidades e Interfaces)
│   ├── LojaPesca.Application/      # Camada de aplicação (Serviços e DTOs)
│   ├── LojaPesca.Infrastructure/   # Camada de infraestrutura (Repositórios e Dados)
│   └── LojaPesca.API/             # Camada de apresentação (Web API)
└── LojaPesca.sln
```

## 🛠️ Tecnologias

- **.NET 8.0**
- **ASP.NET Core Web API**
- **Swagger/OpenAPI**

## 📦 Projetos

### LojaPesca.Domain
Contém as entidades de domínio e interfaces:
- `Entities/` - Entidades do domínio (Product, BaseEntity)
- `Interfaces/` - Interfaces de repositório

### LojaPesca.Application
Contém a lógica de negócio:
- `Services/` - Serviços de aplicação (ProductService)
- `Interfaces/` - Interfaces de serviços
- `DTOs/` - Data Transfer Objects

### LojaPesca.Infrastructure
Implementação de infraestrutura:
- `Repositories/` - Implementação dos repositórios (InMemoryProductRepository)
- `Data/` - Configuração de acesso a dados
- `DependencyInjection.cs` - Configuração de injeção de dependência

### LojaPesca.API
API Web:
- `Controllers/` - Controllers REST (ProductsController)
- `Program.cs` - Configuração da aplicação

## 🚀 Como Executar

### Pré-requisitos
- .NET 8 SDK ou superior

### Executar a aplicação

```bash
# Restaurar dependências
dotnet restore

# Compilar o projeto
dotnet build

# Executar a API
dotnet run --project src/LojaPesca.API
```

A API estará disponível em `https://localhost:5001` ou `http://localhost:5000`.

### Acessar o Swagger

Após executar a aplicação, acesse: `https://localhost:5001/swagger`

## 📝 Endpoints da API

### Products

- `GET /api/products` - Lista todos os produtos
- `GET /api/products/{id}` - Obtém um produto por ID
- `GET /api/products/category/{category}` - Lista produtos por categoria
- `GET /api/products/search?name={name}` - Busca produtos por nome
- `POST /api/products` - Cria um novo produto
- `PUT /api/products/{id}` - Atualiza um produto
- `DELETE /api/products/{id}` - Remove um produto

## 🔄 Próximos Passos

Este é um projeto base. Você pode expandir com:

- [ ] Adicionar Entity Framework Core para persistência em banco de dados
- [ ] Implementar autenticação e autorização
- [ ] Adicionar mais entidades (Cliente, Pedido, ItemPedido, etc.)
- [ ] Implementar validações com FluentValidation
- [ ] Adicionar testes unitários e de integração
- [ ] Implementar padrão CQRS com MediatR
- [ ] Adicionar cache com Redis
- [ ] Implementar logging estruturado com Serilog

## 📄 Licença

Este projeto é livre para uso e modificação.
