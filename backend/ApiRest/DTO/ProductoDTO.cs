namespace ApiRest.DTO;

public class ProductoDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public decimal Precio { get; set; }
    public int IdCat { get; set; }
    public virtual CategoriaCreationDTO IdCatNavigation { get; set; }
    public virtual ICollection<ComandaInProductoDTO> Comanda { get; set; }
}