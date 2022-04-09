using Microsoft.EntityFrameworkCore;
using OurWayApiRest.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OurWayApiRest.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> // where TEntity : Entity, new()
    {
        protected readonly OurWayContext Db;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(OurWayContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task Delete(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChenges();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task Insert(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChenges();
        }

        public async Task<int> SaveChenges()
        {
            return await Db.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChenges();
        }
    }
}
