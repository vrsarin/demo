﻿using Microsoft.Extensions.Configuration;
using System;

namespace demo.api.Utils
{
    public class APIConfigurationManager : IAPIConfigurationManager
    {
        private readonly IConfiguration configuration;

        public APIConfigurationManager(IConfiguration configuration)
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

        public DbTypeEnum DbType
        {
            get
            {
                DbTypeEnum dbType;
                Enum.TryParse<DbTypeEnum>(this.configuration["apiConfig:dbType"],out dbType);
                return dbType;
            }
        }

        public string PgsqlConnectionString
        {
            get
            {
                return $"Server={this.configuration["apiConfig:pgsqlHost"]};Port={this.configuration["apiConfig:pgsqlPort"]};Database={this.configuration["apiConfig:pgsqlDatabase"]};User Id={this.configuration["apiConfig:pgsqlUserId"]};Password={this.configuration["apiConfig:pgsqlPassword"]}";
            }

        }
    }
}
