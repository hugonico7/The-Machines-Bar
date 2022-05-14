using ApiRest.DTO;
using ApiRest.Entities;
using ApiRest.Service;
using AutoMapper;

namespace ApiRest.Controller;
using Microsoft.AspNetCore.Mvc;

[Route("producto")]
[ApiController]
public class ProductoController : Controller
{
    private readonly ProductoService _productoService;
    private readonly IMapper _mapper;

    public ProductoController(ProductoService productoService, IMapper mapper)
    {
        _mapper = mapper;
        _productoService = productoService;
    }
    
    [HttpGet]
    public async Task<IList<ProductoDTO>> GetAll() 
    {
        var productos = await _productoService.FindAll();

        return productos.Select(p => _mapper.Map<ProductoDTO>(p)).ToList();
    }
    
    [HttpGet("{id}")]
    public async Task<ProductoDTO?> Get(int id)
    {
        var producto = await _productoService.FindById(id); 
        return producto is null ? null : _mapper.Map<ProductoDTO>(producto);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(ProductoDTO productoDto) 
    {
        try
        {
            var producto = _mapper.Map<Producto>(productoDto);
            await _productoService.Save(producto);
            return Ok("Producto Creado");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpPut("{id}")] 
    public async Task<IActionResult?> Update(long id, ProductoDTO productoDto)
    {
        try
        {
            var producto = _mapper.Map<Producto>(productoDto); 
            if (id != producto.Id) 
            { 
                return null;
            }

            await _productoService.Update(producto);
            return Ok("Producto Actualizado");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpDelete("{id}")] 
    public async Task<bool> Delete(int id) 
    { 
        var deleted = await _productoService.DeleteById(id); 
        return deleted;
    }
}