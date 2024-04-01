using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IceTaskOne.Data;
using IceTaskOne.Models;

namespace IceTaskOne.Controllers
{
    public class BootsController : Controller
    {
        private readonly IceTaskOneContext _context;

        public BootsController(IceTaskOneContext context)
        {
            _context = context;
        }

        // GET: Boots
        public async Task<IActionResult> Index()
        {
            return View(await _context.Boots.ToListAsync());
        }

        // GET: Boots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boots = await _context.Boots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boots == null)
            {
                return NotFound();
            }

            return View(boots);
        }

        // GET: Boots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Price,ReleaseDate")] Boots boots)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boots);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boots);
        }

        // GET: Boots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boots = await _context.Boots.FindAsync(id);
            if (boots == null)
            {
                return NotFound();
            }
            return View(boots);
        }

        // POST: Boots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Price,ReleaseDate")] Boots boots)
        {
            if (id != boots.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boots);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BootsExists(boots.Id))
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
            return View(boots);
        }

        // GET: Boots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boots = await _context.Boots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boots == null)
            {
                return NotFound();
            }

            return View(boots);
        }

        // POST: Boots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boots = await _context.Boots.FindAsync(id);
            if (boots != null)
            {
                _context.Boots.Remove(boots);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BootsExists(int id)
        {
            return _context.Boots.Any(e => e.Id == id);
        }
    }
}
