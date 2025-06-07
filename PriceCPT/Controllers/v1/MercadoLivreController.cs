using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using Newtonsoft.Json.Linq;
using PriceCPT.Domain.DTOs;
using PriceCPT.Domain.Models;
using PriceCPT.Infraestrutura;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace PriceCPT.Controllers.v1
{
    [ApiController]
    [Route("api/[controller]")]
    public class MercadoLivreController : ControllerBase
    {
        private readonly ConexaoContext _context;

        public MercadoLivreController(ConexaoContext context)
        {
            _context = context;
        }

        [HttpPost("adicionar-produto")]
        public async Task<IActionResult> AdicionarProduto([FromBody] string link)
        {
            try
            {
                string mlb = ExtrairMLB(link);
                

                
                var produtoExistente = await _context.Produtos.FirstOrDefaultAsync(p => p.Mlb == mlb);
                if (produtoExistente != null)
                {
                    return Ok($"O produto já está cadastrado.");
                }

                
                string apiUrl = $"http://scripts.shoppingdeprecos.com.br/scripts/ml/consultamlb.php?mlb={mlb}";
                using var httpClient = new HttpClient(); // cria um cliente 
                var response = await httpClient.GetAsync(apiUrl); // faz um GET para a API

                var json = await response.Content.ReadAsStringAsync(); // le o conteudo da API como um string (Json)
                var jsonData = JsonDocument.Parse(json).RootElement; // transforma em Json para poder pegar os dados

                string nome = jsonData.GetProperty("title").GetString();
                decimal preco = jsonData.GetProperty("price").GetDecimal();
                decimal preco_base = jsonData.GetProperty("base_price").GetDecimal();
                string imagemUrl = jsonData.GetProperty("thumbnail").GetString();
                int estoque = jsonData.GetProperty("initial_quantity").GetInt32();

                var novoProduto = new Produto
                {
                    Nome = nome,
                    Preco = preco,
                    Preco_base = preco_base,
                    Mlb = mlb,
                    Imagem_url = imagemUrl,
                    Estoque = estoque,
                    Data_cadastro = DateTime.Now,
                    
                };

                _context.Produtos.Add(novoProduto);
                await _context.SaveChangesAsync();

                return Ok(novoProduto);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        
        private string? ExtrairMLB(string link)
        {
            
            var wid = Regex.Match(link, @"wid=(MLB-?\d+)");
            if (wid.Success)
            {
                return wid.Groups[1].Value.Replace("-", "");
            }


            var geral = Regex.Match(link, @"MLB-?\d+");

            if (geral.Success)
            {
                return geral.Value.Replace("-", "");
            }
            else
            {
                return null;
            }
        }
        [HttpPut("atualizar-preco")]
        public async Task<IActionResult> AtualizarPrecoProduto([FromBody] string link)
        {
            try
            {
                string mlb = ExtrairMLB(link);
                string url = $"http://scripts.shoppingdeprecos.com.br/scripts/ml/consultamlb.php?mlb={mlb}";
                var httpClient = new HttpClient();
                var resposta = await httpClient.GetAsync(url);
                var jsonString = await resposta.Content.ReadAsStringAsync();

                JsonElement dados;
                dados = JsonDocument.Parse(jsonString).RootElement;

                string nome = dados.GetProperty("title").GetString();
                decimal precoAtual = dados.GetProperty("price").GetDecimal();
                decimal preco_base = dados.GetProperty("base_price").GetDecimal();
                string imagem = dados.GetProperty("thumbnail").GetString();
                int estoque = dados.GetProperty("initial_quantity").GetInt32();

                
                var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Mlb == mlb);

                if (produto != null)
                {

                    bool houveMudanca = false;

                    // Verifica e atualiza o preço, se necessário
                    if (produto.Preco != precoAtual)
                    {
                        var alteracao = new AlteracaoPreco
                        {
                            Id_produto = produto.Id_produto,
                            Preco_antigo = produto.Preco,
                            Preco_novo = precoAtual,
                            Preco_base = preco_base,
                            Data_alteracao = DateTime.Now,
                            Estoque = estoque
                        };

                        _context.AlteracaoPrecos.Add(alteracao);
                        produto.Preco = precoAtual;
                        houveMudanca = true;
                    }

                    // Verifica e atualiza o preco_base, se necessário
                    if (produto.Preco_base != preco_base)
                    {
                        produto.Preco_base = preco_base;
                        houveMudanca = true;
                    }

                    // Verifica e atualiza o estoque, se necessário
                    if (produto.Estoque != estoque)
                    {
                        produto.Estoque = estoque;
                        houveMudanca = true;
                    }

                    if (houveMudanca)
                    {
                        _context.Produtos.Update(produto);
                        await _context.SaveChangesAsync();

                        return Ok(new
                        {
                            mensagem = "Produto atualizado.",
                            produto = new ProdutoDTOs
                            {
                                Id_produto = produto.Id_produto,
                                Nome = produto.Nome,
                                Mlb = produto.Mlb,
                                Preco = produto.Preco,
                                Preco_base = produto.Preco_base,
                                Imagem_url = produto.Imagem_url,
                                Data_cadastro = produto.Data_cadastro,
                                Estoque = produto.Estoque
                            }
                        });
                    }
                    else
                    {
                        return Ok(new { mensagem = "Nenhuma mudança detectada." });
                    }

                }

                
                var novoProduto = new Produto

                {
                    
                    Nome = nome,
                    Preco = precoAtual,
                    Preco_base = preco_base,
                    Mlb = mlb,
                    Imagem_url = imagem,
                    Data_cadastro = DateTime.Now,
                    Estoque = estoque,
                };

                _context.Produtos.Add(novoProduto);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    mensagem = "Produto cadastrado",
                });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


    }

}
