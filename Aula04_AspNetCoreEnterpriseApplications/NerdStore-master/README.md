# NerdStore

- Aplicação web do curso avançado de ASP.NET Core Enterprise Applications do desenvolvedor.io.

## Objetivos

- Aplicação estilo e-commerce utilizando conceitos avançados do ASP.NET Core e modelagem.

- Cenários de aplicações corporativas onde o conhecimento e planejamento são fundamentais 
para a implementação de uma solução sólida e bem estruturada.

- Implementação de recursos de comunicação como filas,
chamadas remotas e também distribuição utilizando containners
com Docker.

- Pattern's e muito mais

## Algumas features da API (Os commits serão feitos quando cada feature for concluída)

### API de Identidade

- Fluxo de autenticação
- Configuração do Identity
- Registro de login
- Documentação com Swagger
- Configuração do JWT
- Response Customizado

### Aplicação Web

- Configurar a autenticação
- Consumindo uma API via HttpService
- Gerar cookie através do JWT e obter dados do usuário através dele
- Tratamento de erros do response e exibi-los para o usuário
- Tratar erros do servidor
- Boas práticas HttpServices

### Comunicação com API's

-Layout do e-commerce
- Arquitetura, modelagem e acesso a dados da API Catalogo
- Validação de JWT
- Validação de acesso baseado em Claims
- DelegatingHandlers
- Refit para consumo de API's
- Retry Pattern e Circuit Breaker com Polly

### Modelagem da API de Clientes

- Definir entidades
- Objetos de valor e validações
- Mapeamento das tabelas
- Command e command handler
- MediatR e command handler
- Persistência via command handler
- Eventos
- Execução do processo de cadastro e registro do cliente via WebApp

### Comunicação entre API's com RabbitMQ

- Request response pattern
- Implementando o request e response
- Customização do EventBus
- Validar cenários e recuperação de falhas

### API de Carrinho

- Reconhecimento do usuário
- Comportamento de negocio da API
- Implementando carrinho no front-end

### Processo de Pedidos

- Implementando e consumindo serviços pelo BFF
- Modelagem da entidade voucher e criação da tabela
- Application query stack e Specification Pattern
- Aplicando o voucher via BFF
- Aplicando Voucher na API de Carrinho e na WebApp
- Modelagem do pedido no dominio
- Camadas de infraestrutura de pedido, application de pedido.
- Utilizando Dapper na query stack
- Manipulando o Carrinho via RabbitMQ
- Cadastro e consulat de endereço do cliente
- Configurações e validações no BFF de Compras
- Tratamento de erros

### API de Pagamentos

- Gateway de pagamento
- Solicitando o processamento de pagamento
- Modelagem das classes
- Facade com o gateway de pagamento
- Background service de pagamento
- Fluxo de captura e cancelamento
- Rodando tarefas agendadas de forma nativa
- Baixando o pedido do estoque
- Captura e cancelamento de pagamentos


### E mais como:

- Paginação no MVC
- ViewComponent de paginação
- Pesquisa avançada
- JWK e JWKS na API de Identidade
- Refresh Token
- gRPC
- SQL Server via Docker
- NGINX






































