using System.Collections.Generic;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.BLL.Exceptions
{
    public interface IOficialBll
    {
         // Create
        void Inserir(Oficial oficial);
        // Read
        List<Oficial> ObterTodos();
        Oficial ObterPorId(string IdOficial);
        Oficial ObterChefeInstrucao();
        // Update
        void Atualizar(string id, Oficial novoOficial);
        // Delete
        void Excluir(string id);
    }
}