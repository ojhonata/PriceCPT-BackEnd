namespace PriceCPT.Aplication.ViewModel
{
    public class ProdutoViewModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string MBL { get; set; }
        public string Imagen { get; set; }
        public int Estoque { get; set; } = 0;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public List<AlteracaoPrecoViewModel> AlteracaoProdutos { get; set; } = new();
    }
}
