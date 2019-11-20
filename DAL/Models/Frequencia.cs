using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace back_sistema_tg.DAL.Models
{
    public class Frequencia
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdFrequencia { get; set; }
        
        [BsonElement("Data")]
        public string Data { get; set; }

        [BsonElement("Tipo")]
        public string Tipo { get; set; }

        [BsonElement("NomeAtirador")]
        public string NomeAtirador { get; set; }

        [BsonElement("CRAtirador")]
        public string CRAtirador { get; set; }

        [BsonElement("PesoHoras")]
        public int PesoHoras { get; set; }

        [BsonElement("PesoPontos")]
        public int PesoPontos { get; set; }

        [BsonElement("Presenca")]
        public string Presenca { get; set; }
    }
}