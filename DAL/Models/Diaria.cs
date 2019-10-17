using System;

namespace back_sistema_tg.DAL.Models
{
    public class Diaria
    {
        public string [] PermanenciaManha { get; set; }
        public string [] PermanenciaTarde { get; set; }
        public string ComandanteGuarda { get; set; }
        public string [] Guardas { get; set; }
        public DateTime Dia { get; set; }
    }
}