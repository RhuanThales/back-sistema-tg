using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_sistema_tg.DAL.Models
{
    public class RegistroGeral
    {
        [BsonElement("OrgaoEmissor")]
        public string OrgaoEmissor { get; set; }
        
        [BsonElement("Numero")]
        public string Numero { get; set; }
    }
}