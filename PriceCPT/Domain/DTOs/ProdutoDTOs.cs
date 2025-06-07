namespace PriceCPT.Domain.DTOs
{
    public class ProdutoDTOs
    {
        private decimal preco1;

        public int Id_produto { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get => preco1; set => preco1 = value; }
        public decimal? Preco_base { get; set; }
        public string? Mlb { get; set; }

        public string? Imagem_url { get; set; }
        public DateTime Data_cadastro { get; set; } = DateTime.Now;
        public int Estoque { get; set; }

        public List<AlteracaoPrecoDTOs> alteracaoProdutos { get; set; } = new();

    }
}
