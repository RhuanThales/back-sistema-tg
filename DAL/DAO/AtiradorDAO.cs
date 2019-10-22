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
                Telefone = atirador.Telefone,
                TelefonePai = atirador.TelefonePai,
                TelefoneMae = atirador.TelefoneMae,
                CPF = atirador.CPF,
                Funcao = atirador.Funcao,
                Endereco = atirador.Endereco,
                RegistroGeral = atirador.RegistroGeral,
                TituloEleitor = atirador.TituloEleitor,
                StatusAtirador = false,
                TotalPontos = 0,
                TotalHoras = 0,
            };

            _context.CollectionAtirador.InsertOne(novoAtirador);
        }

        public List<Atirador> ObterTodos()
        {
            var colecaoAtirador = _context.CollectionAtirador.Find(atirador => atirador.StatusAtirador == false).ToList();

            return colecaoAtirador;
        }
         public List<Atirador> ObterPorPelotao(int NumeroPelotao)
        {
            var pelotaoAtirador = _context.CollectionAtirador.Find<Atirador>(num => num.NumeroPelotao == NumeroPelotao && num.StatusAtirador == false).ToList();

            return pelotaoAtirador;
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
                Telefone = novoAtirador.Telefone,
                TelefonePai = novoAtirador.TelefonePai,
                CPF = novoAtirador.CPF,
                Funcao = novoAtirador.Funcao,
                Endereco = novoAtirador.Endereco,
                RegistroGeral = novoAtirador.RegistroGeral,
                TituloEleitor = novoAtirador.TituloEleitor,
                StatusAtirador = novoAtirador.StatusAtirador,
                TotalPontos = novoAtirador.TotalPontos,
                TotalHoras = novoAtirador.TotalHoras
            };

            _context.CollectionAtirador.ReplaceOne(u => u.IdAtirador == id, atirador);
        }

        public void Excluir(string id)
        {
            _context.CollectionAtirador.DeleteOne(atirador => atirador.IdAtirador == id);
        }
    }
}
