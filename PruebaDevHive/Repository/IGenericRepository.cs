using Microsoft.EntityFrameworkCore;

namespace PruebaDevHive.Repository
{
    public interface IGenericRepository<TEntity, TContext>
    where TEntity : class
    where TContext : DbContext
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(int id, TEntity entity);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<TEntity>> GetAllFromStoredProcedureAsync(string sP);

    }
}
