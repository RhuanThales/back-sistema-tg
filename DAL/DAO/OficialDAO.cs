using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public class OficialDAO : IOficialDAO
    {
        // Injeção de Dependências
        private readonly IMongoContext _context;

        // Método Construtor da classe
        public OficialDAO(IMongoContext context)
        {
            _context = context;
        }

        
        public void Inserir(Oficial oficial)
        {
            Oficial novoOficial = new Oficial{
                Nome = oficial.Nome,
                NumeroPelotao = oficial.NumeroPelotao,
                Patente = oficial.Patente,
                FuncaoOficial = oficial.FuncaoOficial,
                ChefeInstrucao = oficial.ChefeInstrucao
            };

            _context.CollectionOficial.InsertOne(novoOficial);
        }

        public List<Oficial> ObterTodos()
        {
            var colecaoOficial = _context.CollectionOficial.Find(Oficial => true).ToList();

            return colecaoOficial;
        }

        public Oficial ObterPorId(string id)
        {
            var Oficial = _context.CollectionOficial.Find<Oficial>(u => u.IdOficial == id).FirstOrDefault();

            return Oficial;
        }

        public Oficial ObterChefeInstrucao()
        {
            var Oficial = _context.CollectionOficial.Find<Oficial>(u => u.ChefeInstrucao == true).FirstOrDefault();

            return Oficial;
        }

        public void Atualizar(string id, Oficial novoOficial)
        {
            Oficial oficial = new Oficial{
               IdOficial = novoOficial.IdOficial,
                Nome = novoOficial.Nome,
                NumeroPelotao = novoOficial.NumeroPelotao,
                Patente = novoOficial.Patente,
                FuncaoOficial = novoOficial.FuncaoOficial,
                ChefeInstrucao = novoOficial.ChefeInstrucao

            };

            _context.CollectionOficial.ReplaceOne(u => u.IdOficial == id, oficial);
        }

        public void Excluir(string id)
        {
            _context.CollectionOficial.DeleteOne(oficial => oficial.IdOficial == id);
        }

    }
}