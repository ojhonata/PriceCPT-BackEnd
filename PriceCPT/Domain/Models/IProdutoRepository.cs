namespace PriceCPT.Domain.Models
{
    public interface IProdutoRepository
    {
        void Add(Produto produto);

        List<Produto> Get();
        Produto Get(int id_produto);
        List<Produto> BuscarPorNome(string termo);
        void Remove(int id_produto);
    }
}
