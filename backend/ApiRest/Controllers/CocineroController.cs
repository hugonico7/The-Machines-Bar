using ApiRest.DTO;
using ApiRest.Entities;
using ApiRest.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controller;

[Route("Cocinero")]
[ApiController]
public class CocineroController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly CocineroService _cocineroService;
    private readonly IMapper _mapper;
            
    public CocineroController(CocineroService cocineroService, IMapper mapper) 
    { 
        _cocineroService = cocineroService; 
        _mapper = mapper;
    }
            
    [HttpGet]
    public async Task<List<CocineroDTO>> GetAll() 
    { 
        List<CocineroDTO> cocineroList = new List<CocineroDTO>(); 
        var cocineros = await _cocineroService.FindAll(); 
        foreach (Cocinero c in cocineros) 
        { 
            cocineroList.Add(_mapper.Map<CocineroDTO>(c));
        } 
        return cocineroList;
    }
    
    [HttpGet("{id}")]
    public CocineroDTO Get(int id)
    {
        var cocinero = _cocineroService.FindById(id); 
        if (cocinero is null) 
        { 
            return null;
        } 
        return _mapper.Map<CocineroDTO>(cocinero);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CocineroDTO cocineroDto) 
    {
        try
        {
            Cocinero cocinero = _mapper.Map<Cocinero>(cocineroDto); 
            await _cocineroService.Save(cocinero);
            return Ok("Cocinero creado");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
            
    [HttpPut("{id}")] 
    public async Task<IActionResult> Update(long id, CocineroDTO cocineroDto)
    {
        try
        {
            var cocinero = _mapper.Map<Cocinero>(cocineroDto); 
            if (id != cocinero.Id)
            {
                return BadRequest("No coincide el ID a actualizar con el insertado");
            } 
            await _cocineroService.Update(cocinero);
            return Ok("Cocinero actualizado");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpDelete("{id}")] 
    public async Task<bool> Delete(int id) 
    {
        var deleted = await _cocineroService.DeleteById(id); 
        return deleted;
    }
}