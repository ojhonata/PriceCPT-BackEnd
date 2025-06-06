using Microsoft.AspNetCore.Mvc;
using PriceCPT.Domain.Models;
using PriceCPT.Infraestrutura.Repository;
using AutoMapper;
using PriceCPT.Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;

namespace PriceCPT.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/usuario")]
    [ApiVersion("1.0")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        

        

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            
            
        }



        [HttpPost]
        public IActionResult Add([FromBody] UsuarioDTOs usuarios)
        {
            var usuario = new Usuario(usuarios.NOME, usuarios.EMAIL, usuarios.SENHA);
            _usuarioRepository.Add(usuario);

            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTOs loginDto)
        {
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Senha))
            {
                return BadRequest("Email e senha são obrigatórios.");
            }

            var usuario = _usuarioRepository.GetByEmail(loginDto.Email);
            if (usuario == null)
            {
                return Unauthorized("Usuário não encontrado.");
            }

            if (usuario.SENHA != loginDto.Senha)
            {
                return Unauthorized("Senha incorreta.");
            }

            return Ok("Login realizado com sucesso.");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _usuarioRepository.Get();

            var usuariosDTO = usuarios.Select(u => new UsuarioDTOs
            {
                ID_USUARIO = u.ID_USUARIO,
                NOME = u.NOME,
                EMAIL = u.EMAIL,
                SENHA = u.SENHA
            }).ToList();

            return Ok(usuariosDTO);
        }

        [HttpGet("{ID_USUARIO}")]
        public IActionResult Search(int ID_USUARIO)
        {
            var usuario = _usuarioRepository.Get(ID_USUARIO) as Usuario;

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            var usuarioDTO = new UsuarioDTOs
            {
                ID_USUARIO = usuario.ID_USUARIO,
                NOME = usuario.NOME,
                EMAIL = usuario.EMAIL,
                SENHA = usuario.SENHA
            };

            return Ok(usuarioDTO);
        }

        [HttpDelete("{ID_USUARIO}")]
        public IActionResult DeleteUsuario(int ID_USUARIO)
        {
            var usuario = _usuarioRepository.Get(ID_USUARIO);

            if (usuario == null)
                return NotFound("Usuário não encontrado");

            _usuarioRepository.Remove(ID_USUARIO);
            return Ok("Usuário deletado com sucesso");
        }

    }
}
