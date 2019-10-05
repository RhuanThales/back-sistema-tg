using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public class AtiradorDAO : IAtiradorDAO
    {
        // Injeção de Dependências
        private readonly IMongoContext _context;

        // Método Construtor da classe
        public AtiradorDAO(IMongoContext context)
        {
            _context = context;
        }
        
        public void Inserir(Atirador atirador)
        {
            Atirador novoAtirador = new Atirador{
                CR = atirador.CR,
                NomeAtirador = atirador.NomeAtirador,
                NumeroPelotao = atirador.NumeroPelotao,
                NomeGuerra = atirador.NomeGuerra,
                NumeroAtirador = atirador.NumeroAtirador,
                Religiao = atirador.Religiao,
                Escolaridade = atirador.Escolaridade,
                Volutario = atirador.Volutario,
                DataNascimento = atirador.DataNascimento,
                Naturalidade = atirador.Naturalidade,
                NaturalidadeCR = atirador.NaturalidadeCR,
                NomePai = atirador.NomePai,
                NomeMae = atirador.NomeMae,
                Endereco = atirador.Endereco,
                Telefones = atirador.Telefones,
                TelefonePai = atirador.TelefonePai,
                TelefoneMae = atirador.TelefoneMae,
                RG = atirador.RG,
                CPF = atirador.CPF,
                TituloEleitor = atirador.TituloEleitor,
                Funcao = atirador.Funcao,
                TotalPontos = atirador.TotalPontos
            };

            _context.CollectionAtirador.InsertOne(novoAtirador);
        }

        public List<Atirador> ObterTodos()
        {
            var colecaoAtirador = _context.CollectionAtirador.Find(atirador => true).ToList();

            return colecaoAtirador;
        }

        public Atirador ObterPorId(string id)
        {
            var atirador = _context.CollectionAtirador.Find<Atirador>(u => u.IdAtirador == id).FirstOrDefault();

            return atirador;
        }

        public void Atualizar(string id, Atirador novoAtirador)
        {
            Atirador atirador = new Atirador{
                IdAtirador = id,
                CR = novoAtirador.CR,
                NomeAtirador = novoAtirador.NomeAtirador,
                NumeroPelotao = novoAtirador.NumeroPelotao,
                NomeGuerra = novoAtirador.NomeGuerra,
                NumeroAtirador = novoAtirador.NumeroAtirador,
                Religiao = novoAtirador.Religiao,
                Escolaridade = novoAtirador.Escolaridade,
                Volutario = novoAtirador.Volutario,
                DataNascimento = novoAtirador.DataNascimento,
                Naturalidade = novoAtirador.Naturalidade,
                NaturalidadeCR = novoAtirador.NaturalidadeCR,
                NomePai = novoAtirador.NomePai,
                NomeMae = novoAtirador.NomeMae,
                Endereco = novoAtirador.Endereco,
                Telefones = novoAtirador.Telefones,
                TelefonePai = novoAtirador.TelefonePai,
                TelefoneMae = novoAtirador.TelefoneMae,
                RG = novoAtirador.RG,
                CPF = novoAtirador.CPF,
                TituloEleitor = novoAtirador.TituloEleitor,
                Funcao = novoAtirador.Funcao,
                TotalPontos = novoAtirador.TotalPontos
            };

            _context.CollectionAtirador.ReplaceOne(u => u.IdAtirador == id, atirador);
        }

        public void Excluir(string id)
        {
            _context.CollectionAtirador.DeleteOne(atirador => atirador.IdAtirador == id);
        }
    }
}
