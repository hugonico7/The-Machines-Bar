﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiRest.DTO;
using ApiRest.Entities;
using ApiRest.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiRest.Controllers;

[Route("Usuario")]
[ApiController]
public class UsuarioController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly UsuarioService _usuarioService;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;

    public UsuarioController(UsuarioService usuarioService, IMapper mapper, IConfiguration configuration)
    {
        _usuarioService = usuarioService;
        _mapper = mapper;
        _config = configuration;
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IList<UsuarioDTO>> GetAllUsers()
    {
        var users = await _usuarioService.FindAll();
        return users.Select(u => _mapper.Map<UsuarioDTO>(u)).ToList();
    }

    [HttpGet("{id:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<UsuarioDTO?> GetUser(int id)
    {
        var user = await _usuarioService.FindById(id);
        return user is null ? null : _mapper.Map<UsuarioDTO>(user);
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<UsuarioDTO> CreateUser(UsuarioCreationDTO userDto)
    {
        var user = _mapper.Map<Usuario>(userDto);
        user = await _usuarioService.Save(user);

        return _mapper.Map<UsuarioDTO>(user);
    }

    [HttpPut("{id:long}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<IActionResult> UpdateUser(long id, UsuarioDTO userDto)
    {
        try
        {
            var user = _mapper.Map<Usuario>(userDto);
            if (id != user.Id)
            {
                return BadRequest("Las id no coinciden");
            }

            await _usuarioService.Update(user);
            return Ok("Usuario actualizado");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "gerente")]
    public async Task<bool> DeleteUser(int id)
    {
        var deleted = await _usuarioService.DeleteById(id);
        return deleted;
    }

    [HttpPost]
    [Route("/Login")]
    public async Task<IResult> Login(UsuarioLoginDTO user)
    {
        var userlogged = await _usuarioService.GetUserByUsername(user.Username);

        var comprobar = BCrypt.Net.BCrypt.Verify(user.Password, userlogged!.Password);

        if (comprobar)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userlogged?.Username!),
                new Claim(ClaimTypes.Role, userlogged?.Rol!)
            };

            var token = new JwtSecurityToken(_config.GetSection("Jwt").GetSection("Issuer").Value,
                _config.GetSection("Jwt").GetSection("Audience").Value, claims, expires: DateTime.UtcNow.AddHours(1),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_config.GetSection("Jwt").GetSection("key").Value ?? string.Empty)),
                    SecurityAlgorithms.HmacSha512));

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Results.Ok(tokenString);
        }
        else
            return Results.BadRequest("Login fail");
    }
}