using Tables.Table;

namespace TablesDto.Table;

public class CarroItemDto
{
    public int Id { get; set; }
    public int FabricanteId { get; set; }
    public string? Modelo { get; set; }
    public string? Cor { get; set; }
    public int Ano { get; set; }
    public CarroItemDto() { }
    public CarroItemDto(Carro carroItem)
    {
        Id = carroItem.Id;
        FabricanteId = carroItem.FabricanteId;
        Modelo = carroItem.Modelo;
        Cor = carroItem.Cor;
        Ano = carroItem.Ano;
    }
}

public class FabricanteItemDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public FabricanteItemDto() { }
    public FabricanteItemDto(Fabricante itemFabricante)
    {
        Id = itemFabricante.Id;
        Name = itemFabricante.Name;
    }
}