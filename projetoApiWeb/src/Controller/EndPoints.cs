using DbServices.service;
using Tables.Models;
using TablesDto.Models;

namespace projetoApiWeb.src.Controller;

public static class CarrosEndpoints
{
    public static void MapCarrosEndpoints(this WebApplication app)
    {
        string endpointCarros = app.Configuration["ApiSettings:EndpointCarro"] ??
            throw new InvalidOperationException("Varíavel de ambiente não encontrada");

        var carrosMap = app.MapGroup(endpointCarros).WithTags("Carros");

        carrosMap.MapGet("/", GetAllCarros);
        carrosMap.MapGet("/{Id}", GetCarroById);
        carrosMap.MapPost("/", CreateCarro);
        carrosMap.MapDelete("/{Id}", DeleteCarroById);
        carrosMap.MapPatch("/", UpdateCarro);
    }

    private static async Task<IResult> GetAllCarros(CarrosServices service) => await service.GetAllAsync();
    private static async Task<IResult> GetCarroById(int Id, CarrosServices service) => await service.GetByIdAsync(Id);
    private static async Task<IResult> DeleteCarroById(int Id, CarrosServices service) => await service.DeleteAsync(Id);
    private static async Task<IResult> CreateCarro(CarroItemDto carro, CarrosServices service)
    {
        var newCarro = new Carro
        {
            Ano = carro.Ano,
            Cor = carro.Cor,
            FabricanteId = carro.FabricanteId,
            Modelo = carro.Modelo
        };
        return await service.CreateAsync(newCarro);
    }
    private static async Task<IResult> UpdateCarro(CarroItemDto carro, CarrosServices service)
    {
        var newCarro = new Carro
        {
            Ano = carro.Ano,
            Cor = carro.Cor,
            FabricanteId = carro.FabricanteId,
            Id = carro.Id,
            Modelo = carro.Modelo
        };
        return await service.UpdateAsync(newCarro);
    }
}

public static class FabricantesEndpoints
{
    public static void MapFabricantesEndpoints(this WebApplication app)
    {
        string endpointFabricantes = app.Configuration["ApiSettings:EndpointFabricante"] ??
            throw new InvalidOperationException("Varíavel de ambiente não encontrada");

        var carrosMap = app.MapGroup(endpointFabricantes).WithTags("Fabricantes");

        carrosMap.MapGet("/", GetAllFabricantes);
        carrosMap.MapPost("/", CreateFabricante);
        carrosMap.MapDelete("/{Id}", DeleteFabricanteById);
    }

    private static async Task<IResult> GetAllFabricantes(FabricanteServices service) => await service.GetAllAsync();
    private static async Task<IResult> DeleteFabricanteById(int Id, FabricanteServices service) => await service.DeleteAsync(Id);
    private static async Task<IResult> CreateFabricante(FabricanteItemDto fabricante, FabricanteServices service)
    {
        var newFabricante = new Fabricante
        {
            Id = fabricante.Id,
            Name = fabricante.Name
        };
        return await service.CreateAsync(newFabricante);
    }
}