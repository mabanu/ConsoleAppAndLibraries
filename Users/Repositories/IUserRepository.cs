using Users.Model;

namespace Users.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUserById(Guid id);
    Task CreateUser(User user);
}