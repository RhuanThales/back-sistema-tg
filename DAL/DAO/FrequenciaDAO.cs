using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public class FrequenciaDAO:IFrequenciaDAO
    {
        private readonly IMongoContext _context;

        // Método Construtor da classe
        public FrequenciaDAO(IMongoContext context)
        {
            _context = context;
        }
        
        public void Inserir(Frequencia frequencia)
        {
            Frequencia novaFrequencia = new Frequencia{
                Data = frequencia.Data,
                Tipo = frequencia.Tipo,
                NomeAtirador = frequencia.NomeAtirador,
                CRAtirador = frequencia.CRAtirador,
                PesoHoras = frequencia.PesoHoras,
                PesoPontos = frequencia.PesoPontos,
                Presenca = frequencia.Presenca
            };

            _context.CollectionFrequencia.InsertOne(novaFrequencia);
        }

        public void InserirFrequencia(string data, string tipo, string crAtirador, int horas, int pontos, string presenca)
        {
            var atirador = _context.CollectionAtirador.Find<Atirador>(a => a.CR == crAtirador).FirstOrDefault();
            
            Frequencia novaFrequencia = new Frequencia{
                Data = data,
                Tipo = tipo,
                NomeAtirador = atirador.NomeAtirador,
                CRAtirador = crAtirador,
                PesoHoras = horas,
                PesoPontos = pontos,
                Presenca = presenca
            };

            _context.CollectionFrequencia.InsertOne(novaFrequencia);
        }

        public List<Frequencia> ObterTodos()
        {
            var colecaoFrequencia = _context.CollectionFrequencia.Find(frequencia => true).ToList();

            return colecaoFrequencia;
        }

        public List<Frequencia> ObterFrequenciasPorAtirador(string crAtirador)
        {
            var colecaoFrequencia = _context.CollectionFrequencia.Find(frequencia => frequencia.CRAtirador == crAtirador).ToList();

            return colecaoFrequencia;
        }

        public Frequencia ObterPorId(string id)
        {
            var frequencia = _context.CollectionFrequencia.Find<Frequencia>(u => u.IdFrequencia == id).FirstOrDefault();

            return frequencia;
        }
        public void Atualizar(string id, Frequencia novaFrequencia)
        {
            Frequencia frequencia = new Frequencia{
                IdFrequencia = id,
                Data = novaFrequencia.Data,
                Tipo = novaFrequencia.Tipo,
                NomeAtirador = novaFrequencia.NomeAtirador,
                CRAtirador = novaFrequencia.CRAtirador,
                PesoHoras = novaFrequencia.PesoHoras,
                Presenca = novaFrequencia.Presenca
            };

            _context.CollectionFrequencia.ReplaceOne(u => u.IdFrequencia == id, frequencia);
        }

        public void Excluir(string id)
        {
            _context.CollectionFrequencia.DeleteOne(frequencia => frequencia.IdFrequencia == id);
        }
    }  
}
