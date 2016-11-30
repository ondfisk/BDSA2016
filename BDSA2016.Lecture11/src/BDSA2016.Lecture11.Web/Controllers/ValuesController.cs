using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BDSA2016.Lecture11.Web.Models;
using System.Net;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BDSA2016.Lecture11.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private static IDictionary<int, string> _values = new Dictionary<int, string> { { 1, "Value 1" }, { 2, "Value 2" } };

        // GET: api/values
        [HttpGet]
        public IEnumerable<Value> Get()
        {
            return _values.Select(v => new Value { Id = v.Key, Name = v.Value });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Value Get(int id)
        {
            string value;
            if (_values.TryGetValue(id, out value))
            {
                return new Value { Id = id, Name = value };
            }

            return null;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            var id = _values.DefaultIfEmpty().Max(v => v.Key) + 1;

            _values.Add(id, value);

            return CreatedAtAction("Get", new { id }, new Value { Id = id, Name = value });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            if (_values.ContainsKey(id))
            {
                _values[id] = value;

                return NoContent();
            }

            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existed = _values.Remove(id);

            if (existed)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpGet("code/{code}")]
        public IActionResult GetByCode(int code)
        {
            switch (code)
            {
                case 200:
                    return Ok(code);
                case 201:
                    return CreatedAtAction("Get", new { id = 42 });
                case 202:
                    return AcceptedAtAction("Get", new { id = 42 });
                case 204:
                    return NoContent();
                case 301:
                    return RedirectPermanent("https://www.google.com/");
                case 302:
                    return Redirect("https://www.google.com/");
                case 400:
                    return BadRequest();
                case 401:
                    return Unauthorized();
                case 403:
                    return Forbid();
                case 404:
                    return NotFound();
                default:
                    return StatusCode(code);
            }
        }
    }
}
