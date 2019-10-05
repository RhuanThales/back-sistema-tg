using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace back_sistema_tg.DAL.Models
{
    public class Escala
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdEscala { get; set; }
        
        [BsonElement("InstrutorDia")]
        public string InstrutorDia { get; set; }

        [BsonElement("PermanenciaManha")]
        public string [] PermanenciaManha { get; set; }

        [BsonElement("PermanenciaTarde")]
        public string [] PermanenciaTarde { get; set; }

        [BsonElement("ComandanteGuarda")]
        public string ComandanteGuarda { get; set; }

        [BsonElement("Guardas")]
        public string [] Guardas { get; set; }

         [BsonElement("Dia")]
        public DateTime Dia { get; set; }
    }
}
