using ApiRest.Context;
using ApiRest.Entities;

namespace ApiRest.Repository;

public class PedidoRepository : MasterRepoImpl<Pedido,MyDbContext>
{
    public PedidoRepository(MyDbContext context) : base(context)
    {
    }
}