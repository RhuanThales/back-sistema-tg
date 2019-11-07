using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public interface IChamadaDAO
    {
        // Create
        void Inserir(Chamada chamada);
        // Read
        List<Chamada> ObterTodos();
        Chamada ObterPorId(string idChamada);
        // Update
        void Atualizar(string idChamada, Chamada novaChamada);
        // Delete
        void Excluir(string idChamada);
        // Métodos de calculo
        void ConfirmarChamada(string idChamada);
    }
}