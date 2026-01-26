using Microsoft.EntityFrameworkCore;
using Tables.Table;

namespace Database.Db;
public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Carro> Carros { get; set; }
    public DbSet<Fabricante> Fabricantes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Fabricante>().HasData(
            new Fabricante {Id = 1, Name = "Volkswagen"},
            new Fabricante {Id = 2, Name = "General Motors"},
            new Fabricante {Id = 3, Name = "FIAT"},
            new Fabricante {Id = 4, Name = "Toyota"},
            new Fabricante {Id = 5, Name = "BYD"}
        );
    }
}