using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_event__tarde.Domains;
using webapi_event__tarde.Interfaces;
using webapi_event__tarde.Repositories;

namespace webapi_event__tarde.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
        {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController()
            {
            _usuarioRepository = new UsuarioRepository();
            }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
            {
            try
                {
                _usuarioRepository.Cadastrar(usuario);
                return StatusCode(201);
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }

        [HttpGet]
        public IActionResult Get()
            {
            try
                {
                return Ok(_usuarioRepository.Listar());
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }
        }
    }
