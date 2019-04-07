using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Produccion.Web.Data;
using Produccion.Web.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produccion.Web.Controllers
{
    public class AdministradorasController : Controller
    {
        private IRepository repository { get; }

        public AdministradorasController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: Administradoras
        public IActionResult Index()
        {
            return View(this.repository.GetAdministradoras());
        }

        // GET: Administradoras/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administradora = this.repository.GetAdministradora(id.Value);

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
        public async Task<IActionResult> Create(Administradora administradora)
        {
            if (ModelState.IsValid)
            {
                this.repository.AddAdministradora(administradora);
                await this.repository.SaveAllAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(administradora);
        }

        // GET: Administradoras/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administradora = this.repository.GetAdministradora(id.Value);
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
        public async Task<IActionResult> Edit(Administradora administradora)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.repository.UpdateAdministradora(administradora);
                    await this.repository.SaveAllAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.repository.AdministradoraExists(administradora.Id))
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
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administradora = this.repository.GetAdministradora(id.Value);

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
            var administradora = this.repository.GetAdministradora(id);
            this.repository.RemoveAdministradora(administradora);
            await this.repository.SaveAllAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
