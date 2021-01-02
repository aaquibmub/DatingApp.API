using System.Collections.Generic;
using System.Threading.Tasks;
using Helpers;
using Models;

namespace Data
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<PagedList<DbUser>> GetUsers(UserParams userParams);
        Task<DbUser> GetUser(int id);
        Task<DbPhoto> GetPhoto(int id);
        Task<DbPhoto> GetMainPhotoForUser(int userId);
        Task<DbLike> GetLike(int userId, int recipientId);
        Task<DbMessage> GetMessage(int id);
        Task<PagedList<DbMessage>> GetMessagesForUser(MessageParams messageParams);
        Task<IEnumerable<DbMessage>> GetMessageThread(int userId, int recipientId);

    }
}