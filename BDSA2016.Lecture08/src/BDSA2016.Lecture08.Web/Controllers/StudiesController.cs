using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BDSA2016.Lecture08.Web.Models;

namespace BDSA2016.Lecture08.Web.Controllers
{
    [Route("api/[controller]")]
    public class StudiesController : Controller
    {
        private readonly IStudyRepository _repository;

        public StudiesController(IStudyRepository repository)
        {
            _repository = repository;
        }

        // GET api/studies
        [HttpGet]
        public IQueryable<StudyDTO> Get()
        {
            return _repository.Read();
        }

        // GET api/studies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var study = await _repository.FindAsync(id);

            if (study == null)
            {
                return NotFound();
            }

            return Ok(study);
        }

        // POST api/studies
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]StudyDTO study)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await _repository.CreateAsync(study);
            study.Id = id;

            return CreatedAtAction("Get", new { id }, study);
        }

        // PUT api/studies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]StudyDTO study)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ok = await _repository.UpdateAsync(study);

            if (ok)
            {
                return NoContent();
            }

            return NotFound();
        }

        // DELETE api/studies/5
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
