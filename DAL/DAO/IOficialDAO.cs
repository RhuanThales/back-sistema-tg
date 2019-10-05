using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public interface IOficialDAO
    {
        // Create
        void Inserir(Oficial oficial);
        // Read
        List<Oficial> ObterTodos();
        Oficial ObterPorId(string id);
        // Update
        void Atualizar(string id, Oficial novoOficial);
        // Delete
        void Excluir(string id);
    }
}