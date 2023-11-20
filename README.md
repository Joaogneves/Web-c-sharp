# Projeto de Estudo c# .Net framework

Um sistema backend para gerenciar médicos e clientes


## Sobre

Projeto CRUD de médicos e clientes desenvolvido em C# e .Net framework

## Tecnologias Utilizadas

- C#
- .Net framework
- SQL Server

## Requisitos

- .Net framework
- SQL Server

## Configuração do Projeto

1. Clone o repositório:

```bash
git clone 
 ```

2. Edite o arquivo 'Web.config'

- [Ajuda para string de conexão](https://www.connectionstrings.com/sql-server/)


```xml
<connectionStrings>
	<add name="consultorio" connectionString="coloque aqui sua connection string"/>
</connectionStrings>
```
3. Execute o comando SQL no SQL Server para criação do banco de dados
   
```SQL
CREATE DATABASE consultorio;
```
5. Pode ser startado diretamente da IDE VISUAL STUDIO.

6. Execute o comando SQL no SQL Server para criar as tabelas.

```SQL
Use consultorio;
go 

CREATE TABLE cliente(
	id int identity(1,1) not null,
	nome varchar(200) not null,
	dataNascimento date,
	constraint pk_cliente primary key (id)
)

CREATE TABLE medico(
	id int identity(1,1) not null,
	nome varchar(100) not null,
	crm varchar(20) not null,
	especialidade varchar(200),
	constraint pk_medico primary key (id)
)
```

### Endpoints

O servidor estará disponível em https://localhost:44377
- /api/medicos: Cadastro, Listagem, Updates e Delete de medicos
- /api/cliente: Cadastro, Listagem, Updates e Delete de clientes

## Contato

Caso de dúvidas ou sugestões fique a vontade para entrar em contato.
- Email: joaogabriel443@gmail.com
- Linkedin: https://www.linkedin.com/in/joaognevess

## Contribuindo
Sinta-se à vontade para contribuir com novos recursos, correções de bugs ou melhorias. Abra uma issue para discussões ou envie um pull request.
