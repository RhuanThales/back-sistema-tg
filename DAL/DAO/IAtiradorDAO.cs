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
        List<AtiradorDTO> ObterTodos();
        //Obter os Atiradores por Pelotão
        List<Atirador> ObterPorPelotao(int NumeroPelotao);
        List<Atirador> ObterMonitores();
        List<AtiradorDTO> ObterDesligados();
        Atirador ObterPorId(string id);
        // Update
        void Atualizar(string id, Atirador novoAtirador);
        // Delete
        void Excluir(string id);
        // Métodos de Cálculo
        void Presenca(string [] atiradoresPresentes);
        void PresencaEscala(string atiradorPresente, int peso);
        void Falta(string [] atiradoresFaltosos);
        void FaltaEscala(string atiradorFaltoso, int peso);
        void Justificados(string [] atiradoresJustificados);
        void JustificadosEscala(string atiradorJustificado, int peso);
    }
}
