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
    public class WeaponsController : Controller
    {
        private readonly BeyondCreatorContext _context;

        public WeaponsController(BeyondCreatorContext context)
        {
            _context = context;
        }

        // GET: Weapons
        public async Task<IActionResult> Index()
        {
            var beyondCreatorContext = _context.Weapon.Include(w => w.Dice).Include(w => w.WeaponMaterial);
            return View(await beyondCreatorContext.ToListAsync());
        }

        // GET: Weapons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Weapon == null)
            {
                return NotFound();
            }

            var weapon = await _context.Weapon
                .Include(w => w.Dice)
                .Include(w => w.WeaponMaterial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weapon == null)
            {
                return NotFound();
            }

            return View(weapon);
        }

        // GET: Weapons/Create
        public IActionResult Create()
        {
            ViewData["DiceId"] = new SelectList(_context.Set<Dice>(), "Name", "Name");
            ViewData["WeaponMaterialId"] = new SelectList(_context.Set<WeaponMaterial>(), "Name", "Name");
            return View();
        }

        // POST: Weapons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,DiceId,DiceCount,WeaponMaterialId,damageBonus,Durability,Firmness")] Weapon weapon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weapon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiceId"] = new SelectList(_context.Set<Dice>(), "Id", "Id", weapon.DiceId);
            ViewData["WeaponMaterialId"] = new SelectList(_context.Set<WeaponMaterial>(), "Id", "Id", weapon.WeaponMaterialId);
            return View(weapon);
        }

        // GET: Weapons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Weapon == null)
            {
                return NotFound();
            }

            var weapon = await _context.Weapon.FindAsync(id);
            if (weapon == null)
            {
                return NotFound();
            }
            ViewData["DiceId"] = new SelectList(_context.Set<Dice>(), "Id", "Id", weapon.DiceId);
            ViewData["WeaponMaterialId"] = new SelectList(_context.Set<WeaponMaterial>(), "Id", "Id", weapon.WeaponMaterialId);
            return View(weapon);
        }

        // POST: Weapons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,DiceId,DiceCount,WeaponMaterialId,damageBonus,Durability,Firmness")] Weapon weapon)
        {
            if (id != weapon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weapon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeaponExists(weapon.Id))
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
            ViewData["DiceId"] = new SelectList(_context.Set<Dice>(), "Id", "Id", weapon.DiceId);
            ViewData["WeaponMaterialId"] = new SelectList(_context.Set<WeaponMaterial>(), "Id", "Id", weapon.WeaponMaterialId);
            return View(weapon);
        }

        // GET: Weapons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Weapon == null)
            {
                return NotFound();
            }

            var weapon = await _context.Weapon
                .Include(w => w.Dice)
                .Include(w => w.WeaponMaterial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weapon == null)
            {
                return NotFound();
            }

            return View(weapon);
        }

        // POST: Weapons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Weapon == null)
            {
                return Problem("Entity set 'BeyondCreatorContext.Weapon'  is null.");
            }
            var weapon = await _context.Weapon.FindAsync(id);
            if (weapon != null)
            {
                _context.Weapon.Remove(weapon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeaponExists(int id)
        {
          return _context.Weapon.Any(e => e.Id == id);
        }
    }
}
