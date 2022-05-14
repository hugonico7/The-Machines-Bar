﻿using ApiRest.DTO;
using ApiRest.Entities;

namespace ApiRest.Controller;

using ApiRest.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[Route("reserva")]
[ApiController]
public class ReservaController : Controller
{
    private readonly ReservaService _reservaService;
    private readonly IMapper _mapper;

    public ReservaController(ReservaService reservaService,IMapper mapper)
    {
        _mapper = mapper;
        _reservaService = reservaService;
    }
    
    [HttpGet]
    public async Task<IList<ReservaDTO>> GetAll() 
    {
        var reservas = await _reservaService.FindAll();
        return reservas.Select(r => _mapper.Map<ReservaDTO>(r)).ToList();
    }
    
    [HttpGet("{id}")]
    public async Task<ReservaDTO?> Get(int id)
    {
        var reserva = await _reservaService.FindById(id); 
        return reserva is null ? null : (ReservaDTO) _mapper.Map<ReservaDTO>(reserva);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(ReservaDTO reservaDto) 
    {
        try
        {
            var reserva = _mapper.Map<Reserva>(reservaDto);
            await _reservaService.Save(reserva);
            return Ok("Reserva creada");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpPut("{id}")] 
    public async Task<IActionResult> Update(long id, ReservaDTO reservaDto)
    {
        try
        {
            var reserva = _mapper.Map<Reserva>(reservaDto); 
            if (id != reserva.Id) 
            { 
                return null;
            }

            await _reservaService.Update(reserva);
            return Ok("Resrva Actualizada");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
            
    [HttpDelete("{id}")] 
    public async Task<bool> Delete(int id) 
    { 
        var deleted = await _reservaService.DeleteById(id); 
        return deleted;
    }
}