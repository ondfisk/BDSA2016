using BDSA2016.Lecture11.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BDSA2016.Lecture11.Web.Model
{
    public interface IArtistRepository : IDisposable
    {
        Task<int> CreateAsync(ArtistDTO artist);
        Task<ArtistDTO> FindAsync(int artistId);
        Task<IEnumerable<ArtistDTO>> ReadAsync();
        Task<bool> UpdateAsync(ArtistDTO artist);
        Task<bool> DeleteAsync(int artistId);
    }
}