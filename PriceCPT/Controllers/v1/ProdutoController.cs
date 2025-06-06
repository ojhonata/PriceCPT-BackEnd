
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using PriceCPT.Domain.DTOs;
using PriceCPT.Domain.Models;
using PriceCPT.Infraestrutura.Repository;


namespace PriceCPT.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/produto")]
    [ApiVersion("1.0")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;


        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
            
          
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProdutoDTOs produtos)
        {
            var produto = new Produto(produtos.Nome, produtos.Descricao, produtos.preco, produtos.Mlb);
            _produtoRepository.Add(produto);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _produtoRepository.Get();

            var produtosDTO = produtos.Select(p => new ProdutoDTOs
            {
                Id_produto = p.Id_produto,
                Nome = p.Nome,
                Descricao = p.Descricao,
                preco = p.Preco,
                Mlb = p.Mlb,
                Imagem_url = p.Imagem_url,
                Data_cadastro = p.Data_cadastro,
                Estoque = p.Estoque,
                alteracaoProdutos = p.AlteracaoProdutos?.Select(a => new AlteracaoPrecoDTOs
                {
                    Id_preco = a.Id_preco,
                    Id_produto = a.Id_produto,
                    Preco_antigo = a.Preco_antigo,
                    Preco_novo = a.Preco_novo,
                    Data_alteracao = a.Data_alteracao
                }).ToList() ?? new List<AlteracaoPrecoDTOs>()
            }).ToList();

            return Ok(produtosDTO);
        }


        [HttpGet("buscar/{termo}")]
        public IActionResult Buscar(string termo)
        {
            var produtos = _produtoRepository.BuscarPorNome(termo);

            var dto = produtos.Select(p => new ProdutoDTOs
            {
                Id_produto = p.Id_produto,
                Nome = p.Nome,
                Descricao = p.Descricao,
                preco = p.Preco,
                Mlb = p.Mlb,
                Imagem_url = p.Imagem_url,
                Data_cadastro = p.Data_cadastro,
                Estoque = p.Estoque,
                alteracaoProdutos = p.AlteracaoProdutos?.Select(a => new AlteracaoPrecoDTOs
                {
                    Id_preco = a.Id_preco,
                    Id_produto = a.Id_produto,
                    Preco_antigo = a.Preco_antigo,
                    Preco_novo = a.Preco_novo,
                    Data_alteracao = a.Data_alteracao
                }).ToList() ?? new List<AlteracaoPrecoDTOs>()
            }).ToList();

            return Ok(dto);
        }

        [HttpDelete("{id_produto}")]
        public IActionResult DeleteUsuario(int id_produto)
        {
            var produto = _produtoRepository.Get(id_produto);

            if (produto == null)
                return NotFound("Produto não encontrado");

            _produtoRepository.Remove(id_produto);
            return Ok("Produto deletado");
        }



    }
}
