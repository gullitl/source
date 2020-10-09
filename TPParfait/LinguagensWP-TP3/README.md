# TP3 LinguagensWP - Asp.Net Core MVC CRUD com EF Core


 # Sobre

Neste TP1 foi criado um projeto do tipo ASP.NET Core Web Application, utilizando o template Model-View-Controller.

Foi desenvolvido um CRUD básico (listagem, detalhe, inclusão, alteração, exclusão) utilizando duas entidades: Linguagem e Autor.
Cada entidade contem pelo menos cinco propriedades, incluindo uma Chave Primária (PK), um DateTime e outras de variados tipos (int, string, DateTime, bool). Uma das entidades tem uma Chave Estrangeira (FK).
Além das operações básicas de CRUD, também tem validações nos formulários, para cada entidade foram verificadas pelo menos 3 propriedades.

 # Requisitos adicionais ao TP1

Foi criado um projeto novo utilizando o template de WEB API.

Foi implementado para a camada de Apresentação não acessar mais diretamente as Regras de Negócio.

Foi alterada a camada de Apresentação para acessar o WEB API via requisições HTTP.

Foi implementado para a camada de WEB API passar a fazer acesso a camada de Regras de Negócio para realizar as operações requisitadas pela camada de Apresentação.

Foram criados também projetos do tipo Class Library (.NET Standard) que contêm o código relacionado a negócio e persistência.

Forma mantidos separados os códigos de apresentação, regra de negócio e de persistência.

Foram criados os Modelos, as Visões fortemente tipadas e os Controladores.

Foi usado Entity Framework para as operações de acesso a dados.

 # Autor
 
 Parfait Mbamu