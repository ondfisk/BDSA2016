using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BDSA2016.Lecture11.Web.Model;
using Microsoft.AspNetCore.Authorization;

namespace BDSA2016.Lecture11.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ArtistsController : Controller
    {
        private readonly IArtistRepository _repository;

        public ArtistsController(IArtistRepository repository)
        {
            _repository = repository;
        }

        // GET api/artists
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var artists = await _repository.ReadAsync();

            return Ok(artists);
        }

        // GET api/artists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var artist = await _repository.FindAsync(id);

            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        // POST api/artists
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ArtistDTO artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await _repository.CreateAsync(artist);
            artist.Id = id;

            return CreatedAtAction("Get", new { id }, artist);
        }

        // PUT api/artists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ArtistDTO artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ok = await _repository.UpdateAsync(artist);

            if (ok)
            {
                return NoContent();
            }

            return NotFound();
        }

        // DELETE api/artists/5
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
