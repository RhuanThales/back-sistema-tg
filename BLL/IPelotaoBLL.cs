using System.Collections.Generic;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.BLL
{
    public interface IPelotaoBll
    {
         // Create
        void Inserir(Pelotao pelotao);
        // Read
        List<Pelotao> ObterTodos();
        Pelotao ObterPorId(string IdPelotao);
        // Update
        void Atualizar(string id, Pelotao novoPelotao);
        // Delete
        void Excluir(string id);
    }
}