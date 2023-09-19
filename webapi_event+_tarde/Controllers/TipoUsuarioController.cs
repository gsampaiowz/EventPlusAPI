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
    public class TipoUsuarioController : ControllerBase
        {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioController()
            {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
            }

        [HttpPost]
        public IActionResult Post(TipoUsuario tipoUsuario)
            {
            try
                {
                _tipoUsuarioRepository.Cadastrar(tipoUsuario);
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
                return Ok(_tipoUsuarioRepository.Listar());
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
            {
            try
                {
                return Ok(_tipoUsuarioRepository.BuscarPorId(id));
                }
            catch (Exception e)
                {
                return BadRequest(e.Message);
                }
            }
        }
    }
