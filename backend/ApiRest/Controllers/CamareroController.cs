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
    public IList<CamareroDTO> GetAll() 
    { 
        IList<CamareroDTO> camareroList = new List<CamareroDTO>(); 
        var camareros = _camareroService.FindAll(); 
        foreach (Camarero c in camareros) 
        { 
            camareroList.Add(_mapper.Map<CamareroDTO>(c));
        } 
        return camareroList;
    }
    
    [HttpGet("{id}")]
    public CamareroDTO Get(int id)
    {
        var camarero = _camareroService.FindById(id); 
        if (camarero is null) 
        { 
            return null;
        } 
        return _mapper.Map<CamareroDTO>(camarero);
    }
    
    [HttpPost]
    public CamareroDTO Create(CamareroDTO camareroDto) 
    { 
        Camarero camarero = _mapper.Map<Camarero>(camareroDto); 
        camarero = _camareroService.Save(camarero); 
        return _mapper.Map<CamareroDTO>(camarero);
    }
            
    [HttpPut("{id}")] 
    public CamareroDTO Update(int id, CamareroDTO camareroDto)
    { 
        var camarero = _mapper.Map<Camarero>(camareroDto); 
        if (id != camarero.Id) 
        { 
            return null;
        } 
        camarero = _camareroService.Update(camarero);
        return _mapper.Map<CamareroDTO>(camarero);
    }
            
    [HttpDelete("{id}")] 
    public bool Delete(int id) 
    { 
        var deleted = _camareroService.DeleteById(id); 
        return deleted;
    }
}