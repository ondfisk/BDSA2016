using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BDSA2016.Lecture10.App.Model
{
    public class WebArtistRepository : IArtistRepository
    {
        public Task<int> CreateAsync(Artist artist)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int artistId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public async Task<IEnumerable<Artist>> ReadAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1667/");

                var result = await client.GetAsync("api/artists");

                if (result.IsSuccessStatusCode)
                {
                    return await result.Content.ReadAsAsync<IEnumerable<Artist>>();
                }

                return Enumerable.Empty<Artist>();
            }
        }

        public Task<bool> UpdateAsync(Artist artist)
        {
            throw new NotImplementedException();
        }
    }
}
