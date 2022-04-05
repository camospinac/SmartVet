#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartVet.Data;
using SmartVet.Data.Entities;

namespace SmartVet.Controllers
{
    public class AnimalSpeciesController : Controller
    {
        private readonly DataContext _context;

        public AnimalSpeciesController(DataContext context)
        {
            _context = context;
        }

        // GET: AnimalSpecies
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnimalSpecies.ToListAsync());
        }

        // GET: AnimalSpecies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalSpecie = await _context.AnimalSpecies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animalSpecie == null)
            {
                return NotFound();
            }

            return View(animalSpecie);
        }

        // GET: AnimalSpecies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnimalSpecies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AnimalSpecie animalSpecie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animalSpecie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animalSpecie);
        }

        // GET: AnimalSpecies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalSpecie = await _context.AnimalSpecies.FindAsync(id);
            if (animalSpecie == null)
            {
                return NotFound();
            }
            return View(animalSpecie);
        }

        // POST: AnimalSpecies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] AnimalSpecie animalSpecie)
        {
            if (id != animalSpecie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animalSpecie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalSpecieExists(animalSpecie.Id))
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
            return View(animalSpecie);
        }

        // GET: AnimalSpecies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalSpecie = await _context.AnimalSpecies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animalSpecie == null)
            {
                return NotFound();
            }

            return View(animalSpecie);
        }

        // POST: AnimalSpecies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animalSpecie = await _context.AnimalSpecies.FindAsync(id);
            _context.AnimalSpecies.Remove(animalSpecie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalSpecieExists(int id)
        {
            return _context.AnimalSpecies.Any(e => e.Id == id);
        }
    }
}
