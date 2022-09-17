//using System;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;

//namespace demo.api.Setup
//{
//    internal class ApplicationSettings : IApplicationSettings
//    {


//        private readonly ILogger logger;
//        private readonly IConfiguration configuration;

//        public ApplicationSettings(ILogger logger, IConfiguration configuration)
//        {
//            logger = logger;
//            this.configuration = configuration;
//        }


//        public string RedisConnection => this.GetEnvironmentVariableValue<string>(Settings.REDIS_CACHE_CONNECTION);


//        private T GetEnvironmentVariableValue<T>(string variableName, bool caching = true)
//        {            
//            T value = default;

//            if (caching)
//            {
//                // TODO: Add redis caching
//            }
//            else
//            {
//                value = this.GetFromFile<T>(variableName);

//                var envValue = Environment.GetEnvironmentVariable(variableName);

//            }
//            if (string.IsNullOrEmpty(value))
//            {
//                this.logger.LogError($"Environment Variable not found");
//            }

//            return value;
//        }

//        private T GetFromFile<T>(string variableName)
//        {
//            return this.configuration.GetValue<T>(variableName);
//        }

//        private SettingTypes IfValueExists<T>(string variableName)
//        {
//            if(configuration.GetValue<T>(variableName)!=null)
//            {
//                return SettingTypes.Application;
//            }
//        }


//        internal class Settings
//        {
//            public const string REDIS_CACHE_CONNECTION = "Redis:Cache:Connection";
//        }
//        enum SettingTypes
//        {
//            Cached=0,
//            Application=1,
//            File=2,
//            EnvironmentVariable=3,
//            None=4,
//        }

//    }
    
//}
