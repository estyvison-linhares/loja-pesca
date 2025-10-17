using LojaPesca.Domain;

namespace LojaPesca.Infrastructure.Repositories;

public class PecaRepositoryMock<T> : IRepository<T> where T : class
{
    private readonly List<T> _data = new();

    public Task<T?> GetByIdAsync(int id)
    {
        // Implementação mockada - retorna null por enquanto
        return Task.FromResult<T?>(null);
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<T>>(_data);
    }

    public Task AddAsync(T entity)
    {
        _data.Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(T entity)
    {
        // Implementação mockada - apenas simula atualização
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        // Implementação mockada - apenas simula exclusão
        return Task.CompletedTask;
    }

    public Task<bool> ExistsAsync(int id)
    {
        // Implementação mockada - sempre retorna false
        return Task.FromResult(false);
    }
}
