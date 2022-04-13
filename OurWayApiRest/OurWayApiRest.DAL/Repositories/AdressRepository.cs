using OurWayApiRest.BLL.Interfaces;
using OurWayApiRest.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OurWayApiRest.DAL.Repositories
{
    public class AdressRepository : Repository<Adress>, IAdressRepository
    {
        public AdressRepository(OurWayContext db) : base(db){}

        public async Task<Adress> GetAdress(int id)
        {
            return await DbSet.FindAsync(id);
        }
    }
}
