using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OurWayApiRest.DAL.Repositories.Contracts
{
    public interface IRepository<TEntity> : IDisposable
    {
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<TEntity> GetById(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChenges();
    }
}
