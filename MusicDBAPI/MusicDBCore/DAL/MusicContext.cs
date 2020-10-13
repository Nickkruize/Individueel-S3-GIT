using Microsoft.EntityFrameworkCore;
using MusicDBCore.ContextModel;
using System;
using System.Collections.Generic;
using System.Text;

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

    }
}
