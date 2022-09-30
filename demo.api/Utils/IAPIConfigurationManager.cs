namespace demo.api.Utils
{
    public interface IAPIConfigurationManager
    {
        string ApiBasePath { get; }
        string PgsqlConnectionString { get; }

        DbTypeEnum DbType { get; }
    }
}