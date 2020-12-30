using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<DbUser>> GetUsers();
        Task<DbUser> GetUser(int id);

    }
}