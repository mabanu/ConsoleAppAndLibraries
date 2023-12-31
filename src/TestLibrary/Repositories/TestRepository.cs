﻿using Dapper;
using SharedLibrary.Database;
using TestLibrary.Model;

namespace TestLibrary.Repositories;

public class TestRepository : ITestRepository
{
    private readonly AppDbContext _appDbContext;

    public TestRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<Test>> Get()
    {
        var connection = _appDbContext.GetConnection();

        return await connection.QueryAsync<Test>("SELECT * FROM Test;");
    }

    public async Task<Test> GetById(Guid id)
    {
        var connection = _appDbContext.GetConnection();

        return await connection.QuerySingleOrDefaultAsync<Test>("SELECT * FROM Test WHERE ID = @ID LIMIT 1;",
            new { ID = id });
    }

    public async Task CreateTest(Test test)
    {
        var connection = _appDbContext.GetConnection();

        await connection.ExecuteAsync("INSERT INTO Test (ID, TestName) VALUES (@ID, @TestName);", test);
    }
}