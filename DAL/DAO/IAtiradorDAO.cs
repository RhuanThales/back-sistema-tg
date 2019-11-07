using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public interface IAtiradorDAO
    {
        // Create
        void Inserir(Atirador atirador);
        // Read
        List<Atirador> ObterTodos();
        //Obter os Atiradores por Pelotão
        List<Atirador> ObterPorPelotao(int NumeroPelotao);
        List<Atirador> ObterMonitores();
        List<Atirador> ObterDesligados();
        Atirador ObterPorId(string id);
        // Update
        void Atualizar(string id, Atirador novoAtirador);
        // Delete
        void Excluir(string id);
    }
}
