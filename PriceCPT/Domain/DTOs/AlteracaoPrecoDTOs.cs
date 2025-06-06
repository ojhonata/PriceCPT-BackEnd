namespace PriceCPT.Domain.DTOs
{
    public class AlteracaoPrecoDTOs
    {
        public int Id_preco { get; set; }
        public int Id_produto { get; set; }
        public decimal Preco_antigo { get; set; }
        public decimal Preco_novo { get; set; }
        public DateTime Data_alteracao { get; set; }
        public int Estoque { get; set; }

    }
}
