using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BDSA2016.Lecture10.App.Model
{
    public class WebApiAlbumRepository : IAlbumRepository
    {
        private readonly HttpClient _client;
        private readonly MediaTypeFormatter _formatter;

        public WebApiAlbumRepository(HttpClient client)
        {
            _client = client;

            // TODO: Load from settings
            _client.BaseAddress = new Uri("http://localhost:1667/");

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/bson"));
            _formatter = new BsonMediaTypeFormatter();
        }

        public async Task<int> CreateAsync(Album album)
        {
            var result = await _client.PostAsJsonAsync("api/albums", album);

            if (result.IsSuccessStatusCode)
            {
                var created = await result.Content.ReadAsAsync<Album>(new[] { _formatter });

                return created.Id;
            }

            return 0;
        }

        public async Task<bool> DeleteAsync(int albumId)
        {
            var result = await _client.DeleteAsync($"api/albums/{albumId}");

            return result.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Album>> ReadAsync()
        {
            var result = await _client.GetAsync("api/albums");

            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsAsync<IEnumerable<Album>>(new[] { _formatter });
            }

            return Enumerable.Empty<Album>();
        }

        public Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Album album)
        {
            var result = await _client.PutAsync($"api/albums/{album.Id}", album, _formatter);
            
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
        // ~WebApiAlbumRepository() {
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
