using Microsoft.EntityFrameworkCore;
using PriceCPT.Domain.DTOs;
using PriceCPT.Domain.Models;

namespace PriceCPT.Infraestrutura.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ConexaoContext _context;

        public ProdutoRepository(ConexaoContext context)
        {
            _context = context;
        }


        public void Add(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public List<Produto> Get()
        {
            return _context.Produtos
                .Include(p => p.AlteracaoProdutos)
                .ToList();
        }

        public List<Produto> BuscarPorNome(string termo)
        {
            return _context.Produtos
                .Include(p => p.AlteracaoProdutos)
                .Where(p => EF.Functions.Like(p.Nome, $"%{termo}%") || EF.Functions.Like(p.Nome, $"%{termo}%"))
                .ToList();
        }

        public Produto Get(int id_produto)
        {
            return _context.Produtos
                .Include(p => p.AlteracaoProdutos)
                .FirstOrDefault(p => p.Id_produto == id_produto);
        }

        public void Remove(int id_produto)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id_produto == id_produto);

            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }
        }

    }
}
