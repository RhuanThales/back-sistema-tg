using System.Collections.Generic;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.BLL
{
    public interface IEscalaBll
    {
        // Create
        void Inserir(Escala escala);
        // Read
        List<Escala> ObterTodos();
        Escala ObterPorId(string id);
        // Update
        void Atualizar(string id, Escala novoEscala);
        // Delete
        void Excluir(string id);
    }
}
