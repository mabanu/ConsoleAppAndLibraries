using MonoApi.Model;

namespace MonoApi.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> Get();

    Task Create(Product product);
}