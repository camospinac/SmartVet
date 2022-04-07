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
    public class AnimalBreedsController : Controller
    {
        private readonly DataContext _context;

        public AnimalBreedsController(DataContext context)
        {
            _context = context;
        }

        // GET: AnimalBreeds
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnimalBreeds.ToListAsync());
        }

        // GET: AnimalBreeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnimalBreeds/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AnimalBreed animalBreed)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(animalBreed);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe una raza con el mismo nombre.");
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
            return View(animalBreed);
        }

        // GET: AnimalBreeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalBreed = await _context.AnimalBreeds.FindAsync(id);
            if (animalBreed == null)
            {
                return NotFound();
            }
            return View(animalBreed);
        }

        // POST: AnimalBreeds/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] AnimalBreed animalBreed)
        {
            if (id != animalBreed.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animalBreed);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe una raza con el mismo nombre.");
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
            return View(animalBreed);
        }

        // GET: AnimalBreeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalBreed = await _context.AnimalBreeds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animalBreed == null)
            {
                return NotFound();
            }

            return View(animalBreed);
        }

        // POST: AnimalBreeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animalBreed = await _context.AnimalBreeds.FindAsync(id);
            _context.AnimalBreeds.Remove(animalBreed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
