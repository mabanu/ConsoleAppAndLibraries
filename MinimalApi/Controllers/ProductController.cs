using Microsoft.AspNetCore.Mvc;
using MinimalApi.Model;
using MinimalApi.Repositories;

namespace MinimalApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
        return Ok( await _productRepository.Get());
    }

    [HttpPost]
    public async Task Post([FromBody] Product product)
    {
        await _productRepository.Create(product);
    }
}