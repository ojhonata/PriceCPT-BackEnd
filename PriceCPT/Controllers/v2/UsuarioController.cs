using Microsoft.AspNetCore.Mvc;
using PriceCPT.Domain.Models;
using PriceCPT.Infraestrutura.Repository;
using AutoMapper;
using PriceCPT.Domain.DTOs;

namespace PriceCPT.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/usuario")]
    [ApiVersion("2.0")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuarioController> _logger;
        private readonly IMapper _mapper;
        

        public UsuarioController(IUsuarioRepository usuarioRepository, ILogger<UsuarioController> logger, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(UsuarioRepository), "O repositório de usuário não pode ser nulo.");
            _logger = logger ?? throw new ArgumentNullException(nameof(logger), "O logger não pode ser nulo.");
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "O mapper não pode ser nulo.");
        }



        [HttpPost]
        public IActionResult Add(UsuarioDTOs usuarios)
        {
            var usuario = new Usuario(usuarios.NOME, usuarios.EMAIL, usuarios.SENHA);
            _usuarioRepository.Add(usuario);

            return Ok();
        }

        [HttpGet]
        [Route("{ID_USARIO}")]
        public IActionResult Search(int ID_USARIO)
        {
            _logger.Log(LogLevel.Information, "Houve um erro");

            var usuarios = _usuarioRepository.Get(ID_USARIO);
            var usuarioDTO = _mapper.Map<UsuarioDTOs>(usuarios);


            return Ok(usuarioDTO);
        }
    }
}
