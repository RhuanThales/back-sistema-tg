using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_usuarios_tg.DAL.Models
{
    public class Oficial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("NumeroPelotao")]
        public int NumeroPelotao { get; set; }

        [BsonElement("FuncaoOficial")]
        public string FuncaoOficial { get; set; }

        [BsonElement("ChefeInstrucao")]
        public bool ChefeInstrucao { get; set; }
    }
}