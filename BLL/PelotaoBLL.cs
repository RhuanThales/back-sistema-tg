using System.Collections.Generic;
using back_sistema_tg.BLL.Exceptions;
using back_sistema_tg.DAL.DAO;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace back_sistema_tg.BLL
{
    public class PelotaoBll : IPelotaoBll
    {
          public readonly IPelotaoDAO _pelotaoDAO;

        public PelotaoBll(IPelotaoDAO pelotaoDAO)
        {
            _pelotaoDAO = pelotaoDAO;
        }

        public void Inserir(Pelotao pelotao)
        {
            _pelotaoDAO.Inserir(pelotao);
        }

        public List<Pelotao> ObterTodos()
        {
            var listaPelotao = _pelotaoDAO.ObterTodos();

            return listaPelotao;
        }

        public Pelotao ObterPorId(string IdPelotao)
        {
            var pelotao = _pelotaoDAO.ObterPorId(IdPelotao);

            return pelotao;
        }

        public void Atualizar(string IdPelotao, Pelotao novoPelotao)
        {
            bool hasAny = (_pelotaoDAO.ObterPorId(IdPelotao))!=null;

            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado.");
            }
                
            try
            {
                _pelotaoDAO.Atualizar(IdPelotao, novoPelotao);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        } 
        
        public void Excluir(string IdPelotao)
        {           
            var obj = _pelotaoDAO.ObterPorId(IdPelotao);

            bool hasAny = obj!=null;
            
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado.");
            }

            try
            {
                _pelotaoDAO.Excluir(obj.IdPelotao);
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Não foi possível efetuar a remoção.");
            }
        }
    }
}
