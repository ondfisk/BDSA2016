using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace BDSA2016.Lecture10.App.Model
{
    public class StaticAlbumRepository : IAlbumRepository
    {
        public async Task<int> CreateAsync(Album album)
        {
            return await Task.FromResult(0);
        }

        public async Task<IEnumerable<Album>> ReadAsync()
        {
            return new[]
            {
                new Album { Id = 1, Title = "Altars Of Madness", ArtistId = 1, ArtistName = "Morbid Angel", Year = 1989, Cover = await LoadBytesAsync("ms-appx:///Assets/Covers/AltarsOfMadness.jpg") },
                new Album { Id = 2, Title = "Blessed Are The Sick", ArtistId = 1, ArtistName = "Morbid Angel", Year = 1991, Cover = await LoadBytesAsync("ms-appx:///Assets/Covers/BlessedAreTheSick.jpg") },
                new Album { Id = 3, Title = "Covenant", ArtistId = 1, ArtistName = "Morbid Angel", Year = 1993, Cover = await LoadBytesAsync("ms-appx:///Assets/Covers/Covenant.jpg") },
                new Album { Id = 4, Title = "Domination", ArtistId = 1, ArtistName = "Morbid Angel", Year = 1995, Cover = await LoadBytesAsync("ms-appx:///Assets/Covers/Domination.jpg") },
                new Album { Id = 5, Title = "Formulas Fatal To The Flesh", ArtistId = 1, ArtistName = "Morbid Angel", Year = 1998, Cover = await LoadBytesAsync("ms-appx:///Assets/Covers/FormulasFatalToTheFlesh.jpg") },
                new Album { Id = 6, Title = "Gateways To Annihilation", ArtistId = 1, ArtistName = "Morbid Angel", Year = 2000, Cover = await LoadBytesAsync("ms-appx:///Assets/Covers/GatewaysToAnnihilation.jpg") },
                new Album { Id = 7, Title = "Heretic", ArtistId = 1, ArtistName = "Morbid Angel", Year = 2003, Cover = await LoadBytesAsync("ms-appx:///Assets/Covers/Heretic.jpg") },
                new Album { Id = 8, Title = "Illud Divinum Insanus", ArtistId = 1, ArtistName = "Morbid Angel", Year = 2011, Cover = await LoadBytesAsync("ms-appx:///Assets/Covers/IlludDivinumInsanus.jpg") }
            };
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

        public async Task<bool> UpdateAsync(Album album)
        {
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync(int albumId)
        {
            return await Task.FromResult(false);
        }

        public async Task SeedAsync()
        {
            await Task.FromResult<object>(null);
        }

        public void Dispose()
        {
        }
    }
}
