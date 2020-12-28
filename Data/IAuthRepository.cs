using System.Threading.Tasks;
using Models;

namespace Data
{
    public interface IAuthRepository
    {
        Task<DbUser> Register(DbUser user, string password);
        Task<DbUser> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}