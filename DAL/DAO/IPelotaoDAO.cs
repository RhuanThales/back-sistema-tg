using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public interface IPelotaoDAO
    {
        // Create
        void Inserir(Pelotao pelotao);
        // Read
        List<Pelotao> ObterTodos();
        Pelotao ObterPorId(string id);
        // Update
        void Atualizar(string id, Pelotao novoPelotao);
        // Delete
        void Excluir(string id);
    }
}