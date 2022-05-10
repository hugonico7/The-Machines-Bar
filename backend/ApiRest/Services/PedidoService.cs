using ApiRest.Entities;
using ApiRest.Repository;

namespace ApiRest.Service;

public class PedidoService
{
    private readonly PedidoRepository _pedidoRepository;

    public PedidoService(PedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }
    public async Task<bool> DeleteById(int id)
    {
        try
        {
            await _pedidoRepository.Delete(id);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<IList<Pedido>> FindAll()
    {
        return await _pedidoRepository.GetAll();
    }

    public async Task<Pedido?> FindById(int id)
    {
        return await _pedidoRepository.GetById(id);
    }

    public async Task<Pedido> Save(Pedido pedido)
    {
        var pedidoUp = await _pedidoRepository.Add(pedido);
        return pedidoUp;
    }

    public async Task<Pedido> Update(Pedido pedido)
    {
        var pedidoUp = await _pedidoRepository.Update(pedido);
        return pedidoUp;
    }
}