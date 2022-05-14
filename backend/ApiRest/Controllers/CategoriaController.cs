using ApiRest.DTO;
using ApiRest.Entities;
using ApiRest.Service;
using AutoMapper;

namespace ApiRest.Controller;
using Microsoft.AspNetCore.Mvc;

[Route("categoria")]
[ApiController]
public class CategoriaController : Controller
{
    private readonly CategoriaService _categoriaService;
    private readonly IMapper _mapper;

    public CategoriaController(CategoriaService categoriaService,IMapper imapper)
    {
        _categoriaService = categoriaService;
        _mapper = imapper;
    }
    [HttpGet]
    public async Task<IList<CategoriaDTO>> GetAll() 
    {
        var categorias = await _categoriaService.FindAll();
        return categorias.Select(c => _mapper.Map<CategoriaDTO>(c)).ToList();
    }
    
    [HttpGet("{id}")]
    public async Task<CategoriaDTO?> Get(int id)
    {
        var categoria = await _categoriaService.FindById(id); 
        return categoria is null ? null : _mapper.Map<CategoriaDTO>(categoria);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CategoriaDTO categoriaDto) 
    {
        try
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);
            await _categoriaService.Save(categoria);
            return Ok("Categoria creada");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpPut("{id}")] 
    public async Task<IActionResult?> Update(long id, CategoriaDTO categoriaDto)
    {
        try
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto); 
            if (id != categoria.Id) 
            { 
                return null;
            }

            await _categoriaService.Update(categoria);
            return Ok("Categoria Actualizada");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpDelete("{id}")] 
    public async Task<bool> Delete(int id) 
    { 
        var deleted = await _categoriaService.DeleteById(id); 
        return deleted;
    }

}