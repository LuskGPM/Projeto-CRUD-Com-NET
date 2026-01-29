using DbServices.service;
using projetoApiWeb.src.Models;
using Tables.Models;
using TablesDto.Models;

namespace projetoApiWeb.src.Controller;

public static class CarroEndpoints
{
    public static async Task MapCarrosEndpoints(this WebApplication app)
    {
        string endpointCarros = app.Configuration["ApiSettings:EndpointCarro"] ??
            throw new InvalidOperationException("Varíavel de ambiente não encontrada");

        var carrosMap = app.MapGroup(endpointCarros).WithTags("Carros");

        carrosMap.MapGet("/", GetAllCarros);
        carrosMap.MapGet("/{Id}", GetCarrosById);
        carrosMap.MapPost("/", CreateCarros);
        carrosMap.MapDelete("/{Id}", );
    }

    private static async Task<IResult> GetAllCarros(CarrosServices service) => await service.GetAllAsync();
    private static async Task<IResult> GetCarrosById(int Id, CarrosServices service) => await service.GetByIdAsync(Id);
    private static async Task<IResult> CreateCarros(CarroItemDto carro, CarrosServices service)
    {
        var newCarro = new Carro
        {
            Ano = carro.Ano,
            Cor = carro.Cor,
            FabricanteId = carro.FabricanteId,
            Id = carro.Id,
            Modelo = carro.Modelo
        };
        return await service.CreateAsync(newCarro);
    }
    private static async Task<IResult> DeleteCarroById(int Id, CarrosServices service) => await service.DeleteAsync(Id);
}