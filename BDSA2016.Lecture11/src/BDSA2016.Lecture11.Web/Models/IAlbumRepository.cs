using BDSA2016.Lecture11.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BDSA2016.Lecture11.Web.Model
{
    public interface IAlbumRepository : IDisposable
    {
        Task<int> CreateAsync(AlbumDTO album);
        Task<AlbumDTO> FindAsync(int albumId);
        Task<IEnumerable<AlbumDTO>> ReadAsync();
        Task<bool> UpdateAsync(AlbumDTO album);
        Task<bool> DeleteAsync(int albumId);
    }
}