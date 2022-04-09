using OurWayApiRest.DAL.Repositories.Contracts;
using OurWayApiRest.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OurWayApiRest.DAL.Repositories
{
    public class AdressRepository : IAdressRepository
    {
        public Task Delete(Adress entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Adress>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Adress>> GetAll(Expression<Func<Adress, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Adress> GetById(Adress entity)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Adress entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChenges()
        {
            throw new NotImplementedException();
        }

        public Task Update(Adress entity)
        {
            throw new NotImplementedException();
        }
    }
}
