using ApiRest.DTO;
using ApiRest.Entities;
using ApiRest.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers;

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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IList<CamareroDTO>> GetAll() 
    {
        var camareros = await _camareroService.FindAll();
        return camareros.Select(c => _mapper.Map<CamareroDTO>(c)).ToList();
    }
    
    [HttpGet("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<CamareroDTO?> Get(int id)
    {
        var camarero =  await _camareroService.FindById(id); 
        return camarero is null ? null : _mapper.Map<CamareroDTO>(camarero);
    }
    
    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IActionResult> Create(CamareroDTO camareroDto)
    {
        try
        {
            
            var newpass = BCrypt.Net.BCrypt.HashPassword(camareroDto.Password);
            camareroDto.Password = newpass;

            var camarero = _mapper.Map<Camarero>(camareroDto); 
            await _camareroService.Save(camarero);
            return Ok("Camarero creado correctamente");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpPut("{id}")] 
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IActionResult?> Update(int id, CamareroDTO camareroDto)
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IActionResult> Delete(int id) 
    { 
        var deleted = await _camareroService.DeleteById(id);
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