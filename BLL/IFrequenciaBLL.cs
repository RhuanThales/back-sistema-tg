using System.Collections.Generic;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.BLL
{
    public interface IFrequenciabll
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