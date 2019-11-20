using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_sistema_tg.DAL.Models
{
    public class ChamadaEscala
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdChamadaEscala { get; set; }
        
        [BsonElement("StatusChamadaEscala")]
        public bool StatusChamadaEscala { get; set; }

        [BsonElement("IdEscala")]
        public string IdEscala { get; set; }
        
        [BsonElement("DataChamadaEscala")]
        public string DataChamadaEscala { get; set; }

        [BsonElement("UsuarioResponsavel")]
        public string UsuarioResponsavel { get; set; }

        [BsonElement("AtiradoresPresentesPermanenciaM")]
        public string [] AtiradoresPresentesPermanenciaM { get; set; }

        [BsonElement("AtiradoresPresentesPermanenciaT")]
        public string [] AtiradoresPresentesPermanenciaT { get; set; }

        [BsonElement("AtiradoresPresentesGuarda")]
        public string [] AtiradoresPresentesGuarda { get; set; }
        
        [BsonElement("AtiradoresFaltososPermanenciaM")]
        public string [] AtiradoresFaltososPermanenciaM { get; set; }

        [BsonElement("AtiradoresFaltososPermanenciaT")]
        public string [] AtiradoresFaltososPermanenciaT { get; set; }

        [BsonElement("AtiradoresFaltososGuarda")]
        public string [] AtiradoresFaltososGuarda { get; set; }

        [BsonElement("AtiradoresJustificadosPermanenciaM")]
        public string [] AtiradoresJustificadosPermanenciaM { get; set; }

        [BsonElement("AtiradoresJustificadosPermanenciaT")]
        public string [] AtiradoresJustificadosPermanenciaT { get; set; }

        [BsonElement("AtiradoresJustificadosGuarda")]
        public string [] AtiradoresJustificadosGuarda { get; set; }
    }
}