using BDSA2016.Lecture11.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2016.Lecture11.Web.Model
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly IAlbumContext _context;

        public AlbumRepository(IAlbumContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(AlbumDTO album)
        {
            var entity = new Album
            {
                Title = album.Title,
                ArtistId = album.ArtistId,
                Year = album.Year,
                Cover = album.Cover
            };

            _context.Albums.Add(entity);

            return await _context.SaveChangesAsync();
        }

        public async Task<AlbumDTO> FindAsync(int albumId)
        {
            var query = from a in _context.Albums
                        where a.Id == albumId
                        select new AlbumDTO
                        {
                            Id = a.Id,
                            Title = a.Title,
                            ArtistId = a.ArtistId,
                            ArtistName = a.Artist.Name,
                            Year = a.Year,
                            Cover = a.Cover
                        };

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AlbumDTO>> ReadAsync()
        {
            var query =  from a in _context.Albums
                         orderby a.Artist.Name, a.Title
                         select new AlbumDTO
                         {
                             Id = a.Id,
                             Title = a.Title,
                             ArtistId = a.ArtistId,
                             ArtistName = a.Artist.Name,
                             Year = a.Year,
                             Cover = a.Cover
                         };

            return await query.ToListAsync();
        }

        public async Task<bool> UpdateAsync(AlbumDTO album)
        {
            var entity = await _context.Albums.FindAsync(album.Id);

            if (entity == null)
            {
                return false;
            }

            entity.Title = album.Title;
            entity.ArtistId = album.ArtistId;
            entity.Year = album.Year;
            entity.Cover = album.Cover;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int albumId)
        {
            var entity = await _context.Albums.FindAsync(albumId);

            if (entity == null)
            {
                return false;
            }

            _context.Albums.Remove(entity);

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
        // ~EntityFrameworkAlbumRepository() {
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
