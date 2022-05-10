namespace ApiRest.DTO;

public class MesaDTO
{
    public int Id { get; set; }
    public string Estado { get; set; } = null!;
    public virtual ICollection<PedidoCreationDTO> Pedidos { get; set; }
    public virtual ICollection<ReservaCreationDTO> IdReservas { get; set; }
}