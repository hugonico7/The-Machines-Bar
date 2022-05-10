using ApiRest.DTO;
using ApiRest.Entities;
using ApiRest.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controller;

[Route("Gerente")]
[ApiController]
public class GerenteController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly GerenteService _gerenteService;
    private readonly IMapper _mapper;
            
    public GerenteController(GerenteService gerenteService, IMapper mapper) 
    { 
        _gerenteService = gerenteService; 
        _mapper = mapper;
    }
            
    [HttpGet]
    public async Task<IList<GerenteDTO>> GetAll() 
    { 
        IList<GerenteDTO> gerenteList = new List<GerenteDTO>(); 
        var gerentes = await _gerenteService.FindAll(); 
        foreach (Gerente g in gerentes) 
        { 
            gerenteList.Add(_mapper.Map<GerenteDTO>(g));
        } 
        return gerenteList;
    }
    
    [HttpGet("{id}")]
    public async Task<GerenteDTO> Get(int id)
    {
        var gerente = await _gerenteService.FindById(id); 
        if (gerente is null) 
        { 
            return null;
        } 
        return _mapper.Map<GerenteDTO>(gerente);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(GerenteDTO gerenteDto) 
    {
        try
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto); 
            await _gerenteService.Save(gerente);
            return Ok("Gerente creado");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpPut("{id}")] 
    public async Task<IActionResult> Update(long id, GerenteDTO gerenteDto)
    {
        try
        {
            var gerente = _mapper.Map<Gerente>(gerenteDto); 
            if (id != gerente.Id) 
            { 
                return null;
            } 
            await _gerenteService.Update(gerente);
            return Ok("Gerente creado");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpDelete("{id}")] 
    public async Task<bool> Delete(int id) 
    { 
        var deleted = await _gerenteService.DeleteById(id); 
        return deleted;
    }
}