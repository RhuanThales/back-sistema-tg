using MongoDB.Bson;
using System;
using MongoDB.Bson.Serialization.Attributes;

namespace back_sistema_tg.DAL.Models
{
    public class Atirador
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("NomeAtirador")]
        public string NomeAtirador{get;set;}
        
        [BsonElement("NumeroPelotao")]
        public int NumeroPelotao{get;set;}

        [BsonElement("NomeGuerra")]
        public string NomeGuerra{get;set;}

         [BsonElement("NumeroAtirador")]
        public string NumeroAtirador{get;set;}

         [BsonElement("Religiao")]
        public string Religiao{get;set;}

        [BsonElement("Escolaridade")]
        public string Escolaridade{get;set;}

        [BsonElement("Volutario")]
        public bool Volutario{get;set;}

        [BsonElement("DataNascimento")]
        public DateTime DataNascimento{get;set;}

        [BsonElement("Naturalidade")]
        public string Naturalidade{get;set;}

        [BsonElement("NaturalidadeCR")]
        public string NaturalidadeCR{get;set;}

        [BsonElement("NomePai")]
        public string NomePai{get;set;}

        [BsonElement("NomeMae")]
        public string NomeMae{get;set;}

        [BsonElement("CEP")]
        public string CEP{get;set;}

        [BsonElement("Endereco")]
        public string Endereco{get;set;}

        [BsonElement("Telefones")]
        public string Telefones{get;set;}

        [BsonElement("TelefonePai")]
        public string TelefonePai{get;set;}

        [BsonElement("TelefoneMae")]
        public string TelefoneMae{get;set;}

        [BsonElement("RG")]
        public string RG{get;set;}

        [BsonElement("OrgaoEmissor")]
        public string OrgaoEmissor{get;set;}

        [BsonElement("CPF")]
        public string CPF{get;set;}

        [BsonElement("TituloEleitor")]
        public string TituloEleitor{get;set;}

         [BsonElement("Funcao")]
        public string Funcao{get;set;}
    }
}