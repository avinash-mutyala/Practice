using Blog.MVC.CORE.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Blog.MVC.CORE.Models.DataContexts
{
    public class BlogDataContext : DbContext
    {
        public BlogDataContext(DbContextOptions<BlogDataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Post> Posts { get; set; }

        public IQueryable<MonthlySpecial> GetMonthlySpecials()
        {
            return new[]
                {
                    new MonthlySpecial {
                        Key = "calm",
                        Name = "California Calm Package",
                        Type = "Day Spa Package",
                        Price = 250,
                    },
                    new MonthlySpecial {
                        Key = "desert",
                        Name = "From Desert to Sea",
                        Type = "2 Day Salton Sea",
                        Price = 350,
                    },
                    new MonthlySpecial {
                        Key = "backpack",
                        Name = "Backpack Cali",
                        Type = "Big Sur Retreat",
                        Price = 620,
                    },
                    new MonthlySpecial {
                        Key = "taste",
                        Name = "Taste of California",
                        Type = "Tapas & Groves",
                        Price = 150,
                    },
                }.AsQueryable();
        }
    }
}
