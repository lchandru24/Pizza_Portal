using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pizza_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Portal.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Pizza
                if (!context.Pizza.Any())
                {
                    context.Pizza.AddRange(new List<Pizza>()
                    {
                        new Pizza()
                        {
                            Name = "Veg Extravaganza",
                            Description = "A pizza that decidedly staggers under an overload of golden corn, exotic black olives, crunchy onions, crisp capsicum.",
                            Price = 235.00,
                            Category = "Veg",
                            ImageURL = "https://th.bing.com/th/id/R.c28cd1b72cfd5ebbfb9754dd09e305e1?rik=yudlCp1tRA60yg&riu=http%3a%2f%2fwww.dominos.co.in%2ffiles%2fitems%2fDish6-+veg+extravaganza+copy_1346593580.jpg&ehk=l1teJFMyH7a38fTCm0HbZrmjM83w2coQIi3qEMu%2fkfc%3d&risl=&pid=ImgRaw&r=0"
                        },
                        new Pizza()
                        {
                            Name = "Chicken Pizza",
                            Description = " Treat your taste buds with Double Pepper Barbecue Chicken, Peri-Peri Chicken, Chicken Tikka & Grilled Chicken Rashers.",
                            Price = 249.00,
                            Category = "Non Veg",
                            ImageURL = "https://th.bing.com/th/id/R.e45ee0da218db4c7b43abd789d790571?rik=XP5qCJZhzi%2bmyA&riu=http%3a%2f%2fwww.midlandgoodtimespizza.com%2fwp-content%2fuploads%2f2015%2f06%2fSante-Fe-Chicken-Pizza.png&ehk=RvAvet1UoiWs0X6zB1rDOhGH2fm%2bfYdlg1IBIWAlE8M%3d&risl=&pid=ImgRaw&r=0"

                        },
                        new Pizza()
                        {
                            Name = "FarmHouse",
                            Description = "A pizza that goes ballistic on veggies! Check out this mouth watering overload of crunchy, crisp capsicum, succulent mushrooms and fresh tomatoes.",
                            Price = 199.00,
                            Category = "Veg",
                            ImageURL = "https://th.bing.com/th/id/OIP.zjXsGJDK_qldBeeFET2KMgEsEs?pid=ImgDet&rs=1"
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
