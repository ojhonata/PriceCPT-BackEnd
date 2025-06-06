namespace PriceCPT.Aplication.ViewModel
{
    public class AlteracaoPrecoViewModel
    {
        public int IdPreco { get; set; }
        public decimal PrecoAntigo { get; set; }
        public decimal PrecoNovo { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
