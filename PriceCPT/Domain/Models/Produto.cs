using PriceCPT.Domain.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceCPT.Domain.Models
{
    [Table("produto")]
    public class Produto
    {
        [Key]
        public int Id_produto { get; set; }

        public string? Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string? Mlb { get; set; }
        public string? Imagem_url { get; set; }
        public DateTime Data_cadastro { get; set; } = DateTime.Now;
        public int Estoque { get; set; }

        public List<AlteracaoPreco> AlteracaoProdutos { get; set; } = new();
        

        public Produto() { }

        public Produto(string nome, string descricao, decimal preco, string mlb)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.Preco = preco;
            this.Mlb = mlb;
            this.Data_cadastro = DateTime.Now;
            this.Estoque = Estoque;
        }
    }
}
