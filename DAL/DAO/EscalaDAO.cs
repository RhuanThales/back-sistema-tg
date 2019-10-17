using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public class EscalaDAO : IEscalaDAO
    {
        // Injeção de Dependências
        private readonly IMongoContext _context;

        // Método Construtor da classe
        public EscalaDAO(IMongoContext context)
        {
            _context = context;
        }
        
        public void Inserir(Escala escala)
        {
            var qtd = _context.CollectionEscala.Find<Escala>(esc => true).CountDocuments();

            var convert = Convert.ToInt32(qtd);

            var num = convert + 1;
            
            Escala novoEscala = new Escala{
                NumeroEscala = num,
                InstrutorSemana = escala.InstrutorSemana,
                Segunda = escala.Segunda,
                Terca = escala.Terca,
                Quarta = escala.Quarta,
                Quinta = escala.Quinta,
                Sexta = escala.Sexta,
                Sabado = escala.Sabado,
                Domingo = escala.Domingo
            };

            _context.CollectionEscala.InsertOne(novoEscala);
        }

        public List<Escala> ObterTodos()
        {
            var colecaoEscala = _context.CollectionEscala.Find(escala => true).ToList();

            return colecaoEscala;
        }

        public Escala ObterPorId(string id)
        {
            var escala = _context.CollectionEscala.Find<Escala>(u => u.IdEscala == id).FirstOrDefault();

            return escala;
        }
        public void Atualizar(string id, Escala novaEscala)
        {
            Escala escala = new Escala{
                IdEscala = id,
                NumeroEscala = novaEscala.NumeroEscala,
                InstrutorSemana = novaEscala.InstrutorSemana,
                Segunda = novaEscala.Segunda,
                Terca = novaEscala.Terca,
                Quarta = novaEscala.Quarta,
                Quinta = novaEscala.Quinta,
                Sexta = novaEscala.Sexta,
                Sabado = novaEscala.Sabado,
                Domingo = novaEscala.Domingo
            };

            _context.CollectionEscala.ReplaceOne(u => u.IdEscala == id, escala);
        }

        public void Excluir(string id)
        {
            _context.CollectionEscala.DeleteOne(escala => escala.IdEscala == id);
        }
    }
}
