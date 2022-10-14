using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCRUD.Models;

namespace MVCCRUD.Controllers
{
    public class NotasController : Controller
    {
        private readonly MVCCRUDContext _context;

        public NotasController(MVCCRUDContext context)
        {
            _context = context;
        }

        // GET: Notas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Notaests.ToListAsync());
        }

        // GET: Notas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notaests == null)
            {
                return NotFound();
            }

            var notaest = await _context.Notaests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notaest == null)
            {
                return NotFound();
            }

            return View(notaest);
        }

        // GET: Notas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Carnet,Apellidos,Nombres,IPN,IIPN,SIST,PROYEC,NF,EXCI,NFCI,IIC")] Notaest notaest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notaest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notaest);
        }

        // GET: Notas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Notaests == null)
            {
                return NotFound();
            }

            var notaest = await _context.Notaests.FindAsync(id);
            if (notaest == null)
            {
                return NotFound();
            }
            return View(notaest);
        }

        // POST: Notas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Carnet,Apellidos,Nombres,IPN,IIPN,SIST,PROYEC,NF,EXCI,NFCI,IIC")] Notaest notaest)
        {
            if (id != notaest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notaest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaestExists(notaest.Id))
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
            return View(notaest);
        }

        // GET: Notas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notaests == null)
            {
                return NotFound();
            }

            var notaest = await _context.Notaests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notaest == null)
            {
                return NotFound();
            }

            return View(notaest);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notaests == null)
            {
                return Problem("Entity set 'MVCCRUDContext.Notaests'  is null.");
            }
            var notaest = await _context.Notaests.FindAsync(id);
            if (notaest != null)
            {
                _context.Notaests.Remove(notaest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaestExists(int id)
        {
          return _context.Notaests.Any(e => e.Id == id);
        }
    }
}
