using PriceCPT.Domain.DTOs;
using PriceCPT.Domain.Models;
using System.Linq;

namespace PriceCPT.Infraestrutura.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ConexaoContext _context;
        public UsuarioRepository(ConexaoContext context)
        {
            _context = context;
        }
        public void Add(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }



        public List<Usuario> Get()
        {
            return _context.Usuario.ToList();
        }

        public object Get(int iD_USARIO)
        {
            return _context.Usuario.FirstOrDefault(u => u.ID_USUARIO == iD_USARIO);
        }

        public Usuario GetByEmail(string email)
        {
            return _context.Usuario.FirstOrDefault(u => u.EMAIL == email);

        }

        public void Remove(int iD_USUARIO)
        {
            var usuario = _context.Usuario.FirstOrDefault(u => u.ID_USUARIO == iD_USUARIO);

            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
                _context.SaveChanges();
            }
        }
    }
}