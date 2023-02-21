namespace MusicCollectionApi.Data
{
    using MusicCollectionApi.Models;
    using Microsoft.EntityFrameworkCore;
    public class MusicContext : DbContext {
        public MusicContext(DbContextOptions<MusicContext> options) :base(options) {}

        public DbSet<Album> Album {get; set;}
        public DbSet<Song> Song {get; set;}
    }

}