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

        // Dados Pessoais
        [BsonElement("NomeAtirador")]
        public string NomeAtirador { get; set; }

        [BsonElement("DataNascimento")]
        public string DataNascimento { get; set; }
        
        [BsonElement("CPF")]
        public string CPF { get; set; }

        [BsonElement("RegistroGeral")]
        public RegistroGeral RegistroGeral { get; set; }

        [BsonElement("TituloEleitor")]
        public TituloEleitor TituloEleitor { get; set; }

        [BsonElement("Naturalidade")]
        public string Naturalidade { get; set; }
        
        [BsonElement("NomePai")]
        public string NomePai { get; set; }

        [BsonElement("NomeMae")]
        public string NomeMae { get; set; }

        [BsonElement("Religiao")]
        public string Religiao { get; set; }

        [BsonElement("Escolaridade")]
        public string Escolaridade { get; set; }
        
        // Dados Pessoais de Endereço/Contato
        [BsonElement("Endereco")]
        public EnderecoCompleto Endereco { get; set; }
        
        [BsonElement("Telefone")]
        public string Telefone { get; set; }

        [BsonElement("TelefonePai")]
        public string TelefonePai { get; set; }

        [BsonElement("TelefoneMae")]
        public string TelefoneMae { get; set; }
 
        // Dados do Tiro de Guerra
        [BsonElement("CR")]
        public string CR { get; set; }

        [BsonElement("NaturalidadeCR")]
        public string NaturalidadeCR { get; set; } // Naturalidade da Certidão de Reservista

        [BsonElement("NomeGuerra")]
        public string NomeGuerra { get; set; }

        [BsonElement("NumeroAtirador")]
        public int NumeroAtirador { get; set; }
        
        [BsonElement("NumeroPelotao")]
        public int NumeroPelotao { get; set; }

        [BsonElement("Funcao")]
        public string Funcao { get; set; } // A unica função até o momento é a de Monitor

        [BsonElement("Volutario")]
        public bool Volutario { get; set; } // Se é ou não voluntario pro tg

        [BsonElement("StatusAtirador")]
        public bool StatusAtirador { get; set; }  // Indica se ele foi desligado do tg (true) ou se ainda está no tg (false)

        // Dados de Pontuação
        [BsonElement("PontosJustificados")]
        public int PontosJustificados { get; set; }

        [BsonElement("PontosNaoJustificados")]
        public int PontosNaoJustificados { get; set; }

        /* [BsonElement("TotalPontos")]
        public int TotalPontos { get; set; } */

        // Dados de Horas/Tempo de Serviço
        [BsonElement("HorasCfc")]
        public int HorasCfc { get; set; }

        [BsonElement("HorasInstrucao")]
        public int HorasInstrucao { get; set; }

        [BsonElement("HorasExtras")]
        public int HorasExtras { get; set; }

        [BsonElement("HorasServico")]
        public int HorasServico { get; set; }

        /* [BsonElement("TotalHoras")]
        public int TotalHoras { get; set; } */

        /* [BsonElement("TotalDias")]
        public int TotalDias { get; set; } */
    }
}