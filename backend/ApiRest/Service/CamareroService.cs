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

    public async Task<bool> DeleteById(int id)
    {
        try
        {
            await _camareroRepository.Delete(id);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
       
          
    }

    public async Task<IList<Camarero>> FindAll()
    {
        return await _camareroRepository.GetAll();
    }

    public async Task<Camarero?> FindById(int id)
    {
        return await _camareroRepository.GetById(id);
    }

    public async Task<Camarero> Save(Camarero camarero)
    {
        Camarero camareroUp = await _camareroRepository.Add(camarero);
        return camareroUp;
    }

    public async Task<Camarero> Update(Camarero camarero)
    {
        Camarero camareroUp = await _camareroRepository.Update(camarero);
        return camareroUp;
    }
}