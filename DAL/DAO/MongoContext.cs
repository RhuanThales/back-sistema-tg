using System;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public class MongoContext:IMongoContext
    {
        private readonly IMongoDatabase _db;

        public MongoContext(IOptions<Configuracoes> options, IMongoClient client)
        {
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Usuario> CollectionUsuario => _db.GetCollection<Usuario>("Usuario");

        public IMongoCollection<Atirador> CollectionAtirador => _db.GetCollection<Atirador>("Atirador");

       // public IMongoCollection<Oficial> CollectionOficial => _db.GetCollection<Oficial>("Oficial");

    }
}
