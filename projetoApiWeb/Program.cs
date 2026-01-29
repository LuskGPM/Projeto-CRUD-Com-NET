using Microsoft.EntityFrameworkCore;
using Database.service;
using DbServices.service;
using projetoApiWeb.src.Controller;
using projetoApiWeb.src.extension;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Variável não encontrada");

// Builder services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(conf =>
{
    conf.DocumentName = "API CRUD Loja de Carros";
    conf.Title = "CRUDApi Loja de Carros";
    conf.Version = "V1";
});
builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddScoped<CarrosServices>();
builder.Services.AddScoped<FabricanteServices>();
builder.ApplyCorsPolitic();

// AppMap
var app = builder.Build();
// Swagger if app is development Mode
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(conf =>
    {
        conf.DocumentTitle = "CrudApi Loja de carros";
        conf.Path = "/swagger";
        conf.DocumentPath = "/swagger/{documentName}/swagger.json";
        conf.DocExpansion = "list";
    });
}

app.MapGet("/", () => "Hello World!");

// Register Endpoints
app.UseCors("MinhaAppVue");
app.MapCarrosEndpoints();
app.MapFabricantesEndpoints();

// Migration
app.ApplyMigration();

app.Run();
