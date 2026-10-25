# 🚀 Projeto Web Paralelo

### ASP.NET Core MVC | .NET Core 3.1 | Entity Framework Core 3.1.3 | SQL Server

O **Projeto Web Paralelo** é uma aplicação web desenvolvida em C# com ASP.NET Core MVC, voltada ao gerenciamento de produtos, fornecedores, fabricantes e movimentações de estoque.

O projeto foi desenvolvido com o objetivo de aprofundar conhecimentos em desenvolvimento web no ecossistema .NET, aplicando conceitos de programação orientada a objetos, persistência de dados, separação de responsabilidades e integração com bancos de dados relacionais.

A solução utiliza **.NET Core 3.1**, Entity Framework Core e SQL Server, organizando a aplicação em componentes MVC, uma biblioteca de modelos e uma camada de acesso a dados.

---

## 🛠️ Tecnologias utilizadas

| Tecnologia | Versão / aplicação |
|---|---|
| C# | Linguagem de programação |
| .NET Core | 3.1 |
| ASP.NET Core MVC | 3.1 |
| Entity Framework Core | 3.1.3 |
| SQL Server / LocalDB | Banco de dados relacional |
| Razor Views | Interfaces web |
| HTML, CSS e Bootstrap | Estrutura e apresentação visual |
| Visual Studio | Desenvolvimento |
| Git / GitHub | Versionamento |

---

## 🏗️ Arquitetura e organização

A aplicação utiliza o padrão **MVC (Model-View-Controller)** e uma organização que separa modelos, interface, acesso a dados e lógica de interação.

### Model

As entidades estão organizadas em um projeto independente chamado `Modelo`, contendo as estruturas de dados utilizadas pela aplicação.

Entre as entidades estão:

- Produto
- Fornecedor
- Fabricante
- Estoque
- EntradaMercadoria
- ProdutoFornecedor

### View

As interfaces são implementadas com Razor Views, utilizando HTML e recursos de estilização para apresentação e interação com o usuário.

### Controller

Os controllers recebem as requisições HTTP, coordenam os fluxos da aplicação e utilizam a camada de acesso a dados.

### DAL — Data Access Layer

A camada DAL concentra operações de consulta e persistência com o Entity Framework Core.

O projeto possui classes específicas para diferentes responsabilidades, como `ProdutoDAL`, `FornecedorDAL`, `FabricanteDAL`, `EstoqueDAL` e `EntradaMercadoriaDAL`.

### Data / Context

A classe `AcessoContext` herda de `DbContext` e configura o acesso às entidades persistidas no SQL Server.

O contexto é registrado por meio do mecanismo de injeção de dependência do ASP.NET Core.

---

## 📦 Funcionalidades implementadas

### Cadastro de produtos

- Cadastro de produtos.
- Listagem de registros.
- Consulta por identificador.
- Atualização de informações.
- Exclusão de produtos.
- Associação com fabricantes.
- Validação de formulários.

### Cadastro de fornecedores

- Cadastro de fornecedores.
- Listagem e consulta.
- Atualização de dados cadastrais.
- Exclusão de registros.
- Validação dos dados informados.

### Cadastro de fabricantes

- Cadastro de fabricantes.
- Listagem e consulta.
- Atualização de informações.
- Exclusão de registros.

### Controle de estoque

- Consulta de registros de estoque.
- Visualização de detalhes.
- Formulário para entrada de mercadorias.
- Associação de movimentações com produtos e fornecedores.
- Registro de entradas de mercadorias.

**Observação:** o código possui funcionalidades em diferentes estágios de implementação. Os fluxos de edição e exclusão de estoque e determinadas operações de entrada de mercadorias não estão integralmente implementados.

A rotina de entrada também requer revisão para garantir a atualização correta das quantidades em todos os cenários.

---

## 🗄️ Banco de dados e persistência

A aplicação utiliza **SQL Server**, com suporte ao SQL Server LocalDB para desenvolvimento.

O acesso aos dados é realizado por meio do Entity Framework Core 3.1.3.

### Recursos utilizados

- `DbContext` e `DbSet`.
- Operações CRUD.
- Consultas com LINQ.
- Carregamento de relacionamentos com `Include`.
- Operações assíncronas de consulta e persistência.
- Migrations para evolução do esquema do banco de dados.

