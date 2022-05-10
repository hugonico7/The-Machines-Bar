using ApiRest.Entities;
using ApiRest.Repository;

namespace ApiRest.Service;

public class ComandaService
{
    private readonly ComandaRepository _comandaRepository;

    public ComandaService(ComandaRepository comandaRepository)
    {
        _comandaRepository = comandaRepository;
    }
    public async Task<bool> DeleteById(int id)
    {
        try
        {
            await _comandaRepository.Delete(id);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<IList<Comanda>> FindAll()
    {
        return await _comandaRepository.GetAll();
    }

    public async Task<Comanda?> FindById(int id)
    {
        return await _comandaRepository.GetById(id);
    }

    public async Task<Comanda> Save(Comanda comanda)
    {
        var comandaUp = await _comandaRepository.Add(comanda);
        return comandaUp;
    }

    public async Task<Comanda> Update(Comanda comanda)
    {
        var comandaUp = await _comandaRepository.Update(comanda);
        return comandaUp;
    }
}