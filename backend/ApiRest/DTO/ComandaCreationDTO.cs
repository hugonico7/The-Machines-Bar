namespace ApiRest.DTO;

public class ComandaCreationDTO
{
    public int Id { get; set; }
    public int IdCamarero { get; set; }
    public int? IdCocinero { get; set; }
    public int IdProducto { get; set; }
    public int IdPedido { get; set; }
    public string? Descripcion { get; set; }
    public string? Estado { get; set; }
}