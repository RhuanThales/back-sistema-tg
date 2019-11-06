using System.Collections.Generic;
using back_sistema_tg.BLL.Exceptions;
using back_sistema_tg.DAL.DAO;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace back_sistema_tg.BLL
{
    public class OficialBll : IOficialBll
    {
        public readonly IOficialDAO _oficialDAO;

        public OficialBll(IOficialDAO oficialDAO)
        {
            _oficialDAO = oficialDAO;
        }

        public void Inserir(Oficial oficial)
        {
            _oficialDAO.Inserir(oficial);
        }

        public List<Oficial> ObterTodos()
        {
            var listaOficial = _oficialDAO.ObterTodos();

            return listaOficial;
        }

        public Oficial ObterPorId(string IdOficial)
        {
            var oficial = _oficialDAO.ObterPorId(IdOficial);

            return oficial;
        }

        public Oficial ObterChefeInstrucao()
        {
            var oficial = _oficialDAO.ObterChefeInstrucao();

            return oficial;
        }

        public void Atualizar(string IdOficial, Oficial novoOficial)
        {
            bool hasAny = (_oficialDAO.ObterPorId(IdOficial))!=null;

            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado.");
            }
                
            try
            {
                _oficialDAO.Atualizar(IdOficial, novoOficial);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        } 
        
        public void Excluir(string IdOficial)
        {           
            var obj = _oficialDAO.ObterPorId(IdOficial);

            bool hasAny = obj!=null;
            
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado.");
            }

            try
            {
                _oficialDAO.Excluir(obj.IdOficial);
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Não foi possível efetuar a remoção.");
            }
        }
    }
}
