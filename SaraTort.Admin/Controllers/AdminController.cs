using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaraTort.Admin.Models;
using SaraTort.BLL.DTOs.Cake;
using SaraTort.BLL.DTOs.Order;
using SaraTort.DAL.Persistence;
using SaraTort.Domain.Entities.Catalog;

namespace SaraTort.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AdminController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var today = DateTime.UtcNow.Date;

            var model = new DashboardViewModel
            {
                BugungiTushum = await _context.Orders
                    .Where(o => o.CreatedAt >= today)
                    .SumAsync(o => (decimal?)o.TotalAmount) ?? 0,

                BugungiBuyurtmalarSoni = await _context.Orders
                    .CountAsync(o => o.CreatedAt >= today),

                FaolMijozlarSoni = await _context.Users.CountAsync(),

                KatalogdagiTortlarSoni = await _context.Cakes.CountAsync(),

                OxirgiBuyurtmalar = await _context.Orders
                    .OrderByDescending(o => o.CreatedAt)
                    .Take(10)
                    .Select(o => new OrderForResultDto
                    {
                        Id = o.Id,
                        CustomerName = o.CustomerName,
                        CustomerPhone = o.CustomerPhone,
                        DeliveryAddress = o.DeliveryAddress,
                        CustomComment = o.CustomComment,
                        OrderDate = o.CreatedAt,
                        DeliveryDate = o.DeliveryDate,
                        TotalAmount = o.TotalAmount,
                        Status = o.Status,
                        PaymentStatus = o.PaymentStatus
                    })
                    .ToListAsync(),

                TortlarRoyxati = await _context.Cakes
                    .OrderByDescending(c => c.Id)
                    .ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCake([FromForm] CakeForCreateDto dto)
        {
            string imagePath = "/images/default-cake.png";

            if (dto.Image != null && dto.Image.Length > 0)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "images", "cakes");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + dto.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.Image.CopyToAsync(fileStream);
                }

                imagePath = "/images/cakes/" + uniqueFileName;
            }

            string cakeName = !string.IsNullOrWhiteSpace(dto.Name) ? dto.Name : dto.Title;
            if (string.IsNullOrWhiteSpace(cakeName))
            {
                cakeName = "Yangi Tort";
            }

            var category = await _context.Category.FirstOrDefaultAsync();

            if (category == null)
            {
                category = new Category
                {
                    Name = "Umumiy",
                    Description = "Boshlang'ich kategoriya",
                    IsActive = true
                };
                _context.Category.Add(category);
                await _context.SaveChangesAsync();
            }

            int targetCategoryId = dto.CategoryId > 0 ? (int)dto.CategoryId : category.Id;

            var newCake = new Cake
            {
                Title = cakeName,
                Name = cakeName,
                Price = dto.Price,
                Description = dto.Description ?? "",
                ImageUrl = imagePath,
                CategoryId = targetCategoryId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Cakes.Add(newCake);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> EditCake(int id, string title, decimal price, string description, IFormFile? image)
        {
            var cake = await _context.Cakes.FindAsync(id);
            if (cake == null)
            {
                return NotFound();
            }

            cake.Title = title;
            cake.Name = title;
            cake.Price = price;
            cake.Description = description ?? "";

            if (image != null && image.Length > 0)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "images", "cakes");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                cake.ImageUrl = "/images/cakes/" + uniqueFileName;
            }

            _context.Cakes.Update(cake);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

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
    }
}