using back_sistema_tg.DAL.Models;
namespace back_sistema_tg.DAL.DTO
{
    public class EscalaDTO
    {
        public string Id {get; set;}

        public string InstrutorDia { get; set; }

      
        public Atirador PermanenciaManha { get; set; }

  
        public Atirador PermanenciaTarde { get; set; }

   
        public string ComandanteGuarda { get; set; }

        public Atirador Guardas { get; set; }
        
    }
}