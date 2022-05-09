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
    public IList<CocineroDTO> GetAll() 
    { 
        IList<CocineroDTO> cocineroList = new List<CocineroDTO>(); 
        var cocineros = _cocineroService.FindAll(); 
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
    public CocineroDTO Create(CocineroDTO cocineroDto) 
    { 
        Cocinero cocinero = _mapper.Map<Cocinero>(cocineroDto); 
        cocinero = _cocineroService.Save(cocinero); 
        return _mapper.Map<CocineroDTO>(cocinero);
    }
            
    [HttpPut("{id}")] 
    public CocineroDTO Update(long id, CocineroDTO cocineroDto)
    { 
        var cocinero = _mapper.Map<Cocinero>(cocineroDto); 
        if (id != cocinero.Id) 
        { 
            return null;
        } 
        cocinero = _cocineroService.Update(cocinero);
        return _mapper.Map<CocineroDTO>(cocinero);
    }
            
    [HttpDelete("{id}")] 
    public bool Delete(int id) 
    { 
        var deleted = _cocineroService.DeleteById(id); 
        return deleted;
    }
}