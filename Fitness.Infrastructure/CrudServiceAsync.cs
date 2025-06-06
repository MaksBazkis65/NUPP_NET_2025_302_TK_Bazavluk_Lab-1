using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fitness.Infrastructure
{
    public interface ICrudServiceAsync<T>
    {
        Task<bool> CreateAsync(T element);
        Task<T> ReadAsync(int id);
        Task<IEnumerable<T>> ReadAllAsync();
        Task<IEnumerable<T>> ReadAllAsync(int page, int amount);
        Task<bool> UpdateAsync(T element);
        Task<bool> RemoveAsync(T element);
        Task<bool> SaveAsync();
    }

    public class CrudServiceAsync<T> : ICrudServiceAsync<T> where T : class
    {
        private readonly IRepository<T> _repository;
        private readonly FitnessContext _context;

        public CrudServiceAsync(IRepository<T> repository, FitnessContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<bool> CreateAsync(T element)
        {
            await _repository.AddAsync(element);
            return await SaveAsync();
        }

        public async Task<bool> RemoveAsync(T element)
        {
            await _repository.Delete(element);
            return await SaveAsync();
        }

        public async Task<IEnumerable<T>> ReadAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
        {
            var all = await _repository.GetAllAsync();
            return all.Skip((page - 1) * amount).Take(amount);
        }

        public async Task<T> ReadAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(T element)
        {
            await _repository.Update(element);
            return await SaveAsync();
        }
    }
}