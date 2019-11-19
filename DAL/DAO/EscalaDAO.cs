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
        public readonly IAtiradorDAO _atiradorDAO;
        private readonly IMongoContext _context;

        // Método Construtor da classe
        public EscalaDAO(IAtiradorDAO atiradorDAO, IMongoContext context)
        {
            _atiradorDAO = atiradorDAO;
            _context = context;
        }
        
        public void Inserir(Escala escala)
        {
            var qtd = _context.CollectionEscala.Find<Escala>(esc => true).CountDocuments();

            var convert = Convert.ToInt32(qtd);

            var num = convert + 1;
            
            Escala novoEscala = new Escala{
                NumeroEscala = num,
                StatusEscala = false,
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
                StatusEscala = false,
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

        public void ChamadaDiariaEscala(string idEscala, string diaEscala)
        {
            var escala = _context.CollectionEscala.Find<Escala>(u => u.IdEscala == idEscala).FirstOrDefault();
            
            Diaria infoDiariaEscala = obterDiaEscala(idEscala, diaEscala);

            //infoDiariaEscala.ComandanteGuarda

            foreach (var item in infoDiariaEscala.PermanenciaManha)
            {
                
            }
            foreach (var item in infoDiariaEscala.PermanenciaTarde)
            {
                
            }
            foreach (var item in infoDiariaEscala.Guardas)
            {
                
            }
        }

        public Diaria obterDiaEscala(string idEscala, string diaEscala)
        {
            var escala = _context.CollectionEscala.Find<Escala>(u => u.IdEscala == idEscala).FirstOrDefault();

            if(escala.Segunda.DiaEscala == diaEscala){
                return escala.Segunda;
            }
            else if(escala.Terca.DiaEscala == diaEscala){
                return escala.Terca;
            }
            else if(escala.Quarta.DiaEscala == diaEscala){
                return escala.Quarta;
            }
            else if(escala.Quinta.DiaEscala == diaEscala){
                return escala.Quinta;
            }
            else if(escala.Sexta.DiaEscala == diaEscala){
                return escala.Sexta;
            }
            else if(escala.Sabado.DiaEscala == diaEscala){
                return escala.Sabado;
            }
            else {
                return escala.Domingo;
            }
        }
    }
}
