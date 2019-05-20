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
    }
}