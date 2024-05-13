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
    public class librosController : Controller
    {
        private readonly libreriaContext _context;

        public librosController(libreriaContext context)
        {
            _context = context;
        }

        // GET: libros
        public async Task<IActionResult> Index()
        {
            return View(await _context.libros.ToListAsync());
        }

        // GET: libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libros = await _context.libros
                .FirstOrDefaultAsync(m => m.id_Libros == id);
            if (libros == null)
            {
                return NotFound();
            }

            return View(libros);
        }

        // GET: libros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_Libros,Titulo,Autor,año_publicacion,ejemplares,Genero,id_Editorial")] libros libros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libros);
        }

        // GET: libros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libros = await _context.libros.FindAsync(id);
            if (libros == null)
            {
                return NotFound();
            }
            return View(libros);
        }

        // POST: libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_Libros,Titulo,Autor,año_publicacion,ejemplares,Genero,id_Editorial")] libros libros)
        {
            if (id != libros.id_Libros)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!librosExists(libros.id_Libros))
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
            return View(libros);
        }

        // GET: libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libros = await _context.libros
                .FirstOrDefaultAsync(m => m.id_Libros == id);
            if (libros == null)
            {
                return NotFound();
            }

            return View(libros);
        }

        // POST: libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libros = await _context.libros.FindAsync(id);
            if (libros != null)
            {
                _context.libros.Remove(libros);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool librosExists(int id)
        {
            return _context.libros.Any(e => e.id_Libros == id);
        }
    }
}
