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
        public IList<UsuarioDTO> GetAllUsers()
        {
            IList<UsuarioDTO> usersDTO = new List<UsuarioDTO>();
            var users = _usuarioService.FindAll();
            foreach (Usuario u in users)
            {
                usersDTO.Add(_mapper.Map<UsuarioDTO>(u));
            }
            return usersDTO;
        }
        
        [HttpGet("{id}")]
        public UsuarioDTO GetUser(int id)
        {
            var user = _usuarioService.FindById(id);
            if (user is null)
            {
                return null;
            } 
            return _mapper.Map<UsuarioDTO>(user);
        }
        
        [HttpPost]
        public UsuarioDTO CreateUser(UsuarioDTO userDto)
        {
            Usuario user = _mapper.Map<Usuario>(userDto);
            user = _usuarioService.Save(user);
          
            return _mapper.Map<UsuarioDTO>(user);
        }
        
        [HttpPut("{id}")]
        public UsuarioDTO UpdateUser(long id, UsuarioDTO userDto)
        {
            var user = _mapper.Map<Usuario>(userDto);
            if (id != user.Id)
            {
                return null;
            }
 
            user = _usuarioService.Update(user);

            return _mapper.Map<UsuarioDTO>(user);
        }
        
        [HttpDelete("{id}")]
        public bool DeleteUser(int id)
        {
            var deleted = _usuarioService.DeleteById(id);
            return deleted;
        }
    }