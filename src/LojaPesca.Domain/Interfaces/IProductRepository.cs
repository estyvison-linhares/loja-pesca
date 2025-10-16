using LojaPesca.Domain.Entities;

namespace LojaPesca.Domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetByCategoryAsync(string category);
    Task<IEnumerable<Product>> SearchByNameAsync(string name);
}
