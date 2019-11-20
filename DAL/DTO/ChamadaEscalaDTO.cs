using System;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DTO
{
    public class ChamadaEscalaDTO
    {
        public string IdChamadaEscala { get; set; }
        public bool StatusChamadaEscala { get; set; }
        public string IdEscala { get; set; }
        public string DataChamadaEscala { get; set; }
        public string UsuarioResponsavel { get; set; }
        public string [] AtiradoresPresentesPermanenciaM { get; set; }
        public string [] AtiradoresPresentesPermanenciaT { get; set; }
        public string [] AtiradoresPresentesGuarda { get; set; }
        public string [] AtiradoresFaltososPermanenciaM { get; set; }
        public string [] AtiradoresFaltososPermanenciaT { get; set; }
        public string [] AtiradoresFaltososGuarda { get; set; }
        public string [] AtiradoresJustificadosPermanenciaM { get; set; }
        public string [] AtiradoresJustificadosPermanenciaT { get; set; }
        public string [] AtiradoresJustificadosGuarda { get; set; }
    }
}