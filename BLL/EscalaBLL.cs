using System.Collections.Generic;
using back_sistema_tg.BLL.Exceptions;
using back_sistema_tg.DAL.DAO;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace back_sistema_tg.BLL
{
    public class EscalaBll : IEscalaBll
    {
        public readonly IEscalaDAO _escalaDAO;

        public EscalaBll(IEscalaDAO escalaDAO)
        {
            _escalaDAO = escalaDAO;
        }

        public void Inserir(Escala escala)
        {
            _escalaDAO.Inserir(escala);
        }

        public List<Escala> ObterTodos()
        {
            var listaEscala = _escalaDAO.ObterTodos();

            return listaEscala;
        }

        public Escala ObterPorId(string id)
        {
            var escala = _escalaDAO.ObterPorId(id);

            return escala;
        }
        public void Atualizar(string id, Escala novoEscala)
        {
            bool hasAny = (_escalaDAO.ObterPorId(id))!=null;

            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado.");
            }
                
            try
            {
                _escalaDAO.Atualizar(id, novoEscala);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        } 
        
        public void Excluir(string id)
        {           
            var obj = _escalaDAO.ObterPorId(id);

            bool hasAny = obj!=null;
            
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado.");
            }

            try
            {
                _escalaDAO.Excluir(obj.IdEscala);
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Não foi possível efetuar a remoção.");
            }
        }
    }
}
