
# PriceCPT - Backend

## Descrição do Projeto

Este é o back-end da aplicação **PriceCPT**, construído com **.NET 8** e **Entity Framework Core**, integrado com a API pública do Mercado Livre.  
Ele é responsável por buscar dados de produtos a partir da URL do Mercado Livre, armazenar no banco de dados e controlar o histórico de alterações de preços.

---

## Tecnologias Utilizadas

- .NET 8
- Entity Framework Core
- MySQL (via XAMPP)
- API Mercado Livre

---

## Requisitos

- Visual Studio
- .NET 8 SDK
- XAMPP com Apache, MySQL ou MySQL Workbench
- Git

---

## Como rodar o projeto localmente

### 1. Clonar o repositório

```bash
git clone https://github.com/SEU_USUARIO/pricecpt-backend
cd pricecpt-backend
```

### 2. Configurar o ambiente

Siga os passos abaixo:

3. Abrir o **XAMPP** e iniciar os serviços **Apache** e **MySQL** ou **MySQL Workbench**

4. Acessar o **phpMyAdmin** ou **MySQL Workbench** e criar o banco de dados:

```sql
CREATE DATABASE pricecpt;
```

5. No terminal do projeto, instalar o Entity Framework CLI:

```bash
dotnet tool install --global dotnet-ef
```

6. Testar se o EF foi instalado corretamente:

```bash
dotnet ef
```

Se aparecer o **unicórnio**, está tudo certo

7. Remover a pasta `Migrations`, se ela já existir:

```bash
# excluir manualmente ou usar:
rm -r Migrations
```

8. Criar a primeira migration:

```bash
dotnet ef migrations add MigrationInicial
```

9. Atualizar o banco de dados com as tabelas:

```bash
dotnet ef database update
```

10. Verifique no **phpMyAdmin** se as tabelas foram criadas corretamente.

---


## Frontend do Projeto

O frontend da aplicação foi desenvolvido separadamente com **Vue.js 3**, **Chart.js** e **TailwindCSS**.

Repositório do frontend:  
[Frontend](https://github.com/SEU_USUARIO/pricecpt-frontend)

---

Feito por:

Cauã Reginato RA: 1988923  <br>
Jhonata Canevare RA: 1993374 <br>
Giovanni Ferreira RA: 2005056 <br>
Eduardo Santos RA:1989619
