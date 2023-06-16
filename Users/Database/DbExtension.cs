using Dapper;
using SharedLibrary.Database;

namespace Users.Database;

public static class DbExtension
{
    public static void UserExtension(this AppDbContext appDbContext)
    {
        var connection = appDbContext.GetConnection();

        connection.Execute("CREATE TABLE IF NOT EXISTS User (" +
                           "ID UUID PRIMARY KEY ," +
                           "UserName VARCHAR(50) NOT NULL);");
    }
}