using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_sistema_tg.DAL.Models
{
    public class Escala
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdEscala { get; set; }
        
        [BsonElement("NumeroEscala")]
        public int NumeroEscala { get; set; }
        
        [BsonElement("StatusEscala")]
        public bool StatusEscala { get; set; }
        
        [BsonElement("InstrutorSemana")]
        public string InstrutorSemana { get; set; }

        [BsonElement("Segunda")]
        public Diaria Segunda { get; set; }

        [BsonElement("Terca")]
        public Diaria Terca { get; set; }

        [BsonElement("Quarta")]
        public Diaria Quarta { get; set; }

        [BsonElement("Quinta")]
        public Diaria Quinta { get; set; }

        [BsonElement("Sexta")]
        public Diaria Sexta { get; set; }

        [BsonElement("Sabado")]
        public Diaria Sabado { get; set; }
        
        [BsonElement("Domingo")]
        public Diaria Domingo { get; set; }
    }
}