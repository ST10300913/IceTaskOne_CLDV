using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IceTaskOne.Data;
using System;
using System.Linq;


namespace IceTaskOne.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new IceTaskOneContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<IceTaskOneContext>>()))
            {
                // Look for any movies.
                if (context.Boots.Any())
                {
                    return;   // DB has been seeded
                }
                context.Boots.AddRange(
                    new Boots
                    {
                        Brand = "Nike",
                        ReleaseDate = DateTime.Parse("2019-6-13"),
                        Price = 2000.00M
                    },
                    new Boots
                    {
                        Brand = "Adidas",
                        ReleaseDate = DateTime.Parse("2023-3-8"),
                        Price = 5500.00M
                    },
                    new Boots
                    {
                        Brand = "Puma",
                        ReleaseDate = DateTime.Parse("2020-9-7"),
                        Price = 1500.00M
                    },
                    new Boots
                    {
                        Brand = "Asics",
                        ReleaseDate = DateTime.Parse("2024-3-25"),
                        Price = 6700.00M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
