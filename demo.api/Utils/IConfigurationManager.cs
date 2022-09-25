namespace demo.api.Utils
{
    public interface IConfigurationManager
    {
        string ApiBasePath { get; }
        string PgsqlConnectionString { get; }
    }
}