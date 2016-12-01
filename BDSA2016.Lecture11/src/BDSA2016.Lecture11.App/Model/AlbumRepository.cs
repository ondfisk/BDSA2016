using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web.Core;
using Windows.UI.Popups;

namespace BDSA2016.Lecture11.App.Model
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly HttpClient _client;
        private readonly IAuth _auth;
        private readonly MediaTypeFormatter _formatter;

        public AlbumRepository(HttpClient client, IAuth auth)
        {
            _client = client;
            _auth = auth;

            // TODO: Load from settings
            _client.BaseAddress = new Uri("http://localhost:1667/");

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/bson"));
            _formatter = new BsonMediaTypeFormatter();
        }

        private async Task Auth()
        {
            // craft the token request for the Graph api
            var wtr = new WebTokenRequest(_auth.AccountProvider, string.Empty, _auth.ClientId);
            wtr.Properties.Add("resource", _auth.Resource);
            // perform the token request without showing any UX
            var wtrr = await WebAuthenticationCoreManager.GetTokenSilentlyAsync(wtr, _auth.Account);
            if (wtrr.ResponseStatus == WebTokenRequestStatus.Success)
            {
                var accessToken = wtrr.ResponseData[0].Token;
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
            else
            {
                var messageDialog = new MessageDialog("We tried to get a token for the API as the account you are currently signed in, but it didn't work out. Please sign in as a different user.");
                await messageDialog.ShowAsync();
            }
        }

        public async Task<int> CreateAsync(Album album)
        {
            await Auth();

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
            await Auth();

            var result = await _client.DeleteAsync($"api/albums/{albumId}");

            return result.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Album>> ReadAsync()
        {
            await Auth();

            var result = await _client.GetAsync("api/albums");

            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsAsync<IEnumerable<Album>>(new[] { _formatter });
            }

            return Enumerable.Empty<Album>();
        }

        public async Task<bool> UpdateAsync(Album album)
        {
            await Auth();

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
