using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_sistema_tg.DAL.Models
{
    public class Escala
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("InstrutorDia")]
        public string InstrutorDia { get; set; }

        [BsonElement("PermanenciaManha")]
        public Atirador PermanenciaManha { get; set; }

        [BsonElement("PermanenciaTarde")]
        public Atirador PermanenciaTarde { get; set; }

        [BsonElement("ComandanteGuarda")]
        public string ComandanteGuarda { get; set; }

        [BsonElement("Guardas")]
        public Atirador Guardas { get; set; }
    }
}
