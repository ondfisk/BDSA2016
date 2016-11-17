using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BDSA2016.Lecture10.Entities
{
    public interface IAlbumContext : IDisposable
    {
        DbSet<Album> Albums { get; }
        DbSet<Artist> Artists { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}