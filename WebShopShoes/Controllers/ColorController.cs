using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShopShoes.Models;

namespace WebShopShoes.Controllers
{
    public class ColorController : Controller
    {
        private readonly ShopGiayContext _context;
        public ColorController(ShopGiayContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Color.ToListAsync());
        }

        // Get: color/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var colors = await _context.Color.FirstOrDefaultAsync(m => m.Id == id);
            if (colors == null)
            {
                return NotFound();
            }
            return View(colors);
        }


        //Get: Color/Create
        public IActionResult Create()
        {
            return View();
        }

        // Post: Color/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameColor")] Color color)
        {

            if (ModelState.IsValid)
            {
                _context.Add(color);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(color);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colors = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);
            if (colors == null)
                return NotFound();
            return View(colors);
        }

        // Post: Color/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colors = await _context.Color.FindAsync(id);
            _context.Color.Remove(colors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            //var a = "a";
            //var b = int.TryParse(a, out var integer) ? integer : 0;
            if (id <= 0)
                return NotFound();
            var colors = await _context.Color.FirstOrDefaultAsync(f => f.Id == id);
            if (colors == null)
                return NotFound();
            return View(colors);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameColor,CodeColor")] Color color)
        {
            if (id != color.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(color);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColorExists(color.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(color);
        }

        private bool ColorExists(int id)
        {
            return _context.Color.Any(e => e.Id == id);
        }
    }
}