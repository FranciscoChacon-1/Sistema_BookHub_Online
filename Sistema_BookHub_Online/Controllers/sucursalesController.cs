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
    public class sucursalesController : Controller
    {
        private readonly libreriaContext _context;

        public sucursalesController(libreriaContext context)
        {
            _context = context;
        }

        // GET: sucursales
        public async Task<IActionResult> Index()
        {
            return View(await _context.sucursales.ToListAsync());
        }

        // GET: sucursales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursales = await _context.sucursales
                .FirstOrDefaultAsync(m => m.idsucursales == id);
            if (sucursales == null)
            {
                return NotFound();
            }

            return View(sucursales);
        }

        // GET: sucursales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: sucursales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idsucursales,Nombre,Contacto")] sucursales sucursales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sucursales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sucursales);
        }

        // GET: sucursales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursales = await _context.sucursales.FindAsync(id);
            if (sucursales == null)
            {
                return NotFound();
            }
            return View(sucursales);
        }

        // POST: sucursales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idsucursales,Nombre,Contacto")] sucursales sucursales)
        {
            if (id != sucursales.idsucursales)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sucursales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sucursalesExists(sucursales.idsucursales))
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
            return View(sucursales);
        }

        // GET: sucursales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursales = await _context.sucursales
                .FirstOrDefaultAsync(m => m.idsucursales == id);
            if (sucursales == null)
            {
                return NotFound();
            }

            return View(sucursales);
        }

        // POST: sucursales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sucursales = await _context.sucursales.FindAsync(id);
            if (sucursales != null)
            {
                _context.sucursales.Remove(sucursales);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sucursalesExists(int id)
        {
            return _context.sucursales.Any(e => e.idsucursales == id);
        }
    }
}
