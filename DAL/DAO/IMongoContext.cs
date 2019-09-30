using back_sistema_tg.DAL.Models;
using MongoDB.Driver;

namespace back_sistema_tg.DAL.DAO
{
    public interface IMongoContext
    {
        IMongoCollection<Usuario> CollectionUsuario { get; }
    }
}
