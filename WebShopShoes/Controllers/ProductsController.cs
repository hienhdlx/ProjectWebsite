using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShopShoes.Models;

namespace WebShopShoes.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopGiayContext _context;

        public ProductsController(ShopGiayContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var product = await _context.Product.ToListAsync();
            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, IdModle, Image, Price, Sale, Description, CreateDate, StartTime, EndTime, IdSupplier, NameProduct")]Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}