using System.ComponentModel.DataAnnotations.Schema;

namespace Tables.Models;

public class Carro
{
    public int Id { get; set; }
    [ForeignKey("Fabricante")]
    public int FabricanteId { get; set; }
    public string? Modelo { get; set; }
    public string? Cor { get; set; }
    public int Ano { get; set; }
}

public class Fabricante
{
    public int Id { get; set; }
    public string? Name { get; set; }
};