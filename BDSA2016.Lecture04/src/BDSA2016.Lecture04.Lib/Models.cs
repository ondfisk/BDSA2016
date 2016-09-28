using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BDSA2016.Lecture04.Lib 
{
    public interface IMusicDbContext : IDisposable
    {
        DbSet<Artist> Artists { get; }
        DbSet<Album> Albums { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }

    public class MusicDbContext : DbContext, IMusicDbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseSqlite("Filename=./musicdb.db");
        }
    }

    public class Artist
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Album> Albums { get; set; }
    }

    public class Album
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public int? Year { get; set; }

        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

    }

}