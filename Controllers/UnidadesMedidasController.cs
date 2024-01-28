using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndCurso.Models;

namespace BackEndCurso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesMedidasController : ControllerBase
    {
        private readonly EstoqueTreinamentoContext _context;

        public UnidadesMedidasController(EstoqueTreinamentoContext context)
        {
            _context = context;
        }

        // GET: api/UnidadesMedidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadesMedida>>> GetUnidadesMedidas()
        {
          if (_context.UnidadesMedidas == null)
          {
              return NotFound();
          }
            return await _context.UnidadesMedidas.ToListAsync();
        }

        // GET: api/UnidadesMedidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadesMedida>> GetUnidadesMedida(string id)
        {
          if (_context.UnidadesMedidas == null)
          {
              return NotFound();
          }
            var unidadesMedida = await _context.UnidadesMedidas.FindAsync(id);

            if (unidadesMedida == null)
            {
                return NotFound();
            }

            return unidadesMedida;
        }

        // PUT: api/UnidadesMedidas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidadesMedida(string id, UnidadesMedida unidadesMedida)
        {
            if (id != unidadesMedida.Sigla)
            {
                return BadRequest();
            }

            _context.Entry(unidadesMedida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadesMedidaExists(id))
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

        // POST: api/UnidadesMedidas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnidadesMedida>> PostUnidadesMedida(UnidadesMedida unidadesMedida)
        {
          if (_context.UnidadesMedidas == null)
          {
              return Problem("Entity set 'EstoqueTreinamentoContext.UnidadesMedidas'  is null.");
          }
            _context.UnidadesMedidas.Add(unidadesMedida);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UnidadesMedidaExists(unidadesMedida.Sigla))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUnidadesMedida", new { id = unidadesMedida.Sigla }, unidadesMedida);
        }

        // DELETE: api/UnidadesMedidas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnidadesMedida(string id)
        {
            if (_context.UnidadesMedidas == null)
            {
                return NotFound();
            }
            var unidadesMedida = await _context.UnidadesMedidas.FindAsync(id);
            if (unidadesMedida == null)
            {
                return NotFound();
            }

            _context.UnidadesMedidas.Remove(unidadesMedida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnidadesMedidaExists(string id)
        {
            return (_context.UnidadesMedidas?.Any(e => e.Sigla == id)).GetValueOrDefault();
        }
    }
}
