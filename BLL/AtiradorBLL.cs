using System.Collections.Generic;
using back_sistema_tg.BLL.Exceptions;
using back_sistema_tg.DAL.DAO;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace back_sistema_tg.BLL
{
    public class AtiradorBll : IAtiradorBll
    {
        public readonly IAtiradorDAO _atiradorDAO;

        public AtiradorBll(IAtiradorDAO atiradorDAO)
        {
            _atiradorDAO = atiradorDAO;
        }

        public void Inserir(Atirador atirador)
        {
            _atiradorDAO.Inserir(atirador);
        }

        public List<Atirador> ObterTodos()
        {
            var listaAtirador = _atiradorDAO.ObterTodos();

            return listaAtirador;
        }

        public Atirador ObterPorId(string IdAtirador)
        {
            var atirador = _atiradorDAO.ObterPorId(IdAtirador);

            return atirador;
        }

        public List<Atirador> ObterPorPelotao(int NumeroPelotao){
            try
            {
                var pelotao = _atiradorDAO.ObterPorPelotao(NumeroPelotao);
                return pelotao;
            }
            catch (System.Exception ex)
            {
                
                throw new System.Exception(ex.Message);
            }
            
        }

        public List<Atirador> ObterMonitores(){
            try
            {
                var monitor = _atiradorDAO.ObterMonitores();
                return monitor;
            }
            catch (System.Exception ex)
            {
                
                throw new System.Exception(ex.Message);
            }
            
        }

        public void Atualizar(string IdAtirador, Atirador novoAtirador)
        {
            bool hasAny = (_atiradorDAO.ObterPorId(IdAtirador))!=null;

            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado.");
            }
                
            try
            {
                _atiradorDAO.Atualizar(IdAtirador, novoAtirador);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        } 
        
        public void Excluir(string IdAtirador)
        {           
            var obj = _atiradorDAO.ObterPorId(IdAtirador);

            bool hasAny = obj!=null;
            
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado.");
            }

            try
            {
                _atiradorDAO.Excluir(obj.IdAtirador);
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Não foi possível efetuar a remoção.");
            }
        }
    }
}
