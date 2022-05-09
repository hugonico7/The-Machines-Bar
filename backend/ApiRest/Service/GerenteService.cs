using ApiRest.Entities;
using ApiRest.Repository;

namespace ApiRest.Service;

public class GerenteService
{
    private readonly GerenteRepository _gerenteRepository;

    public GerenteService(GerenteRepository gerenteRepository)
    {
        _gerenteRepository = gerenteRepository;
    }

    public bool DeleteById(int id)
    {
        _gerenteRepository.Delete(id);
        return true;
    }

    public IList<Gerente> FindAll()
    {
        return _gerenteRepository.GetAll().Result;
    }

    public Gerente? FindById(int id)
    {
        return _gerenteRepository.GetById(id).Result;
    }

    public Gerente Save(Gerente gerente)
    {
        Gerente gerenteUp = _gerenteRepository.Add(gerente).Result;
        return gerenteUp;
    }

    public Gerente Update(Gerente gerente)
    {
        Gerente gerenteUp = _gerenteRepository.Update(gerente).Result;
        return gerenteUp;
    }
}