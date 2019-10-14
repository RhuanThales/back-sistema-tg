using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_sistema_tg.DAL.Models
{
    public class Atirador
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdAtirador { get; set; }

        [BsonElement("CR")]
        public string CR { get; set; }

        [BsonElement("NomeAtirador")]
        public string NomeAtirador { get; set; }
        
        [BsonElement("NumeroPelotao")]
        public int NumeroPelotao { get; set; }

        [BsonElement("NomeGuerra")]
        public string NomeGuerra { get; set; }

        [BsonElement("NumeroAtirador")]
        public int NumeroAtirador { get; set; }

        [BsonElement("Religiao")]
        public string Religiao { get; set; }

        [BsonElement("Escolaridade")]
        public string Escolaridade { get; set; }

        [BsonElement("Volutario")]
        public bool Volutario { get; set; }

        [BsonElement("DataNascimento")]
        public DateTime DataNascimento { get; set; }

        [BsonElement("Naturalidade")]
        public string Naturalidade { get; set; }

        [BsonElement("NaturalidadeCR")]
        public string NaturalidadeCR { get; set; }

        [BsonElement("NomePai")]
        public string NomePai { get; set; }

        [BsonElement("NomeMae")]
        public string NomeMae { get; set; }

        [BsonElement("Telefone")]
        public string Telefone { get; set; }

        [BsonElement("TelefonePai")]
        public string TelefonePai { get; set; }

        [BsonElement("TelefoneMae")]
        public string TelefoneMae { get; set; }

        [BsonElement("CPF")]
        public string CPF { get; set; }

        [BsonElement("Funcao")]
        public string Funcao { get; set; }

        [BsonElement("Logradouro")]
        public string Logradouro { get; set; }
        
        [BsonElement("Bairro")]
        public string Bairro { get; set; }

        [BsonElement("NumeroEndereco")]
        public int NumeroEndereco { get; set; }

        [BsonElement("CEP")]
        public string CEP { get; set; }

        [BsonElement("Cidade")]
        public string Cidade { get; set; }

        [BsonElement("Estado")]
        public string Estado { get; set; }

        [BsonElement("OrgaoEmissor")]
        public string OrgaoEmissor { get; set; }
        
        [BsonElement("NumeroRg")]
        public string NumeroRG { get; set; }

        [BsonElement("Zona")]  
        public string Zona { get; set; }
        
        [BsonElement("NumeroTitulo")] 
        public string NumeroTitulo { get; set; }

        [BsonElement("TotalPontos")]
        public int TotalPontos { get; set; }        
    }
}