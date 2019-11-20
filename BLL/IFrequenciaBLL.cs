using System.Collections.Generic;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.BLL
{
    public interface IFrequenciaBll
    {
        // Create
        void Inserir(Frequencia frequencia);
        // Read
        List<Frequencia> ObterTodos();
        List<Frequencia> ObterFrequenciasPorAtirador(string crAtirador);
        Frequencia ObterPorId(string id);
        // Update
        void Atualizar(string id, Frequencia novaFrequencia);
        // Delete
        void Excluir(string id);
    } 
    
}