using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCoreMvcGitExercise.Data;
using WebCoreMvcGitExercise.Models;

namespace WebCoreMvcGitExercise.Controllers
{
    public class PlayerClassesController : Controller
    {
        private readonly PlayersDbContext _context;

        public PlayerClassesController(PlayersDbContext context)
        {
            _context = context;
        }

        // GET: PlayerClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlayerClass.ToListAsync());
        }

        // GET: PlayerClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerClass = await _context.PlayerClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playerClass == null)
            {
                return NotFound();
            }

            return View(playerClass);
        }

        // GET: PlayerClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlayerClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Team")] PlayerClass playerClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playerClass);
        }

        // GET: PlayerClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerClass = await _context.PlayerClass.FindAsync(id);
            if (playerClass == null)
            {
                return NotFound();
            }
            return View(playerClass);
        }

        // POST: PlayerClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Team")] PlayerClass playerClass)
        {
            if (id != playerClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerClassExists(playerClass.Id))
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
            return View(playerClass);
        }

        // GET: PlayerClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerClass = await _context.PlayerClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playerClass == null)
            {
                return NotFound();
            }

            return View(playerClass);
        }

        // POST: PlayerClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerClass = await _context.PlayerClass.FindAsync(id);
            _context.PlayerClass.Remove(playerClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerClassExists(int id)
        {
            return _context.PlayerClass.Any(e => e.Id == id);
        }
    }
}
