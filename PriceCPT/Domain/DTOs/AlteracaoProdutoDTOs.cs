namespace PriceCPT.Domain.DTOs
{
    public class AlteracaoProdutoDTOs
    {
        public int Id { get; set; }
        public decimal PrecoAnterior { get; set; }
        public decimal PrecoAtual { get; set; }
        public DateTime DataAlteracao { get; set; }

        public string? NomeProduto { get; set; }
    }
}
