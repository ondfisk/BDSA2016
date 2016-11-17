using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BDSA2016.Lecture10.App.Model
{
    public interface IAlbumRepository : IDisposable
    {
        Task<int> CreateAsync(Album album);
        Task<IEnumerable<Album>> ReadAsync();
        Task<bool> UpdateAsync(Album album);
        Task<bool> DeleteAsync(int albumId);
        Task SeedAsync();
    }
}