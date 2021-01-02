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
        public DbSet<DbLike> DbLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DbLike>()
                .HasKey(k => new { k.LikerId, k.LikeeId });

            builder.Entity<DbLike>()
                .HasOne(u => u.Likee)
                .WithMany(u => u.Likers)
                .HasForeignKey(u => u.LikeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DbLike>()
                .HasOne(u => u.Liker)
                .WithMany(u => u.Likees)
                .HasForeignKey(u => u.LikerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}