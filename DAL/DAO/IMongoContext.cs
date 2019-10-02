using MongoDB.Driver;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DAO
{
    public interface IMongoContext
    {
        IMongoCollection<Usuario> CollectionUsuario { get; }
        IMongoCollection<Atirador> CollectionAtirador { get; }
        IMongoCollection<Oficial> CollectionOficial { get; }
        IMongoCollection<Pelotao> CollectionPelotao { get; }
        IMongoCollection<Escala> CollectionEscala { get; }
    }
}