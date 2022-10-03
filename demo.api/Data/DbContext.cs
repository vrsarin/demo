using demo.api.Models.V1;
using demo.api.Utils;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace demo.api.Data
{
    public class DemoApiDbContext : DbContext
    {
        public DemoApiDbContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<Product> Products { get; set; }
    }
}