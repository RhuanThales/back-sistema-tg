using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public class ChamadaEscalaDAO : IChamadaEscalaDAO
    {
        // Injeção de Dependências
        public readonly IAtiradorDAO _atiradorDAO;
        public readonly IFrequenciaDAO _frequenciaDAO;
        private readonly IMongoContext _context;

        // Método Construtor da classe
        public ChamadaEscalaDAO(IAtiradorDAO atiradorDAO, IFrequenciaDAO frequenciaDAO, IMongoContext context)
        {
            _atiradorDAO = atiradorDAO;
            _frequenciaDAO = frequenciaDAO;
            _context = context;
        }
        
        public void InserirChamadaEscala(ChamadaEscala chamada)
        {            
            ChamadaEscala novaChamada = new ChamadaEscala{
                StatusChamadaEscala = false,
                IdEscala = chamada.IdEscala,
                DataChamadaEscala = chamada.DataChamadaEscala,
                UsuarioResponsavel = chamada.UsuarioResponsavel,
                AtiradoresPresentesPermanenciaM = chamada.AtiradoresPresentesPermanenciaM,
                AtiradoresPresentesPermanenciaT = chamada.AtiradoresPresentesPermanenciaT,
                AtiradoresPresentesGuarda = chamada.AtiradoresPresentesGuarda,
                AtiradoresFaltososPermanenciaM = chamada.AtiradoresFaltososPermanenciaM,
                AtiradoresFaltososPermanenciaT = chamada.AtiradoresFaltososPermanenciaT,
                AtiradoresFaltososGuarda = chamada.AtiradoresFaltososGuarda,
                AtiradoresJustificadosPermanenciaM = chamada.AtiradoresJustificadosPermanenciaM,
                AtiradoresJustificadosPermanenciaT = chamada.AtiradoresJustificadosPermanenciaT,
                AtiradoresJustificadosGuarda = chamada.AtiradoresJustificadosGuarda
            };

            _context.CollectionChamadaEscala.InsertOne(novaChamada);
        }

        public List<ChamadaEscala> ObterTodasChamadasEscala(string idEscala)
        {
            var chamadas = _context.CollectionChamadaEscala.Find(cha => cha.IdEscala == idEscala).ToList();

            return chamadas;
        }

        public ChamadaEscala ObterPorId(string id)
        {
            var chamada = _context.CollectionChamadaEscala.Find<ChamadaEscala>(c => c.IdChamadaEscala == id).FirstOrDefault();

            return chamada;
        }

        public void AtualizarChamadaEscala(string id, ChamadaEscala novaChamada)
        {
            ChamadaEscala chamada = new ChamadaEscala{
                IdChamadaEscala = id,
                StatusChamadaEscala = false,
                IdEscala = novaChamada.IdEscala,
                DataChamadaEscala = novaChamada.DataChamadaEscala,
                UsuarioResponsavel = novaChamada.UsuarioResponsavel,
                AtiradoresPresentesPermanenciaM = novaChamada.AtiradoresPresentesPermanenciaM,
                AtiradoresPresentesPermanenciaT = novaChamada.AtiradoresPresentesPermanenciaT,
                AtiradoresPresentesGuarda = novaChamada.AtiradoresPresentesGuarda,
                AtiradoresFaltososPermanenciaM = novaChamada.AtiradoresFaltososPermanenciaM,
                AtiradoresFaltososPermanenciaT = novaChamada.AtiradoresFaltososPermanenciaT,
                AtiradoresFaltososGuarda = novaChamada.AtiradoresFaltososGuarda,
                AtiradoresJustificadosPermanenciaM = novaChamada.AtiradoresJustificadosPermanenciaM,
                AtiradoresJustificadosPermanenciaT = novaChamada.AtiradoresJustificadosPermanenciaT,
                AtiradoresJustificadosGuarda = novaChamada.AtiradoresJustificadosGuarda
            };

            _context.CollectionChamadaEscala.ReplaceOne(u => u.IdChamadaEscala == id, chamada);
        }

        public void ConfirmarChamadaEscala(string idChamadaEscala)
        {
            var chamada = _context.CollectionChamadaEscala.Find<ChamadaEscala>(c => c.IdChamadaEscala == idChamadaEscala).FirstOrDefault();

            foreach (var item in chamada.AtiradoresPresentesPermanenciaM)
            {
                _frequenciaDAO.InserirFrequencia(chamada.DataChamadaEscala, "Presença em Permanência Manhã", item, 6, 0, "Presente");
                _atiradorDAO.PresencaEscala(item, 6);
            }

            foreach (var item in chamada.AtiradoresFaltososPermanenciaM)
            {
                _frequenciaDAO.InserirFrequencia(chamada.DataChamadaEscala, "Presença em Permanência Manhã", item, 0, 12, "Não Presente");
                _atiradorDAO.FaltaEscala(item, 12);
            }

            foreach (var item in chamada.AtiradoresJustificadosPermanenciaM)
            {
                _frequenciaDAO.InserirFrequencia(chamada.DataChamadaEscala, "Presença em Permanência Manhã", item, 0, 6, "Não Presente - Justificado");
                _atiradorDAO.JustificadoEscala(item, 6);
            }

            foreach (var item in chamada.AtiradoresPresentesPermanenciaT)
            {
                _frequenciaDAO.InserirFrequencia(chamada.DataChamadaEscala, "Presença em Permanência Tarde", item, 6, 0, "Presente");
                _atiradorDAO.PresencaEscala(item, 6);
            }

            foreach (var item in chamada.AtiradoresFaltososPermanenciaT)
            {
                _frequenciaDAO.InserirFrequencia(chamada.DataChamadaEscala, "Presença em Permanência Tarde", item, 0, 12, "Não Presente");
                _atiradorDAO.FaltaEscala(item, 12);
            }

            foreach (var item in chamada.AtiradoresJustificadosPermanenciaT)
            {
                _frequenciaDAO.InserirFrequencia(chamada.DataChamadaEscala, "Presença em Permanência Tarde", item, 0, 6, "Não Presente - Justificado");
                _atiradorDAO.JustificadoEscala(item, 6);
            }

            foreach (var item in chamada.AtiradoresPresentesGuarda)
            {
                _frequenciaDAO.InserirFrequencia(chamada.DataChamadaEscala, "Presença em Guarda", item, 12, 0, "Presente");
                _atiradorDAO.PresencaEscala(item, 12);
            }

            foreach (var item in chamada.AtiradoresFaltososGuarda)
            {
                _frequenciaDAO.InserirFrequencia(chamada.DataChamadaEscala, "Presença em Guarda", item, 0, 24, "Não Presente");
                _atiradorDAO.FaltaEscala(item, 24);
            }

            foreach (var item in chamada.AtiradoresJustificadosGuarda)
            {
                _frequenciaDAO.InserirFrequencia(chamada.DataChamadaEscala, "Presença em Guarda", item, 0, 12, "Não Presente - Justificado");
                _atiradorDAO.JustificadoEscala(item, 12);
            }

            _context.CollectionChamadaEscala.UpdateOne(ch =>
                ch.IdChamadaEscala == chamada.IdChamadaEscala,
                Builders<ChamadaEscala>.Update.Set(cha => cha.StatusChamadaEscala, true),
                new UpdateOptions { IsUpsert = false }
            );
        }
    }
}
