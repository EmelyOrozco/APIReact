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
    public class EstadoPacientesController : ControllerBase
    {
        private readonly RehabContext _context;

        public EstadoPacientesController(RehabContext context)
        {
            _context = context;
        }

        // GET: api/EstadoPacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoPaciente>>> GetEstadoPacientes()
        {
            return await _context.EstadoPacientes.ToListAsync();
        }

        // GET: api/EstadoPacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoPaciente>> GetEstadoPaciente(decimal id)
        {
            var estadoPaciente = await _context.EstadoPacientes.FindAsync(id);

            if (estadoPaciente == null)
            {
                return NotFound();
            }

            return estadoPaciente;
        }

        // PUT: api/EstadoPacientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoPaciente(decimal id, EstadoPaciente estadoPaciente)
        {
            if (id != estadoPaciente.IdEstadoPaciente)
            {
                return BadRequest();
            }

            _context.Entry(estadoPaciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoPacienteExists(id))
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

        // POST: api/EstadoPacientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadoPaciente>> PostEstadoPaciente(EstadoPaciente estadoPaciente)
        {
            _context.EstadoPacientes.Add(estadoPaciente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoPaciente", new { id = estadoPaciente.IdEstadoPaciente }, estadoPaciente);
        }

        // DELETE: api/EstadoPacientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoPaciente(decimal id)
        {
            var estadoPaciente = await _context.EstadoPacientes.FindAsync(id);
            if (estadoPaciente == null)
            {
                return NotFound();
            }

            _context.EstadoPacientes.Remove(estadoPaciente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoPacienteExists(decimal id)
        {
            return _context.EstadoPacientes.Any(e => e.IdEstadoPaciente == id);
        }
    }
}
