using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BDSA2016.Lecture10.Web.Model;

namespace BDSA2016.Lecture10.Web.Controllers
{
    [Route("api/[controller]")]
    public class AlbumsController : Controller
    {
        private readonly IAlbumRepository _repository;

        public AlbumsController(IAlbumRepository repository)
        {
            _repository = repository;
        }

        // GET api/albums
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var albums = await _repository.ReadAsync();

            return Ok(albums);
        }

        // GET api/albums/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var album = await _repository.FindAsync(id);

            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        // POST api/albums
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AlbumDTO album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await _repository.CreateAsync(album);
            album.Id = id;

            return CreatedAtAction("Get", new { id }, album);
        }

        // PUT api/albums/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]AlbumDTO album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ok = await _repository.UpdateAsync(album);

            if (ok)
            {
                return NoContent();
            }

            return NotFound();
        }

        // DELETE api/albums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _repository.DeleteAsync(id);

            if (ok)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
