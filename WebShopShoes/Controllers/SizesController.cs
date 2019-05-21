using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShopShoes.Models;

namespace WebShopShoes.Controllers
{
    public class SizesController : Controller
    {
        private readonly ShopGiayContext _context;

        public SizesController(ShopGiayContext context)
        {
            _context = context;
        }

        //get color
        public async Task<IActionResult> Index()
        {
            var size = await _context.Size.ToListAsync();
            return View(size);
        }

        //size details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var size = await _context.Size.FirstOrDefaultAsync(x => x.Id == id);
            if (size == null)
                return NotFound();
            return View(size);
        }


        //create view create size
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("Id,NameSize")]Size size)
        {
            if (ModelState.IsValid)
            {
                _context.Add(size);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(size);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var size = await _context.Size.FirstOrDefaultAsync(x => x.Id == id);
            if (size == null)
                return NotFound();
            return View(size);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id,[Bind("ID, NameSize")]Size size)
        {
            if (id != size.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(size);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SizeExit(size.Id))
                        return NotFound();
                    else
                        throw;
                }
               
                return RedirectToAction();
            }
            return View(size);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var size = await _context.Size.FirstOrDefaultAsync(x => x.Id == id);
            if (size == null)
                return NotFound();
            return View(size);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var size = await _context.Size.FindAsync(id);
            _context.Size.Remove(size);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SizeExit(int id)
        {
            return _context.Size.Any(e => e.Id == id);
        }
    }
}