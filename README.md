## Desenho da Solução
![](https://raw.githubusercontent.com/alanbassi/cash-flow/main/Architecture.drawio.png)

## Subindo a aplicação com Docker Compose
Para subir a aplicação é necessário ter o Docker e o Docker Compose instalado na máquina.

Na pasta raíz do projeto execute o seguinte comando: docker compose up -d

## Sobre o projeto
### Frontend

Como base para o frontend utilizei um projeto [React](https://github.com/luiizsilverio/dtmoney) com licença MIT para uso. Precisei realizar algumas alterações afim de manter a Linguagem Ubíqua da solução e também realizar as integrações com a API.

### Backend

Na parte do backend criei uma estrutura do zero feita em .Net 6 (Última versão LTS) afim de atender o desafio. Utilizei algumas tecnologias/boas práticas como AutoMapper, MediatR, Singleton, Swagger, Repository Pattern, MongoDB (NoSQL), CQS, SOLID, Clean Code e Clean Architecture.

## Screenshots
![](https://raw.githubusercontent.com/alanbassi/cash-flow/main/frontend/public/screen1.png)
![](https://raw.githubusercontent.com/alanbassi/cash-flow/main/frontend/public/screen2.png)
