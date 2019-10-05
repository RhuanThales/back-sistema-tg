using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_sistema_tg.DAL.Models
{
    public class TituloEleitor
    {
        public string Zona { get; set; }
        public string Numero { get; set; }
    }
}