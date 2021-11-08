using Microsoft.EntityFrameworkCore;
using Pizza_Portal.Data.Base;
using Pizza_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Portal.Data.Services
{
    public class PizzaService : EntityBaseRepository<Pizza>, IPizzaService
    {
        private readonly AppDbContext _context;
        public PizzaService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Pizza> GetPizzaByIdAsync(int id)
        {
            var PizzaDetails = await _context.Pizza.FirstOrDefaultAsync(n => n.Id == id);
            return PizzaDetails;
        }
    }
}
