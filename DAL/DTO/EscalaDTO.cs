using System.Collections.Generic;
using back_sistema_tg.DAL.Models;
using System;

namespace back_sistema_tg.DAL.DTO
{
    public class EscalaDTO
    {
        public string IdEscala { get; set; }
        public string InstrutorDia { get; set; }
        public string [] PermanenciaManha { get; set; }
        public string [] PermanenciaTarde { get; set; }
        public string ComandanteGuarda { get; set; }
        public string [] Guardas { get; set; }
        public DateTime Dia { get; set; }
    }
}