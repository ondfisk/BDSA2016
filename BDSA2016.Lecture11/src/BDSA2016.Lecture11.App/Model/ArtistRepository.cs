using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BDSA2016.Lecture11.App.Model
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly HttpClient _client;

        public ArtistRepository(HttpClient client)
        {
            _client = client;

            // TODO: Load from settings
            _client.BaseAddress = new Uri("http://localhost:1667/");
        }

        public async Task<int> CreateAsync(Artist artist)
        {
            var result = await _client.PostAsJsonAsync("api/artists", artist);

            if (result.IsSuccessStatusCode)
            {
                var created = await result.Content.ReadAsAsync<Artist>();

                return created.Id;
            }

            return 0;
        }

        public async Task<bool> DeleteAsync(int artistId)
        {
            var result = await _client.DeleteAsync($"api/artists/{artistId}");

            return result.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Artist>> ReadAsync()
        {
            var result = await _client.GetAsync("api/artists");

            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsAsync<IEnumerable<Artist>>();
            }

            return Enumerable.Empty<Artist>();
        }

        public Task SeedAsync()
        {
            return Task.FromResult<object>(null);
        }

        public async Task<bool> UpdateAsync(Artist artist)
        {
            var result = await _client.PutAsJsonAsync($"api/artists/{artist.Id}", artist);

            return result.IsSuccessStatusCode;
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
                    _client.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~WebApiArtistRepository() {
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
