using ApiRest.DTO;
using ApiRest.Entities;
using ApiRest.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controller;

[Route("Camarero")]
[ApiController]
public class CamareroController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly CamareroService _camareroService;
    private readonly IMapper _mapper;
            
    public CamareroController(CamareroService camareroService, IMapper mapper) 
    { 
        _camareroService = camareroService; 
        _mapper = mapper;
    }
            
    [HttpGet]
    public async Task<IList<CamareroDTO>> GetAll() 
    { 
        IList<CamareroDTO> camareroList = new List<CamareroDTO>(); 
        var camareros = await _camareroService.FindAll(); 
        foreach (Camarero c in camareros) 
        { 
            camareroList.Add(_mapper.Map<CamareroDTO>(c));
        } 
        return camareroList;
    }
    
    [HttpGet("{id}")]
    public async Task<CamareroDTO> Get(int id)
    {
        var camarero =  await _camareroService.FindById(id); 
        if (camarero is null) 
        { 
            return null;
        } 
        return _mapper.Map<CamareroDTO>(camarero);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CamareroDTO camareroDto) 
    {
        try
        {
            Camarero camarero = _mapper.Map<Camarero>(camareroDto); 
            await _camareroService.Save(camarero);
            return Ok("Camarero creado correctamente");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpPut("{id}")] 
    public async Task<IActionResult> Update(int id, CamareroDTO camareroDto)
    {
        try
        {
            var camarero = _mapper.Map<Camarero>(camareroDto); 
            if (id != camarero.Id) 
            { 
                return null;
            } 
            await _camareroService.Update(camarero);
            return Ok("Camarero actualizado");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
            
    [HttpDelete("{id}")] 
    public async Task<IActionResult> Delete(int id) 
    { 
        bool deleted = await _camareroService.DeleteById(id);
        if (deleted)
        {
            return Ok("Camarero borrado");
        }
        else
        {
            return BadRequest("Camarero no borrado");
        }
    }
}