using System;

namespace back_sistema_tg.DAL.DTO
{
    public class FrequenciaDTO
    {
        public string IdFrequencia { get; set; }
        public string Data { get; set; }
        public string Tipo { get; set; }
        public string NomeAtirador { get; set; }
        public string CRAtirador { get; set; }
        public int PesoHoras { get; set; }
        public int PesoPontos { get; set; }
        public string Presenca { get; set; }
    }
}