using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rehab.Models;

namespace Rehab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DolorController : ControllerBase
    {
        private readonly RehabContext _context;

        public DolorController(RehabContext context)
        {
            _context = context;
        }

        // GET: api/Dolor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dolor>>> GetDolors()
        {
            return await _context.Dolors.ToListAsync();
        }

        // GET: api/Dolor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dolor>> GetDolor(decimal id)
        {
            var dolor = await _context.Dolors.FindAsync(id);

            if (dolor == null)
            {
                return NotFound();
            }

            return dolor;
        }

        // PUT: api/Dolor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDolor(decimal id, Dolor dolor)
        {
            if (id != dolor.IdDolor)
            {
                return BadRequest();
            }

            _context.Entry(dolor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DolorExists(id))
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

        // POST: api/Dolor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dolor>> PostDolor(Dolor dolor)
        {
            _context.Dolors.Add(dolor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDolor", new { id = dolor.IdDolor }, dolor);
        }

        // DELETE: api/Dolor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDolor(decimal id)
        {
            var dolor = await _context.Dolors.FindAsync(id);
            if (dolor == null)
            {
                return NotFound();
            }

            _context.Dolors.Remove(dolor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DolorExists(decimal id)
        {
            return _context.Dolors.Any(e => e.IdDolor == id);
        }
    }
}
