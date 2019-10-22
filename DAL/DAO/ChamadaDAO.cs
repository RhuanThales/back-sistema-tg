using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public class ChamadaDAO : IChamadaDAO
    {
        // Injeção de Dependências
        private readonly IMongoContext _context;

        // Método Construtor da classe
        public ChamadaDAO(IMongoContext context)
        {
            _context = context;
        }
        
        public void Inserir(Chamada chamada)
        {            
            Chamada novaChamada = new Chamada{
                NumeroPelotao = chamada.NumeroPelotao,
                DataChamada = chamada.DataChamada,
                HorarioChamada = chamada.HorarioChamada,
                Usuario = chamada.Usuario,
                AtiradoresPresentes = chamada.AtiradoresPresentes,
                AtiradoresFaltosos = chamada.AtiradoresFaltosos
            };

            _context.CollectionChamada.InsertOne(novaChamada);
        }

        public List<Chamada> ObterTodos()
        {
            var chamadas = _context.CollectionChamada.Find(cha => true).ToList();

            return chamadas;
        }

        public Chamada ObterPorId(string id)
        {
            var chamada = _context.CollectionChamada.Find<Chamada>(c => c.IdChamada == id).FirstOrDefault();

            return chamada;
        }
        public void Atualizar(string id, Chamada novaChamada)
        {
            Chamada chamada = new Chamada{
                IdChamada = id,
                NumeroPelotao = novaChamada.NumeroPelotao,
                DataChamada = novaChamada.DataChamada,
                HorarioChamada = novaChamada.HorarioChamada,
                Usuario = novaChamada.Usuario,
                AtiradoresPresentes = novaChamada.AtiradoresPresentes,
                AtiradoresFaltosos = novaChamada.AtiradoresFaltosos
            };

            _context.CollectionChamada.ReplaceOne(u => u.IdChamada == id, chamada);
        }

        public void Excluir(string id)
        {
            _context.CollectionChamada.DeleteOne(chamada => chamada.IdChamada == id);
        }
    }
}
