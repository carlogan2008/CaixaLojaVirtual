Pagamento Caixa Loja Vitual

Fluxo de caixa desnevolvida em .Net MVC, com Clean Code e os principios do SOLID.


Tecnologias e bibliotecas usadas

	•	.NET 7

	•	EntityFramework Core

	•	SQL Server

	•	AutoMapper

	•	FluentValidation

	•	Identity Server
	

Patterns utilizados

	•	Database per Service
	•	Unit Of Work
	•	Repository


Padrões de projetos utilizados

	•	Scoped


Instruções:

	•	Subir o Docker através do CMD com o comando "docker-compose up"

	•	Executar o projeto pelo Visual Studio

	•	Realizar as migrations:

		•	No projeto CaixaLojaVirtual.WebApp.MVC executar o comando "update-database -Context ApplicationDbContext"

		•	No projeto CaixaLojaVirtual.Pagamentos.Data executar o comando "update-database -Context PagamentoContext"
