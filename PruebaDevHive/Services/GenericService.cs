using Microsoft.EntityFrameworkCore;
using PruebaDevHive.Repository;

namespace PruebaDevHive.Services
{
    public class GenericService<TEntity, TContext> : IGenericService<TEntity, TContext>
    where TEntity : class
    where TContext : DbContext
    {
        private readonly IGenericRepository<TEntity, TContext> _repository;

        public GenericService(IGenericRepository<TEntity, TContext> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(int id, TEntity entity)
        {
            return await _repository.UpdateAsync(id, entity);
        }



        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }



        public async Task<IEnumerable<TEntity>> GetAllFromStoredProcedureAsync(string storedProcedure)
        {
            return await _repository.GetAllFromStoredProcedureAsync(storedProcedure);
        }

    }
}
