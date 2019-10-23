using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_sistema_tg.DAL.Models
{
    public class Chamada
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdChamada { get; set; }
        
        [BsonElement("NumeroPelotao")]
        public int NumeroPelotao { get; set; }
        
        [BsonElement("DataChamada")]
        public string DataChamada { get; set; }

        [BsonElement("HorarioChamada")]
        public string HorarioChamada { get; set; }

        [BsonElement("Usuario")]
        public string Usuario { get; set; }

        [BsonElement("AtiradoresPresentes")]
        public string [] AtiradoresPresentes { get; set; }
        
        [BsonElement("AtiradoresFaltosos")]
        public string [] AtiradoresFaltosos { get; set; }

        [BsonElement("AtiradoresJustificados")]
        public string [] AtiradoresJustificados { get; set; }
    }
}