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
        public readonly IAtiradorDAO _atiradorDAO;
        private readonly IMongoContext _context;

        // Método Construtor da classe
        public ChamadaDAO(IAtiradorDAO atiradorDAO, IMongoContext context)
        {
            _atiradorDAO = atiradorDAO;
            _context = context;
        }
        
        public void Inserir(Chamada chamada)
        {            
            Chamada novaChamada = new Chamada{
                StatusChamada = false,
                NumeroPelotao = chamada.NumeroPelotao,
                DataChamada = chamada.DataChamada,
                HorarioChamada = chamada.HorarioChamada,
                Usuario = chamada.Usuario,
                AtiradoresPresentes = chamada.AtiradoresPresentes,
                AtiradoresFaltosos = chamada.AtiradoresFaltosos,
                AtiradoresJustificados = chamada.AtiradoresJustificados
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
                StatusChamada = false,
                NumeroPelotao = novaChamada.NumeroPelotao,
                DataChamada = novaChamada.DataChamada,
                HorarioChamada = novaChamada.HorarioChamada,
                Usuario = novaChamada.Usuario,
                AtiradoresPresentes = novaChamada.AtiradoresPresentes,
                AtiradoresFaltosos = novaChamada.AtiradoresFaltosos,
                AtiradoresJustificados = novaChamada.AtiradoresJustificados
            };

            _context.CollectionChamada.ReplaceOne(u => u.IdChamada == id, chamada);
        }

        public void Excluir(string id)
        {
            _context.CollectionChamada.DeleteOne(chamada => chamada.IdChamada == id);
        }

        public void ConfirmarChamada(string idChamada)
        {
            var chamada = _context.CollectionChamada.Find<Chamada>(c => c.IdChamada == idChamada).FirstOrDefault();

            _atiradorDAO.Presenca(chamada.AtiradoresPresentes);
            _atiradorDAO.Falta(chamada.AtiradoresFaltosos);
            _atiradorDAO.Justificados(chamada.AtiradoresJustificados);

            _context.CollectionChamada.UpdateOne(ch =>
                ch.IdChamada == chamada.IdChamada,
                Builders<Chamada>.Update.Set(cha => cha.StatusChamada, true),
                new UpdateOptions { IsUpsert = false }
            );
        }
    }
}
