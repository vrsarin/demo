using Microsoft.Extensions.Configuration;

namespace demo.api.Utils
{
    public class ConfigurationManager : IConfigurationManager
    {
        private readonly IConfiguration configuration;

        public ConfigurationManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public string ApiBasePath
        {
            get
            {
                return this.configuration["apiConfig:basePath"];
            }
        }

        public string PgsqlConnectionString
        {
            get
            {
                return $"host={this.configuration["apiConfig:pgsqlDBName"]};port={this.configuration["apiConfig:pgsqlPort"]};database={this.configuration["apiConfig:pgsqlDatabase"]};username={this.configuration["apiConfig:pgsqlUserId"]};password={this.configuration["apiConfig:pgsqlPassword"]}";
            }

        }
    }
}
