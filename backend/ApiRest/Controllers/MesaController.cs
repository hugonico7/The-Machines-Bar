﻿using ApiRest.DTO;

namespace ApiRest.Controller;
using ApiRest.Entities;
using ApiRest.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[Route("Mesa")]
[ApiController]
public class MesaController : Controller
{
    private readonly MesaService _mesaService;
    private readonly IMapper _mapper;

    public MesaController(MesaService mesaService,IMapper mapper)
    {
        _mesaService = mesaService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IList<MesaDTO>> GetAll() 
    {
        var mesas = await _mesaService.FindAll();
        return mesas.Select(m => _mapper.Map<MesaDTO>(m)).ToList();
    }
    
    [HttpGet("{id}")]
    public async Task<MesaDTO> Get(int id)
    {
        var mesa = await _mesaService.FindById(id); 
        if (mesa is null) 
        { 
            return null;
        } 
        return _mapper.Map<MesaDTO>(mesa);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(MesaDTO mesaDto) 
    {
        try
        {
            var mesa = _mapper.Map<Mesa>(mesaDto);
            await _mesaService.Save(mesa);
            return Ok("Mesa creada");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpPut("{id}")] 
    public async Task<IActionResult> Update(long id, MesaDTO mesaDto)
    {
        try
        {
            var mesa = _mapper.Map<Mesa>(mesaDto); 
            if (id != mesa.Id) 
            { 
                return null;
            }

            await _mesaService.Update(mesa);
            return Ok("Mesa Actualizado");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpDelete("{id}")] 
    public async Task<bool> Delete(int id) 
    { 
        var deleted = await _mesaService.DeleteById(id); 
        return deleted;
    }

}