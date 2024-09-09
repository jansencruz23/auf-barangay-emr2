using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Persistence.Repositories.Common
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : BaseDomainEntity
    {
        private readonly EmrDbContext _dbContext;

        public GenericRepository(EmrDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            var result = await _dbContext.AddAsync(entity);
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await Get(id);
            _dbContext.Remove(entity);
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<int> TotalCount()
        {
            return await _dbContext.Set<T>().AsNoTracking().CountAsync();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).OriginalValues["Version"] = entity.Version;
            _dbContext.Update(entity);
        }
    }
}
