using TestLibrary.Model;

namespace TestLibrary.Repositories;

public interface ITestRepository
{
    Task<IEnumerable<Test>> Get();
    Task<Test> GetById(Guid id);
    Task CreateTest(Test test);
}