using Microsoft.AspNetCore.Mvc;
using PriceCPT.Domain.DTOs;
using PriceCPT.Domain.Models;

namespace PriceCPT.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/alteracao-preco")]
    [ApiVersion("1.0")]
    public class AlteracaoPrecoController : Controller
    {
        private readonly IAlteracaoPrecoRepository _alteracaoPrecoRepository;

        public AlteracaoPrecoController(IAlteracaoPrecoRepository alteracaoPrecoRepository)
        {
            _alteracaoPrecoRepository = alteracaoPrecoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var alteracoes = _alteracaoPrecoRepository.Get()    ;

            var dto = alteracoes.Select(a => new AlteracaoPrecoDTOs
            {
                Id_preco = a.Id_preco,
                Id_produto = a.Id_produto,
                Preco_antigo = a.Preco_antigo,
                Preco_novo = a.Preco_novo,
                Data_alteracao = a.Data_alteracao,
                Estoque = a.Estoque ?? 0
            }).ToList();

            return Ok(dto);
        }

    }
}
