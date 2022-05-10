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

    public async Task<bool> DeleteById(int id)
    {
        try
        {
            await _cocineroRepository.Delete(id);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<IList<Cocinero>> FindAll()
    {
        return await _cocineroRepository.GetAll();
    }

    public async Task<Cocinero?> FindById(int id)
    {
        return await _cocineroRepository.GetById(id);
    }

    public async Task<Cocinero> Save(Cocinero cocinero)
    {
        return await _cocineroRepository.Add(cocinero);
    }

    public async Task<Cocinero> Update(Cocinero cocinero)
    {
        return await _cocineroRepository.Update(cocinero);
    }
}