using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public class UsuarioDAO : IUsuarioDAO
    {
        // Injeção de Dependências
        private readonly IMongoContext _context;

        // Método Construtor da classe
        public UsuarioDAO(IMongoContext context)
        {
            _context = context;
        }

        
        public void Inserir(Usuario usuario)
        {
            Usuario novoUsuario = new Usuario{
                Nome = usuario.Nome,
                Login = usuario.Login,
                Senha = usuario.Senha,
                PerfilSuper = usuario.PerfilSuper
            };

            _context.CollectionUsuario.InsertOne(novoUsuario);
        }

        public List<Usuario> ObterTodos()
        {
            var colecaoUsuarios = _context.CollectionUsuario.Find(usuario => true).ToList();

            return colecaoUsuarios;
        }

        public Usuario ObterPorId(string id)
        {
            var usuario = _context.CollectionUsuario.Find<Usuario>(u => u.Id == id).FirstOrDefault();

            return usuario;
        }

        public Usuario ObterPorLogin(string login)
        {
            var usuario = _context.CollectionUsuario.Find<Usuario>(u => u.Login == login).FirstOrDefault();

            return usuario;
        }

        public void Atualizar(string id, Usuario novoUsuario)
        {
            Usuario usuario = new Usuario{
              Id = id,
              Nome = novoUsuario.Nome,
              Login = novoUsuario.Login,
              Senha = novoUsuario.Senha,
              PerfilSuper = novoUsuario.PerfilSuper
            };

            _context.CollectionUsuario.ReplaceOne(u => u.Id == id, usuario);
        }

        public void Excluir(string id)
        {
            _context.CollectionUsuario.DeleteOne(usuario => usuario.Id == id);
        }
    }
}
