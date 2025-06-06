using PriceCPT.Domain.Models;

namespace PriceCPT.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IAlteracaoPrecoRepository _alteracaoRepository;

        public ProdutoService(IProdutoRepository produtoRepository, IAlteracaoPrecoRepository alteracaoRepository)
        {
            _produtoRepository = produtoRepository;
            _alteracaoRepository = alteracaoRepository;
        }

        public void AtualizarPreco(int idProduto, decimal novoPreco)
        {
            var produto = _produtoRepository.Get(idProduto) as Produto;

            if (produto == null)
                throw new Exception("Produto não encontrado.");

            decimal precoAntigo = produto.Preco;
            produto.Preco = novoPreco;

            var alteracao = new AlteracaoPreco
            {
                Id_produto = produto.Id_produto,
                Produto = produto,
                Preco_antigo = precoAntigo,
                Preco_novo = novoPreco,
                Data_alteracao = DateTime.Now
            };

            _alteracaoRepository.Add(alteracao);
            _produtoRepository.Add(produto);
        }

        // Novo método: Adiciona produto vindo da API Mercado Livre
        public void AdicionarProdutoML(string mlId, string nome, decimal preco, int estoque, string imagemUrl)
        {
            var produto = new Produto
            {
                Nome = nome,
                Preco = preco,
                Estoque = estoque,
                Imagem_url = imagemUrl,
                Data_cadastro = DateTime.Now
            };

            _produtoRepository.Add(produto);
        }
    }
}
