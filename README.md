# Desafio Técnico - Microserviços Avanade

## 📋 Descrição do Projeto

Sistema de microserviços para gerenciamento de estoque de produtos e vendas em uma plataforma de e-commerce. A aplicação é composta por dois microserviços principais que se comunicam via API Gateway e utilizam RabbitMQ para comunicação assíncrona.

![Arquitetura do Sistema](./images/45346875-7aad-45d4-8845-feadf18488e5.webp)

## 🏗️ Arquitetura

### Microserviços

#### 1. **Microserviço de Gestão de Estoque** (`stock.service`)
- Responsável por cadastrar produtos
- Controlar o estoque
- Fornecer informações sobre quantidade disponível

#### 2. **Microserviço de Gestão de Vendas** (`sales.service`)
- Gerenciar pedidos
- Interagir com o serviço de estoque
- Verificar disponibilidade de produtos

### Componentes da Arquitetura

- **API Gateway**: Ponto de entrada único para roteamento de requisições
- **RabbitMQ**: Comunicação assíncrona entre microserviços
- **JWT**: Autenticação e autorização
- **Entity Framework**: ORM para acesso ao banco de dados
- **SQL Server**: Banco de dados relacional

## 🚀 Tecnologias Utilizadas

- **.NET Core** (C#)
- **Entity Framework Core**
- **RESTful APIs**
- **RabbitMQ**
- **JWT (JSON Web Tokens)**
- **SQL Server**
- **Docker**

## ⚙️ Funcionalidades

### Microserviço de Estoque
- ✅ **Cadastro de Produtos**: Adicionar produtos com nome, descrição, preço e quantidade
- ✅ **Consulta de Produtos**: Visualizar catálogo e estoque disponível
- ✅ **Atualização de Estoque**: Sincronização automática com vendas

### Microserviço de Vendas
- ✅ **Criação de Pedidos**: Validação de estoque antes da confirmação
- ✅ **Consulta de Pedidos**: Acompanhamento do status dos pedidos
- ✅ **Notificação de Venda**: Comunicação assíncrona para atualização de estoque

### Recursos Comuns
- 🔐 **Autenticação JWT**: Proteção de endpoints
- 🌐 **API Gateway**: Centralização do acesso às APIs
- 📊 **Monitoramento**: Logs e rastreamento de transações

## 🛠️ Como Executar

### Pré-requisitos
- .NET 9.0 SDK
- Docker Desktop
- SQL Server (se executar localmente)
- RabbitMQ (se executar localmente)

### 🐳 Executando com Docker (Recomendado)

A forma mais fácil de executar todo o ambiente é usando Docker Compose:

1. **Clone o repositório**
   ```bash
   git clone https://github.com/your-repo/desafio-tecnico-avanade.git
   cd desafio-tecnico-avanade
   ```

2. **Configure as variáveis de ambiente (opcional)**
   O projeto utiliza um arquivo `.env` para configuração de variáveis sensíveis:
   ```bash
   # Edite o arquivo .env para personalizar as configurações
   # Já existe um arquivo .env com valores padrão
   ```
   
   Principais variáveis que podem ser configuradas:
   - `SA_PASSWORD`: Senha do SQL Server
   - `RABBITMQ_DEFAULT_USER`: Usuário do RabbitMQ
   - `RABBITMQ_DEFAULT_PASS`: Senha do RabbitMQ
   - `STOCK_DB`: Nome do banco de dados do serviço de estoque
   - `SALES_DB`: Nome do banco de dados do serviço de vendas

3. **Execute o script PowerShell (Windows)**
   ```powershell
   # Iniciar todos os serviços
   .\run.ps1

   # Ou comandos específicos:
   .\run.ps1 -Action up      # Iniciar serviços
   .\run.ps1 -Action down    # Parar serviços
   .\run.ps1 -Action build   # Fazer build
   .\run.ps1 -Action logs    # Ver logs
   .\run.ps1 -Action clean   # Limpar ambiente
   ```

4. **Ou use Docker Compose diretamente**
   ```bash
   # Iniciar todos os serviços
   docker-compose up -d --build

   # Parar todos os serviços
   docker-compose down

   # Ver logs
   docker-compose logs -f
   ```

### 🌐 URLs dos Serviços após execução:
- **Stock Service API**: http://localhost:5001
- **Sales Service API**: http://localhost:5002  
- **RabbitMQ Management**: http://localhost:15672 (admin/admin123)
- **SQL Server**: localhost:1433 (sa/YourStrong@Passw0rd)

### 💻 Executando Localmente (Desenvolvimento)

1. **Configure o banco de dados**
   - Atualize as connection strings nos arquivos `appsettings.json`
   - Execute as migrações do Entity Framework

2. **Configure o RabbitMQ**
   - Instale e configure o RabbitMQ
   - Atualize as configurações de conexão

3. **Execute os microserviços**

   **Microserviço de Estoque:**
   ```bash
   cd services/stock.service
   dotnet restore
   dotnet run --project API
   ```

   **Microserviço de Vendas:**
   ```bash
   cd services/sales.service
   dotnet restore
   dotnet run --project API
   ```

## 📚 Estrutura do Projeto

```
📦 desafio-tecnico-avanade
├── 📁 services/
│   ├── 📁 stock.service/
│   │   ├── 📁 API/              # Controladores e configuração da API
│   │   ├── 📁 Application/      # Casos de uso e DTOs
│   │   ├── 📁 Domain/           # Entidades e interfaces de domínio
│   │   └── 📁 Infra/           # Repositórios e acesso a dados
│   └── 📁 sales.service/
│       ├── 📁 API/              # Controladores e configuração da API
│       ├── 📁 Application/      # Casos de uso e DTOs
│       ├── 📁 Domain/           # Entidades e interfaces de domínio
│       └── 📁 Infra/           # Repositórios e acesso a dados
├── 📁 images/                   # Imagens da documentação
└── 📄 README.md
```

## 🔗 Endpoints da API

### Microserviço de Estoque (`stock.service`)
- `GET /api/products` - Listar produtos
- `GET /api/products/{id}` - Obter produto por ID
- `POST /api/products` - Cadastrar produto
- `PUT /api/products/{id}` - Atualizar produto
- `DELETE /api/products/{id}` - Remover produto

### Microserviço de Vendas (`sales.service`)
- `GET /api/orders` - Listar pedidos
- `GET /api/orders/{id}` - Obter pedido por ID
- `POST /api/orders` - Criar pedido
- `PUT /api/orders/{id}/status` - Atualizar status do pedido

## 🔐 Autenticação

O sistema utiliza JWT (JSON Web Tokens) para autenticação. Para acessar os endpoints protegidos:

1. Obtenha um token através do endpoint de login
2. Inclua o token no header `Authorization: Bearer {token}`

## 🧪 Testes

Execute os testes unitários:

```bash
dotnet test
```

## 📊 Monitoramento e Logs

O sistema implementa:
- Logs estruturados com Serilog
- Rastreamento de transações
- Monitoramento de performance
- Health checks

## 🚀 Escalabilidade

A arquitetura foi projetada para ser facilmente escalável:
- Microserviços independentes
- Comunicação assíncrona
- Preparado para containerização
- Suporte a load balancing

## 🤝 Contribuição

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças seguindo o padrão Conventional Commits (`git commit -m 'feat: adicionar nova funcionalidade'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

### Padrão de Commits

Este projeto segue o padrão [Conventional Commits](https://www.conventionalcommits.org/):

- `feat`: Nova funcionalidade
- `fix`: Correção de bug
- `docs`: Documentação
- `style`: Formatação de código
- `refactor`: Refatoração
- `test`: Testes
- `chore`: Tarefas de manutenção

## 📄 Licença

Este projeto está licenciado sob a [MIT License](LICENSE.txt).

## 👥 Contexto do Negócio

A aplicação simula um sistema para uma plataforma de e-commerce, onde empresas precisam gerenciar seu estoque de produtos e realizar vendas de forma eficiente. A solução é escalável e robusta, com separação clara entre as responsabilidades de estoque e vendas, utilizando boas práticas de arquitetura de microserviços.

Este tipo de sistema é comum em empresas que buscam flexibilidade e alta disponibilidade em ambientes com grande volume de transações.

---

**Desenvolvido como parte do Desafio Técnico Avanade** 🚀