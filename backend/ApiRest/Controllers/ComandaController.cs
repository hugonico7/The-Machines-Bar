using ApiRest.DTO;
using ApiRest.Entities;
using ApiRest.Repository;

namespace ApiRest.Controller;

using ApiRest.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

[Route("comanda")]
[ApiController]
public class ComandaController : Controller
{
    private readonly ComandaService _comandaService;
    private readonly IMapper _mapper;

    public ComandaController(ComandaService comandaService,IMapper mapper)
    {
        _mapper = mapper;
        _comandaService = comandaService;
    }
    
    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "camarero")]
    public async Task<IList<ComandaDTO>> GetAll() 
    {
        var comandas = await _comandaService.FindAll();
        return comandas.Select(c => _mapper.Map<ComandaDTO>(c)).ToList();
    }
    
    [HttpGet("{id}")]
    public async Task<ComandaDTO?> Get(int id)
    {
        var comanda = await _comandaService.FindById(id); 
        return comanda is null ? null :  _mapper.Map<ComandaDTO>(comanda);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(ComandaDTO comandaDto) 
    {
        try
        {
            var comanda = _mapper.Map<Comanda>(comandaDto);
            await _comandaService.Save(comanda);
            return Ok("Comanda Creada");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpPut("{id}")] 
    public async Task<IActionResult?> Update(long id, ComandaDTO comandaDto)
    {
        try
        {
            var comanda = _mapper.Map<Comanda>(comandaDto); 
            if (id != comanda.Id) 
            { 
                return null;
            }

            await _comandaService.Update(comanda);
            return Ok("Comanda Actualizada");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpDelete("{id}")] 
    public async Task<bool> Delete(int id) 
    { 
        var deleted = await _comandaService.DeleteById(id); 
        return deleted;
    }
}