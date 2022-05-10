using ApiRest.Entities;

namespace ApiRest.DTO;

public class CategoriaDTO
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public ICollection<ProductoInCategoriaDTO>? Productos { get; set; }

}