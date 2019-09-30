using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_sistema_tg.DAL.Models;
using MongoDB.Driver;

namespace back_sistema_tg.DAL.DAO
{
    public class SeedingService
    {
        private readonly IMongoContext _context;

        public SeedingService(IMongoContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.CollectionUsuario.Find(u => true).ToList().Count != 0)
            {
                return; // DB has been seeded
            }

            Usuario userRoot = new Usuario();
            userRoot.Nome = "Administrador do Sistema";
            userRoot.Login = "adm";
            userRoot.Senha = "@adm@1234";
            userRoot.PerfilSuper = true;

            List<Usuario> user = new List<Usuario>();
            user.Add(userRoot);

            _context.CollectionUsuario.InsertMany(user);
        }
    }
}