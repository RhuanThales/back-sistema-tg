using System.Collections.Generic;
using back_sistema_tg.BLL.Exceptions;
using back_sistema_tg.DAL.DAO;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace back_sistema_tg.BLL
{
    public class ChamadaEscalaBll : IChamadaEscalaBll
    {
        public readonly IChamadaEscalaDAO _chamadaEscalaDAO;

        public ChamadaEscalaBll(IChamadaEscalaDAO chamadaEscalaDAO)
        {
            _chamadaEscalaDAO = chamadaEscalaDAO;
        }

        public void InserirChamadaEscala(ChamadaEscala chamada)
        {
            _chamadaEscalaDAO.InserirChamadaEscala(chamada);
        }

        public List<ChamadaEscala> ObterTodasChamadasEscala(string idEscala)
        {
            var listaChamadas = _chamadaEscalaDAO.ObterTodasChamadasEscala(idEscala);

            return listaChamadas;
        }

        public ChamadaEscala ObterPorId(string id)
        {
            var chamada = _chamadaEscalaDAO.ObterPorId(id);

            return chamada;
        }

        public void AtualizarChamadaEscala(string id, ChamadaEscala novaChamada)
        {
            bool hasAny = (_chamadaEscalaDAO.ObterPorId(id))!=null;

            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado.");
            }
                
            try
            {
                _chamadaEscalaDAO.AtualizarChamadaEscala(id, novaChamada);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        } 

        public void ConfirmarChamadaEscala(string idChamada)
        { 
            var obj = _chamadaEscalaDAO.ObterPorId(idChamada);

            bool hasAny = obj!=null;
            
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado.");
            }

            try
            {
                _chamadaEscalaDAO.ConfirmarChamadaEscala(obj.IdChamadaEscala);
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Não foi possível efetuar a remoção.");
            }
        }
    }
}
