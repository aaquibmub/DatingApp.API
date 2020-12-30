using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DatingApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<DbValue> DbValues { get; set; }
        public DbSet<DbUser> DbUsers { get; set; }
        public DbSet<DbPhoto> DbPhotos { get; set; }
    }
}