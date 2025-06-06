namespace PriceCPT.Domain.Models
{
    public interface IAlteracaoPrecoRepository
    {
        void Add(AlteracaoPreco alteracaoProduto);
        List<AlteracaoPreco> Get();
    }
}