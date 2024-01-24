using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeyondCreator.Data;
using BeyondCreator.Models;

namespace BeyondCreator.Controllers
{
    public class DicesController : Controller
    {
        private readonly BeyondCreatorContext _context;

        public DicesController(BeyondCreatorContext context)
        {
            _context = context;
        }

        // GET: Dices
        public async Task<IActionResult> Index()
        {
            var x = await _context.Dices.ToListAsync();
            return View(await _context.Dices.ToListAsync());
        }

        // GET: Dices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dice = await _context.Dices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dice == null)
            {
                return NotFound();
            }

            return View(dice);
        }

        // GET: Dices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Date")] Dice dice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dice);
        }

        // GET: Dices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dice = await _context.Dices.FindAsync(id);
            if (dice == null)
            {
                return NotFound();
            }
            return View(dice);
        }

        // POST: Dices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Date")] Dice dice)
        {
            if (id != dice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiceExists(dice.Id))
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
            return View(dice);
        }

        // GET: Dices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dice = await _context.Dices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dice == null)
            {
                return NotFound();
            }

            return View(dice);
        }

        // POST: Dices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dice = await _context.Dices.FindAsync(id);
            if (dice != null)
            {
                _context.Dices.Remove(dice);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiceExists(int id)
        {
            return _context.Dices.Any(e => e.Id == id);
        }
    }
}
