using ApiRest.Context;
using ApiRest.Entities;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

namespace ApiRest.Repository;

public class UsuarioRepository : MasterRepoImpl<Usuario,MyDbContext>

{
    public UsuarioRepository(MyDbContext context) : base(context)
    {
        
    }    
}