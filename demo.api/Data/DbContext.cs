using demo.api.Models.V1;
using demo.api.Utils;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace demo.api.Data
{
    public class DemoApiDbContext : DbContext
    {
        public DemoApiDbContext(IConfigurationManager configurationManager) : base()
        {
            base.Database.SetConnectionString(configurationManager.PgsqlConnectionString);            
        }

        public DbSet<Product> Countries { get; set; }
    }
}
