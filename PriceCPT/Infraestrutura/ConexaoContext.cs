using Microsoft.EntityFrameworkCore;
using PriceCPT.Domain.Models;

namespace PriceCPT.Infraestrutura
{
    public class ConexaoContext : DbContext
    {
        public ConexaoContext(DbContextOptions<ConexaoContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<AlteracaoPreco> AlteracaoPrecos { get; set; }

    }
}
