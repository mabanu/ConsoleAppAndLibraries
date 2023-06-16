using Dapper;
using SharedLibrary.Database;

namespace TestLibrary.Database;

public static class DbExtension
{
    public static void TestExtension(this AppDbContext appDbContext)
    {
        var connection = appDbContext.GetConnection();

        connection.Execute("CREATE TABLE IF NOT EXISTS Test (" +
                           "ID UUID PRIMARY KEY ," +
                           "TestName VARCHAR(50) NOT NULL);");
    }
}