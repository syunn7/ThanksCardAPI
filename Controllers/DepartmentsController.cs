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
    public class MS_ORGANIZATIONsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public MS_ORGANIZATIONsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ORGANIZATIONs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organization>>> GetORGANIZATIONs()
        {
            return await _context.Organizations.ToListAsync();
        }

        // GET: api/ORGANIZATIONs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organization>> GetMS_ORGANIZATION(long id)
        {
            var ORGANIZATION = await _context.Organizations.FindAsync(id);

            if (ORGANIZATION == null)
            {
                return NotFound();
            }

            return ORGANIZATION;
        }

        // PUT: api/ORGANIZATIONs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMS_ORGANIZATION(long id, Organization ORGANIZATION)
        {
            if (id != ORGANIZATION.Id)
            {
                return BadRequest();
            }

            _context.Entry(ORGANIZATION).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ORGANIZATIONExists(id))
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

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Organization>> PostDepartment(Organization ORGANIZATIONs)
        {
            // Parent Department には既に存在している部署が入るため、更新の対象から外す。
            if (ORGANIZATIONs.Parent != null)
            {
                _context.Organizations.Attach(ORGANIZATIONs.Parent);
            }

            _context.Organizations.Add(ORGANIZATIONs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartment", new { id = ORGANIZATIONs.Id }, ORGANIZATIONs);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMS_ORGANIZATION(long id)
        {
            var ORGANIZATIONs = await _context.Organizations.FindAsync(id);
            if (ORGANIZATIONs == null)
            {
                return NotFound();
            }

            _context.Organizations.Remove(ORGANIZATIONs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ORGANIZATIONExists(long id)
        {
            return _context.Departments.Any(e => e.Id == id);
        }
    }
}
