namespace ApiRest.DTO;

public class ProductoInCategoriaDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public decimal Precio { get; set; }
}