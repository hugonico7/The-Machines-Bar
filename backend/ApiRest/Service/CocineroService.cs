using ApiRest.Entities;
using ApiRest.Repository;

namespace ApiRest.Service;

public class CocineroService
{
    private readonly CocineroRepository _cocineroRepository;

    public CocineroService(CocineroRepository cocineroRepository)
    {
        _cocineroRepository = cocineroRepository;
    }

    public bool DeleteById(int id)
    {
        _cocineroRepository.Delete(id);
        return true;
    }

    public IList<Cocinero> FindAll()
    {
        return _cocineroRepository.GetAll().Result;
    }

    public Cocinero? FindById(int id)
    {
        return _cocineroRepository.GetById(id).Result;
    }

    public Cocinero Save(Cocinero cocinero)
    {
        Cocinero cocineroUp = _cocineroRepository.Add(cocinero).Result;
        return cocineroUp;
    }

    public Cocinero Update(Cocinero cocinero)
    {
        Cocinero cocineroUp = _cocineroRepository.Update(cocinero).Result;
        return cocineroUp;
    }
}