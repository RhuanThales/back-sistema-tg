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
            Escala novoEscala = new Escala{
                InstrutorDia = escala.InstrutorDia,
                PermanenciaManha = escala.PermanenciaManha,
                PermanenciaTarde = escala.PermanenciaTarde,
                ComandanteGuarda = escala.ComandanteGuarda,
                Guardas = escala.Guardas,
                Dia = escala.Dia

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
        public void Atualizar(string id, Escala novoEscala)
        {
            Escala escala = new Escala{
                IdEscala = id,
                InstrutorDia = novoEscala.InstrutorDia,
                PermanenciaManha = novoEscala.PermanenciaManha,
                PermanenciaTarde = novoEscala.PermanenciaTarde,
                ComandanteGuarda = novoEscala.ComandanteGuarda,
                Guardas = novoEscala.Guardas,
                Dia = novoEscala.Dia
            };

            _context.CollectionEscala.ReplaceOne(u => u.IdEscala == id, escala);
        }

        public void Excluir(string id)
        {
            _context.CollectionEscala.DeleteOne(escala => escala.IdEscala == id);
        }
    }
}
