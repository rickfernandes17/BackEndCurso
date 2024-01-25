using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BackEndCurso.Models;

namespace BackEndCurso.Controllers
{
    public class UnidadesMedidasController : Controller
    {
        private readonly EstoqueTreinamentoContext _context;

        public UnidadesMedidasController(EstoqueTreinamentoContext context)
        {
            _context = context;
        }

        // GET: UnidadesMedidas
        public async Task<IActionResult> Index()
        {
              return _context.UnidadesMedidas != null ? 
                          View(await _context.UnidadesMedidas.ToListAsync()) :
                          Problem("Entity set 'EstoqueTreinamentoContext.UnidadesMedidas'  is null.");
        }

        // GET: UnidadesMedidas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.UnidadesMedidas == null)
            {
                return NotFound();
            }

            var unidadesMedida = await _context.UnidadesMedidas
                .FirstOrDefaultAsync(m => m.Sigla == id);
            if (unidadesMedida == null)
            {
                return NotFound();
            }

            return View(unidadesMedida);
        }

        // GET: UnidadesMedidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnidadesMedidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sigla,Descricao,CasasDecimais,Ativa,CadastradoUsuario,CadastradoData,AlteradoUsuario,AlteradoData")] UnidadesMedida unidadesMedida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadesMedida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidadesMedida);
        }

        // GET: UnidadesMedidas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.UnidadesMedidas == null)
            {
                return NotFound();
            }

            var unidadesMedida = await _context.UnidadesMedidas.FindAsync(id);
            if (unidadesMedida == null)
            {
                return NotFound();
            }
            return View(unidadesMedida);
        }

        // POST: UnidadesMedidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Sigla,Descricao,CasasDecimais,Ativa,CadastradoUsuario,CadastradoData,AlteradoUsuario,AlteradoData")] UnidadesMedida unidadesMedida)
        {
            if (id != unidadesMedida.Sigla)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadesMedida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadesMedidaExists(unidadesMedida.Sigla))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(unidadesMedida);
        }

        // GET: UnidadesMedidas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.UnidadesMedidas == null)
            {
                return NotFound();
            }

            var unidadesMedida = await _context.UnidadesMedidas
                .FirstOrDefaultAsync(m => m.Sigla == id);
            if (unidadesMedida == null)
            {
                return NotFound();
            }

            return View(unidadesMedida);
        }

        // POST: UnidadesMedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.UnidadesMedidas == null)
            {
                return Problem("Entity set 'EstoqueTreinamentoContext.UnidadesMedidas'  is null.");
            }
            var unidadesMedida = await _context.UnidadesMedidas.FindAsync(id);
            if (unidadesMedida != null)
            {
                _context.UnidadesMedidas.Remove(unidadesMedida);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadesMedidaExists(string id)
        {
          return (_context.UnidadesMedidas?.Any(e => e.Sigla == id)).GetValueOrDefault();
        }
    }
}
