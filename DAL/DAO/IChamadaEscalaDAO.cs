using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public interface IChamadaEscalaDAO
    {
        // Create
        void InserirChamadaEscala(ChamadaEscala chamada);
        // Read
        List<ChamadaEscala> ObterTodasChamadasEscala(string idEscala);
        ChamadaEscala ObterPorId(string idChamada);
        // Update
        void AtualizarChamadaEscala(string idChamada, ChamadaEscala novaChamada);
        // Delete
        // Não há método para deletar pois não será permitido
        // Métodos de calculo de horas e pontos
        void ConfirmarChamadaEscala(string idChamada);
    }
}