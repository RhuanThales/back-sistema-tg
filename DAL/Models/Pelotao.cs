using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_sistema_tg.DAL.Models
{
    public class Pelotao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdPelotao { get; set; }
        
        [BsonElement("NomePelotao")]
        public string NomePelotao { get; set; }

        [BsonElement("NumeroPelotao")]
        public int NumeroPelotao { get; set; }

        [BsonElement("Comandante")]
        public string Comandante { get; set; }

    }
}