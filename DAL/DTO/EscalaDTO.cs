using System.Collections.Generic;
using back_sistema_tg.DAL.Models;
using System;

namespace back_sistema_tg.DAL.DTO
{
    public class EscalaDTO
    {
        public string IdEscala { get; set; }
        public int NumeroEscala { get; set; }
        public bool StatusEscala { get; set; }
        public string InstrutorSemana { get; set; }
        public Diaria Segunda { get; set; }
        public Diaria Terca { get; set; }
        public Diaria Quarta { get; set; }
        public Diaria Quinta { get; set; }
        public Diaria Sexta { get; set; }
        public Diaria Sabado { get; set; }
        public Diaria Domingo { get; set; }
    }
}