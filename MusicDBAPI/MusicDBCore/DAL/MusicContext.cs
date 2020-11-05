using Microsoft.EntityFrameworkCore;
using MusicDBCore.ContextModel;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;

namespace MusicDBCore.DAL
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        {

        }

        public DbSet<Artist> Artist { get; set; }

        public DbSet<Song> Song { get; set; }

        public DbSet<Album> Album { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<ArtistGenre> ArtistGenres { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtistGenre>()
                .HasKey(bc => new { bc.ArtistId, bc.GenreId });
            modelBuilder.Entity<ArtistGenre>()
                .HasOne(bc => bc.Artist)
                .WithMany(b => b.ArtistGenres)
                .HasForeignKey(bc => bc.ArtistId);
            modelBuilder.Entity<ArtistGenre>()
                .HasOne(bc => bc.Genre)
                .WithMany(c => c.ArtistGenres)
                .HasForeignKey(bc => bc.GenreId);
        }
    }
}
