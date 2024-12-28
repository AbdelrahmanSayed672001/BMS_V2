using BMS_V2.Data;
using BMS_V2.Models;
using BMS_V2.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BMS_V2.Controllers
{
    [Authorize(Roles =Role.ADMIN)]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.Include(x=>x.Category).ToListAsync();
            return View(products);
        }


        public async Task<IActionResult> AddProduct()
        {
            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;  
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(Product model)
        {
            if (!ModelState.IsValid) 
                return View(model);

           await _context.Products.AddAsync(model);
           await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> CategoriesIndex()
        {
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }
        public IActionResult AddCategory()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _context.Categories.AddAsync(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("CategoriesIndex");
        }

        

    }
}
