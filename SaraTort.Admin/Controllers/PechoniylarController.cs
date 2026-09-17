using Microsoft.AspNetCore.Mvc;
using SaraTort.Admin.Models;
using SaraTort.BLL.Services;
using SaraTort.Domain.Entities.Catalog;

namespace SaraTort.Admin.Controllers;

public class PechoniylarController : Controller
{
    private readonly CakeService _cakeService;

    public PechoniylarController(CakeService cakeService)
    {
        _cakeService = cakeService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        // CakeService xizmatidan CakeForResultDto ro'yxati keladi
        var cakeDtos = await _cakeService.GetAllAsync();

        var viewModel = new DashboardViewModel
        {
            // DTO'larni DashboardViewModel kutgan Cake obyektlariga o'giramiz
            TortlarRoyxati = cakeDtos.Select(dto => new Cake
            {
                Id = (int)dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl
            }).ToList()
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(string name, string description, decimal price, IFormFile? image)
    {
        // Yangi pechoniy yaratish mantig'i shu yerda ishlaydi
        return RedirectToAction(nameof(Index));
    }
}