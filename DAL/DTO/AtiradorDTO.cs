using System;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DTO
{
    public class AtiradorDTO
    {
        public string IdAtirador { get; set; }

        // Dados Pessoais
        public string NomeAtirador { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public RegistroGeral RegistroGeral { get; set; }
        public TituloEleitor TituloEleitor { get; set; }
        public string Naturalidade { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public string Religiao { get; set; }
        public string Escolaridade { get; set; }
        
        // Dados Pessoais de Endereço/Contato
        public EnderecoCompleto Endereco { get; set; }
        public string Telefone { get; set; }
        public string TelefonePai { get; set; }
        public string TelefoneMae { get; set; }
 
        // Dados do Tiro de Guerra
        public string CR { get; set; }
        public string NaturalidadeCR { get; set; } // Naturalidade da Certidão de Reservista
        public string NomeGuerra { get; set; }
        public int NumeroAtirador { get; set; }
        public int NumeroPelotao { get; set; }
        public string Funcao { get; set; } // A unica função até o momento é a de Monitor
        public bool Volutario { get; set; } // Se é ou não voluntario pro tg
        public bool StatusAtirador { get; set; }  // Indica se ele foi desligado do tg (true) ou se ainda está no tg (false)

        // Dados de Pontuação
        public int PontosJustificados { get; set; }
        public int PontosNaoJustificados { get; set; }
        public int TotalPontos { get; set; } // Soma dos pontos justificados e não justificados
        
        // Dados de Horas/Tempo de Serviço
        public int HorasCfc { get; set; }
        public int HorasInstrucao { get; set; }
        public int HorasExtras { get; set; }
        public int HorasServico { get; set; }
        public int TotalHoras { get; set; } // Soma de todos os valores dos atributos de horas
        public int TotalDias { get; set; } // Divide-se o total de horas por 8
    }
}