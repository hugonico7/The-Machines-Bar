using ApiRest.DTO;
using ApiRest.Entities;

namespace ApiRest.Controller;

using ApiRest.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[Route("pedido")]
[ApiController]
public class PedidoController : Controller
{
    private readonly PedidoService _pedidoService;
    private readonly IMapper _mapper;

    public PedidoController(PedidoService pedidoService, IMapper mapper)
    {
        _mapper = mapper;
        _pedidoService = pedidoService;
    }
    
    [HttpGet]
    public async Task<IList<PedidoDTO>> GetAll() 
    {
        var pedidos = await _pedidoService.FindAll();

        return pedidos.Select(p => _mapper.Map<PedidoDTO>(p)).ToList();
    }
    
    [HttpGet("{id}")]
    public async Task<PedidoDTO?> Get(int id)
    {
        var pedido = await _pedidoService.FindById(id); 
        return pedido is null ? null : _mapper.Map<PedidoDTO>(pedido);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(PedidoDTO pedidoDto) 
    {
        try
        {
            var pedido = _mapper.Map<Pedido>(pedidoDto);
            await _pedidoService.Save(pedido);
            return Ok("Pedido Creado");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpPut("{id}")] 
    public async Task<IActionResult?> Update(long id, PedidoDTO pedidoDto)
    {
        try
        {
            var pedido = _mapper.Map<Pedido>(pedidoDto); 
            if (id != pedido.Id) 
            { 
                return null;
            }

            await _pedidoService.Update(pedido);
            return Ok("Pedido Actualizado");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpDelete("{id}")] 
    public async Task<bool> Delete(int id) 
    { 
        var deleted = await _pedidoService.DeleteById(id); 
        return deleted;
    }
    

}