using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaraTort.Admin.Models;
using SaraTort.DAL.Persistence;
using SaraTort.Domain.Entities.Catalog;

namespace SaraTort.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // 1. DASHBOARD (FAQAT TORTLAR)
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cakeCategory = await _context.Category
                .FirstOrDefaultAsync(c => c.Name.ToLower().Contains("tort"));

            int cakeCategoryId = cakeCategory?.Id ?? 0;

            var model = new DashboardViewModel
            {
                FaolMijozlarSoni = await _context.Users.CountAsync(),

                KatalogdagiTortlarSoni = await _context.Cakes
                    .CountAsync(c => cakeCategoryId == 0 || c.CategoryId == cakeCategoryId),

                TortlarRoyxati = await _context.Cakes
                    .Where(c => cakeCategoryId == 0 || c.CategoryId == cakeCategoryId)
                    .OrderByDescending(c => c.Id)
                    .ToListAsync()
            };

            return View(model);
        }

        // 2. PECHONIYLAR KATALOGI (FAQAT PECHONIYLAR)
        [HttpGet]
        public async Task<IActionResult> Pechoniylar()
        {
            var pechoniyCategory = await _context.Category
                .FirstOrDefaultAsync(c => c.Name.ToLower().Contains("pechoniy"));

            int pechoniyCategoryId = pechoniyCategory?.Id ?? 0;

            var model = new DashboardViewModel
            {
                FaolMijozlarSoni = await _context.Users.CountAsync(),

                KatalogdagiTortlarSoni = await _context.Cakes
                    .CountAsync(c => c.CategoryId == pechoniyCategoryId),

                TortlarRoyxati = await _context.Cakes
                    .Where(c => c.CategoryId == pechoniyCategoryId)
                    .OrderByDescending(c => c.Id)
                    .ToListAsync()
            };

            return View(model);
        }

        // 3. MIJOZLAR BAZASI
        [HttpGet]
        public async Task<IActionResult> Mijozlar()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        // 4. YANGI MAHSULOT QO'SHISH (CREATE)
        [HttpPost]
        public async Task<IActionResult> CreateCake(string Title, decimal Price, string Description, IFormFile Image)
        {
            string imageUrl = "/images/default-cake.png";

            if (Image != null && Image.Length > 0)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/cakes");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(Image.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }

                imageUrl = "/images/cakes/" + uniqueFileName;
            }

            // Standart ravishda "Tort" kategoriyasiga biriktiramiz
            var cakeCategory = await _context.Category
                .FirstOrDefaultAsync(c => c.Name.ToLower().Contains("tort"));

            var newCake = new Cake
            {
                Title = Title,
                Price = Price,
                Description = Description,
                ImageUrl = imageUrl,
                CategoryId = cakeCategory?.Id ?? 1
            };

            _context.Cakes.Add(newCake);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // 5. MAHSULOTNI TAHRIRLASH (EDIT)
        [HttpPost]
        public async Task<IActionResult> EditCake(int Id, string Title, decimal Price, string Description, IFormFile Image)
        {
            var cake = await _context.Cakes.FindAsync(Id);
            if (cake == null)
            {
                return NotFound();
            }

            cake.Title = Title;
            cake.Price = Price;
            cake.Description = Description;

            if (Image != null && Image.Length > 0)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/cakes");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(Image.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }

                cake.ImageUrl = "/images/cakes/" + uniqueFileName;
            }

            _context.Cakes.Update(cake);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // 6. MAHSULOTNI O'CHIRISH (DELETE)
        [HttpPost]
        public async Task<IActionResult> DeleteCake(int id)
        {
            var cake = await _context.Cakes.FindAsync(id);
            if (cake != null)
            {
                _context.Cakes.Remove(cake);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // 7. FILIAL TELEFON RAQAMINI YANGILASH
        [HttpPost]
        public async Task<IActionResult> UpdateBranchPhone(string Branch, string PhoneNumber)
        {
            // Bu yerda o'zingizning filiallar yoki sozlamalar jadvalingiz bilan bog'lashingiz mumkin
            // Masalan: AppSettings yoki Branches jadvalini yangilash logic-i qo'yiladi.

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}