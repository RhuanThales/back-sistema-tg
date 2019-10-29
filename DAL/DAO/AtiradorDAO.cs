using System.Linq;
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
                // Dados Pessoais
                NomeAtirador = atirador.NomeAtirador,
                DataNascimento = atirador.DataNascimento,
                CPF = atirador.CPF,
                RegistroGeral = atirador.RegistroGeral,
                TituloEleitor = atirador.TituloEleitor,
                Naturalidade = atirador.Naturalidade,
                NomePai = atirador.NomePai,
                NomeMae = atirador.NomeMae,
                Religiao = atirador.Religiao,
                Escolaridade = atirador.Escolaridade,

                // Dados de Endereço/Contato
                Endereco = atirador.Endereco,
                Telefone = atirador.Telefone,
                TelefonePai = atirador.TelefonePai,
                TelefoneMae = atirador.TelefoneMae,

                // Dados do Tiro de Guerra
                CR = atirador.CR,
                NaturalidadeCR = atirador.NaturalidadeCR,
                NomeGuerra = atirador.NomeGuerra,
                NumeroAtirador = atirador.NumeroAtirador,
                NumeroPelotao = atirador.NumeroPelotao,
                Funcao = atirador.Funcao,
                Volutario = atirador.Volutario,
                StatusAtirador = false, // False informa que ele não foi desligado do TG
                
                // Dados de Pontuação
                PontosJustificados = 0,
                PontosNaoJustificados = 0,
                TotalPontos = 0,

                // Dados de Horas/Tempo de Serviço
                HorasCfc = 0,
                HorasInstrucao = 0,
                HorasExtras = 0,
                HorasServico = 0,
                TotalHoras = 0,
                TotalDias = 0,
            };

            _context.CollectionAtirador.InsertOne(novoAtirador);
        }

        public List<Atirador> ObterTodos()
        {
            var colecaoAtirador = _context.CollectionAtirador.Find(atirador => atirador.StatusAtirador == false).ToList();

            return colecaoAtirador.OrderBy(a => a.NumeroAtirador).ToList();
        }
         public List<Atirador> ObterPorPelotao(int NumeroPelotao)
        {
            var pelotaoAtirador = _context.CollectionAtirador.Find<Atirador>(num => num.NumeroPelotao == NumeroPelotao && num.StatusAtirador == false).ToList();

            return pelotaoAtirador.OrderBy(a => a.NumeroAtirador).ToList();
        }

         public List<Atirador> ObterMonitores()
        {
            var monitorAtirador = _context.CollectionAtirador.Find<Atirador>(func => func.Funcao == "Monitor" && func.StatusAtirador == false).ToList();

            return monitorAtirador.OrderBy(a => a.NumeroAtirador).ToList();
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
                // Dados Pessoais
                NomeAtirador = novoAtirador.NomeAtirador,
                DataNascimento = novoAtirador.DataNascimento,
                CPF = novoAtirador.CPF,
                RegistroGeral = novoAtirador.RegistroGeral,
                TituloEleitor = novoAtirador.TituloEleitor,
                Naturalidade = novoAtirador.Naturalidade,
                NomePai = novoAtirador.NomePai,
                NomeMae = novoAtirador.NomeMae,
                Religiao = novoAtirador.Religiao,
                Escolaridade = novoAtirador.Escolaridade,

                // Dados de Endereço/Contato
                Endereco = novoAtirador.Endereco,
                Telefone = novoAtirador.Telefone,
                TelefonePai = novoAtirador.TelefonePai,
                TelefoneMae = novoAtirador.TelefoneMae,

                // Dados do Tiro de Guerra
                CR = novoAtirador.CR,
                NaturalidadeCR = novoAtirador.NaturalidadeCR,
                NomeGuerra = novoAtirador.NomeGuerra,
                NumeroAtirador = novoAtirador.NumeroAtirador,
                NumeroPelotao = novoAtirador.NumeroPelotao,
                Funcao = novoAtirador.Funcao,
                Volutario = novoAtirador.Volutario,
                StatusAtirador = novoAtirador.StatusAtirador,
                
                // Dados de Pontuação
                PontosJustificados = novoAtirador.PontosJustificados,
                PontosNaoJustificados = novoAtirador.PontosNaoJustificados,
                TotalPontos = novoAtirador.TotalPontos,

                // Dados de Horas/Tempo de Serviço
                HorasCfc = novoAtirador.HorasCfc,
                HorasInstrucao = novoAtirador.HorasInstrucao,
                HorasExtras = novoAtirador.HorasExtras,
                HorasServico = novoAtirador.HorasServico,
                TotalHoras = novoAtirador.TotalHoras,
                TotalDias = novoAtirador.TotalDias,
            };

            _context.CollectionAtirador.ReplaceOne(u => u.IdAtirador == id, atirador);
        }

        public void Excluir(string id)
        {
            _context.CollectionAtirador.DeleteOne(atirador => atirador.IdAtirador == id);
        }
    }
}
