using demo.api.Models.V1;
using demo.api.Utils;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace demo.api.Data
{
    public class DemoApiDbContext : DbContext
    {
        private readonly IAPIConfigurationManager configurationManager;


        public DemoApiDbContext(DbContextOptions options):base(options)
        {

        }


        //public DemoApiDbContext(IAPIConfigurationManager configurationManager) : base()
        //{
        //    this.configurationManager = configurationManager;
        
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (this.configurationManager != null && !string.IsNullOrEmpty(this.configurationManager.PgsqlConnectionString))
        //    {
        //        optionsBuilder.UseNpgsql(this.configurationManager.PgsqlConnectionString);
        //    }
        //    else
        //    {
        //        optionsBuilder.UseInMemoryDatabase("LOCAL-DB");
        //    }
        //}

        public DbSet<Product> Products { get; set; }
    }
}