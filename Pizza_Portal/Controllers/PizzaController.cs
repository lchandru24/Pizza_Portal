using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizza_Portal.Data;
using Pizza_Portal.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Portal.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService _service;
        private readonly IOrdersService _ordersService;

        public PizzaController(IPizzaService service, IOrdersService ordersService)
        {
            _service = service;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            await _ordersService.DeleteAllOrderAsync();
            var allPizzas = await _service.GetAllAsync();
            return View(allPizzas);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allPizzas = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allPizzas.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString) || n.Category.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allPizzas);
        }
    }
}
