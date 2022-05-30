using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThanksCardAPI.Models;

namespace ThanksCardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Classification : ControllerBase
    {
        private readonly ApplicationContext _context;

        public Classification(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Tags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MS_CLASSIFICATION>>> GetTag()
        {
            return await _context.Classifications.ToListAsync();
        }

        // GET: api/Tags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MS_CLASSIFICATION>> GetTag(long id)
        {
            var Classifications = await _context.Classifications.FindAsync(id);

            if (Classifications == null)
            {
                return NotFound();
            }

            return Classifications;
        }

        // PUT: api/Tags/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMS_CLASSIFICATION(long id, MS_CLASSIFICATION Classifications)
        {
            if (id != Classifications.Id)
            {
                return BadRequest();
            }

            _context.Entry(Classifications).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MS_CLASSIFICATIONExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tags
        [HttpPost]
        public async Task<ActionResult<MS_CLASSIFICATION>> PostMS_CLASSIFICATION(MS_CLASSIFICATION Classifications)
        {
            _context.Classifications.Add(Classifications);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTag", new { id = Classifications.Id }, Classifications);
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MS_CLASSIFICATION>> DeleteMS_CLASSIFICATION(long id)
        {
            var Classifications = await _context.Classifications.FindAsync(id);
            if (Classifications == null)
            {
                return NotFound();
            }

            _context.Classifications.Remove(Classifications);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MS_CLASSIFICATIONExists(long id)
        {
            return _context.Classifications.Any(e => e.Id == id);
        }
    }
}
