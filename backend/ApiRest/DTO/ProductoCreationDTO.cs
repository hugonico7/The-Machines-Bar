namespace ApiRest.DTO;

public class ProductoCreationDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public decimal Precio { get; set; }
    public int IdCat { get; set; }
}