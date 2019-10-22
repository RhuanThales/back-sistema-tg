using System.Collections.Generic;
using back_sistema_tg.BLL.Exceptions;
using back_sistema_tg.DAL.DAO;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace back_sistema_tg.BLL
{
    public class ChamadaBll : IChamadaBll
    {
        public readonly IChamadaDAO _chamadaDAO;

        public ChamadaBll(IChamadaDAO chamadaDAO)
        {
            _chamadaDAO = chamadaDAO;
        }

        public void Inserir(Chamada chamada)
        {
            _chamadaDAO.Inserir(chamada);
        }

        public List<Chamada> ObterTodos()
        {
            var listaChamadas = _chamadaDAO.ObterTodos();

            return listaChamadas;
        }

        public Chamada ObterPorId(string id)
        {
            var chamada = _chamadaDAO.ObterPorId(id);

            return chamada;
        }
        public void Atualizar(string id, Chamada novaChamada)
        {
            bool hasAny = (_chamadaDAO.ObterPorId(id))!=null;

            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado.");
            }
                
            try
            {
                _chamadaDAO.Atualizar(id, novaChamada);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        } 
        
        public void Excluir(string id)
        {           
            var obj = _chamadaDAO.ObterPorId(id);

            bool hasAny = obj!=null;
            
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado.");
            }

            try
            {
                _chamadaDAO.Excluir(obj.IdChamada);
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Não foi possível efetuar a remoção.");
            }
        }
    }
}
