using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PriceCPT.Domain.Models
{
    [Table("alteracao_preco")]
    public class AlteracaoPreco
    {
        [Key]
        public int Id_preco { get; set; }

        [ForeignKey("Produto")]
        public int Id_produto { get; set; }

        
        public Produto Produto { get; set; }

        public decimal Preco_novo { get; set; }
        public decimal Preco_antigo { get; set; }
        public decimal? Preco_base { get; set; }
        public DateTime Data_alteracao { get; set; }
        public int? Estoque { get; set; }

        public AlteracaoPreco() { }

        public AlteracaoPreco(int id_produto, decimal precoNovo, decimal precoAntigo, decimal precoBase, DateTime dataAlteracao, int estoque)
        {
            this.Id_produto = id_produto;
            this.Preco_novo = precoNovo;
            this.Preco_antigo = precoAntigo;
            this.Preco_base = precoBase;
            this.Data_alteracao = dataAlteracao;
            this.Estoque = estoque;
        }
    }
}
