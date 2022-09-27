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

        public DemoApiDbContext(IAPIConfigurationManager configurationManager) : base()
        {
            this.configurationManager = configurationManager;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(this.configurationManager.PgsqlConnectionString);
            //optionsBuilder.UseNpgsql($"host=localhost;port=5432;database=demo-api-db;username=admin;password=P@ssw0d!123");
        }

        public DbSet<Product> Products { get; set; }
    }
}
