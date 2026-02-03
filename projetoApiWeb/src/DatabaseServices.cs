using Database.service;
using BaseService.Service;
using Tables.Models;

namespace DbServices.service;

public class FabricanteServices(DatabaseContext db) : BaseService<Fabricante>(db)
{
    private DatabaseContext Db => _db;
    public override async Task<IResult> CreateAsync(Fabricante entity)
    {
        await Db.Fabricantes.AddAsync(entity);

        await Db.SaveChangesAsync();
        return TypedResults.Created($"{entity.Id}", entity);
    }

    public override async Task<IResult> DeleteAsync(int Id)
    {
        var entity = await Db.Fabricantes.FindAsync(Id);
        if (entity is null) return TypedResults.NotFound();

        Db.Remove(entity);

        await Db.SaveChangesAsync();
        return TypedResults.NoContent();
    }
}

public class CarrosServices(DatabaseContext db) : BaseService<Carro>(db)
{
    private DatabaseContext Db => _db;
    public override async Task<IResult> CreateAsync(Carro entity)
    {
        var newEntity = new Carro
        {
            Ano = entity.Ano,
            Cor = entity.Cor,
            FabricanteId = entity.FabricanteId,
            Modelo = entity.Modelo
        };

        await Db.Carros.AddAsync(newEntity);

        await Db.SaveChangesAsync();
        return TypedResults.Created($"{newEntity.Id}", newEntity);
    }
    public override async Task<IResult> DeleteAsync(int Id)
    {
        var entity = await Db.Carros.FindAsync(Id);
        if (entity is null) return TypedResults.NotFound();

        Db.Remove(entity);

        await Db.SaveChangesAsync();
        return TypedResults.NoContent();
    }
    public override async Task<IResult> UpdateAsync(Carro entity)
    {
        var entityToUpdate = await Db.Carros.FindAsync(entity.Id);
        if (entityToUpdate is null) return TypedResults.NotFound();

        Db.Carros.Entry(entityToUpdate).CurrentValues.SetValues(entity);

        await Db.SaveChangesAsync();
        return TypedResults.Ok(entity);
    }
}