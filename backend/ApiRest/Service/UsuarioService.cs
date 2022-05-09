using ApiRest.Entities;
using ApiRest.Repository;

namespace ApiRest.Service;

public class UsuarioService
{
    UsuarioRepository UserRepository;

    public UsuarioService(UsuarioRepository userRepository)
    {
        UserRepository = userRepository;
    }

    public bool DeleteById(int id)
    {
        UserRepository.Delete(id);
        return true;
    }

    public IList<Usuario> FindAll()
    {
        return UserRepository.GetAll().Result;
    }

    public Usuario? FindById(int id)
    {
        return UserRepository.GetById(id).Result;
    }

    public Usuario Save(Usuario usuario)
    {
        Usuario usuarioUp = UserRepository.Add(usuario).Result;
        return usuarioUp;
    }

    public Usuario Update(Usuario usuario)
    {
        Usuario usuarioUp = UserRepository.Update(usuario).Result;
        return usuarioUp;
    }
}