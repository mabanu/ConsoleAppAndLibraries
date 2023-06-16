using Dapper;
using Microsoft.Data.Sqlite;
using MonoApi.Database;
using MonoApi.Model;

namespace MonoApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DatabaseConfig _databaseConfig;

    public ProductRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public async Task<IEnumerable<Product>> Get()
    {
        await using var connection = new SqliteConnection(_databaseConfig.ConnectionString);

        return await connection.QueryAsync<Product>("SELECT rowid AS Id, Name, Description FROM Product;");
    }

    public async Task Create(Product product)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);

        await connection.ExecuteAsync("INSERT INTO Product (Name, Description)" +
                                      "VALUES (@Name, @Description);", product);
    }
}