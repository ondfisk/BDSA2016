using BDSA2016.Lecture10.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtistEntity = BDSA2016.Lecture10.Entities.Artist;

namespace BDSA2016.Lecture10.App.Model
{
    public class StaticArtistRepository : IArtistRepository
    {
        public async Task<int> CreateAsync(Artist artist)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Artist>> ReadAsync()
        {
            return new[] {
                new Artist { Id = 1, Name = "Morbid Angel" },
                new Artist { Id = 2, Name = "Cannibal Corpse" },
                new Artist { Id = 3, Name = "Obituary" }
            };
        }

        public async Task<bool> UpdateAsync(Artist artist)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int artistId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
