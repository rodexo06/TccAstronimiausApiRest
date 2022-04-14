using Microsoft.EntityFrameworkCore;
using OurWayApiRest.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OurWayApiRest.DAL.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly OurWayContext _context;
        protected readonly DbSet<TEntity> DbSet;
        protected readonly string _connectionString;

        protected Repository(OurWayContext db)
        {
            _context = db;
            DbSet = db.Set<TEntity>();
            _connectionString = _context.Database.GetDbConnection().ConnectionString;
        }

        public virtual async Task Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            await SaveChenges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public  virtual async Task<TEntity> GetById(TEntity entity)
        {
            return await DbSet.FindAsync(entity);
        }

        public virtual async Task Insert(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChenges();
        }

        public async Task<int> SaveChenges()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChenges();
        }
    }
}
