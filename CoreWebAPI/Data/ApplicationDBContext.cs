using CoreWebAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreWebAPI.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<CofeeShop> CofeeShops { get; set; }

    }
}