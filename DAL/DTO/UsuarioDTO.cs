namespace back_sistema_tg.DAL.DTO
{
    public class UsuarioDTO
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool PerfilSuper { get; set; }
    }
}