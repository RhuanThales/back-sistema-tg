using System.Collections.Generic;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.BLL
{
    public interface IChamadaBll
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