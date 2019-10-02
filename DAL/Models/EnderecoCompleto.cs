using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_sistema_tg.DAL.Models
{
    public class EnderecoCompleto
    {
        [BsonElement("Logradouro")]
        public string Logradouro { get; set; }
        
        [BsonElement("Bairro")]
        public string Bairro { get; set; }

        [BsonElement("Numero")]
        public int Numero { get; set; }

        [BsonElement("CEP")]
        public string CEP { get; set; }

        [BsonElement("Cidade")]
        public string Cidade { get; set; }

        [BsonElement("Estado")]
        public string Estado { get; set; }
    }
}