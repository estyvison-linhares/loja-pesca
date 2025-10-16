using System.Collections.Concurrent;
using LojaPesca.Domain.Entities;
using LojaPesca.Domain.Interfaces;

namespace LojaPesca.Infrastructure.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    private readonly ConcurrentDictionary<Guid, Product> _products = new();

    public Task<Product?> GetByIdAsync(Guid id)
    {
        _products.TryGetValue(id, out var product);
        return Task.FromResult(product);
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Product>>(_products.Values);
    }

    public Task<IEnumerable<Product>> GetByCategoryAsync(string category)
    {
        if (string.IsNullOrWhiteSpace(category))
        {
            return Task.FromResult<IEnumerable<Product>>(Array.Empty<Product>());
        }
        
        var products = _products.Values.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult<IEnumerable<Product>>(products);
    }

    public Task<IEnumerable<Product>> SearchByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Task.FromResult<IEnumerable<Product>>(Array.Empty<Product>());
        }
        
        var products = _products.Values.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult<IEnumerable<Product>>(products);
    }

    public Task<Product> AddAsync(Product entity)
    {
        if (!_products.TryAdd(entity.Id, entity))
        {
            throw new InvalidOperationException($"Product with ID {entity.Id} already exists.");
        }
        return Task.FromResult(entity);
    }

    public Task UpdateAsync(Product entity)
    {
        _products[entity.Id] = entity;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        _products.TryRemove(id, out _);
        return Task.CompletedTask;
    }
}
