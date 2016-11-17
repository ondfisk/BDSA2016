using BDSA2016.Lecture10.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtistEntity = BDSA2016.Lecture10.Entities.Artist;

namespace BDSA2016.Lecture10.App.Model
{
    public class EntityFrameworkArtistRepository : IArtistRepository
    {
        private readonly IAlbumContext _context;

        public EntityFrameworkArtistRepository(IAlbumContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Artist artist)
        {
            var entity = new ArtistEntity
            {
                Name = artist.Name
            };

            _context.Artists.Add(entity);

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Artist>> ReadAsync()
        {
            var query =  from a in _context.Artists
                         orderby a.Name
                         select new Artist
                         {
                             Id = a.Id,
                             Name = a.Name
                         };

            return await query.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Artist artist)
        {
            var entity = await _context.Artists.FindAsync(artist.Id);

            if (entity == null)
            {
                return false;
            }

            entity.Name = artist.Name;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int artistId)
        {
            var entity = await _context.Artists.FindAsync(artistId);

            if (entity == null)
            {
                return false;
            }

            _context.Artists.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EntityFrameworkArtistRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
