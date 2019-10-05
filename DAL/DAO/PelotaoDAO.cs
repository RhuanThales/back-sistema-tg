using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public class PelotaoDAO : IPelotaoDAO
    {
            
        // Injeção de Dependências
        private readonly IMongoContext _context;

        // Método Construtor da classe
        public PelotaoDAO(IMongoContext context)
        {
            _context = context;
        }

        
        public void Inserir(Pelotao pelotao)
        {
            Pelotao novoPelotao = new Pelotao{
                NomePelotao = pelotao.NomePelotao,
                NumeroPelotao = pelotao.NumeroPelotao,
                Comandante = pelotao.Comandante,
                Monitor = pelotao.Monitor
                
            };

            _context.CollectionPelotao.InsertOne(novoPelotao);
        }

        public List<Pelotao> ObterTodos()
        {
            var colecaoPelotao = _context.CollectionPelotao.Find(Pelotao => true).ToList();

            return colecaoPelotao;
        }

        public Pelotao ObterPorId(string id)
        {
            var Pelotao = _context.CollectionPelotao.Find<Pelotao>(u => u.IdPelotao == id).FirstOrDefault();

            return Pelotao;
        }


        public void Atualizar(string id, Pelotao novoPelotao)
        {
            Pelotao pelotao = new Pelotao{
                IdPelotao = novoPelotao.IdPelotao,
                NomePelotao = novoPelotao.NomePelotao,
                NumeroPelotao = novoPelotao.NumeroPelotao,
                Comandante = novoPelotao.Comandante,
                Monitor = novoPelotao.Monitor

            };

            _context.CollectionPelotao.ReplaceOne(u => u.IdPelotao == id, pelotao);
        }

        public void Excluir(string id)
        {
            _context.CollectionPelotao.DeleteOne(pelotao => pelotao.IdPelotao == id);
        }

    }
    
}