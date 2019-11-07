using System.Collections.Generic;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.BLL
{
    public interface IAtiradorBll
    {
        // Create
        void Inserir(Atirador atirador);
        // Read
        List<AtiradorDTO> ObterTodos();
        Atirador ObterPorId(string IdAtirador);
        List<Atirador> ObterPorPelotao(int NumeroPelotao);
        List<Atirador> ObterMonitores();
        List<AtiradorDTO> ObterDesligados();
        // Update
        void Atualizar(string id, Atirador novoAtirador);
        // Delete
        void Excluir(string id);
    }
}
