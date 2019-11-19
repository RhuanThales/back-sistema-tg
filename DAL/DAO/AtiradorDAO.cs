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
                // TotalPontos = 0,

                // Dados de Horas/Tempo de Serviço
                HorasCfc = 0,
                HorasInstrucao = 0,
                HorasExtras = 0,
                HorasServico = 0,
                // TotalHoras = 0,
                // TotalDias = 0,
            };

            _context.CollectionAtirador.InsertOne(novoAtirador);
        }

        public List<AtiradorDTO> ObterTodos()
        {
            List<AtiradorDTO> atiradores = new List<AtiradorDTO>();
            
            var colecaoAtirador = _context.CollectionAtirador.Find(atirador => atirador.StatusAtirador == false).ToList();

            foreach (var item in colecaoAtirador)
            {
                var pontosTotais = item.PontosJustificados + item.PontosNaoJustificados;
                var horasTotais = item.HorasCfc + item.HorasInstrucao + item.HorasExtras + item.HorasServico;
                
                AtiradorDTO at = new AtiradorDTO{    
                    IdAtirador = item.IdAtirador,
                    // Dados Pessoais
                    NomeAtirador = item.NomeAtirador,
                    DataNascimento = item.DataNascimento,
                    CPF = item.CPF,
                    RegistroGeral = item.RegistroGeral,
                    TituloEleitor = item.TituloEleitor,
                    Naturalidade = item.Naturalidade,
                    NomePai = item.NomePai,
                    NomeMae = item.NomeMae,
                    Religiao = item.Religiao,
                    Escolaridade = item.Escolaridade,

                    // Dados de Endereço/Contato
                    Endereco = item.Endereco,
                    Telefone = item.Telefone,
                    TelefonePai = item.TelefonePai,
                    TelefoneMae = item.TelefoneMae,

                    // Dados do Tiro de Guerra
                    CR = item.CR,
                    NaturalidadeCR = item.NaturalidadeCR,
                    NomeGuerra = item.NomeGuerra,
                    NumeroAtirador = item.NumeroAtirador,
                    NumeroPelotao = item.NumeroPelotao,
                    Funcao = item.Funcao,
                    Volutario = item.Volutario,
                    StatusAtirador = item.StatusAtirador, // False informa que ele não foi desligado do TG
                    
                    // Dados de Pontuação
                    PontosJustificados = item.PontosJustificados,
                    PontosNaoJustificados = item.PontosNaoJustificados,
                    TotalPontos = pontosTotais,

                    // Dados de Horas/Tempo de Serviço
                    HorasCfc = item.HorasCfc,
                    HorasInstrucao = item.HorasInstrucao,
                    HorasExtras = item.HorasExtras,
                    HorasServico = item.HorasServico,
                    TotalHoras = horasTotais,
                    TotalDias = horasTotais / 8,
                };

                atiradores.Add(at);
            }
            
            return atiradores.OrderBy(a => a.NumeroAtirador).ToList();
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

        public List<AtiradorDTO> ObterDesligados()
        {
            List<AtiradorDTO> atiradores = new List<AtiradorDTO>();
            
            var desligados = _context.CollectionAtirador.Find<Atirador>(stat => stat.StatusAtirador == true).ToList();

            foreach (var item in desligados)
            {
                var pontosTotais = item.PontosJustificados + item.PontosNaoJustificados;
                var horasTotais = item.HorasCfc + item.HorasInstrucao + item.HorasExtras + item.HorasServico;
                
                AtiradorDTO at = new AtiradorDTO{    
                    IdAtirador = item.IdAtirador,
                    // Dados Pessoais
                    NomeAtirador = item.NomeAtirador,
                    DataNascimento = item.DataNascimento,
                    CPF = item.CPF,
                    RegistroGeral = item.RegistroGeral,
                    TituloEleitor = item.TituloEleitor,
                    Naturalidade = item.Naturalidade,
                    NomePai = item.NomePai,
                    NomeMae = item.NomeMae,
                    Religiao = item.Religiao,
                    Escolaridade = item.Escolaridade,

                    // Dados de Endereço/Contato
                    Endereco = item.Endereco,
                    Telefone = item.Telefone,
                    TelefonePai = item.TelefonePai,
                    TelefoneMae = item.TelefoneMae,

                    // Dados do Tiro de Guerra
                    CR = item.CR,
                    NaturalidadeCR = item.NaturalidadeCR,
                    NomeGuerra = item.NomeGuerra,
                    NumeroAtirador = item.NumeroAtirador,
                    NumeroPelotao = item.NumeroPelotao,
                    Funcao = item.Funcao,
                    Volutario = item.Volutario,
                    StatusAtirador = item.StatusAtirador, // False informa que ele não foi desligado do TG
                    
                    // Dados de Pontuação
                    PontosJustificados = item.PontosJustificados,
                    PontosNaoJustificados = item.PontosNaoJustificados,
                    TotalPontos = pontosTotais,

                    // Dados de Horas/Tempo de Serviço
                    HorasCfc = item.HorasCfc,
                    HorasInstrucao = item.HorasInstrucao,
                    HorasExtras = item.HorasExtras,
                    HorasServico = item.HorasServico,
                    TotalHoras = horasTotais,
                    TotalDias = horasTotais / 8,
                };

                atiradores.Add(at);
            }
            
            return atiradores.OrderBy(a => a.NumeroAtirador).ToList();
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
                // TotalPontos = novoAtirador.TotalPontos,

                // Dados de Horas/Tempo de Serviço
                HorasCfc = novoAtirador.HorasCfc,
                HorasInstrucao = novoAtirador.HorasInstrucao,
                HorasExtras = novoAtirador.HorasExtras,
                HorasServico = novoAtirador.HorasServico,
                // TotalHoras = novoAtirador.TotalHoras,
                // TotalDias = novoAtirador.TotalDias,
            };

            _context.CollectionAtirador.ReplaceOne(u => u.IdAtirador == id, atirador);
        }

        public void Excluir(string id)
        {
            _context.CollectionAtirador.DeleteOne(atirador => atirador.IdAtirador == id);
        }

        public void Presenca(string [] atiradoresPresentes)
        {
            foreach (var item in atiradoresPresentes)
            {
                var atirador = _context.CollectionAtirador.Find<Atirador>(a => a.CR == item).FirstOrDefault();

                var horas = atirador.HorasInstrucao + 2;

                _context.CollectionAtirador.UpdateOne(at =>
                    at.IdAtirador == atirador.IdAtirador,
                    Builders<Atirador>.Update.Set(ati => ati.HorasInstrucao, horas),
                    new UpdateOptions { IsUpsert = false }
                );

                horas = 0;
            }
        }

        public void PresencaEscala(string atiradorPresente, int peso)
        {
            var atirador = _context.CollectionAtirador.Find<Atirador>(a => a.CR == atiradorPresente).FirstOrDefault();

            var horas = atirador.HorasServico + peso;

            _context.CollectionAtirador.UpdateOne(at =>
                at.IdAtirador == atirador.IdAtirador,
                Builders<Atirador>.Update.Set(ati => ati.HorasServico, horas),
                new UpdateOptions { IsUpsert = false }
            );

             horas = 0;
        }

        public void Falta(string [] atiradoresFaltosos)
        {
            foreach (var item in atiradoresFaltosos)
            {
                var atirador = _context.CollectionAtirador.Find<Atirador>(a => a.CR == item).FirstOrDefault();

                var pontos = atirador.PontosNaoJustificados + 4;

                _context.CollectionAtirador.UpdateOne(at =>
                    at.IdAtirador == atirador.IdAtirador,
                    Builders<Atirador>.Update.Set(ati => ati.PontosNaoJustificados, pontos),
                    new UpdateOptions { IsUpsert = false }
                );

                pontos = 0;
            }
        }

        public void FaltaEscala(string atiradorFaltoso, int peso)
        {
            var atirador = _context.CollectionAtirador.Find<Atirador>(a => a.CR == atiradorFaltoso).FirstOrDefault();

            var pontos = atirador.PontosNaoJustificados + peso;

            _context.CollectionAtirador.UpdateOne(at =>
                at.IdAtirador == atirador.IdAtirador,
                Builders<Atirador>.Update.Set(ati => ati.PontosNaoJustificados, pontos),
                new UpdateOptions { IsUpsert = false }
            );

            pontos = 0;
        }

        public void Justificados(string [] atiradoresJustificados)
        {
            foreach (var item in atiradoresJustificados)
            {
                var atirador = _context.CollectionAtirador.Find<Atirador>(a => a.CR == item).FirstOrDefault();

                var pontos = atirador.PontosJustificados + 2;

                _context.CollectionAtirador.UpdateOne(at =>
                    at.IdAtirador == atirador.IdAtirador,
                    Builders<Atirador>.Update.Set(ati => ati.PontosJustificados, pontos),
                    new UpdateOptions { IsUpsert = false }
                );

                pontos = 0;
            }
        }

        public void JustificadosEscala(string atiradorJustificado, int peso)
        {
            var atirador = _context.CollectionAtirador.Find<Atirador>(a => a.CR == atiradorJustificado).FirstOrDefault();

            var pontos = atirador.PontosJustificados + peso;

            _context.CollectionAtirador.UpdateOne(at =>
                at.IdAtirador == atirador.IdAtirador,
                Builders<Atirador>.Update.Set(ati => ati.PontosJustificados, pontos),
                new UpdateOptions { IsUpsert = false }
            );

            pontos = 0;
        }
    }
}