O repositório contém migrations relacionadas à estrutura inicial, estoque e entrada de mercadorias.

---

## 📂 Estrutura do projeto

```text
ProjetoWebParalelo/
├── Modelo/
│   ├── Cadastro/
│   │   ├── Produto.cs
│   │   ├── Fornecedor.cs
│   │   ├── Fabricante.cs
│   │   ├── Estoque.cs
│   │   └── EntradaMercadoria.cs
│   └── Modelo.csproj
│
├── ProjetoWebParalelo/
│   ├── Controllers/
│   ├── Data/
│   │   ├── DAL/
│   │   └── AcessoContext.cs
│   ├── Migrations/
│   ├── Models/
│   ├── Views/
│   ├── Properties/
│   ├── Startup.cs
│   ├── Program.cs
│   ├── appsettings.json
│   └── ProjetoWebParalelo.csproj
│
└── ProjetoWebParalelo.sln
```

---

## ⚙️ Como executar

### Pré-requisitos

- .NET Core SDK 3.1.
- Visual Studio compatível com o projeto.
- SQL Server ou SQL Server LocalDB.
- Ferramentas do Entity Framework Core compatíveis com a versão 3.1.

### 1. Clonar o repositório

```bash
git clone https://github.com/JulianoFerreiraSilva/ProjetoWebParalelo.git
```

### 2. Abrir a solução

Abra o arquivo `ProjetoWebParalelo.sln` no Visual Studio.

### 3. Restaurar dependências

Na pasta da solução, execute:

```bash
dotnet restore
```

### 4. Configurar o banco de dados

A configuração de conexão utiliza a chave:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ProjeroParaleloDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

O exemplo representa a configuração de desenvolvimento presente no projeto.

Para utilizar outra instância do SQL Server, ajuste a string de conexão conforme seu ambiente.

### 5. Aplicar as migrations

No diretório do projeto web, com as ferramentas do Entity Framework Core configuradas, execute:

```bash
dotnet ef database update
```

### 6. Executar a aplicação

```bash
dotnet run
```

O perfil de execução do projeto utiliza os seguintes endereços locais:

- HTTPS: `https://localhost:5001`
- HTTP: `http://localhost:5000`

A disponibilidade da aplicação depende da configuração local e da restauração correta das dependências.

---

## 🧪 Conceitos aplicados

O projeto demonstra a utilização de:

- Programação orientada a objetos.
- ASP.NET Core MVC.
- Separação de responsabilidades.
- Camada de acesso a dados.
- Injeção de dependência.
- Entity Framework Core.
- LINQ.
- Programação assíncrona.
- Operações CRUD.
- Validação de formulários.
- Migrations.
- Persistência com SQL Server.

---

## 📌 Contexto e evolução técnica

Este projeto representa uma etapa de evolução dos conhecimentos em desenvolvimento web com C# e .NET.

Em comparação com projetos baseados no .NET Framework clássico, a aplicação utiliza ASP.NET Core, registro de dependências, Entity Framework Core e uma organização mais modular.

O projeto também antecede trabalhos desenvolvidos com versões mais recentes do .NET e arquiteturas voltadas ao desenvolvimento de APIs REST.

### Projetos relacionados

**[Sistema de Estoque e Vendas](https://github.com/JulianoFerreiraSilva/SistemaEstoqueVendas)**

Aplicação desenvolvida com ASP.NET MVC 5, .NET Framework 4.5.2, Entity Framework 5 e SQL Server.

**[Finance Core](https://github.com/JulianoFerreiraSilva/ApiFinanceCore)**

API REST de controle financeiro desenvolvida em .NET 8, com PostgreSQL, CQRS, MediatR, Identity e autenticação JWT.

Esses projetos demonstram diferentes etapas de aprendizado e evolução tecnológica no desenvolvimento de software com C#.

---

## 👨‍💻 Autor

**Juliano Ferreira da Silva**

Desenvolvedor C# / .NET

GitHub: [JulianoFerreiraSilva](https://github.com/JulianoFerreiraSilva)

LinkedIn: [julianoferreirasilva](https://www.linkedin.com/in/julianoferreirasilva/)

---

**Projeto Web Paralelo — Desenvolvimento web com ASP.NET Core MVC, Entity Framework Core e SQL Server.**
