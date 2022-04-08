#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartVet.Data;
using SmartVet.Data.Entities;

namespace SmartVet.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AnimalSpeciesController : Controller
    {
        private readonly DataContext _context;

        public AnimalSpeciesController(DataContext context)
        {
            _context = context;
        }

        // GET: AnimalSpecies/Index
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnimalSpecies.ToListAsync());
        }
        // GET: AnimalSpecies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnimalSpecies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnimalSpecie animalSpecie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(animalSpecie);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe una especie con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AnimalSpecie animalSpecie)
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
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe una especie con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
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

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animalSpecie = await _context.AnimalSpecies.FindAsync(id);
            _context.AnimalSpecies.Remove(animalSpecie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        }
}
