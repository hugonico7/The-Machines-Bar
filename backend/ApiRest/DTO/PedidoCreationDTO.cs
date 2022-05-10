namespace ApiRest.DTO;

public class PedidoCreationDTO
{
    public int Id { get; set; }
    public DateTime? Fecha { get; set; }
    public decimal PrecioTotal { get; set; }
    public string? Estado { get; set; }
    public int IdMesa { get; set; }
}