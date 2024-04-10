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
    public class EspecialidadParaPacientesController : ControllerBase
    {
        private readonly RehabContext _context;

        public EspecialidadParaPacientesController(RehabContext context)
        {
            _context = context;
        }

        // GET: api/EspecialidadParaPacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspecialidadParaPaciente>>> GetEspecialidadParaPacientes()
        {
            return await _context.EspecialidadParaPacientes.ToListAsync();
        }

        // GET: api/EspecialidadParaPacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EspecialidadParaPaciente>> GetEspecialidadParaPaciente(decimal id)
        {
            var especialidadParaPaciente = await _context.EspecialidadParaPacientes.FindAsync(id);

            if (especialidadParaPaciente == null)
            {
                return NotFound();
            }

            return especialidadParaPaciente;
        }

        // PUT: api/EspecialidadParaPacientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecialidadParaPaciente(decimal id, EspecialidadParaPaciente especialidadParaPaciente)
        {
            if (id != especialidadParaPaciente.IdEspecialidadParaPaciente)
            {
                return BadRequest();
            }

            _context.Entry(especialidadParaPaciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadParaPacienteExists(id))
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

        // POST: api/EspecialidadParaPacientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EspecialidadParaPaciente>> PostEspecialidadParaPaciente(EspecialidadParaPaciente especialidadParaPaciente)
        {
            _context.EspecialidadParaPacientes.Add(especialidadParaPaciente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEspecialidadParaPaciente", new { id = especialidadParaPaciente.IdEspecialidadParaPaciente }, especialidadParaPaciente);
        }

        // DELETE: api/EspecialidadParaPacientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecialidadParaPaciente(decimal id)
        {
            var especialidadParaPaciente = await _context.EspecialidadParaPacientes.FindAsync(id);
            if (especialidadParaPaciente == null)
            {
                return NotFound();
            }

            _context.EspecialidadParaPacientes.Remove(especialidadParaPaciente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EspecialidadParaPacienteExists(decimal id)
        {
            return _context.EspecialidadParaPacientes.Any(e => e.IdEspecialidadParaPaciente == id);
        }
    }
}
