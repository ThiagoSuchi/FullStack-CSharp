# FutApi

Um projeto educacional desenvolvido para aprender **C#** e **ASP.NET Core**, com foco em boas práticas de desenvolvimento backend.

## Objetivo do Projeto

Este projeto foi criado com o propósito de ser um **exemplo didático** para quem deseja aprender:
- Fundamentos de **C#** e orientação a objetos
- Desenvolvimento de **APIs REST** com ASP.NET Core
- Integração com **banco de dados SQLite**
- Padrões de arquitetura e boas práticas
- Versionamento com Git e GitHub

## Tecnologias Utilizadas

- **Linguagem**: C# 12
- **Framework**: ASP.NET Core 8.0
- **Banco de Dados**: SQLite (escolhido por ser leve e ideal para aprendizado)
- **Ferramentas**: dotnet CLI, Visual Studio Code

## Pré-requisitos

Antes de começar, certifique-se de ter instalado:
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) ou superior
- [Git](https://git-scm.com/)
- Um editor de código (VS Code, Visual Studio, etc.)

## Como Executar o Projeto

1. **Clone o repositório**:
   ```bash
   git clone https://github.com/ThiagoSuchi/FullStack-CSharp.git
   cd FutApi
   ```

2. **Restaure as dependências**:
   ```bash
   dotnet restore
   ```

3. **Execute o projeto**:
   ```bash
   dotnet run
   ```

4. **Acesse a aplicação**:
   - Por padrão, a aplicação rodará em `https://localhost:5001`
   - Teste o endpoint GET em `https://localhost:5001/`

## Estrutura do Projeto

```
FutApi/
├── Program.cs              # Configuração principal da aplicação
├── appsettings.json        # Configurações da aplicação
├── appsettings.Development.json  # Configurações de desenvolvimento
├── FutApi.csproj           # Arquivo de projeto (dependências)
├── FutApi.sln              # Solução do projeto
├── .gitignore              # Arquivo para ignorar arquivos no Git
└── Properties/
    └── launchSettings.json # Configurações de inicialização
```

## Conceitos Importantes para Aprender

### 1. **Program.cs** - Ponto de Entrada
O arquivo `Program.cs` é o coração da aplicação ASP.NET Core. Aqui você:
- Cria o builder da aplicação
- Configura serviços (dependency injection)
- Define os middlewares
- Mapeia os endpoints

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
```

### 2. **Endpoints REST**
Um endpoint é uma rota da sua API que responde a requisições HTTP. Exemplo:

```csharp
// GET: /api/usuarios
app.MapGet("/api/usuarios", () => new { mensagem = "Lista de usuários" });

// POST: /api/usuarios
app.MapPost("/api/usuarios", (Usuario usuario) => usuario);
```

### 3. **Banco de Dados SQLite**
O SQLite é um banco de dados leve, armazenado em um arquivo local. Perfeito para aprendizado!

Para adicionar suporte a SQLite, você precisará:
```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

## 🎯 Próximas Etapas - Expandindo o Projeto

Aqui estão algumas funcionalidades que você pode implementar para aprender mais:

1. **Modelos (Models)**
   ```csharp
   public class Usuario
   {
       public int Id { get; set; }
       public string Nome { get; set; }
       public string Email { get; set; }
   }
   ```

2. **Banco de Dados com Entity Framework Core**
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore
   ```

3. **Controller ou Minimal APIs**
   ```csharp
   app.MapGet("/api/usuarios/{id}", (int id) => $"Usuário {id}");
   ```

4. **Validação de Dados**
   ```csharp
   if (string.IsNullOrEmpty(usuario.Nome))
       return Results.BadRequest("Nome é obrigatório");
   ```

5. **Tratamento de Erros**
   ```csharp
   try 
   { 
       // lógica
   } 
   catch (Exception ex) 
   { 
       return Results.InternalServerError();
   }
   ```

## Recursos de Aprendizado

- [Documentação oficial do ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/)
- [Documentação de C#](https://learn.microsoft.com/en-us/dotnet/csharp/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/)
- [REST API Best Practices](https://restfulapi.net/)

## Comandos Úteis

```bash
# Criar um novo projeto
dotnet new webapi -n NomeProjeto

# Adicionar um pacote NuGet
dotnet add package NomePacote

# Compilar o projeto
dotnet build

# Rodar testes
dotnet test

# Publicar para produção
dotnet publish -c Release

# Criar um .gitignore para .NET
dotnet new gitignore
```

## Padrões de Código

### Nomenclatura em C#
- **Classes**: PascalCase → `public class Usuario { }`
- **Métodos**: PascalCase → `public void CriarUsuario() { }`
- **Variáveis**: camelCase → `string nomeUsuario = "João";`
- **Constantes**: UPPER_SNAKE_CASE → `const string API_KEY = "...";`

### Estrutura de um Método
```csharp
public class ServicoUsuario
{
    public Usuario ObterPorId(int id)
    {
        // Validação
        if (id <= 0)
            throw new ArgumentException("ID deve ser maior que zero");
        
        // Lógica
        return new Usuario { Id = id, Nome = "João" };
    }
}
```

## Contribuindo

Este é um projeto educacional! Sinta-se livre para:
- Fazer melhorias
- Adicionar novos recursos
- Criar issues com sugestões
- Fazer pull requests

## Licença

Este projeto é de código aberto e disponível sob a licença MIT.

---

**Desenvolvido para fins educacionais**

Para dúvidas ou sugestões, entre em contato ou abra uma issue no repositório!
