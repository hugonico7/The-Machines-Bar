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
    public IList<GerenteDTO> GetAll() 
    { 
        IList<GerenteDTO> gerenteList = new List<GerenteDTO>(); 
        var gerentes = _gerenteService.FindAll(); 
        foreach (Gerente g in gerentes) 
        { 
            gerenteList.Add(_mapper.Map<GerenteDTO>(g));
        } 
        return gerenteList;
    }
    
    [HttpGet("{id}")]
    public GerenteDTO Get(int id)
    {
        var gerente = _gerenteService.FindById(id); 
        if (gerente is null) 
        { 
            return null;
        } 
        return _mapper.Map<GerenteDTO>(gerente);
    }
    
    [HttpPost]
    public GerenteDTO Create(GerenteDTO gerenteDto) 
    { 
        Gerente gerente = _mapper.Map<Gerente>(gerenteDto); 
        gerente = _gerenteService.Save(gerente); 
        return _mapper.Map<GerenteDTO>(gerente);
    }
            
    [HttpPut("{id}")] 
    public GerenteDTO Update(long id, GerenteDTO gerenteDto)
    { 
        var gerente = _mapper.Map<Gerente>(gerenteDto); 
        if (id != gerente.Id) 
        { 
            return null;
        } 
        gerente = _gerenteService.Update(gerente);
        return _mapper.Map<GerenteDTO>(gerente);
    }
            
    [HttpDelete("{id}")] 
    public bool Delete(int id) 
    { 
        var deleted = _gerenteService.DeleteById(id); 
        return deleted;
    }
}