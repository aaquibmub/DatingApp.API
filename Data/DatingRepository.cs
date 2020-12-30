using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _context;
        public DatingRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<DbUser> GetUser(int id)
        {
            var user = await _context.DbUsers.Include(inc => inc.Photos).FirstOrDefaultAsync(f => f.Id == id);

            return user;
        }

        public async Task<IEnumerable<DbUser>> GetUsers()
        {
            var users = await _context.DbUsers.Include(inc => inc.Photos).ToListAsync();

            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}