using System.Data;
using Dapper;
using SharedLibrary.Database;
using Users.Model;

namespace Users.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbConnection _connection;

    public UserRepository(AppDbContext appDbContext)
    {
        _connection = appDbContext.GetConnection();
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _connection.QueryAsync<User>("SELECT * FROM User;");
    }

    public async Task<User> GetUserById(Guid id)
    {
        return await _connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM User WHERE ID = @ID LIMIT 1;",
            new { ID = id });
    }

    public async Task CreateUser(User user)
    {
        await _connection.ExecuteAsync("INSERT INTO User (ID, UserName) VALUES (@ID, @UserName);", user);
    }
}