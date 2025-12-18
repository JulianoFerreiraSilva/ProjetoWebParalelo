🚀 ProjetoWebParalelo

📌 Descrição

O ProjetoWebParalelo é uma aplicação web desenvolvida em ASP.NET Core MVC (.NET Core 3.1), criada com o objetivo de praticar e consolidar conhecimentos em C#, desenvolvimento web, Entity Framework Core e SQL Server, seguindo boas práticas de organização e arquitetura de projetos.
O sistema implementa funcionalidades comuns em aplicações corporativas, como CRUD completo, integração com banco de dados e separação de responsabilidades entre Controllers, Models e Views.
________________________________________
🛠️ Tecnologias Utilizadas

•	C#

•	ASP.NET Core MVC (.NET Core 3.1)

•	Entity Framework Core

•	SQL Server

•	Razor Page

•	HTML5

•	CSS3

•	Bootstrap

•	Visual Studio
________________________________________
🏗️ Arquitetura do Projeto

O projeto segue o padrão MVC (Model–View–Controller):

•	Controllers

Responsáveis por receber as requisições, aplicar regras de negócio e retornar as respostas.

•	Models

Representam as entidades do domínio e o mapeamento com o banco de dados.

•	Views (Razor)

Interface com o usuário, responsável pela renderização das páginas HTML.

•	Data / Context

Configuração do Entity Framework Core e acesso ao banco de dados.
________________________________________
⚙️ Funcionalidades

•	Cadastro de registros

•	Listagem de dados

•	Edição de informações

•	Exclusão de registros

•	Validação de dados

•	Integração com banco de dados SQL Server via Entity Framework Core
________________________________________
▶️ Como Executar o Projeto Localmente

✅ Pré-requisitos

•	Visual Studio 2019 ou superior

•	.NET Core SDK 3.1

•	SQL Server (LocalDB ou instância configurada)
________________________________________
📥 Passo a Passo

1.	Clone o repositório:
2.	git clone https://github.com/JulianoFerreiraSilva/ProjetoWebParalelo.git
3.	Abra o projeto no Visual Studio
4.	Configure a Connection String no arquivo appsettings.json:
5.	"ConnectionStrings": {"DefaultConnection": "Server=SEU_SERVIDOR;Database=ProjetoWebParalelo;Trusted_Connection=True;"}
6.	Execute as migrations do Entity Framework Core (se aplicável):
7.	Update-Database
8.	Execute o projeto:
o	Pelo Visual Studio (F5)
o	Ou via terminal:
o	dotnet run
9.	Acesse no navegador:
10.	https://localhost:5001
________________________________________
🎯 Objetivo do Projeto

Este projeto foi desenvolvido com foco em:

•	Aprimorar conhecimentos em ASP.NET Core MVC

•	Aplicar conceitos de CRUD

•	Trabalhar com Entity Framework Core

•	Estruturação de aplicações web seguindo boas práticas

•	Servir como projeto de portfólio para oportunidades como Desenvolvedor .NET
________________________________________
👨‍💻 Autor

Juliano Ferreira da Silva

•	🔗 LinkedIn: https://www.linkedin.com/in/julianoferreirasilva/
•	💻 GitHub: https://github.com/JulianoFerreiraSilva
________________________________________
📄 Licença

Este projeto está sob a licença MIT.

Sinta-se à vontade para utilizar, estudar e contribuir.

