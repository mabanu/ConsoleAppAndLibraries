using TestLibrary.Model;

namespace TestLibrary.Repositories;

public interface ITestRepository
{
    Task<IEnumerable<TestDtoGuidProblem>> Get();
    Task<TestDtoGuidProblem> GetById(string id);
    Task CreateTest(Test test);
}