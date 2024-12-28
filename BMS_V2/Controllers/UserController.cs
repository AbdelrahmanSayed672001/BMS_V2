using BMS_V2.Data;
using BMS_V2.Models;
using BMS_V2.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BMS_V2.Controllers
{

    [Authorize(Roles = Role.User)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string Title)
        {
            if (string.IsNullOrEmpty(Title))
            {
                var products = await _context.Products.Include(x => x.Category).ToListAsync();
                return View(products);
            }
            var product = await _context.Products.Include(x => x.Category).Where(x => x.Title.Contains(Title)).ToListAsync();
            return View(product);
        }

        
    }
}
