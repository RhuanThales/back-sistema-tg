using System;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DTO
{
    public class ChamadaDTO
    {
        public string IdChamada { get; set; }
        public bool StatusChamada { get; set; }
        public int NumeroPelotao { get; set; }
        public string DataChamada { get; set; }
        public string HorarioChamada { get; set; }
        public string Usuario { get; set; }
        public string [] AtiradoresPresentes { get; set; }
        public string [] AtiradoresFaltosos { get; set; }
        public string [] AtiradoresJustificados { get; set; }
    }
}