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
    public class prestamosController : Controller
    {
        private readonly libreriaContext _context;

        public prestamosController(libreriaContext context)
        {
            _context = context;
        }

        // GET: prestamos
        public async Task<IActionResult> Index()
        {
            return View(await _context.prestamos.ToListAsync());
        }

        // GET: prestamos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamos = await _context.prestamos
                .FirstOrDefaultAsync(m => m.id_libro == id);
            if (prestamos == null)
            {
                return NotFound();
            }

            return View(prestamos);
        }

        // GET: prestamos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: prestamos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_libro,id_usuario,Fecha_prestamo,Estado,id_sucursal")] prestamos prestamos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestamos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prestamos);
        }

        // GET: prestamos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamos = await _context.prestamos.FindAsync(id);
            if (prestamos == null)
            {
                return NotFound();
            }
            return View(prestamos);
        }

        // POST: prestamos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_libro,id_usuario,Fecha_prestamo,Estado,id_sucursal")] prestamos prestamos)
        {
            if (id != prestamos.id_libro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!prestamosExists(prestamos.id_libro))
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
            return View(prestamos);
        }

        // GET: prestamos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamos = await _context.prestamos
                .FirstOrDefaultAsync(m => m.id_libro == id);
            if (prestamos == null)
            {
                return NotFound();
            }

            return View(prestamos);
        }

        // POST: prestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestamos = await _context.prestamos.FindAsync(id);
            if (prestamos != null)
            {
                _context.prestamos.Remove(prestamos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool prestamosExists(int id)
        {
            return _context.prestamos.Any(e => e.id_libro == id);
        }
    }
}
