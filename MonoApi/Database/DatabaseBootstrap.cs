using Dapper;
using Microsoft.Data.Sqlite;

namespace MonoApi.Database;

public class DatabaseBootstrap : IDatabaseBootstrap
{
    private readonly DatabaseConfig _databaseConfig;

    public DatabaseBootstrap(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public void Setup()
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);

        connection.Execute("CREATE TABLE IF NOT EXISTS Product (" +
                           " Name VARCHAR(100) NOT NULL," +
                           "Description VARCHAR(1000) NULL);");
    }
}