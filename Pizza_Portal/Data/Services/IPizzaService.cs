using Pizza_Portal.Data.Base;
using Pizza_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Portal.Data.Services
{
    public interface IPizzaService : IEntityBaseRepository<Pizza>
    {
        Task<Pizza> GetPizzaByIdAsync(int id);
    }
}
