using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public interface IFrequenciaDAO
    {
        // Create
        void Inserir(Frequencia frequencia);
        void InserirFrequencia(string data, string tipo, string crAtirador, int horas, int pontos, string presenca);
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
