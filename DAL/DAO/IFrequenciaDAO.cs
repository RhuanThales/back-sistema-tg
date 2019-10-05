using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public interface IFrequenciaDAO
    {
        // Create
        void Inserir(Frequencia frequencia);
        // Read
        List<Frequencia> ObterTodos();
        Frequencia ObterPorId(string id);
        // Update
        void Atualizar(string id, Frequencia novaFrequencia);
        // Delete
        void Excluir(string id);
    }
}
