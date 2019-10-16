namespace back_sistema_tg.DAL.Models
{
    public class EnderecoCompleto
    {
        public string Logradouro { get; set; }
        
        public string Bairro { get; set; }

        public int NumeroEndereco { get; set; }

        public string CEP { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }
    }
}