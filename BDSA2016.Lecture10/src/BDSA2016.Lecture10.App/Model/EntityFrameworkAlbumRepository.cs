using BDSA2016.Lecture10.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using AlbumEntity = BDSA2016.Lecture10.Entities.Album;
using ArtistEntity = BDSA2016.Lecture10.Entities.Artist;

namespace BDSA2016.Lecture10.App.Model
{
    public class EntityFrameworkAlbumRepository : IAlbumRepository
    {
        private readonly IAlbumContext _context;

        public EntityFrameworkAlbumRepository(IAlbumContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Album album)
        {
            var entity = new AlbumEntity
            {
                Title = album.Title,
                ArtistId = album.ArtistId,
                Year = album.Year,
                Cover = album.Cover
            };

            _context.Albums.Add(entity);

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Album>> ReadAsync()
        {
            var query =  from a in _context.Albums
                         orderby a.Artist.Name, a.Title
                         select new Album
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

        public async Task<bool> UpdateAsync(Album album)
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

        public async Task SeedAsync()
        {
            foreach (var a in _context.Albums)
            {
                _context.Albums.Remove(a);
            }
            foreach (var a in _context.Artists)
            {
                _context.Artists.Remove(a);
            }

            var morbid = new ArtistEntity { Name = "Morbid Angel" };
            var cannibal = new ArtistEntity { Name = "Cannibal Corpse" };
            var obituary = new ArtistEntity { Name = "Obituary" };
            _context.Artists.Add(morbid);
            _context.Artists.Add(cannibal);
            _context.Artists.Add(obituary);

            _context.Albums.AddRange(
                new AlbumEntity { Title = "Altars Of Madness", Artist = morbid, Year = 1989, Cover = await LoadBytesAsync("ms-appx:///Assets/Covers/AltarsOfMadness.jpg") },
                new AlbumEntity { Title = "Blessed Are The Sick", Artist = morbid, Year = 1991, Cover = await LoadBytesAsync("ms-appx:///Assets/Covers/BlessedAreTheSick.jpg") },
                new AlbumEntity { Title = "Covenant", Artist = morbid, Year = 1993, Cover = await LoadBytesAsync("ms-appx:///Assets/Covers/Covenant.jpg") },
                new AlbumEntity { Title = "Domination", Artist = morbid, Year = 1995, Cover = await LoadBytesAsync("ms-appx:///Assets/Covers/Domination.jpg") },
                new AlbumEntity { Title = "Formulas Fatal To The Flesh", Artist = morbid, Year = 1998, Cover = await LoadBytesAsync("ms-appx:///Assets/Covers/FormulasFatalToTheFlesh.jpg") },
                new AlbumEntity { Title = "Gateways To Annihilation", Artist = morbid, Year = 2000, Cover = await LoadBytesAsync("ms-appx:///Assets/Covers/GatewaysToAnnihilation.jpg") },
                new AlbumEntity { Title = "Heretic", Artist = morbid, Year = 2003, Cover = await LoadBytesAsync("ms-appx:///Assets/Covers/Heretic.jpg") },
                new AlbumEntity { Title = "Illud Divinum Insanus", Artist = morbid, Year = 2011, Cover = await LoadBytesAsync("ms-appx:///Assets/Covers/IlludDivinumInsanus.jpg") }
            );

            await _context.SaveChangesAsync();
        }

        private async Task<byte[]> LoadBytesAsync(string uri)
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(uri));

            using (var stream = await file.OpenReadAsync())
            { 
                var bytes = new byte[stream.Size];
                using (var reader = new DataReader(stream))
                {
                    await reader.LoadAsync((uint)stream.Size);
                    reader.ReadBytes(bytes);
                }

                return bytes;
            }
        }

        public async static Task<BitmapImage> ConvertToBitmapImageAsync(byte[] bytes)
        {
            var image = new BitmapImage();
            using (var stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(bytes.AsBuffer());
                stream.Seek(0);
                await image.SetSourceAsync(stream);
            }
            return image;
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
