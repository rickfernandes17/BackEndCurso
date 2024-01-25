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
    public class ProdutosCategoriasController : ControllerBase
    {
        private readonly EstoqueTreinamentoContext _context;

        public ProdutosCategoriasController(EstoqueTreinamentoContext context)
        {
            _context = context;
        }

        // GET: api/ProdutosCategorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutosCategoria>>> GetProdutosCategorias()
        {
          if (_context.ProdutosCategorias == null)
          {
              return NotFound();
          }
            return await _context.ProdutosCategorias.ToListAsync();
        }

        // GET: api/ProdutosCategorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutosCategoria>> GetProdutosCategoria(int id)
        {
          if (_context.ProdutosCategorias == null)
          {
              return NotFound();
          }
            var produtosCategoria = await _context.ProdutosCategorias.FindAsync(id);

            if (produtosCategoria == null)
            {
                return NotFound();
            }

            return produtosCategoria;
        }

        // PUT: api/ProdutosCategorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutosCategoria(int id, ProdutosCategoria produtosCategoria)
        {
            if (id != produtosCategoria.Id)
            {
                return BadRequest();
            }

            _context.Entry(produtosCategoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutosCategoriaExists(id))
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

        // POST: api/ProdutosCategorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProdutosCategoria>> PostProdutosCategoria(ProdutosCategoria produtosCategoria)
        {
          if (_context.ProdutosCategorias == null)
          {
              return Problem("Entity set 'EstoqueTreinamentoContext.ProdutosCategorias'  is null.");
          }
            _context.ProdutosCategorias.Add(produtosCategoria);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProdutosCategoriaExists(produtosCategoria.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProdutosCategoria", new { id = produtosCategoria.Id }, produtosCategoria);
        }

        // DELETE: api/ProdutosCategorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutosCategoria(int id)
        {
            if (_context.ProdutosCategorias == null)
            {
                return NotFound();
            }
            var produtosCategoria = await _context.ProdutosCategorias.FindAsync(id);
            if (produtosCategoria == null)
            {
                return NotFound();
            }

            _context.ProdutosCategorias.Remove(produtosCategoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutosCategoriaExists(int id)
        {
            return (_context.ProdutosCategorias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
