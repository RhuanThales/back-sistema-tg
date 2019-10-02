using System.Collections.Generic;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DTO
{
    public class EscalaDTO
    {
        public string IdEscala { get; set; }
        public string InstrutorDia { get; set; }
        public List<Atirador> PermanenciaManha { get; set; }
        public List<Atirador> PermanenciaTarde { get; set; }
        public string ComandanteGuarda { get; set; }
        public List<Atirador> Guardas { get; set; }
    }
}