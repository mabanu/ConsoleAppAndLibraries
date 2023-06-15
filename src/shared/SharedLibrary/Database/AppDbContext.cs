using System.Data;
using Microsoft.Data.Sqlite;

namespace SharedLibrary.Database;

public class AppDbContext
{
    private readonly DbConnectionString _dbConnectionString;

    public AppDbContext(DbConnectionString dbConnectionString)
    {
        _dbConnectionString = dbConnectionString;
    }

    public IDbConnection GetConnection()
    {
        return new SqliteConnection(_dbConnectionString.ConnectionString);
    }
}