using Microsoft.EntityFrameworkCore;
using PriceCPT.Domain.Models;

namespace PriceCPT.Infraestrutura.Repository
{
    public class AlteracaoPrecoRepository : IAlteracaoPrecoRepository
    {
        private readonly ConexaoContext _context;
        public AlteracaoPrecoRepository(ConexaoContext context)
        {
            _context = context;
        }
        public void Add(AlteracaoPreco alteracaoProduto)
        {
            _context.AlteracaoPrecos.Add(alteracaoProduto);
            _context.SaveChanges();
        }

        public List<AlteracaoPreco> Get()
        {
            return _context.AlteracaoPrecos
                .Include(ap => ap.Produto)
                .ToList();
        }

    }
}
