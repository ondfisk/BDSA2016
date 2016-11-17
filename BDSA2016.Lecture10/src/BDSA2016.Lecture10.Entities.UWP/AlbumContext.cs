using Microsoft.EntityFrameworkCore;

namespace BDSA2016.Lecture10.Entities
{
    public class AlbumContext : DbContext, IAlbumContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Albums.db");
        }
    }
}
