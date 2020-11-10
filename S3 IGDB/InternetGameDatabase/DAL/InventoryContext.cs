using System;
using DAL.ContextModel;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameGenre>()
                .HasKey(bc => new { bc.GameId, bc.GenreId });
            modelBuilder.Entity<GameGenre>()
                .HasOne(bc => bc.Game)
                .WithMany(b => b.GameGenres)
                .HasForeignKey(bc => bc.GameId);
            modelBuilder.Entity<GameGenre>()
                .HasOne(bc => bc.Genre)
                .WithMany(c => c.GameGenres)
                .HasForeignKey(bc => bc.GenreId);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Email).IsRequired();
                entity.HasIndex(e => e.Username).IsUnique();
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.Password).IsRequired();
            });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
