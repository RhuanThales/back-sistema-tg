using System;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DTO
{
    public class AtiradorDTO
    {
        public string IdAtirador { get; set; }
        public string CR { get; set; }
        public string NomeAtirador { get; set; }
        public int NumeroPelotao { get; set; }
        public string NomeGuerra { get; set; }
        public int NumeroAtirador { get; set; }
        public string Religiao { get; set; }
        public string Escolaridade { get; set; }
        public bool Volutario { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Naturalidade { get; set; }
        public string NaturalidadeCR { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public string Telefone { get; set; }
        public string TelefonePai { get; set; }
        public string TelefoneMae { get; set; }
        public string CPF { get; set; }
        public string Funcao { get; set; }
        public EnderecoCompleto Endereco { get; set; }
        public RegistroGeral RegistroGeral { get; set; }
        public TituloEleitor TituloEleitor { get; set; }
        public bool StatusAtirador { get; set; }
        public int TotalPontos { get; set; }
        public int TotalHoras { get; set; }
    }
}