using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BDSA2016.Lecture04.Lib
{   
    public interface ICharacterContext : IDisposable
    {
        DbSet<Character> Characters { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}