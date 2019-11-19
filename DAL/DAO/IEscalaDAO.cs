using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public interface IEscalaDAO
    {
        // Create
        void Inserir(Escala escala);
        // Read
        List<Escala> ObterTodos();
        Escala ObterPorId(string idEscala);
        // Update
        void Atualizar(string idEscala, Escala novoEscala);
        // Delete
        void Excluir(string idEscala);
        // Métodos de calculo
        void ChamadaDiariaEscala(string idEscala, string diaEscala);
    }
}
