namespace ApiRest.DTO;

public class PedidoDTO
{
    public int Id { get; set; }
    public DateTime? Fecha { get; set; }
    public decimal PrecioTotal { get; set; }
    public string? Estado { get; set; }
    public int IdMesa { get; set; }
    public virtual MesaCreationDTO IdMesaNavigation { get; set; } = null!;
    public virtual ICollection<ComandaCreationDTO> Comanda { get; set; }
}