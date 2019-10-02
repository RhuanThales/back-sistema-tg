using System.Collections.Generic;
using back_sistema_tg.BLL.Exceptions;
using back_sistema_tg.DAL.DAO;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace back_sistema_tg.BLL
{
    public class UsuarioBll : IUsuarioBll
    {
        public readonly IUsuarioDAO _usuarioDAO;

        public UsuarioBll(IUsuarioDAO usuarioDAO)
        {
            _usuarioDAO = usuarioDAO;
        }

        public void Inserir(Usuario usuario)
        {
            _usuarioDAO.Inserir(usuario);
        }

        public List<Usuario> ObterTodos()
        {
            var listaUsuarios = _usuarioDAO.ObterTodos();

            return listaUsuarios;
        }

        public Usuario ObterPorId(string id)
        {
            var usuario = _usuarioDAO.ObterPorId(id);

            return usuario;
        }

        public Usuario ObterPorLogin(string login)
        {
            var usuario = _usuarioDAO.ObterPorLogin(login);

            return usuario;
        }

        public void Atualizar(string id, Usuario novoUsuario)
        {
            bool hasAny = (_usuarioDAO.ObterPorId(id))!=null;

            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado.");
            }
                
            try
            {
                _usuarioDAO.Atualizar(id, novoUsuario);
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        } 
        
        public void Excluir(string id)
        {           
            var obj = _usuarioDAO.ObterPorId(id);

            bool hasAny = obj!=null;
            
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado.");
            }

            try
            {
                _usuarioDAO.Excluir(obj.Id);
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Não foi possível efetuar a remoção.");
            }
        }
    }
}
