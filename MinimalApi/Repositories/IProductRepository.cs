using MinimalApi.Model;

namespace MinimalApi.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> Get();

    Task Create(Product product);
}