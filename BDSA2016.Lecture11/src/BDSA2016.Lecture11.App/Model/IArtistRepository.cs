using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BDSA2016.Lecture11.App.Model
{
    public interface IArtistRepository : IDisposable
    {
        Task<int> CreateAsync(Artist artist);
        Task<IEnumerable<Artist>> ReadAsync();
        Task<bool> UpdateAsync(Artist artist);
        Task<bool> DeleteAsync(int artistId);
    }
}