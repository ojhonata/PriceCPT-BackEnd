using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceCPT.Domain.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        public int ID_USUARIO { get; set; }
        public string NOME { get; set; }
        public string EMAIL { get; set; }
        public string SENHA { get; set; }

        public Usuario() { }
 
        public Usuario(string nome, string email, string senha)
        {
            this.NOME = nome;
            this.EMAIL = email;
            this.SENHA = senha;
        }

    }
}
