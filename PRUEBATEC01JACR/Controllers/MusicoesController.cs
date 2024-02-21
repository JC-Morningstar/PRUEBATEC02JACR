using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRUEBATEC01JACR.Models;

namespace PRUEBATEC01JACR.Controllers
{
    public class MusicoesController : Controller
    {
        private readonly DdContext _context;

        public MusicoesController(DdContext context)
        {
            _context = context;
        }

        // GET: Musicoes
        public async Task<IActionResult> Index()
        {
            var ddContext = _context.Musicos.Include(m => m.Banda);
            return View(await ddContext.ToListAsync());
        }

        // GET: Musicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Musicos == null)
            {
                return NotFound();
            }

            var musico = await _context.Musicos
                .Include(m => m.Banda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musico == null)
            {
                return NotFound();
            }

            return View(musico);
        }

        // GET: Musicoes/Create
        public IActionResult Create()
        {
            ViewData["BandaId"] = new SelectList(_context.Bandas, "Id", "Id");
            return View();
        }

        // POST: Musicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Instrumento,Edad,BandaId")] Musico musico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BandaId"] = new SelectList(_context.Bandas, "Id", "Id", musico.BandaId);
            return View(musico);
        }

        // GET: Musicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Musicos == null)
            {
                return NotFound();
            }

            var musico = await _context.Musicos.FindAsync(id);
            if (musico == null)
            {
                return NotFound();
            }
            ViewData["BandaId"] = new SelectList(_context.Bandas, "Id", "Id", musico.BandaId);
            return View(musico);
        }

        // POST: Musicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Instrumento,Edad,BandaId")] Musico musico)
        {
            if (id != musico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicoExists(musico.Id))
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
            ViewData["BandaId"] = new SelectList(_context.Bandas, "Id", "Id", musico.BandaId);
            return View(musico);
        }

        // GET: Musicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Musicos == null)
            {
                return NotFound();
            }

            var musico = await _context.Musicos
                .Include(m => m.Banda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musico == null)
            {
                return NotFound();
            }

            return View(musico);
        }

        // POST: Musicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Musicos == null)
            {
                return Problem("Entity set 'DdContext.Musicos'  is null.");
            }
            var musico = await _context.Musicos.FindAsync(id);
            if (musico != null)
            {
                _context.Musicos.Remove(musico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicoExists(int id)
        {
          return (_context.Musicos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
