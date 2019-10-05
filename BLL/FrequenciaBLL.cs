using System.Collections.Generic;
using back_sistema_tg.BLL.Exceptions;
using back_sistema_tg.DAL.DAO;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace back_sistema_tg.BLL
{
    public class FrequenciaBll : IFrequenciaBll
    {
        public readonly IFrequenciaDAO _frequenciaDAO;

        public FrequenciaBll(IFrequenciaDAO frequenciaDAO)
        {
            _frequenciaDAO = frequenciaDAO;
        }

        public void Inserir(Frequencia frequencia)
        {
            _frequenciaDAO.Inserir(frequencia);
        }

        public List<Frequencia> ObterTodos()
        {
            var listaFrequencia = _frequenciaDAO.ObterTodos();

            return listaFrequencia;
        }

        public Frequencia ObterPorId(string id)
        {
            var frequencia = _frequenciaDAO.ObterPorId(id);

            return frequencia;
        }
        public void Atualizar(string id, Frequencia novaFrequencia)
        {
            bool hasAny = (_frequenciaDAO.ObterPorId(id))!=null;

            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado.");
            }
                
            try
            {
                _frequenciaDAO.Atualizar(id, novaFrequencia);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        } 
        
        public void Excluir(string id)
        {           
            var obj = _frequenciaDAO.ObterPorId(id);

            bool hasAny = obj!=null;
            
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado.");
            }

            try
            {
                _frequenciaDAO.Excluir(obj.IdFrequencia);
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Não foi possível efetuar a remoção.");
            }
        }
    }
    
}