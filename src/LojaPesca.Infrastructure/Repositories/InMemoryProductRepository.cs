using LojaPesca.Domain.Entities;
using LojaPesca.Domain.Interfaces;

namespace LojaPesca.Infrastructure.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();

    public Task<Product?> GetByIdAsync(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(product);
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Product>>(_products);
    }

    public Task<IEnumerable<Product>> GetByCategoryAsync(string category)
    {
        var products = _products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult<IEnumerable<Product>>(products);
    }

    public Task<IEnumerable<Product>> SearchByNameAsync(string name)
    {
        var products = _products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult<IEnumerable<Product>>(products);
    }

    public Task<Product> AddAsync(Product entity)
    {
        _products.Add(entity);
        return Task.FromResult(entity);
    }

    public Task UpdateAsync(Product entity)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == entity.Id);
        if (existingProduct != null)
        {
            var index = _products.IndexOf(existingProduct);
            _products[index] = entity;
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _products.Remove(product);
        }
        return Task.CompletedTask;
    }
}
