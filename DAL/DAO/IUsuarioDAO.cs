using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public interface IUsuarioDAO
    {
        // Create
        void Inserir(Usuario usuario);
        // Read
        List<Usuario> ObterTodos();
        Usuario ObterPorId(string id);
        Usuario ObterPorLogin(string login);
        // Update
        void Atualizar(string id, Usuario novoUsuario);
        // Delete
        void Excluir(string id);
    }
}
