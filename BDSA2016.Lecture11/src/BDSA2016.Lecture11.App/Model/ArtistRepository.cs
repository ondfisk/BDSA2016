using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web.Core;
using Windows.UI.Popups;

namespace BDSA2016.Lecture11.App.Model
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly HttpClient _client;
        private readonly IAuth _auth;

        public ArtistRepository(HttpClient client, IAuth auth)
        {
            _client = client;
            _auth = auth;

            // TODO: Load from settings
            _client.BaseAddress = new Uri("http://localhost:1667/");
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

        public async Task<int> CreateAsync(Artist artist)
        {
            await Auth();

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
            await Auth();

            var result = await _client.DeleteAsync($"api/artists/{artistId}");

            return result.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Artist>> ReadAsync()
        {
            await Auth();

            var result = await _client.GetAsync("api/artists");

            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsAsync<IEnumerable<Artist>>();
            }

            return Enumerable.Empty<Artist>();
        }

        public async Task<bool> UpdateAsync(Artist artist)
        {
            await Auth();

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
