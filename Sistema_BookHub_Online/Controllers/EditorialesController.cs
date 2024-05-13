using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_BookHub_Online.Models;

namespace Sistema_BookHub_Online.Controllers
{
    public class EditorialesController : Controller
    {
        private readonly libreriaContext _context;

        public EditorialesController(libreriaContext context)
        {
            _context = context;
        }

        // GET: Editoriales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Editoriales.ToListAsync());
        }

        // GET: Editoriales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editoriales = await _context.Editoriales
                .FirstOrDefaultAsync(m => m.id_Editorial == id);
            if (editoriales == null)
            {
                return NotFound();
            }

            return View(editoriales);
        }

        // GET: Editoriales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Editoriales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_Editorial,Nombre,Correo,Ubicacion,Contacto")] Editoriales editoriales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editoriales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(editoriales);
        }

        // GET: Editoriales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editoriales = await _context.Editoriales.FindAsync(id);
            if (editoriales == null)
            {
                return NotFound();
            }
            return View(editoriales);
        }

        // POST: Editoriales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_Editorial,Nombre,Correo,Ubicacion,Contacto")] Editoriales editoriales)
        {
            if (id != editoriales.id_Editorial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editoriales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditorialesExists(editoriales.id_Editorial))
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
            return View(editoriales);
        }

        // GET: Editoriales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editoriales = await _context.Editoriales
                .FirstOrDefaultAsync(m => m.id_Editorial == id);
            if (editoriales == null)
            {
                return NotFound();
            }

            return View(editoriales);
        }

        // POST: Editoriales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var editoriales = await _context.Editoriales.FindAsync(id);
            if (editoriales != null)
            {
                _context.Editoriales.Remove(editoriales);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditorialesExists(int id)
        {
            return _context.Editoriales.Any(e => e.id_Editorial == id);
        }
    }
}
