# Projeto-CRUD-Com-NET

Uma aplicação web full-stack moderna para gerenciamento de inventário de carros, construída com **ASP.NET Core** e **Vue 3** com TypeScript. O projeto implementa um CRUD completo com API RESTful Minimal, banco de dados SQL Server e uma interface amigável.

---

## 📋 Índice

- [Visão Geral](#visão-geral)
- [Arquitetura do Projeto](#arquitetura-do-projeto)
- [Tecnologias](#tecnologias)
- [Pré-requisitos](#pré-requisitos)
- [Instalação e Configuração](#instalação-e-configuração)
- [Estrutura de Diretórios](#estrutura-de-diretórios)
- [Funcionalidades](#funcionalidades)
- [API Endpoints](#api-endpoints)
- [Banco de Dados](#banco-de-dados)
- [Como Usar](#como-usar)
- [Desenvolvimento](#desenvolvimento)
- [Build e Produção](#build-e-produção)
- [Contribuindo](#contribuindo)
- [Licença](#licença)

---

## 🎯 Visão Geral

Este projeto implementa um sistema completo de gerenciamento de carros com:

- **Backend**: API RESTful em ASP.NET Core com Entity Framework Core
- **Frontend**: Interface moderna em Vue 3 com TypeScript
- **Banco de Dados**: SQL Server com migrations automáticas
- **Documentação**: Swagger integrado para exploração de APIs

O sistema permite criar, ler, atualizar e deletar registros de carros e fabricantes, com validação robusta e tratamento de erros.

---

## 🏗️ Arquitetura do Projeto

```
Projeto-CRUD-Com-NET/
├── projetoApiWeb/          # Backend - ASP.NET Core API
│   ├── src/
│   │   ├── Models/         # Modelos de dados (Carro, Fabricante)
│   │   ├── Controller/     # Endpoints da API
│   │   ├── service/        # Serviços de negócio
│   │   ├── extension/      # Extensões (CORS, Migrations)
│   │   ├── DbContext.cs    # Contexto do banco de dados
│   │   └── DatabaseServices.cs
│   ├── Migrations/         # Migrações do Entity Framework
│   ├── Properties/         # Configurações de launch
│   ├── appsettings.json    # Configurações da aplicação
│   ├── Program.cs          # Ponto de entrada
│   └── projetoApiWeb.csproj
│
└── view/                   # Frontend - Vue 3 + Vite
    ├── src/
    │   ├── components/     # Componentes Vue
    │   │   └── templates/  # Layouts
    │   │       └── mainComp/
    │   ├── services/       # Serviços de API e cache
    │   ├── stores/         # Pinia stores
    │   ├── interfaces/     # Tipos TypeScript
    │   ├── .config/        # Configurações
    │   ├── App.vue         # Componente raiz
    │   └── main.ts         # Ponto de entrada
    ├── public/             # Arquivos estáticos
    ├── index.html
    ├── vite.config.ts
    ├── tsconfig.json
    └── package.json
```

---

## 🛠️ Tecnologias

### Backend
- **ASP.NET Core 10.0** - Framework web moderno
- **Entity Framework Core 10.0.2** - ORM para .NET
- **SQL Server** - Banco de dados relacional
- **NSwag 14.6.3** - Swagger/OpenAPI para documentação
- **Microsoft.Data.SqlClient** - Driver SQL Server

### Frontend
- **Vue 3** - Framework JavaScript progressivo
- **TypeScript** - Tipagem estática
- **Vite** - Build tool e dev server
- **Bootstrap 5** - Framework CSS
- **Bootstrap Vue Next** - Componentes Vue para Bootstrap
- **Pinia** - State management
- **Axios** - Cliente HTTP
- **Font Awesome** - Ícones SVG

### Ferramentas
- **.NET CLI** - Gerenciamento de projetos .NET
- **npm/node** - Gerenciamento de dependências JavaScript
- **Git** - Controle de versão

---

## 📦 Pré-requisitos

Antes de começar, verifique se você tem instalado:

- **Node.js**: v20.19.0 ou v22.12.0+ ([Download](https://nodejs.org/))
- **.NET SDK**: v10.0+ ([Download](https://dotnet.microsoft.com/download))
- **SQL Server**: 2019 ou posterior (ou Azure SQL)
- **Git**: Para clonar o repositório
- **npm**: Gerenciador de pacotes (incluído com Node.js)

Verifique as versões:

```bash
node --version      # v20.19.0 ou superior
npm --version       # 10.0 ou superior
dotnet --version    # 10.0 ou superior
```

---

## 🚀 Instalação e Configuração

### 1. Clonar o Repositório

```bash
git clone https://github.com/seu-usuario/Projeto-CRUD-Com-NET.git
cd Projeto-CRUD-Com-NET
```

### 2. Configurar o Backend

#### 2.1 Restaurar Dependências

```bash
cd projetoApiWeb
dotnet restore
```

#### 2.2 Configurar Connection String

Edite `appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=seu-servidor;Database=CrudCarrosDb;User Id=seu-usuario;Password=sua-senha;TrustServerCertificate=true;"
  },
  "ApiSettings": {
    "EndpointCarro": "/api/carros",
    "EndpointFabricante": "/api/fabricantes"
  }
}
```

#### 2.3 Executar Migrations

```bash
dotnet ef database update
```

#### 2.4 Iniciar o Backend

```bash
dotnet run
```

A API estará disponível em: `https://localhost:5001`

### 3. Configurar o Frontend

#### 3.1 Instalar Dependências

```bash
cd ../view
npm install
```

#### 3.2 Configurar URL da API

Edite `src/.config/api.config.ts`:

```typescript
export const API_BASE_URL = 'https://localhost:5001';
```

#### 3.3 Iniciar Dev Server

```bash
npm run dev
```

A aplicação estará disponível em: `http://localhost:5173`

---

## 📁 Estrutura de Diretórios

### Backend - `projetoApiWeb/`

```
src/
├── Models/
│   ├── Tables.cs              # Entidades: Carro e Fabricante
│   └── TablesItemDto.cs       # DTOs para transferência de dados
├── Controller/
│   └── EndPoints.cs           # Mapeamento de endpoints (Carros, Fabricantes)
├── service/
│   └── BaseService.cs         # Serviço genérico base
├── extension/
│   ├── DbCorsPolitic.cs       # Configuração de CORS
│   └── DbMigrationHelper.cs   # Helper para migrations
├── DbContext.cs               # Contexto do Entity Framework
└── DatabaseServices.cs        # Serviços específicos de database
```

### Frontend - `view/src/`

```
├── components/
│   ├── StructureBody.vue      # Layout principal
│   └── templates/
│       ├── HeaderStructure.vue
│       ├── FooterStructure.vue
│       ├── MainStructure.vue
│       └── mainComp/
│           ├── FormCadastro.vue   # Formulário de cadastro
│           ├── ListItems.vue      # Lista de carros
│           └── MenuComp.vue       # Menu de navegação
├── services/
│   ├── api.ts                 # Cliente HTTP
│   └── responseApi.ts         # Tratamento de respostas
├── stores/
│   └── cache.ts              # Pinia store para cache
├── interfaces/
│   └── schemas.ts            # Tipos TypeScript
└── .config/
    ├── api.config.ts         # Configuração de API
    └── app.config.json       # Configurações gerais
```

---

## ✨ Funcionalidades

### Gerenciamento de Carros
- ✅ **Listar** todos os carros
- ✅ **Buscar** carro por ID
- ✅ **Criar** novo carro com validação
- ✅ **Atualizar** informações do carro
- ✅ **Deletar** carro do inventário

### Gerenciamento de Fabricantes
- ✅ **Listar** fabricantes disponíveis
- ✅ **Criar** novo fabricante
- ✅ **Atualizar** fabricante
- ✅ **Deletar** fabricante

### Funcionalidades Técnicas
- ✅ **API RESTful** completa com Minimal APIs
- ✅ **Documentação Swagger** automática
- ✅ **CORS** configurado para desenvolvimento
- ✅ **Validação** de dados em tempo real
- ✅ **Cache** com Pinia (persistedstate)
- ✅ **Migrations** automáticas no startup
- ✅ **Tratamento** de erros estruturado

---

## 🔌 API Endpoints

### Carros

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| `GET` | `/api/carros` | Listar todos os carros |
| `GET` | `/api/carros/{id}` | Obter carro por ID |
| `POST` | `/api/carros` | Criar novo carro |
| `PATCH` | `/api/carros` | Atualizar carro |
| `DELETE` | `/api/carros/{id}` | Deletar carro |

### Fabricantes

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| `GET` | `/api/fabricantes` | Listar todos os fabricantes |
| `POST` | `/api/fabricantes` | Criar novo fabricante |
| `DELETE` | `/api/fabricantes/{id}` | Deletar fabricante |

### Exemplo de Payload - Criar Carro

```json
{
  "modelo": "Gol",
  "cor": "Preto",
  "ano": 2024,
  "fabricanteId": 1
}
```

### Acessar Swagger

Com a aplicação rodando, acesse: `http://localhost:5001/swagger`

---

## 🗄️ Banco de Dados

### Entidades

#### Carro
```csharp
public class Carro
{
    public int Id { get; set; }
    public int FabricanteId { get; set; }  // Foreign Key
    public string? Modelo { get; set; }
    public string? Cor { get; set; }
    public int Ano { get; set; }
}
```

#### Fabricante
```csharp
public class Fabricante
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
```

### Dados Iniciais

O banco é seed com os seguintes fabricantes:
- Volkswagen
- General Motors
- FIAT
- Toyota
- BYD

---

## 📖 Como Usar

### 1. Acessar a Aplicação

Abra no navegador: `http://localhost:5173`

### 2. Interface do Usuário

- **Menu**: Navegue entre as seções
- **Listar Carros**: Visualize todos os carros cadastrados
- **Formulário**: Preencha para cadastrar novo carro
- **Ações**: Clique em editar ou deletar na lista

### 3. Exemplo de Fluxo

1. Acesse a tela de carros
2. Clique em "Novo Carro"
3. Preencha os campos:
   - Modelo: "Gol"
   - Cor: "Vermelho"
   - Ano: 2024
   - Fabricante: Selecione "Volkswagen"
4. Clique em "Salvar"
5. Veja o carro listado

---

## 🔧 Desenvolvimento

### Backend

#### Executar com Watch Mode

```bash
cd projetoApiWeb
dotnet watch run
```

#### Executar Testes (se existirem)

```bash
dotnet test
```

#### Criar Nova Migration

```bash
dotnet ef migrations add NomeDaMigracao
dotnet ef database update
```

### Frontend

#### Dev Server com Hot Reload

```bash
cd view
npm run dev
```

#### Build para Produção

```bash
npm run build
```

#### Preview da Build

```bash
npm run preview
```

#### Type Checking

```bash
npm run type-check
```

### Variáveis de Ambiente

#### Backend - `appsettings.Development.json`
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=CrudCarrosDb;..."
  },
  "ApiSettings": {
    "EndpointCarro": "/api/carros",
    "EndpointFabricante": "/api/fabricantes"
  }
}
```

#### Frontend - `.config/api.config.ts`
```typescript
export const API_BASE_URL = 'http://localhost:5001';
export const API_TIMEOUT = 5000;
```

---

## 🏗️ Build e Produção

### Build Backend

```bash
cd projetoApiWeb
dotnet publish -c Release -o ./publish
```

Outputs em: `projetoApiWeb/bin/Release/net10.0/publish/`

### Build Frontend

```bash
cd view
npm run build
```

Outputs em: `view/dist/`

### Deploy

#### Backend no Azure App Service
```bash
cd projetoApiWeb
dotnet publish -c Release
# Zipar e fazer upload
```

#### Frontend como Static Web App
```bash
# Copiar conteúdo de view/dist para servidor estático
# ou usar Azure Static Web Apps
```

---

## 📝 Documentação

### Swagger/OpenAPI

Ao rodar o backend em desenvolvimento, a documentação interativa está em:

```
http://localhost:5001/swagger
```

**Recursos:**
- Explore todos os endpoints
- Teste requisições direto do Swagger
- Veja schema dos requests/responses

### Estrutura de Resposta

Todas as respostas seguem este padrão:

```json
{
  "success": true,
  "data": { },
  "message": "Operação realizada com sucesso",
  "statusCode": 200
}
```

---

## 🐛 Troubleshooting

### Erro de Conexão com Banco de Dados

```
InvalidOperationException: Variável não encontrada
```

**Solução**: Verifique `appsettings.Development.json` e a connection string do SQL Server.

### CORS Error no Frontend

```
Access to XMLHttpRequest blocked by CORS policy
```

**Solução**: Verifique `DbCorsPolitic.cs` e confirme que a origem do frontend está autorizada.

### Port já em uso

```
error: Address already in use
```

**Solução**:
- Backend: Altere porta em `Properties/launchSettings.json`
- Frontend: `npm run dev -- --port 5174`

### Node/NPM Issues

```bash
# Limpar cache
npm cache clean --force

# Reinstalar dependências
rm -r node_modules
npm install
```

---

## 🤝 Contribuindo

Contribuições são bem-vindas! Para contribuir:

1. **Fork** o repositório
2. **Crie** uma branch para sua feature (`git checkout -b feature/MinhaFeature`)
3. **Commit** suas mudanças (`git commit -m 'Adiciona MinhaFeature'`)
4. **Push** para a branch (`git push origin feature/MinhaFeature`)
5. **Abra** um Pull Request

### Padrões de Código

- **C#**: Siga [Microsoft C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- **TypeScript/Vue**: Use ESLint e Prettier
- **Commits**: Use mensagens descritivas em português

---

## 📄 Licença

Este projeto está sob a licença **ISC**. Veja o arquivo LICENSE para mais detalhes.

---

## 📧 Contato e Suporte

Para dúvidas ou sugestões:
- Abra uma **Issue** no GitHub
- Envie um email para o autor
- Consulte a documentação do Swagger

---

## 🔗 Links Úteis

- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
- [Vue 3 Guide](https://vuejs.org/)
- [TypeScript Handbook](https://www.typescriptlang.org/docs)
- [Vite Documentation](https://vitejs.dev/)
- [NSwag Documentation](https://github.com/RicoSuter/NSwag)

---

## 📊 Status do Projeto

- ✅ MVP Completo
- ✅ API Funcional
- ✅ Interface Básica
- 🔄 Melhorias em Progresso

---

**Última Atualização**: Fevereiro de 2026

**Versão**: 1.0.0 
