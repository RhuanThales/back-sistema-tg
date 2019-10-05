using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_sistema_tg.DAL.Models
{
    public class Oficial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdOficial { get; set; }
        
        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("NumeroPelotao")]
        public int NumeroPelotao { get; set; }

        [BsonElement("Patente")]
        public string Patente { get; set; }
        
        [BsonElement("FuncaoOficial")]
        public string FuncaoOficial { get; set; }

        [BsonElement("ChefeInstrucao")]
        public bool ChefeInstrucao { get; set; }
    }
}