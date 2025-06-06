namespace PriceCPT.Controllers
{
    public class Usuario
    {
        [Key]
        public int ID_USUARIO { get; set; }
        public string NOME { get; set; }
        public string EMAIL { get; set; }
        public string SENHA { get; set; }

        public Usuario(int id_usuario, string nome, string email, string senha)
        {
            ID_USUARIO = id_usuario;
            NOME = nome;
            EMAIL = email;
            SENHA = senha;
        }
    }
}
