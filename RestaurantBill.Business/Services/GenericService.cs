using RestaurantBill.Core.Interfaces;

namespace RestaurantBill.Business.Services;

public class GenericService<T> : IGenericService<T> where T : class
{
    private readonly IGenericRepository<T> _generic;
    public GenericService(IGenericRepository<T> generic)
    {
        _generic = generic;
    }
    public async Task AddAsync(T entity)
    {
        await _generic.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _generic.DeleteAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>>? filter = null)
    {
        return await _generic.GetAllAsync(filter);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _generic.GetByIdAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        await _generic.UpdateAsync(entity);
    }
}
