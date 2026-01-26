using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Database.Db;
using DbServices.Services;
using TablesDto.Table;
using Tables.Table;

// Enviroments
Env.Load();
string db_connection_string = Environment.GetEnvironmentVariable("DATABASE_STRING_CONNECTION") ?? throw new InvalidOperationException("Varíavel de ambiente não encontrada!");
string endpoit_carros = Environment.GetEnvironmentVariable("ENDPOIN_API_Carros") ?? "/carros";
string endpoit_fabricantes = Environment.GetEnvironmentVariable("ENDPOIN_API_Fabricantes") ?? "/fabricantes";

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("lojaDeCarros") ?? db_connection_string;

// Builder services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(conf =>
{
    conf.DocumentName = "API CRUD Loja de Carros";
    conf.Title = "CRUDApi Loja de Carros";
    conf.Version = "V1";
});
builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseMySQL(connectionString));
builder.Services.AddScoped<CarrosServices>();
builder.Services.AddScoped<FabricanteServices>();

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

// CarrosMap
var carrosMap = app.MapGroup(endpoit_carros).WithTags("Carros");
// GETS
carrosMap.MapGet("/", async (CarrosServices services) => await services.GetAllAsync());
carrosMap.MapGet("/{Id}", async (CarrosServices services, int Id) => await services.GetByIdAsync(Id));
// POST
carrosMap.MapPost("/", async (CarrosServices services, CarroItemDto carro) =>
{
    var newCarro = new Carro
    {
        Ano = carro.Ano,
        Cor = carro.Cor,
        FabricanteId = carro.FabricanteId,
        Id = carro.Id,
        Modelo = carro.Modelo
    };
    return await services.CreateAsync(newCarro);
});
// UPDATE
carrosMap.MapPatch("/", async (CarrosServices services, CarroItemDto carro) =>
{
    var newCarro = new Carro
    {
        Ano = carro.Ano,
        Cor = carro.Cor,
        FabricanteId = carro.FabricanteId,
        Id = carro.Id,
        Modelo = carro.Modelo
    };
    return await services.UpdateAsync(newCarro);
});
// DELETE
carrosMap.MapDelete("/{Id}", async (CarrosServices services, int Id) => await services.DeleteAsync(Id));

// FabricanteMap
var fabricanteMap = app.MapGroup(endpoit_fabricantes).WithTags("Fabricantes");
// GET
fabricanteMap.MapGet("/", async (FabricanteServices services) => await services.GetAllAsync());
// POST
fabricanteMap.MapPost("/", async (FabricanteServices services, FabricanteItemDto fabricante) =>
{
    var newFabricante = new Fabricante
    {
        Id = fabricante.Id,
        Name = fabricante.Name
    };
    return await services.CreateAsync(newFabricante);
});
// DELETE
fabricanteMap.MapDelete("/{Id}", async (FabricanteServices services, int Id) => await services.DeleteAsync(Id));

app.Run();
