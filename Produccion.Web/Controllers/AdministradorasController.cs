using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Produccion.Web.Data;
using Produccion.Web.Data.Entities;

namespace Produccion.Web.Controllers
{
    public class AdministradorasController : Controller
    {
        private readonly DataContext _context;

        public AdministradorasController(DataContext context)
        {
            _context = context;
        }

        // GET: Administradoras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Administradoras.ToListAsync());
        }

        // GET: Administradoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administradora = await _context.Administradoras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administradora == null)
            {
                return NotFound();
            }

            return View(administradora);
        }

        // GET: Administradoras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administradoras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoAdministradora,NombreAdministradora")] Administradora administradora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administradora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(administradora);
        }

        // GET: Administradoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administradora = await _context.Administradoras.FindAsync(id);
            if (administradora == null)
            {
                return NotFound();
            }
            return View(administradora);
        }

        // POST: Administradoras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoAdministradora,NombreAdministradora")] Administradora administradora)
        {
            if (id != administradora.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administradora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministradoraExists(administradora.Id))
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
            return View(administradora);
        }

        // GET: Administradoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administradora = await _context.Administradoras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administradora == null)
            {
                return NotFound();
            }

            return View(administradora);
        }

        // POST: Administradoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administradora = await _context.Administradoras.FindAsync(id);
            _context.Administradoras.Remove(administradora);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministradoraExists(int id)
        {
            return _context.Administradoras.Any(e => e.Id == id);
        }
    }
}
