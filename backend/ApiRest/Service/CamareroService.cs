using ApiRest.Entities;
using ApiRest.Repository;

namespace ApiRest.Service;

public class CamareroService
{
    private readonly CamareroRepository _camareroRepository;

    public CamareroService(CamareroRepository camareroRepository)
    {
        _camareroRepository = camareroRepository;
    }

    public bool DeleteById(int id)
    {
        _camareroRepository.Delete(id);
        return true;
    }

    public IList<Camarero> FindAll()
    {
        return _camareroRepository.GetAll().Result;
    }

    public Camarero? FindById(int id)
    {
        return _camareroRepository.GetById(id).Result;
    }

    public Camarero Save(Camarero camarero)
    {
        Camarero camareroUp = _camareroRepository.Add(camarero).Result;
        return camareroUp;
    }

    public Camarero Update(Camarero camarero)
    {
        Camarero camareroUp = _camareroRepository.Update(camarero).Result;
        return camareroUp;
    }
}