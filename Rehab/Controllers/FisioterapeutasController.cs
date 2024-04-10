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
    public class FisioterapeutasController : ControllerBase
    {
        private readonly RehabContext _context;

        public FisioterapeutasController(RehabContext context)
        {
            _context = context;
        }

        // GET: api/Fisioterapeutas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fisioterapeuta>>> GetFisioterapeutas()
        {
            return await _context.Fisioterapeutas.ToListAsync();
        }

        // GET: api/Fisioterapeutas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fisioterapeuta>> GetFisioterapeuta(decimal id)
        {
            var fisioterapeuta = await _context.Fisioterapeutas.FindAsync(id);

            if (fisioterapeuta == null)
            {
                return NotFound();
            }

            return fisioterapeuta;
        }

        // PUT: api/Fisioterapeutas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFisioterapeuta(decimal id, Fisioterapeuta fisioterapeuta)
        {
            if (id != fisioterapeuta.IdFisioterapeuta)
            {
                return BadRequest();
            }

            _context.Entry(fisioterapeuta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FisioterapeutaExists(id))
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

        // POST: api/Fisioterapeutas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fisioterapeuta>> PostFisioterapeuta(Fisioterapeuta fisioterapeuta)
        {
            _context.Fisioterapeutas.Add(fisioterapeuta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFisioterapeuta", new { id = fisioterapeuta.IdFisioterapeuta }, fisioterapeuta);
        }

        // DELETE: api/Fisioterapeutas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFisioterapeuta(decimal id)
        {
            var fisioterapeuta = await _context.Fisioterapeutas.FindAsync(id);
            if (fisioterapeuta == null)
            {
                return NotFound();
            }

            _context.Fisioterapeutas.Remove(fisioterapeuta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FisioterapeutaExists(decimal id)
        {
            return _context.Fisioterapeutas.Any(e => e.IdFisioterapeuta == id);
        }
    }
}
