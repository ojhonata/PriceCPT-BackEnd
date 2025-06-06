using PriceCPT.Domain.DTOs;

namespace PriceCPT.Domain.Models
{
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);

        Usuario GetByEmail(string email);
        List<Usuario> Get();
        object Get(int iD_USARIO);
        void Remove(int iD_USUARIO);
    }
}
