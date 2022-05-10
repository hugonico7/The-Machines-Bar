using ApiRest.Context;
using ApiRest.Entities;

namespace ApiRest.Repository;

public class ComandaRepository : MasterRepoImpl<Comanda,MyDbContext>
{
    public ComandaRepository(MyDbContext context) : base(context)
    {
    }
}