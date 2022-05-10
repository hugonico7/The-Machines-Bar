using ApiRest.DTO;
using ApiRest.Entities;
using ApiRest.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controller;

    [Route("Usuario")]
    [ApiController]
    public class UsuarioController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly IMapper _mapper;
        
        public UsuarioController(UsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IList<UsuarioDTO>> GetAllUsers()
        {
            var users = await _usuarioService.FindAll();
            return users.Select(u => _mapper.Map<UsuarioDTO>(u)).ToList();
        }
        
        [HttpGet("{id}")]
        public async Task<UsuarioDTO?> GetUser(int id)
        {
            var user = await _usuarioService.FindById(id);
            return user is null ? null : _mapper.Map<UsuarioDTO>(user);
        }
        
        [HttpPost]
        public async Task<UsuarioDTO> CreateUser(UsuarioDTO userDto)
        {
            Usuario user = _mapper.Map<Usuario>(userDto);
            user = await _usuarioService.Save(user);
          
            return _mapper.Map<UsuarioDTO>(user);
        }
        
        [HttpPut("{id}")]
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
        public async Task<bool> DeleteUser(int id)
        {
            var deleted = await _usuarioService.DeleteById(id);
            return deleted;
        }
    }